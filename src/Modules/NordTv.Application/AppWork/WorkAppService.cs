using NordTv.Application.AppWork.Input;
using NordTv.Application.AppWork.Interfaces;
using NordTv.Domain.Entities;
using NordTv.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordTv.Application.AppWork
{
    public class WorkAppService : IWorkAppService
    {
        private readonly IWorkRepository _workRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IUserRepository _userRepository;
        private readonly IGenreRepository _genreRepository;
        public WorkAppService(IWorkRepository workRepository,
                             IUserRepository userRepository,
                             IActorRepository actorRepository,
                             IGenreRepository genreRepository)
        {
            _workRepository = workRepository;
            _userRepository = userRepository;
            _actorRepository = actorRepository;
            _genreRepository = genreRepository;
        }
        public async Task<Work> InsertAsync(WorkInput input)
        {
            var produtor = await _userRepository.GetByIdAsync(input.Productor_Id).ConfigureAwait(false);
            var genre = await _genreRepository.GetByIdAsync(input.Genre_Id).ConfigureAwait(false);
            var actors = await _actorRepository.GetAllAsync().ConfigureAwait(false);
            var listActors = actors.FindAll(actors => actors.Id == input.Actors.Where(ac => ac == actors.Id).FirstOrDefault());

            var workNew = new Work(produtor, genre, input.Name.ToString(), 
                                double.Parse(input.Budget.ToString()), DateTime.Parse(input.DateStart.ToString()),
                                DateTime.Parse(input.DateEnd.ToString()),
                                listActors);
            var work = await _workRepository.InsertAsync(workNew).ConfigureAwait(false);

            return work;
        }
        public async Task<Work> GetByIdAsync(int id)
        {
            return await _workRepository.GetByIdAsync(id).ConfigureAwait(false);
        }
        public async Task<List<Work>> GetAllAsync()
        {
            return await _workRepository.GetAllAsync().ConfigureAwait(false);
        }
    }
}
