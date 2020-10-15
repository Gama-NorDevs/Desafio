using NordTv.Domain.Entities;
using NordTv.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordTv.Infrastructure.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        public Task<List<User>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Insert(User people)
        {
            throw new NotImplementedException();
        }
    }
}
