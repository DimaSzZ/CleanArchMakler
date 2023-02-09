using FluentValidation;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_Category.DeleteCategory;

public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryCommand>
{
    
    public DeleteCategoryValidator()
    {
        RuleFor(command => command.Id)
            .NotNull();
    }
}