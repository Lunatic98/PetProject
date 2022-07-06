using FluentValidation;
using PetProject.Application.Users.Queries.GetUserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Application.Users.Queries.GetUserList
{
    public class GetUserListQueryValidator : AbstractValidator<GetUserListQuery>
    {
        public GetUserListQueryValidator()
        {
            RuleFor(user=>user.Id).NotEqual(Guid.Empty);
        }
    }
}
