using FluentValidation;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_Category.CreateCategory;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        RuleFor(command => command.Category)
            .NotNull()
            .MaximumLength(40);
    }
}