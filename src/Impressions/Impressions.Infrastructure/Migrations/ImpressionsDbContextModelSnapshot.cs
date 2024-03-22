﻿// <auto-generated />
using System;
using Impressions.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Impressions.Infrastructure.Migrations
{
    [DbContext(typeof(ImpressionsDbContext))]
    partial class ImpressionsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "impression_type", new[] { "click", "play" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Impressions.Domain.Entities.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("character varying")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("games", "super-bonanza", t =>
                        {
                            t.ExcludeFromMigrations();
                        });

                    b.HasData(
                        new
                        {
                            Id = new Guid("2856aeb9-629a-4a17-9888-eeae9663f4b0"),
                            Description = "Random description.",
                            Name = "Blackjack"
                        },
                        new
                        {
                            Id = new Guid("9f9c53f3-9337-4b31-ac6d-de43583aa67d"),
                            Description = "Random description.",
                            Name = "Roullete"
                        },
                        new
                        {
                            Id = new Guid("4cc803a9-d627-408c-aaa3-1abbf502744b"),
                            Description = "Random description.",
                            Name = "Poker"
                        },
                        new
                        {
                            Id = new Guid("4f74258a-9a2a-4b40-8eba-df0089bda5ee"),
                            Description = "Random description.",
                            Name = "Slots"
                        },
                        new
                        {
                            Id = new Guid("5295395d-d499-4002-93b5-b6bbe1c88098"),
                            Description = "Random description.",
                            Name = "Big Wheel"
                        });
                });

            modelBuilder.Entity("Impressions.Domain.Entities.Impression", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("GameId")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying")
                        .HasColumnName("gameId");

                    b.Property<string>("PlayerId")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying")
                        .HasColumnName("playerId");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("impressions", "super-bonanza");
                });
#pragma warning restore 612, 618
        }
    }
}