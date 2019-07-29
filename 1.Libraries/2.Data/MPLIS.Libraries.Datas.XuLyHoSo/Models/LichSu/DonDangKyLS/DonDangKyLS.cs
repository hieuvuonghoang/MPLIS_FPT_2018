using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class DonDangKyLS
    {
        public List<DangKy_GCNLS> DSDangKyGCN { get; set; }
        public List<DangKy_NguoiLS> DSDangKyChu { get; set; }
        public List<DangKy_TaiSanLS> DSDangKyTaiSan { get; set; }
        public List<DangKy_ThuaLS> DSDangKyThua { get; set; }
        public List<XacNhanDonDangKyLS> DSXacNhan { get; set; }

        public DonDangKyLS()
        {
            DSDangKyGCN = new List<Models.DangKy_GCNLS>();
            DSDangKyChu = new List<Models.DangKy_NguoiLS>();
            DSDangKyTaiSan = new List<Models.DangKy_TaiSanLS>();
            DSDangKyThua = new List<Models.DangKy_ThuaLS>();
            DSXacNhan = new List<Models.XacNhanDonDangKyLS>();
        }

        #region "Properties"
        public string DONDANGKYID { get; set; }
        public string MADON { get; set; }
        public Nullable<System.DateTime> NGAYDANGKY { get; set; }
        public string GHICHU { get; set; }
        public string DACAPGIAY { get; set; }
        public string CANCUPHAPLY { get; set; }
        public string SOVAOSO { get; set; }
        public Nullable<System.DateTime> NGAYCAP { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public string HOSOTIEPNHANID { get; set; }
        #endregion
    }
}
