using PDE.Models.Entities;
using PDE.Models.Interfaces;
using PDE.Persistence;

namespace PDE.DataAccess.Repositories
{
    public class CategoriaRepository : GenericRepository<Categoria>, ICategoriaRepository
    {
        private readonly DBPDEContext _context;
        public CategoriaRepository(DBPDEContext context) : base(context)
        {
            _context = context;
        }


    }
}
