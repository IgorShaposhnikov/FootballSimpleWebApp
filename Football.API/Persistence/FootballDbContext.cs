using Football.Domain;
using Microsoft.EntityFrameworkCore;

namespace Football.API.Persistence
{
    public class FootballDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        public FootballDbContext(DbContextOptions<FootballDbContext> options) : base(options)
        {

        }
    }
}
