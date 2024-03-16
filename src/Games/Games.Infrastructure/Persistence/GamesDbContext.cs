using Games.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Games.Infrastructure.Persistence;

public class GamesDbContext : DbContext
{
    public GamesDbContext(DbContextOptions<GamesDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Game> Games { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Game>()
            .HasData([
                new Game()
                {
                    Id = Guid.NewGuid(),
                    Name = "Blackjack",
                    Description = "Random description."
                },
                new Game()
                {
                    Id = Guid.NewGuid(),
                    Name = "Roullete",
                    Description = "Random description."
                },
                new Game()
                {
                    Id = Guid.NewGuid(),
                    Name = "Poker",
                    Description = "Random description."
                },
                new Game()
                {
                    Id = Guid.NewGuid(),
                    Name = "Slots",
                    Description = "Random description."
                },
                new Game()
                {
                    Id = Guid.NewGuid(),
                    Name = "Big Wheel",
                    Description = "Random description."
                }
            ]);
    }
}