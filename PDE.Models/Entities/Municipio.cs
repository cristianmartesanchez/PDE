using System;
using System.Collections.Generic;

namespace PDE.Models.Entities
{
    public partial class Municipio
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int ProvinciaId { get; set; }
        public int? MunicipioPadreId { get; set; }
        public double? Oficio { get; set; }
        public string? Estatus { get; set; }
        public string? Dm { get; set; }
        public int? IdUsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public Guid? RegId { get; set; }
    }
}
