using CacheNQueue.Application.Cache;
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
        readonly IRedisCacheService _cacheService;
        public ProductDeleteCommandHandler(IProductRepository productRepository, IRedisCacheService cacheService = null)
        {
            _productRepository = productRepository;
            _cacheService = cacheService;
        }

        public async Task<ProductDeleteCommandResponse> Handle(ProductDeleteCommandRequest request, CancellationToken cancellationToken)
        {


           var product=await _productRepository.GetByIdAsync(request.Id,cancellationToken);
            await _cacheService.DeleteAsync(product.Id, cancellationToken);

            await _productRepository.RemoveAsync(product, cancellationToken);

            return new()
            {
                 Message="Başarılı"
            };
        }
    }
}
