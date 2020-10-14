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
        public Task Insert(People people)
        {
            throw new NotImplementedException();
        }
    }
}
