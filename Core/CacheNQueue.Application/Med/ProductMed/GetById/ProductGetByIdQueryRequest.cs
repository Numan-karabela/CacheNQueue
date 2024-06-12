using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Med.ProductMed.GetById
{
    public class ProductGetByIdQueryRequest:IRequest<ProductGetByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
