using Microsoft.Extensions.Logging;
using ABBI.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Text.Json;
using ABBI.Domain.Entities;
using System;

namespace ABBI.Infrastructure.Context
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {

            try
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                if (!orderContext.Orders.Any())
                {
                    orderContext.Orders.AddRange(GetPreconfiguredOrders());
                    await orderContext.SaveChangesAsync();
                    logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
                }

                if (!orderContext.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText(@"../ABBI.Infrastructure/Contexts/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var item in brands)
                    {
                        orderContext.ProductBrands.Add(item);
                    }

                    await orderContext.SaveChangesAsync();
                }

                if (!orderContext.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText( @"../ABBI.Infrastructure/Contexts/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var item in types)
                    {
                        orderContext.ProductTypes.Add(item);
                    }

                    await orderContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
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
