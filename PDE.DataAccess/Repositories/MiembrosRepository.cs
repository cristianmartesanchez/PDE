﻿using Microsoft.EntityFrameworkCore;
using PDE.Models.Dto;
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

        public async Task<MiembroDto> GetMiembroByCedula(string cedula)
        {
            var miembros =  GetMiembros();
            var data = await miembros.FirstOrDefaultAsync(a => a.Cedula == cedula);

            return data;
        }


        public IQueryable<MiembroDto> GetMiembros()
        {
           
            var data =  (from a in _context.Miembros
                        join b in _context.Miembros on a.SupervisorId equals b.Id into c
                        from d in c.DefaultIfEmpty()
                        join e in _context.Estructuras on a.EstructuraId equals e.Id
                        join i in _context.Cargos on a.CargoId equals i.Id
                        join lo in _context.Localidads on a.LocalidadId equals lo.Id
                        join ec in _context.EstadoCiviles on a.EstadoCivilId equals ec.Id
                        join sx in _context.Sexos on a.SexoId equals sx.Id
                        join j in _context.Categorias on a.CategoriaId equals j.Id into k
                        from l in k.DefaultIfEmpty()
                        join m in _context.Municipios on a.MunicipioId equals m.Id into n
                        from o in n.DefaultIfEmpty()
                        join p in _context.Provincia on o.ProvinciaId equals p.Id into q
                        from r in q.DefaultIfEmpty()
                        join s in _context.Nacionalidads on a.NacionalidadId equals s.Id
                        join oc in _context.Ocupacions on a.OcupacionId equals oc.Id
                        join co in _context.Colegios on a.ColegioId equals co.Id
                        join rc in _context.Recintos on co.RecintoId equals rc.Id
                        join cc in _context.Circunscripcions on rc.CircunscripcionId equals cc.Id into ccp
                        from cp in ccp.DefaultIfEmpty()
                        select new MiembroDto
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
                            LocalidadId = a.LocalidadId,
                            Supervisor = new MiembroDto
                            {
                                Nombres = d.Nombres,
                                Apellidos = d.Apellidos
                            },
                            EstructuraId = a.EstructuraId,
                            Estructura = new EstructuraDto
                            {
                                Descripcion = e.Descripcion
                            },
                            Cargo = new CargoDto
                            {
                                Id = a.CargoId,
                                Descripcion = i.Descripcion
                            },

                            Localidad = new LocalidadDto
                            {
                                Id = lo.Id,
                                Nombre = lo.Nombre
                            },

                            Municipio = new MunicipioDto
                            {
                                Id = o.Id,
                                Descripcion = o.Descripcion,
                                ProvinciaId = r.Id,
                                Provincia = new ProvinciaDto
                                {
                                    Id = r.Id,
                                    Descripcion = r.Descripcion
                                }
                            },
                            Nacionalidad = new NacionalidadDto
                            {
                                Id = s.Id,
                                Descripcion = s.Descripcion
                            },
                            Categoria = new CategoriaDto
                            {
                                
                                Descripcion = l.Descripcion
                            },
                            Ocupacion = new OcupacionDto
                            {
                                Id = oc.Id,
                                Descripcion = oc.Descripcion
                            },
                            EstadoCivil = new EstadoCivilDto
                            {
                                Id = ec.Id,
                                Descripcion= ec.Descripcion
                            },
                            Sexo = new SexoDto
                            {
                                Id = sx.Id,
                                Descripcion = sx.Descripcion
                            },
                            Colegio = new ColegioDto
                            {
                                Id = co.Id,
                                Descripcion = co.Descripcion,
                                RecintoId = co.RecintoId,
                                Recinto = new RecintoDto
                                {
                                    Id = rc.Id,
                                    Descripcion = rc.Descripcion,
                                    CodigoRecinto = rc.CodigoRecinto,
                                    Circunscripcion = new CircunscripcionDto
                                    {
                                        Id = cp.Id,
                                        Descripcion = cp.Descripcion
                                    }
                                }
                            }

                        });

            return data;
        }

        public IQueryable<MiembroDto> GetMiembrosBySupervisor(int supervisorId)
        {
            var miembros = GetMiembros();
            var data = miembros.Where(a => a.SupervisorId == supervisorId);
            return data;
        }

        public async Task<IEnumerable<MiembroDto>> GetMiembrosByCargo(int cargoId)
        {
                       
            var miembros = GetMiembros();            
            var data = await miembros.Where(a => a.CargoId == cargoId).ToListAsync();

            return data;
        }

        public async Task<IEnumerable<MiembroDto>> GetSupervisorByCargo(int CargoId, int LocalidadId)
        {

            var miembros = await (from a in GetMiembros()
                                  join b in _context.CargoTerritorials on a.CargoId equals b.CargoSupervisorId into c
                                  from d in c.DefaultIfEmpty()
                                  where d.CargoId == CargoId && d.LocalidadId == LocalidadId
                                  select a).ToListAsync();

            return miembros;
        }

        public bool MiembroExists(string cedula)
        {
            return _context.Miembros.Any(a => a.Cedula == cedula);
        }
    }
}
