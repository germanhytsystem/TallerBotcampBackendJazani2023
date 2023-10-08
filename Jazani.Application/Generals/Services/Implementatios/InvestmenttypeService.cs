using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Generals.Dtos.Investmenttypes;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Services.Implementatios
{
    public class InvestmenttypeService:IInvestmenttypeService
    {
        private readonly IInvestmenttypeRepository _investmenttypeRepository;
        private readonly IMapper _mapper;

        public InvestmenttypeService(IInvestmenttypeRepository investmenttypeRepository, IMapper mapper)
        {
            _investmenttypeRepository = investmenttypeRepository;
            _mapper = mapper;
        }


        public async Task<InvestmenttypeDto> CreateAsync(InvestmenttypeSaveDto saveDto)
        {
            //throw new NotImplementedException();
            Investmenttype investmenttype = _mapper.Map<Investmenttype>(saveDto);
            investmenttype.RegistrationDate = DateTime.Now;
            investmenttype.State = true;

            await _investmenttypeRepository.SaveAsync(investmenttype);

            return _mapper.Map<InvestmenttypeDto>(investmenttype);
        }

        public async Task<InvestmenttypeDto> DisabledAsync(int id)
        {
            //throw new NotImplementedException();
            Investmenttype? investmenttype = await _investmenttypeRepository.FindByIdAsync(id);

            if (investmenttype is null) throw InvestmenttypeNotFound(id);

            investmenttype.State = false;

            await _investmenttypeRepository.SaveAsync(investmenttype);

            return _mapper.Map<InvestmenttypeDto>(investmenttype);

        }

        public async Task<InvestmenttypeDto> EditAsync(int id, InvestmenttypeSaveDto saveDto)
        {
            //throw new NotImplementedException();
            Investmenttype? investmenttype = await _investmenttypeRepository.FindByIdAsync(id);

            if (investmenttype is null) throw InvestmenttypeNotFound(id);

            _mapper.Map<InvestmenttypeSaveDto, Investmenttype>(saveDto, investmenttype);

            await _investmenttypeRepository.SaveAsync(investmenttype);

            return _mapper.Map<InvestmenttypeDto>(investmenttype);

        }


        public async Task<IReadOnlyList<InvestmenttypeDto>> FindAllAsync()
        {
            //throw new NotImplementedException();
            IReadOnlyList<Investmenttype> investmentconcepts = await _investmenttypeRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<InvestmenttypeDto>>(investmentconcepts);
        }

        public async Task<InvestmenttypeDto?> FindByIdAsync(int id)
        {
            //throw new NotImplementedException();
            Investmenttype? investmenttype = await _investmenttypeRepository.FindByIdAsync(id);

            if (investmenttype is null) throw InvestmenttypeNotFound(id);

            return _mapper.Map<InvestmenttypeDto?>(investmenttype);
        }


        public NotFoundCoreException InvestmenttypeNotFound(int id)
        {
            return new NotFoundCoreException("Tipo de Investmentconcept no encontrado: " + id);
        }


    }
}
