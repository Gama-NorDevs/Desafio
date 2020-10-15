using NordTv.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordTv.Domain.Interfaces.Repositories
{
    public interface IGenreRepository
    {
        Task<Genre> Insert (Genre genre);
        Task<int> Delete (Genre genre);
        Task<Genre> DeleteById (int id);
        Task<Genre> Update (Genre genre);
        Task<Genre> GetById (int id);
    }
}
