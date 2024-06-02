﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto.Data;

#nullable disable

namespace Proyecto.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("Staty_Id")
                        .HasColumnType("int");

                    b.HasKey("Status_Id");

                    b.HasIndex("Staty_Id");

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

            modelBuilder.Entity("Proyecto.Models.User", b =>
                {
                    b.Property<long>("Us_Id")
                        .HasColumnType("bigint");

                    b.Property<string>("DocType_Id")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Rol_Id")
                        .HasColumnType("int");

                    b.Property<int>("Status_Civil")
                        .HasColumnType("int");

                    b.Property<int>("Status_Id")
                        .HasColumnType("int");

                    b.Property<string>("Us_Adress")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Us_CityBorn")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<long>("Us_Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Us_Code"));

                    b.Property<string>("Us_CurrentCity")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("Us_DateBorn")
                        .HasColumnType("date");

                    b.Property<DateTime>("Us_DateCreation")
                        .HasColumnType("date");

                    b.Property<string>("Us_Email")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Us_HourCreation")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Us_Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Us_Observation")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Us_Password")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Us_Phone")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Us_ProfessionalProfile")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.HasKey("Us_Id");

                    b.HasIndex("DocType_Id");

                    b.HasIndex("Rol_Id");

                    b.HasIndex("Status_Civil");

                    b.HasIndex("Status_Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Proyecto.Models.Status", b =>
                {
                    b.HasOne("Proyecto.Models.Status_Type", "Statuses_Types")
                        .WithMany()
                        .HasForeignKey("Staty_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Statuses_Types");
                });

            modelBuilder.Entity("Proyecto.Models.User", b =>
                {
                    b.HasOne("Proyecto.Models.Document_Type", "Docs_Types")
                        .WithMany()
                        .HasForeignKey("DocType_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Proyecto.Models.Roles", "Role")
                        .WithMany()
                        .HasForeignKey("Rol_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Proyecto.Models.Status", "CivilStatus")
                        .WithMany()
                        .HasForeignKey("Status_Civil")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Proyecto.Models.Status", "Statuses")
                        .WithMany()
                        .HasForeignKey("Status_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CivilStatus");

                    b.Navigation("Docs_Types");

                    b.Navigation("Role");

                    b.Navigation("Statuses");
                });
#pragma warning restore 612, 618
        }
    }
}