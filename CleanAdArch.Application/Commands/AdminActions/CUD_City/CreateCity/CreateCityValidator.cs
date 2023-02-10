using FluentValidation;

namespace CleanAdArch.Application.Commands.AdminActions.CUD_City.CreateCity;

public class CreateCityValidator : AbstractValidator<CreateCityCommand>
{
    public CreateCityValidator()
    {
        RuleFor(command => command.City).NotNull().MaximumLength(168).MinimumLength(1);
    }
}