using CleanAdArch.Application.Validators;
using FluentValidation;

namespace CleanAdArch.Application.Commands.Auth.ChangePassword;

public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordValidator()
    {
        RuleFor(command => command.OldPassword)
            .SetValidator(new UserPasswordValidator());
        RuleFor(command => command.NewPassword)
            .SetValidator(new UserPasswordValidator())
            .NotEqual(command => command.OldPassword);
    }
}