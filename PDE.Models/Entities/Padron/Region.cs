using System;
using System.Collections.Generic;

namespace PDE.Models.Entities.Padron
{
    public partial class Region
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int? IdmacroRegion { get; set; }
    }
}
