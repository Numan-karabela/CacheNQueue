using AutoMapper;
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
        readonly IMapper mapper;
        readonly IDistributedCache cache;
        public ProductCommandHandler(IProductRepository productRepository, IMapper mapper, IDistributedCache cache)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
            this.cache = cache;
        }

        public async Task<ProductAddCommandResponse> Handle(ProductAddCommandReques request, CancellationToken cancellationToken)
        {
              
             var product= ProductAddCommandReques.MapToProduct(request); 
             await productRepository.AddAsync(product); 


             
            return new()
            {
             Message="Başarılı"
            };
        }
    }
}
