using GameZone.Application;
using GameZone.Domain;
using GameZone.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

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
            services.AddScoped<IGenreRepository, InMemoryGenreRepository>();
            services.AddScoped<IPlatformRepository, PlatformRepository>();
            services.AddScoped<IUserRepository, InMemoryUserRepository>();
            services.AddDbContext<GameZoneContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GameZoneTest;Trusted_Connection=True;ConnectRetryCount=0"));
            
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
        }
    }
}
