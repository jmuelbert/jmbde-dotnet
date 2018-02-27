using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace jmbde.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Computer",
                columns: table => new
                {
                    ComputerId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Active = table.Column<string>(nullable: true),
                    ComputerSoftwareId = table.Column<long>(nullable: true),
                    DepartmentId = table.Column<long>(nullable: true),
                    DeviceNameId = table.Column<long>(nullable: true),
                    DeviceTypeId = table.Column<long>(nullable: true),
                    EmployeeId = table.Column<long>(nullable: true),
                    InventoryId = table.Column<long>(nullable: true),
                    LastUpdate = table.Column<string>(nullable: true),
                    ManufacturerId = table.Column<long>(nullable: true),
                    Memory = table.Column<long>(nullable: true),
                    Network = table.Column<string>(nullable: true),
                    NetworkIpAddress = table.Column<string>(nullable: true),
                    NetworkName = table.Column<string>(nullable: true),
                    OsId = table.Column<long>(nullable: true),
                    PlaceId = table.Column<long>(nullable: true),
                    PrinterId = table.Column<long>(nullable: true),
                    ProcessorId = table.Column<long>(nullable: true),
                    Replace = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    ServiceNumber = table.Column<string>(nullable: true),
                    ServiceTag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computer", x => x.ComputerId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Active = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    BirthDay = table.Column<string>(nullable: true),
                    BusinessMailAddress = table.Column<string>(nullable: true),
                    ChipCardId = table.Column<long>(nullable: true),
                    ComputerId = table.Column<long>(nullable: true),
                    DataCare = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<long>(nullable: true),
                    EmployeeAccountId = table.Column<long>(nullable: true),
                    EmployeeDocumentId = table.Column<long>(nullable: true),
                    EmployeeNr = table.Column<long>(nullable: true),
                    EndDate = table.Column<string>(nullable: true),
                    FaxId = table.Column<long>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    FunctionId = table.Column<long>(nullable: true),
                    Gender = table.Column<long>(nullable: true),
                    HireDate = table.Column<string>(nullable: true),
                    HomeMailAddress = table.Column<string>(nullable: true),
                    HomeMobile = table.Column<string>(nullable: true),
                    HomePhone = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LastUpdate = table.Column<string>(nullable: true),
                    MobileId = table.Column<long>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    PhoneId = table.Column<long>(nullable: true),
                    Photo = table.Column<byte[]>(nullable: true),
                    PrinterId = table.Column<long>(nullable: true),
                    TitleId = table.Column<long>(nullable: true),
                    ZipCityId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Mobile",
                columns: table => new
                {
                    MobileId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Active = table.Column<string>(nullable: true),
                    CardNumber = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<long>(nullable: true),
                    DeviceNameId = table.Column<long>(nullable: true),
                    DeviceTypeId = table.Column<long>(nullable: true),
                    EmployeeId = table.Column<long>(nullable: true),
                    InventoryId = table.Column<long>(nullable: true),
                    LastUpdate = table.Column<string>(nullable: true),
                    ManufacturerId = table.Column<long>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Pin = table.Column<string>(nullable: true),
                    PlaceId = table.Column<long>(nullable: true),
                    Replace = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobile", x => x.MobileId);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    PhoneId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Active = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<long>(nullable: true),
                    DeviceNameId = table.Column<long>(nullable: true),
                    DeviceTypeId = table.Column<long>(nullable: true),
                    EmployeeId = table.Column<long>(nullable: true),
                    InventoryId = table.Column<long>(nullable: true),
                    LastUpdate = table.Column<string>(nullable: true),
                    ManufacturerId = table.Column<long>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Pin = table.Column<string>(nullable: true),
                    PlaceId = table.Column<long>(nullable: true),
                    Replace = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.PhoneId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Computer");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Mobile");

            migrationBuilder.DropTable(
                name: "Phone");
        }
    }
}
