using System;
using System.Collections.Generic;

namespace PDE.Models.Entities.Padron
{
    public partial class Padron
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
    }
}
