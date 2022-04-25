using System;
using System.Collections.Generic;

namespace PDE.Models.Entities.Padron
{
    public partial class CausaCancelacion
    {
        public short Id { get; set; }
        public short IdtipoCausaCancelacion { get; set; }
        public string? Descripcion { get; set; }
        public string? Descripcion2016 { get; set; }
        public string? AfectaColegio { get; set; }
        public short? Codigo { get; set; }
        public Guid? RegId { get; set; }
        public string? TipoRegistro { get; set; }
        public string? TituloReporteCancelacion { get; set; }
        public string? TituloReporteRevalidacion { get; set; }
        public string? TituloReporte { get; set; }
        public string? DobleEscaneo { get; set; }
    }
}
