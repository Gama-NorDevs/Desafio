using NordTv.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NordTv.Domain.Interfaces.Repositories
{
    public interface IWorkRepository
    {
        Task<Work> InsertAsync(Work work);
        Task<Work> GetByIdAsync(int id);
        Task<List<Work>> GetAllAsync();
    }
}
