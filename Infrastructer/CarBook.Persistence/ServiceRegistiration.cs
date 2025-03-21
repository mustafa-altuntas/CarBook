﻿using CarBook.Persistence.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CarBook.Persistence
{
    public static class ServiceRegistiration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CarBookContext>(opts => opts.UseNpgsql(configuration.GetConnectionString("Postgres")));
        }

        public static void UseSeedData(this WebApplication app)
        {
            SeedData.SeedDatabase(app.Services);
        }
    }
}
