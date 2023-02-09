using CleanAdArch.Domain.Models.Category;
using MediatR;

namespace CleanAdArch.Application.Queries.GetCategories;

public record GetCategoriesQuery() : IRequest<List<Category>>;