﻿using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Infrastructure.Generals.Persistences
{
    public class PeriodtypeRepository : CrudRepository<Periodtype, int>, IPeriodtypeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PeriodtypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
