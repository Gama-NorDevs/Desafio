using Microsoft.Extensions.Configuration;
using NordTv.Domain.Entities;
using NordTv.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace NordTv.Infrastructure.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string configurationDB;
        public ActorRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            configurationDB = _configuration["ConnectionString"];
        }

        public async Task<List<Actor>> GetAllAsync()
        {
            try
            {
                using var connectionDB = new SqlConnection(configurationDB);
                var actorList = new List<Actor>();
                var sqlQuery = @" SELECT Actor.id, Actor.amount, Actor.sex, 
                                    U.id AS Id_user, U.name, U.email, U.password, 
                                    U.profile AS user_profile FROM [dbo].[Actor] Actor 
                                    JOIN [dbo].[User] U ON Actor.id_user = U.id ";

                using SqlCommand sqlCommand = new SqlCommand(sqlQuery, connectionDB);
                sqlCommand.CommandType = CommandType.Text;
                connectionDB.Open();

                var reader = await sqlCommand.ExecuteReaderAsync().ConfigureAwait(false);
                
                while (reader.Read())
                {
                    var actor = new Actor(
                                        int.Parse(reader["id"].ToString()),
                                        double.Parse(reader["amount"].ToString()),
                                        char.Parse(reader["sex"].ToString()),
                                        new User (   
                                                    int.Parse(reader["Id_user"].ToString()), reader["name"].ToString(), reader["email"].ToString(),
                                                    reader["password"].ToString(), reader["user_profile"].ToString()
                                                 )
                                        ); 


                    actorList.Add(actor);
                }

                return actorList;
            }
            catch (SqlException sqlException)
            {
                throw new Exception(sqlException.Message);
            }
            
        }
        public async Task<Actor> InsertAsync(Actor actor)
        {
            try
            {
                using var connectionDB = new SqlConnection(configurationDB);
                var sqlQuery = @" INSERT INTO 
                                    [dbo].[Actor] 
                                    (  
                                    Amount, 
                                    Sex, 
                                    Id_user)
                                VALUES (   
                                        @amount,
                                        @sex,           
                                        @id_user
                                        );
                                SELECT scope_identity();";

                using SqlCommand sqlCommand = new SqlCommand(sqlQuery, connectionDB);

                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters.AddWithValue("amount", actor.Amount);
                sqlCommand.Parameters.AddWithValue("sex", actor.Sex);
                sqlCommand.Parameters.AddWithValue("id_user", actor.User.Id);

                var sqlActorGenre = @"INSERT INTO 
                                        [dbo].[Actor_Genre] (id_actor, id_genre) 
                                            VALUES ( @id_actor, @id_genre); 
                                    SELECT scope_identity();";

                connectionDB.Open();

                var id = await sqlCommand.ExecuteScalarAsync().ConfigureAwait(false);

                foreach (Genre genre in actor.Genres)
                {
                    using SqlCommand commandRelaction = new SqlCommand(sqlActorGenre, connectionDB);

                    commandRelaction.CommandType = CommandType.Text;

                    commandRelaction.Parameters.AddWithValue("id_actor", id);
                    commandRelaction.Parameters.AddWithValue("id_genre", genre.Id);

                    await commandRelaction.ExecuteScalarAsync().ConfigureAwait(false);
                }

                connectionDB.Close();

                actor.SetId(int.Parse(id.ToString()));
                return actor;
            }
            catch (SqlException sqlException)
            {
                throw new Exception(sqlException.Message);
            }
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            try
            {
                using var connectionDB = new SqlConnection(configurationDB);
                
                var sqlQuery = $@" SELECT Actor.id, Actor.amount, Actor.sex, 
                                    U.id AS Id_user, U.name, U.email, U.password, 
                                    U.profile AS user_profile FROM [dbo].[Actor] Actor 
                                    JOIN [dbo].[User] U ON Actor.id_user = U.id 
                                    WHERE Actor.id ={id}";

                using SqlCommand sqlCommand = new SqlCommand(sqlQuery, connectionDB);
                sqlCommand.CommandType = CommandType.Text;
                connectionDB.Open();

                var reader = await sqlCommand.ExecuteReaderAsync().ConfigureAwait(false);

                while (reader.Read())
                {
                    var actor = new Actor(
                                        int.Parse(reader["id"].ToString()),
                                        double.Parse(reader["amount"].ToString()),
                                        char.Parse(reader["sex"].ToString()),
                                        new User(
                                                    int.Parse(reader["Id_user"].ToString()), reader["name"].ToString(), reader["email"].ToString(),
                                                    reader["password"].ToString(), reader["user_profile"].ToString()
                                                 )
                                        );

                    return actor;
                }

                return default;
            }
            catch (SqlException sqlException)
            {
                throw new Exception(sqlException.Message);
            }
        }
        
    }
}
