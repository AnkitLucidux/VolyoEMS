using Microsoft.EntityFrameworkCore.Migrations;

namespace EMS.Entities.Migrations
{
    public partial class AddedholidayEntity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_holidays",
                table: "holidays");

            migrationBuilder.RenameTable(
                name: "holidays",
                newName: "Holidays");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Holidays",
                table: "Holidays",
                column: "HolidayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Holidays",
                table: "Holidays");

            migrationBuilder.RenameTable(
                name: "Holidays",
                newName: "holidays");

            migrationBuilder.AddPrimaryKey(
                name: "PK_holidays",
                table: "holidays",
                column: "HolidayId");
        }
    }
}
