using NordTv.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NordTv.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> InsertAsync(User user);
        Task<int> DeleteAsync(User user);
        Task<int> DeleteByIdAsync(int id);
        Task<User> UpdateAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task<User> GetByEmailAsync(string email);
        Task<List<User>> GetAllAsync();
    }
}
