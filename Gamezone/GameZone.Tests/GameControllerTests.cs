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
        private readonly IGameRepository _gameRepository;

        public GameControllerTests(IGameRepository gameRepository)
        {
            _gameRepository=gameRepository;
        }

        [Fact]
        public async Task Index_ReturnAViewResult_WithAListOfGames()
        {
            //Arrage
            var mockRepo = new Mock<IGameRepository>();
            mockRepo.Setup(repo => repo.ReturnAllAsync()).ReturnsAsync(DbHelperGames.GetTestGames());

            var controller = new GamesController(mockRepo.Object);
        }
    }
}
*/