using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using AutoMapper;
using Jazani.Application.Generals.Dtos.Liabilities;

namespace Jazani.Application.Generals.Services.Implementatios
{
    public class LiabilitieService : ILiabilitieService
    {
        private readonly ILiabilitieRepository _liabilitieTypeRepository;
        private readonly IMapper _mapper;

        public LiabilitieService(ILiabilitieRepository liabilitieTypeRepository, IMapper mapper)
        {
            this._liabilitieTypeRepository = liabilitieTypeRepository;
            _mapper = mapper;
        }

        public async Task<LiabilitieDto> CreateAsync(LiabilitieSaveDto liabilitieTypeSaveDto )
        {
            //throw new NotImplementedException();
            Liabilitie liabilitieType = _mapper.Map<Liabilitie>(liabilitieTypeSaveDto);
            liabilitieType.RegistrationDate = DateTime.Now;
            liabilitieType.State = true;

            await _liabilitieTypeRepository.SaveAsync(liabilitieType);

            return _mapper.Map<LiabilitieDto>(liabilitieType);
        }

        public async Task<LiabilitieDto?> DisabledAsync(int id)
        {
            //throw new NotImplementedException();
            Liabilitie? liabilitieType = await _liabilitieTypeRepository.FindByIdAsync(id);
            liabilitieType.State = false;

            await _liabilitieTypeRepository.SaveAsync(liabilitieType);

            return _mapper.Map<LiabilitieDto>(liabilitieType);
        }

        public async Task<LiabilitieDto?> EditAsync(int id, LiabilitieSaveDto? liabilitieTypeSaveDto)
        {
            //throw new NotImplementedException();
            Liabilitie? liabilitieType = await _liabilitieTypeRepository.FindByIdAsync(id);
            _mapper.Map<LiabilitieSaveDto?, Liabilitie?>(liabilitieTypeSaveDto, liabilitieType);

            await _liabilitieTypeRepository.SaveAsync(liabilitieType);

            return _mapper.Map<LiabilitieDto>(liabilitieType);
        }

        public async Task<IReadOnlyList<LiabilitieDto>> FindAllAsync()
        {
            //throw new NotImplementedException();
            IReadOnlyList<Liabilitie> liabilitieType = await _liabilitieTypeRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<LiabilitieDto>>(liabilitieType);
        }

        public async Task<LiabilitieDto?> FindByIdAsync(int id)
        {
            //throw new NotImplementedException();
            Liabilitie? liabilitieType = await _liabilitieTypeRepository.FindByIdAsync(id);

            return _mapper.Map<LiabilitieDto>(liabilitieType);

        }
    }
}
