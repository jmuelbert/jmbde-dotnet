using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using jmbde.Data;

namespace jmbde.Migrations
{
    [DbContext(typeof(jmbdesqliteContext))]
    [Migration("20170524135031_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("jmbde.Data.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<int>("SystemdataId");

                    b.Property<string>("Timestamp");

                    b.Property<string>("Username");

                    b.HasKey("AccountId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("jmbde.Data.Chipcard", b =>
                {
                    b.Property<int>("ChipcardId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EmployeeId");

                    b.Property<string>("Nummer");

                    b.Property<string>("Timestamp");

                    b.Property<bool>("isActive");

                    b.HasKey("ChipcardId");

                    b.ToTable("Chipcard");
                });

            modelBuilder.Entity("jmbde.Data.Cityname", b =>
                {
                    b.Property<int>("CitynameId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Timestamp");

                    b.HasKey("CitynameId");

                    b.ToTable("Cityname");
                });

            modelBuilder.Entity("jmbde.Data.Computer", b =>
                {
                    b.Property<int>("ComputerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ComputersoftwareId");

                    b.Property<int>("DepartmentId");

                    b.Property<int>("DevicenameId");

                    b.Property<int>("DevicetypeId");

                    b.Property<int?>("EmployeeId");

                    b.Property<int>("InventoryId");

                    b.Property<int>("ManufacturerId");

                    b.Property<long?>("Memory");

                    b.Property<string>("Network");

                    b.Property<string>("NetworkIpaddress");

                    b.Property<string>("NetworkName");

                    b.Property<int>("OsId");

                    b.Property<int>("PlaceId");

                    b.Property<int?>("PrinterId");

                    b.Property<int?>("PrinterId1");

                    b.Property<int>("ProcessorId");

                    b.Property<string>("Serialnumber");

                    b.Property<string>("ServiceNumber");

                    b.Property<string>("ServiceTag");

                    b.Property<string>("Timestamp");

                    b.Property<bool>("isActive");

                    b.Property<bool>("shouldReplace");

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
                    b.Property<int>("ComputersoftwareId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ComputerId");

                    b.Property<int>("SoftwareId");

                    b.Property<string>("Timestamp");

                    b.HasKey("ComputersoftwareId");

                    b.HasIndex("ComputerId");

                    b.ToTable("Computersoftware");
                });

            modelBuilder.Entity("jmbde.Data.Databaseversion", b =>
                {
                    b.Property<int>("DatabaseversionId")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("Patch");

                    b.Property<long?>("Revision");

                    b.Property<string>("Timestamp");

                    b.Property<long?>("Version");

                    b.HasKey("DatabaseversionId");

                    b.ToTable("Databaseversion");
                });

            modelBuilder.Entity("jmbde.Data.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ComputerId");

                    b.Property<int?>("EmployeeId");

                    b.Property<int>("FaxId");

                    b.Property<string>("Name");

                    b.Property<int>("PrinterId");

                    b.Property<int?>("Prio");

                    b.Property<string>("Timestamp");

                    b.HasKey("DepartmentId");

                    b.HasIndex("ComputerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("jmbde.Data.Devicename", b =>
                {
                    b.Property<int>("DevicenameId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ManufacturerId");

                    b.Property<string>("Name");

                    b.Property<string>("Timestamp");

                    b.HasKey("DevicenameId");

                    b.ToTable("Devicename");
                });

            modelBuilder.Entity("jmbde.Data.Devicetype", b =>
                {
                    b.Property<int>("DevicetypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Timestamp");

                    b.HasKey("DevicetypeId");

                    b.ToTable("Devicetype");
                });

            modelBuilder.Entity("jmbde.Data.Documents", b =>
                {
                    b.Property<int>("DocumentsId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Document");

                    b.Property<string>("Name");

                    b.Property<string>("Timestamp");

                    b.HasKey("DocumentsId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("jmbde.Data.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(50);

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Businessemail");

                    b.Property<int>("ChipcardId");

                    b.Property<int?>("ChipcardId1");

                    b.Property<int>("ComputerId");

                    b.Property<bool>("Datacare");

                    b.Property<int>("DepartmentId");

                    b.Property<int>("EmployeeDocumentId");

                    b.Property<long?>("EmployeeNr");

                    b.Property<int>("EmployeeaAccountId");

                    b.Property<string>("Enddate");

                    b.Property<int>("FaxId");

                    b.Property<string>("Firstname")
                        .HasMaxLength(50);

                    b.Property<int>("FunctionId");

                    b.Property<int?>("Gender");

                    b.Property<string>("Homeemail");

                    b.Property<string>("Homemobile");

                    b.Property<string>("Homephone");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("MobileId");

                    b.Property<string>("Notes");

                    b.Property<int>("PhoneId");

                    b.Property<byte[]>("Photo");

                    b.Property<int>("PrinterId");

                    b.Property<string>("Startdate");

                    b.Property<string>("Timestamp");

                    b.Property<int?>("TitleId");

                    b.Property<string>("ZipcityId");

                    b.Property<int?>("ZipcityId1");

                    b.Property<bool>("isActive");

                    b.HasKey("EmployeeId");

                    b.HasIndex("ChipcardId1");

                    b.HasIndex("TitleId");

                    b.HasIndex("ZipcityId1");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("jmbde.Data.Employeeaccount", b =>
                {
                    b.Property<int>("EmployeeaccountId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountId");

                    b.Property<int>("EmployeeId");

                    b.Property<string>("Timestamp");

                    b.HasKey("EmployeeaccountId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Employeeaccount");
                });

            modelBuilder.Entity("jmbde.Data.Employeedocument", b =>
                {
                    b.Property<int>("EmployeedocumentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DocumentId");

                    b.Property<int>("EmployeeId");

                    b.Property<string>("Timestamp");

                    b.HasKey("EmployeedocumentId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Employeedocument");
                });

            modelBuilder.Entity("jmbde.Data.Fax", b =>
                {
                    b.Property<int>("FaxId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartmentId");

                    b.Property<int>("DevicenameId");

                    b.Property<int>("DevicetypeId");

                    b.Property<int?>("EmployeeId");

                    b.Property<int>("InventoryId");

                    b.Property<int>("ManufacturerId");

                    b.Property<string>("Number");

                    b.Property<string>("Pin");

                    b.Property<int>("PlaceId");

                    b.Property<int>("PrinterId");

                    b.Property<string>("Serialnumber");

                    b.Property<string>("Timestamp");

                    b.Property<bool>("isActive");

                    b.Property<bool>("shouldReplace");

                    b.HasKey("FaxId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Fax");
                });

            modelBuilder.Entity("jmbde.Data.Function", b =>
                {
                    b.Property<int>("FunctionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EmployeeId");

                    b.Property<string>("Name");

                    b.Property<int?>("Prio");

                    b.Property<string>("Timestamp");

                    b.HasKey("FunctionId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Function");
                });

            modelBuilder.Entity("jmbde.Data.Inventory", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Number");

                    b.Property<string>("Text");

                    b.Property<string>("Timestamp");

                    b.Property<bool>("isActive");

                    b.HasKey("InventoryId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("jmbde.Data.Manufacturer", b =>
                {
                    b.Property<int>("ManufacturerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Address2");

                    b.Property<string>("Email");

                    b.Property<string>("Fax");

                    b.Property<string>("Hotline");

                    b.Property<string>("Name");

                    b.Property<string>("Name2");

                    b.Property<string>("Phone");

                    b.Property<string>("Supporter");

                    b.Property<string>("Timestamp");

                    b.Property<string>("ZipcityId");

                    b.HasKey("ManufacturerId");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("jmbde.Data.Mobile", b =>
                {
                    b.Property<int>("MobileId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Activatedate");

                    b.Property<string>("Cardnumber");

                    b.Property<int>("DepartmentId");

                    b.Property<int>("DevicenameId");

                    b.Property<int>("DevicetypeId");

                    b.Property<int?>("EmployeeId");

                    b.Property<int>("InventoryId");

                    b.Property<int>("ManufacturerId");

                    b.Property<string>("Number");

                    b.Property<string>("Pin");

                    b.Property<int>("PlaceId");

                    b.Property<string>("Serialnumber");

                    b.Property<string>("Timestamp");

                    b.Property<bool>("isActive");

                    b.Property<bool>("shouldReplace");

                    b.HasKey("MobileId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Mobile");
                });

            modelBuilder.Entity("jmbde.Data.Os", b =>
                {
                    b.Property<int>("OsId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Fix");

                    b.Property<string>("Name");

                    b.Property<string>("Revision");

                    b.Property<string>("Timestamp");

                    b.Property<string>("Version");

                    b.HasKey("OsId");

                    b.ToTable("Os");
                });

            modelBuilder.Entity("jmbde.Data.Phone", b =>
                {
                    b.Property<int>("PhoneId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartmentId");

                    b.Property<int>("DevicenameId");

                    b.Property<int>("DevicetypeId");

                    b.Property<int?>("EmployeeId");

                    b.Property<int>("InventoryId");

                    b.Property<int>("ManufacturerId");

                    b.Property<string>("Number");

                    b.Property<string>("Pin");

                    b.Property<int>("PlaceId");

                    b.Property<string>("Serialnumber");

                    b.Property<string>("Timestamp");

                    b.Property<bool>("isActive");

                    b.Property<bool>("shouldReplace");

                    b.HasKey("PhoneId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("jmbde.Data.Place", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Desk");

                    b.Property<string>("Name");

                    b.Property<string>("Room");

                    b.Property<string>("Timestamp");

                    b.HasKey("PlaceId");

                    b.ToTable("Place");
                });

            modelBuilder.Entity("jmbde.Data.Printer", b =>
                {
                    b.Property<int>("PrinterId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ComputerId");

                    b.Property<int>("DepartmentId");

                    b.Property<int>("DevicenameId");

                    b.Property<int>("DevicetypeId");

                    b.Property<int?>("EmployeeId");

                    b.Property<int>("InventoryId");

                    b.Property<int>("ManufacturerId");

                    b.Property<string>("Network");

                    b.Property<string>("NetworkIpaddress");

                    b.Property<string>("NetworkName");

                    b.Property<string>("PapersizeMax");

                    b.Property<int>("PlaceId");

                    b.Property<string>("Resources");

                    b.Property<string>("Serialnumber");

                    b.Property<string>("Timestamp");

                    b.Property<bool>("isActive");

                    b.Property<bool>("isColor");

                    b.Property<bool>("shouldReplace");

                    b.HasKey("PrinterId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Printer");
                });

            modelBuilder.Entity("jmbde.Data.Processor", b =>
                {
                    b.Property<int>("ProcessorId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Cores");

                    b.Property<float>("Ghz");

                    b.Property<string>("Name");

                    b.Property<string>("Timestamp");

                    b.HasKey("ProcessorId");

                    b.ToTable("Processor");
                });

            modelBuilder.Entity("jmbde.Data.Software", b =>
                {
                    b.Property<int>("SoftwareId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Fix");

                    b.Property<string>("Name");

                    b.Property<int>("Revision");

                    b.Property<string>("Timestamp");

                    b.Property<int>("Version");

                    b.HasKey("SoftwareId");

                    b.ToTable("Software");
                });

            modelBuilder.Entity("jmbde.Data.Systemdata", b =>
                {
                    b.Property<int>("SystemdataId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountId");

                    b.Property<string>("Address");

                    b.Property<string>("Address2");

                    b.Property<string>("Company");

                    b.Property<string>("Name");

                    b.Property<string>("Timestamp");

                    b.Property<bool>("isLocal");

                    b.HasKey("SystemdataId");

                    b.ToTable("Systemdata");
                });

            modelBuilder.Entity("jmbde.Data.Title", b =>
                {
                    b.Property<int>("TitleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Timestamp");

                    b.HasKey("TitleId");

                    b.ToTable("Title");
                });

            modelBuilder.Entity("jmbde.Data.Zipcity", b =>
                {
                    b.Property<int>("ZipcityId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CityId");

                    b.Property<int>("CitynameId");

                    b.Property<string>("Timestamp");

                    b.Property<int>("ZipcodeId");

                    b.HasKey("ZipcityId");

                    b.ToTable("Zipcity");
                });

            modelBuilder.Entity("jmbde.Data.Zipcode", b =>
                {
                    b.Property<int>("ZipcodeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Timestamp");

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
