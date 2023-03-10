using FluentValidation;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_SubCategory.DeleteSubCategory;

public class DeleteSubCategoryValidator : AbstractValidator<DeleteSubCategoryCommand>
{
    public DeleteSubCategoryValidator()
    {
        RuleFor(command => command.SubCategoryId).NotNull();
    }
}