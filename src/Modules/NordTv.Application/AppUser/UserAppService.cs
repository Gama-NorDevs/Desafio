using NordTv.Application.AppUser.Input;
using NordTv.Application.AppUser.Interfaces;
using NordTv.Application.AppUser.Output;
using NordTv.Domain.Entities;
using NordTv.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordTv.Application.AppUser
{
   public class UserAppService : IUserAppService
    {

        private readonly IUserRepository _userRepository;

        public UserAppService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllAsync()
        { 
            return await _userRepository.GetAllAsync().ConfigureAwait(false);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id).ConfigureAwait(false);
        }

        public async Task<User> GetByLoginAsync(string email)
        {
            return await _userRepository.GetByLoginAsync(email).ConfigureAwait(false);
        }

        public async Task<UserViewModel> InsertAsync(UserInput input)
        {
            if (input.Profile is null)
            {
                throw new ArgumentException("Perfil associado não existe!"); ;
            }

            var user = new User(input.Name, input.Email, input.Password, input.Profile);

            if (!user.IsValid())
            {
                throw new ArgumentException("Dados do usuário são obrigatórios."); ;
            } 
            
            var id = await _userRepository
                            .InsertAsync(user)
                            .ConfigureAwait(false);

            return new UserViewModel(id.Id, user.Email, user.Name, user.Profile); ;
        }
    }

}
