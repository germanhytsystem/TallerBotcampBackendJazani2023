using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using AutoMapper;
using Jazani.Application.Generals.Dtos.Holders;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Generals.Services.Implementatios
{
    public class HolderService : IHolderService
    {
        private readonly IHolderRepository _holderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<HolderService> _logger;

        public HolderService(IHolderRepository holderRepository, IMapper mapper, ILogger<HolderService> logger)
        {
            _holderRepository = holderRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<HolderDto> CreateAsync(HolderSaveDto holderSaveDto )
        {
            //throw new NotImplementedException();
            Holder holder = _mapper.Map<Holder>(holderSaveDto);
            holder.RegistrationDate = DateTime.Now;
            holder.State = true;

            await _holderRepository.SaveAsync(holder);

            return _mapper.Map<HolderDto>(holder);
        }

        public async Task<HolderDto?> DisabledAsync(int id)
        {
            //throw new NotImplementedException();
            Holder? holder = await _holderRepository.FindByIdAsync(id);
            holder.State = false;

            await _holderRepository.SaveAsync(holder);

            return _mapper.Map<HolderDto>(holder);
        }

        public async Task<HolderDto?> EditAsync(int id, HolderSaveDto? holderSaveDto)
        {
            //throw new NotImplementedException();
            Holder? holder = await _holderRepository.FindByIdAsync(id);
            _mapper.Map<HolderSaveDto?, Holder?>(holderSaveDto, holder);

            await _holderRepository.SaveAsync(holder);

            return _mapper.Map<HolderDto>(holder);
        }

        public async Task<IReadOnlyList<HolderDto>> FindAllAsync()
        {
            //throw new NotImplementedException();
            IReadOnlyList<Holder> holder = await _holderRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<HolderDto>>(holder);
        }

        public async Task<HolderDto?> FindByIdAsync(int id)
        {
            //throw new NotImplementedException();
            Holder? holder = await _holderRepository.FindByIdAsync(id);

            return _mapper.Map<HolderDto>(holder);

        }
    }
}
