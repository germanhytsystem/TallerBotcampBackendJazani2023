using Jazani.Api.Exceptions;
using Jazani.Application.Generals.Dtos.Miningconcessions;
using Jazani.Application.Generals.Services;
using Jazani.Domain.Generals.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Generals
{
    [Route("api/[controller]")]
    //[ApiController]
    public class MiningconcessionController : ControllerBase
    {
        private readonly IMiningconcessionService _miningconcessionService;

        public MiningconcessionController(IMiningconcessionService miningconcessionService)
        {
            _miningconcessionService = miningconcessionService;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<MiningconcessionDto>> Get()
        {
            return await _miningconcessionService.FindAllAsync();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MiningconcessionDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound<ErrorModel>, Ok<MiningconcessionDto>>> Get(int id)
        {
            MiningconcessionDto miningconcessionDto = await _miningconcessionService.FindByIdAsync(id);

            return TypedResults.Ok(miningconcessionDto);
        }


        // POST api/<ValuesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MiningconcessionDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<MiningconcessionDto>>> Post([FromBody] MiningconcessionSaveDto mingSaveDto)
        {
            var res = await _miningconcessionService.CreateAsync(mingSaveDto);
            return TypedResults.CreatedAtRoute(res);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<MiningconcessionDto> Put(int id, [FromBody] MiningconcessionSaveDto mingSaveDto)
        {
            return await _miningconcessionService.EditAsync(id, mingSaveDto);
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<MiningconcessionDto> Delete(int id)
        {
            return await _miningconcessionService.DisabledAsync(id);
        }
    }
}
