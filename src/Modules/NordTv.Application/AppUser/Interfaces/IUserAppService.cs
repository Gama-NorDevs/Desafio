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
        Task<User> Insert(UserInput input);
        Task<int> DeleteById(int id);
        Task<User> Update(UserInput user);
        Task<User> GetById(int id);
        Task<User> GetByEmail(string email);
        Task<List<User>> GetAll();
    }
}
