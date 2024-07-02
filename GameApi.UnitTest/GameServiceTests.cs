using GameApi.Business.Services;
using GameApi.Data.Models;
using GameApi.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace GameApi.Tests.Services
{
    [TestFixture]
    public class GameServiceTests
    {
        private Mock<IGameRepository> _mockRepo;
        private GameService _service;

        [SetUp]
        public void SetUp()
        {
            _mockRepo = new Mock<IGameRepository>();
            _service = new GameService(_mockRepo.Object);
        }

        #region Positive Scenarios

        [Test]
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
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task GetGameById_ReturnsGame()
        {
            // Arrange
            var game = new Game { ID = 1, Title = "Game1" };
            _mockRepo.Setup(repo => repo.GetGameById(1)).ReturnsAsync(game);

            // Act
            var result = await _service.GetGameById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }

        [Test]
        public async Task AddGame_AddsGame()
        {
            // Arrange
            var game = new Game { ID = 1, Title = "Game1" };
            _mockRepo.Setup(repo => repo.AddGame(game)).ReturnsAsync(game);

            // Act
            var result = await _service.AddGame(game);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }

        [Test]
        public async Task UpdateGame_UpdatesGame()
        {
            // Arrange
            var game = new Game { ID = 1, Title = "Game1" };
            _mockRepo.Setup(repo => repo.UpdateGame(game)).ReturnsAsync(game);

            // Act
            var result = await _service.UpdateGame(game);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }

        [Test]
        public async Task DeleteGame_DeletesGame()
        {
            // Arrange
            var game = new Game { ID = 1, Title = "Game1" };
            _mockRepo.Setup(repo => repo.GetGameById(1)).ReturnsAsync(game);
            _mockRepo.Setup(repo => repo.DeleteGame(1)).Returns(Task.CompletedTask);

            // Act
            await _service.DeleteGame(1);

            // Assert
            _mockRepo.Verify(repo => repo.DeleteGame(1), Times.Once);
        }

        #endregion

        #region Negative Scenarios

        [Test]
        public void GetGameById_GameNotFound_ThrowsException()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetGameById(It.IsAny<int>())).ReturnsAsync((Game)null);

            // Act & Assert
            var ex = Assert.ThrowsAsync<InvalidOperationException>(() => _service.GetGameById(99));
            Assert.That(ex.Message, Is.EqualTo("Game not found"));
        }

        [Test]
        public void UpdateGame_GameNotFound_ThrowsException()
        {
            // Arrange
            var game = new Game { ID = 1, Title = "Game1" };
            _mockRepo.Setup(repo => repo.UpdateGame(game)).ReturnsAsync((Game)null);

            // Act & Assert
            var ex = Assert.ThrowsAsync<InvalidOperationException>(() => _service.UpdateGame(game));
            Assert.That(ex.Message, Is.EqualTo("Game not found"));
        }

        [Test]
        public void DeleteGame_GameNotFound_ThrowsException()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetGameById(It.IsAny<int>())).ReturnsAsync((Game)null);

            // Act & Assert
            var ex = Assert.ThrowsAsync<InvalidOperationException>(() => _service.DeleteGame(99));
            Assert.That(ex.Message, Is.EqualTo("Game not found"));
        }

        #endregion

        #region Boundary Conditions

        [Test]
        public async Task GetAllGames_ZeroGames_ReturnsEmptyList()
        {
            // Arrange
            var games = new List<Game>();
            _mockRepo.Setup(repo => repo.GetAllGames(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(games);

            // Act
            var result = await _service.GetAllGames(1, 10);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }

        [Test]
        public async Task AddGame_NullGame_ThrowsArgumentNullException()
        {
            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _service.AddGame(null));
            Assert.That(ex.ParamName, Is.EqualTo("game"));
        }

        [Test]
        public void GetGameById_InvalidId_ThrowsArgumentException()
        {
            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(() => _service.GetGameById(-1));
            Assert.That(ex.ParamName, Is.EqualTo("id"));
        }
        #endregion Negative Scenarios

        #region Bulk Insertion 

        [Test]
        public async Task AddGames_ValidGames_ReturnsAddedGames()
        {
            // Arrange
            var games = new List<Game>
            {
                new Game { ID = 1, Title = "Game 1", Genre = "Cricket", Description = "Description 1", Price = 59.99m, ReleaseDate = new DateTime(2021, 1, 1), StockQuantity = 100 },
                new Game { ID = 2, Title = "Game 2", Genre = "Hockey", Description = "Description 2", Price = 49.99m, ReleaseDate = new DateTime(2022, 1, 1), StockQuantity = 200 }
            };

            _mockRepo.Setup(repo => repo.AddGames(It.IsAny<IEnumerable<Game>>())).ReturnsAsync(games);

            // Act
            var result = await _service.AddGames(games);

            // Assert
            Assert.IsNotNull(result);
            
        }


        [Test]
        public void AddGames_NullGames_ThrowsArgumentNullException()
        {
            // Arrange
            IEnumerable<Game> games = null;

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _service.AddGames(games));
            Assert.AreEqual("Value cannot be null.", ex.Message);
        }


        #endregion
    }
}

