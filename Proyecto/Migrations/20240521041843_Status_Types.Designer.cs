﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto.Data;

#nullable disable

namespace Proyecto.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240521041843_Status_Types")]
    partial class Status_Types
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proyecto.Models.Document_Type", b =>
                {
                    b.Property<string>("DocType_Id")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("DocType_Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DocType_Code"));

                    b.Property<string>("DocType_Description")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("DocType_Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("DocType_Id");

                    b.ToTable("Documents_Types");
                });

            modelBuilder.Entity("Proyecto.Models.Roles", b =>
                {
                    b.Property<int>("Rol_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Rol_Id"));

                    b.Property<string>("Rol_Description")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Rol_Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Rol_Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Proyecto.Models.Status", b =>
                {
                    b.Property<int>("Status_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Status_Id"));

                    b.Property<string>("Status_Description")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Status_Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Status_Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Proyecto.Models.Status_Type", b =>
                {
                    b.Property<int>("Staty_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Staty_Id"));

                    b.Property<string>("Staty_Description")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Staty_Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Staty_Id");

                    b.ToTable("Status_Types");
                });
#pragma warning restore 612, 618
        }
    }
}