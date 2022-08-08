﻿using GameZone.Application;
using GameZone.Domain;
using GameZone.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameZone.ConsolePresentation
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(IAssemblyMarker));
            services.AddAutoMapper(typeof(IAssemblyMarker));
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IPlatformRepository, PlatformRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<GameZoneContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GameZoneTest;Trusted_Connection=True;ConnectRetryCount=0"));
            
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
