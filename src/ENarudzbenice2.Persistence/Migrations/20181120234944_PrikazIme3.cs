using Microsoft.EntityFrameworkCore.Migrations;

namespace ENarudzbenice2.Persistence.Migrations
{
    public partial class PrikazIme3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PrikazIme",
                schema: "App",
                table: "Users",
                nullable: true,
                computedColumnSql: "[Ime] + ' ' + [Prezime]",
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PrikazIme",
                schema: "App",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true,
                oldComputedColumnSql: "[Ime] + ' ' + [Prezime]");
        }
    }
}
