using Jazani.Domain.Admins.Repositories;
using Jazani.Domain.Cores.Paginations;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infrastructure.Admins.Persistences;
using Jazani.Infrastructure.Cores.Paginations;
using Jazani.Infrastructure.Generals.Persistences;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


namespace Jazani.Infrastructure.Cores.Contexts
{
	public static class InfrastructureServiceRegistration
	{
        public static IServiceCollection addInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuramos del DbContext de Entity Framework Core para la base de datos
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                //Usamos SQL Server como proveedor de base de datos y nos conectamos mediante la cadena de conexión que hay en Config
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });

            // Registro de servicios transitorios entre interfaz e implementación
            //services.AddTransient<ILiabilitieRepository, LiabilitieRepository>();
            //services.AddTransient<IModuleRepository, ModuleRepository>();

            services.AddTransient(typeof(IPaginator<>), typeof(Paginator<>));


            return services;
		}

    }
}

