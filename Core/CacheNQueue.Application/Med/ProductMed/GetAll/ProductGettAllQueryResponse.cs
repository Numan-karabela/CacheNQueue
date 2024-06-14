using CacheNQueue.Application.Med.ProductMed.Add;
using CacheNQueue.Application.Med.ProductMed.GetById;
using CacheNQueue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Med.ProductMed.GetAll
{
    public class ProductGettAllQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }   
        public string Description { get; set; }    
        public decimal Price { get; set; }  
        public int Stock { get; set; }

        public static ProductGettAllQueryResponse Map(Product product)
        {
            return new ProductGettAllQueryResponse()
            {   Id= product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,

            }; 

        }


    }
}
