using NordTv.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordTv.Domain.Interfaces.Repositories
{
    public interface IPeopleRepository
    {
        Task Insert(People people);
        
    }
}
