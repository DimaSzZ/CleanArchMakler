using CleanAdArch.Domain.Interface.Repositories;
using CleanAdArch.Domain.Models.Ads;
using MediatR;

namespace CleanAdArch.Application.Queries.Search;

public class SearchQueryHandler : IRequestHandler<SearchQuery,List<AdsShort>>
{
    private readonly ISearchRepository _searchRepository;

    public SearchQueryHandler(ISearchRepository searchRepository)
    {
        _searchRepository = searchRepository;
    }

    public async Task<List<AdsShort>> Handle(SearchQuery request, CancellationToken cancellationToken)
    {
        return await _searchRepository.Search(request.Heading,request.Category,request.SubCategory,request.City,cancellationToken);
    }
}