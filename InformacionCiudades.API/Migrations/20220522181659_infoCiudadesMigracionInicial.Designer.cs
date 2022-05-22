﻿// <auto-generated />
using System;
using InformacionCiudades.API.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InformacionCiudades.API.Migrations
{
    [DbContext(typeof(InformacionCiudadesContext))]
    [Migration("20220522181659_infoCiudadesMigracionInicial")]
    partial class infoCiudadesMigracionInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("InformacionCiudades.API.Entities.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("InformacionCiudades.API.Entities.PuntoDeInteres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CiudadId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CiudadId");

                    b.ToTable("PuntosDeInteres");
                });

            modelBuilder.Entity("InformacionCiudades.API.Entities.PuntoDeInteres", b =>
                {
                    b.HasOne("InformacionCiudades.API.Entities.Ciudad", "Ciudad")
                        .WithMany("PuntosDeInteres")
                        .HasForeignKey("CiudadId");

                    b.Navigation("Ciudad");
                });

            modelBuilder.Entity("InformacionCiudades.API.Entities.Ciudad", b =>
                {
                    b.Navigation("PuntosDeInteres");
                });
#pragma warning restore 612, 618
        }
    }
}
