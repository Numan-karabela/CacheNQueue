using CacheNQueue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Cache
{
     public  interface  IRedisCacheService
    {
        Task<Product> GetByıdAsync(Guid key);
        Task<List<Product>> GetAllAsync();
        Task SetAsync (Product product);
        Task DeleteAsync(Guid key);
    }
}
