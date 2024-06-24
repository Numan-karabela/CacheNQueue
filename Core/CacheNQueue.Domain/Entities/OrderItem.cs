using CacheNQueue.Domain.Entities.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Domain.Entities
{
    public class OrderItem : BaseEntity// Sipariş
    {
        public Guid OrderId { get; set; } // Sipariş kimlik numarası  
        public Guid ProductId { get; set; } // Ürün kimlik numarası 
        public Guid Quantity { get; set; } // Ürün miktarı  
        public decimal UnitPrice { get; set; } // Birim fiyatı  
        public decimal TotalPrice { get; set; } // Toplam fiyat  
        public Order Order { get; set; } // İlgili sipariş
        public Product Product { get; set; } // İlgili ürün
    }

}
