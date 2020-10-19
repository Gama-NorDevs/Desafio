using NordTv.Application.AppUser.Interfaces;
using NordTv.Application.AppUser.Output;
using NordTv.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordTv.Application.AppUser
{
    public class LoginAppService : ILoginAppService
    {
        private readonly IUserRepository _userRepository;

        public LoginAppService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> LoginAsync(string email, string password)
        {
            var user = await _userRepository
                                .GetByLoginAsync(email)
                                .ConfigureAwait(false);

            if (user == default)
            {
                throw new ArgumentException("Usuário não encontrado!");
            }

            if (!user.IsEqualPassword(password))
            {
               throw new ArgumentException("Senha incorreta!");
            }

            return new UserViewModel(user.Id, user.Email, user.Name, user.Profile);
        }
    }
}
