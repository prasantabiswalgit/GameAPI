using GameApi.Business.Services;
using GameApi.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames(int page = 1, int pageSize = 10)
        {
            try
            {
                var games = await _gameService.GetAllGames(page, pageSize);
                return Ok(games);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            try
            {
                var game = await _gameService.GetGameById(id);
                if (game == null)
                {
                    return NotFound();
                }
                return Ok(game);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("add")]
        public async Task<ActionResult<Game>> AddGame(Game game)
        {
            try
            {
                var createdGame = await _gameService.AddGame(game);
                return CreatedAtAction(nameof(GetGame), new { id = createdGame.ID }, createdGame);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Game object is null");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, Game game)
        {
            try
            {
                if (id != game.ID)
                {
                    return BadRequest("ID mismatch");
                }

                await _gameService.UpdateGame(game);
                return NoContent();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            try
            {
                await _gameService.DeleteGame(id);
                return NoContent();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("bulk")]
        public async Task<ActionResult<IEnumerable<Game>>> AddBulkGames(IEnumerable<Game> games)  // for bulk insertion
        {
            try
            {
                var createdGames = await _gameService.AddGames(games);
                return Ok(createdGames);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}