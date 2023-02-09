using CleanAdArch.Application.Validators;
using FluentValidation;

namespace CleanAdArch.Application.Commands.Auth.Registration;

public class RegistrationCommandValidator : AbstractValidator<RegistrationCommand>
{
    public RegistrationCommandValidator()
    {
        RuleFor(command => command.Email)
            .NotEmpty()
            .EmailAddress();
        RuleFor(command => command.Name)
            .NotEmpty()
            .MaximumLength(25);
        RuleFor(command => command.SecondName)
            .NotEmpty()
            .MaximumLength(25);
        RuleFor(command => command.Password)
            .SetValidator(new UserPasswordValidator());
        RuleFor(commands => commands.Phone)
            .SetValidator(new UserPhoneValidator());
    }
}