using Jazani.Application.Generals.Dtos.LiabilitieTypes;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using AutoMapper;

namespace Jazani.Application.Generals.Services.Implementatios
{
    public class LiabilitieTypeService : ILiabilitieTypeService
    {
        private readonly ILiabilitieTypeRepository _liabilitieTypeRepository;
        private readonly IMapper _mapper;

        public LiabilitieTypeService(ILiabilitieTypeRepository liabilitieTypeRepository, IMapper mapper)
        {
            this._liabilitieTypeRepository = liabilitieTypeRepository;
            _mapper = mapper;
        }

        public async Task<LiabilitieTypeDto> CreateAsync(LiabilitieTypeSaveDto liabilitieTypeSaveDto )
        {
            //throw new NotImplementedException();
            LiabilitieType liabilitieType = _mapper.Map<LiabilitieType>(liabilitieTypeSaveDto);
            liabilitieType.RegistrationDate = DateTime.Now;
            liabilitieType.State = true;

            await _liabilitieTypeRepository.SaveAsync(liabilitieType);

            return _mapper.Map<LiabilitieTypeDto>(liabilitieType);
        }

        public async Task<LiabilitieTypeDto> DisabledAsync(int id)
        {
            //throw new NotImplementedException();
            LiabilitieType liabilitieType = await _liabilitieTypeRepository.FindByIdAsync(id);
            liabilitieType.State = false;

            await _liabilitieTypeRepository.SaveAsync(liabilitieType);

            return _mapper.Map<LiabilitieTypeDto>(liabilitieType);
        }

        public async Task<LiabilitieTypeDto> EditAsync(int id, LiabilitieTypeSaveDto liabilitieTypeSaveDto)
        {
            //throw new NotImplementedException();
            LiabilitieType liabilitieType = await _liabilitieTypeRepository.FindByIdAsync(id);
            _mapper.Map<LiabilitieTypeSaveDto, LiabilitieType>(liabilitieTypeSaveDto, liabilitieType);

            await _liabilitieTypeRepository.SaveAsync(liabilitieType);

            return _mapper.Map<LiabilitieTypeDto>(liabilitieType);
        }

        public async Task<IReadOnlyList<LiabilitieTypeDto>> FindAllAsync()
        {
            //throw new NotImplementedException();
            IReadOnlyList<LiabilitieType> liabilitieType = await _liabilitieTypeRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<LiabilitieTypeDto>>(liabilitieType);
        }

        public async Task<LiabilitieTypeDto?> FindByIdAsync(int id)
        {
            //throw new NotImplementedException();
            LiabilitieType liabilitieType = await _liabilitieTypeRepository.FindByIdAsync(id);

            return _mapper.Map<LiabilitieTypeDto>(liabilitieType);

        }
    }
}
