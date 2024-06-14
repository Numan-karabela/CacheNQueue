using CacheNQueue.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Med.ProductMed.Add
{
    public class ProductAddCommandReques:IRequest<ProductAddCommandResponse>
    { 
            public string Name { get; set; } 
            public string Description { get; set; }    
            public decimal Price { get; set; }  
            public int Stock { get; set; }  
        public static Product MapToProduct(ProductAddCommandReques command)
        {
            return new Product()
            {   Id = Guid.NewGuid(),
                Name = command.Name,
                Price = command.Price,
                Stock = command.Stock,
                Description = command.Description,

            };

        }
         
    }
}
