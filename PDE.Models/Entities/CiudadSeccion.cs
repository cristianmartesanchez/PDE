using System;
using System.Collections.Generic;

namespace PDE.Models.Entities
{
    public partial class CiudadSeccion
    {
        public CiudadSeccion()
        {
            SectorParajes = new HashSet<SectorParaje>();
        }

        public int Id { get; set; }
        public int MunicipioId { get; set; }
        public int? DistritoMunicipalId { get; set; }
        public string? CodigoCiudad { get; set; }
        public string? Descripcion { get; set; }
        public long? Oficio { get; set; }
        public string? Estatus { get; set; }
        public Guid? RegId { get; set; }

        public virtual Municipio Municipio { get; set; } = null!;
        public virtual ICollection<SectorParaje> SectorParajes { get; set; }
    }
}
