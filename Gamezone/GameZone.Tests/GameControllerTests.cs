/*using GameZone.Api.Controllers;
using GameZone.Application;
using GameZone.Tests.Helpers;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace GameZone.Tests
{
    public class GameControllerTests
    {
        [Fact]
        public async Task Index_ReturnAViewResult_WithAListOfGames()
        {
            //Arrange
            var mockRepo = new Mock<IGameRepository>();
            mockRepo.Setup(repo => repo.ReturnAllAsync()).ReturnsAsync(DbHelperGames.GetTestGames());

            var controller = new GamesController();
        }
    }
}
*/