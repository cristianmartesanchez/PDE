using System;
using System.Collections.Generic;

namespace PDE.Models.Entities
{
    public partial class Region
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public int? MacroRegionId { get; set; }

        public virtual MacroRegion? MacroRegion { get; set; }
    }
}
