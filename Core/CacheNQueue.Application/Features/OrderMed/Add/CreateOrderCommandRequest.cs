using CacheNQueue.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Features.OrderMed.Add
{
    public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
    {
        public Order Order { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public CreateOrderCommandRequest(Order order, List<OrderItem> orderItems)
        {
            Order = order;
            OrderItems = orderItems;
        }
    }
}