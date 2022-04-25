using System;
using System.Collections.Generic;

namespace PDE.Models.Entities.Padron
{
    public partial class ElectoresHabilesFebrero
    {
        public string Cedula { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellido1 { get; set; } = null!;
        public string? Apellido2 { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? LugarNacimiento { get; set; }
        public short Idcategoria { get; set; }
        public string? IdSexo { get; set; }
        public string? IdEstadoCivil { get; set; }
        public short? IdOcupacion { get; set; }
        public short? Idnacionalidad { get; set; }
        public short? Idmunicipio { get; set; }
        public int? Idcolegio { get; set; }
        public short? IdcausaCancelacion { get; set; }
        public string? Idestatus { get; set; }
        public string? EstatusCedulaAzul { get; set; }
        public string? CedulaAnterior { get; set; }
        public string? MunCed { get; set; }
        public string? SeqCed { get; set; }
        public string? VerCed { get; set; }
        public string? CodigoColegio { get; set; }
        public string? DescripcionColegio { get; set; }
        public int? IdRecinto { get; set; }
        public string? CodigoRecinto { get; set; }
        public string? DescripcionRecinto { get; set; }
        public string? DireccionRecinto { get; set; }
        public string? EstatusRecinto { get; set; }
        public short? IdCircunscripcion { get; set; }
        public string? DescripcionCircunscripcion { get; set; }
        public short? IdProvincia { get; set; }
        public string? DescripcionProvincia { get; set; }
        public string? Zona { get; set; }
        public short? IdmunicipioElectoral { get; set; }
        public string? DescripcionMunicipio { get; set; }
        public short? IdDistritoMunicipal { get; set; }
        public string? DescripcionDistritoMunicipal { get; set; }
        public short? IdCiudadSeccion { get; set; }
        public string? CodigoCiudad { get; set; }
        public string? DescripcionCiudad { get; set; }
        public string? CodigoSector { get; set; }
        public string? DescripcionSector { get; set; }
        public string? EstatusSector { get; set; }
    }
}
