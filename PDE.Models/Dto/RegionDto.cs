using System;
using System.Collections.Generic;

namespace PDE.Models.Dto
{
    public partial class RegionDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public int? MacroRegionId { get; set; }

        public virtual MacroRegionDto? MacroRegion { get; set; }
    }
}
