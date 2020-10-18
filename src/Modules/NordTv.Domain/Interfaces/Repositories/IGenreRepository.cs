using NordTv.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NordTv.Domain.Interfaces.Repositories
{
    public interface IGenreRepository
    {
        Task<Genre> GetByIdAsync (int id);
        Task<List<Genre>> GetAllAsync();
    }
}
