using Microsoft.EntityFrameworkCore;
using GameApi.Data.Models;
using System.Collections.Generic;

namespace GameApi.Data
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }
    }
}
