using CacheNQueue.Application.Med.ProductMed.GetById;
using CacheNQueue.Domain.Entities;
using CacheNQueue.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Features.OrderMed
{
    public class GetOrderByIdQueryrResponse
    {
        public string OrderStatus { get; set; } // Sipariş durumu 
        public decimal TotalAmount { get; set; } // Toplam tutar  

        public AppRole User { get; set; } // Siparişi veren kullanıcı
        public ICollection<OrderItem> OrderItems { get; set; } // Siparişin detayları

        public static GetOrderByIdQueryrResponse Map(Order order)
        {
            return new GetOrderByIdQueryrResponse()
            {
                OrderStatus = order.OrderStatus,
                TotalAmount = order.TotalAmount,
                User = order.User,
                OrderItems = order.OrderItems,

            };


        }
    }
}
