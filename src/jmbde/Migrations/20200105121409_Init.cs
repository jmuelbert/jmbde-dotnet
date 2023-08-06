/****************************************************************
 *
 ** SPDX-FileCopyrightText: 2016-2023 Jürgen Mülbert
 ** Copyright (c) 2016-2023 Jürgen Mülbert. All rights reserved.
 ** SPDX-License-Identifier: EUPL-1.2
 **
 ******************************************************************/

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace jmbde.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChipCard",
                columns: table =>
                    new
                    {
                        ID =
                              table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                        Number = table.Column<string>(maxLength: 25, nullable: false),
                        Locked = table.Column<bool>(nullable: false),
                        LastUpdate = table.Column<DateTime>(nullable: false)
                    },
                constraints: table => { table.PrimaryKey("PK_ChipCard", x => x.ID); });

            migrationBuilder.CreateTable(
                name: "CityName",
                columns: table =>
                    new
                    {
                        ID =
                              table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                        Name = table.Column<string>(maxLength: 50, nullable: false),
                        LastUpdate = table.Column<DateTime>(nullable: false)
                    },
                constraints: table => { table.PrimaryKey("PK_CityName", x => x.ID); });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table =>
                    new
                    {
                        ID =
                              table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                        Name = table.Column<string>(maxLength: 50, nullable: false),
                        Priority = table.Column<long>(nullable: true),
                        LastUpdate = table.Column<DateTime>(nullable: false)
                    },
                constraints: table => { table.PrimaryKey("PK_Department", x => x.ID); });

            migrationBuilder.CreateTable(
                name: "DeviceName",
                columns: table =>
                    new
                    {
                        ID =
                              table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                        Name = table.Column<string>(maxLength: 50, nullable: false),
                        LastUpdate = table.Column<DateTime>(nullable: false)
                    },
                constraints: table => { table.PrimaryKey("PK_DeviceName", x => x.ID); });

            migrationBuilder.CreateTable(
                name: "DeviceType",
                columns: table =>
                    new
                    {
                        ID =
                              table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                        Name = table.Column<string>(maxLength: 50, nullable: false),
                        LastUpdate = table.Column<DateTime>(nullable: false)
                    },
                constraints: table => { table.PrimaryKey("PK_DeviceType", x => x.ID); });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table =>
                    new
                    {
                        ID =
                              table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                        Identifier = table.Column<string>(maxLength: 50, nullable: false),
                        Description = table.Column<string>(maxLength: 100, nullable: true),
                        Active = table.Column<bool>(nullable: false),
                        LastUpdate = table.Column<DateTime>(nullable: false)
                    },
                constraints: table => { table.PrimaryKey("PK_Inventory", x => x.ID); });

            migrationBuilder.CreateTable(
                name: "JobTitle",
                columns: table =>
                    new
                    {
                        ID =
                              table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                        Name = table.Column<string>(maxLength: 50, nullable: false),
                        FromDate = table.Column<DateTime>(nullable: false),
                        LastUpdate = table.Column<DateTime>(nullable: false)
                    },
                constraints: table => { table.PrimaryKey("PK_JobTitle", x => x.ID); });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table =>
                    new
                    {
                        ID =
                              table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                        Name = table.Column<string>(maxLength: 50, nullable: false),
                        Room = table.Column<string>(maxLength: 50, nullable: false),
                        Desk = table.Column<string>(maxLength: 50, nullable: false),
                        LastUpdate = table.Column<DateTime>(nullable: false)
                    },
                constraints: table => { table.PrimaryKey("PK_Place", x => x.ID); });

            migrationBuilder.CreateTable(
                name: "Processor",
                columns: table =>
                    new
                    {
                        ID =
                              table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                        Name = table.Column<string>(maxLength: 50, nullable: false),
                        ClockRate = table.Column<float>(nullable: false),
                        Cores = table.Column<int>(nullable: false),
                        LastUpdate = table.Column<DateTime>(nullable: false)
                    },
                constraints: table => { table.PrimaryKey("PK_Processor", x => x.ID); });

            migrationBuilder.CreateTable(
                name: "ZipCode",
                columns: table =>
                    new
                    {
                        ID =
                              table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                        Code = table.Column<string>(maxLength: 20, nullable: false),
                        Country = table.Column<string>(maxLength: 20, nullable: true),
                        LastUpdate = table.Column<DateTime>(nullable: false)
                    },
                constraints: table => { table.PrimaryKey("PK_ZipCode", x => x.ID); });

            migrationBuilder.CreateTable(
                name: "ChipCardProfile",
                columns: table =>
                    new
                    {
                        ID =
                              table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                        Number = table.Column<string>(maxLength: 25, nullable: false),
                        LastUpdate = table.Column<DateTime>(nullable: false),
                        ChipCardID = table.Column<int>(nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChipCardProfile", x => x.ID);
                    table.ForeignKey(name: "FK_ChipCardProfile_ChipCard_ChipCardID",
                               column: x => x.ChipCardID, principalTable: "ChipCard",
                               principalColumn: "ID", onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table =>
                    new
                    {
                        ID =
                              table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                        Name = table.Column<string>(maxLength: 50, nullable: false),
                        Name2 = table.Column<string>(maxLength: 50, nullable: true),
                        Supporter = table.Column<string>(maxLength: 50, nullable: true),
                        Street = table.Column<string>(maxLength: 50, nullable: true),
                        Street22 = table.Column<string>(maxLength: 50, nullable: true),
                        ZipCodeID = table.Column<int>(nullable: true),
                        MailAddress = table.Column<string>(maxLength: 50, nullable: true),
                        PhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                        FaxNumber = table.Column<string>(maxLength: 50, nullable: true),
                        HotlineNumber = table.Column<string>(maxLength: 50, nullable: true),
                        LastUpdate = table.Column<DateTime>(nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.ID);
                    table.ForeignKey(name: "FK_Manufacturer_ZipCode_ZipCodeID", column: x => x.ZipCodeID,
                               principalTable: "ZipCode", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChipCardDoor",
                columns: table =>
                    new
                    {
                        ID =
                              table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                        Number = table.Column<string>(maxLength: 25, nullable: false),
                        PlaceID = table.Column<int>(nullable: true),
                        DepartmentID = table.Column<int>(nullable: true),
                        LastUpdate = table.Column<DateTime>(nullable: false),
                        ChipCardID = table.Column<int>(nullable: true),
                        ChipCardProfileID = table.Column<int>(nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChipCardDoor", x => x.ID);
                    table.ForeignKey(name: "FK_ChipCardDoor_ChipCard_ChipCardID", column: x => x.ChipCardID,
                               principalTable: "ChipCard", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_ChipCardDoor_ChipCardProfile_ChipCardProfileID",
                               column: x => x.ChipCardProfileID, principalTable: "ChipCardProfile",
                               principalColumn: "ID", onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_ChipCardDoor_Department_DepartmentID",
                               column: x => x.DepartmentID, principalTable: "Department",
                               principalColumn: "ID", onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_ChipCardDoor_Place_PlaceID", column: x => x.PlaceID,
                               principalTable: "Place", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fax",
                columns: table =>
                    new
                    {
                        ID =
                              table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                        Number = table.Column<string>(maxLength: 50, nullable: false),
                        SerialNumber = table.Column<string>(maxLength: 20, nullable: true),
                        Pin = table.Column<string>(maxLength: 10, nullable: true),
                        Active = table.Column<bool>(nullable: false),
                        Replace = table.Column<bool>(nullable: false),
                        DeviceNameID = table.Column<int>(nullable: true),
                        DeviceTypeID = table.Column<int>(nullable: true),
                        PlaceID = table.Column<int>(nullable: true),
                        DepartmentID = table.Column<int>(nullable: true),
                        ManufacturerID = table.Column<int>(nullable: true),
                        InventoryID = table.Column<int>(nullable: true),
                        LastUpdate = table.Column<DateTime>(nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fax", x => x.ID);
                    table.ForeignKey(name: "FK_Fax_Department_DepartmentID", column: x => x.DepartmentID,
                               principalTable: "Department", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Fax_DeviceName_DeviceNameID", column: x => x.DeviceNameID,
                               principalTable: "DeviceName", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Fax_DeviceType_DeviceTypeID", column: x => x.DeviceTypeID,
                               principalTable: "DeviceType", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Fax_Inventory_InventoryID", column: x => x.InventoryID,
                               principalTable: "Inventory", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Fax_Manufacturer_ManufacturerID",
                               column: x => x.ManufacturerID, principalTable: "Manufacturer",
                               principalColumn: "ID", onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Fax_Place_PlaceID", column: x => x.PlaceID,
                               principalTable: "Place", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mobile",
                columns: table =>
                    new
                    {
                        ID =
                              table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                        Number = table.Column<string>(maxLength: 50, nullable: false),
                        SerialNumber = table.Column<string>(maxLength: 20, nullable: true),
                        Pin = table.Column<string>(maxLength: 10, nullable: true),
                        CardNumber = table.Column<string>(maxLength: 30, nullable: true),
                        Active = table.Column<bool>(nullable: false),
                        Replace = table.Column<bool>(nullable: false),
                        DeviceNameID = table.Column<int>(nullable: true),
                        DeviceTypeID = table.Column<int>(nullable: true),
                        PlaceID = table.Column<int>(nullable: true),
                        DepartmentID = table.Column<int>(nullable: true),
                        ManufacturerID = table.Column<int>(nullable: true),
                        InventoryID = table.Column<int>(nullable: true),
                        LastUpdate = table.Column<DateTime>(nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobile", x => x.ID);
                    table.ForeignKey(name: "FK_Mobile_Department_DepartmentID", column: x => x.DepartmentID,
                               principalTable: "Department", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Mobile_DeviceName_DeviceNameID", column: x => x.DeviceNameID,
                               principalTable: "DeviceName", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Mobile_DeviceType_DeviceTypeID", column: x => x.DeviceTypeID,
                               principalTable: "DeviceType", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Mobile_Inventory_InventoryID", column: x => x.InventoryID,
                               principalTable: "Inventory", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Mobile_Manufacturer_ManufacturerID",
                               column: x => x.ManufacturerID, principalTable: "Manufacturer",
                               principalColumn: "ID", onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Mobile_Place_PlaceID", column: x => x.PlaceID,
                               principalTable: "Place", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table =>
                    new
                    {
                        ID =
                              table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                        Number = table.Column<string>(maxLength: 50, nullable: false),
                        SerialNumber = table.Column<string>(maxLength: 20, nullable: true),
                        Pin = table.Column<string>(maxLength: 10, nullable: true),
                        Active = table.Column<bool>(nullable: false),
                        Replace = table.Column<bool>(nullable: false),
                        DeviceNameID = table.Column<int>(nullable: true),
                        DeviceTypeID = table.Column<int>(nullable: true),
                        PlaceID = table.Column<int>(nullable: true),
                        DepartmentID = table.Column<int>(nullable: true),
                        ManufacturerID = table.Column<int>(nullable: true),
                        InventoryID = table.Column<int>(nullable: true),
                        LastUpdate = table.Column<DateTime>(nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.ID);
                    table.ForeignKey(name: "FK_Phone_Department_DepartmentID", column: x => x.DepartmentID,
                               principalTable: "Department", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Phone_DeviceName_DeviceNameID", column: x => x.DeviceNameID,
                               principalTable: "DeviceName", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Phone_DeviceType_DeviceTypeID", column: x => x.DeviceTypeID,
                               principalTable: "DeviceType", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Phone_Inventory_InventoryID", column: x => x.InventoryID,
                               principalTable: "Inventory", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Phone_Manufacturer_ManufacturerID",
                               column: x => x.ManufacturerID, principalTable: "Manufacturer",
                               principalColumn: "ID", onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Phone_Place_PlaceID", column: x => x.PlaceID,
                               principalTable: "Place", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table =>
                    new
                    {
                        ID =
                              table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                        PersonID = table.Column<int>(nullable: false),
                        PersonIdent = table.Column<string>(maxLength: 50, nullable: true),
                        Gender = table.Column<int>(nullable: false),
                        FirstName = table.Column<string>(maxLength: 50, nullable: true),
                        LastName = table.Column<string>(maxLength: 50, nullable: false),
                        BirthDay = table.Column<DateTime>(nullable: false),
                        Street = table.Column<string>(maxLength: 50, nullable: false),
                        ZipCodeID = table.Column<int>(nullable: true),
                        HomePhone = table.Column<string>(maxLength: 50, nullable: true),
                        HomeMobile = table.Column<string>(maxLength: 50, nullable: true),
                        HomeMailAddress = table.Column<string>(maxLength: 50, nullable: true),
                        Photo = table.Column<byte[]>(nullable: true),
                        EmployeeIdent = table.Column<string>(nullable: true),
                        JobTitleID = table.Column<int>(nullable: true),
                        BusinessMailAddress = table.Column<string>(maxLength: 50, nullable: true),
                        DataCare = table.Column<bool>(nullable: false),
                        IsActive = table.Column<bool>(nullable: false),
                        Notes = table.Column<string>(nullable: true),
                        HireDate = table.Column<DateTime>(nullable: false),
                        EndDate = table.Column<DateTime>(nullable: false),
                        DepartmentID = table.Column<int>(nullable: true),
                        PhoneID = table.Column<int>(nullable: true),
                        MobileID = table.Column<int>(nullable: true),
                        FaxID = table.Column<int>(nullable: true),
                        ChipCardID = table.Column<int>(nullable: true),
                        LastUpdate = table.Column<DateTime>(nullable: false),
                        ChipCardDoorID = table.Column<int>(nullable: true),
                        ChipCardProfileID = table.Column<int>(nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID);
                    table.ForeignKey(name: "FK_Employee_ChipCardDoor_ChipCardDoorID",
                               column: x => x.ChipCardDoorID, principalTable: "ChipCardDoor",
                               principalColumn: "ID", onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Employee_ChipCard_ChipCardID", column: x => x.ChipCardID,
                               principalTable: "ChipCard", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Employee_ChipCardProfile_ChipCardProfileID",
                               column: x => x.ChipCardProfileID, principalTable: "ChipCardProfile",
                               principalColumn: "ID", onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Employee_Department_DepartmentID",
                               column: x => x.DepartmentID, principalTable: "Department",
                               principalColumn: "ID", onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Employee_Fax_FaxID", column: x => x.FaxID,
                               principalTable: "Fax", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Employee_JobTitle_JobTitleID", column: x => x.JobTitleID,
                               principalTable: "JobTitle", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Employee_Mobile_MobileID", column: x => x.MobileID,
                               principalTable: "Mobile", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Employee_Phone_PhoneID", column: x => x.PhoneID,
                               principalTable: "Phone", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Employee_ZipCode_ZipCodeID", column: x => x.ZipCodeID,
                               principalTable: "ZipCode", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table =>
                    new
                    {
                        ID =
                              table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                        Name = table.Column<string>(maxLength: 50, nullable: false),
                        Name2 = table.Column<string>(maxLength: 50, nullable: true),
                        Street = table.Column<string>(maxLength: 50, nullable: true),
                        ZipCodeID = table.Column<int>(nullable: true),
                        PhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                        FaxNumber = table.Column<string>(maxLength: 50, nullable: true),
                        MobileNumber = table.Column<string>(maxLength: 50, nullable: true),
                        MailAddress = table.Column<string>(maxLength: 50, nullable: true),
                        Active = table.Column<bool>(nullable: false),
                        EmployeeID = table.Column<int>(nullable: true),
                        LastUpdate = table.Column<DateTime>(nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.ID);
                    table.ForeignKey(name: "FK_Company_Employee_EmployeeID", column: x => x.EmployeeID,
                               principalTable: "Employee", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Company_ZipCode_ZipCodeID", column: x => x.ZipCodeID,
                               principalTable: "ZipCode", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table =>
                    new
                    {
                        ID =
                              table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                        Name = table.Column<string>(maxLength: 50, nullable: false),
                        DocumentData = table.Column<byte[]>(nullable: true),
                        LastUpdate = table.Column<DateTime>(nullable: false),
                        EmployeeID = table.Column<int>(nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.ID);
                    table.ForeignKey(name: "FK_Document_Employee_EmployeeID", column: x => x.EmployeeID,
                               principalTable: "Employee", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Printer",
                columns: table =>
                    new
                    {
                        ID =
                              table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                        Name = table.Column<string>(maxLength: 50, nullable: false),
                        SerialNumber = table.Column<string>(maxLength: 20, nullable: true),
                        ServiceTag = table.Column<string>(maxLength: 20, nullable: true),
                        ServiceNumber = table.Column<string>(maxLength: 20, nullable: true),
                        Network = table.Column<string>(maxLength: 50, nullable: true),
                        NetworkIpAddress = table.Column<string>(maxLength: 50, nullable: true),
                        Active = table.Column<bool>(nullable: false),
                        Replace = table.Column<bool>(nullable: false),
                        Resources = table.Column<string>(nullable: true),
                        PaperSize = table.Column<int>(nullable: true),
                        Color = table.Column<bool>(nullable: false),
                        DeviceNameID = table.Column<int>(nullable: true),
                        DeviceTypeID = table.Column<int>(nullable: true),
                        EmployeeID = table.Column<int>(nullable: true),
                        PlaceID = table.Column<int>(nullable: true),
                        DepartmentID = table.Column<int>(nullable: true),
                        ManufacturerID = table.Column<int>(nullable: true),
                        InventoryID = table.Column<int>(nullable: true),
                        LastUpdate = table.Column<DateTime>(nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Printer", x => x.ID);
                    table.ForeignKey(name: "FK_Printer_Department_DepartmentID",
                               column: x => x.DepartmentID, principalTable: "Department",
                               principalColumn: "ID", onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Printer_DeviceName_DeviceNameID",
                               column: x => x.DeviceNameID, principalTable: "DeviceName",
                               principalColumn: "ID", onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Printer_DeviceType_DeviceTypeID",
                               column: x => x.DeviceTypeID, principalTable: "DeviceType",
                               principalColumn: "ID", onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Printer_Employee_EmployeeID", column: x => x.EmployeeID,
                               principalTable: "Employee", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Printer_Inventory_InventoryID", column: x => x.InventoryID,
                               principalTable: "Inventory", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Printer_Manufacturer_ManufacturerID",
                               column: x => x.ManufacturerID, principalTable: "Manufacturer",
                               principalColumn: "ID", onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Printer_Place_PlaceID", column: x => x.PlaceID,
                               principalTable: "Place", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkFunction",
                columns: table =>
                    new
                    {
                        ID =
                              table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                        Name = table.Column<string>(maxLength: 50, nullable: false),
                        Priority = table.Column<long>(nullable: true),
                        LastUpdate = table.Column<DateTime>(nullable: false),
                        EmployeeID = table.Column<int>(nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFunction", x => x.ID);
                    table.ForeignKey(name: "FK_WorkFunction_Employee_EmployeeID", column: x => x.EmployeeID,
                               principalTable: "Employee", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SystemData",
                columns: table =>
                    new
                    {
                        ID =
                              table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                        Name = table.Column<string>(maxLength: 50, nullable: false),
                        Local = table.Column<bool>(nullable: false),
                        CompanyID = table.Column<int>(nullable: true),
                        LastUpdate = table.Column<DateTime>(nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemData", x => x.ID);
                    table.ForeignKey(name: "FK_SystemData_Company_CompanyID", column: x => x.CompanyID,
                               principalTable: "Company", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SystemAccount",
                columns: table =>
                    new
                    {
                        ID =
                              table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                        UserName = table.Column<string>(maxLength: 50, nullable: false),
                        PassWord = table.Column<string>(maxLength: 25, nullable: false),
                        SystemDataID = table.Column<int>(nullable: true),
                        LastUpdate = table.Column<DateTime>(nullable: false),
                        EmployeeID = table.Column<int>(nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemAccount", x => x.ID);
                    table.ForeignKey(name: "FK_SystemAccount_Employee_EmployeeID",
                               column: x => x.EmployeeID, principalTable: "Employee",
                               principalColumn: "ID", onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_SystemAccount_SystemData_SystemDataID",
                               column: x => x.SystemDataID, principalTable: "SystemData",
                               principalColumn: "ID", onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Software",
                columns: table =>
                    new
                    {
                        ID =
                              table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                        Name = table.Column<string>(maxLength: 50, nullable: false),
                        Version = table.Column<string>(maxLength: 25, nullable: true),
                        Revision = table.Column<string>(maxLength: 25, nullable: true),
                        Fix = table.Column<string>(maxLength: 25, nullable: true),
                        LastUpdate = table.Column<DateTime>(nullable: false),
                        ComputerID = table.Column<string>(nullable: true)
                    },
                constraints: table => { table.PrimaryKey("PK_Software", x => x.ID); });

            migrationBuilder.CreateTable(
                name: "Computer",
                columns: table =>
                    new
                    {
                        ComputerID = table.Column<string>(maxLength: 50, nullable: false),
                        SerialNumber = table.Column<string>(maxLength: 20, nullable: true),
                        ServiceTag = table.Column<string>(maxLength: 20, nullable: true),
                        ServiceNumber = table.Column<string>(maxLength: 20, nullable: true),
                        Memory = table.Column<long>(nullable: true),
                        Network = table.Column<string>(maxLength: 50, nullable: true),
                        NetworkIpAddress = table.Column<string>(maxLength: 50, nullable: true),
                        IsActive = table.Column<bool>(nullable: false),
                        ShouldReplace = table.Column<bool>(nullable: false),
                        DeviceNameID = table.Column<int>(nullable: true),
                        DeviceTypeID = table.Column<int>(nullable: true),
                        PlaceID = table.Column<int>(nullable: true),
                        DepartmentID = table.Column<int>(nullable: true),
                        ManufacturerID = table.Column<int>(nullable: true),
                        InventoryID = table.Column<int>(nullable: true),
                        ProcessorID = table.Column<int>(nullable: true),
                        OSID = table.Column<int>(nullable: true),
                        LastUpdate = table.Column<DateTime>(nullable: false),
                        EmployeeID = table.Column<int>(nullable: true)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computer", x => x.ComputerID);
                    table.ForeignKey(name: "FK_Computer_Department_DepartmentID",
                               column: x => x.DepartmentID, principalTable: "Department",
                               principalColumn: "ID", onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Computer_DeviceName_DeviceNameID",
                               column: x => x.DeviceNameID, principalTable: "DeviceName",
                               principalColumn: "ID", onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Computer_DeviceType_DeviceTypeID",
                               column: x => x.DeviceTypeID, principalTable: "DeviceType",
                               principalColumn: "ID", onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Computer_Employee_EmployeeID", column: x => x.EmployeeID,
                               principalTable: "Employee", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Computer_Inventory_InventoryID", column: x => x.InventoryID,
                               principalTable: "Inventory", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Computer_Manufacturer_ManufacturerID",
                               column: x => x.ManufacturerID, principalTable: "Manufacturer",
                               principalColumn: "ID", onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Computer_Software_OSID", column: x => x.OSID,
                               principalTable: "Software", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Computer_Place_PlaceID", column: x => x.PlaceID,
                               principalTable: "Place", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(name: "FK_Computer_Processor_ProcessorID", column: x => x.ProcessorID,
                               principalTable: "Processor", principalColumn: "ID",
                               onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(name: "IX_ChipCardDoor_ChipCardID", table: "ChipCardDoor",
                                         column: "ChipCardID");

            migrationBuilder.CreateIndex(name: "IX_ChipCardDoor_ChipCardProfileID", table: "ChipCardDoor",
                                         column: "ChipCardProfileID");

            migrationBuilder.CreateIndex(name: "IX_ChipCardDoor_DepartmentID", table: "ChipCardDoor",
                                         column: "DepartmentID");

            migrationBuilder.CreateIndex(name: "IX_ChipCardDoor_PlaceID", table: "ChipCardDoor",
                                         column: "PlaceID");

            migrationBuilder.CreateIndex(name: "IX_ChipCardProfile_ChipCardID", table: "ChipCardProfile",
                                         column: "ChipCardID");

            migrationBuilder.CreateIndex(name: "IX_Company_EmployeeID", table: "Company",
                                         column: "EmployeeID");

            migrationBuilder.CreateIndex(name: "IX_Company_ZipCodeID", table: "Company",
                                         column: "ZipCodeID");

            migrationBuilder.CreateIndex(name: "IX_Computer_DepartmentID", table: "Computer",
                                         column: "DepartmentID");

            migrationBuilder.CreateIndex(name: "IX_Computer_DeviceNameID", table: "Computer",
                                         column: "DeviceNameID");

            migrationBuilder.CreateIndex(name: "IX_Computer_DeviceTypeID", table: "Computer",
                                         column: "DeviceTypeID");

            migrationBuilder.CreateIndex(name: "IX_Computer_EmployeeID", table: "Computer",
                                         column: "EmployeeID");

            migrationBuilder.CreateIndex(name: "IX_Computer_InventoryID", table: "Computer",
                                         column: "InventoryID");

            migrationBuilder.CreateIndex(name: "IX_Computer_ManufacturerID", table: "Computer",
                                         column: "ManufacturerID");

            migrationBuilder.CreateIndex(name: "IX_Computer_OSID", table: "Computer", column: "OSID");

            migrationBuilder.CreateIndex(name: "IX_Computer_PlaceID", table: "Computer",
                                         column: "PlaceID");

            migrationBuilder.CreateIndex(name: "IX_Computer_ProcessorID", table: "Computer",
                                         column: "ProcessorID");

            migrationBuilder.CreateIndex(name: "IX_Document_EmployeeID", table: "Document",
                                         column: "EmployeeID");

            migrationBuilder.CreateIndex(name: "IX_Employee_ChipCardDoorID", table: "Employee",
                                         column: "ChipCardDoorID");

            migrationBuilder.CreateIndex(name: "IX_Employee_ChipCardID", table: "Employee",
                                         column: "ChipCardID");

            migrationBuilder.CreateIndex(name: "IX_Employee_ChipCardProfileID", table: "Employee",
                                         column: "ChipCardProfileID");

            migrationBuilder.CreateIndex(name: "IX_Employee_DepartmentID", table: "Employee",
                                         column: "DepartmentID");

            migrationBuilder.CreateIndex(name: "IX_Employee_FaxID", table: "Employee", column: "FaxID");

            migrationBuilder.CreateIndex(name: "IX_Employee_JobTitleID", table: "Employee",
                                         column: "JobTitleID");

            migrationBuilder.CreateIndex(name: "IX_Employee_MobileID", table: "Employee",
                                         column: "MobileID");

            migrationBuilder.CreateIndex(name: "IX_Employee_PhoneID", table: "Employee",
                                         column: "PhoneID");

            migrationBuilder.CreateIndex(name: "IX_Employee_ZipCodeID", table: "Employee",
                                         column: "ZipCodeID");

            migrationBuilder.CreateIndex(name: "IX_Fax_DepartmentID", table: "Fax",
                                         column: "DepartmentID");

            migrationBuilder.CreateIndex(name: "IX_Fax_DeviceNameID", table: "Fax",
                                         column: "DeviceNameID");

            migrationBuilder.CreateIndex(name: "IX_Fax_DeviceTypeID", table: "Fax",
                                         column: "DeviceTypeID");

            migrationBuilder.CreateIndex(name: "IX_Fax_InventoryID", table: "Fax", column: "InventoryID");

            migrationBuilder.CreateIndex(name: "IX_Fax_ManufacturerID", table: "Fax",
                                         column: "ManufacturerID");

            migrationBuilder.CreateIndex(name: "IX_Fax_PlaceID", table: "Fax", column: "PlaceID");

            migrationBuilder.CreateIndex(name: "IX_Manufacturer_ZipCodeID", table: "Manufacturer",
                                         column: "ZipCodeID");

            migrationBuilder.CreateIndex(name: "IX_Mobile_DepartmentID", table: "Mobile",
                                         column: "DepartmentID");

            migrationBuilder.CreateIndex(name: "IX_Mobile_DeviceNameID", table: "Mobile",
                                         column: "DeviceNameID");

            migrationBuilder.CreateIndex(name: "IX_Mobile_DeviceTypeID", table: "Mobile",
                                         column: "DeviceTypeID");

            migrationBuilder.CreateIndex(name: "IX_Mobile_InventoryID", table: "Mobile",
                                         column: "InventoryID");

            migrationBuilder.CreateIndex(name: "IX_Mobile_ManufacturerID", table: "Mobile",
                                         column: "ManufacturerID");

            migrationBuilder.CreateIndex(name: "IX_Mobile_PlaceID", table: "Mobile", column: "PlaceID");

            migrationBuilder.CreateIndex(name: "IX_Phone_DepartmentID", table: "Phone",
                                         column: "DepartmentID");

            migrationBuilder.CreateIndex(name: "IX_Phone_DeviceNameID", table: "Phone",
                                         column: "DeviceNameID");

            migrationBuilder.CreateIndex(name: "IX_Phone_DeviceTypeID", table: "Phone",
                                         column: "DeviceTypeID");

            migrationBuilder.CreateIndex(name: "IX_Phone_InventoryID", table: "Phone",
                                         column: "InventoryID");

            migrationBuilder.CreateIndex(name: "IX_Phone_ManufacturerID", table: "Phone",
                                         column: "ManufacturerID");

            migrationBuilder.CreateIndex(name: "IX_Phone_PlaceID", table: "Phone", column: "PlaceID");

            migrationBuilder.CreateIndex(name: "IX_Printer_DepartmentID", table: "Printer",
                                         column: "DepartmentID");

            migrationBuilder.CreateIndex(name: "IX_Printer_DeviceNameID", table: "Printer",
                                         column: "DeviceNameID");

            migrationBuilder.CreateIndex(name: "IX_Printer_DeviceTypeID", table: "Printer",
                                         column: "DeviceTypeID");

            migrationBuilder.CreateIndex(name: "IX_Printer_EmployeeID", table: "Printer",
                                         column: "EmployeeID");

            migrationBuilder.CreateIndex(name: "IX_Printer_InventoryID", table: "Printer",
                                         column: "InventoryID");

            migrationBuilder.CreateIndex(name: "IX_Printer_ManufacturerID", table: "Printer",
                                         column: "ManufacturerID");

            migrationBuilder.CreateIndex(name: "IX_Printer_PlaceID", table: "Printer", column: "PlaceID");

            migrationBuilder.CreateIndex(name: "IX_Software_ComputerID", table: "Software",
                                         column: "ComputerID");

            migrationBuilder.CreateIndex(name: "IX_SystemAccount_EmployeeID", table: "SystemAccount",
                                         column: "EmployeeID");

            migrationBuilder.CreateIndex(name: "IX_SystemAccount_SystemDataID", table: "SystemAccount",
                                         column: "SystemDataID");

            migrationBuilder.CreateIndex(name: "IX_SystemData_CompanyID", table: "SystemData",
                                         column: "CompanyID");

            migrationBuilder.CreateIndex(name: "IX_WorkFunction_EmployeeID", table: "WorkFunction",
                                         column: "EmployeeID");

            migrationBuilder.AddForeignKey(name: "FK_Software_Computer_ComputerID", table: "Software",
                                           column: "ComputerID", principalTable: "Computer",
                                           principalColumn: "ComputerID",
                                           onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_ChipCardDoor_ChipCard_ChipCardID",
                                            table: "ChipCardDoor");

            migrationBuilder.DropForeignKey(name: "FK_ChipCardProfile_ChipCard_ChipCardID",
                                            table: "ChipCardProfile");

            migrationBuilder.DropForeignKey(name: "FK_Employee_ChipCard_ChipCardID", table: "Employee");

            migrationBuilder.DropForeignKey(name: "FK_ChipCardDoor_ChipCardProfile_ChipCardProfileID",
                                            table: "ChipCardDoor");

            migrationBuilder.DropForeignKey(name: "FK_Employee_ChipCardProfile_ChipCardProfileID",
                                            table: "Employee");

            migrationBuilder.DropForeignKey(name: "FK_ChipCardDoor_Department_DepartmentID",
                                            table: "ChipCardDoor");

            migrationBuilder.DropForeignKey(name: "FK_Computer_Department_DepartmentID",
                                            table: "Computer");

            migrationBuilder.DropForeignKey(name: "FK_Employee_Department_DepartmentID",
                                            table: "Employee");

            migrationBuilder.DropForeignKey(name: "FK_Fax_Department_DepartmentID", table: "Fax");

            migrationBuilder.DropForeignKey(name: "FK_Mobile_Department_DepartmentID", table: "Mobile");

            migrationBuilder.DropForeignKey(name: "FK_Phone_Department_DepartmentID", table: "Phone");

            migrationBuilder.DropForeignKey(name: "FK_ChipCardDoor_Place_PlaceID", table: "ChipCardDoor");

            migrationBuilder.DropForeignKey(name: "FK_Computer_Place_PlaceID", table: "Computer");

            migrationBuilder.DropForeignKey(name: "FK_Fax_Place_PlaceID", table: "Fax");

            migrationBuilder.DropForeignKey(name: "FK_Mobile_Place_PlaceID", table: "Mobile");

            migrationBuilder.DropForeignKey(name: "FK_Phone_Place_PlaceID", table: "Phone");

            migrationBuilder.DropForeignKey(name: "FK_Computer_Employee_EmployeeID", table: "Computer");

            migrationBuilder.DropForeignKey(name: "FK_Manufacturer_ZipCode_ZipCodeID",
                                            table: "Manufacturer");

            migrationBuilder.DropForeignKey(name: "FK_Computer_DeviceName_DeviceNameID",
                                            table: "Computer");

            migrationBuilder.DropForeignKey(name: "FK_Computer_DeviceType_DeviceTypeID",
                                            table: "Computer");

            migrationBuilder.DropForeignKey(name: "FK_Computer_Inventory_InventoryID", table: "Computer");

            migrationBuilder.DropForeignKey(name: "FK_Computer_Manufacturer_ManufacturerID",
                                            table: "Computer");

            migrationBuilder.DropForeignKey(name: "FK_Computer_Software_OSID", table: "Computer");

            migrationBuilder.DropTable(name: "CityName");

            migrationBuilder.DropTable(name: "Document");

            migrationBuilder.DropTable(name: "Printer");

            migrationBuilder.DropTable(name: "SystemAccount");

            migrationBuilder.DropTable(name: "WorkFunction");

            migrationBuilder.DropTable(name: "SystemData");

            migrationBuilder.DropTable(name: "Company");

            migrationBuilder.DropTable(name: "ChipCard");

            migrationBuilder.DropTable(name: "ChipCardProfile");

            migrationBuilder.DropTable(name: "Department");

            migrationBuilder.DropTable(name: "Place");

            migrationBuilder.DropTable(name: "Employee");

            migrationBuilder.DropTable(name: "ChipCardDoor");

            migrationBuilder.DropTable(name: "Fax");

            migrationBuilder.DropTable(name: "JobTitle");

            migrationBuilder.DropTable(name: "Mobile");

            migrationBuilder.DropTable(name: "Phone");

            migrationBuilder.DropTable(name: "ZipCode");

            migrationBuilder.DropTable(name: "DeviceName");

            migrationBuilder.DropTable(name: "DeviceType");

            migrationBuilder.DropTable(name: "Inventory");

            migrationBuilder.DropTable(name: "Manufacturer");

            migrationBuilder.DropTable(name: "Software");

            migrationBuilder.DropTable(name: "Computer");

            migrationBuilder.DropTable(name: "Processor");
        }
    }
}