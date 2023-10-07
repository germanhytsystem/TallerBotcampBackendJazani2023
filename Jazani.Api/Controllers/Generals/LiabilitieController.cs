using Jazani.Api.Exceptions;
using Jazani.Application.Generals.Dtos.Liabilities;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Generals
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiabilitieController : Controller
    {

        private readonly ILiabilitieService _liabilitieTypeService;

        public LiabilitieController(ILiabilitieService liabilitieTypeService)
        {
            _liabilitieTypeService = liabilitieTypeService;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<LiabilitieDto>> Get()
        {
            return await _liabilitieTypeService.FindAllAsync();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK,Type=typeof(LiabilitieDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound,Ok<LiabilitieDto>>?> Get(int id)
        {
            //return await _liabilitieTypeService.FindByIdAsync(id);
            var res= await _liabilitieTypeService.FindByIdAsync(id);

            return TypedResults.Ok(res);
        }

        // POST api/<ValuesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(LiabilitieDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest,Type=typeof(ErrorResponse))]
        public async Task<Results<BadRequest,CreatedAtRoute<LiabilitieDto>>> Post([FromBody] LiabilitieSaveDto ltSaveDto)
        {   
            var res= await _liabilitieTypeService.CreateAsync(ltSaveDto);
            return TypedResults.CreatedAtRoute(res); 
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<LiabilitieDto> Put(int id, [FromBody] LiabilitieSaveDto ltSaveDto)
        {
            return await _liabilitieTypeService.EditAsync(id, ltSaveDto);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<LiabilitieDto> Delete(int id)
        {
            return await _liabilitieTypeService.DisabledAsync(id);  
        }
    }
}
