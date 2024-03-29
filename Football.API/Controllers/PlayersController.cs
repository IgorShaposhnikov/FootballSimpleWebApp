﻿using Football.Domain;
using Football.Persistence.Data;
using Microsoft.AspNetCore.Mvc;

namespace Football.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly FootballDbContext _dbContext;


        #region Contructors


        public PlayersController(FootballDbContext dataContext)
        {
            _dbContext = dataContext;
        }


        #endregion Constructors


        #region Public Methods


        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            return Ok(_dbContext.Players);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(Guid id)
        {
            var player = _dbContext.Players.Where(p => p.Id == id).First();

            if (player is null)
                return NotFound($"Player with id {id} not found.");

            return Ok(player);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> AddPlayer(Player player)
        {
            player.Id = Guid.NewGuid();

            _dbContext.Players.Add(player);

            await _dbContext.SaveChangesAsync();

            return Ok(player.Id);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdatePlayer(Player player)
        {
            var updatablePlayer = await _dbContext.Players.FindAsync(player.Id);

            if (updatablePlayer is null)
                return BadRequest("Cannot update this player. Player not found.");

            updatablePlayer.FirstName = player.FirstName;
            updatablePlayer.LastName = player.LastName;
            updatablePlayer.Birthday = player.Birthday;
            updatablePlayer.Gender = player.Gender;
            updatablePlayer.TeamId = player.TeamId;
            updatablePlayer.Country = player.Country;

            await _dbContext.SaveChangesAsync();

            return Ok(true);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> RemovePlayer(Guid id)
        {
            var player = await _dbContext.Players.FindAsync(id);

            if (player is null)
                return BadRequest("Cannot remove this player. Player not found.");

            _dbContext.Players.Remove(player);
            await _dbContext.SaveChangesAsync();

            return Ok(true);
        }


        #endregion Public Methods
    }
}
