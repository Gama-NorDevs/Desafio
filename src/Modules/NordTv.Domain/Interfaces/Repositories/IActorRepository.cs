using NordTv.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NordTv.Domain.Interfaces.Repositories
{
    public interface IActorRepository
    {
        Task<Actor> InsertAsync(Actor actor);
        Task<Actor> GetByIdAsync(int id);
        Task<List<Actor>> GetAllAsync();
    }
}
