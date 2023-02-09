using FluentValidation;

namespace CleanAdArch.Application.Validators;

public class UserPhoneValidator : AbstractValidator<string>
{
    public UserPhoneValidator()
    {
        RuleFor(Phone => Phone)
            .NotEmpty()
            .MaximumLength(18)
            .Must(IsPhoneValid);
    }
    private bool IsPhoneValid(string phone)
    {
        return !(!phone.StartsWith("+79")
                 || !phone.Substring(1).All(c => Char.IsDigit(c)));
    }
}
