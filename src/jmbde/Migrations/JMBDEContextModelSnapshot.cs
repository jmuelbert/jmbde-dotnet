﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using jmbde.Data;

namespace jmbde.Migrations
{
    [DbContext(typeof(JMBDEContext))]
    partial class JMBDEContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932");

            modelBuilder.Entity("jmbdeData.Models.ChipCard", b =>
                {
                    b.Property<long>("ChipCardId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastUpdate");

                    b.Property<bool>("Locked");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("ChipCardId");

                    b.ToTable("ChipCard");
                });

            modelBuilder.Entity("jmbdeData.Models.ChipCardDoor", b =>
                {
                    b.Property<long>("ChipCardDoorId")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ChipCardId");

                    b.Property<long?>("ChipCardProfileId");

                    b.Property<long?>("DepartmentId");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<long?>("PlaceId");

                    b.HasKey("ChipCardDoorId");

                    b.HasIndex("ChipCardId");

                    b.HasIndex("ChipCardProfileId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("PlaceId");

                    b.ToTable("ChipCardDoor");
                });

            modelBuilder.Entity("jmbdeData.Models.ChipCardProfile", b =>
                {
                    b.Property<long>("ChipCardProfileId")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ChipCardId");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("ChipCardProfileId");

                    b.HasIndex("ChipCardId");

                    b.ToTable("ChipCardProfile");
                });

            modelBuilder.Entity("jmbdeData.Models.CityName", b =>
                {
                    b.Property<long>("CityNameId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("CityNameId");

                    b.ToTable("CityName");
                });

            modelBuilder.Entity("jmbdeData.Models.Company", b =>
                {
                    b.Property<long>("CompanyId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<long?>("EmployeeId");

                    b.Property<string>("FaxNumber")
                        .HasMaxLength(50);

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("MailAddress")
                        .HasMaxLength(50);

                    b.Property<string>("MobileNumber")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Name2")
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50);

                    b.Property<string>("Street")
                        .HasMaxLength(50);

                    b.Property<long?>("ZipCodeId");

                    b.HasKey("CompanyId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ZipCodeId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("jmbdeData.Models.Computer", b =>
                {
                    b.Property<long>("ComputerId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<long?>("DepartmentId");

                    b.Property<long?>("DeviceNameId");

                    b.Property<long?>("DeviceTypeId");

                    b.Property<long?>("EmployeeId");

                    b.Property<long?>("InventoryId");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<long?>("ManufacturerId");

                    b.Property<long?>("Memory");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Network")
                        .HasMaxLength(50);

                    b.Property<string>("NetworkIpAddress")
                        .HasMaxLength(50);

                    b.Property<long?>("OSSoftwareId");

                    b.Property<long?>("PlaceId");

                    b.Property<long?>("ProcessorId");

                    b.Property<bool>("Replace");

                    b.Property<string>("SerialNumber")
                        .HasMaxLength(20);

                    b.Property<string>("ServiceNumber")
                        .HasMaxLength(20);

                    b.Property<string>("ServiceTag")
                        .HasMaxLength(20);

                    b.HasKey("ComputerId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DeviceNameId");

                    b.HasIndex("DeviceTypeId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("InventoryId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("OSSoftwareId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("ProcessorId");

                    b.ToTable("Computer");
                });

            modelBuilder.Entity("jmbdeData.Models.Department", b =>
                {
                    b.Property<long>("DepartmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<long?>("Priority");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("jmbdeData.Models.DeviceName", b =>
                {
                    b.Property<long>("DeviceNameId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("DeviceNameId");

                    b.ToTable("DeviceName");
                });

            modelBuilder.Entity("jmbdeData.Models.DeviceType", b =>
                {
                    b.Property<long>("DeviceTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("DeviceTypeId");

                    b.ToTable("DeviceType");
                });

            modelBuilder.Entity("jmbdeData.Models.Document", b =>
                {
                    b.Property<long>("DocumentId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("DocumentData");

                    b.Property<long?>("EmployeeId");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("DocumentId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("jmbdeData.Models.Employee", b =>
                {
                    b.Property<long>("EmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("BirthDay");

                    b.Property<string>("BusinessMailAddress")
                        .HasMaxLength(50);

                    b.Property<long?>("ChipCardDoorId");

                    b.Property<long?>("ChipCardId");

                    b.Property<long?>("ChipCardProfileId");

                    b.Property<bool>("DataCare");

                    b.Property<long?>("DepartmentId");

                    b.Property<string>("EmployeeIdent");

                    b.Property<DateTime>("EndDate");

                    b.Property<long?>("FaxId");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<int>("Gender");

                    b.Property<DateTime>("HireDate");

                    b.Property<string>("HomeMailAddress")
                        .HasMaxLength(50);

                    b.Property<string>("HomeMobile")
                        .HasMaxLength(50);

                    b.Property<string>("HomePhone")
                        .HasMaxLength(50);

                    b.Property<long?>("JobTitleId");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("LastUpdate");

                    b.Property<long?>("MobileId");

                    b.Property<string>("Notes");

                    b.Property<long?>("PhoneId");

                    b.Property<byte[]>("Photo");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<long?>("ZipCodeId");

                    b.HasKey("EmployeeId");

                    b.HasIndex("ChipCardDoorId");

                    b.HasIndex("ChipCardId");

                    b.HasIndex("ChipCardProfileId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("FaxId");

                    b.HasIndex("JobTitleId");

                    b.HasIndex("MobileId");

                    b.HasIndex("PhoneId");

                    b.HasIndex("ZipCodeId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("jmbdeData.Models.Fax", b =>
                {
                    b.Property<long>("FaxId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<long?>("DepartmentId");

                    b.Property<long?>("DeviceNameId");

                    b.Property<long?>("DeviceTypeId");

                    b.Property<long?>("InventoryId");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<long?>("ManufacturerId");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Pin")
                        .HasMaxLength(10);

                    b.Property<long?>("PlaceId");

                    b.Property<bool>("Replace");

                    b.Property<string>("SerialNumber")
                        .HasMaxLength(20);

                    b.HasKey("FaxId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DeviceNameId");

                    b.HasIndex("DeviceTypeId");

                    b.HasIndex("InventoryId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Fax");
                });

            modelBuilder.Entity("jmbdeData.Models.Function", b =>
                {
                    b.Property<long>("FunctionId")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("EmployeeId");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<long?>("Priority");

                    b.HasKey("FunctionId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Function");
                });

            modelBuilder.Entity("jmbdeData.Models.Inventory", b =>
                {
                    b.Property<long>("InventoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Description")
                        .HasMaxLength(100);

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("LastUpdate");

                    b.HasKey("InventoryId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("jmbdeData.Models.JobTitle", b =>
                {
                    b.Property<long>("JobTitleId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("FromDate");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("JobTitleId");

                    b.ToTable("JobTitle");
                });

            modelBuilder.Entity("jmbdeData.Models.Manufacturer", b =>
                {
                    b.Property<long>("ManufacturerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FaxNumber")
                        .HasMaxLength(50);

                    b.Property<string>("HotlineNumber")
                        .HasMaxLength(50);

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("MailAddress")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Name2")
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50);

                    b.Property<string>("Street")
                        .HasMaxLength(50);

                    b.Property<string>("Street22")
                        .HasMaxLength(50);

                    b.Property<string>("Supporter")
                        .HasMaxLength(50);

                    b.Property<long?>("ZipCodeId");

                    b.HasKey("ManufacturerId");

                    b.HasIndex("ZipCodeId");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("jmbdeData.Models.Mobile", b =>
                {
                    b.Property<long>("MobileId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("CardNumber")
                        .HasMaxLength(30);

                    b.Property<long?>("DepartmentId");

                    b.Property<long?>("DeviceNameId");

                    b.Property<long?>("DeviceTypeId");

                    b.Property<long?>("InventoryId");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<long?>("ManufacturerId");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Pin")
                        .HasMaxLength(10);

                    b.Property<long?>("PlaceId");

                    b.Property<bool>("Replace");

                    b.Property<string>("SerialNumber")
                        .HasMaxLength(20);

                    b.HasKey("MobileId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DeviceNameId");

                    b.HasIndex("DeviceTypeId");

                    b.HasIndex("InventoryId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Mobile");
                });

            modelBuilder.Entity("jmbdeData.Models.Phone", b =>
                {
                    b.Property<long>("PhoneId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<long?>("DepartmentId");

                    b.Property<long?>("DeviceNameId");

                    b.Property<long?>("DeviceTypeId");

                    b.Property<long?>("InventoryId");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<long?>("ManufacturerId");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Pin")
                        .HasMaxLength(10);

                    b.Property<long?>("PlaceId");

                    b.Property<bool>("Replace");

                    b.Property<string>("SerialNumber")
                        .HasMaxLength(20);

                    b.HasKey("PhoneId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DeviceNameId");

                    b.HasIndex("DeviceTypeId");

                    b.HasIndex("InventoryId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("jmbdeData.Models.Place", b =>
                {
                    b.Property<long>("PlaceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Desk")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Room")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("PlaceId");

                    b.ToTable("Place");
                });

            modelBuilder.Entity("jmbdeData.Models.Printer", b =>
                {
                    b.Property<long>("PrinterId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<bool>("Color");

                    b.Property<long?>("DepartmentId");

                    b.Property<long?>("DeviceNameId");

                    b.Property<long?>("DeviceTypeId");

                    b.Property<long?>("EmployeeId");

                    b.Property<long?>("InventoryId");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<long?>("ManufacturerId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Network")
                        .HasMaxLength(50);

                    b.Property<string>("NetworkIpAddress")
                        .HasMaxLength(50);

                    b.Property<int?>("PaperSize");

                    b.Property<long?>("PlaceId");

                    b.Property<bool>("Replace");

                    b.Property<string>("Resources");

                    b.Property<string>("SerialNumber")
                        .HasMaxLength(20);

                    b.Property<string>("ServiceNumber")
                        .HasMaxLength(20);

                    b.Property<string>("ServiceTag")
                        .HasMaxLength(20);

                    b.HasKey("PrinterId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DeviceNameId");

                    b.HasIndex("DeviceTypeId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("InventoryId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Printer");
                });

            modelBuilder.Entity("jmbdeData.Models.Processor", b =>
                {
                    b.Property<long>("ProcessorId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("ClockRate");

                    b.Property<int>("Cores");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ProcessorId");

                    b.ToTable("Processor");
                });

            modelBuilder.Entity("jmbdeData.Models.Software", b =>
                {
                    b.Property<long>("SoftwareId")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ComputerId");

                    b.Property<string>("Fix")
                        .HasMaxLength(25);

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Revision")
                        .HasMaxLength(25);

                    b.Property<string>("Version")
                        .HasMaxLength(25);

                    b.HasKey("SoftwareId");

                    b.HasIndex("ComputerId");

                    b.ToTable("Software");
                });

            modelBuilder.Entity("jmbdeData.Models.SystemAccount", b =>
                {
                    b.Property<long>("SystemAccountId")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("EmployeeId");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<long?>("SystemDataId");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("SystemAccountId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("SystemDataId");

                    b.ToTable("SystemAccount");
                });

            modelBuilder.Entity("jmbdeData.Models.SystemData", b =>
                {
                    b.Property<long>("SystemDataId")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("CompanyId");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<bool>("Local");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("SystemDataId");

                    b.HasIndex("CompanyId");

                    b.ToTable("SystemData");
                });

            modelBuilder.Entity("jmbdeData.Models.ZipCode", b =>
                {
                    b.Property<long>("ZipCodeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Country")
                        .HasMaxLength(20);

                    b.Property<DateTime>("LastUpdate");

                    b.HasKey("ZipCodeId");

                    b.ToTable("ZipCode");
                });

            modelBuilder.Entity("jmbdeData.Models.ChipCardDoor", b =>
                {
                    b.HasOne("jmbdeData.Models.ChipCard")
                        .WithMany("ChipCardDoor")
                        .HasForeignKey("ChipCardId");

                    b.HasOne("jmbdeData.Models.ChipCardProfile")
                        .WithMany("ChipCardDoor")
                        .HasForeignKey("ChipCardProfileId");

                    b.HasOne("jmbdeData.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("jmbdeData.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId");
                });

            modelBuilder.Entity("jmbdeData.Models.ChipCardProfile", b =>
                {
                    b.HasOne("jmbdeData.Models.ChipCard")
                        .WithMany("ChipCardProfile")
                        .HasForeignKey("ChipCardId");
                });

            modelBuilder.Entity("jmbdeData.Models.Company", b =>
                {
                    b.HasOne("jmbdeData.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("jmbdeData.Models.ZipCode", "ZipCode")
                        .WithMany()
                        .HasForeignKey("ZipCodeId");
                });

            modelBuilder.Entity("jmbdeData.Models.Computer", b =>
                {
                    b.HasOne("jmbdeData.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("jmbdeData.Models.DeviceName", "DeviceName")
                        .WithMany()
                        .HasForeignKey("DeviceNameId");

                    b.HasOne("jmbdeData.Models.DeviceType", "DeviceType")
                        .WithMany()
                        .HasForeignKey("DeviceTypeId");

                    b.HasOne("jmbdeData.Models.Employee")
                        .WithMany("Computer")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("jmbdeData.Models.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId");

                    b.HasOne("jmbdeData.Models.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId");

                    b.HasOne("jmbdeData.Models.Software", "OS")
                        .WithMany()
                        .HasForeignKey("OSSoftwareId");

                    b.HasOne("jmbdeData.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId");

                    b.HasOne("jmbdeData.Models.Processor", "Processor")
                        .WithMany()
                        .HasForeignKey("ProcessorId");
                });

            modelBuilder.Entity("jmbdeData.Models.Document", b =>
                {
                    b.HasOne("jmbdeData.Models.Employee")
                        .WithMany("Document")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("jmbdeData.Models.Employee", b =>
                {
                    b.HasOne("jmbdeData.Models.ChipCardDoor")
                        .WithMany("Employee")
                        .HasForeignKey("ChipCardDoorId");

                    b.HasOne("jmbdeData.Models.ChipCard", "ChipCard")
                        .WithMany("Employee")
                        .HasForeignKey("ChipCardId");

                    b.HasOne("jmbdeData.Models.ChipCardProfile")
                        .WithMany("Employee")
                        .HasForeignKey("ChipCardProfileId");

                    b.HasOne("jmbdeData.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("jmbdeData.Models.Fax", "Fax")
                        .WithMany("Employee")
                        .HasForeignKey("FaxId");

                    b.HasOne("jmbdeData.Models.JobTitle", "JobTitle")
                        .WithMany()
                        .HasForeignKey("JobTitleId");

                    b.HasOne("jmbdeData.Models.Mobile", "Mobile")
                        .WithMany()
                        .HasForeignKey("MobileId");

                    b.HasOne("jmbdeData.Models.Phone", "Phone")
                        .WithMany()
                        .HasForeignKey("PhoneId");

                    b.HasOne("jmbdeData.Models.ZipCode", "ZipCode")
                        .WithMany()
                        .HasForeignKey("ZipCodeId");
                });

            modelBuilder.Entity("jmbdeData.Models.Fax", b =>
                {
                    b.HasOne("jmbdeData.Models.Department", "Department")
                        .WithMany("Fax")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("jmbdeData.Models.DeviceName", "DeviceName")
                        .WithMany()
                        .HasForeignKey("DeviceNameId");

                    b.HasOne("jmbdeData.Models.DeviceType", "DeviceType")
                        .WithMany()
                        .HasForeignKey("DeviceTypeId");

                    b.HasOne("jmbdeData.Models.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId");

                    b.HasOne("jmbdeData.Models.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId");

                    b.HasOne("jmbdeData.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId");
                });

            modelBuilder.Entity("jmbdeData.Models.Function", b =>
                {
                    b.HasOne("jmbdeData.Models.Employee")
                        .WithMany("Function")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("jmbdeData.Models.Manufacturer", b =>
                {
                    b.HasOne("jmbdeData.Models.ZipCode", "ZipCode")
                        .WithMany()
                        .HasForeignKey("ZipCodeId");
                });

            modelBuilder.Entity("jmbdeData.Models.Mobile", b =>
                {
                    b.HasOne("jmbdeData.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("jmbdeData.Models.DeviceName", "DeviceName")
                        .WithMany()
                        .HasForeignKey("DeviceNameId");

                    b.HasOne("jmbdeData.Models.DeviceType", "DeviceType")
                        .WithMany()
                        .HasForeignKey("DeviceTypeId");

                    b.HasOne("jmbdeData.Models.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId");

                    b.HasOne("jmbdeData.Models.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId");

                    b.HasOne("jmbdeData.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId");
                });

            modelBuilder.Entity("jmbdeData.Models.Phone", b =>
                {
                    b.HasOne("jmbdeData.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("jmbdeData.Models.DeviceName", "DeviceName")
                        .WithMany()
                        .HasForeignKey("DeviceNameId");

                    b.HasOne("jmbdeData.Models.DeviceType", "DeviceType")
                        .WithMany()
                        .HasForeignKey("DeviceTypeId");

                    b.HasOne("jmbdeData.Models.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId");

                    b.HasOne("jmbdeData.Models.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId");

                    b.HasOne("jmbdeData.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId");
                });

            modelBuilder.Entity("jmbdeData.Models.Printer", b =>
                {
                    b.HasOne("jmbdeData.Models.Department", "Department")
                        .WithMany("Printer")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("jmbdeData.Models.DeviceName", "DeviceName")
                        .WithMany()
                        .HasForeignKey("DeviceNameId");

                    b.HasOne("jmbdeData.Models.DeviceType", "DeviceType")
                        .WithMany()
                        .HasForeignKey("DeviceTypeId");

                    b.HasOne("jmbdeData.Models.Employee", "Employee")
                        .WithMany("Printer")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("jmbdeData.Models.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId");

                    b.HasOne("jmbdeData.Models.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId");

                    b.HasOne("jmbdeData.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId");
                });

            modelBuilder.Entity("jmbdeData.Models.Software", b =>
                {
                    b.HasOne("jmbdeData.Models.Computer")
                        .WithMany("Software")
                        .HasForeignKey("ComputerId");
                });

            modelBuilder.Entity("jmbdeData.Models.SystemAccount", b =>
                {
                    b.HasOne("jmbdeData.Models.Employee")
                        .WithMany("SystemAccount")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("jmbdeData.Models.SystemData", "SystemData")
                        .WithMany()
                        .HasForeignKey("SystemDataId");
                });

            modelBuilder.Entity("jmbdeData.Models.SystemData", b =>
                {
                    b.HasOne("jmbdeData.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");
                });
#pragma warning restore 612, 618
        }
    }
}
