using CleanAdArch.Domain.Models.Ads;
using CleanAdArch.Domain.Models.User;

namespace CleanAdArch.Domain.Interface.Repositories;

public interface IAdsRepository
{
    public Task Save(Ads subCategoryInfo, CancellationToken cancellationToken);
    public Task<Ads?> OnById(Guid id,CancellationToken cancellationToken);
    public Task Delete(Ads like, CancellationToken cancellationToken);
}