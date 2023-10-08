using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.Investments.Profiles
{
    public class InvestmentProfile : Profile
    {

        public InvestmentProfile()
        {
            CreateMap<Investment,InvestmentDto>();

            CreateMap<Investment,InvestmentSaveDto>().ReverseMap();
        }
    }
}
