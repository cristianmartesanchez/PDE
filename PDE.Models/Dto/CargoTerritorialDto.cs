using System;
using System.Collections.Generic;

namespace PDE.Models.Dto
{
    public partial class CargoTerritorialDto
    {
        public int Id { get; set; }
        public int CargoId { get; set; }
        public int? CargoSupervisorId { get; set; }
        public int LocalidadId { get; set; }
        public int EstructuraId { get; set; }

        public virtual CargoDto Cargo { get; set; } = null!;
        public virtual CargoDto CargoSupervisor { get; set; } = null!;
        public virtual LocalidadDto Localidad { get; set; } = null!;
        public virtual EstructuraDto Estructura { get; set; } = null!;
    }
}
