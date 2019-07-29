using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class QT_HOSOTIEPNHAN
    {
        public DC_DONDANGKY DonDangKy { get; set; }
        public DC_BIENDONG BienDong { get; set; }
        public DC_BIENDONG CurBienDong { get; set; }
        public QT_THUTUCHANHCHINH ThuTucHanhChinh { get; set; }
        public QT_HOSO_LANXULY HoSoLanXuLy { get; set; }
        public HT_TOCHUC HeThongToChuc { get; set; }
        public List<QT_FILEDINHKEMHOSO> DSFileDinhKem { get; set; }
        public bool isInitData = false;
        public string MaKVHC { get; set; }
        public string TenKVHC { get; set; }
        public string TenThuThuHanhChinh { get; set; }
    }
}
