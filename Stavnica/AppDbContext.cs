using Microsoft.EntityFrameworkCore;

namespace Stavnica;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> User { get; set; }
    public DbSet<SportEvent> SportEvent { get; set; }
    public DbSet<Bet> Bet { get; set; }
}