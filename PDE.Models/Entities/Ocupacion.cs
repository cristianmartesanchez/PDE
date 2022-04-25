using System;
using System.Collections.Generic;

namespace PDE.Models.Entities
{
    public partial class Ocupacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string? RequiereTitulo { get; set; }
        public string? Estatus { get; set; }
        public Guid? RegId { get; set; }
    }
}
