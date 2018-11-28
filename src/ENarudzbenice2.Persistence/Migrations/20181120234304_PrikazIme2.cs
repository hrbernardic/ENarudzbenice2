using Microsoft.EntityFrameworkCore.Migrations;

namespace ENarudzbenice2.Persistence.Migrations
{
    public partial class PrikazIme2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrikazIme",
                schema: "App",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrikazIme",
                schema: "App",
                table: "Users");
        }
    }
}
