using FluentValidation;

namespace CleanAdArch.Application.Commands.Auth.Revoke;

public class RevokeTokenValidator : AbstractValidator<RevokeTokenCommand>
{
    public RevokeTokenValidator()
    {
        RuleFor(command => command.RefreshToken).NotEmpty();
    }
    
}