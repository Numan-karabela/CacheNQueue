using CacheNQueue.Domain.Entities;
using CacheNQueue.Persistence.Context;
using CacheNQueue.Persistence.Repositorty;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Repositories.OrderRepository
{
    public class OrderRepository : EfCoreRepositoryAsync<Order>, IOrderRepository
    {
        public OrderRepository(CacheNQueueDbContext context) : base(context)
        {
        }
        public async Task<List<Order>> GetOrdersByUserIdAsync(Guid userId)
        {
            return await _context.Orders
                                 .Where(o => o.UserId == userId)
                                 .Include(o => o.OrderItems)
                                 .ToListAsync();
        }
    }
}
