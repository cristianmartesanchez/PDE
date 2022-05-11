using PDE.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDE.Models.Service
{
    public interface ILocalidadService
    {
        Task<Localidad> Get(string URL, string accessToken);
        Task<IEnumerable<Localidad>> GetAll(string URL, string accessToken);
    }
}
