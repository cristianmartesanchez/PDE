using PDE.Models.Entities;
using PDE.Models.Interfaces;
using PDE.Persistence;

namespace PDE.DataAccess.Repositories
{
    public class OcupacionRepository : GenericRepository<Ocupacion>, IOcupacionRepository
    {
        private readonly DBPDEContext _context;
        public OcupacionRepository(DBPDEContext context) : base(context)
        {
            _context = context;
        }


    }
}
