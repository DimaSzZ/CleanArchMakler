using CleanAdArch.Application.Validators;
using FluentValidation;

namespace CleanAdArch.Application.Commands.AdminUserActions.CUD_Ads.CreateAd;

public class CreateAdValidator : AbstractValidator<CreateAdCommand>
{
    public  CreateAdValidator()
    {
        RuleFor(command => command.City).NotNull().MaximumLength(168).MinimumLength(1);
        RuleFor(command => command.Heading).NotNull().MaximumLength(50);
        RuleFor(command => command.Description).NotNull().MaximumLength(1000);
        RuleFor(command => command.Phone)
            .SetValidator(new UserPhoneValidator());
        RuleFor(command => command.CityId).NotNull();
        RuleFor(command => command.CategoryId).NotNull();
        RuleFor(command => command.SubCategoryId).NotNull();
        RuleFor(command => command.Price).NotNull();
    }
}