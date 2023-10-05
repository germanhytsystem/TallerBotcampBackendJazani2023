using Jazani.Application.Admins.Dtos.Liabilities;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    public class LiabilitieController : Controller
    {
        private readonly ILiabilitieService _LiabilitieService;

        public LiabilitieController(ILiabilitieService LiabilitieService)
        {
            _LiabilitieService = LiabilitieService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<LiabilitieDto>> Get()
        {
            return await _LiabilitieService.FindAllAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<LiabilitieDto> Get(int id)
        {
            return await _LiabilitieService.FindByIdAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<LiabilitieDto> Post([FromBody] LiabilitieSaveDto LiabilitieSaveDto)
        {
            return await _LiabilitieService.CreateAsync(LiabilitieSaveDto);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<LiabilitieDto> Put(int id, [FromBody] LiabilitieSaveDto LiabilitieSaveDto)
        {
            return await _LiabilitieService.EditAsync(id, LiabilitieSaveDto);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<LiabilitieDto> Delete(int id)
        {
            return await _LiabilitieService.DisabledAsync(id);
        }
    }
}

