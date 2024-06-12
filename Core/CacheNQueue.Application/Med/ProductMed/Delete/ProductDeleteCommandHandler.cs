using CacheNQueue.Application.Repositories.ProductRepository;
using CacheNQueue.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Med.ProductMed.Delete
{
    public class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommandRequest, ProductDeleteCommandResponse>
    {
        private readonly IProductRepository _productRepository;

        public ProductDeleteCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDeleteCommandResponse> Handle(ProductDeleteCommandRequest request, CancellationToken cancellationToken)
        {


           Product product=await _productRepository.GetByIdAsync(request.Id); 
           await _productRepository.Remove(product);


            return new()
            {
                 Message="Başarılı"
            };
        }
    }
}
