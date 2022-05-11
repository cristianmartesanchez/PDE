using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDE.Models.Entities.Identity
{
    public class RegisterModel : IdentityUser
    {

        public int MiembroId { get; set; }
        public string Cedula { get; set; }
        public string Celular { get; set; }
        public int CargoId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

    }
}
