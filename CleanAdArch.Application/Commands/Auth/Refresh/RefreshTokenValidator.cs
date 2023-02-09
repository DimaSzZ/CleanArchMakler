using FluentValidation;

namespace CleanAdArch.Application.Commands.Auth.Refresh;

public class RefreshTokenValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenValidator()
    {
        RuleFor(command => command.Email).NotNull();
        RuleFor(command => command.RefreshToken).NotNull();
    }
}