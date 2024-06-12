using AutoMapper;
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

        public ProductGetByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<ProductGetByIdQueryResponse> Handle(ProductGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
          var product= await productRepository.GetByIdAsync(request.Id);

            return ProductGetByIdQueryResponse.Map(product);

            
        }
    }
}
