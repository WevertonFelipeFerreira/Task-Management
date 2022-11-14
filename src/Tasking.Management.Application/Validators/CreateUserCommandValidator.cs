using FluentValidation;
using System.Text.RegularExpressions;
using Tasking.Management.Application.Commands.CreateUser;

namespace Tasking.Management.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            //TODO create message resource
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Required field.")
                .Must(ValidEmail!)
                .WithMessage("Invalid Email.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Required field.")
                .Must(ValidPassword!)
                .WithMessage("Invalid or weak Password.");

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Invalid Name");

            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Invalid LastName");
        }

        private bool ValidPassword(string password)
        {
            var regex = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$");
            return password != null ? regex.IsMatch(password) : false!;
        }

        private bool ValidEmail(string email)
        {
            var regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return email != null ? regex.IsMatch(email) : false!;
        }
    }
}
