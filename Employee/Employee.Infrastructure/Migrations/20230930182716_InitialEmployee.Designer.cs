﻿// <auto-generated />
using System;
using Employee.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Employee.Infrastructure.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20230930182716_InitialEmployee")]
    partial class InitialEmployee
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Employee.Model.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryName");

                    b.ToTable("Country");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryName = "Bangaldesh",
                            Created = new DateTimeOffset(new DateTime(2023, 10, 1, 0, 27, 16, 861, DateTimeKind.Unspecified).AddTicks(9592), new TimeSpan(0, 6, 0, 0, 0)),
                            CreatedBy = "1",
                            Currency = "BDT",
                            LastModified = new DateTimeOffset(new DateTime(2023, 10, 1, 0, 27, 16, 861, DateTimeKind.Unspecified).AddTicks(9625), new TimeSpan(0, 6, 0, 0, 0)),
                            Status = 1
                        });
                });

            modelBuilder.Entity("Employee.Model.Employees", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("FirstName");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Zigatola,Dhanmondi",
                            Age = 29,
                            CountryId = 1,
                            Created = new DateTimeOffset(new DateTime(2023, 10, 1, 0, 27, 16, 862, DateTimeKind.Unspecified).AddTicks(3403), new TimeSpan(0, 6, 0, 0, 0)),
                            CreatedBy = "1",
                            FirstName = "Raihan",
                            LastModified = new DateTimeOffset(new DateTime(2023, 10, 1, 0, 27, 16, 862, DateTimeKind.Unspecified).AddTicks(3411), new TimeSpan(0, 6, 0, 0, 0)),
                            LastName = "Shariare",
                            PhoneNumber = "01580480304",
                            Status = 1
                        });
                });

            modelBuilder.Entity("Employee.Model.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Statename")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("Statename");

                    b.ToTable("State");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTimeOffset(new DateTime(2023, 10, 1, 0, 27, 16, 862, DateTimeKind.Unspecified).AddTicks(5069), new TimeSpan(0, 6, 0, 0, 0)),
                            CreatedBy = "1",
                            LastModified = new DateTimeOffset(new DateTime(2023, 10, 1, 0, 27, 16, 862, DateTimeKind.Unspecified).AddTicks(5077), new TimeSpan(0, 6, 0, 0, 0)),
                            Statename = "Bangladesh",
                            Status = 1
                        });
                });

            modelBuilder.Entity("Employee.Model.Employees", b =>
                {
                    b.HasOne("Employee.Model.Country", "Country")
                        .WithMany("Employees")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Employee.Model.State", b =>
                {
                    b.HasOne("Employee.Model.Country", null)
                        .WithMany("State")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("Employee.Model.Country", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("State");
                });
#pragma warning restore 612, 618
        }
    }
}