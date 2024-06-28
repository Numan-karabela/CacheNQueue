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
        public Guid UserId { get; set; } // Kullanıcı kimlik numarası  
        public Guid ProductId { get; set; }//sipariş 
        public string Address { get; set; }//Address
        public string OrderStatus { get; set; } = "Şipariş Hazırlanıyor";
        public decimal UnitPrice { get; set; } // Birim fiyatı

    }

}
