using Jazani.Api.Exceptions;
using Jazani.Application.Generals.Dtos.Investmentconcepts;
using Jazani.Application.Generals.Dtos.Investments;
using Jazani.Application.Generals.Services;
using Jazani.Core.Paginations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Generals
{
    [Route("api/[controller]")]
    //[ApiController]
    public class InvestmentController : ControllerBase
    {
        private readonly IInvestmentService _investmentService;

        public InvestmentController(IInvestmentService investmentService)
        {
            _investmentService = investmentService;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<InvestmentDto>> Get()
        {
            return await _investmentService.FindAllAsync();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound<ErrorModel>, Ok<InvestmentDto>>> Get(int id)
        {
            InvestmentDto investmentDto = await _investmentService.FindByIdAsync(id);

            return TypedResults.Ok(investmentDto);
        }


        // POST api/<ValuesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InvestmentDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<InvestmentDto>>> Post([FromBody] InvestmentSaveDto invcSaveDto)
        {
            var res = await _investmentService.CreateAsync(invcSaveDto);
            return TypedResults.CreatedAtRoute(res);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<InvestmentDto> Put(int id, [FromBody] InvestmentSaveDto invsaveDto)
        {
            return await _investmentService.EditAsync(id, invsaveDto);
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<InvestmentDto> Delete(int id)
        {
            return await _investmentService.DisabledAsync(id);
        }

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<InvestmentDto>> PaginatedSearch([FromQuery] RequestPagination<InvestmentFilterDto> request)
        {
            return await _investmentService.PaginatedSearch(request);
        }

    }
}
