using MediatR;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_SubCategory.UpdateSubCategory;

public record UpdateSubCategoryCommand(Guid categoryId, Guid subCategoryId, string NewName) : IRequest;