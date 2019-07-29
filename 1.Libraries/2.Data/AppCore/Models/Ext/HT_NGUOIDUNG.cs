using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class HT_NGUOIDUNG
    {
        public string Id
        {
            get
            {
                return NGUOIDUNGID;
            }
            set
            {
                NGUOIDUNGID = value;
            }
        }
        public string UserName {
            get
            {
                return TENDANGNHAP;
            }
            set
            {
                TENDANGNHAP = value;
            }
        }

        private Hashtable _UserRoles = new Hashtable();

        public Hashtable UserRoles
        {
            get { return _UserRoles; }
            set { _UserRoles = value; }
        }

        public string ungDungDuocChon { get; set; }
        public string batPopUpDoiMatKhau { get; set; }
        public string thongBaoDoiMatkhau { get; set; }
        public string menuDuocChon { get; set; }
    }
}
