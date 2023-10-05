using Jazani.Application.Generals.Dtos.Holders;

namespace Jazani.Application.Generals.Services
{
    public interface IHolderService
    {
        Task<IReadOnlyList<HolderDto>> FindAllAsync();
        Task<HolderDto?> FindByIdAsync(int id);
        Task<HolderDto> CreateAsync(HolderSaveDto holderDto);
        Task<HolderDto> EditAsync(int id, HolderSaveDto holdersaveDto);
        Task<HolderDto> DisabledAsync(int id);
    }
}
