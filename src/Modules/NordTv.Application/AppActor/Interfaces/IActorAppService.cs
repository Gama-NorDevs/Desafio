using NordTv.Application.AppActor.Input;
using NordTv.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordTv.Application.AppActor.Interfaces
{
    public interface IActorAppService
    {
        Task<Actor> InsertAsync(ActorInput input);
        Task<Actor> GetByIdAsync(int id);
        Task<List<Actor>> GetAllAsync();
    }
}
