using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace GameZone.IntegrationTests
{
    public class GenreControllerTests
    {
        private static WebApplicationFactory<Program> _factory;

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
    }
}
