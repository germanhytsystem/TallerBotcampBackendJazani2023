
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Jazani.Application.Cores.Contexts
{
    public static class ApplicationServiceRegistration
	{

        // Método para registrar servicios de la aplicación en el contenedor de dependencias
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Registro de servicios transitorios entre interfaz e implementación
            //services.AddTransient<IModuleService, ModuleService>();

            //services.AddTransient<ILiabilitieTypeService, LiabilitieTypeService>();

            return services;
		}

    }
}

