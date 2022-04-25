using System;
using System.Collections.Generic;

namespace PDE.Models.Entities.Padron
{
    public partial class EstadoCivil
    {
        public string Id { get; set; } = null!;
        public string? Descripcion { get; set; }
        public Guid? RegId { get; set; }
    }
}
