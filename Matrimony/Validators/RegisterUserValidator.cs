using FluentValidation;
using Matrimony.Models.DTOs;

namespace Matrimony.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Mobile)
                .NotEmpty()
                .Matches(@"^[6-9]\d{9}$")
                .WithMessage("Invalid mobile number.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8)
                .Matches("[A-Z]").WithMessage("Password must contain one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain one number.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain one special character.");
        }
    }
}
