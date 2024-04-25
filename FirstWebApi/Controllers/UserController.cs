using FirstWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersService _iUsersService;
        public UserController (IUsersService iUsersService)
        {
            _iUsersService = iUsersService;
        }

        public IActionResult GetUsers()
        {
            return _iUsersService.GetUsers();
        }

        [HttpPost]
        public IActionResult AddUser (Users user) 
        { 
           return _iUsersService.AddUser(user);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveUser(int id)
        {

            return _iUsersService.RemoveUser(id);

        }
    }
}
