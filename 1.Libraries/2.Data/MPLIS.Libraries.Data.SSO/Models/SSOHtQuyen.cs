using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.SSO.Models
{
    public class SSOHtQuyen
    {
        public string QUYENID { get; set; }
        public string CHUCNANGID { get; set; }
        public string THUTUSAPXEP { get; set; }
        public string CONTROLLERNAME { get; set; }
        public string ACTIONNAME { get; set; }
        public string MOTA { get; set; }
        public string UID { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
    }
}
