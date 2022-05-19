using PDE.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDE.Models.Service
{
    public interface ICargoService
    {
        Task<CargoDto> Get(string URL, string accessToken);
        Task<IEnumerable<CargoDto>> GetAll(string URL, string accessToken);
        Task<CargoDto> Post(string url, object body, string accessToken);
        Task<CargoDto> Put(string url, object body, string accessToken);
        Task<bool> Delete(string url, string accessToken);
    }
}
