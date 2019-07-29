using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MPLIS.Libraries.Data.SSO.Models
{
    public class SSOHttpRequestParams
    {
        public string Action { get; set; } //chỉ dùng để check loại request là login hay logout
        public string Token { get; set; }
        public bool isTokenFromCookie { get; set; }
        public string UserName { get; set; }
        public string ReturnUrl { get; set; }
        public string RequestUrl { get; set; }
        public HttpCookie Cookie { get; set; }

        public SSOHttpRequestParams()
        {
            Action = "";
            Token = "";
            ReturnUrl = "";
            isTokenFromCookie = false;
        }
    }
}
