using AutoMapper;
using Jazani.Domain.Generals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Dtos.Investmentconcepts.Profiles
{
    public class InvestmentconceptProfile:Profile
    {
        public InvestmentconceptProfile() { 
            
            CreateMap<Investmentconcept,InvestmentconceptDto>();

            CreateMap<Investmentconcept,InvestmentconceptSimpleDto>();

            CreateMap<Investmentconcept,InvestmentconceptSaveDto>().ReverseMap();
        }
    }
}
