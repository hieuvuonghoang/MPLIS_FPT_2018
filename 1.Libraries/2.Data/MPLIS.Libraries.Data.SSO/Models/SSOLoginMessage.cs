using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.SSO.Models
{
    public class SSOLoginMessage
    {
        public string Token { get; set; }
        public string User { get; set; }
        public string Message { get; set; }
        public DateTime Expires { get; set; }
    }
}
