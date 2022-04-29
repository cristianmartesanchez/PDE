using System;
using System.Collections.Generic;

namespace PDE.Models.Entities
{
    public partial class Colegio
    {
        public Colegio()
        {
            Miembros = new HashSet<Miembro>();
        }

        public int Id { get; set; }
        public string CodigoColegio { get; set; } = null!;
        public int MunicipioId { get; set; }
        public string Descripcion { get; set; } = null!;
        public int RecintoId { get; set; }
        public string? TieneCupo { get; set; }
        public int? CantidadInscritos { get; set; }
        public int? CantidadReservada { get; set; }
        public Guid? RegId { get; set; }

        public virtual Municipio Municipio { get; set; } = null!;
        public virtual Recinto Recinto { get; set; } = null!;
        public virtual ICollection<Miembro> Miembros { get; set; }
    }
}
