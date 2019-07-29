using MPLIS.Libraries.Data.SSO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.SSO.Models
{
    public class SSOHcHuyen : IDMKVHC
    {
        public string HUYENID { get; set; }
        public string TINHID { get; set; }
        public string MAHUYEN { get; set; }
        public string TENHUYEN { get; set; }
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
                return HUYENID;
            }
        }

        public string TENKVHC
        {
            get
            {
                return TENHUYEN;
            }

        }
    }
}
