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
        public Guid Quantity { get; set; } // Ürün miktarı   
        public decimal UnitPrice { get; set; } // Birim fiyatı  
        public decimal TotalPrice { get; set; } // Toplam fiyat 

        public Order Order { get; set; } // İlgili sipariş
        public Product Product { get; set; } // İlgili ürün


        public static GetOrderItemsByOrderIdQueryResponse Map(OrderItem order)
        {
            return new GetOrderItemsByOrderIdQueryResponse()
            {

                Quantity=order.Quantity,
                ProductId=order.ProductId,
                OrderId=order.OrderId,
                UnitPrice = order.UnitPrice,
                TotalPrice = order.TotalPrice,
                Product = order.Product,
                Order= order.Order,

            };


        }
    }
}
