using Microsoft.Extensions.DependencyInjection;
using ABBI.Application.Features;
using ABBI.Domain.Interfaces.Facade;

namespace ABBI.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
