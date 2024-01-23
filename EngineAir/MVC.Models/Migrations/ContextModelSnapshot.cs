﻿// <auto-generated />
using System;
using EngineAir.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC.Models.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MVC.Models.Entities.Aeronave", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModeloID")
                        .HasColumnType("int");

                    b.Property<bool>("MonoMotor")
                        .HasColumnType("bit");

                    b.Property<string>("Propietario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ModeloID");

                    b.ToTable("Aeronave");
                });

            modelBuilder.Entity("MVC.Models.Entities.Catalogo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TiempoRemplazoHrs")
                        .HasColumnType("int");

                    b.Property<int>("TiempoRemplazoMeses")
                        .HasColumnType("int");

                    b.Property<int>("TipoID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TipoID");

                    b.ToTable("Catalogo");
                });

            modelBuilder.Entity("MVC.Models.Entities.Componente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("AeronaveID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool>("Asignacion")
                        .HasColumnType("bit");

                    b.Property<int>("CatalogoID")
                        .HasColumnType("int");

                    b.Property<string>("Serie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AeronaveID");

                    b.HasIndex("CatalogoID");

                    b.ToTable("Componente");
                });

            modelBuilder.Entity("MVC.Models.Entities.Helice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool>("Asignacion")
                        .HasColumnType("bit");

                    b.Property<decimal>("HrsTURM")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ModeloID")
                        .HasColumnType("int");

                    b.Property<string>("Serie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TiempoTotalHrs")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("ModeloID");

                    b.ToTable("Helice");
                });

            modelBuilder.Entity("MVC.Models.Entities.MarcaAeronave", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("MarcaAeronave");
                });

            modelBuilder.Entity("MVC.Models.Entities.MarcaHelice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

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

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("MarcaMotor");
                });

            modelBuilder.Entity("MVC.Models.Entities.ModeloAeronave", b =>
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

                    b.HasKey("ID");

                    b.HasIndex("MarcaID");

                    b.ToTable("ModeloAeronave");
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

                    b.Property<int>("TiempoRemplazoHrs")
                        .HasColumnType("int");

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

                    b.Property<int>("MarcaID")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TiempoRemplazoHrs")
                        .HasColumnType("int");

                    b.Property<int>("TiempoRemplazoMeses")
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

                    b.Property<bool>("Asignacion")
                        .HasColumnType("bit");

                    b.Property<int?>("AvionID")
                        .HasColumnType("int");

                    b.Property<int?>("HeliceID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<decimal>("HrsTURM")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ModeloID")
                        .HasColumnType("int");

                    b.Property<string>("Serie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TiempoTotalHrs")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("AvionID");

                    b.HasIndex("HeliceID");

                    b.HasIndex("ModeloID");

                    b.ToTable("Motor");
                });

            modelBuilder.Entity("MVC.Models.Entities.Seguimiento", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("ComponenteID")
                        .HasColumnType("int");

                    b.Property<int?>("HeliceID")
                        .HasColumnType("int");

                    b.Property<int?>("MotorID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProximaAplicacionFecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ProximaAplicacionHrs")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RemanenteHrs")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RemanenteMeses")
                        .HasColumnType("int");

                    b.Property<DateTime>("UltimaAplicacionFecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("UltimaAplicacionHrs")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("ComponenteID");

                    b.HasIndex("HeliceID");

                    b.HasIndex("MotorID");

                    b.ToTable("Seguimiento");
                });

            modelBuilder.Entity("MVC.Models.Entities.TipoComponente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Componente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TipoComponente");
                });

            modelBuilder.Entity("MVC.Models.Entities.Aeronave", b =>
                {
                    b.HasOne("MVC.Models.Entities.ModeloAeronave", "ModeloAvion")
                        .WithMany("Aeronaves")
                        .HasForeignKey("ModeloID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModeloAvion");
                });

            modelBuilder.Entity("MVC.Models.Entities.Catalogo", b =>
                {
                    b.HasOne("MVC.Models.Entities.TipoComponente", "TipoComponente")
                        .WithMany("Catalogos")
                        .HasForeignKey("TipoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoComponente");
                });

            modelBuilder.Entity("MVC.Models.Entities.Componente", b =>
                {
                    b.HasOne("MVC.Models.Entities.Aeronave", "Aeronave")
                        .WithMany("Componentes")
                        .HasForeignKey("AeronaveID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC.Models.Entities.Catalogo", "Catalogo")
                        .WithMany("Componentes")
                        .HasForeignKey("CatalogoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aeronave");

                    b.Navigation("Catalogo");
                });

            modelBuilder.Entity("MVC.Models.Entities.Helice", b =>
                {
                    b.HasOne("MVC.Models.Entities.ModeloHelice", "ModeloHelice")
                        .WithMany("Helices")
                        .HasForeignKey("ModeloID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModeloHelice");
                });

            modelBuilder.Entity("MVC.Models.Entities.ModeloAeronave", b =>
                {
                    b.HasOne("MVC.Models.Entities.MarcaAeronave", "MarcaAeronave")
                        .WithMany("ModelosAeronave")
                        .HasForeignKey("MarcaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MarcaAeronave");
                });

            modelBuilder.Entity("MVC.Models.Entities.ModeloHelice", b =>
                {
                    b.HasOne("MVC.Models.Entities.MarcaHelice", "MarcaHelice")
                        .WithMany("ModelosHelice")
                        .HasForeignKey("MarcaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MarcaHelice");
                });

            modelBuilder.Entity("MVC.Models.Entities.ModeloMotor", b =>
                {
                    b.HasOne("MVC.Models.Entities.MarcaMotor", "MarcaMotor")
                        .WithMany("ModelosMotor")
                        .HasForeignKey("MarcaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MarcaMotor");
                });

            modelBuilder.Entity("MVC.Models.Entities.Motor", b =>
                {
                    b.HasOne("MVC.Models.Entities.Aeronave", "Aeronave")
                        .WithMany("Motores")
                        .HasForeignKey("AvionID");

                    b.HasOne("MVC.Models.Entities.Helice", "Helice")
                        .WithMany()
                        .HasForeignKey("HeliceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC.Models.Entities.ModeloMotor", "ModeloMotor")
                        .WithMany("Motores")
                        .HasForeignKey("ModeloID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aeronave");

                    b.Navigation("Helice");

                    b.Navigation("ModeloMotor");
                });

            modelBuilder.Entity("MVC.Models.Entities.Seguimiento", b =>
                {
                    b.HasOne("MVC.Models.Entities.Componente", null)
                        .WithMany("Seguimiento")
                        .HasForeignKey("ComponenteID");

                    b.HasOne("MVC.Models.Entities.Helice", null)
                        .WithMany("Seguimiento")
                        .HasForeignKey("HeliceID");

                    b.HasOne("MVC.Models.Entities.Motor", null)
                        .WithMany("Seguimiento")
                        .HasForeignKey("MotorID");
                });

            modelBuilder.Entity("MVC.Models.Entities.Aeronave", b =>
                {
                    b.Navigation("Componentes");

                    b.Navigation("Motores");
                });

            modelBuilder.Entity("MVC.Models.Entities.Catalogo", b =>
                {
                    b.Navigation("Componentes");
                });

            modelBuilder.Entity("MVC.Models.Entities.Componente", b =>
                {
                    b.Navigation("Seguimiento");
                });

            modelBuilder.Entity("MVC.Models.Entities.Helice", b =>
                {
                    b.Navigation("Seguimiento");
                });

            modelBuilder.Entity("MVC.Models.Entities.MarcaAeronave", b =>
                {
                    b.Navigation("ModelosAeronave");
                });

            modelBuilder.Entity("MVC.Models.Entities.MarcaHelice", b =>
                {
                    b.Navigation("ModelosHelice");
                });

            modelBuilder.Entity("MVC.Models.Entities.MarcaMotor", b =>
                {
                    b.Navigation("ModelosMotor");
                });

            modelBuilder.Entity("MVC.Models.Entities.ModeloAeronave", b =>
                {
                    b.Navigation("Aeronaves");
                });

            modelBuilder.Entity("MVC.Models.Entities.ModeloHelice", b =>
                {
                    b.Navigation("Helices");
                });

            modelBuilder.Entity("MVC.Models.Entities.ModeloMotor", b =>
                {
                    b.Navigation("Motores");
                });

            modelBuilder.Entity("MVC.Models.Entities.Motor", b =>
                {
                    b.Navigation("Seguimiento");
                });

            modelBuilder.Entity("MVC.Models.Entities.TipoComponente", b =>
                {
                    b.Navigation("Catalogos");
                });
#pragma warning restore 612, 618
        }
    }
}
