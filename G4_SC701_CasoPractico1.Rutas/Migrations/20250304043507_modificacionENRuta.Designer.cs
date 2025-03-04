﻿// <auto-generated />
using System;
using G4_SC701_CasoPractico1.Rutas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace G4_SC701_CasoPractico1.Rutas.Migrations
{
    [DbContext(typeof(CP1Context))]
    [Migration("20250304043507_modificacionENRuta")]
    partial class modificacionENRuta
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("G4_SC701_CasoPractico1.Rutas.Models.Boleto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdRuta")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdRuta");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Boletos");
                });

            modelBuilder.Entity("G4_SC701_CasoPractico1.Rutas.Models.Horarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Horario")
                        .HasColumnType("datetime2");

                    b.Property<int>("RutaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RutaId");

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("G4_SC701_CasoPractico1.Rutas.Models.Paradas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RutaId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RutaId");

                    b.ToTable("Parada");
                });

            modelBuilder.Entity("G4_SC701_CasoPractico1.Rutas.Models.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("G4_SC701_CasoPractico1.Rutas.Models.Ruta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuarioRegistro")
                        .HasColumnType("int");

                    b.Property<int>("IdVehiculo")
                        .HasColumnType("int");

                    b.Property<string>("NombreRuta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuarioRegistro");

                    b.HasIndex("IdVehiculo");

                    b.ToTable("Rutas");
                });

            modelBuilder.Entity("G4_SC701_CasoPractico1.Rutas.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Usuario");

                    b.Property<int?>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("idVehiculo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("G4_SC701_CasoPractico1.Rutas.Models.Vehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CapacidadPasajeros")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<int>("idUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("idUsuario");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("G4_SC701_CasoPractico1.Rutas.Models.Boleto", b =>
                {
                    b.HasOne("G4_SC701_CasoPractico1.Rutas.Models.Ruta", "ruta")
                        .WithMany()
                        .HasForeignKey("IdRuta")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("G4_SC701_CasoPractico1.Rutas.Models.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ruta");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("G4_SC701_CasoPractico1.Rutas.Models.Horarios", b =>
                {
                    b.HasOne("G4_SC701_CasoPractico1.Rutas.Models.Ruta", "ruta")
                        .WithMany("horario")
                        .HasForeignKey("RutaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ruta");
                });

            modelBuilder.Entity("G4_SC701_CasoPractico1.Rutas.Models.Paradas", b =>
                {
                    b.HasOne("G4_SC701_CasoPractico1.Rutas.Models.Ruta", "ruta")
                        .WithMany("paradas")
                        .HasForeignKey("RutaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ruta");
                });

            modelBuilder.Entity("G4_SC701_CasoPractico1.Rutas.Models.Ruta", b =>
                {
                    b.HasOne("G4_SC701_CasoPractico1.Rutas.Models.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuarioRegistro")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("G4_SC701_CasoPractico1.Rutas.Models.Vehiculo", "vehiculo")
                        .WithMany()
                        .HasForeignKey("IdVehiculo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("usuario");

                    b.Navigation("vehiculo");
                });

            modelBuilder.Entity("G4_SC701_CasoPractico1.Rutas.Models.Usuario", b =>
                {
                    b.HasOne("G4_SC701_CasoPractico1.Rutas.Models.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Usuario_Rol");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("G4_SC701_CasoPractico1.Rutas.Models.Vehiculo", b =>
                {
                    b.HasOne("G4_SC701_CasoPractico1.Rutas.Models.Usuario", "usuario")
                        .WithMany("Vehiculos")
                        .HasForeignKey("idUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Usuario_Vehiculo");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("G4_SC701_CasoPractico1.Rutas.Models.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("G4_SC701_CasoPractico1.Rutas.Models.Ruta", b =>
                {
                    b.Navigation("horario");

                    b.Navigation("paradas");
                });

            modelBuilder.Entity("G4_SC701_CasoPractico1.Rutas.Models.Usuario", b =>
                {
                    b.Navigation("Vehiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
