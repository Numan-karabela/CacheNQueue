using CacheNQueue.Application.Repositories.OrderRepository;
using CacheNQueue.Domain.Entities;
using CacheNQueue.Domain.Entities.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Features.OrderMed.Add
{
    
    public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
    {
        public Guid UserId { get; set; } // Kullanıcı kimlik numarası  
        public Guid ProductId { get; set; }//sipariş 
        public string Address { get; set; }//Address
        public string OrderStatus { get; set; } = "Şipariş Hazırlanıyor";
        public decimal UnitPrice { get; set; } // Birim fiyatı

        public static Order Map(CreateOrderCommandRequest request)
        {
            return new Order()
            {
                UserId=request.UserId,
                ProductId=request.ProductId,
                Address=request.Address,
                OrderStatus=request.OrderStatus,
                UnitPrice=request.UnitPrice,
                
            }; 
        }
    }
    
}