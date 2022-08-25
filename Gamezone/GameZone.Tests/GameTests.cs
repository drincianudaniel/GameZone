using GameZone.Application;
using GameZone.Infrastructure;
using GameZone.Infrastructure.Repositories;
using GameZone.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;
using GameZone.Application.Interfaces;

namespace GameZone.Tests
{
    public class GameTests
    {
        private Game game = new Game()
        {
            Id = new Guid("e9c21e27-a987-4c6d-8d7d-1807ee9243ab"),
            Name = "Ac",
            GameDetails= "game",
            ReleaseDate= DateTime.UtcNow,
        };
        private Guid guid = new Guid("e9c21e27-a987-4c6d-8d7d-1807ee9243ab");

        [Fact]
        public async Task AddGamesTest()
        {
            // arrange: one game exists
            IGameRepository sut = GetInMemoryGameRepository();

            // action: add game
            await sut.CreateAsync(game);
            await sut.SaveAsync();
            var savedGame = await sut.ReturnByIdAsync(guid);
            var list = await sut.ReturnAllAsync();

            // assert: check game is inserted 
            Assert.Single(list);
            Assert.Equal("Ac", savedGame.Name);
            Assert.Equal("game", savedGame.GameDetails);
        }

        [Fact]
        public async Task DeleteGamesTest()
        {
            // arange: one game exists
            IGameRepository sut = GetInMemoryGameRepository();
            await sut.CreateAsync(game);
            await sut.SaveAsync();

            var savedGame = await sut.ReturnByIdAsync(guid);
            var list = await sut.ReturnAllAsync();
            Assert.Single(list);

            // action: delete
            await sut.DeleteAsync(savedGame);
            await sut.SaveAsync();

            list = await sut.ReturnAllAsync();

            // assert empty
            Assert.Empty(list);
        }

        [Fact]
        public async Task GetGameByIdTest()
        {
            // expectedId = x;
            // arrange: one game exists
            IGameRepository sut = GetInMemoryGameRepository();
            await sut.CreateAsync(game);
            await sut.SaveAsync();


            // action: get by id
            var savedGame = await sut.ReturnByIdAsync(guid);

            // assert: check type
            Assert.IsType<Game>(savedGame);
        }

        [Fact]
        public async Task UpdateGame()
        {
            // arrange: one game exists
            IGameRepository sut = GetInMemoryGameRepository();
            await sut.CreateAsync(game);
            await sut.SaveAsync();

            var list = await sut.ReturnAllAsync();
            Assert.Single(list);

            //action: update game
            game.Name = "Updated name";
            await sut.UpdateAsync(game);
            await sut.SaveAsync();

            var savedGame = await sut.ReturnByIdAsync(guid);

            //assert: check if updated
            Assert.Equal("Updated name", savedGame.Name);
        }

        private IGameRepository GetInMemoryGameRepository()
        {
            DbContextOptions<GameZoneContext> options;
            var builder = new DbContextOptionsBuilder<GameZoneContext>();
            builder.UseInMemoryDatabase("GameZone");
            options = builder.Options;
            GameZoneContext gameZoneContext = new GameZoneContext(options);
            gameZoneContext.Database.EnsureDeleted();
            gameZoneContext.Database.EnsureCreated();
            return new GameRepository(gameZoneContext);
        }
    }
}