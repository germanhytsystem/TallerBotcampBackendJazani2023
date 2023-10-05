using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Generals.Persistences
{
    public class LiabilitieRepository : CrudRepository<Liabilitie, int>,ILiabilitieRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public LiabilitieRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IReadOnlyList<Liabilitie>> FindAllAsync()
        {
            return await _dbContext.Set<Liabilitie>().Include(t => t.Holder).AsNoTracking().ToListAsync();
        }

        public override async Task<Liabilitie?> FindByIdAsync(int id)
        {
            return await _dbContext.Set<Liabilitie>().Include(t => t.Holder).FirstOrDefaultAsync(t => t.Id== id);

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
