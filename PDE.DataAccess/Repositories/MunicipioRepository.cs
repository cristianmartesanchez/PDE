using PDE.Models.Entities;
using PDE.Models.Interfaces;
using PDE.Persistence;

namespace PDE.DataAccess.Repositories
{
    public class MunicipioRepository : GenericRepository<Municipio>, IMunicipioRepository
    {
        private readonly DBPDEContext _context;
        public MunicipioRepository(DBPDEContext context) : base(context)
        {
            _context = context;
        }


    }
}
