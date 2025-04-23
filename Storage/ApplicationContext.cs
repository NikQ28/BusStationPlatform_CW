using BusStationPlatform.Domains.Entities;
using Route = BusStationPlatform.Domains.Entities.Route;
using Microsoft.EntityFrameworkCore;

namespace BusStationPlatform.Storage
{
    public class BusStationPlatformContext : DbContext
    {
        public DbSet<User> User { get; set; } = null!;
        public DbSet<Passenger> Passenger { get; set; } = null!;
        public DbSet<Route> Route { get; set; } = null!;
        public DbSet<Invoice> Invoice { get; set; } = null!;
        public DbSet<Ticket> Ticket { get; set; } = null!;
        public DbSet<Place> Place { get; set; } = null!;
        public DbSet<OccupiedPlace> OccupiedPlace { get; set; } = null!;
        public DbSet<Payment> Payment { get; set; } = null!;

        public BusStationPlatformContext(DbContextOptions<BusStationPlatformContext> options) : base(options) { }
    }
}
