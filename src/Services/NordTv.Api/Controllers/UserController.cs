using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NordTv.Application.AppUser.Input;
using NordTv.Application.AppUser.Interfaces;

namespace NordTv.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userService;

        public UserController(IUserAppService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserInput input)
        {
            try
            {

                var user = await _userService.InsertAsync(input).ConfigureAwait(false);
                return Created("", user);
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

                var listUser = await _userService.GetAllAsync().ConfigureAwait(false);

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
                var user = await _userService.GetByIdAsync(id).ConfigureAwait(false);
                return Ok(user);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro => {ex.Message}");
            }
        }

    }
}