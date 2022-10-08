using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repetito.Infrastructure.Migrations
{
    public partial class RemoveCalendar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalendarEntries_Calendars_CalendarId",
                table: "CalendarEntries");

            migrationBuilder.DropTable(
                name: "Calendars");

            migrationBuilder.DropIndex(
                name: "IX_CalendarEntries_CalendarId",
                table: "CalendarEntries");

            migrationBuilder.DropColumn(
                name: "CalendarId",
                table: "CalendarEntries");

            migrationBuilder.AddColumn<Guid>(
                name: "PupilId",
                table: "CalendarEntries",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                table: "CalendarEntries",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEntries_PupilId",
                table: "CalendarEntries",
                column: "PupilId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEntries_TeacherId",
                table: "CalendarEntries",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarEntries_Pupils_PupilId",
                table: "CalendarEntries",
                column: "PupilId",
                principalTable: "Pupils",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarEntries_Teachers_TeacherId",
                table: "CalendarEntries",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalendarEntries_Pupils_PupilId",
                table: "CalendarEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_CalendarEntries_Teachers_TeacherId",
                table: "CalendarEntries");

            migrationBuilder.DropIndex(
                name: "IX_CalendarEntries_PupilId",
                table: "CalendarEntries");

            migrationBuilder.DropIndex(
                name: "IX_CalendarEntries_TeacherId",
                table: "CalendarEntries");

            migrationBuilder.DropColumn(
                name: "PupilId",
                table: "CalendarEntries");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "CalendarEntries");

            migrationBuilder.AddColumn<Guid>(
                name: "CalendarId",
                table: "CalendarEntries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PupilId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calendars_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEntries_CalendarId",
                table: "CalendarEntries",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_TeacherId",
                table: "Calendars",
                column: "TeacherId",
                unique: true,
                filter: "[TeacherId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarEntries_Calendars_CalendarId",
                table: "CalendarEntries",
                column: "CalendarId",
                principalTable: "Calendars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
