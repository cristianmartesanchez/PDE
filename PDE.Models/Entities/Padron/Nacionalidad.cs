﻿using System;
using System.Collections.Generic;

namespace PDE.Models.Entities.Padron
{
    public partial class Nacionalidad
    {
        public short Id { get; set; }
        public string? Descripcion { get; set; }
        public string? Gentilicio { get; set; }
        public string Estatus { get; set; } = null!;
        public string? Siglas { get; set; }
        public Guid? RegId { get; set; }
    }
}
