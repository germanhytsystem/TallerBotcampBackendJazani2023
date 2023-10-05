using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Infrastructure.Generals.Persistences
{
    public class LiabilitieTypeRepository : CrudRepository<LiabilitieType, int>,ILiabilitieTypeRepository
    {
        public LiabilitieTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        //private readonly ApplicationDbContext _dbContext;

        //public LiabilitieTypeRepository(ApplicationDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}


        //public async Task<IReadOnlyList<LiabilitieType>> FindAllAsync()
        //{
        //    //throw new NotImplementedException();
        //    return await _dbContext.LiabilitieTypes.AsNoTracking().ToListAsync();

        //}

        //public async Task<LiabilitieType?> FindByIdAsync(int id)
        //{
        //    //throw new NotImplementedException();
        //    return await _dbContext.LiabilitieTypes.FindAsync(id);
        //}

        //public async Task<LiabilitieType> SaveAsync(LiabilitieType liabilitieType)
        //{
        //    //throw new NotImplementedException();
        //    EntityState state = _dbContext.Entry(liabilitieType).State;

        //    _ = state switch
        //    {
        //        EntityState.Detached => _dbContext.LiabilitieTypes.Add(liabilitieType),
        //        EntityState.Modified => _dbContext.LiabilitieTypes.Update(liabilitieType)
        //    };

        //    await _dbContext.SaveChangesAsync();

        //    return liabilitieType;

        //}

    }
}
