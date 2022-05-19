using PDE.Models.Dto;
using PDE.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDE.Models.Service
{
    public interface IMiembroService
    {
        Task<MiembroDto> Get(string URL, string accessToken);
        Task<IEnumerable<MiembroDto>> GetAll(string URL, string accessToken);
        Task<MiembroDto> Post(string url, object body, string accessToken);
        Task<MiembroDto> Put(string url, object body, string accessToken);
    }
}
