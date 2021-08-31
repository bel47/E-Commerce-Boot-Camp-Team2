using Microsoft.Extensions.Logging;
using ABBI.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABBI.Infrastructure.Context
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
            }
        }
        private static IEnumerable<Order> GetPreconfiguredOrders() 
        {
            return new List<Order>
            {
                new Order(){ TotalPrice = 1000, UserName = "Some User", OrderItems = new List<OrderItemModel>() 
                { 
                    new OrderItemModel(1,"IPhone 12",50000),
                    new OrderItemModel(1,"Airpod Pro",10000)}
                }
            };
        }
    }
}
