using CleanAdArch.Domain.Models.Ads;

namespace CleanAdArch.Domain.Interface.Repositories;

public interface ISearchRepository
{
    public Task<List<AdsShort>> Search(string? Heading,Guid ?Category, Guid ?SubCategory , string? City,CancellationToken cancellationToken);
}