using Microsoft.EntityFrameworkCore;
using VetClinicBackend.Database;
using VetClinicBackend.Service.OwnerService;
using VetClinicBackend.Service.PetService;

namespace VetClinicBackend;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<VetClinicDbContext>((opt) =>
        {
            var connectionString = builder.Configuration.GetConnectionString("DbConnectionString");
            opt.UseSqlServer(connectionString);
        });

        builder.Services.AddScoped<VetClinicDbContext>();

        builder.Services.AddTransient<IPetService,PetService>();

        builder.Services.AddTransient<IOwnerService, OwnerService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
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
