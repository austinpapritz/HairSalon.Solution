using Microsoft.EntityFrameworkCore;

namespace HairSalon.Models
{
    public class HairSalonContext : DbContext
    {
        public DbSet<Stylist>? Stylists { get; set; }
        public DbSet<Client>? Clients { get; set; }

        public HairSalonContext(DbContextOptions options) : base(options) { }

        // Define the one-Stylist-to-many-Clients relationship using Fluent API
        // This allows db migration using EntityFrameworkCore.Design
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Build the Stylist Entity
            modelBuilder.Entity<Stylist>()
                // Stylist HasMany Clients
                .HasMany(s => s.Clients)
                // Client only WithOne stylist
                .WithOne(c => c.stylist)
                // Identify a Client's Stylist with the StylistId fk
                .HasForeignKey(c => c.StylistId);
        }
    }
}