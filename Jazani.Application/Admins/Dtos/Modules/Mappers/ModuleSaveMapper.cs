using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Modules.Mappers
{
	public class ModuleSaveMapper : Profile
	{
		public ModuleSaveMapper()
		{
			CreateMap<Module, ModuleSaveDto>().ReverseMap();
		}
	}
}

