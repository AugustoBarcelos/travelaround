using Microsoft.EntityFrameworkCore;
using TravelMapApi.Models;

namespace TravelMapApi.Data
{
    public class TravelMapDbContext : DbContext
    {
        public TravelMapDbContext(DbContextOptions<TravelMapDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Pin> Pins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração de muitos-para-muitos entre Trip e Pin
            modelBuilder.Entity<Pin>()
                        .HasMany(p => p.Trips)
                        .WithMany(t => t.Pins);
        }
    }
}
