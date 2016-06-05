using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using jmbde.Models;

namespace jmbde.Migrations
{
    [DbContext(typeof(JMBDEContext))]
    partial class JMBDEContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("jmbde.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Active");

                    b.Property<string>("City");

                    b.Property<int>("EmployeeId");

                    b.Property<string>("FaxNumber");

                    b.Property<DateTime?>("LastUpdate");

                    b.Property<string>("Mail")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("MobileNumber");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Name2")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Street");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("jmbde.Models.Computer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Active");

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime?>("LastUpdate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");
                });

            modelBuilder.Entity("jmbde.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Active");

                    b.Property<DateTime?>("Birthday");

                    b.Property<string>("BusinessMail");

                    b.Property<string>("ChipCard")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("City")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int?>("CompanyId");

                    b.Property<bool?>("DataCare");

                    b.Property<int?>("DepartmentId");

                    b.Property<string>("EmployeeNO")
                        .IsRequired();

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("FaxNumber")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("FirstName")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("Gender")
                        .HasAnnotation("MaxLength", 1);

                    b.Property<DateTime?>("LastUpdate");

                    b.Property<string>("Mail")
                        .HasAnnotation("MaxLength", 40);

                    b.Property<string>("MiddleName")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("MobileNumber")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("Notes");

                    b.Property<string>("PhoneNumber")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<byte[]>("Photo");

                    b.Property<int?>("PlaceId");

                    b.Property<DateTime?>("StartDate");

                    b.Property<string>("Street")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int?>("WorkfunctionId");

                    b.Property<string>("ZipCode")
                        .HasAnnotation("MaxLength", 10);

                    b.HasKey("Id");
                });

            modelBuilder.Entity("jmbde.Models.Mobile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Active");

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime?>("LastUpdate");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 30);

                    b.HasKey("Id");
                });

            modelBuilder.Entity("jmbde.Models.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Active");

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime?>("LastUpdate");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 30);

                    b.HasKey("Id");
                });

            modelBuilder.Entity("jmbde.Models.Company", b =>
                {
                    b.HasOne("jmbde.Models.Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("jmbde.Models.Computer", b =>
                {
                    b.HasOne("jmbde.Models.Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("jmbde.Models.Mobile", b =>
                {
                    b.HasOne("jmbde.Models.Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("jmbde.Models.Phone", b =>
                {
                    b.HasOne("jmbde.Models.Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");
                });
        }
    }
}
