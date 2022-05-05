using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PDE.Models.Entities
{
    public partial class Cargo
    {
        public Cargo()
        {
            CargoTerritorialSupervisors = new HashSet<CargoTerritorial>();
            CargoTerritoriales = new HashSet<CargoTerritorial>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<CargoTerritorial> CargoTerritorialSupervisors { get; set; }
        public virtual ICollection<CargoTerritorial> CargoTerritoriales { get; set; }

    }
}
