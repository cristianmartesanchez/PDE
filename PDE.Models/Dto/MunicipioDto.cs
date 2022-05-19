using System;
using System.Collections.Generic;

namespace PDE.Models.Dto
{
    public partial class MunicipioDto
    {
        public MunicipioDto()
        {
            CiudadSeccions = new HashSet<CiudadSeccionDto>();
            Colegios = new HashSet<ColegioDto>();
            Miembros = new HashSet<MiembroDto>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int ProvinciaId { get; set; }
        public int? MunicipioPadreId { get; set; }
        public decimal? Oficio { get; set; }
        public string? Estatus { get; set; }
        public string? Dm { get; set; }
        public Guid? RegId { get; set; }

        public virtual ProvinciaDto Provincia { get; set; } = null!;
        public virtual ICollection<CiudadSeccionDto> CiudadSeccions { get; set; }
        public virtual ICollection<ColegioDto> Colegios { get; set; }
        public virtual ICollection<MiembroDto> Miembros { get; set; }
    }
}
