using NordTv.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NordTv.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> Insert(User user);
        Task<int> Delete(User user);
        Task<int> DeleteById(int id);
        Task<User> Update(User user);
        Task<User> GetById(int id);
        Task<User> GetByEmail(string email);
        Task<List<User>> GetAll();
    }
}
