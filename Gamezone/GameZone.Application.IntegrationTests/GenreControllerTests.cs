using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace GameZone.Application.IntegrationTests
{
    public class GenreControllerTests
    {
        //private static TestContext _testContext;
        private static WebApplicationFactory<Program> _factory;

        public GenreControllerTests(/*TestContext testContext*/)
        {
/*            _testContext = testContext;*/
            _factory = new CustomWebApplicationFactory<Program>();
        }

        [Fact]
        public async Task Get_All_Genres_ShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/genres");

            Xunit.Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
