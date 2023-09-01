﻿// <auto-generated />
using System;
using Company.Datalayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Company.Migrations
{
    [DbContext(typeof(CompanyDbContext))]
    partial class CompanyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Company.Models.Entity.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("department_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department");

                    b.HasData(
                        new
                        {
                            DepartmentId = 1,
                            Name = "Software Engineering"
                        },
                        new
                        {
                            DepartmentId = 2,
                            Name = "Human Resources"
                        });
                });

            modelBuilder.Entity("Company.Models.Entity.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("employee_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasColumnName("age");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("city");

                    b.Property<DateTime?>("DOB")
                        .HasColumnType("datetime2")
                        .HasColumnName("dob");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int")
                        .HasColumnName("department_id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("first_name");

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_of_hire");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("last_name");

                    b.Property<string>("MiddleInitial")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)")
                        .HasColumnName("middle_initial");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("phone_number");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("salary");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("state");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("street");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.Property<int?>("WorkLocation")
                        .HasColumnType("int")
                        .HasColumnName("work_location");

                    b.Property<string>("Zip")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)")
                        .HasColumnName("zip");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("FirstName", "LastName", "Email")
                        .IsUnique();

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            Age = 31,
                            City = "Pune",
                            DepartmentId = 1,
                            Email = "Test@EvolentHealth.com",
                            FirstName = "Test",
                            LastName = "Employee",
                            MiddleInitial = "A",
                            State = "MH",
                            Street = "Street1",
                            Zip = "411048"
                        },
                        new
                        {
                            EmployeeId = 2,
                            Age = 31,
                            City = "Pune",
                            DepartmentId = 2,
                            Email = "Test2@EvolentHealth.com",
                            FirstName = "Test2",
                            LastName = "Employee2",
                            MiddleInitial = "B",
                            State = "MH",
                            Street = "Street2",
                            Zip = "411048"
                        },
                        new
                        {
                            EmployeeId = 3,
                            Age = 31,
                            City = "Pune",
                            DepartmentId = 2,
                            Email = "Test3@EvolentHealth.com",
                            FirstName = "Test3",
                            LastName = "Employee3",
                            MiddleInitial = "C",
                            State = "MH",
                            Street = "Street3",
                            Zip = "411048"
                        });
                });

            modelBuilder.Entity("Company.Models.Entity.Employee", b =>
                {
                    b.HasOne("Company.Models.Entity.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Company.Models.Entity.Department", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
