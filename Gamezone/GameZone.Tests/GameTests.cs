using GameZone.Application;
using GameZone.Infrastructure;
using GameZone.Infrastructure.Repositories;
using GameZoneModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace GameZone.Tests
{
    public class GameTests
    {
        [Fact]
        public async Task AddGames()
        {
            IGameRepository sut = GetInMemoryGameRepository();
            var guid = new Guid("e9c21e27-a987-4c6d-8d7d-1807ee9243ab");
            Game game = new Game()
            {
                Id = new Guid("e9c21e27-a987-4c6d-8d7d-1807ee9243ab"),
                Name = "Ac",
                GameDetails= "game",
                ReleaseDate= DateTime.UtcNow,
            };

            await sut.CreateAsync(game);
            var savedGame = await sut.ReturnByIdAsync(guid);
            var list = await sut.ReturnAllAsync();
            Assert.Single(list);
            Assert.Equal("Ac", savedGame.Name);
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