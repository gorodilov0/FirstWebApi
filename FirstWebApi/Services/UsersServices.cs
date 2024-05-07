using FirstWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Services
{
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


        public List<Users> GetUsers()
        {
             return listUsers;           
        }

        public void AddUser(Users user)
        {
            listUsers.Add(user);
        }

        public void RemoveUser(int id)
        {
            Users users = listUsers.Find(item => item.Id == id);
            listUsers.Remove(users);
        }
    }
}
