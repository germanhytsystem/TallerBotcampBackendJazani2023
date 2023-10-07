using Jazani.Api.Exceptions;
using Jazani.Application.Generals.Dtos.Investmentconcepts;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Generals
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentconceptController : ControllerBase
    {

        private readonly IInvestmentconceptService _investmentconceptService;

        public InvestmentconceptController(IInvestmentconceptService investmentconceptService)
        {
            _investmentconceptService = investmentconceptService;
        }



        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<InvestmentconceptDto>> Get()
        {
            return await _investmentconceptService.FindAllAsync();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InvestmentconceptDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound<ErrorModel>, Ok<InvestmentconceptDto>>> Get(int id)
        {
            InvestmentconceptDto investmentconceptDto=await _investmentconceptService.FindByIdAsync(id);

            return TypedResults.Ok(investmentconceptDto);
        }

    }
}
