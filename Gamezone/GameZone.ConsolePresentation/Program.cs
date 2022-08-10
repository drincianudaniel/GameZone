using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using GameZone.ConsolePresentation;
using MediatR;
using GameZone.Application.Games.Commands.CreateGame;
using GameZone.Application.Games.Queries.GetGameById;
using GameZone.Application.Genres.Commands.CreateGenre;
using GameZone.Application.Genres.Queries.GetGenreById;
using GameZone.Application.Users.Commands.CreateUser;
using GameZone.Application.DTOs;
using GameZone.Application.Users.Queries.GetUserById;
using GameZone.Application.Users.Queries.GetUsersList;
using GameZone.Application.Comments.Commands.CreateComment;
using GameZone.Application.Games.Queries.GetGamesList;
using GameZone.Application.Developers.Commands.CreateDeveloper;

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

                /*  var adventure = await mediator.Send(new CreateGenreCommand
                  {
                      Name = "Adventure"
                  });*/
                var AdventureId = new Guid("9FD822B7-826E-43B1-9FFE-08DA792AEF73");
                var Adventure = await mediator.Send(new GetGenreByIdQuery
                {
                    Id = AdventureId
                });

                /* var minecraft = await mediator.Send(new CreateGameCommand
                 {
                     Name = "Minecraft",
                     ReleaseDate = new DateTime(2000, 06, 16),
                     GameDetails = "Game Details",
                     Genres = { Adventure }
                 });*/

                var minecraftId = new Guid("7A6CB079-A67B-43F4-8C4B-08DA7ABF3CAD");

                var minecraft = await mediator.Send(new GetGameByIdQuery
                {
                    Id= minecraftId,
                });

                /*  var user1Id = await mediator.Send(new CreateUserCommand
                 {
                     Username = "Regular User",
                     Email = "regularuser@gmail.com",
                     Password = "password",
                     FirstName = "Regular",
                     LastName = "User",
                     Role = "Admin",
                     FavoriteGames =  { minecraft }

                 });
 */

                var userId = new Guid("01114767-38B3-4207-4CFA-08DA792B9F95");
                var user = await mediator.Send(new GetUserByIdQuery
                {
                    Id = userId,
                });

               /* var commentId = await mediator.Send(new CreateCommentCommand
                {
                    UserId = user.Id,
                    GameId = minecraft.Id,
                    Content = "test test"
                });*/

                /* var developer = await mediator.Send(new CreateDeveloperCommand
                 {
                     Name = "Ubisoft",
                     HeadQuarters = "Montreal"
                 });*/
                ConsoleDisplay.DisplayGame(minecraft);
                ConsoleDisplay.DisplayUser(user);
                var users = await mediator.Send(new GetUsersListQuery());
                ConsoleDisplay.DisplayUsers(users);

                var games = await mediator.Send(new GetGameListQuery());
                ConsoleDisplay.DisplayGames(games);
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
        */
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
              .ConfigureWebHostDefaults(webBuilder =>
              {
                  webBuilder.UseStartup<Startup>();
              });
    }
}