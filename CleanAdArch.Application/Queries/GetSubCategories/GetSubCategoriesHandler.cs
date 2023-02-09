using CleanAdArch.Domain.Interface.Repositories;
using CleanAdArch.Domain.Models.SubCategory;
using MediatR;

namespace CleanAdArch.Application.Queries.GetSubCategories;

public class GetSubCategoriesHandler : IRequestHandler<GetSubCategoriesQuery,List<SubCategory>>
{
    private readonly ISubCategoryRepository _subCategoryRepository;

    public GetSubCategoriesHandler(ISubCategoryRepository subCategoryRepository)
    {
        _subCategoryRepository = subCategoryRepository;
    }

    public async Task<List<SubCategory>> Handle(GetSubCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _subCategoryRepository.GetAll(request.CategoryId,cancellationToken);
    }
}