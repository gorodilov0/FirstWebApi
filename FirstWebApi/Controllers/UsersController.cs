using FirstWebApi.Models;
using FirstWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace FirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _iUsersService;
        public UsersController (IUsersService iUsersService)
        {
            _iUsersService = iUsersService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                _iUsersService.GetUsers();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Users", "Sorry, but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult AddUser (Users user) 
        { 
            try
            {
                _iUsersService.AddUser(user);
            } 
            catch (Exception ex)
            {
                ModelState.AddModelError("Users", "Sorry, but we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult RemoveUser(int id)
        {
            try
            {
                _iUsersService.RemoveUser(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Users", "Sorry, but we have an exception");
                return BadRequest(ModelState);
            }

            return Ok();
        }
    }
}
