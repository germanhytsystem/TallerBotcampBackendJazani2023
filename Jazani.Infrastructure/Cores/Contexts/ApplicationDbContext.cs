using Jazani.Domain.Admins.Models;
using Jazani.Infrastructure.Admins.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Cores.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        #region "DbSet"
        public DbSet<Liabilitie> Liabilities { get; set; }
        public DbSet<Module> Modules { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfiguration(new LiabilitieConfiguration());
            modelBuilder.ApplyConfiguration(new ModuleConfiguration());
        }

            
    }
}

