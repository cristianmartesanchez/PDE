using PDE.Models.Dto;
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
        Task<ProvinciaDto> Get(string URL, string accessToken);
        Task<IEnumerable<ProvinciaDto>> GetAll(string URL, string accessToken);
    }
}
