using Microsoft.EntityFrameworkCore;

namespace Stavnica;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<SportEvent> SportEvents { get; set; }
    public DbSet<Bet> Bets { get; set; }
}