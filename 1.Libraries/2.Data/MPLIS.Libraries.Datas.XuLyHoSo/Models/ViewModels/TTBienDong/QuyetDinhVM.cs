using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class QuyetDinhVM
    {
        public string QUYETDINHID { get; set; }
        public string SOQUYETDINH { get; set; }
        public Nullable<System.DateTime> NGAYQUYETDINH { get; set; }
        public string NOIDUNGQUYETDINH { get; set; }
        public string SOHOPDONG { get; set; }
        public Nullable<System.DateTime> NGAYHOPDONG { get; set; }
        public Nullable<decimal> GIATRIHOPDONG { get; set; }
        public string SOCONGCHUNG { get; set; }
        public string QUYENCONGCHUNG { get; set; }
        public string NOICONGCHUNG { get; set; }
        public Nullable<System.DateTime> NGAYCONGCHUNG { get; set; }
        public string NOIDUNGHOPDONG { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
    }

    public class DSQuyetDinhVM
    {
        public List<QuyetDinhVM> DSQuyetDinh { get; set; }
        public DSQuyetDinhVM()
        {
            DSQuyetDinh = new List<QuyetDinhVM>();
        }
    }
}
