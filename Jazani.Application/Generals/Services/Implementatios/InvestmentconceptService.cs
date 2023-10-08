using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Generals.Dtos.Investmentconcepts;
using Jazani.Application.Generals.Dtos.LiabilitieDocuments;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Services.Implementatios
{
    public class InvestmentconceptService : IInvestmentconceptService
    {

        private readonly IInvestmentconceptRepository _investmentconceptRepository;
        private readonly IMapper _mapper;

        public InvestmentconceptService(IInvestmentconceptRepository investmentconceptRepository, IMapper mapper)
        {
            _investmentconceptRepository = investmentconceptRepository;
            _mapper = mapper;
        }

        public async Task<InvestmentconceptDto> CreateAsync(InvestmentconceptSaveDto saveDto)
        {
            //throw new NotImplementedException();
            Investmentconcept investmentconcept=_mapper.Map<Investmentconcept>(saveDto);
            investmentconcept.RegistrationDate= DateTime.Now;
            investmentconcept.State = true; 

            await _investmentconceptRepository.SaveAsync(investmentconcept);

            return _mapper.Map<InvestmentconceptDto>(investmentconcept);
        }

        public async Task<InvestmentconceptDto> DisabledAsync(int id)
        {
            //throw new NotImplementedException();
            Investmentconcept? investmentconcept=await _investmentconceptRepository.FindByIdAsync(id);

            if (investmentconcept is null) throw InvestmentconceptNotFound(id);

            investmentconcept.State=false;

            await _investmentconceptRepository.SaveAsync( investmentconcept);

            return _mapper.Map<InvestmentconceptDto>(investmentconcept);

        }

        public async Task<InvestmentconceptDto> EditAsync(int id, InvestmentconceptSaveDto saveDto)
        {
            //throw new NotImplementedException();
            Investmentconcept? investmentconcept = await _investmentconceptRepository.FindByIdAsync(id);

            if(investmentconcept is null) throw InvestmentconceptNotFound(id);

            _mapper.Map<InvestmentconceptSaveDto, Investmentconcept>(saveDto, investmentconcept);

            await _investmentconceptRepository.SaveAsync(investmentconcept);

            return _mapper.Map<InvestmentconceptDto>(investmentconcept);

        }


        public async Task<IReadOnlyList<InvestmentconceptDto>> FindAllAsync()
        {
            //throw new NotImplementedException();
            IReadOnlyList<Investmentconcept> investmentconcepts = await _investmentconceptRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<InvestmentconceptDto>>(investmentconcepts);
        }

        public async Task<InvestmentconceptDto?> FindByIdAsync(int id)
        {
            //throw new NotImplementedException();
            Investmentconcept? investmentconcept = await _investmentconceptRepository.FindByIdAsync(id);

            if (investmentconcept is null) throw InvestmentconceptNotFound(id);

            return _mapper.Map<InvestmentconceptDto?>(investmentconcept);
        }


        public NotFoundCoreException InvestmentconceptNotFound(int id)
        {
            return new NotFoundCoreException("Tipo de Investmentconcept no encontrado: " + id);
        }
    }
}
