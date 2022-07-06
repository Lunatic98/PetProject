using PetProject.DataAcess;
using MediatR;
using PetProject.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using PetProject.Application.Common.Exceptions;

namespace PetProject.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly PetProjectDbContext _db;
        public UpdateUserCommandHandler(PetProjectDbContext db)
        {
            _db = db;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _db.Users.FirstOrDefaultAsync(user =>
                    user.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }
            entity.Name = request.Name;
            entity.Email = request.Email;
            entity.Password = request.Password;
            entity.UpdateDate = DateTime.Now;
            entity.Description = request.Description;

            await _db.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
