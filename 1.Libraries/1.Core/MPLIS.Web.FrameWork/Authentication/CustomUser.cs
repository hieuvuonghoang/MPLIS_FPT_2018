using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Web.FrameWork.Authentication
{
    public class CustomUser
    {
        public CustomUser()
        {

        }
        public string ID { get; set; }
        public string UserName { get; set; }
        //public string FullName { get; set; }
        public string[] roles { get; set; }
        //public Guid? DonViId { get; set; }
        //public string company { get; set; }
        //public string IsSuperAdmin { get; set; }
        //public string ForceSignOut { get; set; }
        //public string AllowLocalLogin { get; set; }
        //public string Activated { get; set; }
        //public string NeedChangePassword { get; set; }
        //public string ListMenu { get; set; }

        // thong tin cua nguoi dung
        public string HOTENNGUOIDUNG { get; set; }
        public string GIOITINH { get; set; }
        public string SODIENTHOAI { get; set; }
        public string SODIENTHOAI2 { get; set; }
        public string EMAIL { get; set; }
        public string DIACHI { get; set; }
        public string LOAINGUOIDUNG { get; set; }
        public string CAPNGUOIDUNG { get; set; }//1:Trung uong, 2:Tinh, 3:Huyen, 4:Xa
        public string MATINH { get; set; }
        public string MAHUYEN { get; set; }
        public string MADONVIHANHCHINH { get; set; }//Donvihanhchinhid tuong ung cap nguoi dung
        public string CurKVHCID { get; set; }
        //public string DONVIHANHCHINHIDCUATOCHUC { get; set; }
        //public string thongBaoDoiMatkhau { get; set; }
        //public string menuDuocChon { get; set; }

    }
}
