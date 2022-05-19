using System;
using System.Collections.Generic;

namespace PDE.Models.Dto
{
    public partial class CiudadSeccionDto
    {
        public CiudadSeccionDto()
        {
            SectorParajes = new HashSet<SectorParajeDto>();
        }

        public int Id { get; set; }
        public int MunicipioId { get; set; }
        public int? DistritoMunicipalId { get; set; }
        public string? CodigoCiudad { get; set; }
        public string? Descripcion { get; set; }
        public long? Oficio { get; set; }
        public string? Estatus { get; set; }
        public Guid? RegId { get; set; }

        public virtual MunicipioDto Municipio { get; set; } = null!;
        public virtual ICollection<SectorParajeDto> SectorParajes { get; set; }
    }
}
