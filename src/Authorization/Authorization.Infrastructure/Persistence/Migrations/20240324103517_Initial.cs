using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authorization.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "super-bonanza");

            migrationBuilder.CreateTable(
                name: "users",
                schema: "super-bonanza",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "character varying", maxLength: 255, nullable: true),
                    hashed_password = table.Column<string>(type: "character varying", maxLength: 255, nullable: true),
                    first_name = table.Column<string>(type: "character varying", maxLength: 255, nullable: true),
                    last_name = table.Column<string>(type: "character varying", maxLength: 255, nullable: true),
                    birth_date = table.Column<DateTime>(type: "date", maxLength: 255, nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users",
                schema: "super-bonanza");
        }
    }
}
