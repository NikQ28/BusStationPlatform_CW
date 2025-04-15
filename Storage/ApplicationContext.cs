using BusStationPlatform.Domains.Entities;
using Route = BusStationPlatform.Domains.Entities.Route;
using Microsoft.EntityFrameworkCore;

namespace BusStationPlatform.Storage
{
    public class BusStationPlatformContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Passenger> Passengers { get; set; } = null!;
        public DbSet<Route> Routes { get; set; } = null!;
        public DbSet<Invoice> Invoices { get; set; } = null!;
        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<Place> Places { get; set; } = null!;
        public DbSet<OccupiedPlace> OccupiedPlaces { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;

        public BusStationPlatformContext(DbContextOptions<BusStationPlatformContext> options) : base(options) { }
    }
}
