using System;
using System.Collections.Generic;

namespace PDE.Models.Entities
{
    public partial class Miembro
    {
        public Miembro()
        {
            InverseSupervisor = new HashSet<Miembro>();
        }

        public int Id { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string? LugarNacimiento { get; set; }
        public string Celular { get; set; } = null!;
        public int? SupervisorId { get; set; }
        public int CargoTerritorialId { get; set; }
        public int? CategoriaId { get; set; }
        public int? SexoId { get; set; }
        public int? EstadoCivilId { get; set; }
        public int? OcupacionId { get; set; }
        public int? NacionalidadId { get; set; }
        public int? MunicipioId { get; set; }
        public int? ColegioId { get; set; }

        public virtual CargoTerritorial? CargoTerritorial { get; set; }
        public virtual Miembro? Supervisor { get; set; }
        public virtual ICollection<Miembro> InverseSupervisor { get; set; }
        public virtual Categoria? Categoria { get; set; }
        public virtual Sexo? Sexo { get; set; }
        public virtual EstadoCivil? EstadoCivil { get; set; }
        public virtual Ocupacion? Ocupacion { get; set; }
        public virtual Nacionalidad? Nacionalidad { get; set; }
        public virtual Municipio? Municipio { get; set; }

    }
}
