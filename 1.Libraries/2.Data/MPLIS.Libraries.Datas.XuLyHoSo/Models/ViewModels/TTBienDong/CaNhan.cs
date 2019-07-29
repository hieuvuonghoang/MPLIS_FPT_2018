using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class CaNhan
    {
        public string CANHANID { get; set; }
        public string HOTEN { get; set; }
        public string HODEM { get; set; }
        public string TEN { get; set; }
        public Nullable<System.DateTime> NGAYSINH { get; set; }
        public Nullable<decimal> NAMSINH { get; set; }
        public Nullable<decimal> GIOITINH { get; set; }
    }
}
