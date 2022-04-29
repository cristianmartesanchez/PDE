using PDE.Models.Entities;
using PDE.Models.Interfaces;
using PDE.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDE.DataAccess.Repositories
{
    public class CargoRepository : GenericRepository<Cargo>, ICargoRepository
    {
        private readonly DBPDEContext _context;
        public CargoRepository(DBPDEContext context) : base(context)
        {
            _context = context;
        }


    }
}
