using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PDE.Models.Entities;
using PDE.Models.Entities.Identity;

namespace PDE.Persistence
{
    public partial class DBPDEContext : IdentityDbContext<IdentityUser>
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
        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<Circunscripcion> Circunscripcions { get; set; } = null!;
        public virtual DbSet<CiudadSeccion> CiudadSeccions { get; set; } = null!;
        public virtual DbSet<Colegio> Colegios { get; set; } = null!;
        public virtual DbSet<EstadoCivil> EstadoCiviles { get; set; } = null!;
        public virtual DbSet<Localidad> Localidads { get; set; } = null!;
        public virtual DbSet<MacroRegion> MacroRegions { get; set; } = null!;
        public virtual DbSet<Miembro> Miembros { get; set; } = null!;
        public virtual DbSet<Municipio> Municipios { get; set; } = null!;
        public virtual DbSet<Nacionalidad> Nacionalidads { get; set; } = null!;
        public virtual DbSet<Ocupacion> Ocupacions { get; set; } = null!;
        public virtual DbSet<Provincia> Provincia { get; set; } = null!;
        public virtual DbSet<Recinto> Recintos { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;
        public virtual DbSet<SectorParaje> SectorParajes { get; set; } = null!;
        public virtual DbSet<Sexo> Sexos { get; set; } = null!;
        public virtual DbSet<Zona> Zonas { get; set; } = null!;
        public virtual DbSet<Estructura> Estructuras { get; set; } = null!;
        public virtual DbSet<Metas> Metas { get; set; } = null!;

        public virtual DbSet<RegisterModel> RegisterModels { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-35GKIRV;Database=db_PDE02;Trusted_Connection=True;MultipleActiveResultSets=true");
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

                entity.HasIndex(e => e.CargoId, "IX_CargoTerritorial_CargoId");

                entity.HasIndex(e => e.CargoSupervisorId, "IX_CargoTerritorial_CargoSupervisorId");

                entity.HasIndex(e => e.LocalidadId, "IX_CargoTerritorial_LocalidadId");

                entity.HasOne(d => d.Cargo)
                    .WithMany(p => p.CargoTerritoriales)
                    .HasForeignKey(d => d.CargoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CargoTerritorial_Cargo");

                entity.HasOne(d => d.CargoSupervisor)
                    .WithMany(p => p.CargoTerritorialSupervisors)
                    .HasForeignKey(d => d.CargoSupervisorId)
                    .HasConstraintName("FK_CargoTerritorial_SupervisorId");

                entity.HasOne(d => d.Localidad)
                    .WithMany(p => p.CargoTerritorials)
                    .HasForeignKey(d => d.LocalidadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CargoTerritorial_Localidad");
            });

            modelBuilder.Entity<Circunscripcion>(entity =>
            {
                entity.ToTable("Circunscripcion");

                entity.Property(e => e.CodigoCircunscripcion)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegId).HasColumnName("RegID");

                entity.HasOne(d => d.Provincia)
                    .WithMany(p => p.Circunscripcions)
                    .HasForeignKey(d => d.ProvinciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Circunscripcion_Provincia");
            });

            modelBuilder.Entity<CiudadSeccion>(entity =>
            {
                entity.ToTable("CiudadSeccion");

                entity.Property(e => e.CodigoCiudad)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RegId).HasColumnName("RegID");

                entity.HasOne(d => d.Municipio)
                    .WithMany(p => p.CiudadSeccions)
                    .HasForeignKey(d => d.MunicipioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CiudadSeccion_Municipio");
            });

            modelBuilder.Entity<Colegio>(entity =>
            {
                entity.HasOne(d => d.Municipio)
                    .WithMany(p => p.Colegios)
                    .HasForeignKey(d => d.MunicipioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Colegios_Municipio");

                entity.HasOne(d => d.Recinto)
                    .WithMany(p => p.Colegios)
                    .HasForeignKey(d => d.RecintoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Colegios_Recinto");
            });

            modelBuilder.Entity<Localidad>(entity =>
            {
                entity.ToTable("Localidad");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<MacroRegion>(entity =>
            {
                entity.ToTable("MacroRegion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegId).HasColumnName("RegID");
            });

            modelBuilder.Entity<Miembro>(entity =>
            {
                entity.ToTable("Miembro");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Apellidos).HasMaxLength(50);

                entity.Property(e => e.Cedula).HasMaxLength(13);

                entity.Property(e => e.Celular).HasMaxLength(13);

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Nombres).HasMaxLength(50);

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Miembros)
                    .HasForeignKey(d => d.CategoriaId)
                    .HasConstraintName("FK_Miembro_Categorias");

                entity.HasOne(d => d.Colegio)
                    .WithMany(p => p.Miembros)
                    .HasForeignKey(d => d.ColegioId)
                    .HasConstraintName("FK_Miembro_Colegios");

                entity.HasOne(d => d.EstadoCivil)
                    .WithMany(p => p.Miembros)
                    .HasForeignKey(d => d.EstadoCivilId)
                    .HasConstraintName("FK_Miembro_EstadoCiviles");

                entity.HasOne(d => d.Municipio)
                    .WithMany(p => p.Miembros)
                    .HasForeignKey(d => d.MunicipioId)
                    .HasConstraintName("FK_Miembro_Municipio");

                entity.HasOne(d => d.Nacionalidad)
                    .WithMany(p => p.Miembros)
                    .HasForeignKey(d => d.NacionalidadId)
                    .HasConstraintName("FK_Miembro_Nacionalidads");

                entity.HasOne(d => d.Ocupacion)
                    .WithMany(p => p.Miembros)
                    .HasForeignKey(d => d.OcupacionId)
                    .HasConstraintName("FK_Miembro_Ocupacions");

                entity.HasOne(d => d.Sexo)
                    .WithMany(p => p.Miembros)
                    .HasForeignKey(d => d.SexoId)
                    .HasConstraintName("FK_Miembro_Sexo");

                entity.HasOne(d => d.Supervisor)
                    .WithMany(p => p.InverseSupervisor)
                    .HasForeignKey(d => d.SupervisorId)
                    .HasConstraintName("FK_Miembro_Miembro");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.ToTable("Municipio");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Dm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DM")
                    .IsFixedLength();

                entity.Property(e => e.Estatus)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Oficio).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RegId).HasColumnName("RegID");

                entity.HasOne(d => d.Provincia)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.ProvinciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Municipio_Provincia");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Oficio).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RegId).HasColumnName("RegID");

                entity.Property(e => e.Zona)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("ZONA");
            });

            modelBuilder.Entity<Recinto>(entity =>
            {
                entity.ToTable("Recinto");

                entity.Property(e => e.CodigoRecinto)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionLarga)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionLarga)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RegId).HasColumnName("RegID");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Circunscripcion)
                    .WithMany(p => p.Recintos)
                    .HasForeignKey(d => d.CircunscripcionId)
                    .HasConstraintName("FK_Recinto_Circunscripcion");

                entity.HasOne(d => d.SectorParaje)
                    .WithMany(p => p.Recintos)
                    .HasForeignKey(d => d.SectorParajeId)
                    .HasConstraintName("FK_Recinto_SectorParaje");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("Region");

                entity.Property(e => e.Descripcion).HasMaxLength(50);

                entity.HasOne(d => d.MacroRegion)
                    .WithMany(p => p.Regions)
                    .HasForeignKey(d => d.MacroRegionId)
                    .HasConstraintName("FK_Region_MacroRegion");
            });

            modelBuilder.Entity<SectorParaje>(entity =>
            {
                entity.ToTable("SectorParaje");

                entity.Property(e => e.CodigoSector)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Oficio).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RegId).HasColumnName("RegID");

                entity.HasOne(d => d.CiudadSeccion)
                    .WithMany(p => p.SectorParajes)
                    .HasForeignKey(d => d.CiudadSeccionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SectorParaje_CiudadSeccion");
            });

            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.ToTable("Sexo");
            });

            modelBuilder.Entity<Zona>(entity =>
            {
                entity.ToTable("Zona");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            base.OnModelCreating(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
