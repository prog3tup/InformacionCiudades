﻿// <auto-generated />
using InformacionCiudades.API.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InformacionCiudades.API.Migrations
{
    [DbContext(typeof(InformacionCiudadesContext))]
    [Migration("20220522193343_seedData")]
    partial class seedData
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "The one with that big park.",
                            Nombre = "New York City"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "The one with the cathedral that was never really finished.",
                            Nombre = "Antwerp"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "The one with that big tower.",
                            Nombre = "Paris"
                        });
                });

            modelBuilder.Entity("InformacionCiudades.API.Entities.PuntoDeInteres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CiudadId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CiudadId");

                    b.ToTable("PuntosDeInteres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CiudadId = 1,
                            Descripcion = "The most visited urban park in the United States.",
                            Nombre = "Central Park"
                        },
                        new
                        {
                            Id = 2,
                            CiudadId = 1,
                            Descripcion = "A 102-story skyscraper located in Midtown Manhattan.",
                            Nombre = "Empire State Building"
                        },
                        new
                        {
                            Id = 3,
                            CiudadId = 2,
                            Descripcion = "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans.",
                            Nombre = "Cathedral of Our Lady"
                        },
                        new
                        {
                            Id = 4,
                            CiudadId = 2,
                            Descripcion = "The the finest example of railway architecture in Belgium.",
                            Nombre = "Antwerp Central Station"
                        },
                        new
                        {
                            Id = 5,
                            CiudadId = 3,
                            Descripcion = "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel.",
                            Nombre = "Eiffel Tower"
                        },
                        new
                        {
                            Id = 6,
                            CiudadId = 3,
                            Descripcion = "The world's largest museum.",
                            Nombre = "The Louvre"
                        });
                });

            modelBuilder.Entity("InformacionCiudades.API.Entities.PuntoDeInteres", b =>
                {
                    b.HasOne("InformacionCiudades.API.Entities.Ciudad", "Ciudad")
                        .WithMany("PuntosDeInteres")
                        .HasForeignKey("CiudadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
