using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;

namespace MPLIS.Libraries.Data.QTHT.Models
{
    public class NguoiDungModel
    {
        MplisEntities db = new MplisEntities();
        public HT_NGUOIDUNG htNguoiDung { get; set; }
        public string XACNHANMATKHAU { get; set; }
        public string CAPDVHC { get; set; }
        public string _TENDVHC {
            get
            {
                string tendvhc = null;
                if (htNguoiDung.CAPNGUOIDUNG == "1")
                {
                    tendvhc = null;
                }
                if (htNguoiDung.CAPNGUOIDUNG == "2")
                {
                    tendvhc = db.HC_TINH.Single(x => x.TINHID == htNguoiDung.DONVIHANHCHINHID).TENTINH;
                }
                if (htNguoiDung.CAPNGUOIDUNG == "3")
                {
                    tendvhc = db.HC_HUYEN.Single(x => x.HUYENID == htNguoiDung.DONVIHANHCHINHID).TENHUYEN;
                }
                return tendvhc;
            }
        }
        public string _TENTOCHUC
        {
            get
            {
                List<HT_TOCHUC_NGUOIDUNG> lsttochucND = db.HT_TOCHUC_NGUOIDUNG.Where(x => x.NGUOIDUNGID == htNguoiDung.NGUOIDUNGID).ToList();
                
                string tentochuc = null;
                if (lsttochucND.Count == 0)
                {
                    tentochuc = null;
                }
                else
                {
                    foreach (var item in lsttochucND)
                    {
                        var tochucid = item.TOCHUCID;
                        tentochuc += db.HT_TOCHUC.Single(x=>x.TOCHUCID == tochucid).TENTOCHUC + " , ";
                    }
                }
                return tentochuc;
            }
        }
        public string _LOAINGUOIDUNG
        {
            get
            {
                string loainguoidung = null;
                if (htNguoiDung.LOAINGUOIDUNG == 1)
                {
                    loainguoidung = "Giám sát hệ thống";
                }
                if (htNguoiDung.LOAINGUOIDUNG == 2)
                {
                    loainguoidung = "Quản trị hệ thống";
                }
                if (htNguoiDung.LOAINGUOIDUNG == 3)
                {
                    loainguoidung = "Cán bộ tác nghiệp";
                }
                if (htNguoiDung.LOAINGUOIDUNG == 4)
                {
                    loainguoidung = "Công chức địa chính xã";
                }
                if (htNguoiDung.LOAINGUOIDUNG == 5)
                {
                    loainguoidung = "Người dùng tra cứu";
                }
                return loainguoidung;
            }
        }
        public string _ANHBIEUTUONG
        {
            get
            {
                if (htNguoiDung.ANHBIEUTUONG != null)
                {
                    var base64 = Convert.ToBase64String(htNguoiDung.ANHBIEUTUONG);
                    return String.Format("data:image/gif;base64,{0}", base64);
                }
                return null;
            }
        }

        //Ánh xạ trường CHOPHEPSUDUNG từ dạng char(1) sang boolean
        public Boolean _CHOPHEPSUDUNG
        {
            set
            {
                if (value)
                {
                    this.htNguoiDung.CHOPHEPSUDUNG = "1";
                }
                else
                {
                    this.htNguoiDung.CHOPHEPSUDUNG = "0";
                }
            }
            get
            {
                if (htNguoiDung.CHOPHEPSUDUNG == null || htNguoiDung.CHOPHEPSUDUNG.Equals("0"))
                {
                    return false;
                }
                return true;
            }
        }
        //Ánh xạ trường PHAITHAYDOIMATKHAU từ dạng char(1) sang boolean
        public Boolean _PHAITHAYDOIMATKHAU
        {
            get
            {
                if (htNguoiDung.PHAITHAYDOIMATKHAU == null || htNguoiDung.PHAITHAYDOIMATKHAU.Equals("0"))
                {
                    return false;
                }
                return true;
            }
            set
            {
                if (value)
                {
                    htNguoiDung.PHAITHAYDOIMATKHAU = "1";
                }
                else
                {
                    htNguoiDung.PHAITHAYDOIMATKHAU = "0";
                }
            }
        }
        public List<ToChucNguoiDung> lstTCND { get; set; }
        public List<XaNguoiDung> lstXaND { get; set; }
    }
    public class ToChucNguoiDung {
        public List<string> tochucid { get; set; }
        public string TCID { get; set; }
        public string TENTOCHUC { get; set; }
        public List<string> CHUCVU { get; set; }
        public string TenChucVu { get; set; }
    }
    public class XaNguoiDung
    {
        public List<string> lstxaid { get; set; }
        public string XAID { get; set; }
        public string TENXA { get; set; }
        public string TENHUYEN { get; set; }
    }
}