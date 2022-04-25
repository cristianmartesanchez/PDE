using System;
using System.Collections.Generic;

namespace PDE.Models.Entities.Padron
{
    public partial class SectorParaje
    {
        public int Id { get; set; }
        public short IdciudadSeccion { get; set; }
        public string? CodigoSector { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Oficio { get; set; }
        public string? Estatus { get; set; }
        public Guid? RegId { get; set; }
    }
}
