﻿using System;
using System.Collections.Generic;

namespace PDE.Models.Entities
{
    public partial class Recinto
    {
        public Recinto()
        {
            Colegios = new HashSet<Colegio>();
        }

        public int Id { get; set; }
        public string? CodigoRecinto { get; set; }
        public string? Descripcion { get; set; }
        public string? Direccion { get; set; }
        public int? SectorParajeId { get; set; }
        public int? CircunscripcionId { get; set; }
        public int? BarrioId { get; set; }
        public int? CapacidadRecinto { get; set; }
        public int? Oficio { get; set; }
        public string? Estatus { get; set; }
        public string? DescripcionLarga { get; set; }
        public string? DireccionLarga { get; set; }
        public string? Tipo { get; set; }
        public short? Codigo { get; set; }
        public Guid? RegId { get; set; }

        public virtual Circunscripcion? Circunscripcion { get; set; }
        public virtual SectorParaje? SectorParaje { get; set; }
        public virtual ICollection<Colegio> Colegios { get; set; }
    }
}
