using Microsoft.Extensions.Configuration;
using NordTv.Domain.Entities;
using NordTv.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

        public Task<int> DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllAsync()
        {
            try
            {
                using var con = new SqlConnection(_configuration["ConnectionString"]);
                var userList = new List<User>();
                var sqlCmd = @"SELECT * FROM [dbo].[User]; ";

                using SqlCommand cmd = new SqlCommand(sqlCmd, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false);

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

        public async Task<User> GetByEmailAsync(string email)
        {
            try
            {
                using var con = new SqlConnection(_configuration["ConnectionString"]);
                var sqlCmd = $@"SELECT *
                                    FROM [dbo].[User] 
                                    WHERE email={email};";

                using SqlCommand cmd = new SqlCommand(sqlCmd, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                var reader = await cmd
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

        public async Task<User> GetByIdAsync(int id)
        {
            try
            {
                using var con = new SqlConnection(_configuration["ConnectionString"]);
                var sqlCmd = $@"SELECT *
                                    FROM [dbo].[User] 
                                    WHERE id={id};";

                using SqlCommand cmd = new SqlCommand(sqlCmd, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                var reader = await cmd
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

        public async Task<User> InsertAsync(User user)
        {
            try
            {
                using var con = new SqlConnection(configurationDB);
                var sqlCmd = @"INSERT INTO 
                                  [dbo].[User] (Name, 
                                        Email, 
                                        Password, 
                                        Profile) 
                               VALUES (@name, 
                                        @email,
                                        @password, 
                                        @profile); SELECT scope_identity();";

                using SqlCommand cmd = new SqlCommand(sqlCmd, con);

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("name", user.Name);
                cmd.Parameters.AddWithValue("email", user.Email);
                cmd.Parameters.AddWithValue("password", user.Password);
                cmd.Parameters.AddWithValue("profile", user.Profile);

                con.Open();

                var id = await cmd.ExecuteScalarAsync().ConfigureAwait(false);

                con.Close();

                user.SetId(int.Parse(id.ToString()));
                return user;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<User> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
