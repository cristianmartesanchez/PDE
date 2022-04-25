using PDE.Models.Entities;
using PDE.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
