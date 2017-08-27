using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace jmbde.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: true),
                    Birthday = table.Column<DateTime>(type: "TEXT", nullable: true),
                    BusinessMail = table.Column<string>(type: "TEXT", maxLength: 40, nullable: true),
                    ChipCard = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: true),
                    DataCare = table.Column<bool>(type: "INTEGER", nullable: true),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: true),
                    EmployeeNO = table.Column<string>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    FaxNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 1, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Mail = table.Column<string>(type: "TEXT", maxLength: 40, nullable: true),
                    MiddleName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    MobileNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Photo = table.Column<byte[]>(type: "BLOB", nullable: true),
                    PlaceId = table.Column<int>(type: "INTEGER", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Street = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    WorkfunctionId = table.Column<int>(type: "INTEGER", nullable: true),
                    ZipCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: true),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Computers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mobiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: true),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Number = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mobiles_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: true),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Number = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Computers_EmployeeId",
                table: "Computers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Mobiles_EmployeeId",
                table: "Mobiles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_EmployeeId",
                table: "Phones",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Computers");

            migrationBuilder.DropTable(
                name: "Mobiles");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
