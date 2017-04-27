using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using jmbde.Data;

namespace jmbde.Migrations
{
    [DbContext(typeof(jmbdesqliteContext))]
    [Migration("20170420192735_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("jmbde.Data.Account", b =>
                {
                    b.Property<long>("AccountId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LastUpdate");

                    b.Property<string>("Password");

                    b.Property<long>("SystemdataId");

                    b.Property<string>("Username");

                    b.HasKey("AccountId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("jmbde.Data.Chipcard", b =>
                {
                    b.Property<long>("ChipcardId")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("EmployeeId");

                    b.Property<string>("LastUpdate");

                    b.Property<string>("Nummer");

                    b.HasKey("ChipcardId");

                    b.ToTable("Chipcard");
                });

            modelBuilder.Entity("jmbde.Data.Cityname", b =>
                {
                    b.Property<long>("CitynameId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LastUpdate");

                    b.Property<string>("Name");

                    b.HasKey("CitynameId");

                    b.ToTable("Cityname");
                });

            modelBuilder.Entity("jmbde.Data.Computer", b =>
                {
                    b.Property<long>("ComputerId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<long>("ComputersoftwareId");

                    b.Property<long>("DepartmentId");

                    b.Property<long>("DevicenameId");

                    b.Property<long>("DevicetypeId");

                    b.Property<long?>("EmployeeId");

                    b.Property<long>("InventoryId");

                    b.Property<string>("LastUpdate");

                    b.Property<long>("ManufacturerId");

                    b.Property<long?>("Memory");

                    b.Property<string>("Network");

                    b.Property<string>("NetworkIpaddress");

                    b.Property<string>("NetworkName");

                    b.Property<long>("OsId");

                    b.Property<long>("PlaceId");

                    b.Property<long?>("PrinterId");

                    b.Property<long?>("PrinterId1");

                    b.Property<long>("ProcessorId");

                    b.Property<bool>("Replace");

                    b.Property<string>("Serialnumber");

                    b.Property<string>("ServiceNumber");

                    b.Property<string>("ServiceTag");

                    b.HasKey("ComputerId");

                    b.HasIndex("DevicenameId");

                    b.HasIndex("DevicetypeId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("InventoryId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("OsId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("PrinterId1");

                    b.HasIndex("ProcessorId");

                    b.ToTable("Computer");
                });

            modelBuilder.Entity("jmbde.Data.Computersoftware", b =>
                {
                    b.Property<long>("ComputersoftwareId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ComputerId");

                    b.Property<string>("LastUpdate");

                    b.Property<long>("SoftwareId");

                    b.HasKey("ComputersoftwareId");

                    b.HasIndex("ComputerId");

                    b.ToTable("Computersoftware");
                });

            modelBuilder.Entity("jmbde.Data.Databaseversion", b =>
                {
                    b.Property<long>("DatabaseversionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LastUpdate");

                    b.Property<long?>("Patch");

                    b.Property<long?>("Revision");

                    b.Property<long?>("Version");

                    b.HasKey("DatabaseversionId");

                    b.ToTable("Databaseversion");
                });

            modelBuilder.Entity("jmbde.Data.Department", b =>
                {
                    b.Property<long>("DepartmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("ComputerId");

                    b.Property<long?>("EmployeeId");

                    b.Property<long>("FaxId");

                    b.Property<string>("LastUpdate");

                    b.Property<string>("Name");

                    b.Property<long>("PrinterId");

                    b.Property<long?>("Prio");

                    b.HasKey("DepartmentId");

                    b.HasIndex("ComputerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("jmbde.Data.Devicename", b =>
                {
                    b.Property<long>("DevicenameId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LastUpdate");

                    b.Property<long>("ManufacturerId");

                    b.Property<string>("Name");

                    b.HasKey("DevicenameId");

                    b.ToTable("Devicename");
                });

            modelBuilder.Entity("jmbde.Data.Devicetype", b =>
                {
                    b.Property<long>("DevicetypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LastUpdate");

                    b.Property<string>("Name");

                    b.HasKey("DevicetypeId");

                    b.ToTable("Devicetype");
                });

            modelBuilder.Entity("jmbde.Data.Documents", b =>
                {
                    b.Property<long>("DocumentsId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Document");

                    b.Property<string>("LastUpdate");

                    b.Property<string>("Name");

                    b.HasKey("DocumentsId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("jmbde.Data.Employee", b =>
                {
                    b.Property<long>("EmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Address")
                        .HasMaxLength(50);

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Businessemail");

                    b.Property<long>("ChipcardId");

                    b.Property<long?>("ChipcardId1");

                    b.Property<long>("ComputerId");

                    b.Property<bool>("Datacare");

                    b.Property<long>("DepartmentId");

                    b.Property<long>("EmployeeDocumentId");

                    b.Property<long?>("EmployeeNr");

                    b.Property<long>("EmployeeaAccountId");

                    b.Property<string>("Enddate");

                    b.Property<long>("FaxId");

                    b.Property<string>("Firstname")
                        .HasMaxLength(50);

                    b.Property<long>("FunctionId");

                    b.Property<int?>("Gender");

                    b.Property<string>("Homeemail");

                    b.Property<string>("Homemobile");

                    b.Property<string>("Homephone");

                    b.Property<string>("LastUpdate");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<long>("MobileId");

                    b.Property<string>("Notes");

                    b.Property<long>("PhoneId");

                    b.Property<byte[]>("Photo");

                    b.Property<long>("PrinterId");

                    b.Property<string>("Startdate");

                    b.Property<long?>("TitleId");

                    b.Property<string>("ZipcityId");

                    b.Property<long?>("ZipcityId1");

                    b.HasKey("EmployeeId");

                    b.HasIndex("ChipcardId1");

                    b.HasIndex("TitleId");

                    b.HasIndex("ZipcityId1");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("jmbde.Data.Employeeaccount", b =>
                {
                    b.Property<long>("EmployeeaccountId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AccountId");

                    b.Property<long>("EmployeeId");

                    b.Property<string>("LastUpdate");

                    b.HasKey("EmployeeaccountId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Employeeaccount");
                });

            modelBuilder.Entity("jmbde.Data.Employeedocument", b =>
                {
                    b.Property<long>("EmployeedocumentId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("DocumentId");

                    b.Property<long>("EmployeeId");

                    b.Property<string>("LastUpdate");

                    b.HasKey("EmployeedocumentId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Employeedocument");
                });

            modelBuilder.Entity("jmbde.Data.Fax", b =>
                {
                    b.Property<long>("FaxId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Active");

                    b.Property<long>("DepartmentId");

                    b.Property<long>("DevicenameId");

                    b.Property<long>("DevicetypeId");

                    b.Property<long?>("EmployeeId");

                    b.Property<long>("InventoryId");

                    b.Property<string>("LastUpdate");

                    b.Property<long>("ManufacturerId");

                    b.Property<string>("Number");

                    b.Property<string>("Pin");

                    b.Property<long>("PlaceId");

                    b.Property<long>("PrinterId");

                    b.Property<string>("Replace");

                    b.Property<string>("Serialnumber");

                    b.HasKey("FaxId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Fax");
                });

            modelBuilder.Entity("jmbde.Data.Function", b =>
                {
                    b.Property<long>("FunctionId")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("EmployeeId");

                    b.Property<string>("LastUpdate");

                    b.Property<string>("Name");

                    b.Property<long?>("Prio");

                    b.HasKey("FunctionId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Function");
                });

            modelBuilder.Entity("jmbde.Data.Inventory", b =>
                {
                    b.Property<long>("InventoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Active");

                    b.Property<string>("LastUpdate");

                    b.Property<string>("Number");

                    b.Property<string>("Text");

                    b.HasKey("InventoryId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("jmbde.Data.Manufacturer", b =>
                {
                    b.Property<long>("ManufacturerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Address2");

                    b.Property<string>("Email");

                    b.Property<string>("Fax");

                    b.Property<string>("Hotline");

                    b.Property<string>("LastUpdate");

                    b.Property<string>("Name");

                    b.Property<string>("Name2");

                    b.Property<string>("Phone");

                    b.Property<string>("Supporter");

                    b.Property<string>("ZipcityId");

                    b.HasKey("ManufacturerId");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("jmbde.Data.Mobile", b =>
                {
                    b.Property<long>("MobileId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Activatedate");

                    b.Property<string>("Active");

                    b.Property<string>("Cardnumber");

                    b.Property<long>("DepartmentId");

                    b.Property<long>("DevicenameId");

                    b.Property<long>("DevicetypeId");

                    b.Property<long?>("EmployeeId");

                    b.Property<long>("InventoryId");

                    b.Property<string>("LastUpdate");

                    b.Property<long>("ManufacturerId");

                    b.Property<string>("Number");

                    b.Property<string>("Pin");

                    b.Property<long>("PlaceId");

                    b.Property<string>("Replace");

                    b.Property<string>("Serialnumber");

                    b.HasKey("MobileId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Mobile");
                });

            modelBuilder.Entity("jmbde.Data.Os", b =>
                {
                    b.Property<long>("OsId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Fix");

                    b.Property<string>("LastUpdate");

                    b.Property<string>("Name");

                    b.Property<string>("Revision");

                    b.Property<string>("Version");

                    b.HasKey("OsId");

                    b.ToTable("Os");
                });

            modelBuilder.Entity("jmbde.Data.Phone", b =>
                {
                    b.Property<long>("PhoneId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Active");

                    b.Property<long>("DepartmentId");

                    b.Property<long>("DevicenameId");

                    b.Property<long>("DevicetypeId");

                    b.Property<long?>("EmployeeId");

                    b.Property<long>("InventoryId");

                    b.Property<string>("LastUpdate");

                    b.Property<long>("ManufacturerId");

                    b.Property<string>("Number");

                    b.Property<string>("Pin");

                    b.Property<long>("PlaceId");

                    b.Property<string>("Replace");

                    b.Property<string>("Serialnumber");

                    b.HasKey("PhoneId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("jmbde.Data.Place", b =>
                {
                    b.Property<long>("PlaceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Desk");

                    b.Property<string>("LastUpdate");

                    b.Property<string>("Name");

                    b.Property<string>("Room");

                    b.HasKey("PlaceId");

                    b.ToTable("Place");
                });

            modelBuilder.Entity("jmbde.Data.Printer", b =>
                {
                    b.Property<long>("PrinterId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Active");

                    b.Property<string>("Color");

                    b.Property<long>("ComputerId");

                    b.Property<long>("DepartmentId");

                    b.Property<long>("DevicenameId");

                    b.Property<long>("DevicetypeId");

                    b.Property<long?>("EmployeeId");

                    b.Property<long>("InventoryId");

                    b.Property<string>("LastUpdate");

                    b.Property<long>("ManufacturerId");

                    b.Property<string>("Network");

                    b.Property<string>("NetworkIpaddress");

                    b.Property<string>("NetworkName");

                    b.Property<string>("PapersizeMax");

                    b.Property<long>("PlaceId");

                    b.Property<string>("Replace");

                    b.Property<string>("Resources");

                    b.Property<string>("Serialnumber");

                    b.HasKey("PrinterId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Printer");
                });

            modelBuilder.Entity("jmbde.Data.Processor", b =>
                {
                    b.Property<long>("ProcessorId")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("Cores");

                    b.Property<string>("Ghz");

                    b.Property<string>("LastUpdate");

                    b.Property<string>("Name");

                    b.HasKey("ProcessorId");

                    b.ToTable("Processor");
                });

            modelBuilder.Entity("jmbde.Data.Software", b =>
                {
                    b.Property<long>("SoftwareId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Fix");

                    b.Property<string>("LastUpdate");

                    b.Property<string>("Name");

                    b.Property<string>("Revision");

                    b.Property<string>("Version");

                    b.HasKey("SoftwareId");

                    b.ToTable("Software");
                });

            modelBuilder.Entity("jmbde.Data.Systemdata", b =>
                {
                    b.Property<long>("SystemdataId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AccountId");

                    b.Property<string>("Address");

                    b.Property<string>("Address2");

                    b.Property<string>("Company");

                    b.Property<string>("LastUpdate");

                    b.Property<string>("Local");

                    b.Property<string>("Name");

                    b.HasKey("SystemdataId");

                    b.ToTable("Systemdata");
                });

            modelBuilder.Entity("jmbde.Data.Title", b =>
                {
                    b.Property<long>("TitleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LastUpdate");

                    b.Property<string>("Name");

                    b.HasKey("TitleId");

                    b.ToTable("Title");
                });

            modelBuilder.Entity("jmbde.Data.Zipcity", b =>
                {
                    b.Property<long>("ZipcityId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CityId");

                    b.Property<long>("CitynameId");

                    b.Property<string>("LastUpdate");

                    b.Property<long>("ZipcodeId");

                    b.HasKey("ZipcityId");

                    b.ToTable("Zipcity");
                });

            modelBuilder.Entity("jmbde.Data.Zipcode", b =>
                {
                    b.Property<long>("ZipcodeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LastUpdate");

                    b.Property<string>("Zipcode1");

                    b.HasKey("ZipcodeId");

                    b.ToTable("Zipcode");
                });

            modelBuilder.Entity("jmbde.Data.Computer", b =>
                {
                    b.HasOne("jmbde.Data.Devicename", "Devicename")
                        .WithMany()
                        .HasForeignKey("DevicenameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Data.Devicetype", "Devicetype")
                        .WithMany()
                        .HasForeignKey("DevicetypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Data.Employee", "Employee")
                        .WithMany("Computer")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("jmbde.Data.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Data.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Data.Os", "Os")
                        .WithMany()
                        .HasForeignKey("OsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Data.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("jmbde.Data.Printer", "Printer")
                        .WithMany()
                        .HasForeignKey("PrinterId1");

                    b.HasOne("jmbde.Data.Processor", "Processor")
                        .WithMany()
                        .HasForeignKey("ProcessorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("jmbde.Data.Computersoftware", b =>
                {
                    b.HasOne("jmbde.Data.Computer")
                        .WithMany("Computersoftware")
                        .HasForeignKey("ComputerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("jmbde.Data.Department", b =>
                {
                    b.HasOne("jmbde.Data.Computer")
                        .WithMany("Department")
                        .HasForeignKey("ComputerId");

                    b.HasOne("jmbde.Data.Employee", "Employee")
                        .WithMany("Department")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("jmbde.Data.Employee", b =>
                {
                    b.HasOne("jmbde.Data.Chipcard", "Chipcard")
                        .WithMany()
                        .HasForeignKey("ChipcardId1");

                    b.HasOne("jmbde.Data.Title", "Title")
                        .WithMany()
                        .HasForeignKey("TitleId");

                    b.HasOne("jmbde.Data.Zipcity", "Zipcity")
                        .WithMany()
                        .HasForeignKey("ZipcityId1");
                });

            modelBuilder.Entity("jmbde.Data.Employeeaccount", b =>
                {
                    b.HasOne("jmbde.Data.Employee", "Employee")
                        .WithMany("Employeeaccount")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("jmbde.Data.Employeedocument", b =>
                {
                    b.HasOne("jmbde.Data.Employee", "Employee")
                        .WithMany("Employeedocument")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("jmbde.Data.Fax", b =>
                {
                    b.HasOne("jmbde.Data.Employee", "Employee")
                        .WithMany("Fax")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("jmbde.Data.Function", b =>
                {
                    b.HasOne("jmbde.Data.Employee", "Employee")
                        .WithMany("Function")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("jmbde.Data.Mobile", b =>
                {
                    b.HasOne("jmbde.Data.Employee", "Employee")
                        .WithMany("Mobile")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("jmbde.Data.Phone", b =>
                {
                    b.HasOne("jmbde.Data.Employee", "Employee")
                        .WithMany("Phone")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("jmbde.Data.Printer", b =>
                {
                    b.HasOne("jmbde.Data.Employee", "Employee")
                        .WithMany("Printer")
                        .HasForeignKey("EmployeeId");
                });
        }
    }
}
