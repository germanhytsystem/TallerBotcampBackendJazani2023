using Jazani.Api.Exceptions;
using Jazani.Application.Generals.Dtos.Periodtypes;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Jazani.Api.Controllers.Generals
//{
//    [Route("api/[controller]")]
//    //[ApiController]
//    public class PeriodtypeController : ControllerBase
//    {
//        private readonly IPeriodtypeService _periodtypeService;

//        public PeriodtypeController(IPeriodtypeService periodtypeService)
//        {
//            _periodtypeService = periodtypeService;
//        }


//        // GET: api/<ValuesController>
//        [HttpGet]
//        public async Task<IEnumerable<PeriodtypeDto>> Get()
//        {
//            return await _periodtypeService.FindAllAsync();
//        }

//        // GET api/<ValuesController>/5
//        [HttpGet("{id}")]
//        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PeriodtypeDto))]
//        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
//        public async Task<Results<NotFound<ErrorModel>, Ok<PeriodtypeDto>>> Get(int id)
//        {
//            PeriodtypeDto periodtypeDto = await _periodtypeService.FindByIdAsync(id);

//            return TypedResults.Ok(periodtypeDto);
//        }


//        // POST api/<ValuesController>
//        [HttpPost]
//        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PeriodtypeDto))]
//        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
//        public async Task<Results<BadRequest, CreatedAtRoute<PeriodtypeDto>>> Post([FromBody] PeriodtypeSaveDto saveDto)
//        {
//            var res = await _periodtypeService.CreateAsync(saveDto);
//            return TypedResults.CreatedAtRoute(res);
//        }

//        // PUT api/<ValuesController>/5
//        [HttpPut("{id}")]
//        public async Task<PeriodtypeDto> Put(int id, [FromBody] PeriodtypeSaveDto saveDto)
//        {
//            return await _periodtypeService.EditAsync(id, saveDto);
//        }


//        // DELETE api/<ValuesController>/5
//        [HttpDelete("{id}")]
//        public async Task<PeriodtypeDto> Delete(int id)
//        {
//            return await _periodtypeService.DisabledAsync(id);
//        }
//    }
//}
