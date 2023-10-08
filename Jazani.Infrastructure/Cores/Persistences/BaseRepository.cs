﻿using Jazani.Domain.Cores.Models;
using Jazani.Domain.Cores.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Infrastructure.Cores.Persistences
{
    public abstract class BaseRepository<T,ID>:IBaseRepository<T,ID> where T : CoreModel<ID>
    {

        private readonly ApplicationDbContext _dbContext;
        private DbSet<T> _dbSet;

        protected BaseRepository(ApplicationDbContext dbContext, DbSet<T> dbSet)
        {
            _dbContext = dbContext;
            _dbSet = dbSet;
        }

        public async virtual Task<T?> DisabledByIdAsync(ID id)
        {
            //throw new NotImplementedException();

            T? entity = await _dbSet.FindAsync(id);

            if (entity is null) throw new Exception("No se encontro informacion para el id: " + id);

            entity.State = false;

            _dbSet.Update(entity);

            await _dbContext.SaveChangesAsync();


            return entity;

        }

        public async Task<IReadOnlyList<T>> FindAllAsync()
        {
            //throw new NotImplementedException();
            return await _dbSet
                .Where(x => x.State == true)
                .ToListAsync();
        }

        public Task<T?> FindByIdAsync(ID id)
        {
            throw new NotImplementedException();
        }

        public Task<T> SaveAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
