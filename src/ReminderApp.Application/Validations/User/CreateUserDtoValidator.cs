using FluentValidation;
using ReminderApp.Application.Dtos.User;
using ReminderApp.Domain.Constats;
using System.Text.RegularExpressions;

namespace ReminderApp.Application.Validations.User
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(u => u.Email).MaximumLength(100)
                .WithMessage("Email has max length 100 character")
                .NotNull().NotEmpty()
                .WithMessage("Email not null")
                .Must(Email => IsValidEmail(Email))
                .WithMessage("Enter a valid email format");

            //RuleFor(u => u.Fullname).MaximumLength(200)
            //    .WithMessage("Fullname has max length 100 character")
            //    .NotNull().NotEmpty()
            //    .WithMessage("Username mot null")
            //    .Must(Fullname => Fullname.Length > 2)
            //    .WithMessage("Fullname must be more than 2 letters")
            //    .Must(Fullname => !Regex.IsMatch(Fullname, RegexPattern.UppercaseLetter) && !string.IsNullOrEmpty(Fullname));

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
