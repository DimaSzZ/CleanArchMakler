using MediatR;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_SubCategory.DeleteSubCategory;

public record DeleteSubCategoryCommand(Guid SubCategoryId) : IRequest;