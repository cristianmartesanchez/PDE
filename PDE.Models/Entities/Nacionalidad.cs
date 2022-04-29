using System;
using System.Collections.Generic;

namespace PDE.Models.Entities
{
    public partial class Nacionalidad
    {
        public Nacionalidad()
        {
            Miembros = new HashSet<Miembro>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public string? Gentilicio { get; set; }
        public string Estatus { get; set; } = null!;
        public string? Siglas { get; set; }
        public Guid? RegId { get; set; }

        public virtual ICollection<Miembro> Miembros { get; set; }
    }
}
