using PDE.Models.Dto;
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
        IQueryable<CargoTerritorialDto> GetCargosBySupervisor(int? cargoSupervisorId = null);
        IQueryable<CargoTerritorialDto> GetCargoTerritoriales();
        Task<IEnumerable<CargoTerritorialDto>> GetCargosByLocalidad(int LocalidadId);
    }
}
