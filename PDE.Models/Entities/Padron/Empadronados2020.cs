using System;
using System.Collections.Generic;

namespace PDE.Models.Entities.Padron
{
    public partial class Empadronados2020
    {
        public string Cedula { get; set; } = null!;
        public int? PaisCodigo { get; set; }
        public string? PaisNombre { get; set; }
        public int? CodNivel1 { get; set; }
        public string? Nivel1 { get; set; }
        public int? CodNivel2 { get; set; }
        public string? Nivel2 { get; set; }
        public int? CodNivel3 { get; set; }
        public string? Nivel3 { get; set; }
        public string? ZonaPostal { get; set; }
        public string? Empadronado { get; set; }
        public int? IdAreaTrabajo { get; set; }
        public string EtiquetaNivel1 { get; set; } = null!;
        public string EtiquetaNivel2 { get; set; } = null!;
        public string EtiquetaNivel3 { get; set; } = null!;
        public short? IdcausaCancelacion { get; set; }
        public string? EmpadronadoSugerencia { get; set; }
        public string? Padron { get; set; }
    }
}
