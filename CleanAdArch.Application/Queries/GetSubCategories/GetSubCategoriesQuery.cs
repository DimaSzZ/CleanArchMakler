using CleanAdArch.Domain.Models.SubCategory;
using MediatR;

namespace CleanAdArch.Application.Queries.GetSubCategories;

public record GetSubCategoriesQuery(Guid CategoryId) : IRequest<List<SubCategory>>;