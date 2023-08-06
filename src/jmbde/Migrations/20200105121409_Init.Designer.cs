// <auto-generated />
using System;
using JMuelbert.BDE.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace jmbde.Migrations {
  [DbContext(typeof(BDEContext))]
  [Migration("20200105121409_Init")]
  partial class Init {
    protected override void BuildTargetModel(ModelBuilder modelBuilder) {
#pragma warning disable 612, 618
      modelBuilder.HasAnnotation("ProductVersion", "3.1.0");

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.ChipCard", b => {
        b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("INTEGER");

        b.Property<DateTime>("LastUpdate").HasColumnType("TEXT");

        b.Property<bool>("Locked").HasColumnType("INTEGER");

        b.Property<string>("Number").IsRequired().HasColumnType("TEXT").HasMaxLength(25);

        b.HasKey("ID");

        b.ToTable("ChipCard");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.ChipCardDoor", b => {
        b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("INTEGER");

        b.Property<int?>("ChipCardID").HasColumnType("INTEGER");

        b.Property<int?>("ChipCardProfileID").HasColumnType("INTEGER");

        b.Property<int?>("DepartmentID").HasColumnType("INTEGER");

        b.Property<DateTime>("LastUpdate").HasColumnType("TEXT");

        b.Property<string>("Number").IsRequired().HasColumnType("TEXT").HasMaxLength(25);

        b.Property<int?>("PlaceID").HasColumnType("INTEGER");

        b.HasKey("ID");

        b.HasIndex("ChipCardID");

        b.HasIndex("ChipCardProfileID");

        b.HasIndex("DepartmentID");

        b.HasIndex("PlaceID");

        b.ToTable("ChipCardDoor");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.ChipCardProfile", b => {
        b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("INTEGER");

        b.Property<int?>("ChipCardID").HasColumnType("INTEGER");

        b.Property<DateTime>("LastUpdate").HasColumnType("TEXT");

        b.Property<string>("Number").IsRequired().HasColumnType("TEXT").HasMaxLength(25);

        b.HasKey("ID");

        b.HasIndex("ChipCardID");

        b.ToTable("ChipCardProfile");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.CityName", b => {
        b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("INTEGER");

        b.Property<DateTime>("LastUpdate").HasColumnType("TEXT");

        b.Property<string>("Name").IsRequired().HasColumnType("TEXT").HasMaxLength(50);

        b.HasKey("ID");

        b.ToTable("CityName");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.Company", b => {
        b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("INTEGER");

        b.Property<bool>("Active").HasColumnType("INTEGER");

        b.Property<int?>("EmployeeID").HasColumnType("INTEGER");

        b.Property<string>("FaxNumber").HasColumnType("TEXT").HasMaxLength(50);

        b.Property<DateTime>("LastUpdate").HasColumnType("TEXT");

        b.Property<string>("MailAddress").HasColumnType("TEXT").HasMaxLength(50);

        b.Property<string>("MobileNumber").HasColumnType("TEXT").HasMaxLength(50);

        b.Property<string>("Name").IsRequired().HasColumnType("TEXT").HasMaxLength(50);

        b.Property<string>("Name2").HasColumnType("TEXT").HasMaxLength(50);

        b.Property<string>("PhoneNumber").HasColumnType("TEXT").HasMaxLength(50);

        b.Property<string>("Street").HasColumnType("TEXT").HasMaxLength(50);

        b.Property<int?>("ZipCodeID").HasColumnType("INTEGER");

        b.HasKey("ID");

        b.HasIndex("EmployeeID");

        b.HasIndex("ZipCodeID");

        b.ToTable("Company");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.Computer", b => {
        b.Property<string>("ComputerID").HasColumnType("TEXT").HasMaxLength(50);

        b.Property<int?>("DepartmentID").HasColumnType("INTEGER");

        b.Property<int?>("DeviceNameID").HasColumnType("INTEGER");

        b.Property<int?>("DeviceTypeID").HasColumnType("INTEGER");

        b.Property<int?>("EmployeeID").HasColumnType("INTEGER");

        b.Property<int?>("InventoryID").HasColumnType("INTEGER");

        b.Property<bool>("IsActive").HasColumnType("INTEGER");

        b.Property<DateTime>("LastUpdate").HasColumnType("TEXT");

        b.Property<int?>("ManufacturerID").HasColumnType("INTEGER");

        b.Property<long?>("Memory").HasColumnType("INTEGER");

        b.Property<string>("Network").HasColumnType("TEXT").HasMaxLength(50);

        b.Property<string>("NetworkIpAddress").HasColumnType("TEXT").HasMaxLength(50);

        b.Property<int?>("OSID").HasColumnType("INTEGER");

        b.Property<int?>("PlaceID").HasColumnType("INTEGER");

        b.Property<int?>("ProcessorID").HasColumnType("INTEGER");

        b.Property<string>("SerialNumber").HasColumnType("TEXT").HasMaxLength(20);

        b.Property<string>("ServiceNumber").HasColumnType("TEXT").HasMaxLength(20);

        b.Property<string>("ServiceTag").HasColumnType("TEXT").HasMaxLength(20);

        b.Property<bool>("ShouldReplace").HasColumnType("INTEGER");

        b.HasKey("ComputerID");

        b.HasIndex("DepartmentID");

        b.HasIndex("DeviceNameID");

        b.HasIndex("DeviceTypeID");

        b.HasIndex("EmployeeID");

        b.HasIndex("InventoryID");

        b.HasIndex("ManufacturerID");

        b.HasIndex("OSID");

        b.HasIndex("PlaceID");

        b.HasIndex("ProcessorID");

        b.ToTable("Computer");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.Department", b => {
        b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("INTEGER");

        b.Property<DateTime>("LastUpdate").HasColumnType("TEXT");

        b.Property<string>("Name").IsRequired().HasColumnType("TEXT").HasMaxLength(50);

        b.Property<long?>("Priority").HasColumnType("INTEGER");

        b.HasKey("ID");

        b.ToTable("Department");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.DeviceName", b => {
        b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("INTEGER");

        b.Property<DateTime>("LastUpdate").HasColumnType("TEXT");

        b.Property<string>("Name").IsRequired().HasColumnType("TEXT").HasMaxLength(50);

        b.HasKey("ID");

        b.ToTable("DeviceName");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.DeviceType", b => {
        b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("INTEGER");

        b.Property<DateTime>("LastUpdate").HasColumnType("TEXT");

        b.Property<string>("Name").IsRequired().HasColumnType("TEXT").HasMaxLength(50);

        b.HasKey("ID");

        b.ToTable("DeviceType");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.Document", b => {
        b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("INTEGER");

        b.Property<byte[]>("DocumentData").HasColumnType("BLOB");

        b.Property<int?>("EmployeeID").HasColumnType("INTEGER");

        b.Property<DateTime>("LastUpdate").HasColumnType("TEXT");

        b.Property<string>("Name").IsRequired().HasColumnType("TEXT").HasMaxLength(50);

        b.HasKey("ID");

        b.HasIndex("EmployeeID");

        b.ToTable("Document");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.Employee", b => {
        b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("INTEGER");

        b.Property<DateTime>("BirthDay").HasColumnType("TEXT");

        b.Property<string>("BusinessMailAddress").HasColumnType("TEXT").HasMaxLength(50);

        b.Property<int?>("ChipCardDoorID").HasColumnType("INTEGER");

        b.Property<int?>("ChipCardID").HasColumnType("INTEGER");

        b.Property<int?>("ChipCardProfileID").HasColumnType("INTEGER");

        b.Property<bool>("DataCare").HasColumnType("INTEGER");

        b.Property<int?>("DepartmentID").HasColumnType("INTEGER");

        b.Property<string>("EmployeeIdent").HasColumnType("TEXT");

        b.Property<DateTime>("EndDate").HasColumnType("TEXT");

        b.Property<int?>("FaxID").HasColumnType("INTEGER");

        b.Property<string>("FirstName").HasColumnType("TEXT").HasMaxLength(50);

        b.Property<int>("Gender").HasColumnType("INTEGER");

        b.Property<DateTime>("HireDate").HasColumnType("TEXT");

        b.Property<string>("HomeMailAddress").HasColumnType("TEXT").HasMaxLength(50);

        b.Property<string>("HomeMobile").HasColumnType("TEXT").HasMaxLength(50);

        b.Property<string>("HomePhone").HasColumnType("TEXT").HasMaxLength(50);

        b.Property<bool>("IsActive").HasColumnType("INTEGER");

        b.Property<int?>("JobTitleID").HasColumnType("INTEGER");

        b.Property<string>("LastName").IsRequired().HasColumnType("TEXT").HasMaxLength(50);

        b.Property<DateTime>("LastUpdate").HasColumnType("TEXT");

        b.Property<int?>("MobileID").HasColumnType("INTEGER");

        b.Property<string>("Notes").HasColumnType("TEXT");

        b.Property<int>("PersonID").HasColumnType("INTEGER");

        b.Property<string>("PersonIdent").HasColumnType("TEXT").HasMaxLength(50);

        b.Property<int?>("PhoneID").HasColumnType("INTEGER");

        b.Property<byte[]>("Photo").HasColumnType("BLOB");

        b.Property<string>("Street").IsRequired().HasColumnType("TEXT").HasMaxLength(50);

        b.Property<int?>("ZipCodeID").HasColumnType("INTEGER");

        b.HasKey("ID");

        b.HasIndex("ChipCardDoorID");

        b.HasIndex("ChipCardID");

        b.HasIndex("ChipCardProfileID");

        b.HasIndex("DepartmentID");

        b.HasIndex("FaxID");

        b.HasIndex("JobTitleID");

        b.HasIndex("MobileID");

        b.HasIndex("PhoneID");

        b.HasIndex("ZipCodeID");

        b.ToTable("Employee");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.Fax", b => {
        b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("INTEGER");

        b.Property<bool>("Active").HasColumnType("INTEGER");

        b.Property<int?>("DepartmentID").HasColumnType("INTEGER");

        b.Property<int?>("DeviceNameID").HasColumnType("INTEGER");

        b.Property<int?>("DeviceTypeID").HasColumnType("INTEGER");

        b.Property<int?>("InventoryID").HasColumnType("INTEGER");

        b.Property<DateTime>("LastUpdate").HasColumnType("TEXT");

        b.Property<int?>("ManufacturerID").HasColumnType("INTEGER");

        b.Property<string>("Number").IsRequired().HasColumnType("TEXT").HasMaxLength(50);

        b.Property<string>("Pin").HasColumnType("TEXT").HasMaxLength(10);

        b.Property<int?>("PlaceID").HasColumnType("INTEGER");

        b.Property<bool>("Replace").HasColumnType("INTEGER");

        b.Property<string>("SerialNumber").HasColumnType("TEXT").HasMaxLength(20);

        b.HasKey("ID");

        b.HasIndex("DepartmentID");

        b.HasIndex("DeviceNameID");

        b.HasIndex("DeviceTypeID");

        b.HasIndex("InventoryID");

        b.HasIndex("ManufacturerID");

        b.HasIndex("PlaceID");

        b.ToTable("Fax");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.Inventory", b => {
        b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("INTEGER");

        b.Property<bool>("Active").HasColumnType("INTEGER");

        b.Property<string>("Description").HasColumnType("TEXT").HasMaxLength(100);

        b.Property<string>("Identifier").IsRequired().HasColumnType("TEXT").HasMaxLength(50);

        b.Property<DateTime>("LastUpdate").HasColumnType("TEXT");

        b.HasKey("ID");

        b.ToTable("Inventory");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.JobTitle", b => {
        b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("INTEGER");

        b.Property<DateTime>("FromDate").HasColumnType("TEXT");

        b.Property<DateTime>("LastUpdate").HasColumnType("TEXT");

        b.Property<string>("Name").IsRequired().HasColumnType("TEXT").HasMaxLength(50);

        b.HasKey("ID");

        b.ToTable("JobTitle");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.Manufacturer", b => {
        b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("INTEGER");

        b.Property<string>("FaxNumber").HasColumnType("TEXT").HasMaxLength(50);

        b.Property<string>("HotlineNumber").HasColumnType("TEXT").HasMaxLength(50);

        b.Property<DateTime>("LastUpdate").HasColumnType("TEXT");

        b.Property<string>("MailAddress").HasColumnType("TEXT").HasMaxLength(50);

        b.Property<string>("Name").IsRequired().HasColumnType("TEXT").HasMaxLength(50);

        b.Property<string>("Name2").HasColumnType("TEXT").HasMaxLength(50);

        b.Property<string>("PhoneNumber").HasColumnType("TEXT").HasMaxLength(50);

        b.Property<string>("Street").HasColumnType("TEXT").HasMaxLength(50);

        b.Property<string>("Street22").HasColumnType("TEXT").HasMaxLength(50);

        b.Property<string>("Supporter").HasColumnType("TEXT").HasMaxLength(50);

        b.Property<int?>("ZipCodeID").HasColumnType("INTEGER");

        b.HasKey("ID");

        b.HasIndex("ZipCodeID");

        b.ToTable("Manufacturer");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.Mobile", b => {
        b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("INTEGER");

        b.Property<bool>("Active").HasColumnType("INTEGER");

        b.Property<string>("CardNumber").HasColumnType("TEXT").HasMaxLength(30);

        b.Property<int?>("DepartmentID").HasColumnType("INTEGER");

        b.Property<int?>("DeviceNameID").HasColumnType("INTEGER");

        b.Property<int?>("DeviceTypeID").HasColumnType("INTEGER");

        b.Property<int?>("InventoryID").HasColumnType("INTEGER");

        b.Property<DateTime>("LastUpdate").HasColumnType("TEXT");

        b.Property<int?>("ManufacturerID").HasColumnType("INTEGER");

        b.Property<string>("Number").IsRequired().HasColumnType("TEXT").HasMaxLength(50);

        b.Property<string>("Pin").HasColumnType("TEXT").HasMaxLength(10);

        b.Property<int?>("PlaceID").HasColumnType("INTEGER");

        b.Property<bool>("Replace").HasColumnType("INTEGER");

        b.Property<string>("SerialNumber").HasColumnType("TEXT").HasMaxLength(20);

        b.HasKey("ID");

        b.HasIndex("DepartmentID");

        b.HasIndex("DeviceNameID");

        b.HasIndex("DeviceTypeID");

        b.HasIndex("InventoryID");

        b.HasIndex("ManufacturerID");

        b.HasIndex("PlaceID");

        b.ToTable("Mobile");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.Phone", b => {
        b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("INTEGER");

        b.Property<bool>("Active").HasColumnType("INTEGER");

        b.Property<int?>("DepartmentID").HasColumnType("INTEGER");

        b.Property<int?>("DeviceNameID").HasColumnType("INTEGER");

        b.Property<int?>("DeviceTypeID").HasColumnType("INTEGER");

        b.Property<int?>("InventoryID").HasColumnType("INTEGER");

        b.Property<DateTime>("LastUpdate").HasColumnType("TEXT");

        b.Property<int?>("ManufacturerID").HasColumnType("INTEGER");

        b.Property<string>("Number").IsRequired().HasColumnType("TEXT").HasMaxLength(50);

        b.Property<string>("Pin").HasColumnType("TEXT").HasMaxLength(10);

        b.Property<int?>("PlaceID").HasColumnType("INTEGER");

        b.Property<bool>("Replace").HasColumnType("INTEGER");

        b.Property<string>("SerialNumber").HasColumnType("TEXT").HasMaxLength(20);

        b.HasKey("ID");

        b.HasIndex("DepartmentID");

        b.HasIndex("DeviceNameID");

        b.HasIndex("DeviceTypeID");

        b.HasIndex("InventoryID");

        b.HasIndex("ManufacturerID");

        b.HasIndex("PlaceID");

        b.ToTable("Phone");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.Place", b => {
        b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("INTEGER");

        b.Property<string>("Desk").IsRequired().HasColumnType("TEXT").HasMaxLength(50);

        b.Property<DateTime>("LastUpdate").HasColumnType("TEXT");

        b.Property<string>("Name").IsRequired().HasColumnType("TEXT").HasMaxLength(50);

        b.Property<string>("Room").IsRequired().HasColumnType("TEXT").HasMaxLength(50);

        b.HasKey("ID");

        b.ToTable("Place");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.Printer", b => {
        b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("INTEGER");

        b.Property<bool>("Active").HasColumnType("INTEGER");

        b.Property<bool>("Color").HasColumnType("INTEGER");

        b.Property<int?>("DepartmentID").HasColumnType("INTEGER");

        b.Property<int?>("DeviceNameID").HasColumnType("INTEGER");

        b.Property<int?>("DeviceTypeID").HasColumnType("INTEGER");

        b.Property<int?>("EmployeeID").HasColumnType("INTEGER");

        b.Property<int?>("InventoryID").HasColumnType("INTEGER");

        b.Property<DateTime>("LastUpdate").HasColumnType("TEXT");

        b.Property<int?>("ManufacturerID").HasColumnType("INTEGER");

        b.Property<string>("Name").IsRequired().HasColumnType("TEXT").HasMaxLength(50);

        b.Property<string>("Network").HasColumnType("TEXT").HasMaxLength(50);

        b.Property<string>("NetworkIpAddress").HasColumnType("TEXT").HasMaxLength(50);

        b.Property<int?>("PaperSize").HasColumnType("INTEGER");

        b.Property<int?>("PlaceID").HasColumnType("INTEGER");

        b.Property<bool>("Replace").HasColumnType("INTEGER");

        b.Property<string>("Resources").HasColumnType("TEXT");

        b.Property<string>("SerialNumber").HasColumnType("TEXT").HasMaxLength(20);

        b.Property<string>("ServiceNumber").HasColumnType("TEXT").HasMaxLength(20);

        b.Property<string>("ServiceTag").HasColumnType("TEXT").HasMaxLength(20);

        b.HasKey("ID");

        b.HasIndex("DepartmentID");

        b.HasIndex("DeviceNameID");

        b.HasIndex("DeviceTypeID");

        b.HasIndex("EmployeeID");

        b.HasIndex("InventoryID");

        b.HasIndex("ManufacturerID");

        b.HasIndex("PlaceID");

        b.ToTable("Printer");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.Processor", b => {
        b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("INTEGER");

        b.Property<float>("ClockRate").HasColumnType("REAL");

        b.Property<int>("Cores").HasColumnType("INTEGER");

        b.Property<DateTime>("LastUpdate").HasColumnType("TEXT");

        b.Property<string>("Name").IsRequired().HasColumnType("TEXT").HasMaxLength(50);

        b.HasKey("ID");

        b.ToTable("Processor");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.Software", b => {
        b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("INTEGER");

        b.Property<string>("ComputerID").HasColumnType("TEXT");

        b.Property<string>("Fix").HasColumnType("TEXT").HasMaxLength(25);

        b.Property<DateTime>("LastUpdate").HasColumnType("TEXT");

        b.Property<string>("Name").IsRequired().HasColumnType("TEXT").HasMaxLength(50);

        b.Property<string>("Revision").HasColumnType("TEXT").HasMaxLength(25);

        b.Property<string>("Version").HasColumnType("TEXT").HasMaxLength(25);

        b.HasKey("ID");

        b.HasIndex("ComputerID");

        b.ToTable("Software");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.SystemAccount", b => {
        b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("INTEGER");

        b.Property<int?>("EmployeeID").HasColumnType("INTEGER");

        b.Property<DateTime>("LastUpdate").HasColumnType("TEXT");

        b.Property<string>("PassWord").IsRequired().HasColumnType("TEXT").HasMaxLength(25);

        b.Property<int?>("SystemDataID").HasColumnType("INTEGER");

        b.Property<string>("UserName").IsRequired().HasColumnType("TEXT").HasMaxLength(50);

        b.HasKey("ID");

        b.HasIndex("EmployeeID");

        b.HasIndex("SystemDataID");

        b.ToTable("SystemAccount");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.SystemData", b => {
        b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("INTEGER");

        b.Property<int?>("CompanyID").HasColumnType("INTEGER");

        b.Property<DateTime>("LastUpdate").HasColumnType("TEXT");

        b.Property<bool>("Local").HasColumnType("INTEGER");

        b.Property<string>("Name").IsRequired().HasColumnType("TEXT").HasMaxLength(50);

        b.HasKey("ID");

        b.HasIndex("CompanyID");

        b.ToTable("SystemData");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.WorkFunction", b => {
        b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("INTEGER");

        b.Property<int?>("EmployeeID").HasColumnType("INTEGER");

        b.Property<DateTime>("LastUpdate").HasColumnType("TEXT");

        b.Property<string>("Name").IsRequired().HasColumnType("TEXT").HasMaxLength(50);

        b.Property<long?>("Priority").HasColumnType("INTEGER");

        b.HasKey("ID");

        b.HasIndex("EmployeeID");

        b.ToTable("WorkFunction");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.ZipCode", b => {
        b.Property<int>("ID").ValueGeneratedOnAdd().HasColumnType("INTEGER");

        b.Property<string>("Code").IsRequired().HasColumnType("TEXT").HasMaxLength(20);

        b.Property<string>("Country").HasColumnType("TEXT").HasMaxLength(20);

        b.Property<DateTime>("LastUpdate").HasColumnType("TEXT");

        b.HasKey("ID");

        b.ToTable("ZipCode");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.ChipCardDoor", b => {
        b.HasOne("JMuelbert.BDE.Shared.Models.ChipCard", null)
            .WithMany("ChipCardDoor")
            .HasForeignKey("ChipCardID");

        b.HasOne("JMuelbert.BDE.Shared.Models.ChipCardProfile", null)
            .WithMany("ChipCardDoor")
            .HasForeignKey("ChipCardProfileID");

        b.HasOne("JMuelbert.BDE.Shared.Models.Department", "Department")
            .WithMany()
            .HasForeignKey("DepartmentID");

        b.HasOne("JMuelbert.BDE.Shared.Models.Place", "Place").WithMany().HasForeignKey("PlaceID");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.ChipCardProfile", b => {
        b.HasOne("JMuelbert.BDE.Shared.Models.ChipCard", null)
            .WithMany("ChipCardProfile")
            .HasForeignKey("ChipCardID");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.Company", b => {
        b.HasOne("JMuelbert.BDE.Shared.Models.Employee", "Employee")
            .WithMany()
            .HasForeignKey("EmployeeID");

        b.HasOne("JMuelbert.BDE.Shared.Models.ZipCode", "ZipCode")
            .WithMany()
            .HasForeignKey("ZipCodeID");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.Computer", b => {
        b.HasOne("JMuelbert.BDE.Shared.Models.Department", "Department")
            .WithMany()
            .HasForeignKey("DepartmentID");

        b.HasOne("JMuelbert.BDE.Shared.Models.DeviceName", "DeviceName")
            .WithMany()
            .HasForeignKey("DeviceNameID");

        b.HasOne("JMuelbert.BDE.Shared.Models.DeviceType", "DeviceType")
            .WithMany()
            .HasForeignKey("DeviceTypeID");

        b.HasOne("JMuelbert.BDE.Shared.Models.Employee", null)
            .WithMany("Computer")
            .HasForeignKey("EmployeeID");

        b.HasOne("JMuelbert.BDE.Shared.Models.Inventory", "Inventory")
            .WithMany()
            .HasForeignKey("InventoryID");

        b.HasOne("JMuelbert.BDE.Shared.Models.Manufacturer", "Manufacturer")
            .WithMany()
            .HasForeignKey("ManufacturerID");

        b.HasOne("JMuelbert.BDE.Shared.Models.Software", "OS").WithMany().HasForeignKey("OSID");

        b.HasOne("JMuelbert.BDE.Shared.Models.Place", "Place").WithMany().HasForeignKey("PlaceID");

        b.HasOne("JMuelbert.BDE.Shared.Models.Processor", "Processor")
            .WithMany()
            .HasForeignKey("ProcessorID");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.Document", b => {
        b.HasOne("JMuelbert.BDE.Shared.Models.Employee", null)
            .WithMany("Document")
            .HasForeignKey("EmployeeID");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.Employee", b => {
        b.HasOne("JMuelbert.BDE.Shared.Models.ChipCardDoor", null)
            .WithMany("Employee")
            .HasForeignKey("ChipCardDoorID");

        b.HasOne("JMuelbert.BDE.Shared.Models.ChipCard", "ChipCard")
            .WithMany("Employee")
            .HasForeignKey("ChipCardID");

        b.HasOne("JMuelbert.BDE.Shared.Models.ChipCardProfile", null)
            .WithMany("Employee")
            .HasForeignKey("ChipCardProfileID");

        b.HasOne("JMuelbert.BDE.Shared.Models.Department", "Department")
            .WithMany()
            .HasForeignKey("DepartmentID");

        b.HasOne("JMuelbert.BDE.Shared.Models.Fax", "Fax")
            .WithMany("Employee")
            .HasForeignKey("FaxID");

        b.HasOne("JMuelbert.BDE.Shared.Models.JobTitle", "JobTitle")
            .WithMany()
            .HasForeignKey("JobTitleID");

        b.HasOne("JMuelbert.BDE.Shared.Models.Mobile", "Mobile")
            .WithMany()
            .HasForeignKey("MobileID");

        b.HasOne("JMuelbert.BDE.Shared.Models.Phone", "Phone").WithMany().HasForeignKey("PhoneID");

        b.HasOne("JMuelbert.BDE.Shared.Models.ZipCode", "ZipCode")
            .WithMany()
            .HasForeignKey("ZipCodeID");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.Fax", b => {
        b.HasOne("JMuelbert.BDE.Shared.Models.Department", "Department")
            .WithMany("Fax")
            .HasForeignKey("DepartmentID");

        b.HasOne("JMuelbert.BDE.Shared.Models.DeviceName", "DeviceName")
            .WithMany()
            .HasForeignKey("DeviceNameID");

        b.HasOne("JMuelbert.BDE.Shared.Models.DeviceType", "DeviceType")
            .WithMany()
            .HasForeignKey("DeviceTypeID");

        b.HasOne("JMuelbert.BDE.Shared.Models.Inventory", "Inventory")
            .WithMany()
            .HasForeignKey("InventoryID");

        b.HasOne("JMuelbert.BDE.Shared.Models.Manufacturer", "Manufacturer")
            .WithMany()
            .HasForeignKey("ManufacturerID");

        b.HasOne("JMuelbert.BDE.Shared.Models.Place", "Place").WithMany().HasForeignKey("PlaceID");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.Manufacturer", b => {
        b.HasOne("JMuelbert.BDE.Shared.Models.ZipCode", "ZipCode")
            .WithMany()
            .HasForeignKey("ZipCodeID");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.Mobile", b => {
        b.HasOne("JMuelbert.BDE.Shared.Models.Department", "Department")
            .WithMany()
            .HasForeignKey("DepartmentID");

        b.HasOne("JMuelbert.BDE.Shared.Models.DeviceName", "DeviceName")
            .WithMany()
            .HasForeignKey("DeviceNameID");

        b.HasOne("JMuelbert.BDE.Shared.Models.DeviceType", "DeviceType")
            .WithMany()
            .HasForeignKey("DeviceTypeID");

        b.HasOne("JMuelbert.BDE.Shared.Models.Inventory", "Inventory")
            .WithMany()
            .HasForeignKey("InventoryID");

        b.HasOne("JMuelbert.BDE.Shared.Models.Manufacturer", "Manufacturer")
            .WithMany()
            .HasForeignKey("ManufacturerID");

        b.HasOne("JMuelbert.BDE.Shared.Models.Place", "Place").WithMany().HasForeignKey("PlaceID");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.Phone", b => {
        b.HasOne("JMuelbert.BDE.Shared.Models.Department", "Department")
            .WithMany()
            .HasForeignKey("DepartmentID");

        b.HasOne("JMuelbert.BDE.Shared.Models.DeviceName", "DeviceName")
            .WithMany()
            .HasForeignKey("DeviceNameID");

        b.HasOne("JMuelbert.BDE.Shared.Models.DeviceType", "DeviceType")
            .WithMany()
            .HasForeignKey("DeviceTypeID");

        b.HasOne("JMuelbert.BDE.Shared.Models.Inventory", "Inventory")
            .WithMany()
            .HasForeignKey("InventoryID");

        b.HasOne("JMuelbert.BDE.Shared.Models.Manufacturer", "Manufacturer")
            .WithMany()
            .HasForeignKey("ManufacturerID");

        b.HasOne("JMuelbert.BDE.Shared.Models.Place", "Place").WithMany().HasForeignKey("PlaceID");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.Printer", b => {
        b.HasOne("JMuelbert.BDE.Shared.Models.Department", "Department")
            .WithMany("Printer")
            .HasForeignKey("DepartmentID");

        b.HasOne("JMuelbert.BDE.Shared.Models.DeviceName", "DeviceName")
            .WithMany()
            .HasForeignKey("DeviceNameID");

        b.HasOne("JMuelbert.BDE.Shared.Models.DeviceType", "DeviceType")
            .WithMany()
            .HasForeignKey("DeviceTypeID");

        b.HasOne("JMuelbert.BDE.Shared.Models.Employee", "Employee")
            .WithMany("Printer")
            .HasForeignKey("EmployeeID");

        b.HasOne("JMuelbert.BDE.Shared.Models.Inventory", "Inventory")
            .WithMany()
            .HasForeignKey("InventoryID");

        b.HasOne("JMuelbert.BDE.Shared.Models.Manufacturer", "Manufacturer")
            .WithMany()
            .HasForeignKey("ManufacturerID");

        b.HasOne("JMuelbert.BDE.Shared.Models.Place", "Place").WithMany().HasForeignKey("PlaceID");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.Software", b => {
        b.HasOne("JMuelbert.BDE.Shared.Models.Computer", null)
            .WithMany("Software")
            .HasForeignKey("ComputerID");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.SystemAccount", b => {
        b.HasOne("JMuelbert.BDE.Shared.Models.Employee", null)
            .WithMany("SystemAccount")
            .HasForeignKey("EmployeeID");

        b.HasOne("JMuelbert.BDE.Shared.Models.SystemData", "SystemData")
            .WithMany()
            .HasForeignKey("SystemDataID");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.SystemData", b => {
        b.HasOne("JMuelbert.BDE.Shared.Models.Company", "Company")
            .WithMany()
            .HasForeignKey("CompanyID");
      });

      modelBuilder.Entity("JMuelbert.BDE.Shared.Models.WorkFunction", b => {
        b.HasOne("JMuelbert.BDE.Shared.Models.Employee", null)
            .WithMany("WorkFunction")
            .HasForeignKey("EmployeeID");
      });
#pragma warning restore 612, 618
    }
  }
}
