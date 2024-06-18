using CacheNQueue.Application.Repositories.ProductRepository;
using CacheNQueue.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
        CancellationTokenSource cts;
        CancellationToken  cancellationToken;

        public RedisCacheService(IDistributedCache cache, IConfiguration collection, IProductRepository productRepository)
        {
            this.cache = cache;
            this.collection = collection;
            this.productRepository = productRepository;
            cts = new CancellationTokenSource();
            cancellationToken = cts.Token;
        }


        public async Task<List<Product>> GetAllAsync()
        {
            var productString = await cache.GetStringAsync(collection.GetConnectionString("GettAllRedis"), cancellationToken);
            if (string.IsNullOrEmpty(productString))
            {
                productString = JsonSerializer.Serialize(await productRepository.GetAllAsync());
                var productStringh = JsonSerializer.Deserialize<List<Product>>(productString);
                await SetAllAsync(productStringh);

                if (productString == null)
                {
                    return null;
                }
            }
            return JsonSerializer.Deserialize<List<Product>>(productString);
        }

        public async Task<Product> GetByıdAsync(Guid key)
        {
            var productString = await cache.GetStringAsync(Convert.ToString(key), cancellationToken);
            if (string.IsNullOrEmpty(productString))
            {
                var products = JsonSerializer.Deserialize<List<Product>>(await cache.GetStringAsync(collection.GetConnectionString("GettAllRedis")));
                var productCache = products.FirstOrDefault(x => x.Id == key);
                var map = Convert.ToString(productCache);
                if (string.IsNullOrEmpty(map))
                {

                    return null;
                }

                await SetAsync(productCache);

                return productCache;

            }
            return JsonSerializer.Deserialize<Product>(productString);
        }


        public async Task SetAsync(Product product)
        {
            await cache.SetStringAsync($"{JsonSerializer.Serialize(product.Id)}", JsonSerializer.Serialize(product));
            var products = JsonSerializer.Deserialize<List<Product>>(await cache.GetStringAsync(collection.GetConnectionString("GettAllRedis")));
            products = products.ToList();
            products.Add(product);
            await cache.RemoveAsync(collection.GetConnectionString(("GettAllRedis")));
            await SetAllAsync(products); 
        }

        public async Task SetAllAsync(List<Product> product) //tamm
        {
            await cache.SetStringAsync(collection.GetConnectionString("GettAllRedis"), JsonSerializer.Serialize(product)); 
        }

        public async Task DeleteAsync(Guid key)
        {
            var products = JsonSerializer.Deserialize<List<Product>>(await cache.GetStringAsync(collection.GetConnectionString("GettAllRedis")));
            await cache.RemoveAsync($"{Convert.ToString(key)}");
            products = products.Where(x => x.Id != key).ToList();
            await SetAllAsync(products);

        }
    }
}