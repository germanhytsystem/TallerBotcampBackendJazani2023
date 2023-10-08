﻿using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Generals.Dtos.Investmentconcepts;
using Jazani.Application.Generals.Dtos.Investments;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Services.Implementatios
{
    public class InvestmentService:IInvestmentService
    {
        private readonly IInvestmentRepository _investmentRepository;
        private readonly IMapper _mapper;

        public InvestmentService(IInvestmentRepository investmentRepository, IMapper mapper)
        {
            _investmentRepository = investmentRepository;
            _mapper = mapper;
        }

        public async Task<InvestmentDto> CreateAsync(InvestmentSaveDto saveDto)
        {
           // throw new NotImplementedException();
            Investment? investment= _mapper.Map<Investment>(saveDto);
            investment.RegistrationDate = DateTime.Now;
            investment.State = true;
           
            await _investmentRepository.SaveAsync(investment);


            return _mapper.Map<InvestmentDto>(investment);
        }

        public async Task<InvestmentDto> DisabledAsync(int id)
        {
            // throw new NotImplementedException();
            Investment? investment = await _investmentRepository.FindByIdAsync(id);

            if (investment is null) throw InvestmentNotFound(id);

            investment.State = false;

            await _investmentRepository.SaveAsync(investment);

            return _mapper.Map<InvestmentDto>(investment);

        }

        public async Task<InvestmentDto> EditAsync(int id, InvestmentSaveDto saveDto)
        {
            //hrow new NotImplementedException();
            Investment? Investment=await _investmentRepository.FindByIdAsync(id);

            if (Investment is null) throw InvestmentNotFound(id);

            _mapper.Map<InvestmentSaveDto, Investment>(saveDto, Investment);

            await _investmentRepository.SaveAsync(Investment);

            return _mapper.Map<InvestmentDto>(Investment);

        }

        public async Task<IReadOnlyList<InvestmentDto>> FindAllAsync()
        {
            //throw new NotImplementedException();
            IReadOnlyList<Investment> investments = await _investmentRepository.FindAllAsync();

            return  _mapper.Map<IReadOnlyList<InvestmentDto>>(investments);

        }

        public async Task<InvestmentDto?> FindByIdAsync(int id)
        {
            //throw new NotImplementedException();

            Investment? investment = await _investmentRepository.FindByIdAsync(id);

            if (investment is null) throw InvestmentNotFound(id);

            return _mapper.Map<InvestmentDto>(investment);

        }


        private NotFoundCoreException InvestmentNotFound(int id)
        {
            return new NotFoundCoreException("Tipo investment no encontrado en el id: " + id);
        }

    }
}
