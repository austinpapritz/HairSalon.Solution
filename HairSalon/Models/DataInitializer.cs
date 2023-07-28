using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Models;

public class DataInitializer
{
    public static void InitializeData(WebApplication app)
    {
        using (var serviceScope = app.Services.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetRequiredService<HairSalonContext>();
            // Apply any pending migrations
            context.Database.Migrate();

            // If there are any stylists already, don't seed again
            if (context.Stylists.Any())
            {
                return;
            }

            // Add 3 stylists
            var stylists = new Stylist[]
            {
                new Stylist { Name = "Stylist 1" },
                new Stylist { Name = "Stylist 2" },
                new Stylist { Name = "Stylist 3" }
            };

            context.Stylists.AddRange(stylists);
            context.SaveChanges();

            // For each stylist, add 3 clients
            foreach (var stylist in stylists)
            {
                context.Clients.AddRange(
                    new Client { Name = "Client 1", StylistId = stylist.StylistId },
                    new Client { Name = "Client 2", StylistId = stylist.StylistId },
                    new Client { Name = "Client 3", StylistId = stylist.StylistId }
                );
            }
            context.SaveChanges();
        }
    }
}