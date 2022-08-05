using MediatR;
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
using GameZone.Application.Users.Queries.GetUsersList;
using GameZone.Application.Games.Commands.DeleteGame;

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
                FavoriteGames = new List<GameDto> { }

            });

            var developers = await mediator.Send(new GetDevelopersListQuery());
            var genres = await mediator.Send(new GetGenresListQuery());
            var platforms = await mediator.Send(new GetPlatformsListQuery());
            var games = await mediator.Send(new GetGameListQuery());
            var users = await mediator.Send(new GetUsersListQuery());

            var favgameadded = await mediator.Send(new AddFavoriteGameCommand
            {
                IdUser = 3,
                IdGame = 2
            });


            bool repeat = false;
            char input;
            do
            {
                var user1 = await mediator.Send(new GetUserByIdQuery
                {
                    Id = user1Id
                });
                var loggedInUser = user1;
                MenuForms.DisplayMenu();
                Console.WriteLine($"Logged in as {loggedInUser.Username}");
                Console.Write("Choose an options: ");
                string s = Console.ReadLine();
                int n = Int32.Parse(s);
                switch (n)
                {
                    case 1:
                        ConsoleDisplay.DisplayGames(games);
                        break;
                    case 2:
                        ConsoleDisplay.DisplayUsers(users);
                        break;
                    case 3:
                        Console.Write("Enter ID: ");
                        int idGame = int.Parse(Console.ReadLine().ToString());
                        var game = await mediator.Send(new GetGameByIdQuery
                        {
                            Id= idGame
                        });
                        ConsoleDisplay.DisplayGame(game);
                        break;
                    case 4:
                        Console.Write("Enter ID: ");
                        int idUser = int.Parse(Console.ReadLine().ToString());
                        var user = await mediator.Send(new GetUserByIdQuery
                        {
                            Id = idUser
                        });
                        ConsoleDisplay.DisplayUser(user);
                        break;
                        case 5:
                            do
                            {

                                ConsoleDisplay.DisplayGames(games);
                                Console.WriteLine("Choose a game from the list to manage: ");
                                int gameId = int.Parse(Console.ReadLine().ToString());
                                var gameChoosed = await mediator.Send(new GetGameByIdQuery
                                {
                                    Id= gameId
                                });
                                Console.WriteLine($"The choosen game is {gameChoosed.Name}");
                                MenuForms.DisplayGameMenu();
                                Console.Write("Choose an option: ");
                                s = Console.ReadLine();
                                n = Int32.Parse(s);
                                switch (n)
                                {
                                    case 1:
                                        var gameToBeAdded = await mediator.Send(new AddFavoriteGameCommand
                                        {
                                            IdUser = loggedInUser.Id,
                                            IdGame = gameChoosed.Id
                                        });
                                        Console.WriteLine("Game added");
                                    break;
                                    default:
                                        Console.WriteLine("Invalid selection");
                                        break;
                                }
                                Console.WriteLine("Would you like to repeat? Y/N");
                                input = Convert.ToChar(Console.ReadLine());
                            } while (input == 'Y' || input == 'y');
                            break;
                    case 6:
                        Console.WriteLine("Enter id of the game you want to remove: ");
                        int idgameToRemove = int.Parse(Console.ReadLine().ToString());
                        var gameToRemove = await mediator.Send(new DeleteGameCommand
                        {
                            Id = idgameToRemove
                        });
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