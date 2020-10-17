using NordTv.Application.AppUser.Input;
using NordTv.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordTv.Application.AppUser.Interfaces
{
    public interface IUserAppService
    {
        Task<User> InsertAsync(UserInput input);
        Task<int> DeleteByIdAsync(int id);
        Task<User> UpdateAsync(UserInput user);
        Task<User> GetByIdAsync(int id);
        Task<User> GetByEmailAsync(string email);
        Task<List<User>> GetAllAsync();
    }
}
