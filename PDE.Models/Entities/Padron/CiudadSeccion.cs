using System;
using System.Collections.Generic;

namespace PDE.Models.Entities.Padron
{
    public partial class CiudadSeccion
    {
        public short Id { get; set; }
        public short Idmunicipio { get; set; }
        public short? IddistritoMunicipal { get; set; }
        public string? CodigoCiudad { get; set; }
        public string? Descripcion { get; set; }
        public long? Oficio { get; set; }
        public string? Estatus { get; set; }
        public int? IdUsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public Guid? RegId { get; set; }
    }
}
