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
        Task<Miembro> Get(string URL, string accessToken);
        Task<IEnumerable<Miembro>> GetAll(string URL, string accessToken);
        Task<Miembro> Post(string url, object body, string accessToken);
        Task<Miembro> Put(string url, object body, string accessToken);
    }
}
