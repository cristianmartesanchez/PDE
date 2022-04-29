using PDE.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P = PDE.Models.Entities.Padron;

namespace PDE.Models.Interfaces.Padron
{
    public interface IPadronRepository : IGenericRepository<P.Padron>
    {
        public Task<Miembro> GetPadron(string cedula);
    }
}
