using System;
using System.Collections.Generic;

namespace PDE.Models.Dto
{
    public partial class ColegioDto
    {
        public ColegioDto()
        {
            Miembros = new HashSet<MiembroDto>();
        }

        public int Id { get; set; }
        public string CodigoColegio { get; set; } = null!;
        public int MunicipioId { get; set; }
        public string Descripcion { get; set; } = null!;
        public int RecintoId { get; set; }
        public string? TieneCupo { get; set; }
        public int? CantidadInscritos { get; set; }
        public int? CantidadReservada { get; set; }
        public Guid? RegId { get; set; }

        public virtual MunicipioDto Municipio { get; set; } = null!;
        public virtual RecintoDto Recinto { get; set; } = null!;
        public virtual ICollection<MiembroDto> Miembros { get; set; }
    }
}
