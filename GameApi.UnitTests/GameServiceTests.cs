using GameApi.Business.Services;
using GameApi.Data.Models;
using GameApi.Data.Repositories;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GameApi.Tests.Services
{
    public class GameServiceTests
    {
        private readonly Mock<IGameRepository> _mockRepo;
        private readonly GameService _service;

        public GameServiceTests()
        {
            _mockRepo = new Mock<IGameRepository>();
            _service = new GameService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllGames_ReturnsAllGames()
        {
            // Arrange
            var games = new List<Game>
            {
                new Game { ID = 1, Title = "Game1" },
                new Game { ID = 2, Title = "Game2" }
            };

            _mockRepo.Setup(repo => repo.GetAllGames(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(games);

            // Act
            var result = await _service.GetAllGames(1, 10);

            // Assert
            Assert.Equal(2, result.Count());
        }

        // Additional tests for GetGameById, AddGame, UpdateGame, and DeleteGame can be added similarly
    }
}