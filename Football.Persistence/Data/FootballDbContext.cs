using Football.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Football.Persistence.Data
{
    public class FootballDbContext : DbContext
    {
        #region Properties


        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }


        #endregion Properties


        #region Constructors


        public FootballDbContext(DbContextOptions<FootballDbContext> options) : base(options)
        {

        }


        #endregion Constructors


        #region Public & Protected Methods


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


        #endregion Public & Protected Methods
    }
}
