﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDE.Models.Entities.Identity
{
    public class RegisterModel
    {

        public string Username { get; set; }

        public string Celular { get; set; }

        public string Password { get; set; }
    }
}