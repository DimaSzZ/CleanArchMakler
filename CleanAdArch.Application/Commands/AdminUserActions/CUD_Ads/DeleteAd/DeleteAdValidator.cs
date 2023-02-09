using FluentValidation;

namespace CleanAdArch.Application.Commands.AdminUserActions.CUD_Ads.DeleteAd;

public class DeleteAdValidator : AbstractValidator<DeleteAdCommand>
{
    public DeleteAdValidator()
    {
        RuleFor(command => command.AdId).NotNull();
        RuleFor(command => command.UserId).NotNull();
    }
}