using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Generals.Dtos.Periodtypes;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;

namespace Jazani.Application.Generals.Services.Implementatios
{
    public class PeriodtypeService : IPeriodtypeService
    {

        private readonly IPeriodtypeRepository _periodtypeRepository;
        private readonly IMapper _mapper;

        public PeriodtypeService(IPeriodtypeRepository periodtypeRepository, IMapper mapper)
        {
            _periodtypeRepository = periodtypeRepository;
            _mapper = mapper;
        }

        public async Task<PeriodtypeDto> CreateAsync(PeriodtypeSaveDto saveDto)
        {
            // throw new NotImplementedException();
            Periodtype? periodtype = _mapper.Map<Periodtype>(saveDto);
            periodtype.RegistrationDate = DateTime.Now;
            periodtype.State = true;

            await _periodtypeRepository.SaveAsync(periodtype);


            return _mapper.Map<PeriodtypeDto>(periodtype);
        }

        public async Task<PeriodtypeDto> DisabledAsync(int id)
        {
            // throw new NotImplementedException();
            Periodtype? periodtype = await _periodtypeRepository.FindByIdAsync(id);

            if (periodtype is null) throw PeriodtypeNotFound(id);

            periodtype.State = false;

            await _periodtypeRepository.SaveAsync(periodtype);

            return _mapper.Map<PeriodtypeDto>(periodtype);

        }

        public async Task<PeriodtypeDto> EditAsync(int id, PeriodtypeSaveDto saveDto)
        {
            //hrow new NotImplementedException();
            Periodtype? periodtype = await _periodtypeRepository.FindByIdAsync(id);

            if (periodtype is null) throw PeriodtypeNotFound(id);

            _mapper.Map<PeriodtypeSaveDto, Periodtype>(saveDto, periodtype);

            await _periodtypeRepository.SaveAsync(periodtype);

            return _mapper.Map<PeriodtypeDto>(periodtype);

        }

        public async Task<IReadOnlyList<PeriodtypeDto>> FindAllAsync()
        {
            //throw new NotImplementedException();
            IReadOnlyList<Periodtype> periodtypes = await _periodtypeRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<PeriodtypeDto>>(periodtypes);

        }

        public async Task<PeriodtypeDto?> FindByIdAsync(int id)
        {
            //throw new NotImplementedException();

            Periodtype? periodtype = await _periodtypeRepository.FindByIdAsync(id);

            if (periodtype is null) throw PeriodtypeNotFound(id);

            return _mapper.Map<PeriodtypeDto>(periodtype);

        }


        private NotFoundCoreException PeriodtypeNotFound(int id)
        {
            return new NotFoundCoreException("Tipo periodtype no encontrado en el id: " + id);
        }

    }
}
