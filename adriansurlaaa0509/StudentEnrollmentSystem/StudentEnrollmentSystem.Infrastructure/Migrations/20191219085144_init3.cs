using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentEnrollmentSystem.Infrastructure.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnrollmentDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    enrollmentSemester = table.Column<string>(nullable: true),
                    enrollmentYear = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubjectLists",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _studentBasicInfoIDID = table.Column<int>(nullable: true),
                    _studentSubjectsIDID = table.Column<int>(nullable: true),
                    _enrollmentDetailsIDID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubjectLists", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentSubjectLists_EnrollmentDetails__enrollmentDetailsIDID",
                        column: x => x._enrollmentDetailsIDID,
                        principalTable: "EnrollmentDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentSubjectLists_StudentBasicInfos__studentBasicInfoIDID",
                        column: x => x._studentBasicInfoIDID,
                        principalTable: "StudentBasicInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentSubjectLists_StudentSubjects__studentSubjectsIDID",
                        column: x => x._studentSubjectsIDID,
                        principalTable: "StudentSubjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSubjectLists");

            migrationBuilder.DropTable(
                name: "EnrollmentDetails");
        }
    }
}
