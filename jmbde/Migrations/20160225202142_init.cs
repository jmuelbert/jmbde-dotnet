using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace jmbde.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Active = table.Column<bool>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    BusinessMail = table.Column<string>(nullable: true),
                    ChipCard = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true),
                    DataCare = table.Column<bool>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true),
                    EmployeeNO = table.Column<string>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    FaxNumber = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    LastUpdate = table.Column<DateTime>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Photo = table.Column<byte[]>(nullable: true),
                    PlaceId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    WorkfunctionId = table.Column<int>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Active = table.Column<bool>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    FaxNumber = table.Column<string>(nullable: true),
                    LastUpdate = table.Column<DateTime>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Name2 = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Computer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Active = table.Column<bool>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Computer_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Mobile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Active = table.Column<bool>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: true),
                    Number = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mobile_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Active = table.Column<bool>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: true),
                    Number = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phone_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Company");
            migrationBuilder.DropTable("Computer");
            migrationBuilder.DropTable("Mobile");
            migrationBuilder.DropTable("Phone");
            migrationBuilder.DropTable("Employee");
        }
    }
}
