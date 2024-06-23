using AutoMapper;
using CacheNQueue.Application.Cache;
using CacheNQueue.Application.Repositories.ProductRepository;
using CacheNQueue.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Med.ProductMed.Add
{
    public class ProductCommandHandler : IRequestHandler<ProductAddCommandReques, ProductAddCommandResponse>
    {   readonly IProductRepository productRepository; 
        readonly IRedisCacheService _cacheService;
        public ProductCommandHandler(IProductRepository productRepository, IRedisCacheService cacheService = null)
        {
            this.productRepository = productRepository; 
            _cacheService = cacheService;
        }

        public async Task<ProductAddCommandResponse> Handle(ProductAddCommandReques request, CancellationToken cancellationToken)
        {
              
             var product= ProductAddCommandReques.MapToProduct(request); 
             await productRepository.AddAsync(product,cancellationToken);
             await _cacheService.SetAsync(product,cancellationToken);

             
            return new()
            {
             Message="Başarılı"
            };
        }
    }
}
