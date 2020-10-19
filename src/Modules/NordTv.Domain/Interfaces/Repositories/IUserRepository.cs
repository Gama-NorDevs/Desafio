using NordTv.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NordTv.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> InsertAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task<User> GetByLoginAsync(string email);
        Task<List<User>> GetAllAsync();
    }
}
