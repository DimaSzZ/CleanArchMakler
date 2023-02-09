using FluentValidation;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_City.UpdateCity;

public class UpdateCityValidator : AbstractValidator<UpdateCityCommand>
{
    public UpdateCityValidator()
    {
        RuleFor(command => command.Id)
            .NotNull();
        RuleFor(command => command.City)
            .NotNull()
            .MaximumLength(168)
            .MinimumLength(1);   
    }
}