using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using jmbde.Data;

namespace jmbde.Migrations
{
    [DbContext(typeof(jmbdesqliteContext))]
    [Migration("20170605133757_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("jmbde.Models.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EmployeeID");

                    b.Property<string>("Password")
                        .HasMaxLength(30);

                    b.Property<int>("SystemdataID");

                    b.Property<string>("Timestamp");

                    b.Property<string>("Username")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("SystemdataID");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("jmbde.Models.Chipcard", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int>("EmployeeID");

                    b.Property<string>("Number");

                    b.Property<string>("Timestamp");

                    b.HasKey("ID");

                    b.ToTable("Chipcard");
                });

            modelBuilder.Entity("jmbde.Models.Chipcarddoor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ChipcardID");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("ChipcardID");

                    b.ToTable("Chipcarddoor");
                });

            modelBuilder.Entity("jmbde.Models.Chipcardprofile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ChipcardID");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("ChipcardID");

                    b.ToTable("Chipcardprofile");
                });

            modelBuilder.Entity("jmbde.Models.City", b =>
                {
                    b.Property<int>("ID");

                    b.Property<string>("Name");

                    b.Property<string>("Timestamp");

                    b.HasKey("ID");

                    b.ToTable("City");
                });

            modelBuilder.Entity("jmbde.Models.Computer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int?>("DepartmentID");

                    b.Property<int>("DevicenameID");

                    b.Property<int>("DevicetypeID");

                    b.Property<int>("EmployeeID");

                    b.Property<int>("InventoryID");

                    b.Property<int>("ManufacturerID");

                    b.Property<long>("Memory");

                    b.Property<string>("Network");

                    b.Property<string>("NetworkIpaddress");

                    b.Property<string>("NetworkName");

                    b.Property<int>("OsID");

                    b.Property<int>("PlaceID");

                    b.Property<int>("PrinterID");

                    b.Property<int>("ProcessorID");

                    b.Property<bool>("Replace");

                    b.Property<string>("Serialnumber");

                    b.Property<string>("ServiceNumber");

                    b.Property<string>("ServiceTag");

                    b.Property<string>("Timestamp");

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("DevicenameID");

                    b.HasIndex("DevicetypeID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("InventoryID");

                    b.HasIndex("ManufacturerID");

                    b.HasIndex("OsID");

                    b.HasIndex("PlaceID");

                    b.HasIndex("PrinterID");

                    b.HasIndex("ProcessorID");

                    b.ToTable("Computer");
                });

            modelBuilder.Entity("jmbde.Models.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EmployeeID");

                    b.Property<string>("Name");

                    b.Property<int?>("Prio");

                    b.Property<string>("Timestamp");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("jmbde.Models.Devicename", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Timestamp");

                    b.HasKey("ID");

                    b.ToTable("Devicename");
                });

            modelBuilder.Entity("jmbde.Models.Devicetype", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Timestamp");

                    b.HasKey("ID");

                    b.ToTable("Devicetype");
                });

            modelBuilder.Entity("jmbde.Models.Document", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EmployeeID");

                    b.Property<byte[]>("MyDocument");

                    b.Property<string>("Name");

                    b.Property<string>("Timestamp");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("jmbde.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Address")
                        .HasMaxLength(50);

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Businessemail");

                    b.Property<int>("ChipcardID");

                    b.Property<string>("CityID");

                    b.Property<int?>("CityID1");

                    b.Property<bool>("Datacare");

                    b.Property<string>("Enddate");

                    b.Property<int>("FaxID");

                    b.Property<string>("Firstname")
                        .HasMaxLength(50);

                    b.Property<int?>("Gender");

                    b.Property<string>("Homeemail");

                    b.Property<string>("Homemobile");

                    b.Property<string>("Homephone");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("MiddleName")
                        .HasMaxLength(20);

                    b.Property<int>("MobileID");

                    b.Property<string>("Notes");

                    b.Property<string>("Nr");

                    b.Property<int>("PhoneID");

                    b.Property<byte[]>("Photo");

                    b.Property<string>("Startdate");

                    b.Property<string>("Timestamp");

                    b.Property<int>("TitleId");

                    b.HasKey("ID");

                    b.HasIndex("CityID1");

                    b.HasIndex("TitleId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("jmbde.Models.Fax", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int>("DepartmentID");

                    b.Property<int>("DevicenameID");

                    b.Property<int>("DevicetypeID");

                    b.Property<int>("EmployeeID");

                    b.Property<int?>("EmployeeID1");

                    b.Property<int>("InventoryID");

                    b.Property<int>("ManufacturerID");

                    b.Property<string>("Number");

                    b.Property<string>("Pin");

                    b.Property<int>("PlaceID");

                    b.Property<int>("PrinterID");

                    b.Property<bool>("Replace");

                    b.Property<string>("Serialnumber");

                    b.Property<string>("Timestamp");

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("DevicenameID");

                    b.HasIndex("DevicetypeID");

                    b.HasIndex("EmployeeID1");

                    b.HasIndex("InventoryID");

                    b.HasIndex("ManufacturerID");

                    b.HasIndex("PlaceID");

                    b.HasIndex("PrinterID");

                    b.ToTable("Fax");
                });

            modelBuilder.Entity("jmbde.Models.Function", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeID");

                    b.Property<string>("Name");

                    b.Property<int?>("Prio");

                    b.Property<string>("Timestamp");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Function");
                });

            modelBuilder.Entity("jmbde.Models.Inventory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Number");

                    b.Property<int>("PlaceID");

                    b.Property<string>("Text");

                    b.Property<string>("Timestamp");

                    b.HasKey("ID");

                    b.HasIndex("PlaceID");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("jmbde.Models.Manufacturer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Address2");

                    b.Property<string>("CityId");

                    b.Property<string>("Email");

                    b.Property<string>("Fax");

                    b.Property<string>("Hotline");

                    b.Property<string>("Name");

                    b.Property<string>("Name2");

                    b.Property<string>("Phone");

                    b.Property<string>("Supporter");

                    b.Property<string>("Timestamp");

                    b.HasKey("ID");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("jmbde.Models.Mobile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Activatedate");

                    b.Property<bool>("Active");

                    b.Property<string>("Cardnumber");

                    b.Property<int>("DepartmentID");

                    b.Property<int>("DevicenameID");

                    b.Property<int>("DevicetypeID");

                    b.Property<int>("EmployeeID");

                    b.Property<int?>("EmployeeID1");

                    b.Property<int>("InventoryID");

                    b.Property<int>("ManufacturerID");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Pin");

                    b.Property<int>("PlaceID");

                    b.Property<bool>("Replace");

                    b.Property<string>("Serialnumber");

                    b.Property<string>("Timestamp");

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("DevicenameID");

                    b.HasIndex("DevicetypeID");

                    b.HasIndex("EmployeeID1");

                    b.HasIndex("InventoryID");

                    b.HasIndex("ManufacturerID");

                    b.HasIndex("PlaceID");

                    b.ToTable("Mobile");
                });

            modelBuilder.Entity("jmbde.Models.Os", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Fix");

                    b.Property<int>("ManufacturerID");

                    b.Property<string>("Name");

                    b.Property<string>("Revision");

                    b.Property<string>("Timestamp");

                    b.Property<string>("Version");

                    b.HasKey("ID");

                    b.HasIndex("ManufacturerID");

                    b.ToTable("Os");
                });

            modelBuilder.Entity("jmbde.Models.Phone", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int>("DepartmentID");

                    b.Property<int>("DevicenameID");

                    b.Property<int>("DevicetypeID");

                    b.Property<int>("EmployeeID");

                    b.Property<int?>("EmployeeID1");

                    b.Property<int>("InventoryID");

                    b.Property<int>("ManufacturerID");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Pin");

                    b.Property<int>("PlaceID");

                    b.Property<bool>("Replace");

                    b.Property<string>("Serialnumber");

                    b.Property<string>("Timestamp");

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("DevicenameID");

                    b.HasIndex("DevicetypeID");

                    b.HasIndex("EmployeeID1");

                    b.HasIndex("InventoryID");

                    b.HasIndex("ManufacturerID");

                    b.HasIndex("PlaceID");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("jmbde.Models.Place", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Desk");

                    b.Property<string>("Name");

                    b.Property<string>("Room");

                    b.Property<string>("Timestamp");

                    b.HasKey("ID");

                    b.ToTable("Place");
                });

            modelBuilder.Entity("jmbde.Models.Printer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<bool>("Color");

                    b.Property<int>("DepartmentID");

                    b.Property<int>("DevicenameID");

                    b.Property<int>("DevicetypeID");

                    b.Property<int>("EmployeeID");

                    b.Property<int>("InventoryID");

                    b.Property<int>("ManufacturerID");

                    b.Property<string>("Network");

                    b.Property<string>("NetworkIpaddress");

                    b.Property<string>("NetworkName");

                    b.Property<string>("PapersizeMax");

                    b.Property<int>("PlaceID");

                    b.Property<bool>("Replace");

                    b.Property<string>("Resources");

                    b.Property<string>("Serialnumber");

                    b.Property<string>("Timestamp");

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("DevicenameID");

                    b.HasIndex("DevicetypeID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("InventoryID");

                    b.HasIndex("ManufacturerID");

                    b.HasIndex("PlaceID");

                    b.ToTable("Printer");
                });

            modelBuilder.Entity("jmbde.Models.Processor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Cores");

                    b.Property<float>("Ghz");

                    b.Property<string>("Name");

                    b.Property<string>("Timestamp");

                    b.HasKey("ID");

                    b.ToTable("Processor");
                });

            modelBuilder.Entity("jmbde.Models.Software", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ComputerID");

                    b.Property<string>("Fix");

                    b.Property<int>("ManufacturerID");

                    b.Property<string>("Name");

                    b.Property<string>("Revision");

                    b.Property<string>("Timestamp");

                    b.Property<string>("Version");

                    b.HasKey("ID");

                    b.HasIndex("ComputerID");

                    b.HasIndex("ManufacturerID");

                    b.ToTable("Software");
                });

            modelBuilder.Entity("jmbde.Models.Systemdata", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Address2");

                    b.Property<int>("CityID");

                    b.Property<string>("Company");

                    b.Property<bool>("Local");

                    b.Property<string>("Name");

                    b.Property<string>("Timestamp");

                    b.HasKey("ID");

                    b.HasIndex("CityID");

                    b.ToTable("Systemdata");
                });

            modelBuilder.Entity("jmbde.Models.Title", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Timestamp");

                    b.HasKey("ID");

                    b.ToTable("Title");
                });

            modelBuilder.Entity("jmbde.Models.Account", b =>
                {
                    b.HasOne("jmbde.Models.Employee")
                        .WithMany("Account")
                        .HasForeignKey("EmployeeID");

                    b.HasOne("jmbde.Models.Systemdata", "Systemdata")
                        .WithMany()
                        .HasForeignKey("SystemdataID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("jmbde.Models.Chipcarddoor", b =>
                {
                    b.HasOne("jmbde.Models.Chipcard")
                        .WithMany("Chipcarddoor")
                        .HasForeignKey("ChipcardID");
                });

            modelBuilder.Entity("jmbde.Models.Chipcardprofile", b =>
                {
                    b.HasOne("jmbde.Models.Chipcard")
                        .WithMany("Chipcardprofile")
                        .HasForeignKey("ChipcardID");
                });

            modelBuilder.Entity("jmbde.Models.Computer", b =>
                {
                    b.HasOne("jmbde.Models.Department")
                        .WithMany("Computer")
                        .HasForeignKey("DepartmentID");

                    b.HasOne("jmbde.Models.Devicename", "Devicename")
                        .WithMany()
                        .HasForeignKey("DevicenameID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Devicetype", "Devicetype")
                        .WithMany()
                        .HasForeignKey("DevicetypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Employee", "Employee")
                        .WithMany("Computer")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Os", "Os")
                        .WithMany()
                        .HasForeignKey("OsID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Printer", "Printer")
                        .WithMany("Computer")
                        .HasForeignKey("PrinterID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Processor", "Processor")
                        .WithMany()
                        .HasForeignKey("ProcessorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("jmbde.Models.Department", b =>
                {
                    b.HasOne("jmbde.Models.Employee")
                        .WithMany("Department")
                        .HasForeignKey("EmployeeID");
                });

            modelBuilder.Entity("jmbde.Models.Document", b =>
                {
                    b.HasOne("jmbde.Models.Employee")
                        .WithMany("Document")
                        .HasForeignKey("EmployeeID");
                });

            modelBuilder.Entity("jmbde.Models.Employee", b =>
                {
                    b.HasOne("jmbde.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityID1");

                    b.HasOne("jmbde.Models.Title", "Title")
                        .WithMany()
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("jmbde.Models.Fax", b =>
                {
                    b.HasOne("jmbde.Models.Department", "Department")
                        .WithMany("Fax")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Devicename", "Devicename")
                        .WithMany()
                        .HasForeignKey("DevicenameID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Devicetype", "Devivetype")
                        .WithMany()
                        .HasForeignKey("DevicetypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID1");

                    b.HasOne("jmbde.Models.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Printer", "Printer")
                        .WithMany()
                        .HasForeignKey("PrinterID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("jmbde.Models.Function", b =>
                {
                    b.HasOne("jmbde.Models.Employee", "Employee")
                        .WithMany("Function")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("jmbde.Models.Inventory", b =>
                {
                    b.HasOne("jmbde.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("jmbde.Models.Mobile", b =>
                {
                    b.HasOne("jmbde.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Devicename", "Devicename")
                        .WithMany()
                        .HasForeignKey("DevicenameID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Devicetype", "Devicetype")
                        .WithMany()
                        .HasForeignKey("DevicetypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID1");

                    b.HasOne("jmbde.Models.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("jmbde.Models.Os", b =>
                {
                    b.HasOne("jmbde.Models.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("jmbde.Models.Phone", b =>
                {
                    b.HasOne("jmbde.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Devicename", "Devicename")
                        .WithMany()
                        .HasForeignKey("DevicenameID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Devicetype", "Devicetype")
                        .WithMany()
                        .HasForeignKey("DevicetypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID1");

                    b.HasOne("jmbde.Models.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("jmbde.Models.Printer", b =>
                {
                    b.HasOne("jmbde.Models.Department", "Department")
                        .WithMany("Printer")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Devicename", "Devicename")
                        .WithMany()
                        .HasForeignKey("DevicenameID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Devicetype", "Devicetype")
                        .WithMany()
                        .HasForeignKey("DevicetypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Employee", "Employee")
                        .WithMany("Printer")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("jmbde.Models.Software", b =>
                {
                    b.HasOne("jmbde.Models.Computer")
                        .WithMany("Software")
                        .HasForeignKey("ComputerID");

                    b.HasOne("jmbde.Models.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("jmbde.Models.Systemdata", b =>
                {
                    b.HasOne("jmbde.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
