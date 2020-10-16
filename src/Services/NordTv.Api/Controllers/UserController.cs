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
                
                var user =await _userService.Insert(input).ConfigureAwait(false);
                return Created("",user);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro => {ex.Message}");
            }
        }
    }
}