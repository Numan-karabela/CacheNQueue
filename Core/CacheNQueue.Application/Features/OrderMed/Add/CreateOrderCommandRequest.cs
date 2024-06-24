using CacheNQueue.Domain.Entities;
using CacheNQueue.Domain.Entities.Identity;
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
        public string OrderStatus { get; set; } // Sipariş durumu 
        public decimal TotalAmount { get; set; } // Toplam tutar  

        public AppUser User { get; set; } // Siparişi veren kullanıcı 
        public CreateOrderCommandRequest(Order order, List<OrderItem> orderItems,Guid UserId, string orderStatus,decimal totalAmount, AppUser appUser)
        {
            Order = order;
            OrderItems = orderItems;
            OrderStatus = orderStatus;
            TotalAmount = totalAmount;
            User = appUser;
        }
    }
}