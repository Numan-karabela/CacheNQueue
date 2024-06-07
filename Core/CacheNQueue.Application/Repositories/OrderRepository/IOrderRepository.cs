using CacheNQueue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Repositories.OrderRepository
{
    public interface IOrderRepository :IRepositoryAsync<Order>
    {
    }
}
