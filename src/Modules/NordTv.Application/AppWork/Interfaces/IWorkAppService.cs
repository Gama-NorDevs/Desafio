using NordTv.Application.AppWork.Input;
using NordTv.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NordTv.Application.AppWork.Interfaces
{
    public interface IWorkAppService
    {
        public Task<Work> InsertAsync(WorkInput input);
        public Task<Work> GetByIdAsync(int id);
        public Task<List<Work>> GetAllAsync();
    }
}
