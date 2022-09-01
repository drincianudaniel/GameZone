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
    public class GenreControllerTests : IDisposable
    {
        private static WebApplicationFactory<Program> _factory;

        public void Dispose()
        {
            _factory.Dispose();
        }

        public GenreControllerTests()
        {
            _factory = new CustomWebApplicationFactory<Program>();
        }

        [Fact]
        public async Task Get_All_Genres_ShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/genres");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Get_All_Genres_ShouldReturnExistingGenre()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/genres");

            var result = await response.Content.ReadAsStringAsync();
            var genres = JsonConvert.DeserializeObject<List<GenreDto>>(result);

            var genre = genres.FirstOrDefault(x => x.Id == Guid.Parse("611da6e3-9b9e-43c4-a539-3758cf69f330"));
            GenreAsserts(genre);
        }

        [Fact]
        public async Task Get_Genre_By_Id_ShouldReturnExistingGenre()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/genres/611da6e3-9b9e-43c4-a539-3758cf69f330");

            var result = await response.Content.ReadAsStringAsync();
            var genre = JsonConvert.DeserializeObject<GenreDto>(result);

            GenreAsserts(genre);
        }

        [Fact]
        public async Task Post_Genre_ShouldReturnCreatedResponse()
        {
            var genre = new GenreViewModel
            {
               Name = "MOBA"
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/genres",
                new StringContent(JsonConvert.SerializeObject(genre), Encoding.UTF8, "application/json"));

            Assert.True(response.StatusCode == HttpStatusCode.Created);
        }

        [Fact]
        public async Task Post_Genre_ShouldReturnCreatedGenre()
        {
            var newGenre = new GenreViewModel
            {
                Name = "MOBA"
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/genres",
                new StringContent(JsonConvert.SerializeObject(newGenre), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var genre = JsonConvert.DeserializeObject<GenreDto>(result);

            Assert.Equal(newGenre.Name, genre.Name);
        }

        [Fact]
        public async Task Put_Genre_ShouldReturnUpdatedGenre()
        {
            var newGenre = new GenreViewModel
            {
                Name = "Updated Name"
            };

            var client = _factory.CreateClient();
            var response = await client.PutAsync("api/genres/611da6e3-9b9e-43c4-a539-3758cf69f330",
                new StringContent(JsonConvert.SerializeObject(newGenre), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var genre = JsonConvert.DeserializeObject<GenreDto>(result);

            Assert.Equal(new Guid("611da6e3-9b9e-43c4-a539-3758cf69f330"), genre.Id);
            Assert.Equal(newGenre.Name, genre.Name);
        }

        public async Task Delete_Genre_ShouldReturnNoContentResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.DeleteAsync($"api/genres/611da6e3-9b9e-43c4-a539-3758cf69f330");

            Assert.True(response.StatusCode == HttpStatusCode.NoContent);
        }

        private static void GenreAsserts(GenreDto genre)
        {
            Assert.Equal("Action", genre.Name);
        }
    }
}
