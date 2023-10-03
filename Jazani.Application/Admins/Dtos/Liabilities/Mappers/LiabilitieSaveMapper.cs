using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Liabilities.Mappers
{
	public class LiabilitieSaveMapper : Profile
	{
		public LiabilitieSaveMapper()
		{
            // Se define una configuración de mapeo de Liabilitie a LiabilitieDto y viceversa (ReverseMap)
            CreateMap<Liabilitie, LiabilitieDto>().ReverseMap();
		}
	}
}

