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
    public class GenreRepository : IGenreRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string configurationDB;
        public GenreRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            configurationDB = _configuration["ConnectionString"];
        }

        public async Task<List<Genre>> GetAllAsync()
        {
            try
            {
                using var con = new SqlConnection(configurationDB);
                var genreList = new List<Genre>();
                var sqlCmd = @"SELECT * FROM [dbo].[Genre]; ";

                using SqlCommand cmd = new SqlCommand(sqlCmd, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false);

                while (reader.Read())
                {
                    var genre = new Genre(int.Parse(reader["id"].ToString()),
                                        reader["description"].ToString());


                    genreList.Add(genre);
                }

                return genreList;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            try
            {
                using var con = new SqlConnection(_configuration["ConnectionString"]);
                var sqlCmd = $@"SELECT *
                                    FROM [dbo].[Genre] 
                                    WHERE id={id};";

                using SqlCommand cmd = new SqlCommand(sqlCmd, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                var reader = await cmd
                                    .ExecuteReaderAsync()
                                    .ConfigureAwait(false);

                while (reader.Read())
                {
                    var genre = new Genre(int.Parse(reader["id"].ToString()),
                                        reader["description"].ToString());

                    return genre;
                }

                return default;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
