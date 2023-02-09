using FluentValidation;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_City.DeleteCity;

public class DeleteCityValidator : AbstractValidator<DeleteCityCommand>
{
    public DeleteCityValidator()
    {
        RuleFor(command => command.Id)
            .NotNull();
    }
}