using AutoMapper;
using Jazani.Application.Generals.Dtos.Miningconcessions;
using Jazani.Domain.Generals.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jazani.Domain.Generals.Models;
using Jazani.Application.Cores.Exceptions;

namespace Jazani.Application.Generals.Services.Implementatios
{
    public class MiningconcessionService:IMiningconcessionService
    {
        private readonly IMiningconcessionRepository _miningconcessionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MiningconcessionService> _logger;

        public MiningconcessionService(IMiningconcessionRepository miningconcessionRepository, IMapper mapper, ILogger<MiningconcessionService> logger)
        {
            _miningconcessionRepository = miningconcessionRepository;
            _mapper = mapper;
            _logger = logger;
        }


        public async Task<MiningconcessionDto> CreateAsync(MiningconcessionSaveDto miningconcessionSaveDto)
        {

            //throw new NotImplementedException();
            Miningconcession? miningconcession= _mapper.Map<Miningconcession>(miningconcessionSaveDto);
            miningconcession.RegistrationDate = DateTime.Now;
            miningconcession.State = true;

            await _miningconcessionRepository.SaveAsync(miningconcession);

            return _mapper.Map<MiningconcessionDto>(miningconcession);

        }

        public async Task<MiningconcessionDto> DisabledAsync(int id)
        {
            //throw new NotImplementedException();
            Miningconcession? miningconcession=await _miningconcessionRepository.FindByIdAsync(id);

            if (miningconcession is null) throw MiningconcessionNotFound(id);

            miningconcession.State=false;

            await _miningconcessionRepository.SaveAsync(miningconcession);

            return _mapper.Map<MiningconcessionDto>(miningconcession);

        }

        public async Task<MiningconcessionDto> EditAsync(int id, MiningconcessionSaveDto miningconcessionSaveDto)
        {
            //throw new NotImplementedException();

            Miningconcession? miningconcession = await _miningconcessionRepository.FindByIdAsync(id);

            if (miningconcession is null) throw MiningconcessionNotFound(id);

             _mapper.Map<MiningconcessionSaveDto, Miningconcession>(miningconcessionSaveDto, miningconcession);

            await _miningconcessionRepository.SaveAsync(miningconcession);

            return _mapper.Map<MiningconcessionDto>(miningconcession);

        }

        public async Task<IReadOnlyList<MiningconcessionDto>> FindAllAsync()
        {
            //throw new NotImplementedException();
            IReadOnlyList<Miningconcession> miningconcessions=await _miningconcessionRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<MiningconcessionDto>>(miningconcessions);

        }

        public async Task<MiningconcessionDto?> FindByIdAsync(int id)
        {
            //throw new NotImplementedException();
            Miningconcession? miningconcession = await _miningconcessionRepository.FindByIdAsync(id);

            if (miningconcession is null)
            {
                throw MiningconcessionNotFound(id);
            }

            return  _mapper.Map<MiningconcessionDto>(miningconcession);

        }



        private NotFoundCoreException MiningconcessionNotFound(int id)
        {
            return new NotFoundCoreException("Tipo de miningconcession no encontrado: " + id);
        }


    }
}
