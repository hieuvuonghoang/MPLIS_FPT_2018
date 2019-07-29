using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.SSO.Models
{
    public class SSOCookieInfor
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
