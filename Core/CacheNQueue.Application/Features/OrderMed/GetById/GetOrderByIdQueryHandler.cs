using CacheNQueue.Application.Repositories.OrderRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Features.OrderMed
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQueryRequest, GetOrderByIdQueryrResponse>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<GetOrderByIdQueryrResponse> Handle(GetOrderByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var order= await _orderRepository.GetByIdAsync(request.OrderId,cancellationToken);
            return  GetOrderByIdQueryrResponse.Map(order);
        }
    }
}