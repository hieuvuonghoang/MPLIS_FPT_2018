using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Web.FrameWork.Authentication
{
    public class ClaimTypes
    {
        //can change these value to uuid
        public const string IsSuperAdmin = "http://mplis.net/identity/claims/IsSuperAdmin";
        //public const string idNguoiDung = "http://mplis.net/identity/claims/idNguoiDung";
        public const string DonViId = "http://mplis.net/identity/claims/DonViId";
        public const string ListMenu = "http://mplis.net/identity/claims/MenuViewModel";
        public const string AllowLocalLogin = "http://mplis.net/identity/claims/AllowLocalLogin";
        public const string ForceSignOut = "http://mplis.net/identity/claims/ForceSignOut";
        public const string Activated = "http://mplis.net/identity/claims/Activated";
        public const string NeedChangePassword = "http://mplis.net/identity/claims/NeedChangePassword";
        // Cac thong tin cua nguoi dung
        public const string HOTENNGUOIDUNG = "http://mplis.net/identity/claims/HOTENNGUOIDUNG";
        public const string GIOITINH = "http://mplis.net/identity/claims/GIOITINH";
        public const string SODIENTHOAI = "http://mplis.net/identity/claims/SODIENTHOAI";
        public const string SODIENTHOAI2 = "http://mplis.net/identity/claims/SODIENTHOAI2";
        public const string EMAIL = "http://mplis.net/identity/claims/EMAIL";
        public const string DIACHI = "http://mplis.net/identity/claims/DIACHI";
        public const string LOAINGUOIDUNG = "http://mplis.net/identity/claims/LOAINGUOIDUNG";
        public const string CAPNGUOIDUNG = "http://mplis.net/identity/claims/CAPNGUOIDUNG";
        public const string MATINH = "http://mplis.net/identity/claims/MATINH";
        public const string MAHUYEN = "http://mplis.net/identity/claims/MAHUYEN";
        public const string DONVIHANHCHINH = "http://mplis.net/identity/claims/DONVIHANHCHINH";
        //public const string CAPTOCHUC = "http://mplis.net/identity/claims/CAPTOCHUC";
        //public const string DONVIHANHCHINHIDCUATOCHUC = "http://mplis.net/identity/claims/DONVIHANHCHINHIDCUATOCHUC";
    }
}
