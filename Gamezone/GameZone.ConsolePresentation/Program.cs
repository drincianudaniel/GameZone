using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using GameZone.ConsolePresentation;
using MediatR;
using GameZone.Application.Games.Commands.CreateGame;
using GameZone.Application.Games.Queries.GetGameById;
using GameZone.Application.Genres.Commands.CreateGenre;
using GameZone.Application.Genres.Queries.GetGenreById;

namespace GameZone.ConsoleProject
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var mediator = services.GetRequiredService<IMediator>();

                var AdventureId = new Guid("D433CFD8-659B-4EA3-C10A-08DA784C18A8");
                var Adventure = await mediator.Send(new GetGenreByIdQuery
                {
                    Id = AdventureId
                });

                /*var minecraft = await mediator.Send(new CreateGameCommand
                  {
                      Name = "Minecraft",
                      ReleaseDate = new DateTime(2000, 06, 16),
                      GameDetails = "Game Details",
                      Genres = { Adventure }
                  });*/

                var minecraftId = new Guid("220C20C9-DC4F-4273-D21A-08DA784C5713");

                var minecraft = await mediator.Send(new GetGameByIdQuery
                {
                    Id= minecraftId,
                });

               ConsoleDisplay.DisplayGame(minecraft);
            }

         

            host.Run();
            //var mediator = diContainer.GetRequiredService<IMediator>();

            /*
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
        }*/
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
              .ConfigureWebHostDefaults(webBuilder =>
              {
                  webBuilder.UseStartup<Startup>();
              });
    }
}