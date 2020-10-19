using NordTv.Application.AppUser.Input;
using NordTv.Application.AppUser.Output;
using NordTv.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordTv.Application.AppUser.Interfaces
{
    public interface IUserAppService
    {
        Task<UserViewModel> InsertAsync(UserInput input);
        Task<User> GetByIdAsync(int id);
        Task<User> GetByLoginAsync(string email);
        Task<List<User>> GetAllAsync();
    }
}
