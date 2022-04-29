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

namespace PDE.DataAccess.Repositories.Padron
{
    public class PadronRepository : GenericPadronRepository<P.Padron>, IPadronRepository
    {

        private readonly PadronContext _context;
        public PadronRepository(PadronContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Miembro> GetPadron(string cedula)
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
                              where a.Cedula == cedula 
                              select new Miembro
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
                                  Municipio = new Municipio
                                  {
                                      Id = b.Id,
                                      Descripcion = b.Descripcion,
                                      ProvinciaId = c.Id,
                                      Provincia = new Provincia
                                      {
                                          Id = c.Id,
                                          Descripcion = c.Descripcion
                                      }
                                  },
                                  Nacionalidad = new Nacionalidad
                                  {
                                      Id = d.Id,
                                      Descripcion = d.Descripcion                                
                                  },
                                  Categoria = new Categoria
                                  {
                                      Id = e.Id,
                                      Descripcion = e.Descripcion
                                  },
                                  Ocupacion = new Ocupacion
                                  {
                                      Id = f.Id,
                                      Descripcion = f.Descripcion
                                  },
                                  Colegio = new Colegio
                                  {
                                      Id = g.Idcolegio,
                                      Descripcion= g.Descripcion,
                                      RecintoId = g.Idrecinto,
                                      Recinto = new Recinto
                                      {
                                          Id = h.Id,
                                          Descripcion = h.Descripcion,
                                          CodigoRecinto = h.CodigoRecinto,
                                          Circunscripcion = new Circunscripcion
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
