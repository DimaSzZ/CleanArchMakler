using CleanAdArch.Domain.Interface.Repositories;
using CleanAdArch.Domain.Models.Category;
using CleanAdArch.Infrastructure.Persistence.PgDbContext;
using Microsoft.EntityFrameworkCore;

namespace CleanAdArch.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly SupabaseDbContext _ctx;

    public CategoryRepository(
        SupabaseDbContext ctx
    )
    {
        _ctx = ctx;
    }

    public async Task Save(Category? category, CancellationToken cancellationToken)
    {
        if (_ctx.Categories.Contains(category))
        {
            _ctx.Update(category);
        }
        else
            await _ctx.Categories.AddAsync(category, cancellationToken);

        await _ctx.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Category>> GetAll(CancellationToken cancellationToken)
    {
        return await _ctx.Categories.ToListAsync(cancellationToken);
    }

    public async Task<Category?> OnById(Guid id, CancellationToken cancellationToken)
    {
        return await _ctx.Categories
            .Where(cat => cat.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<bool> IsExistCategory(string nameCat, CancellationToken cancellationToken)
    {
        return await _ctx.Categories
            .Where(cat => cat.CategoryProduct == nameCat)
            .AnyAsync(cancellationToken);
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        var category = await _ctx.Categories.Where(x => id == x.Id).FirstAsync(cancellationToken: cancellationToken);
        _ctx.Categories.Remove(category);
        await _ctx.SaveChangesAsync(cancellationToken);
    }
}