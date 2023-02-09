using CleanAdArch.Domain.Models.SubCategory;

namespace CleanAdArch.Domain.Interface.Repositories;

public interface ISubCategoryRepository
{
    public Task Save(SubCategory subCategoryInfo, CancellationToken cancellationToken);
    
    public Task<List<SubCategory>> GetAll(Guid categoryId, CancellationToken cancellationToken);
    public Task<SubCategory?> OnById(Guid id,CancellationToken cancellationToken);
    public Task Delete(SubCategory subCategoryInfo, CancellationToken cancellationToken);

    public Task<bool> IsExistSubCategory(string subCategory,Guid idCategory, CancellationToken cancellationToken);
}