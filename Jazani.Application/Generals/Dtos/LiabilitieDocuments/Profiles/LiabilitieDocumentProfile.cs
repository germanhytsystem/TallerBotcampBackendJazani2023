using AutoMapper;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.LiabilitieDocuments.Profiles
{
    public class HolderProfile : Profile
    {
        public HolderProfile()
        {
            CreateMap<LiabilitieDocument, LiabilitieDocumentDto>();
    
  

            CreateMap<LiabilitieDocument, LiabilitieDocumentSaveDto>().ReverseMap();
        }
    }
}
