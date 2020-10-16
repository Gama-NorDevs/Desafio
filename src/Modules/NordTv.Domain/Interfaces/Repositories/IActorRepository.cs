using NordTv.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NordTv.Domain.Interfaces.Repositories
{
    public interface IActorRepository
    {
        Task<Actor> Insert(Actor actor);
        Task<int> Delete(Actor actor);
        Task<Actor> DeleteById(int id);
        Task<Actor> Update(Actor actor);
        Task<Actor> GetById(int id);
        Task<List<Actor>> GetAll();
    }
}
