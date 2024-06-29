using CacheNQueue.Application.Med.ProductMed.GetAll;
using CacheNQueue.Application.Repositories.OrderItemsRepository;
using CacheNQueue.Application.Repositories.OrderRepository;
using CacheNQueue.Application.Repositories.ProductRepository;
using CacheNQueue.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Features.OrderItemsMed
{
    public class GetOrderItemsByOrderIdQueryHandler : IRequestHandler<GetOrderItemsByOrderIdQueryRequest,GetOrderItemsByOrderIdQueryResponse>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        public GetOrderItemsByOrderIdQueryHandler(IOrderItemRepository orderItemRepository, IOrderRepository orderRepository)
        {
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
        }

        public  async Task<GetOrderItemsByOrderIdQueryResponse> Handle(GetOrderItemsByOrderIdQueryRequest request, CancellationToken cancellationToken)
        {
            var order =  await _orderRepository.GetByIdAsync(request.Id,cancellationToken);
            var product = await _productRepository.GetByIdAsync(order.ProductId,cancellationToken);
            var user =   await _orderRepository.GetUserAsync(order.UserId);

          return  GetOrderItemsByOrderIdQueryResponse.Map(product,user,order);
             
            
        }
    }
}