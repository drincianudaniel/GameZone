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
    public class PlatformControllerTests : IDisposable
    {
        private static WebApplicationFactory<Program> _factory;

        public void Dispose()
        {
            _factory.Dispose();
        }

        public PlatformControllerTests()
        {
            _factory = new CustomWebApplicationFactory<Program>();
        }

        [Fact]
        public async Task Get_All_Platforms_ShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/platforms");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Get_All_Platforms_ShouldReturnExistingPlatform()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/platforms");

            var result = await response.Content.ReadAsStringAsync();
            var platforms = JsonConvert.DeserializeObject<List<PlatformDto>>(result);

            var platform = platforms.FirstOrDefault(x => x.Id == Guid.Parse("c0dc1fdf-9615-4cf6-834a-3c36a28b4798"));
            PlatformAsserts(platform);
        }

        [Fact]
        public async Task Get_Platform_By_Id_ShouldReturnExistingPlatform()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/platforms/c0dc1fdf-9615-4cf6-834a-3c36a28b4798");

            var result = await response.Content.ReadAsStringAsync();
            var platform = JsonConvert.DeserializeObject<PlatformDto>(result);

            PlatformAsserts(platform);
        }

        [Fact]
        public async Task Post_Platform_ShouldReturnCreatedResponse()
        {
            var platform = new PlatformViewModel
            {
                Name = "Nintendto Switch"
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/platforms",
                new StringContent(JsonConvert.SerializeObject(platform), Encoding.UTF8, "application/json"));

            Assert.True(response.StatusCode == HttpStatusCode.Created);
        }

        [Fact]
        public async Task Post_Platform_ShouldReturnCreatedPlatform()
        {
            var newPlatform = new PlatformViewModel
            {
                Name = "Nintendto Switch"
            };

            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/platforms",
                new StringContent(JsonConvert.SerializeObject(newPlatform), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var platform = JsonConvert.DeserializeObject<PlatformDto>(result);

            Assert.Equal(newPlatform.Name, platform.Name);
        }

        [Fact]
        public async Task Put_Platform_ShouldReturnUpdatedPlatform()
        {
            var newPlatform = new PlatformViewModel
            {
                Name = "Updated Platform"
            };

            var client = _factory.CreateClient();
            var response = await client.PutAsync("api/platforms/c0dc1fdf-9615-4cf6-834a-3c36a28b4798",
                new StringContent(JsonConvert.SerializeObject(newPlatform), Encoding.UTF8, "application/json"));

            var result = await response.Content.ReadAsStringAsync();
            var platform = JsonConvert.DeserializeObject<PlatformDto>(result);

            Assert.Equal(new Guid("c0dc1fdf-9615-4cf6-834a-3c36a28b4798"), platform.Id);
            Assert.Equal(newPlatform.Name, platform.Name);
        }

        [Fact]
        public async Task Delete_Platform_ShouldReturnNoContentResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.DeleteAsync($"api/platforms/c0dc1fdf-9615-4cf6-834a-3c36a28b4798");

            Assert.True(response.StatusCode == HttpStatusCode.NoContent);
        }

        private static void PlatformAsserts(PlatformDto platform)
        {
            Assert.Equal("PlayStation 4", platform.Name);
        }
    }
}
