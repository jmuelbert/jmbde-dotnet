using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace jmbde.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Password = table.Column<string>(nullable: true),
                    SystemdataId = table.Column<int>(nullable: false),
                    Timestamp = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Chipcard",
                columns: table => new
                {
                    ChipcardId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<int>(nullable: true),
                    Nummer = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chipcard", x => x.ChipcardId);
                });

            migrationBuilder.CreateTable(
                name: "Cityname",
                columns: table => new
                {
                    CitynameId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cityname", x => x.CitynameId);
                });

            migrationBuilder.CreateTable(
                name: "Databaseversion",
                columns: table => new
                {
                    DatabaseversionId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Patch = table.Column<long>(nullable: true),
                    Revision = table.Column<long>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true),
                    Version = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Databaseversion", x => x.DatabaseversionId);
                });

            migrationBuilder.CreateTable(
                name: "Devicename",
                columns: table => new
                {
                    DevicenameId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ManufacturerId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devicename", x => x.DevicenameId);
                });

            migrationBuilder.CreateTable(
                name: "Devicetype",
                columns: table => new
                {
                    DevicetypeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devicetype", x => x.DevicetypeId);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentsId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Document = table.Column<byte[]>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentsId);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryId);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    ManufacturerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Hotline = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Name2 = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Supporter = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true),
                    ZipcityId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.ManufacturerId);
                });

            migrationBuilder.CreateTable(
                name: "Os",
                columns: table => new
                {
                    OsId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fix = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Revision = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Os", x => x.OsId);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    PlaceId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Desk = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Room = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.PlaceId);
                });

            migrationBuilder.CreateTable(
                name: "Processor",
                columns: table => new
                {
                    ProcessorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cores = table.Column<int>(nullable: true),
                    Ghz = table.Column<float>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processor", x => x.ProcessorId);
                });

            migrationBuilder.CreateTable(
                name: "Software",
                columns: table => new
                {
                    SoftwareId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fix = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Revision = table.Column<int>(nullable: false),
                    Timestamp = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Software", x => x.SoftwareId);
                });

            migrationBuilder.CreateTable(
                name: "Systemdata",
                columns: table => new
                {
                    SystemdataId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true),
                    isLocal = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systemdata", x => x.SystemdataId);
                });

            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    TitleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.TitleId);
                });

            migrationBuilder.CreateTable(
                name: "Zipcity",
                columns: table => new
                {
                    ZipcityId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CityId = table.Column<int>(nullable: false),
                    CitynameId = table.Column<int>(nullable: false),
                    Timestamp = table.Column<string>(nullable: true),
                    ZipcodeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zipcity", x => x.ZipcityId);
                });

            migrationBuilder.CreateTable(
                name: "Zipcode",
                columns: table => new
                {
                    ZipcodeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Timestamp = table.Column<string>(nullable: true),
                    Zipcode1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zipcode", x => x.ZipcodeId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Businessemail = table.Column<string>(nullable: true),
                    ChipcardId = table.Column<int>(nullable: false),
                    ChipcardId1 = table.Column<int>(nullable: true),
                    ComputerId = table.Column<int>(nullable: false),
                    Datacare = table.Column<bool>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    EmployeeDocumentId = table.Column<int>(nullable: false),
                    EmployeeNr = table.Column<long>(nullable: true),
                    EmployeeaAccountId = table.Column<int>(nullable: false),
                    Enddate = table.Column<string>(nullable: true),
                    FaxId = table.Column<int>(nullable: false),
                    Firstname = table.Column<string>(maxLength: 50, nullable: true),
                    FunctionId = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: true),
                    Homeemail = table.Column<string>(nullable: true),
                    Homemobile = table.Column<string>(nullable: true),
                    Homephone = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(maxLength: 50, nullable: false),
                    MobileId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    PhoneId = table.Column<int>(nullable: false),
                    Photo = table.Column<byte[]>(nullable: true),
                    PrinterId = table.Column<int>(nullable: false),
                    Startdate = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true),
                    TitleId = table.Column<int>(nullable: true),
                    ZipcityId = table.Column<string>(nullable: true),
                    ZipcityId1 = table.Column<int>(nullable: true),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_Chipcard_ChipcardId1",
                        column: x => x.ChipcardId1,
                        principalTable: "Chipcard",
                        principalColumn: "ChipcardId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Title_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Title",
                        principalColumn: "TitleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Zipcity_ZipcityId1",
                        column: x => x.ZipcityId1,
                        principalTable: "Zipcity",
                        principalColumn: "ZipcityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employeeaccount",
                columns: table => new
                {
                    EmployeeaccountId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employeeaccount", x => x.EmployeeaccountId);
                    table.ForeignKey(
                        name: "FK_Employeeaccount_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employeedocument",
                columns: table => new
                {
                    EmployeedocumentId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DocumentId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employeedocument", x => x.EmployeedocumentId);
                    table.ForeignKey(
                        name: "FK_Employeedocument_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fax",
                columns: table => new
                {
                    FaxId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepartmentId = table.Column<int>(nullable: false),
                    DevicenameId = table.Column<int>(nullable: false),
                    DevicetypeId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true),
                    InventoryId = table.Column<int>(nullable: false),
                    ManufacturerId = table.Column<int>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Pin = table.Column<string>(nullable: true),
                    PlaceId = table.Column<int>(nullable: false),
                    PrinterId = table.Column<int>(nullable: false),
                    Serialnumber = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    shouldReplace = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fax", x => x.FaxId);
                    table.ForeignKey(
                        name: "FK_Fax_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Function",
                columns: table => new
                {
                    FunctionId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Prio = table.Column<int>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Function", x => x.FunctionId);
                    table.ForeignKey(
                        name: "FK_Function_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mobile",
                columns: table => new
                {
                    MobileId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Activatedate = table.Column<string>(nullable: true),
                    Cardnumber = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: false),
                    DevicenameId = table.Column<int>(nullable: false),
                    DevicetypeId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true),
                    InventoryId = table.Column<int>(nullable: false),
                    ManufacturerId = table.Column<int>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Pin = table.Column<string>(nullable: true),
                    PlaceId = table.Column<int>(nullable: false),
                    Serialnumber = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    shouldReplace = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobile", x => x.MobileId);
                    table.ForeignKey(
                        name: "FK_Mobile_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    PhoneId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepartmentId = table.Column<int>(nullable: false),
                    DevicenameId = table.Column<int>(nullable: false),
                    DevicetypeId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true),
                    InventoryId = table.Column<int>(nullable: false),
                    ManufacturerId = table.Column<int>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Pin = table.Column<string>(nullable: true),
                    PlaceId = table.Column<int>(nullable: false),
                    Serialnumber = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    shouldReplace = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.PhoneId);
                    table.ForeignKey(
                        name: "FK_Phone_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Printer",
                columns: table => new
                {
                    PrinterId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComputerId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    DevicenameId = table.Column<int>(nullable: false),
                    DevicetypeId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true),
                    InventoryId = table.Column<int>(nullable: false),
                    ManufacturerId = table.Column<int>(nullable: false),
                    Network = table.Column<string>(nullable: true),
                    NetworkIpaddress = table.Column<string>(nullable: true),
                    NetworkName = table.Column<string>(nullable: true),
                    PapersizeMax = table.Column<string>(nullable: true),
                    PlaceId = table.Column<int>(nullable: false),
                    Resources = table.Column<string>(nullable: true),
                    Serialnumber = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    isColor = table.Column<bool>(nullable: false),
                    shouldReplace = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Printer", x => x.PrinterId);
                    table.ForeignKey(
                        name: "FK_Printer_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Computer",
                columns: table => new
                {
                    ComputerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComputersoftwareId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    DevicenameId = table.Column<int>(nullable: false),
                    DevicetypeId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true),
                    InventoryId = table.Column<int>(nullable: false),
                    ManufacturerId = table.Column<int>(nullable: false),
                    Memory = table.Column<long>(nullable: true),
                    Network = table.Column<string>(nullable: true),
                    NetworkIpaddress = table.Column<string>(nullable: true),
                    NetworkName = table.Column<string>(nullable: true),
                    OsId = table.Column<int>(nullable: false),
                    PlaceId = table.Column<int>(nullable: false),
                    PrinterId = table.Column<int>(nullable: true),
                    PrinterId1 = table.Column<int>(nullable: true),
                    ProcessorId = table.Column<int>(nullable: false),
                    Serialnumber = table.Column<string>(nullable: true),
                    ServiceNumber = table.Column<string>(nullable: true),
                    ServiceTag = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    shouldReplace = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computer", x => x.ComputerId);
                    table.ForeignKey(
                        name: "FK_Computer_Devicename_DevicenameId",
                        column: x => x.DevicenameId,
                        principalTable: "Devicename",
                        principalColumn: "DevicenameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computer_Devicetype_DevicetypeId",
                        column: x => x.DevicetypeId,
                        principalTable: "Devicetype",
                        principalColumn: "DevicetypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computer_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Computer_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computer_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturer",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computer_Os_OsId",
                        column: x => x.OsId,
                        principalTable: "Os",
                        principalColumn: "OsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computer_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computer_Printer_PrinterId1",
                        column: x => x.PrinterId1,
                        principalTable: "Printer",
                        principalColumn: "PrinterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Computer_Processor_ProcessorId",
                        column: x => x.ProcessorId,
                        principalTable: "Processor",
                        principalColumn: "ProcessorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Computersoftware",
                columns: table => new
                {
                    ComputersoftwareId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComputerId = table.Column<int>(nullable: false),
                    SoftwareId = table.Column<int>(nullable: false),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computersoftware", x => x.ComputersoftwareId);
                    table.ForeignKey(
                        name: "FK_Computersoftware_Computer_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computer",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComputerId = table.Column<int>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: true),
                    FaxId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PrinterId = table.Column<int>(nullable: false),
                    Prio = table.Column<int>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Department_Computer_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computer",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Department_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Computer_DevicenameId",
                table: "Computer",
                column: "DevicenameId");

            migrationBuilder.CreateIndex(
                name: "IX_Computer_DevicetypeId",
                table: "Computer",
                column: "DevicetypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Computer_EmployeeId",
                table: "Computer",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Computer_InventoryId",
                table: "Computer",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Computer_ManufacturerId",
                table: "Computer",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Computer_OsId",
                table: "Computer",
                column: "OsId");

            migrationBuilder.CreateIndex(
                name: "IX_Computer_PlaceId",
                table: "Computer",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Computer_PrinterId1",
                table: "Computer",
                column: "PrinterId1");

            migrationBuilder.CreateIndex(
                name: "IX_Computer_ProcessorId",
                table: "Computer",
                column: "ProcessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Computersoftware_ComputerId",
                table: "Computersoftware",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_ComputerId",
                table: "Department",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_EmployeeId",
                table: "Department",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ChipcardId1",
                table: "Employee",
                column: "ChipcardId1");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_TitleId",
                table: "Employee",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ZipcityId1",
                table: "Employee",
                column: "ZipcityId1");

            migrationBuilder.CreateIndex(
                name: "IX_Employeeaccount_EmployeeId",
                table: "Employeeaccount",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employeedocument_EmployeeId",
                table: "Employeedocument",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fax_EmployeeId",
                table: "Fax",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Function_EmployeeId",
                table: "Function",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Mobile_EmployeeId",
                table: "Mobile",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_EmployeeId",
                table: "Phone",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Printer_EmployeeId",
                table: "Printer",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Cityname");

            migrationBuilder.DropTable(
                name: "Computersoftware");

            migrationBuilder.DropTable(
                name: "Databaseversion");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Employeeaccount");

            migrationBuilder.DropTable(
                name: "Employeedocument");

            migrationBuilder.DropTable(
                name: "Fax");

            migrationBuilder.DropTable(
                name: "Function");

            migrationBuilder.DropTable(
                name: "Mobile");

            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropTable(
                name: "Software");

            migrationBuilder.DropTable(
                name: "Systemdata");

            migrationBuilder.DropTable(
                name: "Zipcode");

            migrationBuilder.DropTable(
                name: "Computer");

            migrationBuilder.DropTable(
                name: "Devicename");

            migrationBuilder.DropTable(
                name: "Devicetype");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropTable(
                name: "Os");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropTable(
                name: "Printer");

            migrationBuilder.DropTable(
                name: "Processor");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Chipcard");

            migrationBuilder.DropTable(
                name: "Title");

            migrationBuilder.DropTable(
                name: "Zipcity");
        }
    }
}
