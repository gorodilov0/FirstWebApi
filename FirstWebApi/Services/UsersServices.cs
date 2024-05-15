using FirstWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace FirstWebApi.Services
{
    public class UsersService : IUsersService

    {
        private readonly string connectionString = "Data Source=FirstWebApi.db";
        public List<Users> GetUsers()
        {
            List<Users> users = new List<Users>();

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM Users";
                SqliteCommand command = new SqliteCommand(sql, connection);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Users user = new Users();

                        user.FirstName = reader.GetString(0);
                        user.LastName = reader.GetString(1);
                        user.Id = reader.GetInt32(2);
                        user.Login = reader.GetString(3);

                        users.Add(user);
                    }
                }
            }
            return users;
        }

        public void AddUser(Users user)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO Users " +
                    "(firstname, lastname, id, login) VALUES " +
                    "(@firstname, @lastname, @id, @login)";

                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@firstname", user.FirstName);
                    command.Parameters.AddWithValue("@lastname", user.LastName);
                    command.Parameters.AddWithValue("@id", user.Id);
                    command.Parameters.AddWithValue("@login", user.Login);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void RemoveUser(int id)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string sql = $"DELETE  FROM Users WHERE Id='{id}'";

                SqliteCommand command = new SqliteCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
