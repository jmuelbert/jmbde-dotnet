using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace jmbde.Data
{
    public partial class jmbdesqliteContext : DbContext
    {
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Cityname> Cityname { get; set; }
        public virtual DbSet<Computer> Computer { get; set; }
        public virtual DbSet<Computersoftware> Computersoftware { get; set; }
        public virtual DbSet<Databaseversion> Databaseversion { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Devicename> Devicename { get; set; }
        public virtual DbSet<Devicetype> Devicetype { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Employeeaccount> Employeeaccount { get; set; }
        public virtual DbSet<Employeedocument> Employeedocument { get; set; }
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
        public virtual DbSet<Systemdata> Systemdata { get; set; }
        public virtual DbSet<Title> Title { get; set; }
        public virtual DbSet<Zipcity> Zipcity { get; set; }
        public virtual DbSet<Zipcode> Zipcode { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlite(@"Data Source=jmbdesqlite.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.HasIndex(e => e.SystemdataId)
                    .HasName("idx_fk_account_systemdata");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("VARCHAR(45)");

                entity.Property(e => e.SystemdataId)
                    .HasColumnName("systemdata_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("VARCHAR(45)");
            });

            modelBuilder.Entity<Cityname>(entity =>
            {
                entity.ToTable("cityname");

                entity.HasIndex(e => e.Name)
                    .HasName("idx_cityname")
                    .IsUnique();

                entity.Property(e => e.CitynameId).HasColumnName("cityname_id");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(50)");
            });

            modelBuilder.Entity<Computer>(entity =>
            {
                entity.ToTable("computer");

                entity.HasIndex(e => e.ComputersoftwareId)
                    .HasName("idx_fk_computer_computersoftware");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("idx_fk_computer_department");

                entity.HasIndex(e => e.DevicenameId)
                    .HasName("idx_fk_computer_devicename");

                entity.HasIndex(e => e.DevicetypeId)
                    .HasName("idx_fk_computer_devicetype");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("idx_fk_computer_employee");

                entity.HasIndex(e => e.InventoryId)
                    .HasName("idx_fk_computer_inventory");

                entity.HasIndex(e => e.ManufacturerId)
                    .HasName("idx_fk_computer_manufacturer");

                entity.HasIndex(e => e.OsId)
                    .HasName("idx_fk_computer_os");

                entity.HasIndex(e => e.PlaceId)
                    .HasName("idx_fk_computer_place");

                entity.HasIndex(e => e.PrinterId)
                    .HasName("idx_fk_computer_printer");

                entity.HasIndex(e => e.ProcessorId)
                    .HasName("idx_fk_computer_processor");

                entity.Property(e => e.ComputerId).HasColumnName("computer_id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("BOOLEAN")
                    .HasDefaultValueSql("TRUE");

                entity.Property(e => e.ComputersoftwareId)
                    .HasColumnName("computersoftware_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasColumnType("SMALLINT UNSIGNET")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.DevicenameId)
                    .HasColumnName("devicename_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.DevicetypeId)
                    .HasColumnName("devicetype_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.InventoryId)
                    .HasColumnName("inventory_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ManufacturerId)
                    .HasColumnName("manufacturer_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Memory)
                    .HasColumnName("memory")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("4096");

                entity.Property(e => e.Network)
                    .IsRequired()
                    .HasColumnName("network")
                    .HasColumnType("VARCHAR(45)");

                entity.Property(e => e.NetworkIpaddress)
                    .IsRequired()
                    .HasColumnName("network_ipaddress")
                    .HasColumnType("VARCHAR(30)");

                entity.Property(e => e.NetworkName)
                    .IsRequired()
                    .HasColumnName("network_name")
                    .HasColumnType("VARCHAR(30)");

                entity.Property(e => e.OsId)
                    .HasColumnName("os_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.PlaceId)
                    .HasColumnName("place_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.PrinterId)
                    .HasColumnName("printer_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.ProcessorId)
                    .HasColumnName("processor_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Replace)
                    .HasColumnName("replace")
                    .HasColumnType("BOOLEAN")
                    .HasDefaultValueSql("FALSE");

                entity.Property(e => e.Serialnumber)
                    .IsRequired()
                    .HasColumnName("serialnumber")
                    .HasColumnType("VARCHAR(20)");

                entity.Property(e => e.ServiceNumber)
                    .HasColumnName("service_number")
                    .HasColumnType("VARCHAR(20)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.ServiceTag)
                    .IsRequired()
                    .HasColumnName("service_tag")
                    .HasColumnType("VARCHAR(20)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Computer)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Computersoftware>(entity =>
            {
                entity.ToTable("computersoftware");

                entity.HasIndex(e => e.ComputerId)
                    .HasName("idx_fk_computersoftware_computer");

                entity.HasIndex(e => e.SoftwareId)
                    .HasName("idx_fk_computersoftware_software");

                entity.Property(e => e.ComputersoftwareId).HasColumnName("computersoftware_id");

                entity.Property(e => e.ComputerId)
                    .HasColumnName("computer_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.SoftwareId)
                    .HasColumnName("software_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<Databaseversion>(entity =>
            {
                entity.ToTable("databaseversion");

                entity.Property(e => e.DatabaseversionId).HasColumnName("databaseversion_id");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Patch)
                    .HasColumnName("patch")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Revision)
                    .HasColumnName("revision")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.HasIndex(e => e.FaxId)
                    .HasName("idx_fk_department_dax_id");

                entity.HasIndex(e => e.PrinterId)
                    .HasName("idx_fk_department_printer_id");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.FaxId)
                    .HasColumnName("fax_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(45)");

                entity.Property(e => e.PrinterId)
                    .HasColumnName("printer_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Prio)
                    .HasColumnName("prio")
                    .HasColumnType("SMALLINT")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<Devicename>(entity =>
            {
                entity.ToTable("devicename");

                entity.HasIndex(e => e.ManufacturerId)
                    .HasName("idx_fk_devicename_manufacturer_id");

                entity.Property(e => e.DevicenameId).HasColumnName("devicename_id");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ManufacturerId)
                    .HasColumnName("manufacturer_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(45)");
            });

            modelBuilder.Entity<Devicetype>(entity =>
            {
                entity.ToTable("devicetype");

                entity.Property(e => e.DevicetypeId).HasColumnName("devicetype_id");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(45)");
            });

            modelBuilder.Entity<Documents>(entity =>
            {
                entity.ToTable("documents");

                entity.Property(e => e.DocumentsId).HasColumnName("documents_id");

                entity.Property(e => e.Document)
                    .IsRequired()
                    .HasColumnName("document");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(45)");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.HasIndex(e => e.ComputerId)
                    .HasName("idx_fk_employee_computer_id");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("idx_fk_employee_department_id");

                entity.HasIndex(e => e.EmployeeAccountId)
                    .HasName("idx_fk_employee_employee_account_id");

                entity.HasIndex(e => e.EmployeeDocumentId)
                    .HasName("idx_fk_employee_employee_document_id");

                entity.HasIndex(e => e.EmployeeNr)
                    .HasName("idx_employee_employee_nr");

                entity.HasIndex(e => e.FaxId)
                    .HasName("idx_fk_employee_fax_id");

                entity.HasIndex(e => e.FunctionId)
                    .HasName("idx_fk_employee_function_id");

                entity.HasIndex(e => e.Lastname)
                    .HasName("idx_employee_lastname");

                entity.HasIndex(e => e.MobileId)
                    .HasName("idx_fk_employee_mobile_id");

                entity.HasIndex(e => e.PhoneId)
                    .HasName("idx_fk_employee_phone_id");

                entity.HasIndex(e => e.PrinterId)
                    .HasName("idx_fk_employee_printer_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasColumnName("active")
                    .HasColumnType("BOOLEAN")
                    .HasDefaultValueSql("TRUE");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("DATETIME");

                entity.Property(e => e.Businessemail)
                    .HasColumnName("businessemail")
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.ChipcardId)
                    .HasColumnName("chipcard_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.ComputerId)
                    .HasColumnName("computer_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Datacare)
                    .IsRequired()
                    .HasColumnName("datacare")
                    .HasColumnType("BOOLEAN")
                    .HasDefaultValueSql("FALSE");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.EmployeeAccountId)
                    .HasColumnName("employee_account_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.EmployeeDocumentId)
                    .HasColumnName("employee_document_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.EmployeeNr)
                    .HasColumnName("employee_nr")
                    .HasColumnType("SMALLINT UNSIGNED");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasColumnType("DATETIME");

                entity.Property(e => e.FaxId)
                    .HasColumnName("fax_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasColumnType("VARCHAR(45)");

                entity.Property(e => e.FunctionId)
                    .HasColumnName("function_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasColumnType("VARCHAR(1)");

                entity.Property(e => e.Homeemail)
                    .HasColumnName("homeemail")
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Homemobile)
                    .HasColumnName("homemobile")
                    .HasColumnType("VARCHAR(20)");

                entity.Property(e => e.Homephone)
                    .HasColumnName("homephone")
                    .HasColumnType("VARCHAR(20)");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasColumnType("VARCHAR(45)");

                entity.Property(e => e.MobileId)
                    .HasColumnName("mobile_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.PhoneId)
                    .HasColumnName("phone_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Photo).HasColumnName("photo");

                entity.Property(e => e.PrinterId)
                    .HasColumnName("printer_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("DATETIME");

                entity.Property(e => e.TitleId)
                    .HasColumnName("title_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.ZipcityId)
                    .IsRequired()
                    .HasColumnName("zipcity_id")
                    .HasColumnType("SMALLIT UNSIGNED")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<Employeeaccount>(entity =>
            {
                entity.ToTable("employeeaccount");

                entity.HasIndex(e => e.AccountId)
                    .HasName("idx_fk_employeeaccount_account_id");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("idx_fk_employeeaccount_employee_id");

                entity.Property(e => e.EmployeeaccountId).HasColumnName("employeeaccount_id");

                entity.Property(e => e.AccountId)
                    .HasColumnName("account_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Employeedocument>(entity =>
            {
                entity.ToTable("employeedocument");

                entity.HasIndex(e => e.DocumentId)
                    .HasName("idx_fk_employeedocument_document");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("idx_fk_employeedocument_employee");

                entity.Property(e => e.EmployeedocumentId).HasColumnName("employeedocument_id");

                entity.Property(e => e.DocumentId)
                    .HasColumnName("document_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Fax>(entity =>
            {
                entity.ToTable("fax");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("idx_fk_fax_department");

                entity.HasIndex(e => e.DevicenameId)
                    .HasName("idx_fk_fax_devicename");

                entity.HasIndex(e => e.DevicetypeId)
                    .HasName("idx_fk_fax_devicetype");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("idx_fk_fax_employee");

                entity.HasIndex(e => e.InventoryId)
                    .HasName("idx_fk_fax_inventory");

                entity.HasIndex(e => e.ManufacturerId)
                    .HasName("idx_fk_fax_manufacturer");

                entity.HasIndex(e => e.PlaceId)
                    .HasName("idx_fk_fax_place");

                entity.HasIndex(e => e.PrinterId)
                    .HasName("idx_fk_fax_printer_id");

                entity.Property(e => e.FaxId).HasColumnName("fax_id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("BOOLEAN")
                    .HasDefaultValueSql("TRUE");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasColumnType("SMALLINT UNSIGNET")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.DevicenameId)
                    .HasColumnName("devicename_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.DevicetypeId)
                    .HasColumnName("devicetype_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.InventoryId)
                    .HasColumnName("inventory_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ManufacturerId)
                    .HasColumnName("manufacturer_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasColumnName("number")
                    .HasColumnType("VARCHAR(20)");

                entity.Property(e => e.Pin)
                    .HasColumnName("pin")
                    .HasColumnType("VARCHAR(20)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.PlaceId)
                    .HasColumnName("place_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.PrinterId)
                    .HasColumnName("printer_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Replace)
                    .HasColumnName("replace")
                    .HasColumnType("BOOLEAN")
                    .HasDefaultValueSql("FALSE");

                entity.Property(e => e.Serialnumber)
                    .IsRequired()
                    .HasColumnName("serialnumber")
                    .HasColumnType("VARCHAR(20)");
            });

            modelBuilder.Entity<Function>(entity =>
            {
                entity.ToTable("function");

                entity.Property(e => e.FunctionId).HasColumnName("function_id");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(45)");

                entity.Property(e => e.Prio)
                    .HasColumnName("prio")
                    .HasColumnType("SMALLINT")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("inventory");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("BOOLEAN")
                    .HasDefaultValueSql("TRUE");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasColumnName("number")
                    .HasColumnType("VARCHAR(20)");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text")
                    .HasColumnType("VARCHAR(45)");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("manufacturer");

                entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Address2)
                    .HasColumnName("address2")
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasColumnType("VARCHAR(20)");

                entity.Property(e => e.Hotline)
                    .HasColumnName("hotline")
                    .HasColumnType("VARCHAR(20)");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(45)");

                entity.Property(e => e.Name2)
                    .HasColumnName("name2")
                    .HasColumnType("VARCHAR(45)");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("VARCHAR(20)");

                entity.Property(e => e.Supporter)
                    .IsRequired()
                    .HasColumnName("supporter")
                    .HasColumnType("VARCHAR(45)");

                entity.Property(e => e.ZipcityId)
                    .IsRequired()
                    .HasColumnName("zipcity_id")
                    .HasColumnType("SMALLIT UNSIGNED")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<Mobile>(entity =>
            {
                entity.ToTable("mobile");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("idx_fk_mobile_department");

                entity.HasIndex(e => e.DevicenameId)
                    .HasName("idx_fk_mobile_devicename");

                entity.HasIndex(e => e.DevicetypeId)
                    .HasName("idx_fk_mobile_devicetype");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("idx_fk_mobile_employee");

                entity.HasIndex(e => e.InventoryId)
                    .HasName("idx_fk_mobile_inventory");

                entity.HasIndex(e => e.ManufacturerId)
                    .HasName("idx_fk_mobile_manufacturer");

                entity.HasIndex(e => e.PlaceId)
                    .HasName("idx_fk_mobile_place");

                entity.Property(e => e.MobileId).HasColumnName("mobile_id");

                entity.Property(e => e.Activatedate)
                    .HasColumnName("activatedate")
                    .HasColumnType("DATE");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("BOOLEAN")
                    .HasDefaultValueSql("TRUE");

                entity.Property(e => e.Cardnumber)
                    .HasColumnName("cardnumber")
                    .HasColumnType("VARCHAR(20)");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasColumnType("SMALLINT UNSIGNET")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.DevicenameId)
                    .HasColumnName("devicename_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.DevicetypeId)
                    .HasColumnName("devicetype_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.InventoryId)
                    .HasColumnName("inventory_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ManufacturerId)
                    .HasColumnName("manufacturer_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasColumnName("number")
                    .HasColumnType("VARCHAR(20)");

                entity.Property(e => e.Pin)
                    .HasColumnName("pin")
                    .HasColumnType("VARCHAR(20)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.PlaceId)
                    .HasColumnName("place_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Replace)
                    .HasColumnName("replace")
                    .HasColumnType("BOOLEAN")
                    .HasDefaultValueSql("FALSE");

                entity.Property(e => e.Serialnumber)
                    .IsRequired()
                    .HasColumnName("serialnumber")
                    .HasColumnType("VARCHAR(20)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Mobile)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Os>(entity =>
            {
                entity.ToTable("os");

                entity.Property(e => e.OsId).HasColumnName("os_id");

                entity.Property(e => e.Fix)
                    .HasColumnName("fix")
                    .HasColumnType("VARCHAR(10)");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(20)");

                entity.Property(e => e.Revision)
                    .IsRequired()
                    .HasColumnName("revision")
                    .HasColumnType("VARCHAR(5)");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasColumnName("version")
                    .HasColumnType("VARCHAR(5)");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.ToTable("phone");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("idx_fk_phone_department");

                entity.HasIndex(e => e.DevicenameId)
                    .HasName("idx_fk_phone_devicename");

                entity.HasIndex(e => e.DevicetypeId)
                    .HasName("idx_fk_phone_devicetype");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("idx_fk_phone_employee");

                entity.HasIndex(e => e.InventoryId)
                    .HasName("idx_fk_phone_inventory");

                entity.HasIndex(e => e.ManufacturerId)
                    .HasName("idx_fk_phone_manufacturer");

                entity.HasIndex(e => e.PlaceId)
                    .HasName("idx_fk_phone_place");

                entity.Property(e => e.PhoneId).HasColumnName("phone_id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("BOOLEAN")
                    .HasDefaultValueSql("TRUE");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasColumnType("SMALLINT UNSIGNET")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.DevicenameId)
                    .HasColumnName("devicename_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.DevicetypeId)
                    .HasColumnName("devicetype_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.InventoryId)
                    .HasColumnName("inventory_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ManufacturerId)
                    .HasColumnName("manufacturer_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasColumnName("number")
                    .HasColumnType("VARCHAR(20)");

                entity.Property(e => e.Pin)
                    .HasColumnName("pin")
                    .HasColumnType("VARCHAR(20)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.PlaceId)
                    .HasColumnName("place_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Replace)
                    .HasColumnName("replace")
                    .HasColumnType("BOOLEAN")
                    .HasDefaultValueSql("FALSE");

                entity.Property(e => e.Serialnumber)
                    .IsRequired()
                    .HasColumnName("serialnumber")
                    .HasColumnType("VARCHAR(20)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Phone)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.ToTable("place");

                entity.Property(e => e.PlaceId).HasColumnName("place_id");

                entity.Property(e => e.Desk)
                    .IsRequired()
                    .HasColumnName("desk")
                    .HasColumnType("VARCHAR(45)");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(45)");

                entity.Property(e => e.Room)
                    .IsRequired()
                    .HasColumnName("room")
                    .HasColumnType("VARCHAR(45)");
            });

            modelBuilder.Entity<Printer>(entity =>
            {
                entity.ToTable("printer");

                entity.HasIndex(e => e.ComputerId)
                    .HasName("idx_fk_printer_computer");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("idx_fk_printer_department");

                entity.HasIndex(e => e.DevicenameId)
                    .HasName("idx_fk_printer_devicename");

                entity.HasIndex(e => e.DevicetypeId)
                    .HasName("idx_fk_printer_devicetype");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("idx_fk_printer_employee");

                entity.HasIndex(e => e.InventoryId)
                    .HasName("idx_fk_printer_inventory");

                entity.HasIndex(e => e.ManufacturerId)
                    .HasName("idx_fk_printer_manufacturer");

                entity.HasIndex(e => e.NetworkIpaddress)
                    .HasName("idx_printer_network_ipaddress");

                entity.HasIndex(e => e.NetworkName)
                    .HasName("idx_printer_network_name");

                entity.HasIndex(e => e.PlaceId)
                    .HasName("idx_fk_printer_place");

                entity.Property(e => e.PrinterId).HasColumnName("printer_id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("BOOLEAN")
                    .HasDefaultValueSql("TRUE");

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasColumnType("BOOLEAN")
                    .HasDefaultValueSql("FALSE");

                entity.Property(e => e.ComputerId)
                    .HasColumnName("computer_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("department_id")
                    .HasColumnType("SMALLINT UNSIGNET")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.DevicenameId)
                    .HasColumnName("devicename_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.DevicetypeId)
                    .HasColumnName("devicetype_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.InventoryId)
                    .HasColumnName("inventory_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ManufacturerId)
                    .HasColumnName("manufacturer_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Network)
                    .IsRequired()
                    .HasColumnName("network")
                    .HasColumnType("VARCHAR(45)");

                entity.Property(e => e.NetworkIpaddress)
                    .IsRequired()
                    .HasColumnName("network_ipaddress")
                    .HasColumnType("VARCHAR(30)");

                entity.Property(e => e.NetworkName)
                    .IsRequired()
                    .HasColumnName("network_name")
                    .HasColumnType("VARCHAR(30)");

                entity.Property(e => e.PapersizeMax)
                    .IsRequired()
                    .HasColumnName("papersize_max")
                    .HasColumnType("VARCHAR(5)");

                entity.Property(e => e.PlaceId)
                    .HasColumnName("place_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Replace)
                    .HasColumnName("replace")
                    .HasColumnType("BOOLEAN")
                    .HasDefaultValueSql("FALSE");

                entity.Property(e => e.Resources)
                    .IsRequired()
                    .HasColumnName("resources")
                    .HasColumnType("VARCHAR(45)");

                entity.Property(e => e.Serialnumber)
                    .IsRequired()
                    .HasColumnName("serialnumber")
                    .HasColumnType("VARCHAR(20)");
            });

            modelBuilder.Entity<Processor>(entity =>
            {
                entity.ToTable("processor");

                entity.Property(e => e.ProcessorId).HasColumnName("processor_id");

                entity.Property(e => e.Cores)
                    .HasColumnName("cores")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("2");

                entity.Property(e => e.Ghz)
                    .IsRequired()
                    .HasColumnName("ghz")
                    .HasColumnType("DECIMAL");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(45)");
            });

            modelBuilder.Entity<Software>(entity =>
            {
                entity.ToTable("software");

                entity.Property(e => e.SoftwareId).HasColumnName("software_id");

                entity.Property(e => e.Fix)
                    .HasColumnName("fix")
                    .HasColumnType("VARCHAR(10)");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(20)");

                entity.Property(e => e.Revision)
                    .IsRequired()
                    .HasColumnName("revision")
                    .HasColumnType("VARCHAR(5)");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasColumnName("version")
                    .HasColumnType("VARCHAR(5)");
            });

            modelBuilder.Entity<Systemdata>(entity =>
            {
                entity.ToTable("systemdata");

                entity.HasIndex(e => e.AccountId)
                    .HasName("idx_fk_systemdata_account");

                entity.Property(e => e.SystemdataId).HasColumnName("systemdata_id");

                entity.Property(e => e.AccountId)
                    .HasColumnName("account_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("VARCHAR(45)");

                entity.Property(e => e.Address2)
                    .HasColumnName("address2")
                    .HasColumnType("VARCHAR(45)");

                entity.Property(e => e.Company)
                    .HasColumnName("company")
                    .HasColumnType("VARCHAR(45)");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Local)
                    .HasColumnName("local")
                    .HasColumnType("BOOLEAN")
                    .HasDefaultValueSql("TRUE");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(45)");
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.ToTable("title");

                entity.Property(e => e.TitleId).HasColumnName("title_id");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(20)");
            });

            modelBuilder.Entity<Zipcity>(entity =>
            {
                entity.HasKey(e => e.CitynameId)
                    .HasName("PK_zipcity");

                entity.ToTable("zipcity");

                entity.Property(e => e.CitynameId).HasColumnName("cityname_id");

                entity.Property(e => e.CityId)
                    .HasColumnName("city_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ZipcodeId)
                    .HasColumnName("zipcode_id")
                    .HasColumnType("SMALLINT UNSIGNED")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<Zipcode>(entity =>
            {
                entity.ToTable("zipcode");

                entity.HasIndex(e => e.Zipcode1)
                    .HasName("idx_zip")
                    .IsUnique();

                entity.Property(e => e.ZipcodeId).HasColumnName("zipcode_id");

                entity.Property(e => e.LastUpdate)
                    .IsRequired()
                    .HasColumnName("last_update")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Zipcode1)
                    .IsRequired()
                    .HasColumnName("zipcode")
                    .HasColumnType("VARCHAR(5)");
            });
        }
    }
}