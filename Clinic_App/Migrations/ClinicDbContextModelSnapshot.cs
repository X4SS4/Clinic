﻿// <auto-generated />
using System;
using Clinic_App.Clinic_db_ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Clinic_App.Migrations
{
    [DbContext(typeof(ClinicDbContext))]
    partial class ClinicDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Clinic_App.Models.Persons.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("FIN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientCardId")
                        .HasColumnType("int");

                    b.Property<int?>("WardId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientCardId");

                    b.HasIndex("WardId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Clinic_App.Models.Persons.PatientEntities.DiseaseHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DiseaseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PatientCardId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PatientCardId");

                    b.ToTable("DiseaseHistories");
                });

            modelBuilder.Entity("Clinic_App.Models.Persons.PatientEntities.PatientCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Clinic_App.Models.Persons.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<int>("ContractId")
                        .HasColumnType("int");

                    b.Property<string>("FIN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("Clinic_App.Models.Persons.StaffEntities.StaffContract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Job_title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Salary")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("StaffContracts");
                });

            modelBuilder.Entity("Clinic_App.Models.Rooms.Cabinet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int?>("ownerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ownerId");

                    b.ToTable("Cabinets");
                });

            modelBuilder.Entity("Clinic_App.Models.Rooms.Ward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int?>("PatientCapacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Wards");
                });

            modelBuilder.Entity("Clinic_App.Models.Persons.Patient", b =>
                {
                    b.HasOne("Clinic_App.Models.Persons.PatientEntities.PatientCard", "PatientCard")
                        .WithMany()
                        .HasForeignKey("PatientCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clinic_App.Models.Rooms.Ward", null)
                        .WithMany("Patients")
                        .HasForeignKey("WardId");

                    b.Navigation("PatientCard");
                });

            modelBuilder.Entity("Clinic_App.Models.Persons.PatientEntities.DiseaseHistory", b =>
                {
                    b.HasOne("Clinic_App.Models.Persons.PatientEntities.PatientCard", null)
                        .WithMany("DiseaseHistories")
                        .HasForeignKey("PatientCardId");
                });

            modelBuilder.Entity("Clinic_App.Models.Persons.Staff", b =>
                {
                    b.HasOne("Clinic_App.Models.Persons.StaffEntities.StaffContract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("Clinic_App.Models.Rooms.Cabinet", b =>
                {
                    b.HasOne("Clinic_App.Models.Persons.Staff", "owner")
                        .WithMany()
                        .HasForeignKey("ownerId");

                    b.Navigation("owner");
                });

            modelBuilder.Entity("Clinic_App.Models.Persons.PatientEntities.PatientCard", b =>
                {
                    b.Navigation("DiseaseHistories");
                });

            modelBuilder.Entity("Clinic_App.Models.Rooms.Ward", b =>
                {
                    b.Navigation("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}