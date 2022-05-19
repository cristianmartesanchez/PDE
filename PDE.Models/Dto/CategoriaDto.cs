using System;
using System.Collections.Generic;

namespace PDE.Models.Dto
{
    public partial class CategoriaDto
    {
        public CategoriaDto()
        {
            Miembros = new HashSet<MiembroDto>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public string? LlevaColegio { get; set; }
        public string? PuedeVotar { get; set; }
        public string? LlevaDatosActa { get; set; }
        public string? LlevaDatosPasaporte { get; set; }

        public virtual ICollection<MiembroDto> Miembros { get; set; }
    }
}
