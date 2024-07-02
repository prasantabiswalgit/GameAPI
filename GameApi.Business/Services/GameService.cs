using GameApi.Data.Models;
using GameApi.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameApi.Business.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<IEnumerable<Game>> GetAllGames(int page, int pageSize)
        {
            return await _gameRepository.GetAllGames(page, pageSize);
        }

        public async Task<Game> GetGameById(int id)
        {
            return await _gameRepository.GetGameById(id);
        }

        public async Task<Game> AddGame(Game game)
        {
            return await _gameRepository.AddGame(game);
        }

        public async Task<Game> UpdateGame(Game game)
        {
            return await _gameRepository.UpdateGame(game);
        }

        public async Task DeleteGame(int id)
        {
            await _gameRepository.DeleteGame(id);
        }
        public async Task<IEnumerable<Game>> AddGames(IEnumerable<Game> games) // for bulk insertion
        {
            if (games == null || !games.Any())
            {
                throw new ArgumentNullException(nameof(games));
            }

            return await _gameRepository.AddGames(games);
        }
    }
}