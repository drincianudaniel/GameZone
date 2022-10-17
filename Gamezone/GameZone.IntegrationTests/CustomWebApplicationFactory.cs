﻿using GameZone.Infrastructure;
using GameZone.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using WebMotions.Fake.Authentication.JwtBearer;

namespace GameZone.IntegrationTests
{
    public class CustomWebApplicationFactory<TProgram> 
        : WebApplicationFactory<TProgram> where TProgram : class
    {
        private SqliteConnection _connection;

        public CustomWebApplicationFactory()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        { 

            builder.ConfigureServices(services =>
            {
                var serviceDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<GameZoneContext>));
                services.Remove(serviceDescriptor);

/*                services.AddAuthentication(FakeJwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
*/
                var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlite()
                .BuildServiceProvider();

                services.AddDbContext<GameZoneContext>(options =>
                {
                    options.UseSqlite(_connection);
                    options.UseInternalServiceProvider(serviceProvider);
                }, ServiceLifetime.Scoped);

 
                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<GameZoneContext>();
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();
                    Utilities.InitializeDbForTests(db);
                }
            });
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _connection.Close();
            _connection.Dispose();
        }
    }
}
