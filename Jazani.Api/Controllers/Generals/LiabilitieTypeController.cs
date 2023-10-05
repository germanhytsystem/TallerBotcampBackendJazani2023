using Microsoft.AspNetCore.Mvc;
using Jazani.Application.Generals.Dtos.LiabilitieTypes;
using Jazani.Application.Generals.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Generals
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiabilitieTypeController : Controller
    {

        private readonly ILiabilitieTypeService _liabilitieTypeService;

        public LiabilitieTypeController(ILiabilitieTypeService liabilitieTypeService)
        {
            _liabilitieTypeService = liabilitieTypeService;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<LiabilitieTypeDto>> Get()
        {
            return await _liabilitieTypeService.FindAllAsync();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<LiabilitieTypeDto> Get(int id)
        {
            return await _liabilitieTypeService.FindByIdAsync(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<LiabilitieTypeDto> Post([FromBody] LiabilitieTypeSaveDto ltSaveDto)
        {   
            return await _liabilitieTypeService.CreateAsync(ltSaveDto);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<LiabilitieTypeDto> Put(int id, [FromBody] LiabilitieTypeSaveDto ltSaveDto)
        {
            return await _liabilitieTypeService.EditAsync(id, ltSaveDto);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<LiabilitieTypeDto> Delete(int id)
        {
            return await _liabilitieTypeService.DisabledAsync(id);  
        }
    }
}
