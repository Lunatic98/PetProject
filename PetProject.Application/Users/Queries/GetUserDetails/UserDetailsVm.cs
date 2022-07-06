using PetProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PetProject.Application.Mapping;

namespace PetProject.Application.Users.Queries.GetUserDetails
{
    public class UserDetailsVm : IMapWith<User>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailsVm>()
                .ForMember(userVm => userVm.Name,
                opt => opt.MapFrom(user => user.Name))
                .ForMember(userVm => userVm.Id,
                opt => opt.MapFrom(user => user.Id))
                .ForMember(userVm => userVm.CreatedDate,
                opt => opt.MapFrom(user => user.CreatedDate))
                .ForMember(userVm => userVm.UpdateDate,
                opt => opt.MapFrom(user => user.UpdateDate));
        }
    }
}
