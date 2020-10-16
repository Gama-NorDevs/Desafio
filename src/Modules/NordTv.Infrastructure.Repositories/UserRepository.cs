using NordTv.Domain.Entities;
using NordTv.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordTv.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> users;
        public UserRepository()
        {
            users = new List<User>();
        }
        public Task<int> Delete(User user)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Insert(User user)
        {
             users.Add(user);

            return user;
        }

        public Task<User> Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
