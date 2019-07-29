using MPLIS.Libraries.Data.SSO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.SSO.Models
{
    public class SSOHcXa : IDMKVHC
    {
        public string KVHCID { get; set; }
        public string HUYENID { get; set; }
        public string MAXA { get; set; }
        public string TENKVHC { get; set; }
        public string PHANLOAI { get; set; }
        public string THUTUSAPXEP { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string MAKVHC { get; set; }

        public string ID
        {
            get
            {
                return KVHCID;
            }
        }
    }
}
