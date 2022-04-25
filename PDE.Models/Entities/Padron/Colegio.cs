using System;
using System.Collections.Generic;

namespace PDE.Models.Entities.Padron
{
    public partial class Colegio
    {
        public int Idcolegio { get; set; }
        public string CodigoColegio { get; set; } = null!;
        public short Idmunicipio { get; set; }
        public string Descripcion { get; set; } = null!;
        public int Idrecinto { get; set; }
        public string? TieneCupo { get; set; }
        public int? CantidadInscritos { get; set; }
        public int? CantidadReservada { get; set; }
        public Guid? RegId { get; set; }
    }
}
