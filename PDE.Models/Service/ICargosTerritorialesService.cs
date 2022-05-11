using PDE.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDE.Models.Service
{
    public interface ICargosTerritorialesService
    {
        Task<CargoTerritorial> Get(string URL, string accessToken);
        Task<IEnumerable<CargoTerritorial>> GetAll (string URL, string accessToken);
        Task<CargoTerritorial> Post(string url, object body, string accessToken);
        Task<CargoTerritorial> Put(string url, object body, string accessToken);
        Task<bool> Delete(string url, string accessToken);
    }
}
