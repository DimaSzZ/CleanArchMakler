using CleanAdArch.Domain.Models.Category;

namespace CleanAdArch.Domain.Interface.Repositories;

public interface ICategoryRepository
{
    public Task Save(Category? category , CancellationToken cancellationToken);

    public Task<List<Category>> GetAll(CancellationToken cancellationToken);
    public Task<Category?> OnById(Guid id,CancellationToken cancellationToken);
    
    public Task<bool> IsExistCategory(string nameCat,CancellationToken cancellationToken);
    public Task Delete(Guid id, CancellationToken cancellationToken);
}