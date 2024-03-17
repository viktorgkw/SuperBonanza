using Impressions.Domain.Entities;
using Impressions.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Impressions.Infrastructure.Persistence;

public class ImpressionsDbContext(DbContextOptions<ImpressionsDbContext> options)
    : DbContext(options)
{
    public virtual DbSet<Game> Games { get; set; }
    public virtual DbSet<Impression> Impressions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<ImpressionType>();

        modelBuilder
            .Entity<Impression>(entity =>
            {
                entity.ToTable("impressions", "super-bonanza");

                entity.HasKey(x => x.Id);
                entity
                    .Property(x => x.Id)
                    .HasColumnName("id");

                entity.Property(e => e.GameId)
                    .HasColumnName("gameId")
                    .HasColumnType("character varying")
                    .HasMaxLength(255);

                entity.Property(e => e.PlayerId)
                    .HasColumnName("playerId")
                    .HasColumnType("character varying")
                    .HasMaxLength(255);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("character varying")
                    .HasMaxLength(255);
            });

        modelBuilder
            .Entity<Game>(entity =>
            {
                entity.ToTable("games", "super-bonanza", x => x.ExcludeFromMigrations());

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