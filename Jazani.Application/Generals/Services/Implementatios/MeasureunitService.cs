using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Generals.Dtos.Measureunits.Profiles;
using Jazani.Application.Generals.Dtos.Periodtypes;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Services.Implementatios
{
    public class MeasureunitService : IMeasureunitService
    {
        private readonly IMeasureunitRepository _measureunitRepository;
        private readonly IMapper _mapper;

        public MeasureunitService(IMeasureunitRepository measureunitRepository, IMapper mapper)
        {
            _measureunitRepository = measureunitRepository;
            _mapper = mapper;
        }


        public async Task<MeasureunitDto> CreateAsync(MeasureunitSaveDto saveDto)
        {
            // throw new NotImplementedException();
            Measureunit? measureunit = _mapper.Map<Measureunit>(saveDto);
            measureunit.RegistrationDate = DateTime.Now;
            measureunit.State = true;

            await _measureunitRepository.SaveAsync(measureunit);

            return _mapper.Map<MeasureunitDto>(measureunit);
        }

        public async Task<MeasureunitDto> DisabledAsync(int id)
        {
            // throw new NotImplementedException();
            Measureunit? measureunit = await _measureunitRepository.FindByIdAsync(id);

            if (measureunit is null) throw MeasureunitNotFound(id);

            measureunit.State = false;

            await _measureunitRepository.SaveAsync(measureunit);

            return _mapper.Map<MeasureunitDto>(measureunit);

        }

        public async Task<MeasureunitDto> EditAsync(int id, MeasureunitSaveDto saveDto)
        {
            //hrow new NotImplementedException();
            Measureunit? measureunit = await _measureunitRepository.FindByIdAsync(id);

            if (measureunit is null) throw MeasureunitNotFound(id);

            _mapper.Map<MeasureunitSaveDto, Measureunit>(saveDto, measureunit);

            await _measureunitRepository.SaveAsync(measureunit);

            return _mapper.Map<MeasureunitDto>(measureunit);

        }

        public async Task<IReadOnlyList<MeasureunitDto>> FindAllAsync()
        {
            //throw new NotImplementedException();
            IReadOnlyList<Measureunit> measureunits = await _measureunitRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<MeasureunitDto>>(measureunits);

        }

        public async Task<MeasureunitDto?> FindByIdAsync(int id)
        {
            //throw new NotImplementedException();

            Measureunit? measureunit = await _measureunitRepository.FindByIdAsync(id);

            if (measureunit is null) throw MeasureunitNotFound(id);

            return _mapper.Map<MeasureunitDto>(measureunit);

        }


        private NotFoundCoreException MeasureunitNotFound(int id)
        {
            return new NotFoundCoreException("Tipo measureunit no encontrado en el id: " + id);
        }



    }
}
