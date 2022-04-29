using System;
using System.Collections.Generic;

namespace PDE.Models.Entities
{
    public partial class SectorParaje
    {
        public SectorParaje()
        {
            Recintos = new HashSet<Recinto>();
        }

        public int Id { get; set; }
        public int CiudadSeccionId { get; set; }
        public string? CodigoSector { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Oficio { get; set; }
        public string? Estatus { get; set; }
        public Guid? RegId { get; set; }

        public virtual CiudadSeccion CiudadSeccion { get; set; } = null!;
        public virtual ICollection<Recinto> Recintos { get; set; }
    }
}
