using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task2fromcode.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeptId",
                table: "employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MangerId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "hireDate",
                table: "Departments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_employees_DeptId",
                table: "employees",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_MangerId",
                table: "Departments",
                column: "MangerId",
                unique: true,
                filter: "[MangerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_employees_MangerId",
                table: "Departments",
                column: "MangerId",
                principalTable: "employees",
                principalColumn: "SSN");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_Departments_DeptId",
                table: "employees",
                column: "DeptId",
                principalTable: "Departments",
                principalColumn: "Dnum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_employees_MangerId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_employees_Departments_DeptId",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_DeptId",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_Departments_MangerId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DeptId",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "MangerId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "hireDate",
                table: "Departments");
        }
    }
}
