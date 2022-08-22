using AutoFixture;
using AutoMapper;
using GameZone.Application.Games.Queries.GetGameById;
using GameZone.Infrastructure;
using GameZone.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GameZone.Application.IntegrationTests.Games.QueryHandlers
{
    public class GetGameByIdQueryHandlerTests
    {
        private readonly IFixture _fixture;
        private readonly Guid _gameId;

        // TODO: maybe factory
        public GetGameByIdQueryHandlerTests()
        {
            _gameId = Guid.NewGuid();
            _fixture = new Fixture();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(new[] { typeof(IAssemblyMarker) });
            });

            var mapper = new Mapper(config);
            _fixture.Inject<IMapper>(mapper);

            var options = new DbContextOptionsBuilder<GameZoneContext>()
              .UseInMemoryDatabase(databaseName: nameof(GetGameByIdQueryHandlerTests))
              .Options;

            var game = new GameZone.Domain.Models.Game { Id = _gameId, Name = "game 1" };
            var context = new GameZoneContext(options);
            context.Games.Add(game);
            context.SaveChanges();

            var mockGameRepo = new GameRepository(context);
            _fixture.Inject<IGameRepository>(mockGameRepo);
        }


        [Fact]
        public async Task GetGameById_WhenValidId_ReturnsGame()
        {
            // arrange
            var query = new GetGameByIdQuery { Id = _gameId };

            // act
            var handler = _fixture.Create<GetGameByIdQueryHandler>();
            var actualGame = await handler.Handle(query, cancellationToken: default);

            // assert
            Assert.NotNull(actualGame);
            Assert.Equal(_gameId, actualGame.Id);
        }

        [Fact]
        public async Task GetGameById_WhenInvalidId_ReturnsNull()
        {
            // arrange
            var query = new GetGameByIdQuery { Id = Guid.Empty };

            // act
            var handler = _fixture.Create<GetGameByIdQueryHandler>();
            var actualGame = await handler.Handle(query, cancellationToken: default);

            // assert
            // TODO: maybe should be null instead of exception
            Assert.Null(actualGame);
        }
    }
}