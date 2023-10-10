using Jazani.Core.Paginations;
using Jazani.Domain.Cores.Paginations;
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
        private readonly IPaginator<Investment> _paginator;

        public InvestmentRepository(ApplicationDbContext dbContext, IPaginator<Investment> paginator):base(dbContext)
        {
            _dbContext = dbContext;
            _paginator = paginator;
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

        public async Task<ResponsePagination<Investment>> PaginatedSearch(RequestPagination<Investment> request)
        {
            // throw new NotImplementedException();

            var filter = request.Filter;

            var query=_dbContext.Set<Investment>().AsQueryable();

            if(filter is not null)
            {
                query = query
                    .Where(x=>
                        (string.IsNullOrWhiteSpace(filter.Description) || x.Description.ToUpper().Contains(filter.Description.ToUpper())
                        && (filter.Year == null || filter.Year == 0) || x.Year == filter.Year)
                         && (string.IsNullOrWhiteSpace(filter.Monthname) || x.Monthname.ToUpper().Contains(filter.Monthname.ToUpper()))

                    );
            }

            query = query.OrderByDescending(x => x.Id)
                .Include(t => t.Investmentconcept)
                .Include(t => t.Holder)
                .Include(t => t.Investmenttype)
                .Include(t => t.Miningconcession)
                .Include(t => t.Measureunit)
                .Include(t => t.Periodtype);

            return await _paginator.Paginate(query, request);
        }
    }

}
