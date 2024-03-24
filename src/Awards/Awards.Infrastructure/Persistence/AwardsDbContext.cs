using Awards.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Awards.Infrastructure.Persistence;

public class AwardsDbContext(DbContextOptions<AwardsDbContext> options)
    : DbContext(options)
{
    public virtual DbSet<Award> Awards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Award>(entity =>
            {
                entity.ToTable("awards", "super-bonanza");

                entity.HasKey(x => x.Id);
                entity
                    .Property(x => x.Id)
                    .HasColumnName("id");

                entity.Property(e => e.PlayerId)
                    .HasColumnName("player_id")
                    .HasColumnType("character varying")
                    .HasMaxLength(255);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("character varying")
                    .HasMaxLength(255);
            });
    }
}