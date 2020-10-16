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

        public Task<int> DeleteById(int id)
        {
            return _userRepository.DeleteById(id);
        }

        public Task<List<User>> GetAll()
        {
            return _userRepository.GetAll();
        }

        public Task<User> GetByEmail(string email)
        {
            return _userRepository.GetByEmail(email);
        }

        public Task<User> GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public Task<User> Insert(UserInput input)
        {
            var user = new User(input.Name, input.Email, input.Password, input.Profile);
            return _userRepository.Insert(user);
        }

        public Task<User> Update(UserInput input)
        {
            throw new NotImplementedException();
        }
    }
}
