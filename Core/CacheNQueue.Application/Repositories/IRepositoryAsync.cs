using CacheNQueue.Domain.Entities.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Repositories
{
    public interface IRepositoryAsync<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync(); 

        Task AddAsync(T entity); 

        Task UpdateAsync(T entity);

        Task RemoveAsync(T entity); 
    }
}

