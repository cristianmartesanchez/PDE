using Microsoft.EntityFrameworkCore;
using PDE.Models.Entities;
using PDE.Models.Interfaces;
using PDE.Persistence;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Miembro> GetMiembroByCedula(string cedula)
        {
            var miembros =  GetMiembros();
            var data = await miembros.FirstOrDefaultAsync(a => a.Cedula == cedula);

            return data;
        }

        public IQueryable<Miembro> GetMiembros()
        {
           
            var data =  (from a in _context.Miembros
                        join b in _context.Miembros on a.SupervisorId equals b.Id into c
                        from d in c.DefaultIfEmpty()
                        join e in _context.Cargos on a.CargoId equals e.Id
                        join f in _context.CargoTerritorials on e.Id equals f.CargoId
                        join g in _context.Cargos on f.CargoSupervisorId equals g.Id into h
                        from i in h.DefaultIfEmpty()
                        join j in _context.Categorias on a.CategoriaId equals j.Id into k
                        from l in k.DefaultIfEmpty()
                        join m in _context.Municipios on a.MunicipioId equals m.Id into n
                        from o in n.DefaultIfEmpty()
                        join p in _context.Provincia on o.ProvinciaId equals p.Id into q
                        from r in q.DefaultIfEmpty()
                        select new Miembro
                        {
                            Id = a.Id,
                            Nombres = a.Nombres,
                            Apellidos = a.Apellidos,
                            Cedula = a.Cedula,
                            Celular = a.Celular,
                            CargoId = a.CargoId,
                            SexoId = a.SexoId,
                            FechaNacimiento = a.FechaNacimiento,
                            LugarNacimiento = a.LugarNacimiento,
                            NacionalidadId = a.NacionalidadId,
                            ColegioId = a.ColegioId,
                            OcupacionId = a.OcupacionId,                            
                            EstadoCivilId = a.EstadoCivilId,
                            SupervisorId = a.SupervisorId,
                            CategoriaId = a.CategoriaId,
                            MunicipioId = a.MunicipioId,
                            Municipio = new Municipio
                            {
                                Descripcion = o.Descripcion,
                                ProvinciaId = o.Id,
                                Provincia = new Provincia
                                {
                                    Descripcion = r.Descripcion
                                }
                            },
                            Supervisor = new Miembro
                            {
                                Nombres = d.Nombres,
                                Apellidos = d.Apellidos
                            },
                            Cargo = new Cargo
                            {
                                Id = e.Id,
                                Descripcion = e.Descripcion
                            }
                        });

            return data;
        }

        public IQueryable<Miembro> GetMiembrosBySupervisor(int supervisorId)
        {
            var miembros = GetMiembros();
            var data = miembros.Where(a => a.SupervisorId == supervisorId);
            return data;
        }

        public async Task<IEnumerable<Miembro>> GetMiembrosByCargo(int cargoId)
        {
                       
            var miembros = GetMiembros();            
            var data = await miembros.Where(a => a.CargoId == cargoId).ToListAsync();

            return data;
        }

        public async Task<IEnumerable<Miembro>> GetSupervisorByCargo(int cargoId)
        {
            var cargoTerritorial = _context.CargoTerritorials.FirstOrDefault(a => a.CargoId == cargoId);
            var miembros = GetMiembros();
            var data = await miembros.Where(a => a.CargoId == cargoTerritorial.CargoSupervisorId).ToListAsync();

            return data;
        }

        public bool MiembroExists(string cedula)
        {
            return _context.Miembros.Any(a => a.Cedula == cedula);
        }
    }
}
