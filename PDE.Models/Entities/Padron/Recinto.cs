using System;
using System.Collections.Generic;

namespace PDE.Models.Entities.Padron
{
    public partial class Recinto
    {
        public int Id { get; set; }
        public string? CodigoRecinto { get; set; }
        public string? Descripcion { get; set; }
        public string? Direccion { get; set; }
        public int? IdsectorParaje { get; set; }
        public short? Idcircunscripcion { get; set; }
        public int? Idbarrio { get; set; }
        public int? CapacidadRecinto { get; set; }
        public int? Oficio { get; set; }
        public string? Estatus { get; set; }
        public string? DescripcionLarga { get; set; }
        public string? DireccionLarga { get; set; }
        public string? Tipo { get; set; }
        public short? Codigo { get; set; }
        public Guid? RegId { get; set; }
    }
}
