using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;
using System.Data.Entity;
using MPLIS.Libraries.Data.XuLyHoSo.Models;
using AutoMapper;
using System.Data.Common;
using System.Collections;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http.Headers;
using MPLIS.Libraries.Data.SSO.Models;
using MPLIS.Libraries.Data.SSO.Params;
using MPLIS.Libraries.Services.Utilities;
using MPLIS.Libraries.Services.SSO;
using System.Web.SessionState;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public class HOSOLUUKHOServices
    {
        public static HS_HOSO get_HosoByHSTN(string HoSoTNID)
        {
            HS_HOSO ret = null;
            using (MplisEntities db = new MplisEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;
                var data = (from hs in db.HS_HOSO.Where(t => t.HOSOTIEPNHANID.Equals(HoSoTNID))
                            select new
                            {
                                hs,
                                dsThua = db.HS_LIENKETTHUADAT.Where(t=>t.HOSOID.Equals(hs.HOSOID)),
                                dsfile = db.HS_THANHPHANHOSO.Where(t => t.HOSOID.Equals(hs.HOSOID)),
                                dsGCN =db.HS_TC_GCN.Where(t => t.HOSOID.Equals(hs.HOSOID)),
                                dsChu=db.HS_TC_CHU.Where(t => t.HOSOID.Equals(hs.HOSOID))
                            }).FirstOrDefault();
                if (data != null)
                {
                    ret = data.hs;
                    ret.DSChu = data.dsChu.ToList();
                    ret.DSFileDinhKem = data.dsfile.ToList();
                    ret.DSGCN = data.dsGCN.ToList();
                    ret.DSThua = data.dsThua.ToList();
                    foreach(var a in ret.DSThua)
                    {
                        a.tenxa = getxa(a.XAID);
                    }
                    foreach(var a in ret.DSGCN)
                    {
                        a.tenxa = getxabyma(a.MAKVHC);
                    }
                }
                else
                {
                    ret = new HS_HOSO();
                }
            }
            return ret;
        }
        public static HS_HOSO New_Hoso(BoHoSoModel bhs)
        {
            HS_HOSO hoso = new HS_HOSO();
            hoso.DSGCN = new List<HS_TC_GCN>();
            hoso.DSThua = new List<HS_LIENKETTHUADAT>();
            hoso.DSChu = new List<HS_TC_CHU>();
            hoso.DSFileDinhKem = new List<HS_THANHPHANHOSO>();
            hoso.HOSOID = Guid.NewGuid().ToString();
            hoso.HOSOTIEPNHANID = bhs.HoSoTN.HOSOTIEPNHANID;
            hoso.XAID = bhs.HoSoTN.DONVIHANHCHINHID;
            if(bhs.HoSoTN.BienDong.MABIENDONG!=null)
            hoso.MAHOSO_MB = bhs.HoSoTN.BienDong.MABIENDONG;
            if (bhs.HoSoTN.TENHOSO != null)
                hoso.TENHOSO = bhs.HoSoTN.TENHOSO;
            String s=null;
            foreach(var a in bhs.HoSoTN.BienDong.DSGcn)
            {
                if (a.LAGCNVAO == "N")
                {
                    if (a.MaVach != null && a.MaVach.Length > 6)
                        s = a.MaVach.Substring(a.MaVach.Length - 6);
                    else
                        s = "";
                    break;
                }
            }
            hoso.MAHOSO_ST = s;
            foreach( var gnc in bhs.HoSoTN.BienDong.DSGcn )
            {
                if (gnc.LAGCNVAO == "N")
                {
                    HS_TC_GCN hsgcn = new HS_TC_GCN();
                    hsgcn.HOSOID = hoso.HOSOID;
                    hsgcn.MAKVHC = bhs.HoSoTN.MaKVHC;
                    hsgcn.MAVACH = gnc.MaVach;
                    hsgcn.SOPHATHANH = gnc.SoPhatHanh;
                    hsgcn.SOVAOSO = gnc.GiayChungNhan.SOVAOSO;
                    hsgcn.GCNID = gnc.GIAYCHUNGNHANID;
                    hsgcn.TCGCNID = Guid.NewGuid().ToString();
                    hsgcn.tenxa = bhs.HoSoTN.TenKVHC;
                    hsgcn.GiayChungNhan = gnc.GiayChungNhan;
                    hoso.DSGCN.Add(hsgcn);
                    if (gnc.GiayChungNhan.NGUOIID != null)
                    {
                        var check = (from a in hoso.DSChu where a.CHUID == gnc.GiayChungNhan.NGUOIID select a).FirstOrDefault();
                        if (check == null)
                        {
                            HS_TC_CHU hschu = get_chuhs(gnc.GiayChungNhan.NGUOIID, hoso.HOSOID);
                            hoso.DSChu.Add(hschu);
                        }
                    }
                    if (gnc.GiayChungNhan.BANQUET != null)
                    {
                        HS_THANHPHANHOSO hstphs = new HS_THANHPHANHOSO();
                        hstphs.DUONGDAN = gnc.GiayChungNhan.BANQUET;
                        hstphs.HOSOID = hoso.HOSOID;
                        hstphs.THANHPHANHOSOID = Guid.NewGuid().ToString();
                        hstphs.TENTEPDULIEU = Path.GetFileName(gnc.GiayChungNhan.BANQUET);
                        hoso.DSFileDinhKem.Add(hstphs);
                    }
                    if (gnc.GiayChungNhan.HSKTFILEPATH != null)
                    {
                        HS_THANHPHANHOSO hstphs = new HS_THANHPHANHOSO();
                        hstphs.DUONGDAN = gnc.GiayChungNhan.HSKTFILEPATH;
                        hstphs.HOSOID = hoso.HOSOID;
                        hstphs.THANHPHANHOSOID = Guid.NewGuid().ToString();
                        hstphs.TENTEPDULIEU = Path.GetFileName(gnc.GiayChungNhan.HSKTFILEPATH);
                        hoso.DSFileDinhKem.Add(hstphs);
                    }
                }
            }
            foreach(var thua in bhs.HoSoTN.BienDong.DSThua)
            {
                if (thua.LOAITHUABD == "R")
                {
                    HS_LIENKETTHUADAT thualk = new HS_LIENKETTHUADAT();
                    thualk.HOSOID = hoso.HOSOID;
                    thualk.SOTHUA =  thua.STTThua.ToString();
                    thualk.THUAID = thua.THUADATID;
                    thualk.SOTO = thua.SHToBanDo.ToString();
                    thualk.TOTHUAID = Guid.NewGuid().ToString();
                    thualk.XAID = bhs.HoSoTN.DONVIHANHCHINHID;
                    thualk.tenxa = bhs.HoSoTN.TenKVHC;
                    hoso.DSThua.Add(thualk);
                }
            }
            foreach(var chu in bhs.HoSoTN.BienDong.DSChu)
            {
                HS_TC_CHU hschu = new HS_TC_CHU();
                hschu.CHUID = chu.NGUOIID;
                hschu.DIACHI = chu.Chu_DiaChi;
                hschu.HOSOID = hoso.HOSOID;
                hschu.TENCHU = chu.Chu_HoTen;
                hschu.TCCHUID = Guid.NewGuid().ToString();
                hoso.DSChu.Add(hschu);
            }
            foreach(var hsdinhkem in bhs.HoSoTN.DSFileDinhKem)
            {
                HS_THANHPHANHOSO hstphs = new HS_THANHPHANHOSO();
                hstphs.THANHPHANHOSOID = Guid.NewGuid().ToString();
                hstphs.TENTEPDULIEU = Path.GetFileName(hsdinhkem.DUONGDANFILE);
                hstphs.HOSOID = hoso.HOSOID;
                hstphs.DUONGDAN = hsdinhkem.DUONGDANFILE;
                hstphs.GIAYTOKEMTHEOHSID = hsdinhkem.GIAYTOTHEOTTHCID;
                hstphs.loaihoso = hsdinhkem.GiayToTheoTTHC.TENLOAIGIAYTO;
                hoso.DSFileDinhKem.Add(hstphs);
            }
            return hoso;
        }
        public static List<DM_LOAIBIENDONG> get_MABIENDONG()
        {
            List<DM_LOAIBIENDONG> loaibiendong = new List<DM_LOAIBIENDONG>();
            using (MplisEntities dbo = new MplisEntities())
            {
                loaibiendong = (from a in dbo.DM_LOAIBIENDONG select a).OrderBy(a => a.TENLOAIBIENDONG).ToList();
            }
            return loaibiendong;
        }
        public static List<HS_VITRILUUTRU> get_PHONG()
        {
            List<HS_VITRILUUTRU> listphong = new List<HS_VITRILUUTRU>();
            using (MplisEntities dbo = new MplisEntities())
            {
                listphong = (from a in dbo.HS_VITRILUUTRU where a.MAVITRILUUTRU=="001" select a).OrderBy(a => a.TENVITRILUUTRU).ToList();
            }
            return listphong;
        }
        public static List<HS_VITRILUUTRU> get_KE()
        {
            List<HS_VITRILUUTRU> listke = new List<HS_VITRILUUTRU>();
            using (MplisEntities dbo = new MplisEntities())
            {
                listke = (from a in dbo.HS_VITRILUUTRU where a.MAVITRILUUTRU == "002" select a).OrderBy(a => a.TENVITRILUUTRU).ToList();
            }
            return listke;
        }
        public static List<HS_VITRILUUTRU> get_NGAN()
        {
            List<HS_VITRILUUTRU> listngan = new List<HS_VITRILUUTRU>();
            using (MplisEntities dbo = new MplisEntities())
            {
                listngan = (from a in dbo.HS_VITRILUUTRU where a.MAVITRILUUTRU == "003" select a).OrderBy(a => a.TENVITRILUUTRU).ToList();
            }
            return listngan;
        }
        public static List<HS_VITRILUUTRU> get_HOP()
        {
            List<HS_VITRILUUTRU> listhop = new List<HS_VITRILUUTRU>();
            using (MplisEntities dbo = new MplisEntities())
            {
                listhop = (from a in dbo.HS_VITRILUUTRU where a.MAVITRILUUTRU == "004" select a).OrderBy(a => a.TENVITRILUUTRU).ToList();
            }
            return listhop;
        }
        public static  List<DM_GIAYTOKEMTHEOHS> get_giayto()
        {
            List<DM_GIAYTOKEMTHEOHS> listgiayto = new List<DM_GIAYTOKEMTHEOHS>();
            using (MplisEntities dbo = new MplisEntities())
            {
                listgiayto = (from a in dbo.DM_GIAYTOKEMTHEOHS  select a).OrderBy(a => a.TENGIAYTOKEMTHEOHS).ToList();
            }
            return listgiayto;
        }
        public static HS_VITRILUUTRU CapNhatViTri(string loai,string ten,string id,string xaid)
        {
            HS_VITRILUUTRU vitri =new HS_VITRILUUTRU();
            using (MplisEntities dbo = new MplisEntities())
            {
                if (id != null && id != "")
            {

                    vitri = (from a in dbo.HS_VITRILUUTRU where a.VITRILUUTRUID.Equals(id) select a).FirstOrDefault();
                    vitri.MAVITRILUUTRU = loai;
                    vitri.TENVITRILUUTRU = ten;
                    dbo.Entry(vitri).State = EntityState.Modified;
            }
            else
            {
                    vitri.VITRILUUTRUID = Guid.NewGuid().ToString();
                    vitri.MAVITRILUUTRU = loai;
                    vitri.TENVITRILUUTRU = ten;
                    vitri.XAID = xaid;
                    dbo.HS_VITRILUUTRU.Add(vitri);
            }
                dbo.SaveChanges();
            }
            return vitri;
        }
        public static HS_TC_CHU get_chuhs(string NGUOIID,string hosoid)
        {
            HS_TC_CHU chu_hs = new HS_TC_CHU();
            using (MplisEntities dbo = new MplisEntities())
            {
                var nguoi = (from a in dbo.DC_NGUOI where a.NGUOIID == NGUOIID select a).FirstOrDefault();
                chu_hs.TCCHUID = Guid.NewGuid().ToString();
                chu_hs.CHUID = nguoi.NGUOIID;
                chu_hs.HOSOID = hosoid;
                switch (nguoi.LOAIDOITUONGID)
                {
                    case "1":
                        var canhan = (from a in dbo.DC_CANHAN where a.CANHANID == nguoi.CHITIETID select a).FirstOrDefault();
                        chu_hs.DIACHI = canhan.DIACHI;
                        chu_hs.SOGIAYTOXM = canhan.SOGIAYTO;
                        chu_hs.TENCHU = canhan.HOTEN;
                        break;
                    case "2":
                        var hogiadinh = (from a in dbo.DC_HOGIADINH where a.HOGIADINHID == nguoi.CHITIETID select a).FirstOrDefault();
                        var chuho = (from a in dbo.DC_CANHAN where a.CANHANID == hogiadinh.CHUHO select a).FirstOrDefault();
                        chu_hs.DIACHI = hogiadinh.DIACHI;
                        chu_hs.SOGIAYTOXM = hogiadinh.CMTCHUHO;
                        chu_hs.TENCHU = chuho.HOTEN;
                        break;
                    case "3":
                        var vochong = (from a in dbo.DC_VOCHONG where a.VOCHONGID == nguoi.CHITIETID select a).FirstOrDefault();
                        var chong = (from a in dbo.DC_CANHAN where a.CANHANID == vochong.CHONG select a).FirstOrDefault();
                        chu_hs.DIACHI = vochong.DIACHI;
                        chu_hs.SOGIAYTOXM = vochong.CMTCHONG;
                        chu_hs.TENCHU = chong.HOTEN;
                        break;
                    case "4":
                        var tochuc = (from a in dbo.DC_TOCHUC where a.TOCHUCID == nguoi.CHITIETID select a).FirstOrDefault();
                        chu_hs.DIACHI = tochuc.DIACHI;
                        chu_hs.SOGIAYTOXM = tochuc.SOQUYETDINH;
                        chu_hs.TENCHU = tochuc.TENTOCHUC;
                        break;
                    case "5":
                        var congdong = (from a in dbo.DC_CONGDONG where a.CONGDONGID == nguoi.CHITIETID select a).FirstOrDefault();
                        chu_hs.DIACHI = congdong.DIACHI;
                        chu_hs.SOGIAYTOXM = congdong.CMTNGUOIDAIDIEN;
                        chu_hs.TENCHU = congdong.TENCONGDONG;
                        break;
                    case "6":
                        var nhomnguoi = (from a in dbo.DC_NHOMNGUOI where a.NHOMNGUOIID == nguoi.CHITIETID select a).FirstOrDefault();
                        var chunhom = (from a in dbo.DC_CANHAN where a.CANHANID == nhomnguoi.NGUOIDAIDIEN select a).FirstOrDefault();
                        chu_hs.SOGIAYTOXM = nhomnguoi.CMTNGUOIDAIDIEN;
                        chu_hs.TENCHU = chunhom.HOTEN;
                        break;
                    default:
                        break;
                }
            }
            return chu_hs;
        }
        public static string save(HS_HOSO hoso)
        {
            string result = "";
            try
            {
                using (MplisEntities dbo = new MplisEntities())
                {
                    var luuhoso = (from a in dbo.HS_HOSO where a.HOSOID == hoso.HOSOID select a).FirstOrDefault();
                    if (luuhoso == null)
                    {
                        dbo.HS_HOSO.Add(hoso);
                        result = "Thêm mới hồ sơ lưu kho thành công";
                    }
                    else
                    {
                        luuhoso.MAHOSO = hoso.MAHOSO;
                        luuhoso.MAHOSO_MB = hoso.MAHOSO_MB;
                        luuhoso.MAHOSO_ST = hoso.MAHOSO_ST;
                        luuhoso.MAHOSO_TB = hoso.MAHOSO_TB;
                        luuhoso.XAID = hoso.XAID;
                        luuhoso.TENHOSO = hoso.TENHOSO;
                        luuhoso.TENHOP = hoso.TENHOP;
                        luuhoso.PHONG = hoso.PHONG;
                        luuhoso.NGAYHOSO = hoso.NGAYHOSO;
                        luuhoso.NGAN = hoso.NGAN;
                        luuhoso.KE = hoso.KE;
                        luuhoso.HOP = hoso.HOP;
                        luuhoso.GHICHU = hoso.GHICHU;
                        dbo.Entry(luuhoso).State = EntityState.Modified;
                        result = "Cập nhật hồ sơ lưu kho thành công";
                    }
                    dbo.SaveChanges();
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            return result;
        }
        public static bool check_hslk(string hosoid)
        {
            using (MplisEntities dbo = new MplisEntities())
            {
                var check = (from a in dbo.HS_HOSO where a.HOSOID == hosoid select a).FirstOrDefault();
                if (check == null)
                    return false;
                else
                    return true;
            }
        }
        public static void SAVE_DSGCN(HS_HOSO hoso)
        {
            using (MplisEntities dbo = new MplisEntities())
            {
                Del(hoso.HOSOID,"HS_TC_GCN");
               // foreach(var a in hoso.DSGCN)
               // {
              //      dbo.HS_TC_GCN.Add(a);
              //  }
                dbo.SaveChanges();
            }
        }
        public static void SAVE_DSTHUA(HS_HOSO hoso)
        {
            using (MplisEntities dbo = new MplisEntities())
            {
                Del(hoso.HOSOID, "HS_LIENKETTHUADAT");
               // foreach (var a in hoso.DSThua)
               // {
               //     dbo.HS_LIENKETTHUADAT.Add(a);
               // }
                dbo.SaveChanges();
            }
        }
        public static void SAVE_DSCHU(HS_HOSO hoso)
        {
            using (MplisEntities dbo = new MplisEntities())
            {
                Del(hoso.HOSOID, "HS_TC_CHU");
               // foreach (var a in hoso.DSChu)
               // {
               //     dbo.HS_TC_CHU.Add(a);
               // }
                dbo.SaveChanges();
            }
        }
        public static void Del(string  hosoid,string loai)
        {
            using (MplisEntities db = new MplisEntities())
            {
                if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                        || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                    db.Database.Connection.Open();
                var trans = db.Database.Connection.BeginTransaction();
                DbCommand cmd = db.Database.Connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "delete from "+loai+" where HOSOID = '" + hosoid + "'";
                cmd.ExecuteNonQuery();
                trans.Commit();
                db.SaveChanges();
            }
        }
        public static string getxa(string xaid)
        {
            using (MplisEntities db = new MplisEntities())
            {
              var  xa = (from a in db.HC_DMKVHC where a.KVHCID == xaid select a).FirstOrDefault();
                return xa.TENKVHC;
            }
        }
        public static string gethuyen(string xaid)
        {
            using (MplisEntities db = new MplisEntities())
            {
                var xa = (from a in db.HC_DMKVHC where a.KVHCID == xaid select a).FirstOrDefault();
                var huyen = (from a in db.HC_HUYEN where a.HUYENID == xa.HUYENID select a).FirstOrDefault();
                return huyen.TENHUYEN;
            }
        }
        public static string gettinh(string xaid)
        {
            using (MplisEntities db = new MplisEntities())
            {
                var xa = (from a in db.HC_DMKVHC where a.KVHCID == xaid select a).FirstOrDefault();
                var huyen = (from a in db.HC_HUYEN where a.HUYENID == xa.HUYENID select a).FirstOrDefault();
                var tinh = (from a in db.HC_TINH where a.TINHID == huyen.TINHID select a).FirstOrDefault();
                return tinh.TENTINH;
            }
        }
        public static string getxabyma(string maKVHC)
        {
            using (MplisEntities db = new MplisEntities())
            {
                var xa = (from a in db.HC_DMKVHC where a.MAXA == maKVHC select a).FirstOrDefault();
                return xa.TENKVHC;
            }
        }

    }
}