using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Liabilities.Mappers
{
	public class LiabilitieMapper : Profile
	{
        // Clase LiabilitieMapper que configura el mapeo entre Liabilitie y LiabilitieDto utilizando AutoMapper
        public LiabilitieMapper()
		{
            // Se define una configuración de mapeo de Liabilitie a LiabilitieDto
            CreateMap<Liabilitie, LiabilitieDto>();
		}
	}
}

