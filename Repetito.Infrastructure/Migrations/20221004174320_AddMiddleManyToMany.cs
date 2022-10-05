using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repetito.Infrastructure.Migrations
{
    public partial class AddMiddleManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PupilTeacher");

            migrationBuilder.CreateTable(
                name: "TeacherPupil",
                columns: table => new
                {
                    PupilId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherPupil", x => new { x.TeacherId, x.PupilId });
                    table.ForeignKey(
                        name: "FK_TeacherPupil_Pupils_PupilId",
                        column: x => x.PupilId,
                        principalTable: "Pupils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherPupil_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherPupil_PupilId",
                table: "TeacherPupil",
                column: "PupilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherPupil");

            migrationBuilder.CreateTable(
                name: "PupilTeacher",
                columns: table => new
                {
                    PupilsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeachersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PupilTeacher", x => new { x.PupilsId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_PupilTeacher_Pupils_PupilsId",
                        column: x => x.PupilsId,
                        principalTable: "Pupils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PupilTeacher_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PupilTeacher_TeachersId",
                table: "PupilTeacher",
                column: "TeachersId");
        }
    }
}
