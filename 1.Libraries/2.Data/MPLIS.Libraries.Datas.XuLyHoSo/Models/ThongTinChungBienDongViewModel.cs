using System;
using System.Collections.Generic;
using System.Linq;
using AppCore.Models;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
   public class ThongTinChungBienDongViewModel
    {
        public DC_BIENDONG BienDong { get; set; }
        
        public List<DC_LOAIBIENDONG> GetListTT()
        {
            using (var context = new MplisEntities())
            {
                var list = context.DC_LOAIBIENDONG.OrderBy(m => m.TENLOAIBIENDONG).ToList();
                return list;
            }
        }

        //public string BIENDONGID { get; set; }
        //public string LOAIBIENDONGID { get; set; }
        //public decimal? SOTHUTU { get; set; }
        //public decimal? SOTHUTUBIENDONG { get; set; }

        //public DateTime THOIDIEMBIENDONG { get; set; }
        //public string MABIENDONG { get; set; }
        //public string MAHOSOTHUTUCDANGKY { get; set; }
        //public string QUYETDINHID { get; set; }
        //public string SOHOPDONG { get; set; }
        //public DateTime NGAYHOPDONG { get; set; }
        //public string SOCONGCHUNG { get; set; }
        //public DateTime NGAYCONGCHUNG { get; set; }
        //public string NOICONGCHUNGID { get; set; }
        //public string QUYENCONGCHUNG { get; set; }
        //public DateTime NGAYTRUOCBA { get; set; }
        //public string LYDOBIENDONG { get; set; }
        //public string NOIDUNGBIENDONG { get; set; }
        //public string NOIDUNGHOPDONG { get; set; }
        //public string HOSOTIEPNHANID { get; set; }

    }
}
