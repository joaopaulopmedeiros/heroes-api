﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebApi.Infrastructure.Database.Repositories;
using WebApi.Infrastructure.Databse.Contexts;
using WebApi.Mappers;
using WebApi.Services;

namespace WebApi.Infrastructure.Ioc
{
    public static class DIContainer
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<HeroDbContext>(options => {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.UseMySql(
                    Environment.GetEnvironmentVariable("DB_CONNECTION"),
                    new MySqlServerVersion(new Version(8, 0, 27))
                );
            });

            services.AddAutoMapper(typeof(HeroProfile));

            services.AddTransient<HeroRepository>();

            services.AddTransient<SearchHeroesService>();

            return services;
        }
    }
}
