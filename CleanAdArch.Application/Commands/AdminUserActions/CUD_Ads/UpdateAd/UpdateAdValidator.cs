using CleanAdArch.Application.Validators;
using FluentValidation;

namespace CleanAdArch.Application.Commands.AdminUserActions.CUD_Ads.UpdateAd;

public class UpdateAdValidator : AbstractValidator<UpdateAdCommand>
{
    public UpdateAdValidator()
    {
        RuleFor(command => command.Id).NotNull();
        RuleFor(command => command.City).NotNull().MaximumLength(168).MaximumLength(1);
        RuleFor(command => command.Heading).NotNull().MaximumLength(50);
        RuleFor(command => command.Description).NotNull().MaximumLength(1000);
        RuleFor(command => command.Price).NotNull();
        RuleFor(command => command.Phone)
            .SetValidator(new UserPhoneValidator());
        RuleFor(command => command.CityId).NotNull();
        RuleFor(command => command.CategoryId).NotNull();
        RuleFor(command => command.SubCategoryId).NotNull();
        RuleFor(command => command.UserId).NotNull();
        RuleFor(command => command.OldPicture).NotNull();
    }
}