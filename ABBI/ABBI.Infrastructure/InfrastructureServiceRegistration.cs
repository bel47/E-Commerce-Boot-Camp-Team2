using Microsoft.Extensions.DependencyInjection;
using ABBI.Infrastructure.Context;
using ABBI.Infrastructure.Repository;
using ABBI.Domain.Seeds;
using ABBI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ABBI.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<OrderContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("OrderingConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
            services.AddScoped<IOrderRepository, OrderRepository>();
            return services;
        }
    }
}
