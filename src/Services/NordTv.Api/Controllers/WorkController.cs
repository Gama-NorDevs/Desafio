using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NordTv.Application.AppWork.Input;
using NordTv.Application.AppWork.Interfaces;

namespace NordTv.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly IWorkAppService _workService;

        public WorkController(IWorkAppService workService)
        {
            _workService = workService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WorkInput input)
        {
            try
            {
                var work = await _workService.InsertAsync(input).ConfigureAwait(false);
                return Created("", work);
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

                var listWork = await _workService.GetAllAsync().ConfigureAwait(false);

                return Ok(listWork.ToArray());
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
                var work = await _workService.GetByIdAsync(id).ConfigureAwait(false);
                return Ok(work);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro => {ex.Message}");
            }
        }
    }
}