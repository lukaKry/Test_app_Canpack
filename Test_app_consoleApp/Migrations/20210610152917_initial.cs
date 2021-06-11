using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_app_consoleApp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DatabaseRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessingStatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Efficiency = table.Column<decimal>(type: "decimal(5,4)", nullable: false),
                    CurrentDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatabaseRecords", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatabaseRecords");
        }
    }
}
