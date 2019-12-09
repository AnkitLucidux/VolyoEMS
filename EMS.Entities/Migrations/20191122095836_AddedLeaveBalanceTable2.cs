using Microsoft.EntityFrameworkCore.Migrations;

namespace EMS.Entities.Migrations
{
    public partial class AddedLeaveBalanceTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employeeLeaveBalances_Employees_EmployeeId",
                table: "employeeLeaveBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_employeeLeaveBalances_LeaveTypes_LeaveTypeId",
                table: "employeeLeaveBalances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employeeLeaveBalances",
                table: "employeeLeaveBalances");

            migrationBuilder.RenameTable(
                name: "employeeLeaveBalances",
                newName: "EmployeeLeaveBalances");

            migrationBuilder.RenameIndex(
                name: "IX_employeeLeaveBalances_LeaveTypeId",
                table: "EmployeeLeaveBalances",
                newName: "IX_EmployeeLeaveBalances_LeaveTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_employeeLeaveBalances_EmployeeId",
                table: "EmployeeLeaveBalances",
                newName: "IX_EmployeeLeaveBalances_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeLeaveBalances",
                table: "EmployeeLeaveBalances",
                column: "LeaveBalanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeLeaveBalances_Employees_EmployeeId",
                table: "EmployeeLeaveBalances",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeLeaveBalances_LeaveTypes_LeaveTypeId",
                table: "EmployeeLeaveBalances",
                column: "LeaveTypeId",
                principalTable: "LeaveTypes",
                principalColumn: "LeaveTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeLeaveBalances_Employees_EmployeeId",
                table: "EmployeeLeaveBalances");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeLeaveBalances_LeaveTypes_LeaveTypeId",
                table: "EmployeeLeaveBalances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeLeaveBalances",
                table: "EmployeeLeaveBalances");

            migrationBuilder.RenameTable(
                name: "EmployeeLeaveBalances",
                newName: "employeeLeaveBalances");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeLeaveBalances_LeaveTypeId",
                table: "employeeLeaveBalances",
                newName: "IX_employeeLeaveBalances_LeaveTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeLeaveBalances_EmployeeId",
                table: "employeeLeaveBalances",
                newName: "IX_employeeLeaveBalances_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employeeLeaveBalances",
                table: "employeeLeaveBalances",
                column: "LeaveBalanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_employeeLeaveBalances_Employees_EmployeeId",
                table: "employeeLeaveBalances",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_employeeLeaveBalances_LeaveTypes_LeaveTypeId",
                table: "employeeLeaveBalances",
                column: "LeaveTypeId",
                principalTable: "LeaveTypes",
                principalColumn: "LeaveTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
