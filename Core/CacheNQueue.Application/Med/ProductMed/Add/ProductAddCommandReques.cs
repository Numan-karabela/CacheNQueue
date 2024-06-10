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
        public string Name { get; set; } // Ürün adı 
        public string Description { get; set; } // Ürün açıklaması  
        public decimal Price { get; set; } // Ürün fiyatı 
        public int Stock { get; set; } // Stok miktarı 
    }
}
