using PDE.Models.Entities;
using PDE.Models.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDE.Models.Service
{
    public interface IAuthenticateService
    {
        Task<TokenModel> Login(string url, object body);
        Task<bool> Post(string url, object body);
        Task<bool> Put(string url, object body);
    }
}
