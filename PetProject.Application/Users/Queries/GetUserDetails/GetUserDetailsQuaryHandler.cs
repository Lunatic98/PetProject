using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PetProject.Application.Common.Exceptions;
using PetProject.DataAcess;
using PetProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Application.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsVm>
    {
        private readonly IMapper _mapper;
        private readonly PetProjectDbContext _db;
        public GetUserDetailsQueryHandler(PetProjectDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<UserDetailsVm> Handle(GetUserDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _db.Users.FirstOrDefaultAsync(user =>
            user.Id == request.Id, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }
            return _mapper.Map<UserDetailsVm>(entity);
        }
    }
}
