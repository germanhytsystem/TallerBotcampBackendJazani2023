using Jazani.Application.Generals.Dtos.Holders;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

//For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Generals
{
    [Route("api/[controller]")]
    //[ApiController]
    public class HolderController : Controller
    {

        private readonly IHolderService _holderService;

        public HolderController(IHolderService holderService)
        {
            _holderService = holderService;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<HolderDto>> Get()
        {
            return await _holderService.FindAllAsync();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<HolderDto?> Get(int id)
        {
            return await _holderService.FindByIdAsync(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<HolderDto> Post([FromBody] HolderSaveDto holderSaveDto)
        {
            return await _holderService.CreateAsync(holderSaveDto);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<HolderDto> Put(int id, [FromBody] HolderSaveDto holderSaveDto)
        {
            return await _holderService.EditAsync(id, holderSaveDto);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<HolderDto> Delete(int id)
        {
            return await _holderService.DisabledAsync(id);
        }
    }
}
