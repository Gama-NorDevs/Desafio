using NordTv.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordTv.Domain.Interfaces.Repositories
{
    public interface IWorkRepository
    {
        Task<Work> Insert(Work work);
        Task<int> Delete(Work work);
        Task<Work> DeleteById(int id);
        Task<Work> Update(Work work);
        Task<Work> GetById(int id);
    }
}
