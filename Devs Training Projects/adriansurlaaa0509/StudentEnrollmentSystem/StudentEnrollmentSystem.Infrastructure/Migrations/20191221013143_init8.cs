using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentEnrollmentSystem.Infrastructure.Migrations
{
    public partial class init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentBasicInfoID",
                table: "StudentProfessors");

            migrationBuilder.AddColumn<int>(
                name: "StudentProfessorID",
                table: "StudentSubjectLists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentSubjectsID",
                table: "StudentProfessors",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentProfessorID",
                table: "StudentSubjectLists");

            migrationBuilder.DropColumn(
                name: "StudentSubjectsID",
                table: "StudentProfessors");

            migrationBuilder.AddColumn<int>(
                name: "StudentBasicInfoID",
                table: "StudentProfessors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
