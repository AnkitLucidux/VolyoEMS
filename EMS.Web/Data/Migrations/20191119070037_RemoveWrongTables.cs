using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EMS.Web.Data.Migrations
{
    public partial class RemoveWrongTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_EmployeeViewModel_EmployeeViewModelId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Designation_EmployeeViewModel_EmployeeViewModelId",
                table: "Designation");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeeViewModel_EmployeeViewModelId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Qualification_EmployeeViewModel_EmployeeViewModelId",
                table: "Qualification");

            migrationBuilder.DropTable(
                name: "RoleViewModel");

            migrationBuilder.DropTable(
                name: "UserViewModel");

            migrationBuilder.DropTable(
                name: "EmployeeViewModel");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Designation");

            migrationBuilder.DropTable(
                name: "Qualification");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoleViewModel",
                columns: table => new
                {
                    RoleId = table.Column<string>(nullable: false),
                    RoleName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleViewModel", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "UserViewModel",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    AspUserId = table.Column<Guid>(nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastLogin = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddileName = table.Column<string>(maxLength: 50, nullable: true),
                    MobileNumber = table.Column<string>(maxLength: 20, nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    RoleId = table.Column<string>(nullable: true),
                    RoleName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserViewModel", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(nullable: false),
                    AadharNumber = table.Column<string>(maxLength: 20, nullable: true),
                    CommunicationAddress = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    DesignationId = table.Column<int>(nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: false),
                    EmployeeCode = table.Column<int>(nullable: false),
                    EmployeeViewModelId = table.Column<int>(nullable: true),
                    FatherName = table.Column<string>(maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    JoiningDate = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    MaritalStatus = table.Column<int>(nullable: false),
                    MiddileName = table.Column<string>(maxLength: 50, nullable: true),
                    MobileNumber = table.Column<string>(maxLength: 20, nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    MotherName = table.Column<string>(maxLength: 50, nullable: true),
                    PanNumber = table.Column<string>(maxLength: 20, nullable: true),
                    PassportExpDate = table.Column<DateTime>(nullable: false),
                    PassportNumber = table.Column<string>(maxLength: 20, nullable: true),
                    PastExperience = table.Column<decimal>(nullable: false),
                    PermanentAddress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    PrimarySkills = table.Column<string>(nullable: true),
                    QualificationId = table.Column<int>(nullable: false),
                    ReportTo = table.Column<string>(nullable: true),
                    SecondarySkills = table.Column<string>(nullable: true),
                    TotalExperience = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: true),
                    DesignationId = table.Column<int>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    QualificationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeViewModel_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentName = table.Column<string>(maxLength: 20, nullable: false),
                    EmployeeViewModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Department_EmployeeViewModel_EmployeeViewModelId",
                        column: x => x.EmployeeViewModelId,
                        principalTable: "EmployeeViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Designation",
                columns: table => new
                {
                    DesignationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DesignationName = table.Column<string>(maxLength: 50, nullable: false),
                    EmployeeViewModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designation", x => x.DesignationId);
                    table.ForeignKey(
                        name: "FK_Designation_EmployeeViewModel_EmployeeViewModelId",
                        column: x => x.EmployeeViewModelId,
                        principalTable: "EmployeeViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Qualification",
                columns: table => new
                {
                    QualificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeViewModelId = table.Column<int>(nullable: true),
                    QualificationName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualification", x => x.QualificationId);
                    table.ForeignKey(
                        name: "FK_Qualification_EmployeeViewModel_EmployeeViewModelId",
                        column: x => x.EmployeeViewModelId,
                        principalTable: "EmployeeViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_EmployeeViewModelId",
                table: "Department",
                column: "EmployeeViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Designation_EmployeeViewModelId",
                table: "Designation",
                column: "EmployeeViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DesignationId",
                table: "Employee",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeViewModelId",
                table: "Employee",
                column: "EmployeeViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_QualificationId",
                table: "Employee",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeViewModel_DepartmentId",
                table: "EmployeeViewModel",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeViewModel_DesignationId",
                table: "EmployeeViewModel",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeViewModel_EmployeeId",
                table: "EmployeeViewModel",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeViewModel_QualificationId",
                table: "EmployeeViewModel",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Qualification_EmployeeViewModelId",
                table: "Qualification",
                column: "EmployeeViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmployeeViewModel_EmployeeViewModelId",
                table: "Employee",
                column: "EmployeeViewModelId",
                principalTable: "EmployeeViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_DepartmentId",
                table: "Employee",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Designation_DesignationId",
                table: "Employee",
                column: "DesignationId",
                principalTable: "Designation",
                principalColumn: "DesignationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Qualification_QualificationId",
                table: "Employee",
                column: "QualificationId",
                principalTable: "Qualification",
                principalColumn: "QualificationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeViewModel_Department_DepartmentId",
                table: "EmployeeViewModel",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeViewModel_Designation_DesignationId",
                table: "EmployeeViewModel",
                column: "DesignationId",
                principalTable: "Designation",
                principalColumn: "DesignationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeViewModel_Qualification_QualificationId",
                table: "EmployeeViewModel",
                column: "QualificationId",
                principalTable: "Qualification",
                principalColumn: "QualificationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
