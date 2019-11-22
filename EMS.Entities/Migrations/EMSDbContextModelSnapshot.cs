﻿// <auto-generated />
using System;
using EMS.Entities.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EMS.Entities.Migrations
{
    [DbContext(typeof(EMSDbContext))]
    partial class EMSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EMS.Entities.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EMS.Entities.Designation", b =>
                {
                    b.Property<int>("DesignationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DesignationName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("DesignationId");

                    b.ToTable("Designations");
                });

            modelBuilder.Entity("EMS.Entities.Employee", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AadharNumber")
                        .HasMaxLength(20);

                    b.Property<string>("CommunicationAddress");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("DOB")
                        .IsRequired();

                    b.Property<int>("DepartmentId");

                    b.Property<int>("DesignationId");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("EmployeeCode");

                    b.Property<string>("FatherName")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Gender");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("JoiningDate");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("MaritalStatus");

                    b.Property<string>("MiddileName")
                        .HasMaxLength(50);

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("MotherName")
                        .HasMaxLength(50);

                    b.Property<string>("PanNumber")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("PassportExpDate");

                    b.Property<string>("PassportNumber")
                        .HasMaxLength(20);

                    b.Property<decimal?>("PastExperience");

                    b.Property<string>("PermanentAddress");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20);

                    b.Property<string>("PrimarySkills");

                    b.Property<int>("QualificationId");

                    b.Property<string>("ReportTo");

                    b.Property<string>("SecondarySkills");

                    b.Property<decimal?>("TotalExperience");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DesignationId");

                    b.HasIndex("QualificationId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EMS.Entities.Holiday", b =>
                {
                    b.Property<int>("HolidayId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("HolidayDate")
                        .IsRequired();

                    b.Property<string>("HolidayName")
                        .IsRequired();

                    b.HasKey("HolidayId");

                    b.ToTable("Holidays");
                });

            modelBuilder.Entity("EMS.Entities.LeaveType", b =>
                {
                    b.Property<int>("LeaveTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LeaveTypeName")
                        .IsRequired();

                    b.HasKey("LeaveTypeId");

                    b.ToTable("LeaveTypes");
                });

            modelBuilder.Entity("EMS.Entities.Qualification", b =>
                {
                    b.Property<int>("QualificationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("QualificationName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("QualificationId");

                    b.ToTable("Qualifications");
                });

            modelBuilder.Entity("EMS.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AspUserId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("LastLogin");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("MiddileName")
                        .HasMaxLength(50);

                    b.Property<string>("MobileNumber")
                        .HasMaxLength(20);

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EMS.Entities.Employee", b =>
                {
                    b.HasOne("EMS.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EMS.Entities.Designation", "Designation")
                        .WithMany()
                        .HasForeignKey("DesignationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EMS.Entities.Qualification", "Qualification")
                        .WithMany()
                        .HasForeignKey("QualificationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
