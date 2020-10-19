using Microsoft.Extensions.Configuration;
using NordTv.Domain.Entities;
using NordTv.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace NordTv.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string configurationDB;
        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            configurationDB = _configuration["ConnectionString"];
        }

        public async Task<List<User>> GetAllAsync()
        {
            try
            {
                using var connection = new SqlConnection(_configuration["ConnectionString"]);
                var userList = new List<User>();
                var sqlQuery = @"SELECT * FROM [dbo].[User]; ";

                using SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.CommandType = CommandType.Text;
                connection.Open();

                var reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

                while (reader.Read())
                {
                    var user = new User(int.Parse(reader["id"].ToString()), 
                                        reader["name"].ToString(), 
                                        reader["email"].ToString(), 
                                        reader["password"].ToString(), 
                                        reader["profile"].ToString());


                    userList.Add(user);
                }

                return userList;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public async Task<User> GetByIdAsync(int id)
        {
            try
            {
                using var connection = new SqlConnection(_configuration["ConnectionString"]);
                var sqlQuery = $@"SELECT *
                                    FROM [dbo].[User] 
                                    WHERE id={id};";

                using SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.CommandType = CommandType.Text;
                connection.Open();

                var reader = await command
                                    .ExecuteReaderAsync()
                                    .ConfigureAwait(false);

                while (reader.Read())
                {
                    var user = new User(int.Parse(reader["id"].ToString()), 
                                        reader["name"].ToString(), 
                                        reader["email"].ToString(), 
                                        reader["password"].ToString(), 
                                        reader["profile"].ToString());

                    return user;
                }

                return default;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> GetByLoginAsync(string email)
        {
            try
            {
                using var connection = new SqlConnection(_configuration["ConnectionString"]);
                var sqlQuery = $@"SELECT *
                                    FROM [dbo].[User] 
                                    WHERE email='{email}';";

                using SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.CommandType = CommandType.Text;
                connection.Open();

                var reader = await command
                                    .ExecuteReaderAsync()
                                    .ConfigureAwait(false);

                while (reader.Read())
                {
                    var user = new User(int.Parse(reader["id"].ToString()),
                                        reader["name"].ToString(),
                                        reader["email"].ToString(),
                                        reader["password"].ToString(),
                                        reader["profile"].ToString());

                    user.InformationEmailUser(reader["Email"].ToString(),
                        reader["Password"].ToString());
                    return user;
                }

                return default;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> InsertAsync(User user)
        {
            try
            {
                using var connection = new SqlConnection(configurationDB);
                var sqlQuery = @"INSERT INTO 
                                  [dbo].[User] (Name, 
                                        Email, 
                                        Password, 
                                        Profile) 
                               VALUES (@name, 
                                        @email,
                                        @password, 
                                        @profile); SELECT scope_identity();";

                using SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.CommandType = CommandType.Text;

                command.Parameters.AddWithValue("name", user.Name);
                command.Parameters.AddWithValue("email", user.Email);
                command.Parameters.AddWithValue("password", user.Password);
                command.Parameters.AddWithValue("profile", user.Profile);

                connection.Open();

                var id = await command.ExecuteScalarAsync().ConfigureAwait(false);

                connection.Close();

                user.SetId(int.Parse(id.ToString()));
                return user;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
