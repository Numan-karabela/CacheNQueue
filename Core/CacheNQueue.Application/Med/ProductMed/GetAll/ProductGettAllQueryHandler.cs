using CacheNQueue.Application.Repositories.ProductRepository;
using CacheNQueue.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CacheNQueue.Application.Med.ProductMed.GetAll
{
    public class ProductGettAllQueryHandler : IRequestHandler<ProductGettAllQueryRequest,List<ProductGettAllQueryResponse>>
    {
        readonly   IProductRepository _productRepository;

        public ProductGettAllQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
         
        async Task<List<ProductGettAllQueryResponse>> IRequestHandler<ProductGettAllQueryRequest, List<ProductGettAllQueryResponse>>.Handle(ProductGettAllQueryRequest request, CancellationToken cancellationToken)
        {
            List<Product> products =await _productRepository.GetAllAsync();

            return products.Select(o => new ProductGettAllQueryResponse
            {
                 Name=o.Name,
                 Price=o.Price,
                 Stock=o.Stock,
                Description = o.Description
            }).ToList();

        }
    }
}
