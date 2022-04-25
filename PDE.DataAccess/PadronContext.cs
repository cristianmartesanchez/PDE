using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PDE.Models.Entities.Padron;

namespace PDE.DataAccess
{
    public partial class PadronContext : DbContext
    {

        public PadronContext() { }

        public PadronContext(DbContextOptions<PadronContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CancelacionTipoCausa> CancelacionTipoCausas { get; set; } = null!;
        public virtual DbSet<Categorias> Categoria { get; set; } = null!;
        public virtual DbSet<CausaCancelacion> CausaCancelacions { get; set; } = null!;
        public virtual DbSet<Circunscripcion> Circunscripcions { get; set; } = null!;
        public virtual DbSet<CiudadSeccion> CiudadSeccions { get; set; } = null!;
        public virtual DbSet<Colegio> Colegios { get; set; } = null!;
        public virtual DbSet<ConcurrenciaFeb2020> ConcurrenciaFeb2020s { get; set; } = null!;
        public virtual DbSet<ConcurrenciaJul2020> ConcurrenciaJul2020s { get; set; } = null!;
        public virtual DbSet<ElectoresHabilesFebrero> ElectoresHabilesFebreros { get; set; } = null!;
        public virtual DbSet<ElectoresHabilesMayo> ElectoresHabilesMayos { get; set; } = null!;
        public virtual DbSet<Empadronados2020> Empadronados2020s { get; set; } = null!;
        public virtual DbSet<Enlace> Enlaces { get; set; } = null!;
        public virtual DbSet<EstadoCivil> EstadoCivils { get; set; } = null!;
        public virtual DbSet<MacroRegion> MacroRegions { get; set; } = null!;
        public virtual DbSet<Municipio> Municipios { get; set; } = null!;
        public virtual DbSet<Nacionalidad> Nacionalidads { get; set; } = null!;
        public virtual DbSet<NuevosDesempadronado> NuevosDesempadronados { get; set; } = null!;
        public virtual DbSet<NuevosEmpadronado> NuevosEmpadronados { get; set; } = null!;
        public virtual DbSet<Ocupacion> Ocupacions { get; set; } = null!;
        public virtual DbSet<Padron> Padrons { get; set; } = null!;
        public virtual DbSet<Provincium> Provincia { get; set; } = null!;
        public virtual DbSet<Recinto> Recintos { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;
        public virtual DbSet<SectorParaje> SectorParajes { get; set; } = null!;
        public virtual DbSet<Sexo> Sexos { get; set; } = null!;
        public virtual DbSet<VwCascadum> VwCascada { get; set; } = null!;
        public virtual DbSet<VwColegioCascadum> VwColegioCascada { get; set; } = null!;
        public virtual DbSet<VwRecintoCascadum> VwRecintoCascada { get; set; } = null!;
        public virtual DbSet<Zona> Zonas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-35GKIRV;Database=dbPadron2024_20210917;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_AltDiction_CP850_CI_AI");

            modelBuilder.Entity<CancelacionTipoCausa>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CancelacionTipoCausa");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RegId).HasColumnName("RegID");
            });

            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LlevaColegio)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LlevaDatosActa)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LlevaDatosPasaporte)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PuedeVotar)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RegId).HasColumnName("RegID");
            });

            modelBuilder.Entity<CausaCancelacion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CausaCancelacion");

                entity.Property(e => e.AfectaColegio)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion2016)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DobleEscaneo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdtipoCausaCancelacion).HasColumnName("IDTipoCausaCancelacion");

                entity.Property(e => e.RegId).HasColumnName("RegID");

                entity.Property(e => e.TipoRegistro)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TituloReporte)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TituloReporteCancelacion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TituloReporteRevalidacion)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Circunscripcion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Circunscripcion");

                entity.Property(e => e.CodigoCircunscripcion)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idprovincia).HasColumnName("IDProvincia");

                entity.Property(e => e.RegId).HasColumnName("RegID");
            });

            modelBuilder.Entity<CiudadSeccion>(entity =>
            {
                entity.HasNoKey();

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

                entity.Property(e => e.FechaCreacion).HasColumnType("smalldatetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("smalldatetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IddistritoMunicipal).HasColumnName("IDDistritoMunicipal");

                entity.Property(e => e.Idmunicipio).HasColumnName("IDMunicipio");

                entity.Property(e => e.RegId).HasColumnName("RegID");
            });

            modelBuilder.Entity<Colegio>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Colegio");

                entity.Property(e => e.CodigoColegio)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Idcolegio).HasColumnName("IDColegio");

                entity.Property(e => e.Idmunicipio).HasColumnName("IDMunicipio");

                entity.Property(e => e.Idrecinto).HasColumnName("IDRecinto");

                entity.Property(e => e.RegId).HasColumnName("RegID");

                entity.Property(e => e.TieneCupo)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ConcurrenciaFeb2020>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ConcurrenciaFeb2020");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("smalldatetime");

                entity.Property(e => e.IdEstadoCivil)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IdSexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ValorFinal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ConcurrenciaJul2020>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ConcurrenciaJul2020");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("smalldatetime");

                entity.Property(e => e.IdEstadoCivil)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IdSexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ValorFinal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ElectoresHabilesFebrero>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ElectoresHabilesFebrero");

                entity.Property(e => e.Apellido1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.CedulaAnterior)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoCiudad)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoColegio)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoRecinto)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoSector)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionCircunscripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionCiudad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionColegio)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionDistritoMunicipal)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionMunicipio)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionProvincia)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionRecinto)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionSector)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionRecinto)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusCedulaAzul)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EstatusRecinto)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusSector)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaNacimiento).HasPrecision(3);

                entity.Property(e => e.IdEstadoCivil)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IdSexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Idcategoria).HasColumnName("IDCategoria");

                entity.Property(e => e.IdcausaCancelacion).HasColumnName("IDCausaCancelacion");

                entity.Property(e => e.Idcolegio).HasColumnName("IDColegio");

                entity.Property(e => e.Idestatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IDEstatus")
                    .IsFixedLength();

                entity.Property(e => e.Idmunicipio).HasColumnName("IDMunicipio");

                entity.Property(e => e.IdmunicipioElectoral).HasColumnName("IDMunicipioElectoral");

                entity.Property(e => e.Idnacionalidad).HasColumnName("IDNacionalidad");

                entity.Property(e => e.LugarNacimiento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MunCed)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("mun_ced");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SeqCed)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("seq_ced");

                entity.Property(e => e.VerCed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ver_ced");

                entity.Property(e => e.Zona)
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ElectoresHabilesMayo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ElectoresHabilesMayo");

                entity.Property(e => e.Apellido1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.CedulaAnterior)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoCiudad)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoColegio)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoRecinto)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoSector)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionCircunscripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionCiudad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionColegio)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionDistritoMunicipal)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionMunicipio)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionProvincia)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionRecinto)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionSector)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionRecinto)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusCedulaAzul)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EstatusRecinto)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusSector)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaNacimiento).HasPrecision(3);

                entity.Property(e => e.IdEstadoCivil)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IdSexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Idcategoria).HasColumnName("IDCategoria");

                entity.Property(e => e.IdcausaCancelacion).HasColumnName("IDCausaCancelacion");

                entity.Property(e => e.Idcolegio).HasColumnName("IDColegio");

                entity.Property(e => e.Idestatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IDEstatus")
                    .IsFixedLength();

                entity.Property(e => e.Idmunicipio).HasColumnName("IDMunicipio");

                entity.Property(e => e.IdmunicipioElectoral).HasColumnName("IDMunicipioElectoral");

                entity.Property(e => e.Idnacionalidad).HasColumnName("IDNacionalidad");

                entity.Property(e => e.LugarNacimiento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MunCed)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("mun_ced");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SeqCed)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("seq_ced");

                entity.Property(e => e.VerCed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ver_ced");

                entity.Property(e => e.Zona)
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empadronados2020>(entity =>
            {
                entity.HasKey(e => e.Cedula);

                entity.ToTable("Empadronados2020");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Empadronado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmpadronadoSugerencia)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EtiquetaNivel1)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.EtiquetaNivel2)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.EtiquetaNivel3)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.IdcausaCancelacion).HasColumnName("IDCausaCancelacion");

                entity.Property(e => e.Nivel1)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Nivel2)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Nivel3)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Padron)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PaisNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZonaPostal)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Enlace>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Enlace");

                entity.Property(e => e.Estatus)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RegId).HasColumnName("RegID");
            });

            modelBuilder.Entity<EstadoCivil>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EstadoCivil");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RegId).HasColumnName("RegID");
            });

            modelBuilder.Entity<MacroRegion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MacroRegion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RegId).HasColumnName("RegID");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.HasNoKey();

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

                entity.Property(e => e.FechaCreacion).HasColumnType("smalldatetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("smalldatetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdmunicipioPadre).HasColumnName("IDMunicipioPadre");

                entity.Property(e => e.Idprovincia).HasColumnName("IDProvincia");

                entity.Property(e => e.Oficio).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RegId).HasColumnName("RegID");
            });

            modelBuilder.Entity<Nacionalidad>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Nacionalidad");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Gentilicio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RegId).HasColumnName("RegID");

                entity.Property(e => e.Siglas)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<NuevosDesempadronado>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Cedula)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("cedula");
            });

            modelBuilder.Entity<NuevosEmpadronado>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Cedula)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Empadronado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EtiquetaNivel1)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.EtiquetaNivel2)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.EtiquetaNivel3)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Nivel1)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Nivel2)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Nivel3)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PaisNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZonaPostal)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ocupacion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ocupacion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RegId).HasColumnName("RegID");

                entity.Property(e => e.RequiereTitulo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Padron>(entity =>
            {
                entity.HasKey(e => e.Cedula);

                entity.ToTable("PADRON");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido1)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CedulaAnterior)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusCedulaAzul)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaNacimiento).HasPrecision(3);

                entity.Property(e => e.IdEstadoCivil)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IdSexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Idcategoria).HasColumnName("IDCategoria");

                entity.Property(e => e.IdcausaCancelacion).HasColumnName("IDCausaCancelacion");

                entity.Property(e => e.Idcolegio).HasColumnName("IDColegio");

                entity.Property(e => e.Idestatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IDEstatus")
                    .IsFixedLength();

                entity.Property(e => e.Idmunicipio).HasColumnName("IDMunicipio");

                entity.Property(e => e.Idnacionalidad).HasColumnName("IDNacionalidad");

                entity.Property(e => e.LugarNacimiento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MunCed)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("mun_ced");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SeqCed)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("seq_ced");

                entity.Property(e => e.VerCed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ver_ced");
            });

            modelBuilder.Entity<Provincium>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdmunicipioCabecera).HasColumnName("IDMunicipioCabecera");

                entity.Property(e => e.Oficio).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RegId).HasColumnName("RegID");

                entity.Property(e => e.Zona)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("ZONA");
            });

            modelBuilder.Entity<Recinto>(entity =>
            {
                entity.HasNoKey();

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

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idbarrio).HasColumnName("IDBarrio");

                entity.Property(e => e.Idcircunscripcion).HasColumnName("IDCircunscripcion");

                entity.Property(e => e.IdsectorParaje).HasColumnName("IDSectorParaje");

                entity.Property(e => e.RegId).HasColumnName("RegID");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Region");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdmacroRegion).HasColumnName("IDMacroRegion");
            });

            modelBuilder.Entity<SectorParaje>(entity =>
            {
                entity.HasNoKey();

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

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdciudadSeccion).HasColumnName("IDCiudadSeccion");

                entity.Property(e => e.Oficio).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RegId).HasColumnName("RegID");
            });

            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Sexo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("smalldatetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("smalldatetime");

                entity.Property(e => e.IdSexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RegId).HasColumnName("RegID");
            });

            modelBuilder.Entity<VwCascadum>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwCascada");

                entity.Property(e => e.CodigoCiudad)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoSector)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionCiudad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionDistritoMunicipal)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionMacroRegion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionMunicipio)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionProvincia)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionRegion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionSector)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusSector)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IdmacroRegion).HasColumnName("IDMacroRegion");

                entity.Property(e => e.Idregion).HasColumnName("IDRegion");

                entity.Property(e => e.Zona)
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwColegioCascadum>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwColegioCascada");

                entity.Property(e => e.CodigoCiudad)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoColegio)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoRecinto)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoSector)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Codigocircunscripcion)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("codigocircunscripcion");

                entity.Property(e => e.DescripcionCircunscripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionCiudad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionColegio)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionDistritoMunicipal)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionMunicipio)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionProvincia)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionRecinto)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionSector)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionRecinto)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusRecinto)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusSector)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Idcolegio).HasColumnName("IDColegio");

                entity.Property(e => e.TieneCupo)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Zona)
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwRecintoCascadum>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwRecintoCascada");

                entity.Property(e => e.CodigoCiudad)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoRecinto)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoSector)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Codigocircunscripcion)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("codigocircunscripcion");

                entity.Property(e => e.DescripcionCircunscripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionCiudad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionDistritoMunicipal)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionMunicipio)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionProvincia)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionRecinto)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionSector)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionRecinto)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusRecinto)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusSector)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Zona)
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Zona>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Zona");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ID")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
