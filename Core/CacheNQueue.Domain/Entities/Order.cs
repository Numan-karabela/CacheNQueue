using CacheNQueue.Domain.Entities.Comman;
using CacheNQueue.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Domain.Entities
{
    public class Order : BaseEntity//sipariş
    {
        public string OrderStatus { get; set; } = "şipariş verildi";
        public decimal TotalAmount { get; set; } // Toplam tutar  
        public Guid UserId { get; set; } // Kullanıcı kimlik numarası  

        public AppUser User { get; set; } // Siparişi veren kullanıcı
        public ICollection<OrderItem> OrderItems { get; set; } // Siparişin detayları
    }

}
