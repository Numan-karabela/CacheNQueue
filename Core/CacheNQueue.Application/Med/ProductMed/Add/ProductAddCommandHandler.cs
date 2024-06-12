using AutoMapper;
using CacheNQueue.Application.Repositories.ProductRepository;
using CacheNQueue.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Med.ProductMed.Add
{
    public class ProductCommandHandler : IRequestHandler<ProductAddCommandReques, ProductAddCommandResponse>
    {   readonly IProductRepository productRepository;
        readonly IMapper mapper;
        public ProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
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
