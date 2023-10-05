using AutoMapper;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.Holders.Profiles
{
    public class HolderProfile : Profile
    {
        public HolderProfile()
        {
            CreateMap<Holder, HolderDto>();
            CreateMap<Holder, HolderSimpleDto>();

            CreateMap<Holder, HolderSaveDto>().ReverseMap();
        }
    }
}
