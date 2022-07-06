using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using PetProject.Domain.Entity;
using PetProject.DataAcess;

namespace PetProject.Application.Users.Commands.RegisterUser
{
    
    public class RegisterUserCommandHandler
        :IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly PetProjectDbContext _db;
        public async Task<Guid> Handle(RegisterUserCommand request,
            CancellationToken cancellationToken)
        {
            var user = new User
            {
              Id = Guid.NewGuid(),
              Name = request.Name,
              Email = request.Email,
              Password = request.Password
            };
            return user.Id;
        }
    }
}
