using GameZone.Application;
using GameZone.Infrastructure;
using GameZone.Infrastructure.Repositories;
using GameZoneModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GameZone.Tests
{
    public class GameTests
    {
        Game game = new Game()
        {
            Id = new Guid("e9c21e27-a987-4c6d-8d7d-1807ee9243ab"),
            Name = "Ac",
            GameDetails= "game",
            ReleaseDate= DateTime.UtcNow,
        };

        [Fact]
        public async Task AddGamesTest()
        {
            IGameRepository sut = GetInMemoryGameRepository();
            var guid = new Guid("e9c21e27-a987-4c6d-8d7d-1807ee9243ab");
            await sut.CreateAsync(game);
            var savedGame = await sut.ReturnByIdAsync(guid);
            var list = await sut.ReturnAllAsync();
            Assert.Single(list);
            Assert.Equal("Ac", savedGame.Name);
            Assert.Equal("game", savedGame.GameDetails);
        }

        [Fact]
        public async Task DeleteGamesTest()
        {
            // arange: one game exists
            // action: delete
            // assert empty
            IGameRepository sut = GetInMemoryGameRepository();
            var guid = new Guid("e9c21e27-a987-4c6d-8d7d-1807ee9243ab");
            await sut.CreateAsync(game);
            var savedGame = await sut.ReturnByIdAsync(guid);
            await sut.DeleteAsync(savedGame);
            var list = await sut.ReturnAllAsync();

            Assert.Empty(list);
        }

        [Fact]
        public async Task GetGameByIdTest()
        {
            // expectedId = x;
            IGameRepository sut = GetInMemoryGameRepository();
            var guid = new Guid("e9c21e27-a987-4c6d-8d7d-1807ee9243ab");
            await sut.CreateAsync(game);
            var savedGame = await sut.ReturnByIdAsync(guid);

            Assert.IsType<Game>(savedGame);
        }

        private IGameRepository GetInMemoryGameRepository()
        {
            DbContextOptions<GameZoneContext> options;
            var builder = new DbContextOptionsBuilder<GameZoneContext>();
            builder.UseInMemoryDatabase("GameZoneTest");
            options = builder.Options;
            GameZoneContext gameZoneContext = new GameZoneContext(options);
            gameZoneContext.Database.EnsureDeleted();
            gameZoneContext.Database.EnsureCreated();
            return new GameRepository(gameZoneContext);
        }
    }
}