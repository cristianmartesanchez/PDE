using System;
using System.Collections.Generic;

namespace PDE.Models.Entities
{
    public partial class Circunscripcion
    {
        public Circunscripcion()
        {
            Recintos = new HashSet<Recinto>();
        }

        public int Id { get; set; }
        public int ProvinciaId { get; set; }
        public string? CodigoCircunscripcion { get; set; }
        public string? Descripcion { get; set; }
        public Guid? RegId { get; set; }

        public virtual Provincia Provincia { get; set; } = null!;
        public virtual ICollection<Recinto> Recintos { get; set; }
    }
}
