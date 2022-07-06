using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(registerUserCommand =>
            registerUserCommand.Name).NotEmpty().MaximumLength(20);
            RuleFor(registerUserCommand =>
            registerUserCommand.Description).MaximumLength(200);
            RuleFor(registerUserCommand =>
            registerUserCommand.Id).NotEqual(Guid.Empty);
        }

    }
}
