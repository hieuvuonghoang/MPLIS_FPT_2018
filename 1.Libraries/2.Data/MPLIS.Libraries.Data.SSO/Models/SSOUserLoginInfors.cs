using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MPLIS.Libraries.Data.SSO.Models
{
    public class SSOUserLoginInfors
    {
        public Hashtable AllUngDung { get; set; }
        public Hashtable DSUngDung { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpires { get; set; }
        public SSOHtNguoiDung User { get; set; }
        public Hashtable NguoiDungQuyen { get; set; }
        public List<SSOHcXa> NguoiDungXa { get; set; }
        public List<SSOHcHuyen> NguoiDungHuyen { get; set; }
        public Hashtable CauHinhNguoiDung { get; set; }
        public HttpCookie UserCookie { get; set; }
        public SSOHtToChuc ToChuc { get; set; }
        public SSOHtToChucNguoiDung ToChucNguoiDung { get; set; }
        public Hashtable ToChucMenu { get; set; }
        public Hashtable ToChucQuyen { get; set; }
        public Hashtable ToChucKVHC { get; set; }
        public bool SuccessGetData { get; set; }
        public string ThongBao { get; set; }

        public SSOUserLoginInfors()
        {
            AllUngDung = new Hashtable();
            NguoiDungQuyen = new Hashtable();
            NguoiDungXa = new List<SSOHcXa>();
            NguoiDungHuyen = new List<SSOHcHuyen>();
            ToChucMenu = new Hashtable();
            ToChucQuyen = new Hashtable();
            ToChucKVHC = new Hashtable();
            DSUngDung = new Hashtable();
            CauHinhNguoiDung = new Hashtable();
        }
    }
}
