using AutoMapper;
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
        readonly IMapper mapper;

        public ProductGettAllQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            this.mapper = mapper;
        }

        async Task<List<ProductGettAllQueryResponse>> IRequestHandler<ProductGettAllQueryRequest, List<ProductGettAllQueryResponse>>.Handle(ProductGettAllQueryRequest request, CancellationToken cancellationToken)
        { 

            var products = await _productRepository.GetAllAsync(); 
            var model= mapper.Map<List<ProductGettAllQueryResponse>>(products); 
            return new List<ProductGettAllQueryResponse>(model);
        }
    }
}
