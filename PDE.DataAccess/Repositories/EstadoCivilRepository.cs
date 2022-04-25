using PDE.Models.Entities;
using PDE.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDE.DataAccess.Repositories
{
    public class EstadoCivilRepository : GenericRepository<EstadoCivil>, IEstadoCivilRepository
    {
        private readonly DBPDEContext _context;
        public EstadoCivilRepository(DBPDEContext context) : base(context)
        {
            _context = context;
        }


    }
}
