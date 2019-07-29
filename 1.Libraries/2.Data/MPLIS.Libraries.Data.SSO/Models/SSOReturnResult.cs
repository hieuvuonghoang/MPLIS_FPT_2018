using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.SSO.Models
{
    public class SSOReturnResult
    {
        public HttpStatusCode ReturnCode { get; set; }
        public string Message { get; set; }
    }
}
