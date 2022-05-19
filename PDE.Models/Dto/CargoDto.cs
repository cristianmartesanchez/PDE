using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PDE.Models.Dto
{
    public partial class CargoDto
    {
        public CargoDto()
        {
            CargoTerritorialSupervisors = new HashSet<CargoTerritorialDto>();
            CargoTerritoriales = new HashSet<CargoTerritorialDto>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<CargoTerritorialDto> CargoTerritorialSupervisors { get; set; }
        public virtual ICollection<CargoTerritorialDto> CargoTerritoriales { get; set; }

    }
}
