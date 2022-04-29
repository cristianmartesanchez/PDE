using System;
using System.Collections.Generic;

namespace PDE.Models.Entities
{
    public partial class EstadoCivil
    {
        public EstadoCivil()
        {
            Miembros = new HashSet<Miembro>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public Guid? RegId { get; set; }

        public virtual ICollection<Miembro> Miembros { get; set; }
    }
}
