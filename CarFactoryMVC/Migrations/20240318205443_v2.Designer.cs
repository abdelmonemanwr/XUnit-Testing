﻿// <auto-generated />
using CarFactoryMVC.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarFactoryMVC.Migrations
{
    [DbContext(typeof(FactoryContext))]
    [Migration("20240318205443_v2")]
    partial class v2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.2.24128.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarFactoryMVC.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("VIN")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Velocity")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId")
                        .IsUnique()
                        .HasFilter("[OwnerId] IS NOT NULL");

                    b.HasIndex("VIN")
                        .IsUnique();

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarFactoryMVC.Entities.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("CarFactoryMVC.Entities.Car", b =>
                {
                    b.HasOne("CarFactoryMVC.Entities.Owner", "Owner")
                        .WithOne("Car")
                        .HasForeignKey("CarFactoryMVC.Entities.Car", "OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CarFactoryMVC.Entities.Owner", b =>
                {
                    b.Navigation("Car")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}