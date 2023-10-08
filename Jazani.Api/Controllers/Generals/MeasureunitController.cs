using Jazani.Api.Exceptions;
using Jazani.Application.Generals.Dtos.Measureunits.Profiles;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Generals
{
    [Route("api/[controller]")]
    //[ApiController]
    public class MeasureunitController : ControllerBase
    {
        private readonly IMeasureunitService _measureunitService;

        public MeasureunitController(IMeasureunitService measureunitService)
        {
            _measureunitService = measureunitService;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<MeasureunitDto>> Get()
        {
            return await _measureunitService.FindAllAsync();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MeasureunitDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound<ErrorModel>, Ok<MeasureunitDto>>> Get(int id)
        {
            MeasureunitDto? measureunitDto = await _measureunitService.FindByIdAsync(id);

            return TypedResults.Ok(measureunitDto);
        }


        // POST api/<ValuesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MeasureunitDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<MeasureunitDto>>> Post([FromBody] MeasureunitSaveDto saveDto)
        {
            var res = await _measureunitService.CreateAsync(saveDto);
            return TypedResults.CreatedAtRoute(res);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<MeasureunitDto> Put(int id, [FromBody] MeasureunitSaveDto saveDto)
        {
            return await _measureunitService.EditAsync(id, saveDto);
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<MeasureunitDto> Delete(int id)
        {
            return await _measureunitService.DisabledAsync(id);
        }
    }
}
