using System;
using System.Collections.Generic;

namespace PDE.Models.Entities.Padron
{
    public partial class MacroRegion
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public Guid? RegId { get; set; }
    }
}
