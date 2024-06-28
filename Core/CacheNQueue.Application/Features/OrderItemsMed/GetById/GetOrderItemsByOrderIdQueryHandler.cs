using CacheNQueue.Application.Med.ProductMed.GetAll;
using CacheNQueue.Application.Repositories.OrderItemsRepository;
using CacheNQueue.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Features.OrderItemsMed
{
    public class GetOrderItemsByOrderIdQueryHandler : IRequestHandler<GetOrderItemsByOrderIdQueryRequest,List<GetOrderItemsByOrderIdQueryResponse>>
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public GetOrderItemsByOrderIdQueryHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public  async Task<List<GetOrderItemsByOrderIdQueryResponse>> Handle(GetOrderItemsByOrderIdQueryRequest request, CancellationToken cancellationToken)
        {
            var a = await _orderItemRepository.GetOrderItemsByOrderIdAsync(request.id, cancellationToken);
            //var productDtos = a.Select(x => GetOrderItemsByOrderIdQueryResponse.Map(x)); 
            return new  ();
        }
    }
}