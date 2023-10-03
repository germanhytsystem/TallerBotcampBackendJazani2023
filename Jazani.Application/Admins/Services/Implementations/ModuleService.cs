using AutoMapper;
using Jazani.Application.Admins.Dtos.Modules;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;

namespace Jazani.Application.Admins.Services.Implementations
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly IMapper _mapper;

        public ModuleService(IModuleRepository moduleRepository, IMapper mapper)
        {
            _moduleRepository = moduleRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ModuleDto>> FindAllAsync()
        {
            IReadOnlyList<Module> modules = await _moduleRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<ModuleDto>>(modules);
        }

        public async Task<ModuleDto?> FindByIdAsync(int id)
        {
            Module? Module = await _moduleRepository.FindByIdAsync(id);

            return _mapper.Map<ModuleDto>(Module);
        }

        public async Task<ModuleDto> CreateAsync(ModuleSaveDto ModuleSaveDto)
        {
            Module Module = _mapper.Map<Module>(ModuleSaveDto);
            Module.RegistrationDate = DateTime.Now;
            Module.State = true;

            Module ModuleSaved = await _moduleRepository.SaveAsync(Module);

            return _mapper.Map<ModuleDto>(ModuleSaved);
        }

        public async Task<ModuleDto> EditAsync(int id, ModuleSaveDto moduleSaveDto)
        {

            Module? module = await _moduleRepository.FindByIdAsync(id);

            _mapper.Map<ModuleSaveDto, Module>(moduleSaveDto, module);

            Module ModuleSaved = await _moduleRepository.SaveAsync(module);

            return _mapper.Map<ModuleDto>(ModuleSaved);
        }

        public async Task<ModuleDto> DisabledAsync(int id)
        {
            Module? module = await _moduleRepository.FindByIdAsync(id);
            module.State = false;

            Module moduleSaved = await _moduleRepository.SaveAsync(module);

            return _mapper.Map<ModuleDto>(moduleSaved);
        }


    }
}

