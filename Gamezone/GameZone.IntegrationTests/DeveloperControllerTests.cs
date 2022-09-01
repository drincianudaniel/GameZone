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
    public class DeveloperControllerTests : IDisposable
    {
        private static WebApplicationFactory<Program> _factory;

        public void Dispose()
        {
            _factory.Dispose();
        }

        public DeveloperControllerTests()
        {
            _factory = new CustomWebApplicationFactory<Program>();
        }

        [Fact]
        public async Task Get_All_Developers_ShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/developers");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Get_All_Developers_ShouldReturnExistingDeveloper()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/developers");

            var result = await response.Content.ReadAsStringAsync();
            var developers = JsonConvert.DeserializeObject<List<DeveloperDto>>(result);

            var developer = developers.FirstOrDefault(x => x.Id == Guid.Parse("e830d6d6-ff42-4a25-a933-ef5fe62945ed"));
            DeveloperAsserts(developer);
        }

        [Fact]
        public async Task Get_Developer_By_Id_ShouldReturnExistingDeveloper()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/developers/e830d6d6-ff42-4a25-a933-ef5fe62945ed");

            var result = await response.Content.ReadAsStringAsync();
            var developer = JsonConvert.DeserializeObject<DeveloperDto>(result);

            DeveloperAsserts(developer);
        }

        [Fact]
        public async Task Post_Developer_ShouldReturnCreatedResponse()
        {
            var developer = new DeveloperViewModel
            {
                Name = "Rockstar Games",
                HeadQuarters = "New York"
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/developers",
                new StringContent(JsonConvert.SerializeObject(developer), Encoding.UTF8, "application/json"));

            Assert.True(response.StatusCode == HttpStatusCode.Created);
        }

        [Fact]
        public async Task Post_Developer_ShouldReturnCreatedDeveloper()
        {
            var newDeveloper = new DeveloperViewModel
            {
                Name = "Rockstar Games",
                HeadQuarters = "New York"
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/developers",
                new StringContent(JsonConvert.SerializeObject(newDeveloper), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var developer = JsonConvert.DeserializeObject<DeveloperDto>(result);

            Assert.Equal(newDeveloper.Name, developer.Name);
            Assert.Equal(newDeveloper.HeadQuarters, developer.Headquarters);
        }

        [Fact]
        public async Task Put_Developer_ShouldReturnUpdatedDeveloper()
        {
            var newDeveloper = new DeveloperViewModel
            {
                Name = "Updated name",
                HeadQuarters = "Updated Headquarters"
            };

            var client = _factory.CreateClient();
            var response = await client.PutAsync("api/developers/e830d6d6-ff42-4a25-a933-ef5fe62945ed",
                new StringContent(JsonConvert.SerializeObject(newDeveloper), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var developer = JsonConvert.DeserializeObject<DeveloperDto>(result);

            Assert.Equal(new Guid("e830d6d6-ff42-4a25-a933-ef5fe62945ed"), developer.Id);
            Assert.Equal(newDeveloper.Name, developer.Name);
            Assert.Equal(newDeveloper.HeadQuarters, developer.Headquarters);
        }

        public async Task Delete_Developer_ShouldReturnNoContentResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.DeleteAsync($"api/genres/e830d6d6-ff42-4a25-a933-ef5fe62945ed");

            Assert.True(response.StatusCode == HttpStatusCode.NoContent);
        }

        private static void DeveloperAsserts(DeveloperDto developer)
        {
            Assert.Equal("Ubisoft", developer.Name);
            Assert.Equal("Montreal", developer.Headquarters);
        }
    }
}
