using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repetito.Infrastructure.Migrations
{
    public partial class AddAgeToTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Teachers");
        }
    }
}
