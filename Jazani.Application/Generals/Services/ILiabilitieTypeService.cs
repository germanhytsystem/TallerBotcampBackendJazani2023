using Jazani.Application.Generals.Dtos.LiabilitieTypes;

namespace Jazani.Application.Generals.Services
{
    public interface ILiabilitieTypeService
    {
        Task<IReadOnlyList<LiabilitieTypeDto>> FindAllAsync();
        Task<LiabilitieTypeDto?> FindByIdAsync(int id);
        Task<LiabilitieTypeDto> CreateAsync(LiabilitieTypeSaveDto officeSaveDto);
        Task<LiabilitieTypeDto> EditAsync(int id, LiabilitieTypeSaveDto officeSaveDto);
        Task<LiabilitieTypeDto> DisabledAsync(int id);
    }
}
