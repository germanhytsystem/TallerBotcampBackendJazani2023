using Jazani.Api.Exceptions;
using Jazani.Application.Generals.Dtos.Investments;
using Jazani.Application.Generals.Dtos.Investmenttypes;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Jazani.Api.Controllers.Generals
//{
//    [Route("api/[controller]")]
//    //[ApiController]
//    public class InvestmenttypeController : ControllerBase
//    {
//        private readonly IInvestmenttypeService _investmenttypeService;

//        public InvestmenttypeController(IInvestmenttypeService investmenttypeService)
//        {
//            _investmenttypeService = investmenttypeService;
//        }


//        // GET: api/<ValuesController>
//        [HttpGet]
//        public async Task<IEnumerable<InvestmenttypeDto>> Get()
//        {
//            return await _investmenttypeService.FindAllAsync();
//        }

//        // GET api/<ValuesController>/5
//        [HttpGet("{id}")]
//        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmenttypeDto))]
//        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
//        public async Task<Results<NotFound<ErrorModel>, Ok<InvestmenttypeDto>>> Get(int id)
//        {
//            InvestmenttypeDto investmenttypeDto = await _investmenttypeService.FindByIdAsync(id);

//            return TypedResults.Ok(investmenttypeDto);
//        }


//        // POST api/<ValuesController>
//        [HttpPost]
//        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmenttypeDto))]
//        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
//        public async Task<Results<BadRequest, CreatedAtRoute<InvestmenttypeDto>>> Post([FromBody] InvestmenttypeSaveDto invcSaveDto)
//        {
//            var res = await _investmenttypeService.CreateAsync(invcSaveDto);
//            return TypedResults.CreatedAtRoute(res);
//        }

//        // PUT api/<ValuesController>/5
//        [HttpPut("{id}")]
//        public async Task<InvestmenttypeDto> Put(int id, [FromBody] InvestmenttypeSaveDto invsaveDto)
//        {
//            return await _investmenttypeService.EditAsync(id, invsaveDto);
//        }


//        // DELETE api/<ValuesController>/5
//        [HttpDelete("{id}")]
//        public async Task<InvestmenttypeDto> Delete(int id)
//        {
//            return await _investmenttypeService.DisabledAsync(id);
//        }

//    }
//}
