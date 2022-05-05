using PDE.Models.Entities;
using PDE.Models.Interfaces;
using PDE.Persistence;

namespace PDE.DataAccess.Repositories
{
    public class EstructuraRepository : GenericRepository<Estructura>, IEstructuraRepository
    {
        private readonly DBPDEContext _context;
        public EstructuraRepository(DBPDEContext context) : base(context)
        {
            _context = context;
        }


    }
}
