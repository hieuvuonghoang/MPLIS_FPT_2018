using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class DC_DANGKY_GCN
    {
        public DC_GIAYCHUNGNHAN GiayChungNhan { get; set; }
        public string SoPhatHanh { get; set; }
        public string MaVach { get; set; }
        public string TrangThai { get; set; }
        public int themxoa { get; set; }
        // themxoa =1 :them
        // themxoa =3 :xoa
        public void InitData()
        {
            if(GiayChungNhan != null)
            {
                SoPhatHanh = GiayChungNhan.SOPHATHANH;
                MaVach = GiayChungNhan.MAVACH;
                TrangThai = GiayChungNhan.TRANGTHAIXULY;
            }
        }
    }
}
