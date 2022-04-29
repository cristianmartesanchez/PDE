using PDE.Models.Entities;
using PDE.Models.Interfaces;
using PDE.Persistence;

namespace PDE.DataAccess.Repositories
{
    public class SexoRepository : GenericRepository<Sexo>, ISexoRepository
    {
        private readonly DBPDEContext _context;
        public SexoRepository(DBPDEContext context) : base(context)
        {
            _context = context;
        }


    }
}
