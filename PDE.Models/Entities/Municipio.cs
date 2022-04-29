using System;
using System.Collections.Generic;

namespace PDE.Models.Entities
{
    public partial class Municipio
    {
        public Municipio()
        {
            CiudadSeccions = new HashSet<CiudadSeccion>();
            Colegios = new HashSet<Colegio>();
            Miembros = new HashSet<Miembro>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int ProvinciaId { get; set; }
        public int? MunicipioPadreId { get; set; }
        public decimal? Oficio { get; set; }
        public string? Estatus { get; set; }
        public string? Dm { get; set; }
        public Guid? RegId { get; set; }

        public virtual Provincia Provincia { get; set; } = null!;
        public virtual ICollection<CiudadSeccion> CiudadSeccions { get; set; }
        public virtual ICollection<Colegio> Colegios { get; set; }
        public virtual ICollection<Miembro> Miembros { get; set; }
    }
}
