using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PetProject.DataAcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Application.Users.Queries.GetUserList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserListVm>
    {
        private readonly PetProjectDbContext _db;
        private readonly IMapper _mapper;
        public GetUserListQueryHandler(PetProjectDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<UserListVm> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var usersQuery = await _db.Users.Where(user => user.Id == request.Id)
                .ProjectTo<UserLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return new UserListVm { Users = usersQuery };
        }
    }
}
