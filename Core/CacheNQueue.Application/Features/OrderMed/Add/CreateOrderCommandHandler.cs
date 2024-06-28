using AutoMapper;
using CacheNQueue.Application.Repositories.OrderItemsRepository;
using CacheNQueue.Application.Repositories.OrderRepository;
using CacheNQueue.Domain.Entities;
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
        private readonly IMapper mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            this.mapper = mapper;
        }



        async  Task<CreateOrderCommandResponse> IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>.Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {

           var a = await _orderRepository.GetUserAsync(request.UserId); 
           var map= CreateOrderCommandRequest.Map(request,a);
           await _orderRepository.AddAsync(map,cancellationToken);

            //foreach (var orderItem in request.OrderItems)
            //{
            //    orderItem.OrderId = request.Order.Id;
            //    await _orderItemRepository.AddAsync(orderItem);
            //}

            return new() 
            { 
             Message="Başarılı"
            };
        }
    }
}