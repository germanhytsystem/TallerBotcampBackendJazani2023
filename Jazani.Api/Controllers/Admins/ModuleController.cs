//using Jazani.Application.Admins.Dtos.Modules;
//using Jazani.Application.Admins.Services;
//using Microsoft.AspNetCore.Mvc;


//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Jazani.Api.Controllers.Admins
//{
//    [Route("api/[controller]")]
//    public class ModuleController : Controller
//    {
//        private readonly IModuleService _ModuleService;


//        public ModuleController(IModuleService ModuleService)
//        {
//            _ModuleService = ModuleService;
//        }


//        // GET: api/values
//        [HttpGet]
//        public async Task<IEnumerable<ModuleDto>> Get()
//        {
//            return await _ModuleService.FindAllAsync();
//        }

//        // GET api/values/5
//        [HttpGet("{id}")]
//        public async Task<ModuleDto?> Get(int id)
//        {
//            return await _ModuleService.FindByIdAsync(id);
//        }

//        // POST api/values
//        [HttpPost]
//        public async Task<ModuleDto> Post([FromBody] ModuleSaveDto ModuleSaveDto)
//        {
//            return await _ModuleService.CreateAsync(ModuleSaveDto);
//        }

//        // PUT api/values/5
//        [HttpPut("{id}")]
//        public async Task<ModuleDto> Put(int id, [FromBody] ModuleSaveDto ModuleSaveDto)
//        {
//            return await _ModuleService.EditAsync(id, ModuleSaveDto);
//        }

//        // DELETE api/values/5
//        [HttpDelete("{id}")]
//        public async Task<ModuleDto> Delete(int id)
//        {
//            return await _ModuleService.DisabledAsync(id);
//        }
//    }
//}

