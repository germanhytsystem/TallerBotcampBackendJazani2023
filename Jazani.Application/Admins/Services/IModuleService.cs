using Jazani.Application.Admins.Dtos.Modules;

namespace Jazani.Application.Admins.Services
{
	public interface IModuleService
    {
		Task<IReadOnlyList<ModuleDto>> FindAllAsync();
		Task<ModuleDto?> FindByIdAsync(int id);
		Task<ModuleDto> CreateAsync(ModuleSaveDto moduleSaveDto);
        Task<ModuleDto> EditAsync(int  id, ModuleSaveDto moduleSaveDto);
		Task<ModuleDto> DisabledAsync(int id);
    }
}

