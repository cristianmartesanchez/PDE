using Microsoft.EntityFrameworkCore;
using PDE.Models.Entities;
using PDE.Models.Interfaces;
using PDE.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDE.DataAccess.Repositories
{
    public class CargosTerritorialesRepository : GenericRepository<CargoTerritorial>, ICargosTerritorialesRepository
    {
        private readonly DBPDEContext _context;
        public CargosTerritorialesRepository(DBPDEContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<CargoTerritorial> GetCargoTerritoriales()
        {
            var data = from a in _context.CargoTerritorials
                       join b in _context.Cargos on a.CargoId equals b.Id
                       join c in _context.Cargos on a.CargoSupervisorId equals c.Id into d
                       from e in d.DefaultIfEmpty()
                       join f in _context.Localidads on a.LocalidadId equals f.Id
                       select new CargoTerritorial
                       {
                           Id = a.Id,
                           CargoId = a.CargoId,
                           CargoSupervisorId = a.CargoSupervisorId,
                           Cargo = b,
                           CargoSupervisor = e,
                           LocalidadId = a.LocalidadId,
                           Localidad = f
                       };

            return data;
        }

        public IQueryable<CargoTerritorial> GetCargosBySupervisor(int? cargoSupervisorId = null)
        {

            var cargos = GetCargoTerritoriales();
            var data = cargos.Where(a => cargoSupervisorId.HasValue ?
            a.CargoSupervisorId == cargoSupervisorId : a.CargoSupervisorId == null);

            return data;

        }

        public IEnumerable<CargoTerritorial> GetCargosByLocalidad(int LocalidadId)
        {
            var cargos = GetCargoTerritoriales().ToList();
            var data =  cargos.Where(a => a.LocalidadId == LocalidadId);

            return data;
        }
    }
}
