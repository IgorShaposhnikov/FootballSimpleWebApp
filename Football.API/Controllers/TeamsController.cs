using Football.Domain;
using Football.Persistence.Data;
using Microsoft.AspNetCore.Mvc;

namespace Football.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly FootballDbContext _dbContext;


        #region Constructors


        public TeamsController(FootballDbContext dataContext)
        {
            _dbContext = dataContext;
        }


        #endregion Constructors


        #region Public Methods


        [HttpGet]
        public async Task<ActionResult<List<Team>>> GetTeamsList()
        {
            return Ok(_dbContext.Teams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(Guid id)
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


        #endregion Public Methods
    }
}
