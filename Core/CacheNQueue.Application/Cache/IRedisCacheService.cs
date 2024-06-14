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
        Task Set(Product product, Guid key);
        Task SetAll(List<Product> product,string key);
        Task<Product> GetByıd(Guid key);
        Task<List<Product>> GetAll();
        Task Delete(Guid key);
        Task DeleteAll();
    }
}
