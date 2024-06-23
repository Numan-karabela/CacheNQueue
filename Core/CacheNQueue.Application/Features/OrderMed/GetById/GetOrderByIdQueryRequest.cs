using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Features.OrderMed
{
    public class GetOrderByIdQueryRequest : IRequest<GetOrderByIdQueryrResponse>
    {
        public Guid OrderId { get; set; }

        public GetOrderByIdQueryRequest(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}