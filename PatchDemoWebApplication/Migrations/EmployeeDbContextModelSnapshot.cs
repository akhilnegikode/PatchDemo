﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatchDemoWebApplication.Context;

namespace PatchDemoWebApplication.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    partial class EmployeeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("PatchDemoWebApplication.Context.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            Address = "New York",
                            CompanyName = "ABC Inc",
                            Designation = "Developer",
                            Name = "John",
                            Salary = 30000f
                        },
                        new
                        {
                            EmployeeId = 2,
                            Address = "New York",
                            CompanyName = "XYZ Inc",
                            Designation = "Manager",
                            Name = "Chris",
                            Salary = 50000f
                        },
                        new
                        {
                            EmployeeId = 3,
                            Address = "New Delhi",
                            CompanyName = "XYZ Inc",
                            Designation = "Consultant",
                            Name = "Mukesh",
                            Salary = 20000f
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
