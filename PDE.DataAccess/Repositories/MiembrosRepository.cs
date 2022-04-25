using PDE.Models.Entities;
using PDE.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDE.DataAccess.Repositories
{
    internal class MiembrosRepository : GenericRepository<Miembro>, IMiembrosRepository
    {

        private readonly DBPDEContext _context;
        public MiembrosRepository(DBPDEContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Miembro> GetMiembros()
        {
            var data = (from a in _context.Miembros
                       join b in _context.Miembros on a.SupervisorId equals b.Id into c
                       from d in c.DefaultIfEmpty()
                       join e in _context.CargoTerritorials on a.CargoTerritorialId equals e.Id
                       join f in _context.Cargos on e.CargoId equals f.Id
                       join g in _context.Cargos on e.SupervisorId equals g.Id into h
                       from i in h.DefaultIfEmpty()
                       select new Miembro
                       {
                           Id = a.Id,
                           Nombres = a.Nombres,
                           Apellidos = a.Apellidos,
                           Cedula = a.Cedula,
                           Celular = a.Celular,
                           Supervisor = new Miembro
                           {
                               Nombres = d.Nombres,
                               Apellidos = d.Apellidos
                           },
                           CargoTerritorial = new CargoTerritorial
                           {
                               Cargo = f,
                               Supervisor = i

                           }
                       });

            return data;
        }
    }
}
