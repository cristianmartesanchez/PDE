using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PDE.Models.Entities.Identity
{
    public class TokenModel
    {
        public string token;
        public DateTime expiration;
        public string user;
    }
}
