using System;
using System.Collections.Generic;

namespace PDE.Models.Entities.Padron
{
    public partial class VwRecintoCascadum
    {
        public int IdRecinto { get; set; }
        public string? CodigoRecinto { get; set; }
        public string? DescripcionRecinto { get; set; }
        public string? DireccionRecinto { get; set; }
        public string? EstatusRecinto { get; set; }
        public short? IdCircunscripcion { get; set; }
        public string? DescripcionCircunscripcion { get; set; }
        public short? IdProvincia { get; set; }
        public string? DescripcionProvincia { get; set; }
        public string? Zona { get; set; }
        public short? IdMunicipio { get; set; }
        public string? DescripcionMunicipio { get; set; }
        public short? IdDistritoMunicipal { get; set; }
        public string? DescripcionDistritoMunicipal { get; set; }
        public short? IdCiudadSeccion { get; set; }
        public string? CodigoCiudad { get; set; }
        public string? DescripcionCiudad { get; set; }
        public int? IdSectorParaje { get; set; }
        public string? CodigoSector { get; set; }
        public string? DescripcionSector { get; set; }
        public string? EstatusSector { get; set; }
        public string? Codigocircunscripcion { get; set; }
    }
}
