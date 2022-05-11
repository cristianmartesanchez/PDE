﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PDE.Models.Entities
{
    public partial class Miembro
    {
        public Miembro()
        {
            InverseSupervisor = new HashSet<Miembro>();            
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

        public virtual Cargo Cargo { get; set; } = null!;
        public virtual Estructura Estructura { get; set; } = null!;
        public virtual Categoria Categoria { get; set; } = null!;
        public virtual Colegio Colegio { get; set; } = null!;
        public virtual EstadoCivil EstadoCivil { get; set; } = null!;
        public virtual Municipio Municipio { get; set; } = null!;
        public virtual Nacionalidad Nacionalidad { get; set; } = null!;
        public virtual Ocupacion Ocupacion { get; set; } = null!;
        public virtual Sexo Sexo { get; set; } = null!;
        public virtual Miembro Supervisor { get; set; } = null!;
        public virtual Localidad Localidad { get; set; } = null!;
        public virtual ICollection<Miembro> InverseSupervisor { get; set; } = null!;
    }
}
