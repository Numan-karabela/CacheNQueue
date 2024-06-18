using CacheNQueue.Application.Repositories;
using CacheNQueue.Domain.Entities.Comman;
using CacheNQueue.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Persistence.Repositorty
{
    public class EfCoreRepositoryAsync<T> : IRepositoryAsync<T> where T :BaseEntity 
    {
        protected readonly CacheNQueueDbContext _context;
        CancellationTokenSource cts;
        CancellationToken token;

        public EfCoreRepositoryAsync(CacheNQueueDbContext context)
        {
            cts = new CancellationTokenSource();
            token =cts.Token;
            _context = context;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id, token);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync(token);
        }

         

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

         
    }
}
