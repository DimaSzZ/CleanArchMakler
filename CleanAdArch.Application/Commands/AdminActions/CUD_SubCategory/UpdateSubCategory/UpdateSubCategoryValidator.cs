using FluentValidation;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_SubCategory.UpdateSubCategory;

public class UpdateSubCategoryValidator : AbstractValidator<UpdateSubCategoryCommand>
{
    public UpdateSubCategoryValidator()
    {
        RuleFor(command => command.NewName).NotNull().MaximumLength(40);
        RuleFor(command => command.categoryId).NotNull();
        RuleFor(command => command.subCategoryId).NotNull();
    }
}