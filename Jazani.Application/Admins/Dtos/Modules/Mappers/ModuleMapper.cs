using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Modules.Mappers
{
	public class ModuleMapper : Profile
	{
		public ModuleMapper()
		{
			CreateMap<Module, ModuleDto>();
		}
	}
}

