﻿using System;
using System.Collections.Generic;

namespace PDE.Models.Entities
{
    public partial class CargoTerritorial
    {
        public int Id { get; set; }
        public int CargoId { get; set; }
        public int? CargoSupervisorId { get; set; }
        public int LocalidadId { get; set; }

        public virtual Cargo Cargo { get; set; } = null!;
        public virtual Cargo? CargoSupervisor { get; set; }
        public virtual Localidad Localidad { get; set; } = null!;
    }
}
