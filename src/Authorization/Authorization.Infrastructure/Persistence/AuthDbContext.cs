using Authorization.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Authorization.Infrastructure.Persistence;

public class AuthDbContext(DbContextOptions<AuthDbContext> options)
    : DbContext(options)
{
    public virtual DbSet<AppUser> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<AppUser>(entity =>
            {
                entity.ToTable("users", "super-bonanza");

                entity.HasKey(x => x.Id);
                entity
                    .Property(x => x.Id)
                    .HasColumnName("id");

                entity.Property(e => e.UserName)
                    .HasColumnName("username")
                    .HasColumnType("character varying")
                    .HasMaxLength(255);

                entity.Property(e => e.HashedPassword)
                    .HasColumnName("hashed_password")
                    .HasColumnType("character varying")
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("character varying")
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("character varying")
                    .HasMaxLength(255);

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date")
                    .HasMaxLength(255);

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("boolean")
                    .HasMaxLength(255);
            });
    }
}