using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistences;

namespace Jazani.Infrastructure.Generals.Persistences
{
    public class HolderRepository : CrudRepository<Holder, int>,IHolderRepository
    {

        public HolderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }


    }
}
