using PDE.Models.Entities;
using PDE.Models.Interfaces;
using PDE.Persistence;

namespace PDE.DataAccess.Repositories
{
    public class ProvinciaRepository : GenericRepository<Provincia>, IProvinciaRepository
    {
        private readonly DBPDEContext _context;
        public ProvinciaRepository(DBPDEContext context) : base(context)
        {
            _context = context;
        }


    }
}
