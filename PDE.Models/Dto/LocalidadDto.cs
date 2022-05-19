using System;
using System.Collections.Generic;

namespace PDE.Models.Dto
{
    public partial class LocalidadDto
    {
        public LocalidadDto()
        {
            CargoTerritorials = new HashSet<CargoTerritorialDto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<CargoTerritorialDto> CargoTerritorials { get; set; }
        public virtual ICollection<MiembroDto> Miembros { get; set;}
    }
}
