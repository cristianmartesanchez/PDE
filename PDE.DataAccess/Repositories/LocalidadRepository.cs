using PDE.Models.Entities;
using PDE.Models.Interfaces;
using PDE.Persistence;

namespace PDE.DataAccess.Repositories
{
    public class LocalidadRepository : GenericRepository<Localidad>, ILocalidadRepository
    {
        private readonly DBPDEContext _context;
        public LocalidadRepository(DBPDEContext context) : base(context)
        {
            _context = context;
        }


    }
}
