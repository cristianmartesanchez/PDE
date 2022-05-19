using System;
using System.Collections.Generic;

namespace PDE.Models.Dto
{
    public partial class OcupacionDto
    {
        public OcupacionDto()
        {
            Miembros = new HashSet<MiembroDto>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public string? RequiereTitulo { get; set; }
        public string? Estatus { get; set; }
        public Guid? RegId { get; set; }

        public virtual ICollection<MiembroDto> Miembros { get; set; }
    }
}
