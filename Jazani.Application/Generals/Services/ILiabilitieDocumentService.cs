using Jazani.Application.Generals.Dtos.LiabilitieDocuments;

namespace Jazani.Application.Generals.Services
{
    public interface ILiabilitieDocumentService
    {
        Task<IReadOnlyList<LiabilitieDocumentDto>> FindAllAsync();
        Task<LiabilitieDocumentDto?> FindByIdAsync(int id);
        Task<LiabilitieDocumentDto> CreateAsync(LiabilitieDocumentSaveDto lbsdto);
        Task<LiabilitieDocumentDto> EditAsync(int id, LiabilitieDocumentSaveDto lbsdto);
        Task<LiabilitieDocumentDto> DisabledAsync(int id);
    }
}
