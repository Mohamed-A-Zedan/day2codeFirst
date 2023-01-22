﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using task2fromcode.Models;

#nullable disable

namespace task2fromcode.Migrations
{
    [DbContext(typeof(companyDBcontext))]
    [Migration("20230122223026_v6")]
    partial class v6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("task2fromcode.Models.Dlocations", b =>
                {
                    b.Property<string>("Dlocation")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Dnum")
                        .HasColumnType("int");

                    b.HasKey("Dlocation", "Dnum");

                    b.HasIndex("Dnum");

                    b.ToTable("DLocations");
                });

            modelBuilder.Entity("task2fromcode.Models.department", b =>
                {
                    b.Property<int>("Dnum")
                        .HasColumnType("int");

                    b.Property<string>("DName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MangerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("hireDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Dnum");

                    b.HasIndex("MangerId")
                        .IsUnique()
                        .HasFilter("[MangerId] IS NOT NULL");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("task2fromcode.Models.dependent", b =>
                {
                    b.Property<string>("name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("EmployeeSSN")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Bdate")
                        .HasColumnType("date");

                    b.Property<string>("relationship")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sex")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("name", "EmployeeSSN");

                    b.HasIndex("EmployeeSSN");

                    b.ToTable("Dependents");
                });

            modelBuilder.Entity("task2fromcode.Models.employee", b =>
                {
                    b.Property<int>("SSN")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Bdate")
                        .HasColumnType("date");

                    b.Property<int?>("DeptId")
                        .HasColumnType("int");

                    b.Property<string>("Fname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Lname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("salary")
                        .HasColumnType("int");

                    b.Property<string>("sex")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("superid")
                        .HasColumnType("int");

                    b.HasKey("SSN");

                    b.HasIndex("DeptId");

                    b.HasIndex("superid");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("task2fromcode.Models.project", b =>
                {
                    b.Property<int>("Pnumber")
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentDnum")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("location")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Pnumber");

                    b.HasIndex("DepartmentDnum");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("task2fromcode.Models.workOn", b =>
                {
                    b.Property<int?>("ESSN")
                        .HasColumnType("int");

                    b.Property<int?>("Pnum")
                        .HasColumnType("int");

                    b.Property<int?>("hour")
                        .HasColumnType("int");

                    b.HasKey("ESSN", "Pnum");

                    b.HasIndex("Pnum");

                    b.ToTable("WorkOns");
                });

            modelBuilder.Entity("task2fromcode.Models.Dlocations", b =>
                {
                    b.HasOne("task2fromcode.Models.department", "Department")
                        .WithMany("DLocations")
                        .HasForeignKey("Dnum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("task2fromcode.Models.department", b =>
                {
                    b.HasOne("task2fromcode.Models.employee", "Employee")
                        .WithOne("Departmentt")
                        .HasForeignKey("task2fromcode.Models.department", "MangerId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("task2fromcode.Models.dependent", b =>
                {
                    b.HasOne("task2fromcode.Models.employee", "Employee")
                        .WithMany("dependents")
                        .HasForeignKey("EmployeeSSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("task2fromcode.Models.employee", b =>
                {
                    b.HasOne("task2fromcode.Models.department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DeptId");

                    b.HasOne("task2fromcode.Models.employee", "Employee")
                        .WithMany()
                        .HasForeignKey("superid");

                    b.Navigation("Department");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("task2fromcode.Models.project", b =>
                {
                    b.HasOne("task2fromcode.Models.department", "Department")
                        .WithMany("Projects")
                        .HasForeignKey("DepartmentDnum");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("task2fromcode.Models.workOn", b =>
                {
                    b.HasOne("task2fromcode.Models.employee", "Employee")
                        .WithMany("workOns")
                        .HasForeignKey("ESSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("task2fromcode.Models.project", "Project")
                        .WithMany("WorkOns")
                        .HasForeignKey("Pnum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("task2fromcode.Models.department", b =>
                {
                    b.Navigation("DLocations");

                    b.Navigation("Employees");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("task2fromcode.Models.employee", b =>
                {
                    b.Navigation("Departmentt");

                    b.Navigation("dependents");

                    b.Navigation("workOns");
                });

            modelBuilder.Entity("task2fromcode.Models.project", b =>
                {
                    b.Navigation("WorkOns");
                });
#pragma warning restore 612, 618
        }
    }
}
