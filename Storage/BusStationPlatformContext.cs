using Microsoft.EntityFrameworkCore;

using BusStationPlatform.Domain.Entities;
using Route = BusStationPlatform.Domain.Entities.Route;

namespace BusStationPlatform.Storage
{
    public class BusStationPlatformContext : DbContext
    {
        public DbSet<User> User { get; set; } = null!;
        public DbSet<Passenger> Passenger { get; set; } = null!;
        public DbSet<Route> Route { get; set; } = null!;
        public DbSet<Invoice> Invoice { get; set; } = null!;
        public DbSet<Ticket> Ticket { get; set; } = null!;
        public DbSet<Seat> Seat { get; set; } = null!;
        public DbSet<OccupiedSeat> OccupiedSeat { get; set; } = null!;
        public DbSet<Payment> Payment { get; set; } = null!;

        public BusStationPlatformContext(DbContextOptions<BusStationPlatformContext> options) : base(options) 
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
    }
}
