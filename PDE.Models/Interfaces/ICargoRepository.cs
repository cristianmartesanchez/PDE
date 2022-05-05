using PDE.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDE.Models.Interfaces
{
    public interface ICargoRepository : IGenericRepository<Cargo>
    {
        Task<IEnumerable<Cargo>> GetCargosByEstructura(int estructuraId);
    }
}
