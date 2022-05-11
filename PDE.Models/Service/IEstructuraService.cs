using PDE.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDE.Models.Service
{
    public interface IEstructuraService
    {
        Task<Estructura> Get(string URL, string accessToken);
        Task<IEnumerable<Estructura>> GetAll(string URL, string accessToken);
        Task<Estructura> Post(string url, object body, string accessToken);
        Task<Estructura> Put(string url, object body, string accessToken);
        Task<bool> Delete(string url, string accessToken);
    }
}
