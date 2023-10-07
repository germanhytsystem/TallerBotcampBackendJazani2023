using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.Miningconcessions.Profiles
{
    public class MiningconcessionProfile:Profile
    {
        public MiningconcessionProfile()
        {
            CreateMap<Miningconcession,MiningconcessionDto>();

            CreateMap<Miningconcession, MiningconcessionSaveDto>().ReverseMap();
        }
    }
}
