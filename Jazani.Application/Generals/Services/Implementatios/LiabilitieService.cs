using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Generals.Dtos.Liabilities;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Generals.Services.Implementatios
{
    public class LiabilitieService : ILiabilitieService
    {
        private readonly ILiabilitieRepository _liabilitieTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<LiabilitieService> _logger;

        public LiabilitieService(ILiabilitieRepository liabilitieTypeRepository, IMapper mapper, ILogger<LiabilitieService> logger)
        {
            _liabilitieTypeRepository = liabilitieTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<LiabilitieDto> CreateAsync(LiabilitieSaveDto liabilitieSaveDto)
        {
            //throw new NotImplementedException();
            Liabilitie liabilitie = _mapper.Map<Liabilitie>(liabilitieSaveDto);
            liabilitie.RegistrationDate = DateTime.Now;
            liabilitie.State = true;

            await _liabilitieTypeRepository.SaveAsync(liabilitie);

            return _mapper.Map<LiabilitieDto>(liabilitie);
        }

        public async Task<LiabilitieDto?> DisabledAsync(int id)
        {
            //throw new NotImplementedException();
            Liabilitie? liabilitie = await _liabilitieTypeRepository.FindByIdAsync(id);

            if (liabilitie is null) throw LiabilitieNotFound(id);

            liabilitie.State = false;

            await _liabilitieTypeRepository.SaveAsync(liabilitie);

            return _mapper.Map<LiabilitieDto>(liabilitie);
        }

        public async Task<LiabilitieDto?> EditAsync(int id, LiabilitieSaveDto? liabilitieSaveDto)
        {
            //throw new NotImplementedException();
            Liabilitie? liabilitie = await _liabilitieTypeRepository.FindByIdAsync(id);

            if (liabilitie is null) throw LiabilitieNotFound(id);

            _mapper.Map<LiabilitieSaveDto?, Liabilitie?>(liabilitieSaveDto, liabilitie);

            await _liabilitieTypeRepository.SaveAsync(liabilitie);

            return _mapper.Map<LiabilitieDto>(liabilitie);
        }

        public async Task<IReadOnlyList<LiabilitieDto>> FindAllAsync()
        {
            //throw new NotImplementedException();
            IReadOnlyList<Liabilitie> liabilitie = await _liabilitieTypeRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<LiabilitieDto>>(liabilitie);
        }

        public async Task<LiabilitieDto?> FindByIdAsync(int id)
        {
            //throw new NotImplementedException();
            Liabilitie? liabilitie = await _liabilitieTypeRepository.FindByIdAsync(id);

            //if (liabilitie is null) throw new NotFoundCoreException("Tipo de Liabilie no encontrado para el id: " + id);  //Validación
            if (liabilitie is null)
            {
                _logger.LogWarning("Tipo de liabilitie no encontrado: " + id);
                throw LiabilitieNotFound(id);  //Validación
            }

            _logger.LogInformation("Tipo de liabilitie {name}", liabilitie.Name);

            return _mapper.Map<LiabilitieDto>(liabilitie);
        }


        public NotFoundCoreException LiabilitieNotFound(int id)
        {
            return new NotFoundCoreException("Tipo de liabilitie no encontrado: " + id);
        }
    }
}
