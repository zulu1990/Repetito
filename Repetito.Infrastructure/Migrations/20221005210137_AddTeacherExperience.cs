using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repetito.Infrastructure.Migrations
{
    public partial class AddTeacherExperience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Experience",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Teachers");
        }
    }
}
