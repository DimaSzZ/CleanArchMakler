using CleanAdArch.Domain.Interface.Repositories;
using CleanAdArch.Domain.Models.SubCategory;
using CleanAdArch.Infrastructure.Persistence.PgDbContext;
using Microsoft.EntityFrameworkCore;

namespace CleanAdArch.Infrastructure.Repositories;

public class SubCategory : ISubCategoryRepository
{
    private readonly SupabaseDbContext _ctx;
    public SubCategory(SupabaseDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task Save(Domain.Models.SubCategory.SubCategory subCategoryInfo, CancellationToken cancellationToken)
    {
        if (_ctx.SubCategories.Contains(subCategoryInfo))
        {
            _ctx.Update(subCategoryInfo);
        }
        else
            await _ctx.SubCategories.AddAsync(subCategoryInfo, cancellationToken);

        await _ctx.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Domain.Models.SubCategory.SubCategory>> GetAll(Guid categoryId, CancellationToken cancellationToken)
    {
        return await _ctx.SubCategories
            .Where(x => x.CategoryId == categoryId)
            .ToListAsync(cancellationToken);
    }

    public async Task<Domain.Models.SubCategory.SubCategory?> OnById(Guid id, CancellationToken cancellationToken)
    {
        return await _ctx.SubCategories
            .Where(sub => sub.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task Delete(Domain.Models.SubCategory.SubCategory subCategoryInfo, CancellationToken cancellationToken)
    {
        _ctx.SubCategories.Remove(subCategoryInfo);
        await _ctx.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> IsExistSubCategory(string subCategory, Guid idCategory, CancellationToken cancellationToken)
    {
        return await _ctx.SubCategories
            .Where(sub => sub.CategoryId == idCategory && sub.SubCategoryProduct == subCategory)
            .AnyAsync(cancellationToken);
    }
}