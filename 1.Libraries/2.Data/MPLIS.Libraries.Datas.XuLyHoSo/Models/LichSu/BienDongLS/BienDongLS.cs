using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class BienDongLS
    {
        public List<BDChuLS> DSChu { get; set; }
        public List<BDGiayChungNhanLS> DSGcn { get; set; }
        public List<BDThuaLS> DSThua { get; set; }
        public BDTheChapLS TheChapObj { get; set; }
        public QuyetDinhLS CurDC_QUYETDINH { get; set; }

        #region "Properties"
        public string BIENDONGID { get; set; }
        public string LOAIBIENDONGID { get; set; }
        public Nullable<System.DateTime> THOIDIEMBIENDONG { get; set; }
        public string MACOQUANTHUCHIEN { get; set; }
        public Nullable<decimal> SOTHUTU { get; set; }
        public string MABIENDONG { get; set; }
        public string NOIDUNGBIENDONG { get; set; }
        public string SOHOPDONG { get; set; }
        public Nullable<System.DateTime> NGAYHOPDONG { get; set; }
        public string NOIDUNGHOPDONG { get; set; }
        public string SOCONGCHUNG { get; set; }
        public string QUYENCONGCHUNG { get; set; }
        public Nullable<System.DateTime> NGAYCONGCHUNG { get; set; }
        public string NOICONGCHUNGID { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public string QUYETDINHID { get; set; }
        public string HOSOTIEPNHANID { get; set; }
        public string COTHUAXULY { get; set; }
        public Nullable<decimal> SOTHUTUBIENDONG { get; set; }
        public string MAHSTTDANGKY { get; set; }
        public Nullable<System.DateTime> NGAYTRUOCBA { get; set; }
        public string LYDOBIENDONG { get; set; }
        public string MAHOSOTHUTUCDANGKY { get; set; }
        public string NOICONGCHUNG { get; set; }
        #endregion
    }
}
