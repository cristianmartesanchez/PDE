using System;
using System.Collections.Generic;

namespace PDE.Models.Entities
{
    public partial class Provincia
    {
        public Provincia()
        {
            Circunscripcions = new HashSet<Circunscripcion>();
            Municipios = new HashSet<Municipio>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int? MunicipioCabeceraId { get; set; }
        public decimal? Oficio { get; set; }
        public string? Estatus { get; set; }
        public string? Zona { get; set; }
        public Guid? RegId { get; set; }
        public int? RegionId { get; set; }

        public virtual Region? Region { get; set; }

        public virtual ICollection<Circunscripcion> Circunscripcions { get; set; }
        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}
