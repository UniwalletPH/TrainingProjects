using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EManager.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeInformation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInformation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTimeRecords",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(nullable: false),
                    RecordType = table.Column<int>(nullable: false),
                    EmployeeInformationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTimeRecords", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmployeeTimeRecords_EmployeeInformation_EmployeeInformationID",
                        column: x => x.EmployeeInformationID,
                        principalTable: "EmployeeInformation",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTimeRecords_EmployeeInformationID",
                table: "EmployeeTimeRecords",
                column: "EmployeeInformationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTimeRecords");

            migrationBuilder.DropTable(
                name: "EmployeeInformation");
        }
    }
}
