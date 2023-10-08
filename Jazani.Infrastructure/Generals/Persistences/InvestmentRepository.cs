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
    public class InvestmentRepository : CrudRepository<Investment, int>, IInvestmentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public InvestmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;   
        }


        public override async Task<IReadOnlyList<Investment>> FindAllAsync()
        {
            //return base.FindAllAsync();
            return await _dbContext.Set<Investment>()
                .Include(t => t.Investmentconcept)
                .Include(t => t.Miningconcession)
                .Include(t => t.Periodtype)
                .Include(t => t.Measureunit)
                .Include(t => t.Investmenttype)
                .Include(t => t.Holder)
                .AsNoTracking().ToListAsync();
        }

        public override async Task<Investment?> FindByIdAsync(int id)
        {
            //return base.FindByIdAsync(id);
            return await _dbContext.Set<Investment>()
                .Include(t => t.Investmentconcept)
                .Include(t => t.Miningconcession)
                .Include(t => t.Periodtype)
                .Include(t => t.Measureunit)
                .Include(t => t.Investmenttype)
                .Include(t => t.Holder)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

    }

}
