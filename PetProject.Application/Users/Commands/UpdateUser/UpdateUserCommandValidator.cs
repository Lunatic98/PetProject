using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(updateUserCommand =>
            updateUserCommand.Name).NotEmpty().MaximumLength(20);
            RuleFor(updateUserCommand =>
            updateUserCommand.Description).MaximumLength(200);
            RuleFor(updateUserCommand =>
            updateUserCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateUserCommand =>
            updateUserCommand.Password).NotEmpty();
        }
    }
}
