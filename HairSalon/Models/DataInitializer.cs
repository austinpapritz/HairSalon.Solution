//FOR DEVELOPMENT ONLY
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Models;

public class DataInitializer
{
    public static void InitializeData(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<HairSalonContext>();
            // Apply any pending migrations.
            context.Database.Migrate();

            // If there are any stylists already, don't run.
            if (context.Stylists.Any())
            {
                return;
            }

            // Add 3 stylists.
            var stylists = new Stylist[]
            {
                new Stylist { Name = "Stella Mae DuPont", Specialty= "Straight hair", Wage = 22.22m },
                new Stylist { Name = "Casey Montana", Specialty= "Coloring", Wage = 21.5m  },
                new Stylist { Name = "Alejandra Morales", Specialty= "Curly hair", Wage = 24.75m },
                new Stylist { Name = "Calvin Saitama", Specialty= "Facial hair", Wage = 19.98m }
            };

            context.Stylists.AddRange(stylists);
            context.SaveChanges();

            // For each stylist, add 3 clients with unique names.
            int clientCounter = 1;
            foreach (var stylist in stylists)
            {
                context.Clients.AddRange(
                    new Client { Name = "Client " + clientCounter++, StylistId = stylist.StylistId },
                    new Client { Name = "Client " + clientCounter++, StylistId = stylist.StylistId },
                    new Client { Name = "Client " + clientCounter++, StylistId = stylist.StylistId }
                );
            }
            context.SaveChanges();
        }
    }
}