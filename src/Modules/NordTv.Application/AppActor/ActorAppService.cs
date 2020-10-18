using NordTv.Application.AppActor.Input;
using NordTv.Application.AppActor.Interfaces;
using NordTv.Domain.Entities;
using NordTv.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordTv.Application.AppActor
{
    public class ActorAppService : IActorAppService
    {
        private readonly IActorRepository _actorRepository;
        private readonly IUserRepository _userRepository;
        public ActorAppService(IActorRepository actorRepository, IUserRepository userRepository)
        {
            _actorRepository = actorRepository;
            _userRepository = userRepository;
        }


        public Task<List<Actor>> GetAllAsync()
        {
            return _actorRepository.GetAllAsync();
        }

        public Task<Actor> GetByIdAsync(int id)
        {
            return _actorRepository.GetByIdAsync(id);
        }

        public async Task<Actor> InsertAsync(ActorInput input)
        {
            var user = await _userRepository.GetByIdAsync(input.IdUser).ConfigureAwait(false);
            var actor = await _actorRepository.InsertAsync(new Actor(input.Amount, input.Sex, user)).ConfigureAwait(false);
            return actor;
        }
    }
}
