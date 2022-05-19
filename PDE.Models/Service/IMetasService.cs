using PDE.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDE.Models.Service
{
    public interface IMetasService
    {
        Task<MetasDto> Get(string URL, string accessToken);
        Task<IEnumerable<MetasDto>> GetAll(string URL, string accessToken);
        Task<MetasDto> Post(string url, object body, string accessToken);
        Task<MetasDto> Put(string url, object body, string accessToken);
        Task<bool> Delete(string url, string accessToken);
    }
}
