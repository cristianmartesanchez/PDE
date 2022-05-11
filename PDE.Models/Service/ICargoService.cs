using PDE.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDE.Models.Service
{
    public interface ICargoService
    {
        Task<Cargo> Get(string URL, string accessToken);
        Task<IEnumerable<Cargo>> GetAll(string URL, string accessToken);
        Task<Cargo> Post(string url, object body, string accessToken);
        Task<Cargo> Put(string url, object body, string accessToken);
        Task<bool> Delete(string url, string accessToken);
    }
}
