﻿// <auto-generated />
using System;
using EngineAir.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC.Models.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240402203305_DefaultData")]
    partial class DefaultData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MVC.Models.Entities.Componente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("Aeronave")
                        .HasColumnType("int");

                    b.Property<bool>("Funcional")
                        .HasColumnType("bit");

                    b.Property<string>("NumSerie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VarianteID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("VarianteID");

                    b.ToTable("Componente");
                });

            modelBuilder.Entity("MVC.Models.Entities.Helice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool>("Funcional")
                        .HasColumnType("bit");

                    b.Property<int>("ModeloID")
                        .HasColumnType("int");

                    b.Property<string>("NumSerie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TURM")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TiempoTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("ModeloID");

                    b.ToTable("Helice");
                });

            modelBuilder.Entity("MVC.Models.Entities.MarcaHelice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("MarcaHelice");
                });

            modelBuilder.Entity("MVC.Models.Entities.MarcaMotor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("MarcaMotor");
                });

            modelBuilder.Entity("MVC.Models.Entities.ModeloHelice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("MarcaID")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TiempoRemplazoHrs")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TiempoRemplazoMeses")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MarcaID");

                    b.ToTable("ModeloHelice");
                });

            modelBuilder.Entity("MVC.Models.Entities.ModeloMotor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<int>("MarcaID")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TiempoRemplazoHrs")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TiempoRemplazoMeses")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MarcaID");

                    b.ToTable("ModeloMotor");
                });

            modelBuilder.Entity("MVC.Models.Entities.Motor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("Aeronave")
                        .HasColumnType("int");

                    b.Property<bool>("Funcional")
                        .HasColumnType("bit");

                    b.Property<int>("ModeloID")
                        .HasColumnType("int");

                    b.Property<string>("NumSerie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TURM")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TiempoTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("ModeloID");

                    b.ToTable("Motor");
                });

            modelBuilder.Entity("MVC.Models.Entities.Perfil", b =>
                {
                    b.Property<string>("ID")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Perfil");
                });

            modelBuilder.Entity("MVC.Models.Entities.TipoComponente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TipoComponente");
                });

            modelBuilder.Entity("MVC.Models.Entities.Usuario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PerfilID")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("ID");

                    b.HasIndex("PerfilID");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("MVC.Models.Entities.Variante", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TiempoRemplazoHrs")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TiempoRemplazoMeses")
                        .HasColumnType("int");

                    b.Property<int>("TipoID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TipoID");

                    b.ToTable("Variante");
                });

            modelBuilder.Entity("MVC.Models.Entities.Componente", b =>
                {
                    b.HasOne("MVC.Models.Entities.Variante", "Variante")
                        .WithMany("Componentes")
                        .HasForeignKey("VarianteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Variante");
                });

            modelBuilder.Entity("MVC.Models.Entities.Helice", b =>
                {
                    b.HasOne("MVC.Models.Entities.ModeloHelice", "Modelo")
                        .WithMany("Helices")
                        .HasForeignKey("ModeloID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("MVC.Models.Entities.ModeloHelice", b =>
                {
                    b.HasOne("MVC.Models.Entities.MarcaHelice", "Marca")
                        .WithMany("Modelos")
                        .HasForeignKey("MarcaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("MVC.Models.Entities.ModeloMotor", b =>
                {
                    b.HasOne("MVC.Models.Entities.MarcaMotor", "Marca")
                        .WithMany("Modelos")
                        .HasForeignKey("MarcaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("MVC.Models.Entities.Motor", b =>
                {
                    b.HasOne("MVC.Models.Entities.ModeloMotor", "Modelo")
                        .WithMany("Motores")
                        .HasForeignKey("ModeloID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("MVC.Models.Entities.Usuario", b =>
                {
                    b.HasOne("MVC.Models.Entities.Perfil", "Perfil")
                        .WithMany()
                        .HasForeignKey("PerfilID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("MVC.Models.Entities.Variante", b =>
                {
                    b.HasOne("MVC.Models.Entities.TipoComponente", "Tipo")
                        .WithMany("Variantes")
                        .HasForeignKey("TipoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tipo");
                });

            modelBuilder.Entity("MVC.Models.Entities.MarcaHelice", b =>
                {
                    b.Navigation("Modelos");
                });

            modelBuilder.Entity("MVC.Models.Entities.MarcaMotor", b =>
                {
                    b.Navigation("Modelos");
                });

            modelBuilder.Entity("MVC.Models.Entities.ModeloHelice", b =>
                {
                    b.Navigation("Helices");
                });

            modelBuilder.Entity("MVC.Models.Entities.ModeloMotor", b =>
                {
                    b.Navigation("Motores");
                });

            modelBuilder.Entity("MVC.Models.Entities.TipoComponente", b =>
                {
                    b.Navigation("Variantes");
                });

            modelBuilder.Entity("MVC.Models.Entities.Variante", b =>
                {
                    b.Navigation("Componentes");
                });
#pragma warning restore 612, 618
        }
    }
}
