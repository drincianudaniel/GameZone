﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using GameZone.Application;
using GameZone.Application.Developers.Queries.GetDevelopersList;
using GameZone.Infrastructure.Repositories;
using GameZone.Application.Genres.Queries.GetGenresList;
using GameZone.Application.Platforms.Queries.GetPlatformsList;
using GameZone.Application.Games.Commands.CreateGame;
using GameZone.Application.Games.Queries.GetGameById;
using GameZone.Application.Genres.Commands.CreateGenre;
using GameZone.Application.Developers.Queries.GetDeveloperById;
using GameZone.Application.DTOs;
using GameZone.Application.Games.Queries.GetGamesList;

namespace GameZone.ConsoleProject
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var diContainer = new ServiceCollection()
                .AddMediatR(typeof(IAssemblyMarker))
                .AddAutoMapper(typeof(IAssemblyMarker))
                .AddScoped<IGameRepository, InMemoryGameRepository>()
                .AddScoped<IDeveloperRepository, InMemoryDeveloperRepository>()
                .AddScoped<IGenreRepository, InMemoryGenreRepository>()
                .AddScoped<IPlatformRepository, InMemoryPlatformRepository>()
                .BuildServiceProvider();

            var mediator = diContainer.GetRequiredService<IMediator>();

            await mediator.Send(new CreateGenreCommand
            {
                Name = "Sports"
            });

            var developer = await mediator.Send(new GetDeveloperByIdQuery
            {
                Id = 1
            });

            var ac = await mediator.Send(new CreateGameCommand
            {
                Name = "Assassin's Creed",
                ReleaseDate = new DateTime(2000, 06, 16),
                GameDetails = "Game Details",
                Developers = new List<DeveloperDto>
                {
                    developer,
                },
                Genres = new List<GenreDto>
                {

                },
                Platforms = new List<PlatformDto>
                {

                }
            });

            var lol = await mediator.Send(new CreateGameCommand
            {
                Name = "League of Legends",
                ReleaseDate = new DateTime(2000, 06, 16),
                GameDetails = "Game Details",
                Developers = new List<DeveloperDto>
                {
                    developer,
                },
                Genres = new List<GenreDto>
                {

                },
                Platforms = new List<PlatformDto>
                {

                }
            });

            var developers = await mediator.Send(new GetDevelopersListQuery());
            var genres = await mediator.Send(new GetGenresListQuery());
            var platforms = await mediator.Send(new GetPlatformsListQuery());
            var games = await mediator.Send(new GetGameListQuery());

            var game = await mediator.Send(new GetGameByIdQuery
            {
                Id = 1,
            });

            ConsoleDisplay.DisplayGames(games);
            
            /*ConsoleDisplay.DisplayDeveloper(developer);
            ConsoleDisplay.DisplayGame(game);

            ConsoleDisplay.DisplayDevelopers(developers);
            ConsoleDisplay.DisplayGenres(genres);
            ConsoleDisplay.DisplayPlatforms(platforms);*/
        }
    }
}