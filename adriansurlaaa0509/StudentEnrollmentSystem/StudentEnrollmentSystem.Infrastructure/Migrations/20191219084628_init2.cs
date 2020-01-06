using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentEnrollmentSystem.Infrastructure.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectID",
                table: "StudentSubjects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SubjectName",
                table: "StudentSubjects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentSubjects",
                table: "StudentBasicInfos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentBasicInfos_StudentSubjects",
                table: "StudentBasicInfos",
                column: "StudentSubjects");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentBasicInfos_StudentSubjects_StudentSubjects",
                table: "StudentBasicInfos",
                column: "StudentSubjects",
                principalTable: "StudentSubjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentBasicInfos_StudentSubjects_StudentSubjects",
                table: "StudentBasicInfos");

            migrationBuilder.DropIndex(
                name: "IX_StudentBasicInfos_StudentSubjects",
                table: "StudentBasicInfos");

            migrationBuilder.DropColumn(
                name: "SubjectID",
                table: "StudentSubjects");

            migrationBuilder.DropColumn(
                name: "SubjectName",
                table: "StudentSubjects");

            migrationBuilder.DropColumn(
                name: "StudentSubjects",
                table: "StudentBasicInfos");
        }
    }
}
