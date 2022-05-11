using PDE.Models.Entities;
using PDE.Models.Entities.Padron;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDE.Models.Service
{
    public interface IPadronService
    {
        Task<Padron> Get(string URL);
        Task<IEnumerable<Padron>> GetAll(string URL);
    }
}
