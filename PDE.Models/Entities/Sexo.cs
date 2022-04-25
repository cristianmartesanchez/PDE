using System;
using System.Collections.Generic;

namespace PDE.Models.Entities
{
    public partial class Sexo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? IdUsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public Guid? RegId { get; set; }
    }
}
