using MediatR;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_SubCategory.CreateSubCategory;

public record CreateSubCategoryCommand(Guid IdCategory ,string SubCategory) : IRequest;