using CacheNQueue.Application.Med.ProductMed.Add;
using CacheNQueue.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Med.ProductMed.Update
{
    public class ProductUpdateCommandRequest:IRequest<ProductUpdateCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // Ürün adı 
        public string Description { get; set; } // Ürün açıklaması  
        public decimal Price { get; set; } // Ürün fiyatı 
        public int Stock { get; set; } // Stok miktarı 
        public static Product MapToProduct(ProductUpdateCommandRequest command)
        {
            return new Product()
            {   

                 Id= command.Id,
                Name = command.Name,
                Price = command.Price,
                Stock = command.Stock,
                Description = command.Description,

            };

        }
    }
}
