using System;
using System.Collections.Generic;

namespace PDE.Models.Dto
{
    public partial class MacroRegionDto
    {
        public MacroRegionDto()
        {
            Regions = new HashSet<RegionDto>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public Guid? RegId { get; set; }

        public virtual ICollection<RegionDto> Regions { get; set; }
    }
}
