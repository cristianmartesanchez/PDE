using PDE.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDE.Models.Service
{
    public interface IProvinciaService
    {
        Task<Provincia> Get(string URL, string accessToken);
        Task<IEnumerable<Provincia>> GetAll(string URL, string accessToken);
    }
}
