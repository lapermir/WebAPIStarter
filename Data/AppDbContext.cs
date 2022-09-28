using Microsoft.EntityFrameworkCore;
using WebAPIStarter.Models;

namespace WebAPIStarter.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base (options)
    {
        
    }

    // TODO
    // Seed Fake Data...
    // protected override void OnModelCreating()
    // {

    // }

    public DbSet<Sample> Samples { get; set; }
}