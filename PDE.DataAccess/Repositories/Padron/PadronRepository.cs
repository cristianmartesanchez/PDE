using P = PDE.Models.Entities.Padron;
using PDE.Models.Interfaces.Padron;
using PDE.Models.Entities;
using Enums = PDE.Models.Enums;
using Microsoft.EntityFrameworkCore;
using PDE.Persistence;
using PDE.Persistence.Padron;
using System.Threading.Tasks;
using System.Linq;
using System;
using PDE.Models.Dto;

namespace PDE.DataAccess.Repositories.Padron
{
    public class PadronRepository : GenericRepository<P.Padron>, IPadronRepository
    {

        private readonly PadronContext _context;
        public PadronRepository(PadronContext context) : base(context)
        {
            _context = context;
        }

        public async Task<MiembroDto> GetPadron(string cedula)
        {

            var data = await (from a in _context.Padrons 
                              join b in _context.Municipios on a.Idmunicipio equals b.Id
                              join c in _context.Provincia on b.Idprovincia equals c.Id
                              join d in _context.Nacionalidads on a.Idnacionalidad equals d.Id
                              join e in _context.Categoria on a.Idcategoria equals e.Id
                              join f in _context.Ocupacions on a.IdOcupacion equals f.Id
                              join g in _context.Colegios on a.Idcolegio equals g.Idcolegio
                              join h in _context.Recintos on g.Idrecinto equals h.Id
                              join i in _context.Circunscripcions on h.Idcircunscripcion equals i.Id into j
                              from k in j.DefaultIfEmpty()
                              join sx in _context.Sexos on a.IdSexo equals sx.IdSexo into m
                              from n in m.DefaultIfEmpty()
                              join ec in _context.EstadoCivils on a.IdEstadoCivil equals ec.Id into o
                              from p in o.DefaultIfEmpty()
                              where a.Cedula == cedula 
                              select new MiembroDto
                              {
                                  Nombres = a.Nombres,
                                  Apellidos = a.Apellido1 +" "+a.Apellido2,
                                  Cedula = a.Cedula,
                                  FechaNacimiento = a.FechaNacimiento.Value,
                                  LugarNacimiento = a.LugarNacimiento,
                                  EstadoCivilId = (int?)Enum.Parse<Enums.EstadoCivil>(a.IdEstadoCivil),
                                  CategoriaId = a.Idcategoria,
                                  ColegioId = a.Idcolegio,
                                  MunicipioId = a.Idmunicipio,
                                  NacionalidadId = a.Idnacionalidad,
                                  OcupacionId = a.IdOcupacion,                                  
                                  SexoId = (int?)Enum.Parse<Enums.Sexo>(a.IdSexo),
                                  Sexo = new SexoDto
                                  {
                                      Descripcion = n.Descripcion
                                  },
                                  EstadoCivil = new EstadoCivilDto
                                  {
                                      Descripcion = p.Descripcion
                                  },
                                  Municipio = new MunicipioDto
                                  {
                                      Id = b.Id,
                                      Descripcion = b.Descripcion,
                                      ProvinciaId = c.Id,
                                      Provincia = new ProvinciaDto
                                      {
                                          Id = c.Id,
                                          Descripcion = c.Descripcion
                                      }
                                  },
                                  Nacionalidad = new NacionalidadDto
                                  {
                                      Id = d.Id,
                                      Descripcion = d.Descripcion                                
                                  },
                                  Categoria = new CategoriaDto
                                  {
                                      Id = e.Id,
                                      Descripcion = e.Descripcion
                                  },
                                  Ocupacion = new OcupacionDto
                                  {
                                      Id = f.Id,
                                      Descripcion = f.Descripcion
                                  },
                                  Colegio = new ColegioDto
                                  {
                                      Id = g.Idcolegio,
                                      Descripcion= g.Descripcion,
                                      RecintoId = g.Idrecinto,
                                      Recinto = new RecintoDto
                                      {
                                          Id = h.Id,
                                          Descripcion = h.Descripcion,
                                          CodigoRecinto = h.CodigoRecinto,
                                          Circunscripcion = new CircunscripcionDto
                                          {
                                              Id = k.Id,
                                              Descripcion = k.Descripcion
                                          }
                                      }
                                  }

                              }).FirstOrDefaultAsync();
                       
            return data;
            
        }

    }
}
