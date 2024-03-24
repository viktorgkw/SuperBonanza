using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Impressions.Infrastructure.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.EnsureSchema(
            name: "super-bonanza");

        migrationBuilder.AlterDatabase()
            .Annotation("Npgsql:Enum:impression_type", "click,play");

        migrationBuilder.CreateTable(
            name: "impressions",
            schema: "super-bonanza",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                gameId = table.Column<string>(type: "character varying", maxLength: 255, nullable: false),
                playerId = table.Column<string>(type: "character varying", maxLength: 255, nullable: false),
                type = table.Column<string>(type: "character varying", maxLength: 255, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_impressions", x => x.id);
            });

        migrationBuilder.InsertData(
            schema: "super-bonanza",
            table: "games",
            columns: new[] { "id", "description", "name" },
            values: new object[,]
            {
                { new Guid("2856aeb9-629a-4a17-9888-eeae9663f4b0"), "Random description.", "Blackjack" },
                { new Guid("4cc803a9-d627-408c-aaa3-1abbf502744b"), "Random description.", "Poker" },
                { new Guid("4f74258a-9a2a-4b40-8eba-df0089bda5ee"), "Random description.", "Slots" },
                { new Guid("5295395d-d499-4002-93b5-b6bbe1c88098"), "Random description.", "Big Wheel" },
                { new Guid("9f9c53f3-9337-4b31-ac6d-de43583aa67d"), "Random description.", "Roullete" }
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "impressions",
            schema: "super-bonanza");
    }
}