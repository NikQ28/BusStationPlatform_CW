using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Domains.EntitiesDTO;
using BusStationPlatform.Domains.Services;
using BusStationPlatform.Storage;
using Microsoft.EntityFrameworkCore;

namespace BusStationPlatform
{
    class Programm
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connection));
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
