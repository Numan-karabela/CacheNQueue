using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application
{
    public static class ServiceRegistrations
    {
        public static void AddAplicationService(this IServiceCollection services )
        {
            var assm=Assembly.GetExecutingAssembly();
            services.AddMediatR(assm); 


        }
    }
}
