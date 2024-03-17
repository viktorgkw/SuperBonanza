using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Games.Infrastructure.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.EnsureSchema(
            name: "super-bonanza");

        migrationBuilder.CreateTable(
            name: "games",
            schema: "super-bonanza",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "character varying", maxLength: 255, nullable: true),
                description = table.Column<string>(type: "character varying", maxLength: 255, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_games", x => x.id);
            });

        migrationBuilder.InsertData(
            schema: "super-bonanza",
            table: "games",
            columns: new[] { "id", "description", "name" },
            values: new object[,]
            {
                { new Guid("0e6ee9c0-2fc5-429e-914c-e83eee1aeb2c"), "Random description.", "Blackjack" },
                { new Guid("51361d78-831d-4bef-98f4-dd8361ef6dc0"), "Random description.", "Big Wheel" },
                { new Guid("5eecc5fb-20a4-452e-9623-0baf70c97bb6"), "Random description.", "Poker" },
                { new Guid("9fdf07cb-8dc6-4681-9d8c-5cecc4f394a7"), "Random description.", "Slots" },
                { new Guid("f73fc9f6-c65d-4b6d-a698-f4e6267b357a"), "Random description.", "Roullete" }
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "games",
            schema: "super-bonanza");
    }
}