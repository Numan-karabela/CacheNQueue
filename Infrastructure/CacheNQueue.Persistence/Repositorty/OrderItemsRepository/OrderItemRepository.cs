using CacheNQueue.Domain.Entities;
using CacheNQueue.Persistence.Context;
using CacheNQueue.Persistence.Repositorty;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Repositories.OrderItemsRepository
{
    public class OrderItemRepository : EfCoreRepositoryAsync<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(CacheNQueueDbContext context) : base(context)
        {
        }
    }
}
