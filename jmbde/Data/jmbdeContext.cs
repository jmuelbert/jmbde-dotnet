using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using jmbde.Models;

namespace jmbde.Data
{
    public partial class jmbdesqliteContext : DbContext
    {
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Chipcard> Chipcard { get; set; }
        public virtual DbSet<Chipcarddoor> Chipcarddoor { get; set; }
        public virtual DbSet<Chipcardprofile> Chipcardprofile { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Computer> Computer { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Devicename> Devicename { get; set; }
        public virtual DbSet<Devicetype> Devicetype { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
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


        public jmbdesqliteContext() {}

        public jmbdesqliteContext(DbContextOptions<jmbdesqliteContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            if (!optionsBuilder.IsConfigured) {
                  optionsBuilder.UseSqlite("Data Source=jmbdesqlite.db");
            }
          
        }

    }
}