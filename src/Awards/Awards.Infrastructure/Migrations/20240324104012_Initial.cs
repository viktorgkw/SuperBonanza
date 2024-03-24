using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Awards.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "super-bonanza");

            migrationBuilder.CreateTable(
                name: "awards",
                schema: "super-bonanza",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_id = table.Column<string>(type: "character varying", maxLength: 255, nullable: false),
                    type = table.Column<string>(type: "character varying", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_awards", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "awards",
                schema: "super-bonanza");
        }
    }
}
