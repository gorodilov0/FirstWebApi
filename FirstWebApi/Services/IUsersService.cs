using FirstWebApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Services
{

    public interface IUsersService
    {
        public List<Users> GetUsers();
        public void AddUser (Users user);
        public void RemoveUser (int id);
    }

}
