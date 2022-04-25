using System;
using System.Collections.Generic;

namespace PDE.Models.Entities.Padron
{
    public partial class CancelacionTipoCausa
    {
        public short Id { get; set; }
        public string? Descripcion { get; set; }
        public string? Codigo { get; set; }
        public Guid? RegId { get; set; }
    }
}
