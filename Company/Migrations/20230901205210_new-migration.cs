﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Company.Migrations
{
    /// <inheritdoc />
    public partial class newmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    department_id = table.Column<int>(type: "int", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    middle_initial = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    dob = table.Column<DateTime>(type: "datetime2", nullable: true),
                    phone_number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    zip = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    age = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_of_hire = table.Column<DateTime>(type: "datetime2", nullable: true),
                    salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    work_location = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.employee_id);
                    table.ForeignKey(
                        name: "FK_Employee_Department_department_id",
                        column: x => x.department_id,
                        principalTable: "Department",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "department_id", "Name" },
                values: new object[,]
                {
                    { 1, "Software Engineering" },
                    { 2, "Human Resources" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "employee_id", "age", "city", "dob", "department_id", "email", "first_name", "date_of_hire", "last_name", "middle_initial", "phone_number", "salary", "state", "street", "title", "work_location", "zip" },
                values: new object[,]
                {
                    { 1, 31, "Pune", null, 1, "Test@EvolentHealth.com", "Test", null, "Employee", "A", null, null, "MH", "Street1", null, null, "411048" },
                    { 2, 31, "Pune", null, 2, "Test2@EvolentHealth.com", "Test2", null, "Employee2", "B", null, null, "MH", "Street2", null, null, "411048" },
                    { 3, 31, "Pune", null, 2, "Test3@EvolentHealth.com", "Test3", null, "Employee3", "C", null, null, "MH", "Street3", null, null, "411048" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_department_id",
                table: "Employee",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_first_name_last_name_email",
                table: "Employee",
                columns: new[] { "first_name", "last_name", "email" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
