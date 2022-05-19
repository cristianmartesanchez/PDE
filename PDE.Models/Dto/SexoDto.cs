using System;
using System.Collections.Generic;

namespace PDE.Models.Dto
{
    public partial class SexoDto
    {
        public SexoDto()
        {
            Miembros = new HashSet<MiembroDto>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public int? IdUsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public Guid? RegId { get; set; }

        public virtual ICollection<MiembroDto> Miembros { get; set; }
    }
}
