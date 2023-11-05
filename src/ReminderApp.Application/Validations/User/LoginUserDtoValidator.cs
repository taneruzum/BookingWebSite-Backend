using FluentValidation;
using ReminderApp.Application.Dtos.User;
using ReminderApp.Domain.Constats;

namespace ReminderApp.Application.Validations.User
{
    public class LoginUserDtoValidator : AbstractValidator<LoginUserDto>
    {
        public LoginUserDtoValidator()
        {
            RuleFor(u => u.Email).MaximumLength(100)
                .WithMessage("Email has max length 100 character")
                .NotNull().NotEmpty()
                .WithMessage("Email not null")
                .Must(Email => IsValidEmail(Email))
                .WithMessage("Enter a valid email format");

            RuleFor(u => u.Password).MaximumLength(200)
                .WithMessage("Password has max length 100 character")
                .NotNull().NotEmpty()
                .WithMessage("Password mot null")
                .Must(Password => ContainsNumber(Password))
                .WithMessage("Password must contains a number value");

        }
        private bool ContainsNumber(string password) => !string.IsNullOrEmpty(password) && password.Any(char.IsDigit);

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            return System.Text.RegularExpressions.Regex.IsMatch(email, RegexPattern.EmailFormat);
        }
    }
}
