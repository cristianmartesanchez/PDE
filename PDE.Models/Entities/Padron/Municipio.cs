using System;
using System.Collections.Generic;

namespace PDE.Models.Entities.Padron
{
    public partial class Municipio
    {
        public short Id { get; set; }
        public string? Descripcion { get; set; }
        public short Idprovincia { get; set; }
        public short? IdmunicipioPadre { get; set; }
        public decimal? Oficio { get; set; }
        public string? Estatus { get; set; }
        public string? Dm { get; set; }
        public int? IdUsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public Guid? RegId { get; set; }
    }
}
