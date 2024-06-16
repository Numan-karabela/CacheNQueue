using CacheNQueue.Application.Cache;
using CacheNQueue.Application.Repositories.ProductRepository;
using CacheNQueue.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Med.ProductMed.Update
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommandRequest, ProductUpdateCommandResponse>
    {
        readonly IProductRepository _productRepository;
        readonly IRedisCacheService _cacheService;

        public ProductUpdateCommandHandler(IProductRepository productRepository, IRedisCacheService cacheService = null)
        {
            _productRepository = productRepository;
            _cacheService = cacheService;
        }

        public async Task<ProductUpdateCommandResponse> Handle(ProductUpdateCommandRequest request, CancellationToken cancellationToken)
        {
           Product product= ProductUpdateCommandRequest.MapToProduct(request);

           await _productRepository.Update(product);

            return new()
            {
                Message="başarılı"
            };
        }
    }
}
