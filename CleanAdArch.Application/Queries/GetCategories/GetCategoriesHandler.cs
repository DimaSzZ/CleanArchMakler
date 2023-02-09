using CleanAdArch.Domain.Interface.Repositories;
using CleanAdArch.Domain.Models.Category;
using MediatR;

namespace CleanAdArch.Application.Queries.GetCategories;

public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, List<Category>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public  async Task<List<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _categoryRepository.GetAll(cancellationToken);
    }
}