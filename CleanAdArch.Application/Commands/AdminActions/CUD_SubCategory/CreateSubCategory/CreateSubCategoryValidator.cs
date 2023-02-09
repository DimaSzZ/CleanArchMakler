using FluentValidation;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_SubCategory.CreateSubCategory;

public class CreateSubCategoryValidator : AbstractValidator<CreateSubCategoryCommand>
{
    private CreateSubCategoryValidator()
    {
        RuleFor(command => command.SubCategory).NotNull().MaximumLength(40);
    }
    
}