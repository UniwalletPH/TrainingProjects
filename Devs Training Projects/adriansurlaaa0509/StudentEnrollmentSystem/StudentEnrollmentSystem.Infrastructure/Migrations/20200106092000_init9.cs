using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentEnrollmentSystem.Infrastructure.Migrations
{
    public partial class init9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "enrollmentYear",
                table: "EnrollmentDetails",
                newName: "EnrollmentYear");

            migrationBuilder.RenameColumn(
                name: "enrollmentSemester",
                table: "EnrollmentDetails",
                newName: "EnrollmentSemester");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EnrollmentYear",
                table: "EnrollmentDetails",
                newName: "enrollmentYear");

            migrationBuilder.RenameColumn(
                name: "EnrollmentSemester",
                table: "EnrollmentDetails",
                newName: "enrollmentSemester");
        }
    }
}
