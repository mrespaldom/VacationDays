using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VacationsDays.Migrations
{
    public partial class addVacationtoDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DaysData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfYear = table.Column<int>(type: "int", nullable: false),
                    IsCheckedV = table.Column<bool>(type: "bit", nullable: false),
                    IsCheckedCH = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaysData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vacations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemainingDays = table.Column<int>(type: "int", nullable: true),
                    TotalDays = table.Column<int>(type: "int", nullable: false),
                    BookedDays = table.Column<int>(type: "int", nullable: false),
                    ChDays = table.Column<int>(type: "int", nullable: false),
                    VacTotalDays = table.Column<int>(type: "int", nullable: false),
                    LegalVacYearBef = table.Column<int>(type: "int", nullable: false),
                    LegalVacYearBefH2 = table.Column<int>(type: "int", nullable: false),
                    LegalVacYear = table.Column<int>(type: "int", nullable: false),
                    SelectedDays = table.Column<int>(type: "int", nullable: true),
                    BlokedJson = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DaysData");

            migrationBuilder.DropTable(
                name: "Vacations");
        }
    }
}
