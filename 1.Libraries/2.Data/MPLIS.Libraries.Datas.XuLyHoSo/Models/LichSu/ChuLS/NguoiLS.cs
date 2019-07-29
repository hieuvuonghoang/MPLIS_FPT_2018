using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class NguoiLS
    {
        public CaNhanLS CaNhan { get; set; }
        public NhomNguoiLS NhomNguoi { get; set; }
        public VoChongLS VoChong { get; set; }
        public HoGiaDinhLS HoGiaDinh { get; set; }
        public CongDongLS CongDong { get; set; }
        public ToChucLS ToChuc { get; set; }
        public int TRANGTHAI { get; set; }

        #region "Properties"
        public string NGUOIID { get; set; }
        public string CHITIETID { get; set; }
        public string LOAIDOITUONGID { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public string DOITUONGSUDUNGID { get; set; }
        public string MADINHDANH { get; set; }
        public string MASOTHUE { get; set; }
        #endregion
    }
}
