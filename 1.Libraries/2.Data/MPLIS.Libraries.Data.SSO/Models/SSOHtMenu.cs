using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.SSO.Models
{
    public class SSOHtMenu
    {
        public string MENUID { get; set; }
        public string KHOACHAID { get; set; }
        public string UNGDUNGID { get; set; }
        public string URL { get; set; }
        public string TENMENU { get; set; }
        public string MOTA { get; set; }
        public byte[] ICON { get; set; }
        public string CHOPHEPSUDUNG { get; set; }
        public string THUTUSAPXEP { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string ACTION { get; set; }
        public string CONTROLLER { get; set; }
        public string MAMENU { get; set; }
    }
}
