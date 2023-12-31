﻿// <auto-generated />
using System;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aviokompanija.Migrations
{
    [DbContext(typeof(HotelContext))]
    [Migration("20230220010601_VerzijaV1")]
    partial class VerzijaV1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CategoryHotels", b =>
                {
                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("HotelID")
                        .HasColumnType("int");

                    b.HasKey("CategoryID", "HotelID");

                    b.HasIndex("HotelID");

                    b.ToTable("CategoryHotels");
                });

            modelBuilder.Entity("Hotel.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Naziv");

                    b.Property<string>("opis")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("opis");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Hotel.Models.Gost", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Naziv");

                    b.Property<string>("jmbg")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("jmbg");

                    b.Property<string>("zemlja")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("zemlja");

                    b.HasKey("ID");

                    b.ToTable("Gost");
                });

            modelBuilder.Entity("Hotel.Models.Hotels", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Naziv");

                    b.Property<string>("lokacija")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("lokacija");

                    b.HasKey("ID");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("Hotel.Models.Soba", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<int?>("HotelID")
                        .HasColumnType("int");

                    b.Property<int>("brojSedista")
                        .HasColumnType("int")
                        .HasColumnName("brojSedista");

                    b.Property<string>("kodniNaziv")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("kodniNaziv");

                    b.Property<string>("model")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("model");

                    b.HasKey("ID");

                    b.HasIndex("HotelID");

                    b.ToTable("Soba");
                });

            modelBuilder.Entity("Hotel.Models.ZakazanTermin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("GostID")
                        .HasColumnType("int");

                    b.Property<int>("OdlazniTermin")
                        .HasColumnType("int")
                        .HasColumnName("OdlazniTermin");

                    b.Property<int>("SobaID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Vreme")
                        .HasColumnType("datetime2")
                        .HasColumnName("Vreme");

                    b.Property<int>("duzinaTermina")
                        .HasColumnType("int")
                        .HasColumnName("duzinaTermina");

                    b.HasKey("ID");

                    b.HasIndex("GostID");

                    b.HasIndex("SobaID");

                    b.ToTable("HostRoom");
                });

            modelBuilder.Entity("CategoryHotels", b =>
                {
                    b.HasOne("Hotel.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hotel.Models.Hotels", null)
                        .WithMany()
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hotel.Models.Soba", b =>
                {
                    b.HasOne("Hotel.Models.Hotels", "Hotel")
                        .WithMany("Room")
                        .HasForeignKey("HotelID");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Hotel.Models.ZakazanTermin", b =>
                {
                    b.HasOne("Hotel.Models.Gost", "Gost")
                        .WithMany("ZakazanTermin")
                        .HasForeignKey("GostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hotel.Models.Soba", "Soba")
                        .WithMany("ZakazanTermin")
                        .HasForeignKey("SobaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gost");

                    b.Navigation("Soba");
                });

            modelBuilder.Entity("Hotel.Models.Gost", b =>
                {
                    b.Navigation("ZakazanTermin");
                });

            modelBuilder.Entity("Hotel.Models.Hotels", b =>
                {
                    b.Navigation("Room");
                });

            modelBuilder.Entity("Hotel.Models.Soba", b =>
                {
                    b.Navigation("ZakazanTermin");
                });
#pragma warning restore 612, 618
        }
    }
}
