using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using jmbde.Models;

namespace jmbde.Data
{
    public partial class jmbdeSQliteContext : DbContext
    {
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<ChipCard> ChipCard { get; set; }
        public virtual DbSet<ChipCardDoor> ChipCardDoor { get; set; }
        public virtual DbSet<ChipCardProfile> ChipCardProfile { get; set; }
        public virtual DbSet<ChipCardProfileDoor> ChipCardProfileDoor { get; set; }
        public virtual DbSet<CityName> CityName { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Computer> Computer { get; set; }
        public virtual DbSet<ComputerSoftware> ComputerSoftware { get; set; }
        public virtual DbSet<DatabaseVersion> DatabaseVersion { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<DeviceName> DeviceName { get; set; }
        public virtual DbSet<DeviceType> DeviceType { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeAccount> EmployeeAccount { get; set; }
        public virtual DbSet<EmployeeDocument> EmployeeDocument { get; set; }
        public virtual DbSet<Fax> Fax { get; set; }
        public virtual DbSet<Function> Function { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Mobile> Mobile { get; set; }
        public virtual DbSet<Os> Os { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<Printer> Printer { get; set; }
        public virtual DbSet<Processor> Processor { get; set; }
        public virtual DbSet<Software> Software { get; set; }
        public virtual DbSet<SystemData> SystemData { get; set; }
        public virtual DbSet<Title> Title { get; set; }
        public virtual DbSet<ZipCity> ZipCity { get; set; }
        public virtual DbSet<ZipCode> ZipCode { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite(@"Data Source=jmbdeSQlite.db3");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.Property(e => e.AccountId)
                    .HasColumnName("account_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.SystemDataId).HasColumnName("system_data_id");

                entity.Property(e => e.UserName)
                    .HasColumnName("user_name")
                    .HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<ChipCard>(entity =>
            {
                entity.ToTable("chip_card");

                entity.Property(e => e.ChipCardId)
                    .HasColumnName("chip_card_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ChipCardDoorId).HasColumnName("chip_card_door_id");

                entity.Property(e => e.ChipCardProfileId).HasColumnName("chip_card_profile_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasColumnType("VARCHAR(10)");
            });

            modelBuilder.Entity<ChipCardDoor>(entity =>
            {
                entity.ToTable("chip_card_door");

                entity.Property(e => e.ChipCardDoorId)
                    .HasColumnName("chip_card_door_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasColumnType("VARCHAR(10)");

                entity.Property(e => e.PlaceId).HasColumnName("place_id");
            });

            modelBuilder.Entity<ChipCardProfile>(entity =>
            {
                entity.ToTable("chip_card_profile");

                entity.Property(e => e.ChipCardProfileId)
                    .HasColumnName("chip_card_profile_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ChipCardDoorId).HasColumnName("chip_card_door_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasColumnType("VARCHAR(10)");
            });

            modelBuilder.Entity<ChipCardProfileDoor>(entity =>
            {
                entity.ToTable("chip_card_profile_door");

                entity.Property(e => e.ChipCardProfileDoorId)
                    .HasColumnName("chip_card_profile_door_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ChipCardDoorId).HasColumnName("chip_card_door_id");

                entity.Property(e => e.ChipCardProfileId).HasColumnName("chip_card_profile_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");
            });

            modelBuilder.Entity<CityName>(entity =>
            {
                entity.ToTable("city_name");

                entity.Property(e => e.CityNameId)
                    .HasColumnName("city_name_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.FaxNumber)
                    .HasColumnName("fax_number")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.MailAddress)
                    .HasColumnName("mail_address")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.MobileNumber)
                    .HasColumnName("mobile_number")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Name2)
                    .HasColumnName("name2")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.ZipCityId).HasColumnName("zip_city_id");
            });

            modelBuilder.Entity<Computer>(entity =>
            {
                entity.ToTable("computer");

                entity.Property(e => e.ComputerId)
                    .HasColumnName("computer_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.ComputerSoftwareId).HasColumnName("computer_software_id");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.DeviceNameId).HasColumnName("device_name_id");

                entity.Property(e => e.DeviceTypeId).HasColumnName("device_type_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");

                entity.Property(e => e.Memory).HasColumnName("memory");

                entity.Property(e => e.Network)
                    .HasColumnName("network")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.NetworkIpAddress)
                    .HasColumnName("network_ip_address")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.NetworkName)
                    .HasColumnName("network_name")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.OsId).HasColumnName("os_id");

                entity.Property(e => e.PlaceId).HasColumnName("place_id");

                entity.Property(e => e.PrinterId).HasColumnName("printer_id");

                entity.Property(e => e.ProcessorId).HasColumnName("processor_id");

                entity.Property(e => e.Replace)
                    .HasColumnName("replace")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.SerialNumber)
                    .HasColumnName("serial_number")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.ServiceNumber)
                    .HasColumnName("service_number")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.ServiceTag)
                    .HasColumnName("service_tag")
                    .HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<ComputerSoftware>(entity =>
            {
                entity.ToTable("computer_software");

                entity.Property(e => e.ComputerSoftwareId)
                    .HasColumnName("computer_software_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ComputerId).HasColumnName("computer_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.SoftwareId).HasColumnName("software_id");
            });

            modelBuilder.Entity<DatabaseVersion>(entity =>
            {
                entity.ToTable("database_version");

                entity.Property(e => e.DatabaseVersionId)
                    .HasColumnName("database_version_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.Patch)
                    .HasColumnName("patch")
                    .HasColumnType("VARCHAR(10)");

                entity.Property(e => e.Revision)
                    .HasColumnName("revision")
                    .HasColumnType("VARCHAR(10)");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasColumnType("VARCHAR(10)");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FaxId).HasColumnName("fax_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.PrinterId).HasColumnName("printer_id");

                entity.Property(e => e.Priority).HasColumnName("priority");
            });

            modelBuilder.Entity<DeviceName>(entity =>
            {
                entity.ToTable("device_name");

                entity.Property(e => e.DeviceNameId)
                    .HasColumnName("device_name_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<DeviceType>(entity =>
            {
                entity.ToTable("device_type");

                entity.Property(e => e.DeviceTypeId)
                    .HasColumnName("device_type_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("document");

                entity.Property(e => e.DocumentId)
                    .HasColumnName("document_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DocumentData).HasColumnName("document_data");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.BirthDay)
                    .HasColumnName("birth_day")
                    .HasColumnType("DATE");

                entity.Property(e => e.BusinessMailAddress)
                    .HasColumnName("business_mail_address")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.ChipCardId).HasColumnName("chip_card_id");

                entity.Property(e => e.ComputerId).HasColumnName("computer_id");

                entity.Property(e => e.DataCare)
                    .HasColumnName("data_care")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.EmployeeAccountId).HasColumnName("employee_account_id");

                entity.Property(e => e.EmployeeDocumentId)
                    .HasColumnName("employee_document_id")
                    .HasColumnType("INTGER");

                entity.Property(e => e.EmployeeNr).HasColumnName("employee_nr");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("DATE");

                entity.Property(e => e.FaxId).HasColumnName("fax_id");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.FunctionId).HasColumnName("function_id");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.HireDate)
                    .HasColumnName("hire_date")
                    .HasColumnType("DATE");

                entity.Property(e => e.HomeMailAddress)
                    .HasColumnName("home_mail_address")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.HomeMobile)
                    .HasColumnName("home_mobile")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.HomePhone)
                    .HasColumnName("home_phone")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.MobileId).HasColumnName("mobile_id");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.PhoneId).HasColumnName("phone_id");

                entity.Property(e => e.Photo).HasColumnName("photo");

                entity.Property(e => e.PrinterId).HasColumnName("printer_id");

                entity.Property(e => e.TitleId).HasColumnName("title_id");

                entity.Property(e => e.ZipCityId).HasColumnName("zip_city_id");
            });

            modelBuilder.Entity<EmployeeAccount>(entity =>
            {
                entity.ToTable("employee_account");

                entity.Property(e => e.EmployeeAccountId)
                    .HasColumnName("employee_account_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");
            });

            modelBuilder.Entity<EmployeeDocument>(entity =>
            {
                entity.ToTable("employee_document");

                entity.Property(e => e.EmployeeDocumentId)
                    .HasColumnName("employee_document_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DocumentId).HasColumnName("document_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");
            });

            modelBuilder.Entity<Fax>(entity =>
            {
                entity.ToTable("fax");

                entity.Property(e => e.FaxId)
                    .HasColumnName("fax_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.DeviceNameId).HasColumnName("device_name_id");

                entity.Property(e => e.DeviceTypeId).HasColumnName("device_type_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Pin)
                    .HasColumnName("pin")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.PlaceId).HasColumnName("place_id");

                entity.Property(e => e.Replace)
                    .HasColumnName("replace")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.SerialNumber)
                    .HasColumnName("serial_number")
                    .HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<Function>(entity =>
            {
                entity.ToTable("function");

                entity.Property(e => e.FunctionId)
                    .HasColumnName("function_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Priority).HasColumnName("priority");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("inventory");

                entity.Property(e => e.InventoryId)
                    .HasColumnName("inventory_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("manufacturer");

                entity.Property(e => e.ManufacturerId)
                    .HasColumnName("manufacturer_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Address2)
                    .HasColumnName("address2")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.FaxNumber)
                    .HasColumnName("fax_number")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.HotlineNumber)
                    .HasColumnName("hotline_number")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.MailAddress)
                    .HasColumnName("mail_address")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Name2)
                    .HasColumnName("name2")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Supporter)
                    .HasColumnName("supporter")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.ZipCityId).HasColumnName("zip_city_id");
            });

            modelBuilder.Entity<Mobile>(entity =>
            {
                entity.ToTable("mobile");

                entity.Property(e => e.MobileId)
                    .HasColumnName("mobile_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.CardNumber)
                    .HasColumnName("card_number")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.DeviceNameId).HasColumnName("device_name_id");

                entity.Property(e => e.DeviceTypeId).HasColumnName("device_type_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Pin)
                    .HasColumnName("pin")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.PlaceId).HasColumnName("place_id");

                entity.Property(e => e.Replace)
                    .HasColumnName("replace")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.SerialNumber)
                    .HasColumnName("serial_number")
                    .HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<Os>(entity =>
            {
                entity.ToTable("os");

                entity.Property(e => e.OsId)
                    .HasColumnName("os_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fix)
                    .HasColumnName("fix")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Revision)
                    .HasColumnName("revision")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.ToTable("phone");

                entity.Property(e => e.PhoneId)
                    .HasColumnName("phone_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.DeviceNameId).HasColumnName("device_name_id");

                entity.Property(e => e.DeviceTypeId).HasColumnName("device_type_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Pin)
                    .HasColumnName("pin")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.PlaceId).HasColumnName("place_id");

                entity.Property(e => e.Replace)
                    .HasColumnName("replace")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.SerialNumber)
                    .HasColumnName("serial_number")
                    .HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.ToTable("place");

                entity.Property(e => e.PlaceId)
                    .HasColumnName("place_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Desk)
                    .HasColumnName("desk")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Room)
                    .HasColumnName("room")
                    .HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<Printer>(entity =>
            {
                entity.ToTable("printer");

                entity.Property(e => e.PrinterId)
                    .HasColumnName("printer_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.ComputerId).HasColumnName("computer_id");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.DeviceNameId).HasColumnName("device_name_id");

                entity.Property(e => e.DeviceTypeId).HasColumnName("device_type_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");

                entity.Property(e => e.Network)
                    .HasColumnName("network")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.NetworkIpAddress)
                    .HasColumnName("network_ip_address")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.NetworkName)
                    .HasColumnName("network_name")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.PaperSizeMax)
                    .HasColumnName("paper_size_max")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.PlaceId).HasColumnName("place_id");

                entity.Property(e => e.Replace)
                    .HasColumnName("replace")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.Resources)
                    .HasColumnName("resources")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.SerialNumber)
                    .HasColumnName("serial_number")
                    .HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<Processor>(entity =>
            {
                entity.ToTable("processor");

                entity.Property(e => e.ProcessorId)
                    .HasColumnName("processor_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClockRate)
                    .HasColumnName("clock_rate")
                    .HasColumnType("DECIMAL");

                entity.Property(e => e.Cores).HasColumnName("cores");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<Software>(entity =>
            {
                entity.ToTable("software");

                entity.Property(e => e.SoftwareId)
                    .HasColumnName("software_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fix)
                    .HasColumnName("fix")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Revision)
                    .HasColumnName("revision")
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<SystemData>(entity =>
            {
                entity.ToTable("system_data");

                entity.Property(e => e.SystemDataId)
                    .HasColumnName("system_data_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.Local)
                    .HasColumnName("local")
                    .HasColumnType("BOOLEAN");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.ToTable("title");

                entity.Property(e => e.TitleId)
                    .HasColumnName("title_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FromDate)
                    .HasColumnName("from_date")
                    .HasColumnType(@"DATE
    to_date DATE");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(50)");
            });

            modelBuilder.Entity<ZipCity>(entity =>
            {
                entity.ToTable("zip_city");

                entity.Property(e => e.ZipCityId)
                    .HasColumnName("zip_city_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CityNameId).HasColumnName("city_name_id");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");

                entity.Property(e => e.ZipCodeId).HasColumnName("zip_code_id");
            });

            modelBuilder.Entity<ZipCode>(entity =>
            {
                entity.ToTable("zip_code");

                entity.Property(e => e.ZipCodeId)
                    .HasColumnName("zip_code_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("VARCHAR(10)");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP");
            });
        }
    }
}
