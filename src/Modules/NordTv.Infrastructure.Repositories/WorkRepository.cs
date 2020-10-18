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
    public class WorkRepository : IWorkRepository
    {
        private readonly IConfiguration _connectionfiguration;
        private readonly string connectionfigurationDB;
        public WorkRepository(IConfiguration connectionfiguration)
        {
            _connectionfiguration = connectionfiguration;
            connectionfigurationDB = _connectionfiguration["ConnectionString"];
        }

        public async Task<List<Work>> GetAllAsync()
        {
            try
            {
                using var connection = new SqlConnection(connectionfigurationDB);
                var workList = new List<Work>();
                var sqlQuery = $@"SELECT tbWork.id, tbWork.name, tbWork.budget, 
                                 tbWork.date_start, tbWork.date_end,
		                         tbWork.id_admin, tbUser.name AS nameUser, 
                                 tbUser.email, tbUser.password, tbUser.profile,
	                        	 tbWork.id_genre, tbGenre.description
                                    FROM [dbo].[Work] AS tbWork
                                    INNER JOIN [dbo].[User] AS tbUser 
                                    ON tbWork.id_admin = tbUser.id
                                    INNER JOIN [dbo].[Genre] AS tbGenre
                                    On tbWork.id_genre = tbGenre.id";

                using SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.CommandType = CommandType.Text;
                connection.Open();

                var reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

                while (reader.Read())
                {
                    var work = new Work(int.Parse(reader["id"].ToString()),
                                        new User(int.Parse(reader["id_admin"].ToString()),
                                                                reader["nameUser"].ToString(),
                                                                reader["email"].ToString(),
                                                                reader["password"].ToString(),
                                                                reader["profile"].ToString()),
                                       new Genre(int.Parse(reader["id_genre"].ToString()),
                                                                reader["description"].ToString()),
                                       reader["name"].ToString(),
                                       double.Parse(reader["budget"].ToString()),
                                       DateTime.Parse(reader["date_start"].ToString()),
                                       DateTime.Parse(reader["date_end"].ToString()));

                    workList.Add(work);
                }

                return workList;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Work> GetByIdAsync(int id)
        {
            try
            {
                using var connection = new SqlConnection(_connectionfiguration["ConnectionString"]);
                var sqlQuery = $@"SELECT tbWork.id, tbWork.name, tbWork.budget, 
                                 tbWork.date_start, tbWork.date_end,
		                         tbWork.id_admin, tbUser.name AS nameUser, 
                                 tbUser.email, tbUser.password, tbUser.profile,
	                        	 tbWork.id_genre, tbGenre.description
                                    FROM [dbo].[Work] AS tbWork
                                    INNER JOIN [dbo].[User] AS tbUser 
                                    ON tbWork.id_admin = tbUser.id
                                    INNER JOIN [dbo].[Genre] AS tbGenre
                                    On tbWork.id_genre = tbGenre.id
                                    WHERE tbWork.id={id};";

                using SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.CommandType = CommandType.Text;
                connection.Open();

                var reader = await command
                                    .ExecuteReaderAsync()
                                    .ConfigureAwait(false);

                while (reader.Read())
                {
                    var work = new Work(int.Parse(reader["id"].ToString()),
                                        new User(int.Parse(reader["id_admin"].ToString()),
                                            reader["nameUser"].ToString(),
                                            reader["email"].ToString(),
                                            reader["password"].ToString(),
                                            reader["profile"].ToString()),
                                       new Genre(int.Parse(reader["id_genre"].ToString()),
                                            reader["description"].ToString()),
                                       reader["name"].ToString(),
                                       double.Parse(reader["budget"].ToString()),
                                       DateTime.Parse(reader["date_start"].ToString()),
                                       DateTime.Parse(reader["date_end"].ToString()));

                    return work;
                }

                return default;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Work> InsertAsync(Work work)
        {
            try
            {
                using var connection = new SqlConnection(connectionfigurationDB);
                var sqlQuery = @"INSERT INTO 
                                  [dbo].[Work] (Name, 
                                        Budget, 
                                        Date_start, 
                                        Date_end,
                                        Id_admin,
                                        Id_genre) 
                               VALUES (@name, 
                                        @budget,
                                        @date_start, 
                                        @date_end,
                                        @id_admin,
                                        @id_genre); SELECT scope_identity();";

                using SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.CommandType = CommandType.Text;

                command.Parameters.AddWithValue("name", work.Name);
                command.Parameters.AddWithValue("budget", work.Budget);
                command.Parameters.AddWithValue("date_start", work.DateStart);
                command.Parameters.AddWithValue("date_end", work.DateEnd);
                command.Parameters.AddWithValue("id_admin", work.Productor.Id);
                command.Parameters.AddWithValue("id_genre", work.Genre.Id);

                var sqlActorWork = @"INSERT INTO 
                                        [dbo].[Actor_Work] (id_actor, id_work) 
                                            VALUES ( @id_actor, @id_work); 
                                    SELECT scope_identity();";

                connection.Open();

                var id = await command.ExecuteScalarAsync().ConfigureAwait(false);

                foreach (Actor actor in work.Actors)
                {
                    using SqlCommand commandRelaction = new SqlCommand(sqlActorWork, connection);

                    commandRelaction.CommandType = CommandType.Text;

                    commandRelaction.Parameters.AddWithValue("id_actor", actor.Id);
                    commandRelaction.Parameters.AddWithValue("id_work", id);

                    await commandRelaction.ExecuteScalarAsync().ConfigureAwait(false);
                }

                connection.Close();

                work.SetId(int.Parse(id.ToString()));
                return work;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
