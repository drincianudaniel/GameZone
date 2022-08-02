using GameZone.Domain.Exceptions;
using GameZoneModels;
using System;
using GameZone.Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using GameZone.Application;
using GameZone.Application.Developers.Queries.GetDevelopersList;
using GameZone.Infrastructure.Repositories;

namespace GameZone.ConsoleProject
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var diContainer = new ServiceCollection()
                .AddMediatR(typeof(IDeveloperRepository))
                .AddScoped<IDeveloperRepository, InMemoryDeveloperRepository>()
                .BuildServiceProvider();

            var mediator = diContainer.GetRequiredService<IMediator>();

            var developers = await mediator.Send(new GetDevelopersListQuery());

            foreach(var developer in developers)
            {
                Console.WriteLine(developer.DeveloperName);
            }
        }
    }
}