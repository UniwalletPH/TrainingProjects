using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentEnrollmentSystem.Infrastructure.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentBasicInfos_StudentSubjects_StudentSubjects",
                table: "StudentBasicInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjectLists_EnrollmentDetails__enrollmentDetailsIDID",
                table: "StudentSubjectLists");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjectLists_StudentBasicInfos__studentBasicInfoIDID",
                table: "StudentSubjectLists");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjectLists_StudentSubjects__studentSubjectsIDID",
                table: "StudentSubjectLists");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjectLists__enrollmentDetailsIDID",
                table: "StudentSubjectLists");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjectLists__studentBasicInfoIDID",
                table: "StudentSubjectLists");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjectLists__studentSubjectsIDID",
                table: "StudentSubjectLists");

            migrationBuilder.DropIndex(
                name: "IX_StudentBasicInfos_StudentSubjects",
                table: "StudentBasicInfos");

            migrationBuilder.DropColumn(
                name: "SubjectID",
                table: "StudentSubjects");

            migrationBuilder.DropColumn(
                name: "_enrollmentDetailsIDID",
                table: "StudentSubjectLists");

            migrationBuilder.DropColumn(
                name: "_studentBasicInfoIDID",
                table: "StudentSubjectLists");

            migrationBuilder.DropColumn(
                name: "_studentSubjectsIDID",
                table: "StudentSubjectLists");

            migrationBuilder.DropColumn(
                name: "StudentSubjects",
                table: "StudentBasicInfos");

            migrationBuilder.AddColumn<int>(
                name: "EnrollmentDetailsID",
                table: "StudentSubjectLists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentBasicInfoID",
                table: "StudentSubjectLists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentSubjectsID",
                table: "StudentSubjectLists",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnrollmentDetailsID",
                table: "StudentSubjectLists");

            migrationBuilder.DropColumn(
                name: "StudentBasicInfoID",
                table: "StudentSubjectLists");

            migrationBuilder.DropColumn(
                name: "StudentSubjectsID",
                table: "StudentSubjectLists");

            migrationBuilder.AddColumn<int>(
                name: "SubjectID",
                table: "StudentSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "_enrollmentDetailsIDID",
                table: "StudentSubjectLists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "_studentBasicInfoIDID",
                table: "StudentSubjectLists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "_studentSubjectsIDID",
                table: "StudentSubjectLists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentSubjects",
                table: "StudentBasicInfos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectLists__enrollmentDetailsIDID",
                table: "StudentSubjectLists",
                column: "_enrollmentDetailsIDID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectLists__studentBasicInfoIDID",
                table: "StudentSubjectLists",
                column: "_studentBasicInfoIDID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectLists__studentSubjectsIDID",
                table: "StudentSubjectLists",
                column: "_studentSubjectsIDID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjectLists_EnrollmentDetails__enrollmentDetailsIDID",
                table: "StudentSubjectLists",
                column: "_enrollmentDetailsIDID",
                principalTable: "EnrollmentDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjectLists_StudentBasicInfos__studentBasicInfoIDID",
                table: "StudentSubjectLists",
                column: "_studentBasicInfoIDID",
                principalTable: "StudentBasicInfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjectLists_StudentSubjects__studentSubjectsIDID",
                table: "StudentSubjectLists",
                column: "_studentSubjectsIDID",
                principalTable: "StudentSubjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
