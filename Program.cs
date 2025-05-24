using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

using BusStationPlatform.Storage;
using BusStationPlatform.Domain.Services.Contracts;
using BusStationPlatform.Domain.Services.UseCases;
using BusStationPlatform.Domain.Services.Contracts.Repositories;

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
                
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();
            builder.Services.AddScoped<IRouteRepository, RouteRepository>();
            builder.Services.AddScoped<ITicketRepository, TicketRepository>();
            builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
            builder.Services.AddScoped<ISeatRepository, SeatRepository>();
            
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<ISearchRouteService, SearchRouteService>();
            builder.Services.AddScoped<IReturnTicketService, ReturnTicketService>();
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<ISendTicketService, SendTicketService>();

            builder.Services.AddHostedService<InvoiceExpirationCheckService>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => options.LoginPath = "/api/auth/login");
            builder.Services.AddAuthorization();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
