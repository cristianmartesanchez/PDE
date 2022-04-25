using System;
using System.Collections.Generic;

namespace PDE.Models.Entities.Padron
{
    public partial class Enlace
    {
        public int Id { get; set; }
        public int IdSectorParaje { get; set; }
        public int IdRecinto { get; set; }
        public int? Oficio { get; set; }
        public string? Estatus { get; set; }
        public Guid? RegId { get; set; }
    }
}
