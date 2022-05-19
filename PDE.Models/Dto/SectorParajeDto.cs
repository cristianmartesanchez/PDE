using System;
using System.Collections.Generic;

namespace PDE.Models.Dto
{
    public partial class SectorParajeDto
    {
        public SectorParajeDto()
        {
            Recintos = new HashSet<RecintoDto>();
        }

        public int Id { get; set; }
        public int CiudadSeccionId { get; set; }
        public string? CodigoSector { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Oficio { get; set; }
        public string? Estatus { get; set; }
        public Guid? RegId { get; set; }

        public virtual CiudadSeccionDto CiudadSeccion { get; set; } = null!;
        public virtual ICollection<RecintoDto> Recintos { get; set; }
    }
}
