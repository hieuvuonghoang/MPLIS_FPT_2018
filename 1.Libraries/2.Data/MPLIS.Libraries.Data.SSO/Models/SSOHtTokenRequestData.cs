﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.SSO.Models
{
    public class SSOHtTokenRequestData
    {
        public string Token { get; set; }
        public bool isTokenFromCookie { get; set; }
    }
}
