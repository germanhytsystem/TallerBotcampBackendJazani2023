using AutoMapper;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.LiabilitieTypes
{
    public class LiabilitieTypeProfile : Profile
    {
        public LiabilitieTypeProfile()
        {
           CreateMap<LiabilitieType,LiabilitieTypeDto>();

            CreateMap<LiabilitieType,LiabilitieTypeSaveDto>().ReverseMap();
        }
    }
}
