using PDE.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDE.Models.Interfaces
{
    public interface ICargosTerritorialesRepository : IGenericRepository<CargoTerritorial>
    {
        IQueryable<CargoTerritorial> GetCargosBySupervisor(int? cargoSupervisorId = null);
        IQueryable<CargoTerritorial> GetCargoTerritoriales();
        Task<IEnumerable<CargoTerritorial>> GetCargosByLocalidad(int LocalidadId);
    }
}
