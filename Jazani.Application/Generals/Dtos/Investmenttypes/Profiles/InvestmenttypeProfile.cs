using AutoMapper;
using Jazani.Domain.Generals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Dtos.Investmenttypes.Profiles
{
    public class InvestmenttypeProfile : Profile
    {
        public InvestmenttypeProfile()
        {

            CreateMap<Investmenttype, InvestmenttypeDto>();

            CreateMap<Investmenttype,InvestmenttypeSimpleDto>();

            CreateMap<Investmenttype, InvestmenttypeSaveDto>();

        }
    }
}
