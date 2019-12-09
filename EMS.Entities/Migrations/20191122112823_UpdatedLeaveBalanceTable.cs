using Microsoft.EntityFrameworkCore.Migrations;

namespace EMS.Entities.Migrations
{
    public partial class UpdatedLeaveBalanceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeLeaveBalances_LeaveTypes_LeaveTypeId",
                table: "EmployeeLeaveBalances");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeLeaveBalances_LeaveTypeId",
                table: "EmployeeLeaveBalances");

            migrationBuilder.DropColumn(
                name: "LeaveTypeId",
                table: "EmployeeLeaveBalances");

            migrationBuilder.AlterColumn<decimal>(
                name: "LeaveBalance",
                table: "EmployeeLeaveBalances",
                nullable: true,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "LeaveBalance",
                table: "EmployeeLeaveBalances",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LeaveTypeId",
                table: "EmployeeLeaveBalances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLeaveBalances_LeaveTypeId",
                table: "EmployeeLeaveBalances",
                column: "LeaveTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeLeaveBalances_LeaveTypes_LeaveTypeId",
                table: "EmployeeLeaveBalances",
                column: "LeaveTypeId",
                principalTable: "LeaveTypes",
                principalColumn: "LeaveTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
