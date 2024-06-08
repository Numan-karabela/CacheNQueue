using CacheNQueue.Application.Repositories.ProductRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Med.ProductMed.Add
{
    public class ProductCommandHandler : IRequestHandler<ProductCommandReques, ProductCommandResponse>
    {   readonly IProductRepository productRepository;

        public ProductCommandHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<ProductCommandResponse> Handle(ProductCommandReques request, CancellationToken cancellationToken)
        {
           await productRepository.AddAsync(new()
            {
                 Name = request.Name,
                 Description = request.Description,
                 Price = request.Price,
                 Stock = request.Stock,
            });
            return new();

        }
    }
}
