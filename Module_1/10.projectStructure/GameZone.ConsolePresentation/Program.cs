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
using GameZone.Application.Users.Commands.CreateUser;
using GameZone.Application.Users.Queries.GetUserById;
using GameZone.ConsolePresentation.Forms;
using GameZone.Application.Users.Commands.AddFavoriteGame;

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
                .AddScoped<IUserRepository, InMemoryUserRepository>()
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

            var acId = await mediator.Send(new CreateGameCommand
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

            var ac = await mediator.Send(new GetGameByIdQuery
            {
                Id= acId
            });

            var lolId = await mediator.Send(new CreateGameCommand
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

            var lol = await mediator.Send(new GetGameByIdQuery
            {
                Id= lolId
            });

            var user1Id = await mediator.Send(new CreateUserCommand
            {
                Username = "Regular User",
                Email = "regularuser@gmail.com",
                Password = "password",
                FirstName = "Regular",
                LastName = "User",
                Role = "Admin",
                FavoriteGames = new List<GameDto> { ac }

            });

            var developers = await mediator.Send(new GetDevelopersListQuery());
            var genres = await mediator.Send(new GetGenresListQuery());
            var platforms = await mediator.Send(new GetPlatformsListQuery());
            var games = await mediator.Send(new GetGameListQuery());

            var favgameadded = await mediator.Send(new AddFavoriteGameCommand
            {
                IdUser = 3,
                IdGame = 2
            });
            var user1 = await mediator.Send(new GetUserByIdQuery
            {
                Id = user1Id
            });
            ConsoleDisplay.DisplayUser(user1);

            /*ConsoleDisplay.DisplayDeveloper(developer);
            ConsoleDisplay.DisplayGame(game);

            ConsoleDisplay.DisplayDevelopers(developers);
            ConsoleDisplay.DisplayGenres(genres);
            ConsoleDisplay.DisplayPlatforms(platforms);*/
            Console.WriteLine("");
            bool repeat = false;
            char input;
            do
            {
                MenuForms.DisplayMenu();
                var loggedInUser = user1;
                Console.WriteLine($"Logged in as {loggedInUser.Username}");
                Console.Write("Choose an options: ");
                string s = Console.ReadLine();
                int n = Int32.Parse(s);
                switch (n)
                {
                    case 1:
                        ConsoleDisplay.DisplayGames(games);
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }
                Console.WriteLine("Would you like to repeat? Y/N");
                input = Convert.ToChar(Console.ReadLine());
                repeat = (input == 'Y' || input == 'y');
                Console.Clear();
            } while (input == 'Y' || input == 'y');
        }
    }
}