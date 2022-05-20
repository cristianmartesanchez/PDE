using Microsoft.EntityFrameworkCore;
using PDE.Models.Dto;
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

        public IQueryable<CargoTerritorialDto> GetCargoTerritoriales()
        {
            var data = from a in _context.CargoTerritorials
                       join b in _context.Cargos on a.CargoId equals b.Id
                       join c in _context.Cargos on a.CargoSupervisorId equals c.Id into d
                       from e in d.DefaultIfEmpty()
                       join f in _context.Localidads on a.LocalidadId equals f.Id
                       join g in _context.Estructuras on a.EstructuraId equals g.Id
                       select new CargoTerritorialDto
                       {
                           Id = a.Id,
                           CargoId = a.CargoId,
                           CargoSupervisorId = a.CargoSupervisorId,
                           EstructuraId = a.EstructuraId,
                           Cargo = new CargoDto
                           {
                               Id = b.Id,
                               Descripcion = b.Descripcion
                           },
                           CargoSupervisor = new CargoDto
                           {
                               Descripcion = e.Descripcion
                           },
                           LocalidadId = a.LocalidadId,
                           Localidad = new LocalidadDto
                           {
                               Id = f.Id,
                               Nombre = f.Nombre
                           },
                           Estructura = new EstructuraDto
                           {
                               Id = g.Id,
                               Descripcion = g.Descripcion
                           }
                       };

            return data;
        }

        public IQueryable<CargoTerritorialDto> GetCargosBySupervisor(int? cargoSupervisorId = null)
        {

            var cargos = GetCargoTerritoriales();
            var data = cargos.Where(a => cargoSupervisorId.HasValue ?
            a.CargoSupervisorId == cargoSupervisorId : a.CargoSupervisorId == null);

            return data;

        }

        public async Task<IEnumerable<CargoTerritorialDto>> GetCargosByLocalidad(int LocalidadId)
        {
            var cargos = await GetCargoTerritoriales().ToListAsync();
            var data =   cargos.Where(a => a.LocalidadId == LocalidadId).DistinctBy(a => a.CargoId);

            return data;
        }
    }
}
