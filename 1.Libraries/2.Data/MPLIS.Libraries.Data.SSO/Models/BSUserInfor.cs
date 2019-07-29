using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.SSO.Models
{
    public class BSUserInfor
    {
        public SSOUserLoginInfors UserInfo { get; set; }
        public string CurUngDung { get; set; }

        public BSUserInfor()
        {
            UserInfo = null;
            CurUngDung = "";
        }
    }
}
