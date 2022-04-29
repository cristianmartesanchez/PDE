using System;
using System.Collections.Generic;

namespace PDE.Models.Entities
{
    public partial class MacroRegion
    {
        public MacroRegion()
        {
            Regions = new HashSet<Region>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public Guid? RegId { get; set; }

        public virtual ICollection<Region> Regions { get; set; }
    }
}
