using System;
using System.Collections.Generic;

namespace PDE.Models.Entities.Padron
{
    public partial class Sexo
    {
        public string IdSexo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int? IdUsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public Guid? RegId { get; set; }
    }
}
