using Microsoft.AspNetCore.Mvc;
using PetProject.DataAcess;

namespace PetProject.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly PetProjectDbContext _db;
        public UserController(PetProjectDbContext db)
        {
            _db = db;
        }
        [HttpPost]
        public async Task<IActionResult> Register(string name, )
        {
            await _db.Users.AddAsync(new Domain.Entity.User({ 
                Name=name,

            }))
        }
    }
}
