using Jazani.Application.Generals.Dtos.Liabilities;
using Jazani.Application.Generals.Services;
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
        public async Task<LiabilitieDto?> Get(int id)
        {
            return await _liabilitieTypeService.FindByIdAsync(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<LiabilitieDto> Post([FromBody] LiabilitieSaveDto ltSaveDto)
        {   
            return await _liabilitieTypeService.CreateAsync(ltSaveDto);
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
