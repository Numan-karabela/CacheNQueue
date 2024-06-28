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
        public string OrderStatus { get; set; }
        public decimal TotalAmount { get; set; }




        public List<OrderItem> OrderItem1 { get; set; }
        public static Order Map(CreateOrderCommandRequest request,AppUser appUser,OrderItem orderItem,Product product)
        {
            return new Order()
            {
                Id=new Guid(),
                UserId = request.UserId,
                User = appUser,
                OrderStatus=request.OrderStatus,
                TotalAmount=request.TotalAmount,
                OrderItems=request.OrderItem1,
                
            };


        }
    }
}