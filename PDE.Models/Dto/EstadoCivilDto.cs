using System;
using System.Collections.Generic;

namespace PDE.Models.Dto
{
    public partial class EstadoCivilDto
    {
        public EstadoCivilDto()
        {
            Miembros = new HashSet<MiembroDto>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public Guid? RegId { get; set; }

        public virtual ICollection<MiembroDto> Miembros { get; set; }
    }
}
