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
                name: "Chipcard",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Active = table.Column<bool>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chipcard", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Devicename",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devicename", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Devicetype",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devicetype", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    CityId = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Hotline = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Name2 = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Supporter = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Desk = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Room = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Processor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cores = table.Column<int>(nullable: true),
                    Ghz = table.Column<float>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Chipcarddoor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChipcardID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chipcarddoor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Chipcarddoor_Chipcard_ChipcardID",
                        column: x => x.ChipcardID,
                        principalTable: "Chipcard",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chipcardprofile",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChipcardID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chipcardprofile", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Chipcardprofile_Chipcard_ChipcardID",
                        column: x => x.ChipcardID,
                        principalTable: "Chipcard",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Systemdata",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    CityID = table.Column<int>(nullable: false),
                    Company = table.Column<string>(nullable: true),
                    Local = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systemdata", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Systemdata_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Os",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fix = table.Column<string>(nullable: true),
                    ManufacturerID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Revision = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Os", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Os_Manufacturer_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Active = table.Column<bool>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    PlaceID = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Inventory_Place_PlaceID",
                        column: x => x.PlaceID,
                        principalTable: "Place",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Active = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Businessemail = table.Column<string>(nullable: true),
                    ChipcardID = table.Column<int>(nullable: false),
                    CityID = table.Column<string>(nullable: true),
                    CityID1 = table.Column<int>(nullable: true),
                    Datacare = table.Column<bool>(nullable: false),
                    Enddate = table.Column<string>(nullable: true),
                    FaxID = table.Column<int>(nullable: false),
                    Firstname = table.Column<string>(maxLength: 50, nullable: true),
                    Gender = table.Column<int>(nullable: true),
                    Homeemail = table.Column<string>(nullable: true),
                    Homemobile = table.Column<string>(nullable: true),
                    Homephone = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 20, nullable: true),
                    MobileID = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Nr = table.Column<string>(nullable: true),
                    PhoneID = table.Column<int>(nullable: false),
                    Photo = table.Column<byte[]>(nullable: true),
                    Startdate = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true),
                    TitleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employee_City_CityID1",
                        column: x => x.CityID1,
                        principalTable: "City",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Title_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Title",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeID = table.Column<int>(nullable: true),
                    Password = table.Column<string>(maxLength: 30, nullable: true),
                    SystemdataID = table.Column<int>(nullable: false),
                    Timestamp = table.Column<string>(nullable: true),
                    Username = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Account_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Account_Systemdata_SystemdataID",
                        column: x => x.SystemdataID,
                        principalTable: "Systemdata",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Prio = table.Column<int>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Department_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeID = table.Column<int>(nullable: true),
                    MyDocument = table.Column<byte[]>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Document_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Function",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Prio = table.Column<int>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Function", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Function_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mobile",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Activatedate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Cardnumber = table.Column<string>(nullable: true),
                    DepartmentID = table.Column<int>(nullable: false),
                    DevicenameID = table.Column<int>(nullable: false),
                    DevicetypeID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    EmployeeID1 = table.Column<int>(nullable: true),
                    InventoryID = table.Column<int>(nullable: false),
                    ManufacturerID = table.Column<int>(nullable: false),
                    Number = table.Column<string>(maxLength: 30, nullable: false),
                    Pin = table.Column<string>(nullable: true),
                    PlaceID = table.Column<int>(nullable: false),
                    Replace = table.Column<bool>(nullable: false),
                    Serialnumber = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobile", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Mobile_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mobile_Devicename_DevicenameID",
                        column: x => x.DevicenameID,
                        principalTable: "Devicename",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mobile_Devicetype_DevicetypeID",
                        column: x => x.DevicetypeID,
                        principalTable: "Devicetype",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mobile_Employee_EmployeeID1",
                        column: x => x.EmployeeID1,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mobile_Inventory_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mobile_Manufacturer_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mobile_Place_PlaceID",
                        column: x => x.PlaceID,
                        principalTable: "Place",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Active = table.Column<bool>(nullable: false),
                    DepartmentID = table.Column<int>(nullable: false),
                    DevicenameID = table.Column<int>(nullable: false),
                    DevicetypeID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    EmployeeID1 = table.Column<int>(nullable: true),
                    InventoryID = table.Column<int>(nullable: false),
                    ManufacturerID = table.Column<int>(nullable: false),
                    Number = table.Column<string>(maxLength: 30, nullable: false),
                    Pin = table.Column<string>(nullable: true),
                    PlaceID = table.Column<int>(nullable: false),
                    Replace = table.Column<bool>(nullable: false),
                    Serialnumber = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Phone_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Phone_Devicename_DevicenameID",
                        column: x => x.DevicenameID,
                        principalTable: "Devicename",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Phone_Devicetype_DevicetypeID",
                        column: x => x.DevicetypeID,
                        principalTable: "Devicetype",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Phone_Employee_EmployeeID1",
                        column: x => x.EmployeeID1,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Phone_Inventory_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Phone_Manufacturer_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Phone_Place_PlaceID",
                        column: x => x.PlaceID,
                        principalTable: "Place",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Printer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Active = table.Column<bool>(nullable: false),
                    Color = table.Column<bool>(nullable: false),
                    DepartmentID = table.Column<int>(nullable: false),
                    DevicenameID = table.Column<int>(nullable: false),
                    DevicetypeID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    InventoryID = table.Column<int>(nullable: false),
                    ManufacturerID = table.Column<int>(nullable: false),
                    Network = table.Column<string>(nullable: true),
                    NetworkIpaddress = table.Column<string>(nullable: true),
                    NetworkName = table.Column<string>(nullable: true),
                    PapersizeMax = table.Column<string>(nullable: true),
                    PlaceID = table.Column<int>(nullable: false),
                    Replace = table.Column<bool>(nullable: false),
                    Resources = table.Column<string>(nullable: true),
                    Serialnumber = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Printer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Printer_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Printer_Devicename_DevicenameID",
                        column: x => x.DevicenameID,
                        principalTable: "Devicename",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Printer_Devicetype_DevicetypeID",
                        column: x => x.DevicetypeID,
                        principalTable: "Devicetype",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Printer_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Printer_Inventory_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Printer_Manufacturer_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Printer_Place_PlaceID",
                        column: x => x.PlaceID,
                        principalTable: "Place",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Computer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Active = table.Column<bool>(nullable: false),
                    DepartmentID = table.Column<int>(nullable: true),
                    DevicenameID = table.Column<int>(nullable: false),
                    DevicetypeID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    InventoryID = table.Column<int>(nullable: false),
                    ManufacturerID = table.Column<int>(nullable: false),
                    Memory = table.Column<long>(nullable: false),
                    Network = table.Column<string>(nullable: true),
                    NetworkIpaddress = table.Column<string>(nullable: true),
                    NetworkName = table.Column<string>(nullable: true),
                    OsID = table.Column<int>(nullable: false),
                    PlaceID = table.Column<int>(nullable: false),
                    PrinterID = table.Column<int>(nullable: false),
                    ProcessorID = table.Column<int>(nullable: false),
                    Replace = table.Column<bool>(nullable: false),
                    Serialnumber = table.Column<string>(nullable: true),
                    ServiceNumber = table.Column<string>(nullable: true),
                    ServiceTag = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Computer_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Computer_Devicename_DevicenameID",
                        column: x => x.DevicenameID,
                        principalTable: "Devicename",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computer_Devicetype_DevicetypeID",
                        column: x => x.DevicetypeID,
                        principalTable: "Devicetype",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computer_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computer_Inventory_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computer_Manufacturer_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computer_Os_OsID",
                        column: x => x.OsID,
                        principalTable: "Os",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computer_Place_PlaceID",
                        column: x => x.PlaceID,
                        principalTable: "Place",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computer_Printer_PrinterID",
                        column: x => x.PrinterID,
                        principalTable: "Printer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computer_Processor_ProcessorID",
                        column: x => x.ProcessorID,
                        principalTable: "Processor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fax",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Active = table.Column<bool>(nullable: false),
                    DepartmentID = table.Column<int>(nullable: false),
                    DevicenameID = table.Column<int>(nullable: false),
                    DevicetypeID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    EmployeeID1 = table.Column<int>(nullable: true),
                    InventoryID = table.Column<int>(nullable: false),
                    ManufacturerID = table.Column<int>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Pin = table.Column<string>(nullable: true),
                    PlaceID = table.Column<int>(nullable: false),
                    PrinterID = table.Column<int>(nullable: false),
                    Replace = table.Column<bool>(nullable: false),
                    Serialnumber = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fax", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Fax_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fax_Devicename_DevicenameID",
                        column: x => x.DevicenameID,
                        principalTable: "Devicename",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fax_Devicetype_DevicetypeID",
                        column: x => x.DevicetypeID,
                        principalTable: "Devicetype",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fax_Employee_EmployeeID1",
                        column: x => x.EmployeeID1,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fax_Inventory_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fax_Manufacturer_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fax_Place_PlaceID",
                        column: x => x.PlaceID,
                        principalTable: "Place",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fax_Printer_PrinterID",
                        column: x => x.PrinterID,
                        principalTable: "Printer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Software",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComputerID = table.Column<int>(nullable: true),
                    Fix = table.Column<string>(nullable: true),
                    ManufacturerID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Revision = table.Column<string>(nullable: true),
                    Timestamp = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Software", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Software_Computer_ComputerID",
                        column: x => x.ComputerID,
                        principalTable: "Computer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Software_Manufacturer_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_EmployeeID",
                table: "Account",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Account_SystemdataID",
                table: "Account",
                column: "SystemdataID");

            migrationBuilder.CreateIndex(
                name: "IX_Chipcarddoor_ChipcardID",
                table: "Chipcarddoor",
                column: "ChipcardID");

            migrationBuilder.CreateIndex(
                name: "IX_Chipcardprofile_ChipcardID",
                table: "Chipcardprofile",
                column: "ChipcardID");

            migrationBuilder.CreateIndex(
                name: "IX_Computer_DepartmentID",
                table: "Computer",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Computer_DevicenameID",
                table: "Computer",
                column: "DevicenameID");

            migrationBuilder.CreateIndex(
                name: "IX_Computer_DevicetypeID",
                table: "Computer",
                column: "DevicetypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Computer_EmployeeID",
                table: "Computer",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Computer_InventoryID",
                table: "Computer",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Computer_ManufacturerID",
                table: "Computer",
                column: "ManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Computer_OsID",
                table: "Computer",
                column: "OsID");

            migrationBuilder.CreateIndex(
                name: "IX_Computer_PlaceID",
                table: "Computer",
                column: "PlaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Computer_PrinterID",
                table: "Computer",
                column: "PrinterID");

            migrationBuilder.CreateIndex(
                name: "IX_Computer_ProcessorID",
                table: "Computer",
                column: "ProcessorID");

            migrationBuilder.CreateIndex(
                name: "IX_Department_EmployeeID",
                table: "Department",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Document_EmployeeID",
                table: "Document",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CityID1",
                table: "Employee",
                column: "CityID1");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_TitleId",
                table: "Employee",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Fax_DepartmentID",
                table: "Fax",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Fax_DevicenameID",
                table: "Fax",
                column: "DevicenameID");

            migrationBuilder.CreateIndex(
                name: "IX_Fax_DevicetypeID",
                table: "Fax",
                column: "DevicetypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Fax_EmployeeID1",
                table: "Fax",
                column: "EmployeeID1");

            migrationBuilder.CreateIndex(
                name: "IX_Fax_InventoryID",
                table: "Fax",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Fax_ManufacturerID",
                table: "Fax",
                column: "ManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Fax_PlaceID",
                table: "Fax",
                column: "PlaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Fax_PrinterID",
                table: "Fax",
                column: "PrinterID");

            migrationBuilder.CreateIndex(
                name: "IX_Function_EmployeeID",
                table: "Function",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_PlaceID",
                table: "Inventory",
                column: "PlaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Mobile_DepartmentID",
                table: "Mobile",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Mobile_DevicenameID",
                table: "Mobile",
                column: "DevicenameID");

            migrationBuilder.CreateIndex(
                name: "IX_Mobile_DevicetypeID",
                table: "Mobile",
                column: "DevicetypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Mobile_EmployeeID1",
                table: "Mobile",
                column: "EmployeeID1");

            migrationBuilder.CreateIndex(
                name: "IX_Mobile_InventoryID",
                table: "Mobile",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Mobile_ManufacturerID",
                table: "Mobile",
                column: "ManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Mobile_PlaceID",
                table: "Mobile",
                column: "PlaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Os_ManufacturerID",
                table: "Os",
                column: "ManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_DepartmentID",
                table: "Phone",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_DevicenameID",
                table: "Phone",
                column: "DevicenameID");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_DevicetypeID",
                table: "Phone",
                column: "DevicetypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_EmployeeID1",
                table: "Phone",
                column: "EmployeeID1");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_InventoryID",
                table: "Phone",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_ManufacturerID",
                table: "Phone",
                column: "ManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_PlaceID",
                table: "Phone",
                column: "PlaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Printer_DepartmentID",
                table: "Printer",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Printer_DevicenameID",
                table: "Printer",
                column: "DevicenameID");

            migrationBuilder.CreateIndex(
                name: "IX_Printer_DevicetypeID",
                table: "Printer",
                column: "DevicetypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Printer_EmployeeID",
                table: "Printer",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Printer_InventoryID",
                table: "Printer",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Printer_ManufacturerID",
                table: "Printer",
                column: "ManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Printer_PlaceID",
                table: "Printer",
                column: "PlaceID");

            migrationBuilder.CreateIndex(
                name: "IX_Software_ComputerID",
                table: "Software",
                column: "ComputerID");

            migrationBuilder.CreateIndex(
                name: "IX_Software_ManufacturerID",
                table: "Software",
                column: "ManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Systemdata_CityID",
                table: "Systemdata",
                column: "CityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Chipcarddoor");

            migrationBuilder.DropTable(
                name: "Chipcardprofile");

            migrationBuilder.DropTable(
                name: "Document");

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
                name: "Chipcard");

            migrationBuilder.DropTable(
                name: "Computer");

            migrationBuilder.DropTable(
                name: "Os");

            migrationBuilder.DropTable(
                name: "Printer");

            migrationBuilder.DropTable(
                name: "Processor");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Devicename");

            migrationBuilder.DropTable(
                name: "Devicetype");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Title");
        }
    }
}
