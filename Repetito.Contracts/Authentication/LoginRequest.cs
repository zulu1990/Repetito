﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repetito.Contracts.Authentication
{
    public class LoginRequest
    {
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
