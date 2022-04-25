using System;
using System.Collections.Generic;

namespace PDE.Models.Entities.Padron
{
    public partial class ConcurrenciaFeb2020
    {
        public string Cedula { get; set; } = null!;
        public DateTime? FechaNacimiento { get; set; }
        public string? IdSexo { get; set; }
        public string? IdEstadoCivil { get; set; }
        public string ValorFinal { get; set; } = null!;
    }
}
