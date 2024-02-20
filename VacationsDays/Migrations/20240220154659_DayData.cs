using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VacationsDays.Migrations
{
    public partial class DayData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SelectedDays",
                table: "Vacations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "BlokedJson",
                table: "Vacations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                name: "Dictionary<int, string>",
                columns: table => new
                {
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DaysData");

            migrationBuilder.DropTable(
                name: "Dictionary<int, string>");

            migrationBuilder.AlterColumn<int>(
                name: "SelectedDays",
                table: "Vacations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BlokedJson",
                table: "Vacations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
