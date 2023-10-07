using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Generals.Dtos.Investmentconcepts;
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

        public async Task<IReadOnlyList<InvestmentconceptDto>> FindAllAsync()
        {
            //throw new NotImplementedException();
            IReadOnlyList<Investmentconcept> investmentconcepts=await _investmentconceptRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<InvestmentconceptDto>>(investmentconcepts);


        }

        public async Task<InvestmentconceptDto?> FindByIdAsync(int id)
        {
            //throw new NotImplementedException();
            Investmentconcept? investmentconcept=await _investmentconceptRepository.FindByIdAsync(id);

            if (investmentconcept is null) throw new NotFoundCoreException("Tipo de persona no encontrado para el id"+id);

            return _mapper.Map<InvestmentconceptDto?>(investmentconcept);
        }
    }
}
