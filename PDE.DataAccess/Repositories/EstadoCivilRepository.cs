using PDE.Models.Entities;
using PDE.Models.Interfaces;
using PDE.Persistence;

namespace PDE.DataAccess.Repositories
{
    public class EstadoCivilRepository : GenericRepository<EstadoCivil>, IEstadoCivilRepository
    {
        private readonly DBPDEContext _context;
        public EstadoCivilRepository(DBPDEContext context) : base(context)
        {
            _context = context;
        }


    }
}
