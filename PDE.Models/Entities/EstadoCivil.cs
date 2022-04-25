using System;
using System.Collections.Generic;

namespace PDE.Models.Entities
{
    public partial class EstadoCivil
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public Guid? RegId { get; set; }
    }
}
