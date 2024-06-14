using CacheNQueue.Application.Repositories.ProductRepository;
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
        readonly IProductRepository productRepository;

        public RedisCacheService(IDistributedCache cache, IConfiguration collection, IProductRepository productRepository)
        {
            this.cache = cache;
            this.collection = collection;
            this.productRepository = productRepository;
        }


        public async Task<List<Product>> GetAllAsync()
        { 
            var productString = await cache.GetStringAsync(collection.GetConnectionString("GettAllRedis")); 
            if (string.IsNullOrEmpty(productString))
            {
                 productString=JsonSerializer.Serialize(await productRepository.GetAllAsync());
                 var  productStringh =  JsonSerializer.Deserialize<List<Product>>(productString);
                await SetAllAsync(productStringh);

                if (productString==null)
                {
                    return null;
                }
            } 
            return JsonSerializer.Deserialize<List<Product>>(productString);
        }

        public async Task<List<Product>> GetByıdAsync(Guid key) 
        { 
            var products = JsonSerializer.Deserialize<List<Product>>(await cache.GetStringAsync(collection.GetConnectionString("GettAllRedis")));
            products = products.Where(x => x.Id == key).ToList();

            return products;    
        }


        public async Task SetAsync(Product product)
        {
            await cache.SetStringAsync(collection.GetConnectionString("GettAllRedis"), JsonSerializer.Serialize(product));
           await  DeleteAllAsync();

        }

        public async Task SetAllAsync(List<Product> product) 
        {
            await cache.SetStringAsync(collection.GetConnectionString("GettAllRedis"), JsonSerializer.Serialize(product));
            await  GetAllAsync();
        }

        public async Task DeleteAllAsync() 
        {
            await cache.RemoveAsync(collection.GetConnectionString("GettAllRedis"));
            await GetAllAsync();
        }
    }
}
//