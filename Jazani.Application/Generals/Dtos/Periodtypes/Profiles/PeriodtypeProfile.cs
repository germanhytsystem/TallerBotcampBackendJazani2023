using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.Periodtypes.Profiles
{
    public class PeriodtypeProfile : Profile
    {
        public PeriodtypeProfile()
        {
            CreateMap<Periodtype,PeriodtypeDto>();

            CreateMap<Periodtype, PeriodtypeSimpleDto>();

            CreateMap<Periodtype, PeriodtypeSaveDto>().ReverseMap();
        }
    }
}
