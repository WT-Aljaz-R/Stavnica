using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Stavnica.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SportEventController : ControllerBase
{

    private readonly ILogger<SportEventController> _logger;

    private readonly AppDbContext _context;

    public SportEventController(ILogger<SportEventController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SportEvent>> GetSportEvent(int id)
    {
        var sportEvent = await _context.SportEvents.FindAsync(id);

        if (sportEvent == null)
        {
            return NotFound();
        }

        return sportEvent;
    }

    [HttpGet]
    public async Task<ActionResult<List<SportEvent>>> GetSportEvents()
    {
        var sportEvents = await _context.SportEvents.ToListAsync();

        if (sportEvents == null || sportEvents.Count == 0)
        {
            return NotFound();
        }

        return sportEvents;
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostSportEvent(SportEvent sportEvent)
    {
        _context.SportEvents.Add(sportEvent);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSportEvent), new { id = sportEvent.Id }, sportEvent);
    }
}