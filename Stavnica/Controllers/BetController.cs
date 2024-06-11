using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Stavnica.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BetController : ControllerBase
{

    private readonly ILogger<BetController> _logger;

    private readonly AppDbContext _context;

    public BetController(ILogger<BetController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("/user/{userId}")]
    public async Task<ActionResult<List<Bet>>> GetBetsByUser(int userId)
    {
        var bet = await _context.Bets.Where(b => b.UserId == userId).ToListAsync();

        if (bet == null)
        {
            return NotFound();
        }

        return bet;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Bet>> GetBets(int id)
    {
        var bet = await _context.Bets.FindAsync(id);

        if (bet == null)
        {
            return NotFound();
        }

        return bet;
    }


    [HttpPost]
    public async Task<ActionResult<Bet>> PostBet(string side, float payIn, int sportEventId, int userId)
    {
        SportEvent sportEvent = await _context.SportEvents.FindAsync(sportEventId);

        float sideValue = 1;
        if (sportEvent != null)
        {
            if (side.Equals("A"))
            {
                sideValue = sportEvent.SideA;
            }
            else if (side.Equals("B"))
            {
                sideValue = sportEvent.SideB;
            }
        }else {
            return NotFound();
        }

        float payOut = sideValue * payIn;

        Bet bet = new Bet(userId, payIn, payOut, sportEventId, side);


        _context.Bets.Add(bet);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBets), new { id = bet.Id }, bet);
    }

}