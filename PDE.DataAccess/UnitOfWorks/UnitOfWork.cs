using PDE.DataAccess.Repositories;
using PDE.DataAccess.Repositories.Padron;
using PDE.Models.Interfaces;
using PDE.Models.Interfaces.Padron;
using PDE.Persistence;
using PDE.Persistence.Padron;
using System.Threading.Tasks;

namespace PDE.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly PadronContext _dbContext;
        private readonly DBPDEContext _context;
        public UnitOfWork(PadronContext dbContext, DBPDEContext context)
        {
            _context = context;
             _dbContext = dbContext;
            Padron = new PadronRepository(_dbContext);
            Miembros = new MiembrosRepository(_context);
            CargosTerritoriales = new CargosTerritorialesRepository(_context);
            Categoria = new CategoriaRepository(_context);
            Municipio = new MunicipioRepository(_context);
            Nacionalidad = new NacionalidadRepository(_context);
            Ocupacion = new OcupacionRepository(_context);
            Sexo = new SexoRepository(_context);
            EstadoCivil = new EstadoCivilRepository(_context);
            Cargo = new CargoRepository(_context);
            Localidad = new LocalidadRepository(_context);
            Provincia = new ProvinciaRepository(_context);
            Estructura = new EstructuraRepository(_context);
        }

        public IPadronRepository Padron { get;  }
        public IMiembrosRepository Miembros { get; set; }
        public ICargosTerritorialesRepository CargosTerritoriales { get; set; }
        public ICategoriaRepository Categoria { get; set; }
        public IMunicipioRepository Municipio { get; set; }
        public INacionalidadRepository Nacionalidad { get; set; }
        public IOcupacionRepository Ocupacion { get; set; }
        public IColegioRepository Colegio { get; set; }
        public ISexoRepository Sexo { get; set; }
        public IEstadoCivilRepository EstadoCivil { get; set; }
        public ICargoRepository Cargo { get; set; }
        public ILocalidadRepository Localidad { get; set; }
        public IProvinciaRepository Provincia { get; set; }
        public IEstructuraRepository Estructura { get; set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task Save()
        {
           await _context.SaveChangesAsync();
        }
    }
}
