using System;
using System.Collections.Generic;

namespace PDE.Models.Entities.Padron
{
    public partial class VwCascadum
    {
        public short IdProvincia { get; set; }
        public string? DescripcionProvincia { get; set; }
        public string? Zona { get; set; }
        public int? IdmacroRegion { get; set; }
        public string? DescripcionMacroRegion { get; set; }
        public int? Idregion { get; set; }
        public string? DescripcionRegion { get; set; }
        public short IdMunicipio { get; set; }
        public string? DescripcionMunicipio { get; set; }
        public short? IdDistritoMunicipal { get; set; }
        public string? DescripcionDistritoMunicipal { get; set; }
        public short IdCiudadSeccion { get; set; }
        public string? CodigoCiudad { get; set; }
        public string? DescripcionCiudad { get; set; }
        public int IdSectorParaje { get; set; }
        public string? CodigoSector { get; set; }
        public string? DescripcionSector { get; set; }
        public string? EstatusSector { get; set; }
    }
}
