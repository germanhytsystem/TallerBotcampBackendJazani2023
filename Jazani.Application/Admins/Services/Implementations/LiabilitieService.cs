using AutoMapper;
using Jazani.Application.Admins.Dtos.Liabilities;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;

namespace Jazani.Application.Admins.Services.Implementations
{
    public class LiabilitieService : ILiabilitieService
    {
        private readonly ILiabilitieRepository _LiabilitieRepository;
        private readonly IMapper _mapper;

        public LiabilitieService(ILiabilitieRepository LiabilitieRepository, IMapper mapper)
        {
            _LiabilitieRepository = LiabilitieRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<LiabilitieDto>> FindAllAsync()
        {
            IReadOnlyList<Liabilitie> Liabilities = await _LiabilitieRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<LiabilitieDto>>(Liabilities);
        }

        public async Task<LiabilitieDto?> FindByIdAsync(int id)
        {
            Liabilitie? Liabilitie = await _LiabilitieRepository.FindByIdAsync(id);

            return _mapper.Map<LiabilitieDto>(Liabilitie);
        }

        public async Task<LiabilitieDto> CreateAsync(LiabilitieSaveDto LiabilitieSaveDto)
        {
            Liabilitie Liabilitie = _mapper.Map<Liabilitie>(LiabilitieSaveDto);
            Liabilitie.RegistrationDate = DateTime.Now;
            Liabilitie.State = true;

            Liabilitie LiabilitieSaved = await _LiabilitieRepository.SaveAsync(Liabilitie);

            return _mapper.Map<LiabilitieDto>(LiabilitieSaved);
        }

        public async Task<LiabilitieDto> EditAsync(int id, LiabilitieSaveDto LiabilitieSaveDto)
        {

            Liabilitie? Liabilitie = await _LiabilitieRepository.FindByIdAsync(id);

            _mapper.Map<LiabilitieSaveDto, Liabilitie>(LiabilitieSaveDto, Liabilitie);

            Liabilitie LiabilitieSaved = await _LiabilitieRepository.SaveAsync(Liabilitie);

            return _mapper.Map<LiabilitieDto>(LiabilitieSaved);
        }


        public async Task<LiabilitieDto> DisabledAsync(int id)
        {
            Liabilitie? Liabilitie = await _LiabilitieRepository.FindByIdAsync(id);
            Liabilitie.State = false;

            Liabilitie LiabilitieSaved = await _LiabilitieRepository.SaveAsync(Liabilitie);

            return _mapper.Map<LiabilitieDto>(LiabilitieSaved);
        }


    }
}

