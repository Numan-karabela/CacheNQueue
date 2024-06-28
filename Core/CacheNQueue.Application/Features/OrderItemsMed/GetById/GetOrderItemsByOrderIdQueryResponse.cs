using CacheNQueue.Application.Features.OrderMed;
using CacheNQueue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Features.OrderItemsMed
{
    public class GetOrderItemsByOrderIdQueryResponse
    {
        public Guid OrderId { get; set; } // Sipariş kimlik numarası  
        public Guid ProductId { get; set; } // Ürün kimlik numarası  
        public decimal UnitPrice { get; set; } // Birim fiyatı   

        public Order Order { get; set; } // İlgili sipariş
        public Product Product { get; set; } // İlgili ürün


        public static GetOrderItemsByOrderIdQueryResponse Map(OrderItem order)
        {
            return new GetOrderItemsByOrderIdQueryResponse()
            {
                 
                ProductId=order.ProductId,
                OrderId=order.OrderId,
                UnitPrice = order.UnitPrice, 
                Product = order.Product,
                Order= order.Order,

            };


        }
    }
}
