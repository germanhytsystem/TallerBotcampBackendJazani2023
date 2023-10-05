
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Generals.Models;
using Jazani.Infrastructure.Admins.Configurations;
using Jazani.Infrastructure.Generals.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Jazani.Infrastructure.Cores.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        //#region "DbSet"
        //public DbSet<Liabilitie> Liabilities { get; set; }
        //public DbSet<Module> Modules { get; set; }

        //public DbSet<LiabilitieType> LiabilitieTypes { get; set; }
        //#endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //modelBuilder.ApplyConfiguration(new LiabilitieConfiguration());
            //modelBuilder.ApplyConfiguration(new ModuleConfiguration());


            //modelBuilder.ApplyConfiguration(new LiabilitieTypeConfiguration());

            //Automatiza los aplicaciones del modelBuilder
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

            
    }
}

