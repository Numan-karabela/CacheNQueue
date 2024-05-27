using CacheNQueue.Domain.Entities.Identity;
using CacheNQueue.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Persistence
{
    public static class ServiceRegistrations
    {
        public static void AddPersistanceService(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<CacheNQueueDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("sql")));
            service.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<CacheNQueueDbContext>();

        }
    }
}
