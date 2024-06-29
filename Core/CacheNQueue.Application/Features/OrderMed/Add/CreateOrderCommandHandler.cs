﻿using AutoMapper;
using CacheNQueue.Application.Repositories.OrderItemsRepository;
using CacheNQueue.Application.Repositories.OrderRepository;
using CacheNQueue.Application.Repositories.ProductRepository;
using CacheNQueue.Domain.Entities;
using MediatR;
using Pipelines.Sockets.Unofficial;
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

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;   
        }



        async  Task<CreateOrderCommandResponse> IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>.Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
          

           var orderMap =CreateOrderCommandRequest.Map(request);


         await _orderRepository.AddAsync(orderMap,cancellationToken);


           
            return new() 
            { 
             Message="Başarılı"
            };
        }
    }
}