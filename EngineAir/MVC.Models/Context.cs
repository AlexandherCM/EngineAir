﻿using Microsoft.EntityFrameworkCore;
using MVC.Models.Entities;

namespace EngineAir.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public virtual DbSet<MarcaMotor> MarcaMotor { get; set; } 
        public virtual DbSet<MarcaHelice> MarcaHelice { get; set; } 
        public virtual DbSet<TipoComponente> TipoComponente { get; set; }  

        public virtual DbSet<ModeloMotor> ModeloMotor { get; set; }  
        public virtual DbSet<ModeloHelice> ModeloHelice { get; set; } 
        public virtual DbSet<Variante> Variante { get; set; }  

        public virtual DbSet<Motor> Motor { get; set; }  
        public virtual DbSet<Helice> Helice { get; set; }  
        public virtual DbSet<Componente> Componente { get; set; }   

    }
}
