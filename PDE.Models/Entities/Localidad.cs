using System;
using System.Collections.Generic;

namespace PDE.Models.Entities
{
    public partial class Localidad
    {
        public Localidad()
        {
            CargoTerritorials = new HashSet<CargoTerritorial>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<CargoTerritorial> CargoTerritorials { get; set; }
    }
}
