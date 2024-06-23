using CacheNQueue.Application.Repositories.OrderItemsRepository;
using CacheNQueue.Application.Repositories.OrderRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Features.OrderMed.Add
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }

       

       async  Task<CreateOrderCommandResponse> IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>.Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            await _orderRepository.AddAsync(request.Order, cancellationToken);

            foreach (var orderItem in request.OrderItems)
            {
                orderItem.OrderId = request.Order.Id;
                await _orderItemRepository.AddAsync(orderItem, cancellationToken);
            }

            return new() 
            { 
             Message="Başarılı"
            };
        }
    }
}