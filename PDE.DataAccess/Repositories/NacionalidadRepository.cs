using PDE.Models.Entities;
using PDE.Models.Interfaces;
using PDE.Persistence;

namespace PDE.DataAccess.Repositories
{
    public class NacionalidadRepository : GenericRepository<Nacionalidad>, INacionalidadRepository
    {
        private readonly DBPDEContext _context;
        public NacionalidadRepository(DBPDEContext context) : base(context)
        {
            _context = context;
        }


    }
}
