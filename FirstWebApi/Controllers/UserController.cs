using FirstWebApi.Models;
using FirstWebApi.Services;
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

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _iUsersService.GetUsers();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult AddUser (Users user) 
        { 
           _iUsersService.AddUser(user);
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult RemoveUser(int id)
        {
            _iUsersService.RemoveUser(id);
            return Ok();

        }
    }
}
