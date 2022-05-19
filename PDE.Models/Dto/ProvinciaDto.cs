using System;
using System.Collections.Generic;

namespace PDE.Models.Dto
{
    public partial class ProvinciaDto
    {
        public ProvinciaDto()
        {
            Circunscripcions = new HashSet<CircunscripcionDto>();
            Municipios = new HashSet<MunicipioDto>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int? MunicipioCabeceraId { get; set; }
        public decimal? Oficio { get; set; }
        public string? Estatus { get; set; }
        public string? Zona { get; set; }
        public Guid? RegId { get; set; }
        public int? RegionId { get; set; }

        public virtual RegionDto? Region { get; set; }

        public virtual ICollection<CircunscripcionDto> Circunscripcions { get; set; }
        public virtual ICollection<MunicipioDto> Municipios { get; set; }
    }
}
