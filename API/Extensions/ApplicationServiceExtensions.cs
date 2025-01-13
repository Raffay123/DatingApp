using System;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
     IConfiguration config)
    {
        // Add services to the container.
        services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddOpenApi();
        services.AddDbContext<DataContext>(obj =>
        {
            obj.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });
 
        services.AddCors();
        //services.AddSingleton(); // for whole program to maintain a state
        //services.AddTransient(); // too short
        services.AddScoped<ITokenService, TokenService>();// interface and implementation used here
        //because it gives us abstraction and decoupling and make TokenService more testable

        return services;
    }
}
