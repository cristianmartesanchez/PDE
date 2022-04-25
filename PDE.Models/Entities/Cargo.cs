using System;
using System.Collections.Generic;

namespace PDE.Models.Entities
{
    public partial class Cargo
    {
        public Cargo()
        {
            CargoTerritorialCargos = new HashSet<CargoTerritorial>();
            CargoTerritorialSupervisors = new HashSet<CargoTerritorial>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<CargoTerritorial> CargoTerritorialCargos { get; set; }
        public virtual ICollection<CargoTerritorial> CargoTerritorialSupervisors { get; set; }
    }
}
