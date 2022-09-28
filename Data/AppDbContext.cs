using Microsoft.EntityFrameworkCore;
using WebAPIStarter.Models;

namespace WebAPIStarter.Data;

public class AppDbContext : DbContext
{
    private readonly List<Sample> _data = new ()
    {
        new Sample { Id = 1, Title = "Amirabbas" },
        new Sample { Id = 2, Title = "IRAN" },
        new Sample { Id = 3, Title = "Sample N03" },
    };

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base (options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Seed Fake Data...
        builder.Entity<Sample>().HasData(_data);
    }

    public DbSet<Sample> Samples { get; set; }
}