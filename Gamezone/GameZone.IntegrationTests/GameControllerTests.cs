using GameZone.Api.DTOs;
using GameZone.Api.ViewModels;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameZone.IntegrationTests
{
    public class GameControllerTests : IDisposable
    {
        private static WebApplicationFactory<Program> _factory;

        public void Dispose()
        {
            _factory.Dispose();
        }

        public GameControllerTests()
        {
            _factory = new CustomWebApplicationFactory<Program>();
        }

        [Fact]
        public async Task Get_All_Games_ShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/games");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Get_All_Games_ShouldReturnExistingGame()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/games");

            var result = await response.Content.ReadAsStringAsync();
            var games = JsonConvert.DeserializeObject<List<GameDto>>(result);

            var game = games.FirstOrDefault(x => x.Id == Guid.Parse("2df905bf-8205-4466-942d-713a689431c1"));
            GameAsserts(game);
        }

        [Fact]
        public async Task Get_Searched_Games_ShouldReturnSearchedGames()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/games/search/Minecraft");

            var result = await response.Content.ReadAsStringAsync();
            var games = JsonConvert.DeserializeObject<List<GameDto>>(result);

            var game = games.First();
            Assert.Equal("Minecraft", game.Name);
        }

        [Fact]
        public async Task Get_Game_By_Id_ShouldReturnExistingGame()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/games/2df905bf-8205-4466-942d-713a689431c1");

            var result = await response.Content.ReadAsStringAsync();
            var game = JsonConvert.DeserializeObject<GameDto>(result);

            GameAsserts(game);
        }

        [Fact]
        public async Task Post_Game_ShouldReturnCreatedResponse()
        {
            var game = new GameViewModel
            {
                Name = "Red Dead Redemption 2",
                ReleaseDate = new DateTime(2018, 10, 25),
                GameDetails = "Red Dead Redemption 2 is a 2018 action-adventure game developed and published by Rockstar Games. The game is the third entry in the Red Dead series and a prequel to the 2010 game Red Dead",
                ImageSrc = "https://lh3.googleusercontent.com/HCUkD69MAHEOj84Yi7Kb5vxHpCePTsmQI4g9vYuVPUo-87cWE6ZZIk0tiyYzaiS9zaAFMTXRNYJaaRczRN-yQYw",
                GenreList = new List<Guid> { new Guid("611da6e3-9b9e-43c4-a539-3758cf69f330") },
                DeveloperList = new List<Guid> { new Guid("f019d75b-9945-44a9-80d5-0da4a8b3e75e") },
                PlatformList = new List<Guid> { new Guid("c0dc1fdf-9615-4cf6-834a-3c36a28b4798"), new Guid("964a6257-1a9e-4f9b-bb54-9c4ca4582c65") },

            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/games",
                new StringContent(JsonConvert.SerializeObject(game), Encoding.UTF8, "application/json"));

            Assert.True(response.StatusCode == HttpStatusCode.Created);
        }

        [Fact]
        public async Task Post_Game_ShouldReturnCreatedGame()
        {
            var newGame = new GameViewModel
            {
                Name = "Red Dead Redemption 2",
                ReleaseDate = new DateTime(2018, 10, 25),
                GameDetails = "Red Dead Redemption 2 is a 2018 action-adventure game developed and published by Rockstar Games. The game is the third entry in the Red Dead series and a prequel to the 2010 game Red Dead",
                ImageSrc = "https://lh3.googleusercontent.com/HCUkD69MAHEOj84Yi7Kb5vxHpCePTsmQI4g9vYuVPUo-87cWE6ZZIk0tiyYzaiS9zaAFMTXRNYJaaRczRN-yQYw",
                GenreList = new List<Guid> { new Guid("611da6e3-9b9e-43c4-a539-3758cf69f330") },
                DeveloperList = new List<Guid> { new Guid("f019d75b-9945-44a9-80d5-0da4a8b3e75e") },
                PlatformList = new List<Guid> { new Guid("c0dc1fdf-9615-4cf6-834a-3c36a28b4798"), new Guid("964a6257-1a9e-4f9b-bb54-9c4ca4582c65") },

            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/games",
                new StringContent(JsonConvert.SerializeObject(newGame), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var game = JsonConvert.DeserializeObject<GameDto>(result);

            Assert.Equal(newGame.Name, game.Name);
            Assert.Equal(newGame.ReleaseDate, game.ReleaseDate);
            Assert.Equal(newGame.GameDetails, game.GameDetails);
            Assert.Equal(newGame.ImageSrc, game.ImageSrc);
            Assert.Equal("Action", game.Genres.ElementAt(0).Name);
            Assert.Equal(1, game.Genres.Count);
            Assert.Equal("Rockstar Games", game.Developers.ElementAt(0).Name);
            Assert.Equal(1, game.Developers.Count);
            Assert.Equal("PlayStation 4", game.Platforms.ElementAt(0).Name);
            Assert.Equal("PC", game.Platforms.ElementAt(1).Name);
            Assert.Equal(2, game.Platforms.Count);
        }

        [Fact]
        public async Task Put_Game_ShouldReturnUpdatedGame()
        {
            var newGame = new GameViewModel
            {
                Name = "Edited Name",
                ReleaseDate = new DateTime(2018, 10, 25),
                GameDetails = "edit desc edit desc edit desc edit desc edit desc edit desc edit desc edit desc",
                ImageSrc = "https://lh3.googleusercontent.com/HCUkD69MAHEOj84Yi7Kb5vxHpCePTsmQI4g9vYuVPUo-87cWE6ZZIk0tiyYzaiS9zaAFMTXRNYJaaRczRN-yQYw",

            };

            var client = _factory.CreateClient();
            var response = await client.PutAsync("api/games/2df905bf-8205-4466-942d-713a689431c1",
                new StringContent(JsonConvert.SerializeObject(newGame), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var game = JsonConvert.DeserializeObject<GameDto>(result);

            Assert.Equal(new Guid("2df905bf-8205-4466-942d-713a689431c1"), game.Id);
            Assert.Equal(newGame.Name, game.Name);
            Assert.Equal(newGame.ReleaseDate, game.ReleaseDate);
            Assert.Equal(newGame.GameDetails, game.GameDetails);
            Assert.Equal(newGame.ImageSrc, game.ImageSrc);
        }

        [Fact]
        public async Task Delete_Game_ShouldReturnNoContentResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.DeleteAsync($"api/games/2df905bf-8205-4466-942d-713a689431c1");

            Assert.True(response.StatusCode == HttpStatusCode.NoContent);
        }

        private static void GameAsserts(GameDto game)
        {
            Assert.Equal("Minecraft", game.Name);
            Assert.Equal(new DateTime(2011, 11, 18), game.ReleaseDate);
            Assert.Equal("Minecraft is a sandbox video game developed by Mojang Studios. The game was created by Markus Notch Persson in the Java programming language.", game.GameDetails);
            Assert.Equal("https://upload.wikimedia.org/wikipedia/en/5/51/Minecraft_cover.png", game.ImageSrc);
            Assert.Equal("Adventure", game.Genres.ElementAt(0).Name);
            Assert.Equal(1, game.Genres.Count);
            Assert.Equal("Mojang", game.Developers.ElementAt(0).Name);
            Assert.Equal(1, game.Developers.Count);
            Assert.Equal("PC", game.Platforms.ElementAt(0).Name);
            Assert.Equal("Xbox One", game.Platforms.ElementAt(1).Name);
            Assert.Equal(2, game.Platforms.Count);
        }
    }
}
