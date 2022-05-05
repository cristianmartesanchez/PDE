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
    public class CargoRepository : GenericRepository<Cargo>, ICargoRepository
    {
        private readonly DBPDEContext _context;
        public CargoRepository(DBPDEContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cargo>> GetCargosByEstructura(int estructuraId)
        {
            var cargos = await (from a in _context.CargoTerritorials
                          join b in _context.Cargos on a.CargoId equals b.Id
                          where a.EstructuraId == estructuraId
                          select new Cargo
                          {

                              Id = a.CargoId,
                              Descripcion = b.Descripcion

                          }).ToListAsync();

            return cargos;
        }
    }
}
