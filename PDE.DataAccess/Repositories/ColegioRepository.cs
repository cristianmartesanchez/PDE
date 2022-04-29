using PDE.Models.Entities;
using PDE.Models.Interfaces;
using PDE.Persistence;

namespace PDE.DataAccess.Repositories
{
    public class ColegioRepository : GenericRepository<Colegio>, IColegioRepository
    {
        private readonly DBPDEContext _context;
        public ColegioRepository(DBPDEContext context) : base(context)
        {
            _context = context;
        }


    }
}
