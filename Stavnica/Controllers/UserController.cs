using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Stavnica.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{

    private readonly ILogger<UserController> _logger;

    private readonly AppDbContext _context;

    public UserController(ILogger<UserController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpPost("/api/signup")]
    public async Task<ActionResult<User>> PostUser([FromBody] UserRequest userRequest)
    {
        var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == userRequest.Username);

            if (existingUser != null)
            {
                return Conflict(new { message = "Username already exists" });
            }

        User user = new User(userRequest.Username, userRequest.Password);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPost("/api/login")]
    public async Task<ActionResult<User>> LoginUser([FromBody] UserRequest userRequest)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == userRequest.Username);
        if (user.Password == userRequest.Password){
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }else{
            return Conflict(new { message = "Wrong credentials" });
        }  
    }
}
