using ABBI.Application.Services;
using ABBI.Domain.Interfaces.Facade;
using Microsoft.Extensions.DependencyInjection;

namespace ABBI.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }
    }
}
