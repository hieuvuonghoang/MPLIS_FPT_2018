using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class HoGiaDinhLS
    {
        public HoGiaDinhLS()
        {
            DSThanhVien = new List<HoGiaDinhThanhVienLS>();
        }
        //Danh sách id của các thành viên thuộc gia đình
        public List<HoGiaDinhThanhVienLS> DSThanhVien { get; set; }
        public HoGiaDinhThanhVienLS CurHGDThanhVien { get; set; }
        public CaNhanLS ChuHoCN { get; set; }
        public CaNhanLS VoChongCN { get; set; }
        public int TRANGTHAI { get; set; }
        public string CHUHO_HOTEN { get; set; }
        public string VOCHONG_HOTEN { get; set; }

        #region "Properties"
        public string HOGIADINHID { get; set; }
        public string CHUHO { get; set; }
        public string VOCHONG { get; set; }
        public string DIACHI { get; set; }
        public string DIACHIID { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public string CMTCHUHO { get; set; }
        public string CMTVOCHONG { get; set; }
        #endregion
    }
}
