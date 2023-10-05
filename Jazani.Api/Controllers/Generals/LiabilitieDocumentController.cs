using Jazani.Application.Generals.Dtos.LiabilitieDocuments;
using Jazani.Application.Generals.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jazani.Api.Controllers.Generals
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiabilitieDocumentController : ControllerBase
    {
        private readonly ILiabilitieDocumentService _liabilitieDocumentService;

        public LiabilitieDocumentController(ILiabilitieDocumentService liabilitieDocumentService)
        {
            _liabilitieDocumentService = liabilitieDocumentService;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<LiabilitieDocumentDto>> Get()
        {
            return await _liabilitieDocumentService.FindAllAsync();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<LiabilitieDocumentDto?> Get(int id)
        {
            return await _liabilitieDocumentService.FindByIdAsync(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<LiabilitieDocumentDto> Post([FromBody] LiabilitieDocumentSaveDto ltSaveDto)
        {
            return await _liabilitieDocumentService.CreateAsync(ltSaveDto);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<LiabilitieDocumentDto> Put(int id, [FromBody] LiabilitieDocumentSaveDto ltSaveDto)
        {
            return await _liabilitieDocumentService.EditAsync(id, ltSaveDto);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<LiabilitieDocumentDto> Delete(int id)
        {
            return await _liabilitieDocumentService.DisabledAsync(id);
        }
    }
}
