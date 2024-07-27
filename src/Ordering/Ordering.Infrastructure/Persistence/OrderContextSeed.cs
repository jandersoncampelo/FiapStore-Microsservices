using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistence
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

        private static List<Order> GetPreconfiguredOrders() => new()
        {
                new()
                {
                    UserName = "jandersoncampelo",
                    FirstName = "Janderson",
                    LastName = "Campelo",
                    EmailAddress = "jandersoncampelo@gmail.com",
                    AddressLine = "Rua Gaspar Dutra",
                    Country = "Brazil",
                    TotalPrice = 1500
                }
            };
    }
}
