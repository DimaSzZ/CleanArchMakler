using FluentValidation;


namespace CleanAdArch.Application.Commands.AdminActions.CUD_Category.UpdateCategory;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryValidator()
    {
        RuleFor(command => command.Id)
            .NotNull();
        RuleFor(command => command.Category)
            .NotNull()
            .MaximumLength(40);
    }
}