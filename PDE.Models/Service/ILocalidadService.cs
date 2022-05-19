using PDE.Models.Dto;
using PDE.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDE.Models.Service
{
    public interface ILocalidadService
    {
        Task<LocalidadDto> Get(string URL, string accessToken);
        Task<IEnumerable<LocalidadDto>> GetAll(string URL, string accessToken);
    }
}
