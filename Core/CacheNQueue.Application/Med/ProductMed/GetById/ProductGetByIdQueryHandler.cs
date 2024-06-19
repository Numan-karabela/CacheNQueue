using AutoMapper;
using CacheNQueue.Application.Cache;
using CacheNQueue.Application.Repositories.ProductRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Med.ProductMed.GetById
{
    public class ProductGetByIdQueryHandler : IRequestHandler<ProductGetByIdQueryRequest, ProductGetByIdQueryResponse>
    {
        readonly IProductRepository productRepository;
        readonly IMapper mapper;
        readonly IRedisCacheService _cacheService;

        public ProductGetByIdQueryHandler(IProductRepository productRepository, IMapper mapper, IRedisCacheService cacheService = null)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<ProductGetByIdQueryResponse> Handle(ProductGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _cacheService.GetByıdAsync(request.Id, cancellationToken);
            if (product == null)
            {
                return null;
            }
            return ProductGetByIdQueryResponse.Map(product);

            
        }
    }
}
