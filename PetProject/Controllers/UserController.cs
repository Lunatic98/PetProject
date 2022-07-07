using Microsoft.AspNetCore.Mvc;
using PetProject.Application.Users.Queries.GetUserList;

namespace PetProject.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<UserListVm>> GetAll()
        {
            var query = new GetUserListQuery()
            {
                Id = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
