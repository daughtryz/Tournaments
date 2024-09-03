using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tournament.Api.Data;
using Tournament.Api.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tournament.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("[controller]")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private readonly TournamentsDbContext _tournamentsDbContext;

        public TournamentsController(TournamentsDbContext tournamentsDbContext)
        {
            _tournamentsDbContext = tournamentsDbContext;
        }

        // GET: api/<TournamentsController>
        [HttpGet]
        public async Task<IActionResult> GetTournaments()
        {
            var tournaments = await _tournamentsDbContext
                .Tournaments
                .OrderByDescending(x => x.CreatedOn)
                .AsNoTracking()
                .ToListAsync();

            return Ok(tournaments);
        }

        // GET api/<TournamentsController>/5
        [HttpGet("{id}", Name = "GetTournamentById")]
        public async Task<IActionResult> GetTournamentById([FromRoute] Guid id)
        {
            var tournament = await _tournamentsDbContext.Tournaments.FindAsync(id);

            return Ok(tournament);
        }

        // POST api/<TournamentsController>
        [HttpPost]
        public async Task<IActionResult> CreateTournament([FromBody] TournamentsRequest request)
        {
            var createdTournament = new Data.Models.Tournament
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                StartDate = DateTime.Parse(request.StartDate),
                EndDate = DateTime.Parse(request.EndDate),
                TeamsInvolved = request.TeamsInvolved,
                Organizer = request.Organizer,
                CreatedOn = DateTime.Now
            };

            await _tournamentsDbContext.AddAsync(createdTournament);
            await _tournamentsDbContext.SaveChangesAsync();

            return CreatedAtRoute("GetTournamentById", new { id = createdTournament.Id }, createdTournament);
        }

        // PUT api/<TournamentsController>/5
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditTournament(Guid id, [FromBody] TournamentsRequest request)
        {
            var tournament = await _tournamentsDbContext.Tournaments.FindAsync(id);

            if(tournament == null)
            {
                return NotFound();
            }

            tournament.Name = request.Name;
            tournament.Description = request.Description;
            tournament.StartDate = DateTime.Parse(request.StartDate);
            tournament.EndDate = DateTime.Parse(request.EndDate);
            tournament.TeamsInvolved = request.TeamsInvolved;
            tournament.Organizer = request.Organizer;

            await _tournamentsDbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<TournamentsController>/5
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var tournament = await _tournamentsDbContext.Tournaments.FindAsync(id);

            if (tournament == null)
            {
                return NotFound();
            }

            _tournamentsDbContext.Tournaments.Remove(tournament);
            await _tournamentsDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
