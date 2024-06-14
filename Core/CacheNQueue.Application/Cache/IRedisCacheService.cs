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
        Task SetAsync (Product product);
        Task<List<Product>> GetByıdAsync(Guid key);
        Task<List<Product>> GetAllAsync();
        Task DeleteAllAsync();
    }
}
