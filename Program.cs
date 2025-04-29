using BusStationPlatform.Domains.Services;
using BusStationPlatform.Storage;
using Microsoft.EntityFrameworkCore;
using BusStationPlatform.Domains.Services.Contracts;
using Microsoft.AspNetCore.Authentication.Cookies;
using BusStationPlatform.Domains.Services.UseCases;

namespace BusStationPlatform
{
    public class Programm
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<BusStationPlatformContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IPassengerRepository, PassengerRepository>();
            builder.Services.AddTransient<IRouteRepository, RouteRepository>();
            builder.Services.AddTransient<ITicketRepository, TicketRepository>();
            builder.Services.AddTransient<IInvoiceRepository, InvoiceRepository>();
            builder.Services.AddTransient<IPaymentRepository, PaymentRepository>();
            builder.Services.AddTransient<IPlaceRepository, PlaceRepository>();

            builder.Services.AddTransient<IAuthService, AuthService>();
            builder.Services.AddTransient<IBookingService, BookingService>();
            builder.Services.AddTransient<ISearchRouteService, SearchRouteService>();
            builder.Services.AddTransient<IReturnTicketService, ReturnTicketService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.MapControllers();

            app.Run();
        }
    }
}
