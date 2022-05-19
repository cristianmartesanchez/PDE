using PDE.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDE.Models.Service
{
    public interface IEstructuraService
    {
        Task<EstructuraDto> Get(string URL, string accessToken);
        Task<IEnumerable<EstructuraDto>> GetAll(string URL, string accessToken);
        Task<EstructuraDto> Post(string url, object body, string accessToken);
        Task<EstructuraDto> Put(string url, object body, string accessToken);
        Task<bool> Delete(string url, string accessToken);
    }
}
