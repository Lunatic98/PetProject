using PetProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PetProject.Application.Mapping;
using AutoMapper;

namespace PetProject.Application.Users.Queries.GetUserList
{
    public class UserLookupDto : IMapWith<User>
    {
        public Guid Id { get; set; }
        public Guid Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserLookupDto>()
                .ForMember(userDto => userDto.Id,
                opt => opt.MapFrom(user => user.Id))
                .ForMember(userDto => userDto.Name,
                opt => opt.MapFrom(userDto => userDto.Name));
        }
    }
}
