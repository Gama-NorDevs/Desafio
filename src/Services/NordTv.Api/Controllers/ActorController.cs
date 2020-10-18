using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NordTv.Application.AppActor.Input;
using NordTv.Application.AppActor.Interfaces;

namespace NordTv.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorAppService _actorService;

        public ActorController(IActorAppService actorService)
        {
            _actorService = actorService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ActorInput input)
        {
            try
            {

                var actor = await _actorService.InsertAsync(input).ConfigureAwait(false);
                return Created("", actor);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro => {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                var listUser = await _actorService.GetAllAsync().ConfigureAwait(false);

                return Ok(listUser.ToArray());
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro => {ex.Message}");
            }
        }



        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            try
            {
                var user = await _actorService.GetByIdAsync(id).ConfigureAwait(false);
                return Ok(user);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro => {ex.Message}");
            }
        }
    }
}
