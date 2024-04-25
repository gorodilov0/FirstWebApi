using FirstWebApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi
{
    

    public interface IUsersService
    {
        IActionResult GetUsers();
        IActionResult AddUser(Users user);
        IActionResult RemoveUser(int id);
    }

    public class UsersService : IUsersService

    {
        private static List<Users> listUsers = new List<Users>()
        {
            new Users()
            {
                FirstName = "Ivan",
                LastName = "Ivanov",
                Id = 0,
                Login = "IvaIva"
            },

            new Users()
            {
                FirstName = "Sergey",
                LastName = "Sergeev",
                Id = 1,
                Login = "Serega"
            },

            new Users()
            {
                FirstName = "Nikita",
                LastName = "Nikitin",
                Id = 2,
                Login = "Nik"
            }
        };

        [HttpGet]
        IActionResult IUsersService.GetUsers()
        {
            if (listUsers.Count > 0)
            {
                return Ok(listUsers);
            }
            return NoContent();
        }

        IActionResult IUsersService.AddUser(Users user)
        {
            listUsers.Add(user);
            return Ok();
        }

        IActionResult IUsersService.RemoveUser(int id)
        {
            Users users = listUsers.Find(item => item.Id == id);

            if (users != null)
            {
                listUsers.Remove(users);
            }

            return NoContent();
        }
    }

}
