using System;
using System.Collections.Generic;

namespace PDE.Models.Dto
{
    public partial class NacionalidadDto
    {
        public NacionalidadDto()
        {
            Miembros = new HashSet<MiembroDto>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public string? Gentilicio { get; set; }
        public string Estatus { get; set; } = null!;
        public string? Siglas { get; set; }
        public Guid? RegId { get; set; }

        public virtual ICollection<MiembroDto> Miembros { get; set; }
    }
}
