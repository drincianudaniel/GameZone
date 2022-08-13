﻿using GameZone.ConsolePresentation;
using MediatR;
using GameZone.Application.Games.Queries.GetGameById;
using GameZone.Application.Genres.Queries.GetGenreById;
using GameZone.Application.Users.Queries.GetUserById;
using GameZone.Application.Users.Queries.GetUsersList;
using GameZone.Application.Games.Queries.GetGamesList;
using GameZone.Application.Users.Commands.CreateUser;
using GameZone.Application.Comments.Commands.CreateComment;

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

                /*var adventure = await mediator.Send(new CreateGenreCommand
                {
                    Name = "Actions"
                });*/

                /*var platform = await mediator.Send(new CreatePlatformCommand
                {
                    Name= "Pc"
                });*/

                /*var AdventureId = new Guid("9FD822B7-826E-43B1-9FFE-08DA792AEF73");
                var ActionId = new Guid("97ae9a77-fb0a-4996-76c2-08da7b7557cd");

                var Playstation = new Guid("BB03BFDB-2BCD-425A-394D-08DA7B7599EE");
                var PC = new Guid("83C05113-FC33-4030-339A-08DA7B75A419");

                var Adventure = await mediator.Send(new GetGenreByIdQuery
                {
                    Id = AdventureId
                });

                var UbisoftId = new Guid("D1589C7A-F8E8-4093-C3FC-08DA7AC8530D");*/

                /*     var ac = await mediator.Send(new CreateGameCommand
                     {
                         Name = "TEST GAME",
                         ReleaseDate = new DateTime(2000, 06, 16),
                         GameDetails = "Game Details",
                         DeveloperList = { UbisoftId },
                         GenreList = {AdventureId, ActionId},
                         PlatformList = {Playstation,PC},
                     });*/

                /*    var minecraftId = new Guid("7A6CB079-A67B-43F4-8C4B-08DA7ABF3CAD");

                    var minecraft = await mediator.Send(new GetGameByIdQuery
                    {
                        Id= minecraftId,
                    });

                    var TestGameId = new Guid("ED3011BA-8A71-449F-94A1-08DA7B75E7C7");

                    var ac = await mediator.Send(new GetGameByIdQuery
                    {
                        Id= TestGameId,
                    });*/

                /*    var user1Id = await mediator.Send(new CreateUserCommand
                    {
                        Username = "Dani",
                        Email = "Dani@gmail.com",
                        Password = "password",
                        FirstName = "Dani",
                        LastName = "Dani",
                        Role = "Admin",

                    });*/


                /*  var userId = new Guid("C097E69D-4EE3-4386-8434-08DA7D0383A0");
                  var user = await mediator.Send(new GetUserByIdQuery
                  {
                      Id = userId,
                  });

                  var commentId = await mediator.Send(new CreateCommentCommand
                  {
                      UserId = user.Id,
                      GameId = ac.Id,
                      Content = "COMMENT"
                  });*/
                /* var review = await mediator.Send(new CreateReviewCommand
                 {
                     GameId = minecraftId,
                     UserId = userId,
                     Rating = 8,
                     Content = "average game"
                 });*/
                /*var developer = await mediator.Send(new CreateDeveloperCommand
                {
                    Name = "asdasdasd",
                    HeadQuarters = "Montasdassadasreal"
                });*/
                /*    ConsoleDisplay.DisplayGame(minecraft);
                    ConsoleDisplay.DisplayGame(ac);
                    ConsoleDisplay.DisplayUser(user);
                    var users = await mediator.Send(new GetUsersListQuery());
                    ConsoleDisplay.DisplayUsers(users);*/
                var id = new Guid("C097E69D-4EE3-4386-8434-08DA7D0383A0");
                var user = await mediator.Send(new GetUserByIdQuery
                {
                    Id = id
                });
                /*var games = await mediator.Send(new GetGameListQuery());
                ConsoleDisplay.DisplayGames(games);*/
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