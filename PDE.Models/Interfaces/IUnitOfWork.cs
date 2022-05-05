using PDE.Models.Interfaces.Padron;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDE.Models.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPadronRepository Padron { get; }
        IMiembrosRepository Miembros { get; set; }
        ICargosTerritorialesRepository CargosTerritoriales { get; set; }
        ICategoriaRepository Categoria { get; set; }
        IMunicipioRepository Municipio { get; set; }    
        INacionalidadRepository Nacionalidad { get; set; }
        IOcupacionRepository Ocupacion { get; set; }
        IColegioRepository Colegio { get; set; }
        ISexoRepository Sexo { get; set; }
        IEstadoCivilRepository EstadoCivil { get; set; }
        ICargoRepository Cargo { get; set; }
        ILocalidadRepository Localidad { get; set; }
        IProvinciaRepository Provincia { get; set; }
        IEstructuraRepository Estructura { get; set; }
        Task Save();
    }
}
