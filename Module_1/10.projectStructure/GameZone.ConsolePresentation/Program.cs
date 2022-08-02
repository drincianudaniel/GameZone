﻿using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using GameZone.Application;
using GameZone.Application.Developers.Queries.GetDevelopersList;
using GameZone.Infrastructure.Repositories;
using GameZone.Application.Genres.Queries.GetGenresList;
using GameZone.Application.Platforms.Queries.GetPlatformsList;
using GameZone.Application.Games.Commands.CreateGame;
using GameZone.Application.Games.Queries.GetGameById;

namespace GameZone.ConsoleProject
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var diContainer = new ServiceCollection()
                .AddMediatR(typeof(IDeveloperRepository))
                .AddScoped<IGameRepository, InMemoryGameRepository>()
                .AddScoped<IDeveloperRepository, InMemoryDeveloperRepository>()
                .AddScoped<IGenreRepository, InMemoryGenreRepository>()
                .AddScoped<IPlatformRepository, InMemoryPlatformRepository>()
                .BuildServiceProvider();

            var mediator = diContainer.GetRequiredService<IMediator>();

            var developers = await mediator.Send(new GetDevelopersListQuery());
            var genres = await mediator.Send(new GetGenresListQuery());
            var platforms = await mediator.Send(new GetPlatformsListQuery());

            var gameId = await mediator.Send(new CreateGameCommand
            {
                Name = "Assassin's Creed",
                ReleaseDate = new DateTime(2000, 06, 16),
                GameDetails = "Game Details"
            });

            Console.WriteLine($"Game with id {gameId} created");

            var game = await mediator.Send(new GetGameByIdQuery
            {
                Id = 1,
            });

            ConsoleDisplay.DisplayGame(game);

            ConsoleDisplay.DisplayDevelopers(developers);
            ConsoleDisplay.DisplayGenres(genres);
            ConsoleDisplay.DisplayPlatforms(platforms);
        }
    }
}