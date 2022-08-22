using GameZone.Application;
using GameZone.Infrastructure;
using GameZone.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameZone.ConsolePresentation
{
    // TODO: Remove this project
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
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IReplyRepository, ReplyRepository>();

            services.AddDbContext<GameZoneContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GameZone;Trusted_Connection=True;ConnectRetryCount=0"));
            
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
