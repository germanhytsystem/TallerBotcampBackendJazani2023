using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Admins.Persistences
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ModuleRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Module>> FindAllAsync()
        {
     
             var modules = await _dbContext.Modules.ToListAsync();
             return modules;

        
        }

        public async Task<Module?> FindByIdAsync(int id)
        {
            return await _dbContext.Modules
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Module> SaveAsync(Module Module)
        {
            EntityState state = _dbContext.Entry(Module).State;

            switch (state)
            {
                case EntityState.Detached:
                    _dbContext.Modules.Add(Module);
                    break;
                case EntityState.Modified:
                    _dbContext.Modules.Update(Module);
                    break;
            }

            //_ = state switch
            //{
            //    EntityState.Detached => _dbContext.Modules.Add(Module),
            //    EntityState.Modified => _dbContext.Modules.Update(Module)
            //};

            await _dbContext.SaveChangesAsync();

            return Module;
        }

    }
}

