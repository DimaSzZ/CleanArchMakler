using FluentValidation;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_SubCategory.DeleteSubCategory;

public class DeleteSubCategoryValidator : AbstractValidator<DeleteSubCategoryCommand>
{
    public DeleteSubCategoryValidator()
    {
        RuleFor(command => command.categoryId).NotNull();
        RuleFor(command => command.subCategoryId).NotNull();
    }
}