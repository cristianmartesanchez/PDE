using System;
using System.Collections.Generic;

namespace PDE.Models.Dto
{
    public partial class CircunscripcionDto
    {
        public CircunscripcionDto()
        {
            Recintos = new HashSet<RecintoDto>();
        }

        public int Id { get; set; }
        public int ProvinciaId { get; set; }
        public string? CodigoCircunscripcion { get; set; }
        public string? Descripcion { get; set; }
        public Guid? RegId { get; set; }

        public virtual ProvinciaDto Provincia { get; set; } = null!;
        public virtual ICollection<RecintoDto> Recintos { get; set; }
    }
}
