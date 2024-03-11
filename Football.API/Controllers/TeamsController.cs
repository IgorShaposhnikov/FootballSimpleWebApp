using Football.Domain;
using Football.Persistence.Data;
using Microsoft.AspNetCore.Mvc;

namespace Football.API.Controllers
{
    public class TeamsController : ControllerBase
    {
        private readonly FootballDbContext _dbContext;

        public TeamsController(FootballDbContext dataContext)
        {
            _dbContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Team>>> GetList()
        {
            return Ok(_dbContext.Teams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeamById(Guid id)
        {
            return Ok(_dbContext.Teams.Where(team => team.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> AddTeam(Team team)
        {
            team.Id = Guid.NewGuid();

            _dbContext.Teams.Add(team);

            await _dbContext.SaveChangesAsync();

            return Ok(team);
        }
    }
}
