using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PDE.Models.Entities;

namespace PDE.DataAccess
{
    public partial class DBPDEContext : DbContext
    {
        public DBPDEContext()
        {
        }

        public DBPDEContext(DbContextOptions<DBPDEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cargo> Cargos { get; set; } = null!;
        public virtual DbSet<CargoTerritorial> CargoTerritorials { get; set; } = null!;
        public virtual DbSet<Localidad> Localidads { get; set; } = null!;
        public virtual DbSet<Miembro> Miembros { get; set; } = null!;
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Colegio> Colegios { get; set; }
        public virtual DbSet<EstadoCivil> EstadoCiviles { get; set; } = null!;
        public virtual DbSet<Municipio> Municipios { get; set; } = null!;
        public virtual DbSet<Nacionalidad> Nacionalidads { get; set; } = null!;
        public virtual DbSet<Ocupacion> Ocupacions { get; set; } = null!;
        public virtual DbSet<Sexo> Sexo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-35GKIRV;Database=db_PDE;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.ToTable("Cargo");

                entity.Property(e => e.Descripcion).HasMaxLength(50);
            });

            modelBuilder.Entity<CargoTerritorial>(entity =>
            {
                entity.ToTable("CargoTerritorial");

                entity.HasOne(d => d.Cargo)
                    .WithMany(p => p.CargoTerritorialCargos)
                    .HasForeignKey(d => d.CargoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CargoTerritorial_Cargo");

                entity.HasOne(d => d.Localidad)
                    .WithMany(p => p.CargoTerritorials)
                    .HasForeignKey(d => d.LocalidadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CargoTerritorial_Localidad");

                entity.HasOne(d => d.Supervisor)
                    .WithMany(p => p.CargoTerritorialSupervisors)
                    .HasForeignKey(d => d.SupervisorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CargoTerritorial_SupervisorId");
            });

            modelBuilder.Entity<Localidad>(entity =>
            {
                entity.ToTable("Localidad");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Miembro>(entity =>
            {
                entity.ToTable("Miembro");

                entity.Property(e => e.Apellidos).HasMaxLength(60);

                entity.Property(e => e.Cedula).HasMaxLength(11);

                entity.Property(e => e.Celular)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Nombres).HasMaxLength(60);


                entity.HasOne(d => d.Supervisor)
                    .WithMany(p => p.InverseSupervisor)
                    .HasForeignKey(d => d.SupervisorId)
                    .HasConstraintName("FK_Miembro_Miembro");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
