using Microsoft.EntityFrameworkCore;

namespace HairSalon.Models;

public class HairSalonContext : DbContext
{
    public DbSet<Stylist> Stylists { get; set; }
    public DbSet<Client> Clients { get; set; }

    public HairSalonContext(DbContextOptions options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Stylist>()
                // Wage can only have 2 decimal places.
                .Property(s => s.Wage)
                .HasPrecision(4, 2);
    }
}