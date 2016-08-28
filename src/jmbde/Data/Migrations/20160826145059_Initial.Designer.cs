using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using jmbde.Data;

namespace jmbde.Migrations
{
    [DbContext(typeof(JMBDEContext))]
    [Migration("20160826145059_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

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

                    b.HasIndex("EmployeeId");

                    b.ToTable("Computer");
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

                    b.ToTable("Employee");
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

                    b.HasIndex("EmployeeId");

                    b.ToTable("Mobile");
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

                    b.HasIndex("EmployeeId");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("jmbde.Models.Computer", b =>
                {
                    b.HasOne("jmbde.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("jmbde.Models.Mobile", b =>
                {
                    b.HasOne("jmbde.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("jmbde.Models.Phone", b =>
                {
                    b.HasOne("jmbde.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
