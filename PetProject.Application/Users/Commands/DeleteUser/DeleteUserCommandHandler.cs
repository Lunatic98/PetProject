using MediatR;
using PetProject.Domain.Entity;
using PetProject.DataAcess;
using PetProject.Application.Common.Exceptions;

namespace PetProject.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly PetProjectDbContext _db;
        public DeleteUserCommandHandler(PetProjectDbContext db)
        {
            _db = db;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _db.Users.FindAsync(new object[] {request.Id}, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            _db.Users.Remove(entity);
            await _db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
