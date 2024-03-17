using Games.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Games.Infrastructure.Persistence;

public class GamesDbContext(DbContextOptions<GamesDbContext> options)
    : DbContext(options)
{
    public virtual DbSet<Game> Games { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Game>(entity =>
            {
                entity.ToTable("games", "super-bonanza");

                entity.HasKey(x => x.Id);
                entity
                    .Property(x => x.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying")
                    .HasMaxLength(255);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("character varying")
                    .HasMaxLength(255);

                entity.HasData([
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
            });
    }
}