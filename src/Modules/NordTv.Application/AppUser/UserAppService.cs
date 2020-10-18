using NordTv.Application.AppUser.Input;
using NordTv.Application.AppUser.Interfaces;
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

        public Task<int> DeleteByIdAsync(int id)
        {
            return _userRepository.DeleteByIdAsync(id);
        }

        public Task<List<User>> GetAllAsync()
        {
            return _userRepository.GetAllAsync();
        }

        public Task<User> GetByEmailAsync(string email)
        {
            return _userRepository.GetByEmailAsync(email);
        }

        public Task<User> GetByIdAsync(int id)
        {
            return _userRepository.GetByIdAsync(id);
        }

        public Task<User> InsertAsync(UserInput input)
        {
            var user = new User(input.Name, input.Email, input.Password, input.Profile);
            return _userRepository.InsertAsync(user);
        }

        public Task<User> UpdateAsync(UserInput input)
        {
            throw new NotImplementedException();
        }
    }

}
