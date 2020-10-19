using NordTv.Application.AppUser.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordTv.Application.AppUser.Interfaces
{
    public interface ILoginAppService
    {
        Task<UserViewModel> LoginAsync(string email, string password);
    }
}
