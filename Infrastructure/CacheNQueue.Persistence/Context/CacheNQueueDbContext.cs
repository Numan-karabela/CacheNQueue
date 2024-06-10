using CacheNQueue.Domain.Entities;
using CacheNQueue.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Persistence.Context
{
    public class CacheNQueueDbContext:IdentityDbContext<AppUser,AppRole,string>
    {
         
        public CacheNQueueDbContext(DbContextOptions<CacheNQueueDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } // Ürünler tablosu
        public DbSet<Order> Orders { get; set; } // Siparişler tablosu
        public DbSet<OrderItem> OrderItems { get; set; } // Sipariş detayları tablosu 

    }
}
