using AutoMapper;
using Jazani.Application.Generals.Dtos.LiabilitieDocuments;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;

namespace Jazani.Application.Generals.Services.Implementatios
{
    public class LiabilitieDocumentService : ILiabilitieDocumentService
    {
        private readonly ILiabilitieDocumentRepository _liabilitieDocumentRepository;
        private readonly IMapper _mapper;

        public LiabilitieDocumentService(ILiabilitieDocumentRepository liabilitieDocumentRepository, IMapper mapper)
        {
            _liabilitieDocumentRepository = liabilitieDocumentRepository;
            _mapper = mapper;
        }

        public async Task<LiabilitieDocumentDto> CreateAsync(LiabilitieDocumentSaveDto saveDto)
        {
            // throw new NotImplementedException();
            LiabilitieDocument liabilitieDocument = _mapper.Map<LiabilitieDocument>(saveDto);
            liabilitieDocument.RegistrationDate=DateTime.Now;
            liabilitieDocument.State = true;

            await _liabilitieDocumentRepository.SaveAsync(liabilitieDocument);

            return _mapper.Map<LiabilitieDocumentDto>(liabilitieDocument);
        }

        public async Task<LiabilitieDocumentDto> DisabledAsync(int id)
        {
            //throw new NotImplementedException();
            LiabilitieDocument? liabilitieDocument = await _liabilitieDocumentRepository.FindByIdAsync(id);
            liabilitieDocument.State = false;

            await _liabilitieDocumentRepository.SaveAsync(liabilitieDocument);

            return _mapper.Map<LiabilitieDocumentDto>(liabilitieDocument);
        }

        public async Task<LiabilitieDocumentDto?> EditAsync(int id, LiabilitieDocumentSaveDto? saveDto)
        {
            // throw new NotImplementedException();
            LiabilitieDocument? liabilitieDocument = await _liabilitieDocumentRepository.FindByIdAsync(id);

            _mapper.Map<LiabilitieDocumentSaveDto?, LiabilitieDocument?>(saveDto, liabilitieDocument);

            await _liabilitieDocumentRepository.SaveAsync(liabilitieDocument);


            return _mapper.Map<LiabilitieDocumentDto>(liabilitieDocument);
        }

        public async Task<IReadOnlyList<LiabilitieDocumentDto>> FindAllAsync()
        {
            //throw new NotImplementedException();
            IReadOnlyList<LiabilitieDocument> liabilitieDocuments = await _liabilitieDocumentRepository.FindAllAsync();
            
            return _mapper.Map<IReadOnlyList<LiabilitieDocumentDto>>(liabilitieDocuments);
        }

        public async Task<LiabilitieDocumentDto?> FindByIdAsync(int id)
        {
            //throw new NotImplementedException();
            LiabilitieDocument? liabilitieDocument = await _liabilitieDocumentRepository.FindByIdAsync(id);


            return _mapper.Map<LiabilitieDocumentDto>(liabilitieDocument);
        }
    }
}
