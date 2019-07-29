using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.SSO.Models
{
    public class SSOHtCauHinhNguoiDung
    {
        public string CAUHINHNGUOIDUNGID { get; set; }
        public string NGUOIDUNGID { get; set; }
        public string TENCAUHINH { get; set; }
        public string GIATRI { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
    }
}
