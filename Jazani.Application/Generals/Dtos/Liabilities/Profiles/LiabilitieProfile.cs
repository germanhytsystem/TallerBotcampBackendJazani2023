using AutoMapper;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.Liabilities.Profiles
{
    public class LiabilitieDocumentProfile : Profile
    {
        public LiabilitieDocumentProfile()
        {
            CreateMap<Liabilitie, LiabilitieDto>();
            CreateMap<Liabilitie,LiabilitieSimpleDto>();

            CreateMap<Liabilitie, LiabilitieSaveDto>().ReverseMap();
        }
    }
}
