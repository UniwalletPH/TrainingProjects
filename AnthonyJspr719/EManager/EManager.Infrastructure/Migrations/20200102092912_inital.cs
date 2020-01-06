using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EManager.Infrastructure.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeIn",
                table: "EmployeeTimeRecords");

            migrationBuilder.DropColumn(
                name: "TimeOut",
                table: "EmployeeTimeRecords");

            migrationBuilder.AddColumn<int>(
                name: "RecordType",
                table: "EmployeeTimeRecords",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "EmployeeTimeRecords",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordType",
                table: "EmployeeTimeRecords");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "EmployeeTimeRecords");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeIn",
                table: "EmployeeTimeRecords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeOut",
                table: "EmployeeTimeRecords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
