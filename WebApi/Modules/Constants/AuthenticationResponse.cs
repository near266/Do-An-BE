﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApi.Modules.Constants
{
    public class AuthenticationResponse
    {

        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public bool IsVerified { get; set; }
        public string JWTToken { get; set; }
        public string RefreshToken { get; set; }
        public int? IsBan { get; set; } = 0;

    }
}
