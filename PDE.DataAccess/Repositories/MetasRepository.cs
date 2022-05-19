using PDE.Models.Entities;
using PDE.Models.Interfaces;
using PDE.Persistence;

namespace PDE.DataAccess.Repositories
{
    public class MetasRepository : GenericRepository<Metas>, IMetasRepository
    {
        private readonly DBPDEContext _context;
        public MetasRepository(DBPDEContext context) : base(context)
        {
            _context = context;
        }


    }
}
