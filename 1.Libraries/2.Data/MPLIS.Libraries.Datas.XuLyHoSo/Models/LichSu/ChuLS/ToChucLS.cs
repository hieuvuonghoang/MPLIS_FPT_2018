using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class ToChucLS
    {
        public CaNhanLS NguoiDaiDien { get; set; }
        public CaNhanLS CurCaNhan { get; set; }
        public int TRANGTHAI { get; set; }

        #region "Properties"
        public string TOCHUCID { get; set; }
        public string TENTOCHUC { get; set; }
        public string TENVIETTAT { get; set; }
        public string TENTOCHUCTA { get; set; }
        public string NGUOIDAIDIENID { get; set; }
        public string SOQUYETDINH { get; set; }
        public Nullable<System.DateTime> NGAYQUYETDINH { get; set; }
        public string LOAIQUYETDINHTHANHLAP { get; set; }
        public string MADOANHNGHIEP { get; set; }
        public string MASOTHUE { get; set; }
        public string LOAITOCHUC { get; set; }
        public string DIACHI { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public string CMTNGUOIDAIDIEN { get; set; }
        #endregion
    }
}
