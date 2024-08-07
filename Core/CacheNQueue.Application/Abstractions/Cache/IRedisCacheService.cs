﻿using CacheNQueue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Abstractions.Cache
{
    public interface IRedisCacheService
    {
        Task<Product> GetByıdAsync(Guid key, CancellationToken cancellationToken);
        Task<List<Product>> GetAllAsync(CancellationToken cancellationToken);
        Task SetAsync(Product product, CancellationToken cancellationToken);
        Task DeleteAsync(Guid key, CancellationToken cancellationToken);
        Task UpdatedAsync(Product product, CancellationToken cancellationToken);
    }
}
