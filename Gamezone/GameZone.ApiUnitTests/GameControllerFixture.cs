using AutoMapper;
using GameZone.Api.AutoMapperProfiles;
using GameZone.Api.Controllers;
using GameZone.Api.DTOs;
using GameZone.Api.ViewModels;
using GameZone.Application.Games.Commands.CreateGame;
using GameZone.Application.Games.Commands.DeleteGame;
using GameZone.Application.Games.Commands.UpdateGame;
using GameZone.Application.Games.Queries.GetGameById;
using GameZone.Application.Games.Queries.GetGamesList;
using GameZone.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GameZone.ApiUnitTests
{
    public class GameControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly Mock<ILogger<GamesController>> _mockLogger = new Mock<ILogger<GamesController>>();
        [Fact]
        public async Task Get_All_Games_GetAllGamesListQueryIsCalled()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetGameListQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new GamesController(_mockMapper.Object, _mockMediator.Object, _mockLogger.Object);
            await controller.GetGames();

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetGameListQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Get_Game_By_Id_GetGamesByIdQueryIsCalled()
        {
            //Arange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetGameByIdQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new GamesController(_mockMapper.Object, _mockMediator.Object, _mockLogger.Object);
            await controller.GetById(new Guid());

            _mockMediator.Verify(x => x.Send(It.IsAny<GetGameByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Get_Game_By_Id_GetGameByIdQueryWithCorrectGameIdIsCalled()
        {
            //Arrange
            var gameId = new Guid();
            
            _mockMediator
               .Setup(m => m.Send(It.IsAny<GetGameByIdQuery>(), It.IsAny<CancellationToken>()))
               .Returns<GetGameByIdQuery, CancellationToken>(async (q, c) =>
               {
                   gameId = q.Id;
                   return await Task.FromResult(
                       new Game
                       {
                           Id = q.Id,
                           Name = "Assassins Creed"
                       });
               });

            //Act
            var controller = new GamesController(_mockMapper.Object, _mockMediator.Object, _mockLogger.Object);
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");
            await controller.GetById(guid);

            //Assert
            Assert.Equal(gameId, guid);
        }

        [Fact]
        public async Task Get_Genre_By_Id_ShouldReturnOkStatusCode()
        {
            //Arrange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");
            _mockMediator
             .Setup(m => m.Send(It.IsAny<GetGameByIdQuery>(), It.IsAny<CancellationToken>()))
             .ReturnsAsync(
                new Game
                {
                    Id = guid,
                    Name = "Assassins creed"
                });

            //Act
            var controller = new GamesController(_mockMapper.Object, _mockMediator.Object, _mockLogger.Object);
            var result = await controller.GetById(guid);
            var okResult = result as OkObjectResult;
            //Assert
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task Get_Game_By_Id_ShouldReturnFoundGame()
        {
            //Arange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");
            var game = new Game
            {
                Id = guid,
                Name="Assassins Creed"
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetGameByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(game);

            _mockMapper.Setup(m => m.Map<GameDto>(It.IsAny<Game>()))
               .Returns(new GameDto
               {
                   Id = guid,
                   Name="Assassins Creed"
               });

            var mappedGame = _mockMapper.Object.Map<GameDto>(game);
            //Act
            var controller = new GamesController(_mockMapper.Object, _mockMediator.Object, _mockLogger.Object);
            var result = await controller.GetById(guid);
            var okResult = result as OkObjectResult;

            //Assert
            Assert.Equal(mappedGame.Name, ((GameDto)okResult.Value).Name);
        }

        [Fact]
        public async Task CallPost_ReturnsGameDto()
        {
            //Arrange
            var genre = new Genre
            {
                Id = new Guid("3256165c-e08a-4d17-a4c7-bb5d01a2f982"),
                Name = "Action"
            };

            var developer = new Developer
            {
                Id = new Guid("945a91c1-0d5d-4a39-82c9-02a75111a89d"),
                Name = "Ubisoft",
                Headquarters = "Montreal"
            };

            var platform = new Platform
            {
                Id = new Guid("e79c2cad-7117-414a-8fdc-70d83c01b4dc"),
                Name = "PlayStation 4"
            };

            var createGameCommand = new GameViewModel
            {
                Name = "Assassin's Creed",
                GameDetails = "Assassin's Creed is an action-adventure video game developed by Ubisoft Montreal and published by Ubisoft. It is the first installment in the Assassin's Creed series. The game was released for PlayStation 3 and Xbox 360 in November 2007.",
                ReleaseDate = new DateTime(2011, 2, 16),
                ImageSrc = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRcHNm4Py0J8lgox2kPl87ZTV4aRjRcIZcq5hyBZX8q&s",
                GenreList = new List<Guid>{ genre.Id },
                DeveloperList = new List<Guid>{ developer.Id },
                PlatformList = new List<Guid>{ platform.Id }
            };
            
            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreateGameCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Game
                {
                    Name = "Assassin's Creed",
                    GameDetails = "Assassin's Creed is an action-adventure video game developed by Ubisoft Montreal and published by Ubisoft. It is the first installment in the Assassin's Creed series. The game was released for PlayStation 3 and Xbox 360 in November 2007.",
                    ReleaseDate = new DateTime(2011, 2, 16),
                    ImageSrc = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRcHNm4Py0J8lgox2kPl87ZTV4aRjRcIZcq5hyBZX8q&s",
                    Developers = new List<Developer> { developer },
                    Genres = new List<Genre> { genre },
                    Platforms = new List<Platform> { platform },
                });

            _mockMapper.Setup(m => m.Map<GenreDto>(It.IsAny<Genre>()))
              .Returns(new GenreDto
              {
                  Id = new Guid("3256165c-e08a-4d17-a4c7-bb5d01a2f982"),
                  Name = "Action"
              });

            _mockMapper.Setup(m => m.Map<DeveloperDto>(It.IsAny<Developer>()))
              .Returns(new DeveloperDto
              {
                  Id = new Guid("945a91c1-0d5d-4a39-82c9-02a75111a89d"),
                  Name = "Ubisoft",
                  Headquarters = "Montreal"
              });

            _mockMapper.Setup(m => m.Map<PlatformDto>(It.IsAny<Platform>()))
              .Returns(new PlatformDto
              {
                  Id = new Guid("e79c2cad-7117-414a-8fdc-70d83c01b4dc"),
                  Name = "PlayStation 4"
              });

            var genreDto = _mockMapper.Object.Map<GenreDto>(genre);
            var developerDto = _mockMapper.Object.Map<DeveloperDto>(developer);
            var platformDto = _mockMapper.Object.Map<PlatformDto>(platform);

            _mockMapper.Setup(m => m.Map<GameDto>(It.IsAny<Game>()))
               .Returns(new GameDto
               {
                   Name = "Assassin's Creed",
                   GameDetails = "Assassin's Creed is an action-adventure video game developed by Ubisoft Montreal and published by Ubisoft. It is the first installment in the Assassin's Creed series. The game was released for PlayStation 3 and Xbox 360 in November 2007.",
                   ReleaseDate = new DateTime(2011, 2, 16),
                   ImageSrc = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRcHNm4Py0J8lgox2kPl87ZTV4aRjRcIZcq5hyBZX8q&s",
                   Developers = new List<DeveloperDto> { developerDto },
                   Genres = new List<GenreDto> { genreDto },
                   Platforms = new List<PlatformDto> { platformDto },
               });

            //Act
            var controller = new GamesController(_mockMapper.Object, _mockMediator.Object, _mockLogger.Object);
            var result = await controller.CreateGame(createGameCommand);
            var createdAtActionResult = result as CreatedAtActionResult;

            //Assert
            Assert.Equal(createGameCommand.Name, ((GameDto)createdAtActionResult.Value).Name);
            Assert.Equal(createGameCommand.GameDetails, ((GameDto)createdAtActionResult.Value).GameDetails);
            Assert.Equal(createGameCommand.ReleaseDate, ((GameDto)createdAtActionResult.Value).ReleaseDate);
            Assert.Equal(createGameCommand.ImageSrc, ((GameDto)createdAtActionResult.Value).ImageSrc);
            Assert.Equal(createGameCommand.GenreList.ElementAt(0), ((GameDto)createdAtActionResult.Value).Genres.ElementAt(0).Id);
            Assert.Equal(createGameCommand.DeveloperList.ElementAt(0), ((GameDto)createdAtActionResult.Value).Developers.ElementAt(0).Id);
            Assert.Equal(createGameCommand.PlatformList.ElementAt(0), ((GameDto)createdAtActionResult.Value).Platforms.ElementAt(0).Id);
        }

        [Fact]
        public async Task Delete_Game_Should_Return_No_Content()
        {
            //Arrange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");

            var game = new Game
            {
                Id = guid,
                Name="Assassin's Creed"
            };

            _mockMediator
             .Setup(m => m.Send(It.IsAny<DeleteGameCommand>(), It.IsAny<CancellationToken>()))
             .ReturnsAsync(game.Id);

            //Act
            var controller = new GamesController(_mockMapper.Object, _mockMediator.Object, _mockLogger.Object);
            var result = await controller.DeleteGame(guid);
            var noContentResult = result as NoContentResult;
            //Assert
            Assert.Equal((int)HttpStatusCode.NoContent, noContentResult.StatusCode);
        }

        [Fact]
        public async Task Update_Game_Should_Return_OkStatusCode()
        {
            //Arrange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");

            var updateGameCommand = new GameViewModel
            {
                Name = "Assassin's Creed",
                GameDetails = "Assassin's Creed is an action-adventure video game developed by Ubisoft Montreal and published by Ubisoft. It is the first installment in the Assassin's Creed series. The game was released for PlayStation 3 and Xbox 360 in November 2007.",
                ReleaseDate = new DateTime(2011, 2, 16),
                ImageSrc = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRcHNm4Py0J8lgox2kPl87ZTV4aRjRcIZcq5hyBZX8q&s",
            };

            _mockMediator
             .Setup(m => m.Send(It.IsAny<UpdateGameCommand>(), It.IsAny<CancellationToken>()))
             .ReturnsAsync(new Game
             {
                 Id = guid,
                 Name = "Assassin's Creed",
                 GameDetails = "Assassin's Creed is an action-adventure video game developed by Ubisoft Montreal and published by Ubisoft. It is the first installment in the Assassin's Creed series. The game was released for PlayStation 3 and Xbox 360 in November 2007.",
                 ReleaseDate = new DateTime(2011, 2, 16),
                 ImageSrc = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRcHNm4Py0J8lgox2kPl87ZTV4aRjRcIZcq5hyBZX8q&s",
             });

            //Act
            var controller = new GamesController(_mockMapper.Object, _mockMediator.Object, _mockLogger.Object);
            var result = await controller.UpdateGame(guid, updateGameCommand);
            var okResult = result as OkObjectResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task Update_Game_Should_Return_UpdatedGame()
        {
            //Arrange
            var guid = new Guid("3fefe639-af6a-46f7-b7ca-db1608ec3f65");

            var updateGameCommand = new GameViewModel
            {
                Name = "Assassin's Creed",
                GameDetails = "Assassin's Creed is an action-adventure video game developed by Ubisoft Montreal and published by Ubisoft. It is the first installment in the Assassin's Creed series. The game was released for PlayStation 3 and Xbox 360 in November 2007.",
                ReleaseDate = new DateTime(2011, 2, 16),
                ImageSrc = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRcHNm4Py0J8lgox2kPl87ZTV4aRjRcIZcq5hyBZX8q&s",
            };

            _mockMediator
             .Setup(m => m.Send(It.IsAny<UpdateGameCommand>(), It.IsAny<CancellationToken>()))
             .ReturnsAsync(new Game
             {
                 Id = guid,
                 Name = "Assassin's Creed",
                 GameDetails = "Assassin's Creed is an action-adventure video game developed by Ubisoft Montreal and published by Ubisoft. It is the first installment in the Assassin's Creed series. The game was released for PlayStation 3 and Xbox 360 in November 2007.",
                 ReleaseDate = new DateTime(2011, 2, 16),
                 ImageSrc = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRcHNm4Py0J8lgox2kPl87ZTV4aRjRcIZcq5hyBZX8q&s",
             });

            _mockMapper.Setup(m => m.Map<GameDto>(It.IsAny<Game>()))
              .Returns(new GameDto
              {
                  Name = "Assassin's Creed",
                  GameDetails = "Assassin's Creed is an action-adventure video game developed by Ubisoft Montreal and published by Ubisoft. It is the first installment in the Assassin's Creed series. The game was released for PlayStation 3 and Xbox 360 in November 2007.",
                  ReleaseDate = new DateTime(2011, 2, 16),
                  ImageSrc = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRcHNm4Py0J8lgox2kPl87ZTV4aRjRcIZcq5hyBZX8q&s",
              });

            //Act
            var controller = new GamesController(_mockMapper.Object, _mockMediator.Object, _mockLogger.Object);
            var result = await controller.UpdateGame(guid, updateGameCommand);
            var okResult = result as OkObjectResult;

            //Assert
            Assert.Equal(updateGameCommand.Name, ((GameDto)okResult.Value).Name);
            Assert.Equal(updateGameCommand.GameDetails, ((GameDto)okResult.Value).GameDetails);
            Assert.Equal(updateGameCommand.ReleaseDate, ((GameDto)okResult.Value).ReleaseDate);
            Assert.Equal(updateGameCommand.ImageSrc, ((GameDto)okResult.Value).ImageSrc);
        }
    }
}