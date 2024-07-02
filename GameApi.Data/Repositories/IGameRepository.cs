using GameApi.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameApi.Data.Repositories
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAllGames(int page, int pageSize);
        Task<Game> GetGameById(int id);
        Task<Game> AddGame(Game game);
        Task<Game> UpdateGame(Game game);
        Task DeleteGame(int id);
        Task<IEnumerable<Game>> AddGames(IEnumerable<Game> games);   // for bulk insertion
    
   }

}
