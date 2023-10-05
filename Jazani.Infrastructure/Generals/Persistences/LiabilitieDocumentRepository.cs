using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Generals.Persistences
{
    public class LiabilitieDocumentRepository : CrudRepository<LiabilitieDocument, int>, ILiabilitieDocumentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LiabilitieDocumentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IReadOnlyList<LiabilitieDocument>> FindAllAsync()
        {

            return await _dbContext.Set<LiabilitieDocument>().Include(t=>t.Liabilitie).AsNoTracking().ToListAsync();
        }

        public override async Task<LiabilitieDocument?> FindByIdAsync(int id)
        {
            return await _dbContext.Set<LiabilitieDocument>().Include(t => t.Liabilitie).FirstOrDefaultAsync(t => t.DocumentId == id);
        }
    }
}
