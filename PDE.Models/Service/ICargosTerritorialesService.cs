using PDE.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDE.Models.Service
{
    public interface ICargosTerritorialesService
    {
        Task<CargoTerritorialDto> Get(string URL, string accessToken);
        Task<IEnumerable<CargoTerritorialDto>> GetAll (string URL, string accessToken);
        Task<CargoTerritorialDto> Post(string url, object body, string accessToken);
        Task<CargoTerritorialDto> Put(string url, object body, string accessToken);
        Task<bool> Delete(string url, string accessToken);
    }
}
