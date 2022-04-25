using PDE.Models.Entities;
using PDE.Models.Interfaces;
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

        public IQueryable<CargoTerritorial> GetCargoTerritorials()
        {
            var data = from a in _context.CargoTerritorials
                       join b in _context.Cargos on a.CargoId equals b.Id
                       join c in _context.Cargos on a.SupervisorId equals c.Id into d
                       from e in d.DefaultIfEmpty()
                       join f in _context.Localidads on a.LocalidadId equals f.Id
                       select new CargoTerritorial
                       {
                           Id = a.Id,
                           CargoId = a.CargoId,
                           SupervisorId = a.SupervisorId,
                           Cargo = b,
                           Supervisor = e,
                           Localidad = f
                       };
            return data;
        }

        public IQueryable<CargoTerritorial> GetCargosTerritoriales(int? supervisorId = null)
        {

            var data = GetCargoTerritorials().Where(a => a.SupervisorId.HasValue ?
            a.SupervisorId == supervisorId : a.SupervisorId == null);

            return data;

        }
    }
}
