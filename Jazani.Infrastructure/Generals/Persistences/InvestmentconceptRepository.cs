using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistences;

namespace Jazani.Infrastructure.Generals.Persistences
{
    public class InvestmentconceptRepository : CrudRepository<Investmentconcept, int>, IInvestmentconceptRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public InvestmentconceptRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
