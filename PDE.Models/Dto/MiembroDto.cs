using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PDE.Models.Dto
{
    public partial class MiembroDto
    {
        public MiembroDto()
        {
            InverseSupervisor = new HashSet<MiembroDto>();            
        }

        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string LugarNacimiento { get; set; }
        public string Celular { get; set; }   
        public int? SupervisorId { get; set; } = null!;
        public int? CategoriaId { get; set; }
        public int? SexoId { get; set; }
        public int? EstadoCivilId { get; set; }
        public int? OcupacionId { get; set; }
        public int? NacionalidadId { get; set; }
        public int? MunicipioId { get; set; }
        public int? ColegioId { get; set; }
        public int LocalidadId { get; set; }
        public int CargoId { get; set; }
        public int EstructuraId { get; set; }   

        public virtual CargoDto Cargo { get; set; } = null!;
        public virtual EstructuraDto Estructura { get; set; } = null!;
        public virtual CategoriaDto Categoria { get; set; } = null!;
        public virtual ColegioDto Colegio { get; set; } = null!;
        public virtual EstadoCivilDto EstadoCivil { get; set; } = null!;
        public virtual MunicipioDto Municipio { get; set; } = null!;
        public virtual NacionalidadDto Nacionalidad { get; set; } = null!;
        public virtual OcupacionDto Ocupacion { get; set; } = null!;
        public virtual SexoDto Sexo { get; set; } = null!;
        public virtual MiembroDto Supervisor { get; set; } = null!;
        public virtual LocalidadDto Localidad { get; set; } = null!;
        public virtual ICollection<MiembroDto> InverseSupervisor { get; set; } = null!;
    }
}
