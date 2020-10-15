using NordTv.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordTv.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<Actor> Insert(Actor user);
        Task<Actor> GetById(int id);
        Task<List<Actor>> Get();
    }
}
