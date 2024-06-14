using CacheNQueue.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Cache
{
    public class RedisCacheService : IRedisCacheService
    {
        readonly IDistributedCache cache;
        readonly IConfiguration collection;

        public RedisCacheService(IDistributedCache cache, IConfiguration collection)
        {
            this.cache = cache;
            this.collection = collection;
        }


        public async Task<List<Product>> GetAll()
        {
            string key = collection.GetConnectionString("GettAllRedis");

            var productString = await cache.GetStringAsync(key);
            if (string.IsNullOrEmpty(productString))
            {
                return null;
            }

            return JsonSerializer.Deserialize<List<Product>>(productString);
        }

        public async Task<Product> GetByıd(Guid key)
        {
            var product = await cache.GetStringAsync(Convert.ToString(key));
            return JsonSerializer.Deserialize<Product>(product);
        }

        public async Task Delete(Guid key)
        { 
           await cache.RemoveAsync(Convert.ToString(key));
        } 

        public async Task DeleteAll()
        {
           string key = collection.GetConnectionString("GettAllRedis");
           await cache.RemoveAsync(key);
           GetAll();
        }  

        public async Task Set(Product product, Guid key)
        {
           var keyString=Convert.ToString(key);
           await cache.SetStringAsync(Convert.ToString(key),JsonSerializer.Serialize(product));
        } 

        public async Task  SetAll(List<Product> product, string key)
        {
            var productString=JsonSerializer.Serialize(product);
            await cache.SetStringAsync(key,productString);
        }
    }
}
