using P = PDE.Models.Entities.Padron;
using PDE.Models.Interfaces.Padron;
using PDE.Models.Entities;
using Enums = PDE.Models.Enums;

namespace PDE.DataAccess.Repositories.Padron
{
    public class PadronRepository : GenericPadronRepository<P.Padron>, IPadronRepository
    {

        private readonly PadronContext _context;
        public PadronRepository(PadronContext context) : base(context)
        {
            _context = context;
        }

        public Miembro GetPadron(string cedula)
        {
            
            var data = (from a in _context.Padrons 
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
                            SexoId = (int?)Enum.Parse<Enums.Sexo>(a.IdSexo)

                        }).FirstOrDefault();
                       
            return data;
            
        }

    }
}
