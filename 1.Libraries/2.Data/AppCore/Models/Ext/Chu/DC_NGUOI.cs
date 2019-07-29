using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class DC_NGUOI
    {
     
        public DC_CANHAN CaNhan { get; set; }
        public DC_NHOMNGUOI NhomNguoi { get; set; }
        public DC_VOCHONG VoChong { get; set; }
        public DC_HOGIADINH HoGiaDinh { get; set; }
        public DC_CONGDONG CongDong { get; set; }
        public DC_TOCHUC ToChuc { get; set; }
        public DM_DOITUONGSUDUNG DoiTuongSuDung { get; set; }
        public int TRANGTHAI { get; set; }
        public int TRANGTHAI_NGUOI { get; set; }
        public void getData()
        {
            using (MplisEntities db = new MplisEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                switch (LOAIDOITUONGID)
                {
                    case "1"://DC_CANHAN
                        var objchu1 = (from item in db.DC_CANHAN where item.CANHANID == CHITIETID select item).FirstOrDefault();
                        if (objchu1 != null)
                        {
                            CaNhan = objchu1;
                            CaNhan.getData();
                        }
                        break;
                    case "2"://DC_HOGIADINH
                        var objchu2 = (from item in db.DC_HOGIADINH where item.HOGIADINHID == CHITIETID select item).FirstOrDefault();
                        if (objchu2 != null)
                        {
                            HoGiaDinh = objchu2;
                            var objThanhVien = (from t1 in db.DC_HOGIADINH
                                                where t1.HOGIADINHID == objchu2.HOGIADINHID
                                                join t2 in db.DC_HOGIADINH_THANHVIEN on t1.HOGIADINHID equals t2.HOGIADINHID
                                                join t3 in db.DC_CANHAN on t2.CANHANID equals t3.CANHANID
                                                select new
                                                {
                                                    t2,
                                                    t3
                                                }
                                                ).ToList();
                            if (objThanhVien != null)
                            {
                                List<DC_HOGIADINH_THANHVIEN> ls = new List<Models.DC_HOGIADINH_THANHVIEN>();
                                foreach (var it in objThanhVien)
                                {
                                    it.t2.ThanhVien = it.t3;
                                    ls.Add(it.t2);
                                }
                                HoGiaDinh.DSThanhVien = ls;
                                foreach (var ithgd in HoGiaDinh.DSThanhVien)
                                {
                                    ithgd.ThanhVien.getData();
                                }
                            }
                        }
                        break;
                    case "3"://DC_VOCHONG
                        var objchu3 = (from item in db.DC_VOCHONG where item.VOCHONGID == CHITIETID select item).FirstOrDefault();
                        if (objchu3 != null)
                        {
                            VoChong = objchu3;
                            List<string> vcs = new List<string> { VoChong.VO, VoChong.CHONG };
                            var objvc = db.DC_CANHAN.Where(s => vcs.Contains(s.CANHANID)).ToList();
                            if (objvc != null)
                            {
                                foreach (var vc in objvc)
                                {
                                    if (vc.CANHANID.Equals(VoChong.VO)) VoChong.VoCN = vc;
                                    if (vc.CANHANID.Equals(VoChong.CHONG)) VoChong.ChongCN = vc;
                                    vc.getData();
                                }
                            }
                        }
                        break;
                    case "4"://DC_CONGDONG
                        var objchu4 = (from item in db.DC_CONGDONG where item.CONGDONGID == CHITIETID select item).FirstOrDefault();
                        if (objchu4 != null)
                        {
                            CongDong = objchu4;
                            var objcn = (from item in db.DC_CANHAN where item.CANHANID == CongDong.NGUOIDAIDIENID select item).FirstOrDefault();
                            if (objcn != null)
                            {
                                CongDong.NguoiDaiDien = objcn;
                                CongDong.NguoiDaiDien.getData();
                            }

                        }
                        break;
                    case "5"://DC_TOCHUC
                        var objchu5 = (from item in db.DC_TOCHUC where item.TOCHUCID == CHITIETID select item).FirstOrDefault();
                        if (objchu5 != null)
                        {
                            ToChuc = objchu5;
                            var objcn1 = (from item in db.DC_CANHAN where item.CANHANID == ToChuc.NGUOIDAIDIENID select item).FirstOrDefault();
                            if (objcn1 != null)
                            {
                                ToChuc.NguoiDaiDien = objcn1;
                                ToChuc.NguoiDaiDien.getData();
                            }
                        }
                        break;
                    case "6"://DC_NHOMNGUOI
                        //var objTV = (from t1 in db.DC_NHOMNGUOI.Where(t => t.NHOMNGUOIID == CHITIETID)
                        //             from t2 in db.DC_NHOMNGUOI_THANHVIEN.Where(t => t.NHOMNGUOIID == t1.NHOMNGUOIID).DefaultIfEmpty()
                        //             from t3 in db.DC_CANHAN.Where(t => t.CANHANID == t2.THANHPHANID).DefaultIfEmpty()
                        //             join gt in db.DC_GIAYTOTUYTHAN on t3.CANHANID equals gt.CANHANID into gttt
                        //             from gt in gttt.DefaultIfEmpty()
                        //             select new
                        //             {
                        //                 t1,
                        //                 t2,
                        //                 t3,
                        //                 gttt
                        //             }).ToList();
                        //if (objTV != null && objTV.Count > 0)
                        //{
                        //    NhomNguoi = objTV[0].t1;
                        //    List<DC_NHOMNGUOI_THANHVIEN> ls = new List<DC_NHOMNGUOI_THANHVIEN>();
                        //    Hashtable tv = new Hashtable();
                        //    foreach (var it in objTV)
                        //    {
                        //        if (!tv.Contains(it.t3.CANHANID))
                        //        {
                        //            it.t2.ThanhVien = it.t3;
                        //            it.t2.ThanhVien.DSGiayToTuyThan = it.gttt.ToList();
                        //            ls.Add(it.t2);
                        //            tv.Add(it.t3.CANHANID, it.t3.CANHANID);
                        //        }
                        //    }
                        //    NhomNguoi.DSThanhVien = ls;
                        //}
                        break;
                    default:
                        break;
                }
            }
        }
        
    }
}
