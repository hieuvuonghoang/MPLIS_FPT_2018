using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;
using MPLIS.Libraries.Data.XuLyHoSo.Models;
using System.Data.Entity;
using AutoMapper;
using System.Data.Common;
using System.Collections;
using Newtonsoft.Json.Linq;


namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCTAISANGANLIENVOIDATServices
    {
        public static DC_TAISANGANLIENVOIDAT getTaiSanGanLienVoiDat(string TaiSanGanLienVoiDatID)
        {
            DC_TAISANGANLIENVOIDAT ret = null;
            DC_CANHO retch = null;
            using (MplisEntities db = new MplisEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;
                var data = (from ts in db.DC_TAISANGANLIENVOIDAT.Where(t => t.TAISANGANLIENVOIDATID.Equals(TaiSanGanLienVoiDatID))
                            select new
                            {
                                ts,
                                dsThua = ts.DC_THUATAISAN
                            }).FirstOrDefault();
                var chhm = (from ch in db.DC_CANHO.Where(c => c.uId.Equals(TaiSanGanLienVoiDatID))
                            select new
                            {
                                ch,
                                dsHangMuc = ch.DC_CANHO_HANGMUCNCH
                            }).FirstOrDefault();
                if (data != null)
                {
                    ret = data.ts;
                    ret.diachitaisan = get_diachibytaisanid(ret.TAISANGANLIENVOIDATID);
                    ret.LoaiTaiSanGanLienVoiDat = DMLOAITAISANGANLIENVOIDATServices.getLoaiTaiSanGanLienVoiDat(ret.LOAITAISAN);
                    if (data.dsThua != null)
                        ret.DSThua = data.dsThua.ToList();
                    if (chhm != null)
                    {
                        retch = chhm.ch;
                        if (chhm.dsHangMuc != null)
                            ret.DSHangMuc = chhm.dsHangMuc.ToList();
                    }
                    if (ret.TAISANID != null)
                    {
                        ret.getData();
                    }
                }
            }
            return ret;
        }

        //HieuVH2
        public static DC_TAISANGANLIENVOIDAT GetTaiSanGanLienVoiDat(string taiSanGanLienVoiDatID)
        {
            DC_TAISANGANLIENVOIDAT taiSanGanLienVoiDat = null;
            using (MplisEntities db = new MplisEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;
                var ret = db.DC_TAISANGANLIENVOIDAT.Where(it => it.TAISANGANLIENVOIDATID == taiSanGanLienVoiDatID)
                    .Select(taiSan => new
                    {
                        taiSan,
                        loaiTaiSan = db.DM_LOAITAISANGANLIENVOIDAT.Where(it => it.MALOAITAISANGANLIENVOIDAT == taiSan.LOAITAISAN).FirstOrDefault()
                    }).FirstOrDefault();
                if (ret != null)
                {
                    if (ret.loaiTaiSan != null)
                        taiSanGanLienVoiDat.LoaiTaiSanGanLienVoiDat = ret.loaiTaiSan;
                    switch (ret.taiSan.LOAITAISAN)
                    {
                        case "1":
                            ret.taiSan.NhaRiengLe = DCNHARIENGLEServices.GetNhaRiengLe(ret.taiSan.TAISANID, db);
                            break;
                        case "2":
                            ret.taiSan.KhuChungCu = DCKHUCHUNGCUServices.GetKhuChungCu(ret.taiSan.TAISANID, db);
                            break;
                        case "3":
                            ret.taiSan.NhaChungCu = DCNHACHUNGCUServices.GetNhaChungCu(ret.taiSan.TAISANID, db);
                            break;
                        case "4":
                            ret.taiSan.CanHo = DCCANHOServices.GetCanHo(ret.taiSan.TAISANID, db);
                            break;
                        case "5":
                            ret.taiSan.HangMucNgoaiCanHo = DCHANGMUCNGOAICANHOServices.GetHangMucNgoaiCanHo(ret.taiSan.TAISANID, db);
                            break;
                        case "6":
                            ret.taiSan.CongTrinhXayDung = DCCONGTRINHXAYDUNGServices.GetCongTringXayDung(ret.taiSan.TAISANID, db);
                            break;
                        case "7":
                            ret.taiSan.CongTrinhNgam = DCCONGTRINHNGAMServices.GetCongTrinhNgam(ret.taiSan.TAISANID, db);
                            break;
                        case "8":
                            ret.taiSan.HangMucCongTrinh = DCHANGMUCCONGTRINHServices.GetHangMucCongTrinh(ret.taiSan.TAISANID, db);
                            break;
                        case "9":
                            ret.taiSan.RungTrong = DCRUNGTRONGServices.GetRungTrong(ret.taiSan.TAISANID, db);
                            break;
                        case "10":
                            ret.taiSan.CayLauNam = DCCAYLAUNAMServices.GetCayLauNam(ret.taiSan.TAISANID, db);
                            break;
                        default:
                            break;
                    }
                    ret.taiSan.DSThua = DCTHUATAISANServices.GetDSThuaTaiSan(ret.taiSan.TAISANGANLIENVOIDATID, db);
                    taiSanGanLienVoiDat = ret.taiSan;
                }
            }
            return taiSanGanLienVoiDat;
        }

        //Code Old
        public static DC_TAISANGANLIENVOIDAT getTaiSanGanLienVoiDatByTaiSanID(string taiSanID)
        {
            DC_TAISANGANLIENVOIDAT ret = null;
            DC_CANHO retch = null;
            using (MplisEntities db = new MplisEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;
                var data = (from ts in db.DC_TAISANGANLIENVOIDAT.Where(t => t.TAISANGANLIENVOIDATID.Equals(taiSanID) || t.TAISANID.Equals(taiSanID))
                            select new
                            {
                                ts,
                                dsThua = ts.DC_THUATAISAN
                            }).FirstOrDefault();
                var chhm = (from ch in db.DC_CANHO.Where(c => c.uId.Equals(taiSanID))
                            select new
                            {
                                ch,
                                dsHangMuc = ch.DC_CANHO_HANGMUCNCH
                            }).FirstOrDefault();
                if (data != null)
                {
                    ret = data.ts;
                    ret.diachitaisan = get_diachibytaisanid(ret.TAISANGANLIENVOIDATID);
                    ret.LoaiTaiSanGanLienVoiDat = DMLOAITAISANGANLIENVOIDATServices.getLoaiTaiSanGanLienVoiDat(ret.LOAITAISAN);
                    if (data.dsThua != null)
                        ret.DSThua = data.dsThua.ToList();
                    if (chhm != null)
                    {
                        retch = chhm.ch;
                        if (chhm.dsHangMuc != null)
                            ret.DSHangMuc = chhm.dsHangMuc.ToList();
                    }

                    if (ret.TAISANID != null)
                    {
                        ret.getData();
                    }
                }
            }
            return ret;
        }
        public static List<DC_KHUCHUNGCU> getdc_khuchungcu(BoHoSoModel bhs)
        {
            List<DC_KHUCHUNGCU> lstkhuchungcu = new List<DC_KHUCHUNGCU>();
            foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
            {
                if (item.TaiSanGanLienVoiDat.KhuChungCu != null)
                    lstkhuchungcu.Add(item.TaiSanGanLienVoiDat.KhuChungCu);
            }
            return lstkhuchungcu;
        }
        public static List<DC_NHACHUNGCU> getdc_nhachungcu(BoHoSoModel bhs, string a)
        {
            List<DC_NHACHUNGCU> lstnhachungcu = new List<DC_NHACHUNGCU>();
            if (a != null && a != "")
            {
                foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                {
                    if (item.TaiSanGanLienVoiDat.NhaChungCu != null && item.TaiSanGanLienVoiDat.NhaChungCu.KHUCHUNGCUID == a)
                        lstnhachungcu.Add(item.TaiSanGanLienVoiDat.NhaChungCu);
                }
            }
            else
            {
                foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                {
                    if (item.TaiSanGanLienVoiDat.NhaChungCu != null)
                        lstnhachungcu.Add(item.TaiSanGanLienVoiDat.NhaChungCu);
                }
            }
            return lstnhachungcu;
        }
        public static List<DC_CONGTRINHXAYDUNG> getdc_congtrinhxaydung(BoHoSoModel bhs)
        {
            List<DC_CONGTRINHXAYDUNG> lstcongtrinhxaydung = new List<DC_CONGTRINHXAYDUNG>();

            using (MplisEntities db = new MplisEntities())
            {
                lstcongtrinhxaydung = (from t1 in db.DC_CONGTRINHXAYDUNG
                                       join t2 in db.DC_DANGKY_TAISAN
                                       on t1.uId equals t2.TAISANID
                                       where t2.DONDANGKYID == bhs.HoSoTN.DonDangKy.DONDANGKYID
                                       select t1).OrderBy(a => a.TENCONGTRINH).ToList();
            }

            return lstcongtrinhxaydung;
        }
        public static List<DM_LOAITRANGTHAIDANGKYCAPGCN> get_tinhtrangcanho()
        {
            List<DM_LOAITRANGTHAIDANGKYCAPGCN> lstdm_ttch = new List<DM_LOAITRANGTHAIDANGKYCAPGCN>();
            using (MplisEntities db = new MplisEntities())
            {
                lstdm_ttch = (from item in db.DM_LOAITRANGTHAIDANGKYCAPGCN
                              select item).OrderBy(a => a.TENLOAITRANGTHAIDANGKYCAPGCN).ToList();
            }
            return lstdm_ttch;
        }
        public static List<DM_LOAINHA> get_loainharieng()
        {
            List<DM_LOAINHA> lst_loainha = new List<DM_LOAINHA>();
            using (MplisEntities db = new MplisEntities())
            {
                lst_loainha = (from item in db.DM_LOAINHA
                               select item).OrderBy(a => a.TENLOAINHA).ToList();
            }
            return lst_loainha;
        }
        public static List<DM_LOAICAPHANG> get_loaicaphang()
        {
            List<DM_LOAICAPHANG> lst_loaicaphang = new List<DM_LOAICAPHANG>();
            using (MplisEntities db = new MplisEntities())
            {
                lst_loaicaphang = (from item in db.DM_LOAICAPHANG
                                   select item).OrderBy(a => a.TENLOAICAPHANG).ToList();
            }
            return lst_loaicaphang;
        }
        public static bool SaveDangKyTaiSan(List<DC_DANGKY_TAISAN> dsdangkytaisan)
        {
            bool save = false;
            try
            {
                using (MplisEntities dbo = new MplisEntities())
                {
                    foreach (var taisan in dsdangkytaisan)
                    {
                        if (taisan.TaiSanGanLienVoiDat != null)
                        {
                            switch (taisan.trangthaitaisan)
                            {
                                //thêm mới
                                case 1:
                                    {
                                        switch (taisan.TaiSanGanLienVoiDat.LOAITAISAN)
                                        {
                                            // nhà riêng lẻ
                                            case "1":
                                                {
                                                    dbo.DC_NHARIENGLE.Add(taisan.TaiSanGanLienVoiDat.NhaRiengLe);
                                                    // dbo.SaveChanges();
                                                    break;
                                                }
                                            case "2":
                                                {
                                                    dbo.DC_KHUCHUNGCU.Add(taisan.TaiSanGanLienVoiDat.KhuChungCu);
                                                    // dbo.SaveChanges();
                                                    break;
                                                }
                                            case "3":
                                                {
                                                    dbo.DC_NHACHUNGCU.Add(taisan.TaiSanGanLienVoiDat.NhaChungCu);
                                                    // dbo.SaveChanges();
                                                    break;
                                                }
                                            // nhà căn hộ
                                            case "4":
                                                {
                                                    dbo.DC_CANHO.Add(taisan.TaiSanGanLienVoiDat.CanHo);
                                                    foreach (var themchhm in taisan.TaiSanGanLienVoiDat.DSHangMuc)
                                                    {
                                                        if (themchhm != null)
                                                        {
                                                            dbo.DC_CANHO_HANGMUCNCH.Add(themchhm);
                                                        }
                                                    }
                                                    break;
                                                }
                                            case "5":
                                                {
                                                    dbo.DC_HANGMUCNGOAICANHO.Add(taisan.TaiSanGanLienVoiDat.HangMucNgoaiCanHo);
                                                    // dbo.SaveChanges();
                                                    break;
                                                }
                                            case "6":
                                                {
                                                    dbo.DC_CONGTRINHXAYDUNG.Add(taisan.TaiSanGanLienVoiDat.CongTrinhXayDung);
                                                    // dbo.SaveChanges();
                                                    break;
                                                }
                                            case "7":
                                                {
                                                    dbo.DC_CONGTRINHNGAM.Add(taisan.TaiSanGanLienVoiDat.CongTrinhNgam);
                                                    // dbo.SaveChanges();
                                                    break;
                                                }
                                            case "8":
                                                {
                                                    dbo.DC_HANGMUCCONGTRINH.Add(taisan.TaiSanGanLienVoiDat.HangMucCongTrinh);
                                                    // dbo.SaveChanges();
                                                    break;
                                                }
                                            // rừng trồng
                                            case "9":
                                                {
                                                    dbo.DC_RUNGTRONG.Add(taisan.TaiSanGanLienVoiDat.RungTrong);
                                                    break;
                                                }
                                            // cây lâu năm
                                            case "10":
                                                {
                                                    dbo.DC_CAYLAUNAM.Add(taisan.TaiSanGanLienVoiDat.CayLauNam);
                                                    break;
                                                }
                                            default:
                                                break;
                                        }
                                        dbo.DC_TAISANGANLIENVOIDAT.Add(taisan.TaiSanGanLienVoiDat);
                                        // dbo.SaveChanges();
                                        dbo.DC_DANGKY_TAISAN.Add(taisan);
                                        foreach (var thuats in taisan.TaiSanGanLienVoiDat.DSThua)
                                        {
                                            if (thuats != null)
                                            {
                                                dbo.DC_THUATAISAN.Add(thuats);
                                            }
                                        }
                                        if (taisan.TaiSanGanLienVoiDat.diachitaisan != null)
                                        {
                                            dbo.DC_DIACHI.Add(taisan.TaiSanGanLienVoiDat.diachitaisan);
                                            DC_TAISAN_DIACHI tsdc = new DC_TAISAN_DIACHI();
                                            tsdc.TAISANDIACHIID = Guid.NewGuid().ToString();
                                            tsdc.DIACHIID = taisan.TaiSanGanLienVoiDat.diachitaisan.DIACHIID;
                                            tsdc.TAISANGANLIENVOIDATID = taisan.TaiSanGanLienVoiDat.TAISANGANLIENVOIDATID;
                                            dbo.DC_TAISAN_DIACHI.Add(tsdc);
                                        }
                                        //dbo.SaveChanges();
                                        break;
                                    }
                                //sửa
                                case 2:
                                    {
                                        switch (taisan.TaiSanGanLienVoiDat.LOAITAISAN)
                                        {
                                            // nhà riêng lẻ
                                            case "1":
                                                {
                                                    dbo.Entry(taisan.TaiSanGanLienVoiDat.NhaRiengLe).State = EntityState.Modified;
                                                    break;
                                                }
                                            case "2":
                                                {
                                                    dbo.Entry(taisan.TaiSanGanLienVoiDat.KhuChungCu).State = EntityState.Modified;
                                                    break;
                                                }
                                            case "3":
                                                {
                                                    dbo.Entry(taisan.TaiSanGanLienVoiDat.NhaChungCu).State = EntityState.Modified;
                                                    break;
                                                }
                                            // nhà căn hộ
                                            case "4":
                                                {
                                                    dbo.Entry(taisan.TaiSanGanLienVoiDat.CanHo).State = EntityState.Modified;
                                                    List<DC_CANHO_HANGMUCNCH> lstcanhohm = new List<DC_CANHO_HANGMUCNCH>();
                                                    lstcanhohm = (from item in dbo.DC_CANHO_HANGMUCNCH where item.CANHOID == taisan.TaiSanGanLienVoiDat.CanHo.CANHOID select item).ToList();
                                                    if (lstcanhohm != null)
                                                    {
                                                        foreach (var objcanhohm in lstcanhohm)
                                                        {
                                                            dbo.Entry(objcanhohm).State = EntityState.Deleted;
                                                        }

                                                    }
                                                    foreach (var chhm in taisan.TaiSanGanLienVoiDat.DSHangMuc)
                                                    {
                                                        if (chhm != null)
                                                        {
                                                            dbo.DC_CANHO_HANGMUCNCH.Add(chhm);
                                                        }
                                                    }
                                                    break;
                                                }
                                            case "5":
                                                {
                                                    dbo.Entry(taisan.TaiSanGanLienVoiDat.HangMucNgoaiCanHo).State = EntityState.Modified;
                                                    break;
                                                }
                                            case "6":
                                                {
                                                    dbo.Entry(taisan.TaiSanGanLienVoiDat.CongTrinhXayDung).State = EntityState.Modified;
                                                    break;
                                                }
                                            case "7":
                                                {
                                                    dbo.Entry(taisan.TaiSanGanLienVoiDat.CongTrinhNgam).State = EntityState.Modified;
                                                    break;
                                                }
                                            case "8":
                                                {
                                                    dbo.Entry(taisan.TaiSanGanLienVoiDat.HangMucCongTrinh).State = EntityState.Modified;
                                                    break;
                                                }
                                            // rừng trồng
                                            case "9":
                                                {
                                                    dbo.Entry(taisan.TaiSanGanLienVoiDat.RungTrong).State = EntityState.Modified;
                                                    break;
                                                }
                                            // cây lâu năm
                                            case "10":
                                                {
                                                    dbo.Entry(taisan.TaiSanGanLienVoiDat.CayLauNam).State = EntityState.Modified;
                                                    break;
                                                }
                                            default:
                                                break;
                                        }
                                        DCTAISANGANLIENVOIDATServices.SaveDSThuaTS(taisan);
                                        foreach (var obj in taisan.TaiSanGanLienVoiDat.DSThua)
                                        {
                                            if (obj != null)
                                                dbo.Entry(obj).State = EntityState.Added;
                                        }
                                        dbo.Entry(taisan.TaiSanGanLienVoiDat).State = EntityState.Modified;
                                        dbo.Entry(taisan).State = EntityState.Modified;
                                        var diachitaisan = (from a in dbo.DC_TAISAN_DIACHI where a.TAISANGANLIENVOIDATID == taisan.TaiSanGanLienVoiDat.TAISANGANLIENVOIDATID select a).FirstOrDefault();
                                        if (diachitaisan != null)
                                        {
                                            var diachi = (from i in dbo.DC_DIACHI where i.DIACHIID == diachitaisan.DIACHIID select i).FirstOrDefault();
                                            if (diachi != null)
                                            {
                                                dbo.Entry(diachi).State = EntityState.Deleted;
                                            }
                                            dbo.Entry(diachitaisan).State = EntityState.Deleted;
                                        }
                                        if (taisan.TaiSanGanLienVoiDat.diachitaisan != null)
                                        {
                                            dbo.DC_DIACHI.Add(taisan.TaiSanGanLienVoiDat.diachitaisan);
                                            dbo.SaveChanges();
                                            DC_TAISAN_DIACHI tsdc = new DC_TAISAN_DIACHI();
                                            tsdc.TAISANDIACHIID = Guid.NewGuid().ToString();
                                            tsdc.DIACHIID = taisan.TaiSanGanLienVoiDat.diachitaisan.DIACHIID;
                                            tsdc.TAISANGANLIENVOIDATID = taisan.TaiSanGanLienVoiDat.TAISANGANLIENVOIDATID;
                                            Mapper.Map<DC_TAISAN_DIACHI, DC_TAISAN_DIACHI>(tsdc, tsdc);
                                            dbo.DC_TAISAN_DIACHI.Add(tsdc);
                                            dbo.SaveChanges();
                                        }
                                        break;
                                    }
                                //xóa
                                case 3:
                                    {
                                        dbo.Entry(taisan).State = EntityState.Deleted;
                                        dbo.Entry(taisan.TaiSanGanLienVoiDat).State = EntityState.Deleted;
                                        DCTAISANGANLIENVOIDATServices.SaveDSThuaTS(taisan);
                                        var diachitaisan = (from a in dbo.DC_TAISAN_DIACHI where a.TAISANGANLIENVOIDATID == taisan.TaiSanGanLienVoiDat.TAISANGANLIENVOIDATID select a).FirstOrDefault();
                                        if (diachitaisan != null)
                                        {
                                            var diachi = (from i in dbo.DC_DIACHI where i.DIACHIID == diachitaisan.DIACHIID select i).FirstOrDefault();
                                            if (diachi != null)
                                            {
                                                dbo.Entry(diachi).State = EntityState.Deleted;
                                            }
                                            dbo.Entry(diachitaisan).State = EntityState.Deleted;
                                        }
                                        switch (taisan.TaiSanGanLienVoiDat.LOAITAISAN)
                                        {
                                            // nhà riêng lẻ
                                            case "1":
                                                {
                                                    dbo.Entry(taisan.TaiSanGanLienVoiDat.NhaRiengLe).State = EntityState.Deleted;
                                                    break;
                                                }
                                            // nhà căn hộ
                                            case "4":
                                                {
                                                    if (taisan.TaiSanGanLienVoiDat.DSHangMuc != null)
                                                    {
                                                        foreach (var objcanhohm in taisan.TaiSanGanLienVoiDat.DSHangMuc)
                                                        {
                                                            dbo.Entry(objcanhohm).State = EntityState.Deleted;
                                                        }
                                                    }
                                                    dbo.Entry(taisan.TaiSanGanLienVoiDat.CanHo).State = EntityState.Deleted;
                                                    break;
                                                }
                                            case "5":
                                                {
                                                    List<DC_CANHO_HANGMUCNCH> lsthangmucch = new List<DC_CANHO_HANGMUCNCH>();
                                                    lsthangmucch = (from item in dbo.DC_CANHO_HANGMUCNCH where item.HANGMUCSOHUUCHUNGID == taisan.TaiSanGanLienVoiDat.HangMucNgoaiCanHo.HANGMUCSOHUUCHUNGID select item).ToList();
                                                    if (lsthangmucch != null)
                                                    {
                                                        foreach (var objhangmucch in lsthangmucch)
                                                        {
                                                            dbo.Entry(objhangmucch).State = EntityState.Deleted;
                                                        }
                                                    }
                                                    dbo.Entry(taisan.TaiSanGanLienVoiDat.HangMucNgoaiCanHo).State = EntityState.Deleted;
                                                    break;
                                                }
                                            case "6":
                                                {

                                                    dbo.Entry(taisan.TaiSanGanLienVoiDat.CongTrinhXayDung).State = EntityState.Deleted;
                                                    break;
                                                }
                                            case "7":
                                                {
                                                    if (taisan.TaiSanGanLienVoiDat.CongTrinhNgam != null)
                                                    {
                                                        dbo.Entry(taisan.TaiSanGanLienVoiDat.CongTrinhNgam).State = EntityState.Deleted;
                                                    }
                                                    break;
                                                }
                                            case "8":
                                                {
                                                    if (taisan.TaiSanGanLienVoiDat.HangMucCongTrinh != null)
                                                    {
                                                        dbo.Entry(taisan.TaiSanGanLienVoiDat.HangMucCongTrinh).State = EntityState.Deleted;
                                                    }
                                                    break;
                                                }
                                            // rừng trồng
                                            case "9":
                                                {

                                                    dbo.Entry(taisan.TaiSanGanLienVoiDat.RungTrong).State = EntityState.Deleted;
                                                    break;
                                                }
                                            // cây lâu năm
                                            case "10":
                                                {
                                                    dbo.Entry(taisan.TaiSanGanLienVoiDat.CayLauNam).State = EntityState.Deleted;
                                                    break;
                                                }
                                            default:
                                                break;

                                        }
                                        break;
                                    }
                                default:
                                    break;
                            }
                        }
                    }
                    dbo.SaveChanges();
                    save = true;
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
            return save;
        }
        public static void SaveDSThuaTS(DC_DANGKY_TAISAN taisan)
        {
            using (MplisEntities db = new MplisEntities())
            {
                if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                        || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                    db.Database.Connection.Open();
                var trans = db.Database.Connection.BeginTransaction();
                DbCommand cmd = db.Database.Connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "delete from DC_THUATAISAN where TAISANGANLIENVOIDATID = '" + taisan.TAISANID + "'";
                cmd.ExecuteNonQuery();
                trans.Commit();
                db.SaveChanges();
            }
        }
        public static void ThemMoiTaiSan(BoHoSoModel bhs, string dSSHTaiSan, DangKyTaiSan models, int loaitaisan, string dShmch, DC_DIACHI diachi)
        {
            DC_THUATAISAN _add;
            string[] arrdsthuataisan = dSSHTaiSan.Split(',');
            switch (loaitaisan)
            {
                case 1:
                    if (models.CurNhaRiengLe.NHARIENGLEID == null || models.CurNhaRiengLe.NHARIENGLEID == "")
                    {
                        DC_NHARIENGLE nrl = new DC_NHARIENGLE();
                        nrl.NHARIENGLEID = models.CurNhaRiengLe.NHARIENGLEID = Guid.NewGuid().ToString();
                        nrl.CAPHANG = models.CurNhaRiengLe.CAPHANG;
                        nrl.DIACHI = models.CurNhaRiengLe.DIACHI;
                        nrl.DIENTICHSAN = models.CurNhaRiengLe.DIENTICHSAN;
                        nrl.DIENTICHXAYDUNG = models.CurNhaRiengLe.DIENTICHXAYDUNG;
                        nrl.KETCAU = models.CurNhaRiengLe.KETCAU;
                        nrl.SOTANG = models.CurNhaRiengLe.SOTANG;
                        nrl.SOTANGHAM = models.CurNhaRiengLe.SOTANGHAM;
                        nrl.LOAICAPHANGID = models.CurNhaRiengLe.LOAICAPHANGID;
                        nrl.LOAINHAID = models.CurNhaRiengLe.LOAINHAID;
                        nrl.DTSH_RIENG = models.CurNhaRiengLe.DTSH_RIENG;
                        nrl.DT_HT_NVTC = models.CurNhaRiengLe.DT_HT_NVTC;
                        nrl.DT_SH_CHUNG = models.CurNhaRiengLe.DT_SH_CHUNG;
                        nrl.NAMHOANCONG = models.CurNhaRiengLe.NAMHOANCONG;
                        nrl.TLCL_CONLAI = models.CurNhaRiengLe.TLCL_CONLAI;
                        nrl.LOAINHAID = models.CurNhaRiengLe.LOAINHAID;
                        nrl.LOAICAPHANGID = models.CurNhaRiengLe.LOAICAPHANGID;
                        nrl._CO_HSXN_NHADUYNHAT = models.CurNhaRiengLe._CO_HSXN_NHADUYNHAT;
                        if (models.CurNhaRiengLe._CO_HSXN_NHADUYNHAT == true)
                        {
                            nrl.CO_HSXN_NHADUYNHAT = "Y";
                        }
                        else
                        {
                            nrl.CO_HSXN_NHADUYNHAT = "N";
                        }
                        nrl.XAID = bhs.HoSoTN.DONVIHANHCHINHID;
                        DC_TAISANGANLIENVOIDAT tsglvd = new DC_TAISANGANLIENVOIDAT();
                        tsglvd.TAISANGANLIENVOIDATID = Guid.NewGuid().ToString();
                        nrl.uId = models.CurNhaRiengLe.uId = tsglvd.TAISANGANLIENVOIDATID;
                        tsglvd.diachitaisan = diachi;
                        tsglvd.DSThua = new List<DC_THUATAISAN>();
                        tsglvd.LOAITAISAN = "1";
                        tsglvd.TENTAISAN = "Nhà ở riêng lẻ";
                        tsglvd.TAISANID = nrl.NHARIENGLEID;
                        DC_DANGKY_TAISAN dkts = new DC_DANGKY_TAISAN();
                        dkts.DANGKYTAISANID = Guid.NewGuid().ToString();
                        dkts.TAISANID = tsglvd.TAISANGANLIENVOIDATID;
                        dkts.MOTATOMTAT = models.mota;
                        dkts.DienTich = nrl.DIENTICHSAN;
                        dkts.LoaiTaiSan = "Nhà ở riêng lẻ";
                        dkts.trangthaitaisan = 1;
                        dkts.TaiSanGanLienVoiDat = tsglvd;
                        dkts.TaiSanGanLienVoiDat.NhaRiengLe = nrl;
                        dkts.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
                        if (dSSHTaiSan != null && dSSHTaiSan != "")
                        {
                            foreach (string id in arrdsthuataisan)
                            {
                                _add = new DC_THUATAISAN();
                                _add.THUATAISANID = Guid.NewGuid().ToString();
                                _add.TAISANGANLIENVOIDATID = tsglvd.TAISANGANLIENVOIDATID;
                                _add.THUADATID = id;
                                tsglvd.DSThua.Add(_add);
                            }
                        }
                        bhs.HoSoTN.DonDangKy.DSDangKyTaiSan.Add(dkts);
                    }
                    else {
                        foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                        {
                            if (item.TAISANID == models.CurNhaRiengLe.uId || item.TaiSanGanLienVoiDat.TAISANID == models.CurNhaRiengLe.NHARIENGLEID)
                            {
                                item.DienTich = models.CurNhaRiengLe.DIENTICHSAN;
                                item.MOTATOMTAT = models.mota;
                                if (item.TaiSanGanLienVoiDat != null)
                                {
                                    item.TaiSanGanLienVoiDat.TENTAISAN = "Nhà riêng lẻ";
                                    item.TaiSanGanLienVoiDat.diachitaisan = diachi;
                                    if (item.trangthaitaisan != 1)
                                    {
                                        item.trangthaitaisan = 2;
                                    }
                                    item.TaiSanGanLienVoiDat.NhaRiengLe.NHARIENGLEID = models.CurNhaRiengLe.NHARIENGLEID;
                                    item.TaiSanGanLienVoiDat.NhaRiengLe.CAPHANG = models.CurNhaRiengLe.CAPHANG;
                                    item.TaiSanGanLienVoiDat.NhaRiengLe.DIACHI = models.CurNhaRiengLe.DIACHI;
                                    item.TaiSanGanLienVoiDat.NhaRiengLe.DIENTICHSAN = item.DienTich = models.CurNhaRiengLe.DIENTICHSAN;
                                    item.TaiSanGanLienVoiDat.NhaRiengLe.DIENTICHXAYDUNG = models.CurNhaRiengLe.DIENTICHXAYDUNG;
                                    item.TaiSanGanLienVoiDat.NhaRiengLe.KETCAU = models.CurNhaRiengLe.KETCAU;
                                    item.TaiSanGanLienVoiDat.NhaRiengLe.SOTANG = models.CurNhaRiengLe.SOTANG;
                                    item.TaiSanGanLienVoiDat.NhaRiengLe.SOTANGHAM = models.CurNhaRiengLe.SOTANGHAM;
                                    item.TaiSanGanLienVoiDat.NhaRiengLe.XAID = bhs.HoSoTN.DONVIHANHCHINHID;
                                    item.TaiSanGanLienVoiDat.NhaRiengLe.DTSH_RIENG = models.CurNhaRiengLe.DTSH_RIENG;
                                    item.TaiSanGanLienVoiDat.NhaRiengLe.DT_HT_NVTC = models.CurNhaRiengLe.DT_HT_NVTC;
                                    item.TaiSanGanLienVoiDat.NhaRiengLe.DT_SH_CHUNG = models.CurNhaRiengLe.DT_SH_CHUNG;
                                    item.TaiSanGanLienVoiDat.NhaRiengLe.NAMHOANCONG = models.CurNhaRiengLe.NAMHOANCONG;
                                    item.TaiSanGanLienVoiDat.NhaRiengLe.TLCL_CONLAI = models.CurNhaRiengLe.TLCL_CONLAI;
                                    item.TaiSanGanLienVoiDat.NhaRiengLe.LOAINHAID = models.CurNhaRiengLe.LOAINHAID;
                                    item.TaiSanGanLienVoiDat.NhaRiengLe.LOAICAPHANGID = models.CurNhaRiengLe.LOAICAPHANGID;
                                    item.TaiSanGanLienVoiDat.NhaRiengLe._CO_HSXN_NHADUYNHAT = models.CurNhaRiengLe._CO_HSXN_NHADUYNHAT;
                                    if (models.CurNhaRiengLe._CO_HSXN_NHADUYNHAT == true)
                                    {
                                        item.TaiSanGanLienVoiDat.NhaRiengLe.CO_HSXN_NHADUYNHAT = "Y";
                                    }
                                    else
                                    {
                                        item.TaiSanGanLienVoiDat.NhaRiengLe.CO_HSXN_NHADUYNHAT = "N";
                                    }
                                    item.TaiSanGanLienVoiDat.DSThua = new List<DC_THUATAISAN>();
                                    if (dSSHTaiSan != null && dSSHTaiSan != "")
                                    {
                                        foreach (string id in arrdsthuataisan)
                                        {
                                            _add = new DC_THUATAISAN();
                                            _add.THUATAISANID = Guid.NewGuid().ToString();
                                            _add.TAISANGANLIENVOIDATID = item.TaiSanGanLienVoiDat.TAISANGANLIENVOIDATID;
                                            _add.THUADATID = id;
                                            item.TaiSanGanLienVoiDat.DSThua.Add(_add);
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    break;
                case 2:
                    if (models.CurKhuChungCu.KHUCHUNGCUID == null || models.CurKhuChungCu.KHUCHUNGCUID == "")
                    {
                        DC_KHUCHUNGCU kcc = new DC_KHUCHUNGCU();
                        kcc.KHUCHUNGCUID = models.CurKhuChungCu.KHUCHUNGCUID = Guid.NewGuid().ToString();
                        kcc.DIENTICHKHU = models.CurKhuChungCu.DIENTICHKHU;
                        kcc.TENKHU = models.CurKhuChungCu.TENKHU;
                        kcc.DIACHI = models.CurKhuChungCu.DIACHI;
                        kcc.MAXA = bhs.HoSoTN.MaKVHC;
                        DC_TAISANGANLIENVOIDAT tsglvd = new DC_TAISANGANLIENVOIDAT();
                        tsglvd.TAISANGANLIENVOIDATID = Guid.NewGuid().ToString();
                        kcc.uId = models.CurKhuChungCu.uId = tsglvd.TAISANGANLIENVOIDATID;
                        tsglvd.DSThua = new List<DC_THUATAISAN>();
                        tsglvd.LOAITAISAN = "2";
                        tsglvd.TENTAISAN = kcc.TENKHU;
                        tsglvd.TAISANID = kcc.KHUCHUNGCUID;
                        DC_DANGKY_TAISAN dkts = new DC_DANGKY_TAISAN();
                        dkts.DANGKYTAISANID = Guid.NewGuid().ToString();
                        dkts.TAISANID = tsglvd.TAISANGANLIENVOIDATID;
                        dkts.DienTich = kcc.DIENTICHKHU;
                        dkts.LoaiTaiSan = "Khu chung cư";
                        dkts.trangthaitaisan = 1;
                        dkts.TaiSanGanLienVoiDat = tsglvd;
                        dkts.TaiSanGanLienVoiDat.KhuChungCu = kcc;
                        dkts.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
                        bhs.HoSoTN.DonDangKy.DSDangKyTaiSan.Add(dkts);
                    }
                    else {
                        foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                        {
                            if (item.TAISANID == models.CurKhuChungCu.uId)
                            {
                                item.DienTich = models.CurKhuChungCu.DIENTICHKHU;
                                if (item.TaiSanGanLienVoiDat != null)
                                {
                                    item.TaiSanGanLienVoiDat.TENTAISAN = models.CurKhuChungCu.TENKHU;
                                    if (item.trangthaitaisan != 1)
                                    {
                                        item.trangthaitaisan = 2;
                                    }
                                    item.TaiSanGanLienVoiDat.KhuChungCu.TENKHU = models.CurKhuChungCu.TENKHU;
                                    item.TaiSanGanLienVoiDat.KhuChungCu.DIENTICHKHU = models.CurKhuChungCu.DIENTICHKHU;
                                    item.TaiSanGanLienVoiDat.KhuChungCu.DIACHI = models.CurKhuChungCu.DIACHI;
                                    item.TaiSanGanLienVoiDat.KhuChungCu.MAXA = bhs.HoSoTN.MaKVHC;
                                    break;
                                }
                            }
                        }
                    }
                    break;
                case 3:
                    if (models.CurNhaChungCu.NHACHUNGCUID == null || models.CurNhaChungCu.NHACHUNGCUID == "")
                    {
                        DC_NHACHUNGCU ncc = new DC_NHACHUNGCU();
                        ncc.NHACHUNGCUID = models.CurNhaChungCu.NHACHUNGCUID = Guid.NewGuid().ToString();
                        if (models.CurNhaChungCu.KHUCHUNGCUID != null && models.CurNhaChungCu.KHUCHUNGCUID != "")
                        {
                            ncc.KHUCHUNGCUID = models.CurNhaChungCu.KHUCHUNGCUID;
                        }
                        ncc.CAPHANG = models.CurNhaChungCu.CAPHANG;
                        ncc.DIENTICHSAN = models.CurNhaChungCu.DIENTICHSAN;
                        ncc.DIENTICHXAYDUNG = models.CurNhaChungCu.DIENTICHXAYDUNG;
                        ncc.KHUCHUNGCUID = models.CurNhaChungCu.KHUCHUNGCUID;
                        ncc.NAMHOANTHANH = models.CurNhaChungCu.NAMHOANTHANH;
                        ncc.NAMXAYDUNG = models.CurNhaChungCu.NAMXAYDUNG;
                        ncc.SOTANG = models.CurNhaChungCu.SOTANG;
                        ncc.SOTANGHAM = models.CurNhaChungCu.SOTANGHAM;
                        ncc.TENCHUNGCU = models.CurNhaChungCu.TENCHUNGCU;
                        ncc.THOIHANSOHUU = models.CurNhaChungCu.THOIHANSOHUU;
                        ncc.TONGSOCAN = models.CurNhaChungCu.TONGSOCAN;
                        ncc.DIACHI = models.CurNhaChungCu.DIACHI;
                        ncc.MAXA = bhs.HoSoTN.MaKVHC;
                        DC_TAISANGANLIENVOIDAT tsglvd = new DC_TAISANGANLIENVOIDAT();
                        tsglvd.TAISANGANLIENVOIDATID = Guid.NewGuid().ToString();
                        ncc.uId = models.CurNhaChungCu.uId = tsglvd.TAISANGANLIENVOIDATID;
                        tsglvd.DSThua = new List<DC_THUATAISAN>();
                        tsglvd.LOAITAISAN = "3";
                        tsglvd.TENTAISAN = ncc.TENCHUNGCU;
                        tsglvd.TAISANID = ncc.NHACHUNGCUID;
                        DC_DANGKY_TAISAN dkts = new DC_DANGKY_TAISAN();
                        dkts.DANGKYTAISANID = Guid.NewGuid().ToString();
                        dkts.TAISANID = tsglvd.TAISANGANLIENVOIDATID;
                        dkts.DienTich = ncc.DIENTICHSAN;
                        dkts.LoaiTaiSan = "Nhà chung cư";
                        dkts.trangthaitaisan = 1;
                        dkts.TaiSanGanLienVoiDat = tsglvd;
                        dkts.TaiSanGanLienVoiDat.NhaChungCu = ncc;
                        dkts.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
                        bhs.HoSoTN.DonDangKy.DSDangKyTaiSan.Add(dkts);
                    }
                    else {
                        foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                        {
                            if (item.TAISANID == models.CurNhaChungCu.uId)
                            {
                                item.DienTich = models.CurNhaChungCu.DIENTICHSAN;
                                if (item.TaiSanGanLienVoiDat != null)
                                {
                                    item.TaiSanGanLienVoiDat.TENTAISAN = models.CurNhaChungCu.TENCHUNGCU;
                                    if (item.trangthaitaisan != 1)
                                    {
                                        item.trangthaitaisan = 2;
                                    }
                                    Mapper.Map<DC_NHACHUNGCU, DC_NHACHUNGCU>(models.CurNhaChungCu, item.TaiSanGanLienVoiDat.NhaChungCu);
                                    item.TaiSanGanLienVoiDat.NhaChungCu.MAXA = bhs.HoSoTN.MaKVHC;
                                    break;
                                }
                            }
                        }
                    }
                    break;
                case 4:
                    DC_CANHO_HANGMUCNCH hmch;
                    string[] arrdshmch = dShmch.Split(',');
                    if (models.CurCanHo.CANHOID == null || models.CurCanHo.CANHOID == "")
                    {
                        DC_CANHO ch = new DC_CANHO();
                        ch.CANHOID = models.CurCanHo.CANHOID = Guid.NewGuid().ToString();
                        ch.DIENTICHSAN = models.CurCanHo.DIENTICHSAN;
                        ch.HINHTHUCSOHUU = models.CurCanHo.HINHTHUCSOHUU;
                        ch.NHACHUNGCUID = models.CurCanHo.NHACHUNGCUID;
                        ch.SOHIEUCANHO = models.CurCanHo.SOHIEUCANHO;
                        ch.TANGSO = models.CurCanHo.TANGSO;
                        ch.THOIHANSOHUU = models.CurCanHo.THOIHANSOHUU;
                        ch.TINHTRANGDANGKY = models.CurCanHo.TINHTRANGDANGKY;
                        ch.DTSH_CHUNG_CDT = models.CurCanHo.DTSH_CHUNG_CDT;
                        ch.DTSH_CHUNG_NSDD = models.CurCanHo.DTSH_CHUNG_NSDD;
                        ch.DTSH_RIENG = models.CurCanHo.DTSH_RIENG;
                        ch.DT_HT_NVTC = models.CurCanHo.DT_HT_NVTC;
                        ch.DT_PT_KHONGRIENGLE = models.CurCanHo.DT_PT_KHONGRIENGLE;
                        ch.DT_PT_RIENGLE = models.CurCanHo.DT_PT_RIENGLE;
                        ch.NAMHOANCONG = models.CurCanHo.NAMHOANCONG;
                        ch.NGUONGOC = models.CurCanHo.NGUONGOC;
                        ch._CO_HSXN_NHADUYNHAT = models.CurCanHo._CO_HSXN_NHADUYNHAT;
                        if (models.CurCanHo._CO_HSXN_NHADUYNHAT == true)
                        {
                            ch.CO_HSXN_NHADUYNHAT = "Y";
                        }
                        else
                        {
                            ch.CO_HSXN_NHADUYNHAT = "N";
                        }
                        DC_TAISANGANLIENVOIDAT tsglvd = new DC_TAISANGANLIENVOIDAT();
                        tsglvd.TAISANGANLIENVOIDATID = Guid.NewGuid().ToString();
                        ch.uId = models.CurCanHo.uId = tsglvd.TAISANGANLIENVOIDATID;
                        tsglvd.DSThua = new List<DC_THUATAISAN>();
                        tsglvd.DSHangMuc = new List<DC_CANHO_HANGMUCNCH>();
                        tsglvd.LOAITAISAN = "4";
                        tsglvd.TENTAISAN = ch.SOHIEUCANHO;
                        tsglvd.TAISANID = ch.CANHOID;
                        DC_DANGKY_TAISAN dkts = new DC_DANGKY_TAISAN();
                        dkts.DANGKYTAISANID = Guid.NewGuid().ToString();
                        dkts.TAISANID = tsglvd.TAISANGANLIENVOIDATID;
                        dkts.DienTich = ch.DIENTICHSAN;
                        dkts.LoaiTaiSan = "Căn hộ";
                        dkts.trangthaitaisan = 1;
                        dkts.TaiSanGanLienVoiDat = tsglvd;
                        dkts.TaiSanGanLienVoiDat.CanHo = ch;
                        dkts.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
                        if (dSSHTaiSan != null && dSSHTaiSan != "")
                        {
                            foreach (string id in arrdsthuataisan)
                            {
                                _add = new DC_THUATAISAN();
                                _add.THUATAISANID = Guid.NewGuid().ToString();
                                _add.TAISANGANLIENVOIDATID = tsglvd.TAISANGANLIENVOIDATID;
                                _add.THUADATID = id;
                                tsglvd.DSThua.Add(_add);
                            }
                        }
                        if (dShmch != null && dShmch != "")
                        {
                            foreach (string chhmid in arrdshmch)
                            {
                                hmch = new DC_CANHO_HANGMUCNCH();
                                hmch.CANHOID = ch.CANHOID;
                                hmch.HANGMUCSOHUUCHUNGID = chhmid;
                                tsglvd.DSHangMuc.Add(hmch);
                            }
                        }
                        bhs.HoSoTN.DonDangKy.DSDangKyTaiSan.Add(dkts);
                    }
                    else {
                        foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                        {
                            if (item.TAISANID == models.CurCanHo.uId)
                            {
                                item.DienTich = models.CurCanHo.DIENTICHSAN;
                                if (item.TaiSanGanLienVoiDat != null)
                                {
                                    item.TaiSanGanLienVoiDat.TENTAISAN = models.CurCanHo.SOHIEUCANHO;
                                    if (item.trangthaitaisan != 1)
                                    {
                                        item.trangthaitaisan = 2;
                                    }
                                    item.TaiSanGanLienVoiDat.CanHo.DIENTICHSAN = models.CurCanHo.DIENTICHSAN;
                                    item.TaiSanGanLienVoiDat.CanHo.HINHTHUCSOHUU = models.CurCanHo.HINHTHUCSOHUU;
                                    item.TaiSanGanLienVoiDat.CanHo.NHACHUNGCUID = models.CurCanHo.NHACHUNGCUID;
                                    item.TaiSanGanLienVoiDat.CanHo.SOHIEUCANHO = models.CurCanHo.SOHIEUCANHO;
                                    item.TaiSanGanLienVoiDat.CanHo.TANGSO = models.CurCanHo.TANGSO;
                                    item.TaiSanGanLienVoiDat.CanHo.THOIHANSOHUU = models.CurCanHo.THOIHANSOHUU;
                                    item.TaiSanGanLienVoiDat.CanHo.TINHTRANGDANGKY = models.CurCanHo.TINHTRANGDANGKY;
                                    item.TaiSanGanLienVoiDat.CanHo.DTSH_CHUNG_CDT = models.CurCanHo.DTSH_CHUNG_CDT;
                                    item.TaiSanGanLienVoiDat.CanHo.DTSH_CHUNG_NSDD = models.CurCanHo.DTSH_CHUNG_NSDD;
                                    item.TaiSanGanLienVoiDat.CanHo.DTSH_RIENG = models.CurCanHo.DTSH_RIENG;
                                    item.TaiSanGanLienVoiDat.CanHo.DT_HT_NVTC = models.CurCanHo.DT_HT_NVTC;
                                    item.TaiSanGanLienVoiDat.CanHo.DT_PT_KHONGRIENGLE = models.CurCanHo.DT_PT_KHONGRIENGLE;
                                    item.TaiSanGanLienVoiDat.CanHo.DT_PT_RIENGLE = models.CurCanHo.DT_PT_RIENGLE;
                                    item.TaiSanGanLienVoiDat.CanHo.NAMHOANCONG = models.CurCanHo.NAMHOANCONG;
                                    item.TaiSanGanLienVoiDat.CanHo.NGUONGOC = models.CurCanHo.NGUONGOC;
                                    item.TaiSanGanLienVoiDat.CanHo._CO_HSXN_NHADUYNHAT = models.CurCanHo._CO_HSXN_NHADUYNHAT;
                                    if (models.CurCanHo._CO_HSXN_NHADUYNHAT == true)
                                    {
                                        item.TaiSanGanLienVoiDat.CanHo.CO_HSXN_NHADUYNHAT = "Y";
                                    }
                                    else
                                    {
                                        item.TaiSanGanLienVoiDat.CanHo.CO_HSXN_NHADUYNHAT = "N";
                                    }
                                    item.TaiSanGanLienVoiDat.DSThua = new List<DC_THUATAISAN>();
                                    item.TaiSanGanLienVoiDat.DSHangMuc = new List<DC_CANHO_HANGMUCNCH>();
                                    if (dSSHTaiSan != null && dSSHTaiSan != "")
                                    {
                                        foreach (string id in arrdsthuataisan)
                                        {
                                            _add = new DC_THUATAISAN();
                                            _add.THUATAISANID = Guid.NewGuid().ToString();
                                            _add.TAISANGANLIENVOIDATID = item.TaiSanGanLienVoiDat.TAISANGANLIENVOIDATID;
                                            _add.THUADATID = id;
                                            item.TaiSanGanLienVoiDat.DSThua.Add(_add);
                                        }
                                    }
                                    if (dShmch != null && dShmch != "")
                                    {
                                        foreach (string chhmid in arrdshmch)
                                        {
                                            hmch = new DC_CANHO_HANGMUCNCH();
                                            hmch.CANHOID = item.TaiSanGanLienVoiDat.CanHo.CANHOID;
                                            hmch.HANGMUCSOHUUCHUNGID = chhmid;
                                            item.TaiSanGanLienVoiDat.DSHangMuc.Add(hmch);
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    break;
                case 5:
                    if (models.CurHangMucNgoaiCanHo.HANGMUCSOHUUCHUNGID == null || models.CurHangMucNgoaiCanHo.HANGMUCSOHUUCHUNGID == "")
                    {
                        DC_HANGMUCNGOAICANHO hmnch = new DC_HANGMUCNGOAICANHO();
                        hmnch.HANGMUCSOHUUCHUNGID = models.CurHangMucNgoaiCanHo.HANGMUCSOHUUCHUNGID = Guid.NewGuid().ToString();
                        hmnch.DIENTICH = models.CurHangMucNgoaiCanHo.DIENTICH;
                        hmnch.NHACHUNGCUID = models.CurHangMucNgoaiCanHo.NHACHUNGCUID;
                        hmnch.TENHANGMUC = models.CurHangMucNgoaiCanHo.TENHANGMUC;
                        DC_TAISANGANLIENVOIDAT tsglvd = new DC_TAISANGANLIENVOIDAT();
                        tsglvd.TAISANGANLIENVOIDATID = Guid.NewGuid().ToString();
                        hmnch.uId = models.CurHangMucNgoaiCanHo.uId = tsglvd.TAISANGANLIENVOIDATID;
                        tsglvd.DSThua = new List<DC_THUATAISAN>();
                        tsglvd.LOAITAISAN = "5";
                        tsglvd.TENTAISAN = hmnch.TENHANGMUC;
                        tsglvd.TAISANID = hmnch.HANGMUCSOHUUCHUNGID;
                        DC_DANGKY_TAISAN dkts = new DC_DANGKY_TAISAN();
                        dkts.DANGKYTAISANID = Guid.NewGuid().ToString();
                        dkts.TAISANID = tsglvd.TAISANGANLIENVOIDATID;
                        dkts.DienTich = hmnch.DIENTICH;
                        dkts.LoaiTaiSan = "Hạng mục ngoài căn hộ";
                        dkts.trangthaitaisan = 1;
                        dkts.TaiSanGanLienVoiDat = tsglvd;
                        dkts.TaiSanGanLienVoiDat.HangMucNgoaiCanHo = hmnch;
                        dkts.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
                        bhs.HoSoTN.DonDangKy.DSDangKyTaiSan.Add(dkts);
                    }
                    else {
                        foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                        {
                            if (item.TAISANID == models.CurHangMucNgoaiCanHo.uId)
                            {
                                item.DienTich = models.CurHangMucNgoaiCanHo.DIENTICH;
                                if (item.TaiSanGanLienVoiDat != null)
                                {
                                    item.TaiSanGanLienVoiDat.TENTAISAN = models.CurHangMucNgoaiCanHo.TENHANGMUC;
                                    if (item.trangthaitaisan != 1)
                                    {
                                        item.trangthaitaisan = 2;
                                    }
                                    Mapper.Map<DC_HANGMUCNGOAICANHO, DC_HANGMUCNGOAICANHO>(models.CurHangMucNgoaiCanHo, item.TaiSanGanLienVoiDat.HangMucNgoaiCanHo);
                                    break;
                                }
                            }
                        }
                    }
                    break;
                case 6:
                    if (models.CurCongTrinhXayDung.CONGTRINHXAYDUNGID == null || models.CurCongTrinhXayDung.CONGTRINHXAYDUNGID == "")
                    {
                        DC_CONGTRINHXAYDUNG ctxd = new DC_CONGTRINHXAYDUNG();
                        ctxd.CONGTRINHXAYDUNGID = models.CurCongTrinhXayDung.CONGTRINHXAYDUNGID = Guid.NewGuid().ToString();
                        ctxd.CAPHANG = models.CurCongTrinhXayDung.CAPHANG;
                        ctxd.DIENTICHSAN = models.CurCongTrinhXayDung.DIENTICHSAN;
                        ctxd.DIENTICHXAYDUNG = models.CurCongTrinhXayDung.DIENTICHXAYDUNG;
                        ctxd.HINHTHUCSOHUU = models.CurCongTrinhXayDung.HINHTHUCSOHUU;
                        ctxd.MAXA = models.CurCongTrinhXayDung.MAXA;
                        ctxd.NAMHOANTHANH = models.CurCongTrinhXayDung.NAMHOANTHANH;
                        ctxd.NAMXAYDUNG = models.CurCongTrinhXayDung.NAMXAYDUNG;
                        ctxd.SOTANG = models.CurCongTrinhXayDung.SOTANG;
                        ctxd.SOTANGHAM = models.CurCongTrinhXayDung.SOTANGHAM;
                        ctxd.TENCONGTRINH = models.CurCongTrinhXayDung.TENCONGTRINH;
                        ctxd.THOIHANSOHUU = models.CurCongTrinhXayDung.THOIHANSOHUU;
                        ctxd.DIACHI = models.CurCongTrinhXayDung.DIACHI;
                        ctxd.MAXA = bhs.HoSoTN.MaKVHC;
                        DC_TAISANGANLIENVOIDAT tsglvd = new DC_TAISANGANLIENVOIDAT();
                        tsglvd.TAISANGANLIENVOIDATID = Guid.NewGuid().ToString();
                        ctxd.uId = models.CurCongTrinhXayDung.uId = tsglvd.TAISANGANLIENVOIDATID;
                        tsglvd.diachitaisan = diachi;
                        tsglvd.DSThua = new List<DC_THUATAISAN>();
                        tsglvd.LOAITAISAN = "6";
                        tsglvd.TENTAISAN = ctxd.TENCONGTRINH;
                        tsglvd.TAISANID = ctxd.CONGTRINHXAYDUNGID;
                        DC_DANGKY_TAISAN dkts = new DC_DANGKY_TAISAN();
                        dkts.DANGKYTAISANID = Guid.NewGuid().ToString();
                        dkts.TAISANID = tsglvd.TAISANGANLIENVOIDATID;
                        dkts.MOTATOMTAT = models.mota;
                        dkts.trangthaitaisan = 1;
                        dkts.LoaiTaiSan = "công trình xây dựng";
                        dkts.DienTich = ctxd.DIENTICHSAN;
                        dkts.TaiSanGanLienVoiDat = tsglvd;
                        dkts.TaiSanGanLienVoiDat.CongTrinhXayDung = ctxd;
                        dkts.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
                        if (dSSHTaiSan != null && dSSHTaiSan != "")
                        {
                            foreach (string id in arrdsthuataisan)
                            {
                                _add = new DC_THUATAISAN();
                                _add.THUATAISANID = Guid.NewGuid().ToString();
                                _add.TAISANGANLIENVOIDATID = tsglvd.TAISANGANLIENVOIDATID;
                                _add.THUADATID = id;
                                tsglvd.DSThua.Add(_add);
                            }
                        }
                        bhs.HoSoTN.DonDangKy.DSDangKyTaiSan.Add(dkts);
                    }
                    else
                    {
                        foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                        {
                            if (item.TAISANID == models.CurCongTrinhXayDung.uId)
                            {
                                item.DienTich = models.CurCongTrinhXayDung.DIENTICHSAN;
                                item.MOTATOMTAT = models.mota;
                                if (item.TaiSanGanLienVoiDat != null)
                                {
                                    item.TaiSanGanLienVoiDat.TENTAISAN = models.CurCongTrinhXayDung.TENCONGTRINH;
                                    item.TaiSanGanLienVoiDat.diachitaisan = diachi;
                                    if (item.trangthaitaisan != 1)
                                    {
                                        item.trangthaitaisan = 2;
                                    }
                                    item.TaiSanGanLienVoiDat.CongTrinhXayDung.CAPHANG = models.CurCongTrinhXayDung.CAPHANG;
                                    item.TaiSanGanLienVoiDat.CongTrinhXayDung.DIENTICHSAN = models.CurCongTrinhXayDung.DIENTICHSAN;
                                    item.TaiSanGanLienVoiDat.CongTrinhXayDung.DIENTICHXAYDUNG = models.CurCongTrinhXayDung.DIENTICHXAYDUNG;
                                    item.TaiSanGanLienVoiDat.CongTrinhXayDung.HINHTHUCSOHUU = models.CurCongTrinhXayDung.HINHTHUCSOHUU;
                                    item.TaiSanGanLienVoiDat.CongTrinhXayDung.NAMHOANTHANH = models.CurCongTrinhXayDung.NAMHOANTHANH;
                                    item.TaiSanGanLienVoiDat.CongTrinhXayDung.NAMXAYDUNG = models.CurCongTrinhXayDung.NAMXAYDUNG;
                                    item.TaiSanGanLienVoiDat.CongTrinhXayDung.SOTANG = models.CurCongTrinhXayDung.SOTANG;
                                    item.TaiSanGanLienVoiDat.CongTrinhXayDung.SOTANGHAM = models.CurCongTrinhXayDung.SOTANGHAM;
                                    item.TaiSanGanLienVoiDat.CongTrinhXayDung.TENCONGTRINH = models.CurCongTrinhXayDung.TENCONGTRINH;
                                    item.TaiSanGanLienVoiDat.CongTrinhXayDung.THOIHANSOHUU = models.CurCongTrinhXayDung.THOIHANSOHUU;
                                    item.TaiSanGanLienVoiDat.CongTrinhXayDung.DIACHI = models.CurCongTrinhXayDung.DIACHI;
                                    item.TaiSanGanLienVoiDat.CongTrinhXayDung.MAXA = bhs.HoSoTN.MaKVHC;
                                    item.TaiSanGanLienVoiDat.DSThua = new List<DC_THUATAISAN>();
                                    if (dSSHTaiSan != null && dSSHTaiSan != "")
                                    {
                                        foreach (string id in arrdsthuataisan)
                                        {
                                            _add = new DC_THUATAISAN();
                                            _add.THUATAISANID = Guid.NewGuid().ToString();
                                            _add.TAISANGANLIENVOIDATID = item.TaiSanGanLienVoiDat.TAISANGANLIENVOIDATID;
                                            _add.THUADATID = id;
                                            item.TaiSanGanLienVoiDat.DSThua.Add(_add);
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    break;
                case 7:
                    if (models.CurCongTrinhNgam.CONGTRINHNGAMID == null || models.CurCongTrinhNgam.CONGTRINHNGAMID == "")
                    {
                        DC_CONGTRINHNGAM ctn = new DC_CONGTRINHNGAM();
                        ctn.CONGTRINHNGAMID = models.CurCongTrinhNgam.CONGTRINHNGAMID = Guid.NewGuid().ToString();
                        ctn.DIENTICHCONGTRINH = models.CurCongTrinhNgam.DIENTICHCONGTRINH;
                        ctn.DOSAUTOIDA = models.CurCongTrinhNgam.DOSAUTOIDA;
                        ctn.HINHTHUCSOHUU = models.CurCongTrinhNgam.HINHTHUCSOHUU;
                        ctn.LOAICONGTRINHNGAM = models.CurCongTrinhNgam.LOAICONGTRINHNGAM;
                        ctn.NAMHOANTHANH = models.CurCongTrinhNgam.NAMHOANTHANH;
                        ctn.NAMXAYDUNG = models.CurCongTrinhNgam.NAMXAYDUNG;
                        ctn.TENCONGTRINH = models.CurCongTrinhNgam.TENCONGTRINH;
                        ctn.THOIHANSOHUU = models.CurCongTrinhNgam.THOIHANSOHUU;
                        ctn.VITRIDAUNOI = models.CurCongTrinhNgam.VITRIDAUNOI;
                        ctn.DIACHI = models.CurCongTrinhNgam.DIACHI;
                        ctn.MAXA = bhs.HoSoTN.MaKVHC;
                        DC_TAISANGANLIENVOIDAT tsglvd = new DC_TAISANGANLIENVOIDAT();
                        tsglvd.TAISANGANLIENVOIDATID = Guid.NewGuid().ToString();
                        ctn.uId = models.CurCongTrinhNgam.uId = tsglvd.TAISANGANLIENVOIDATID;
                        tsglvd.diachitaisan = diachi;
                        tsglvd.DSThua = new List<DC_THUATAISAN>();
                        tsglvd.LOAITAISAN = "7";
                        tsglvd.TENTAISAN = ctn.TENCONGTRINH;
                        tsglvd.TAISANID = ctn.CONGTRINHNGAMID;
                        DC_DANGKY_TAISAN dkts = new DC_DANGKY_TAISAN();
                        dkts.DANGKYTAISANID = Guid.NewGuid().ToString();
                        dkts.TAISANID = tsglvd.TAISANGANLIENVOIDATID;
                        dkts.MOTATOMTAT = models.mota;
                        dkts.DienTich = ctn.DIENTICHCONGTRINH;
                        dkts.LoaiTaiSan = "Công trình ngầm";
                        dkts.trangthaitaisan = 1;
                        dkts.TaiSanGanLienVoiDat = tsglvd;
                        dkts.TaiSanGanLienVoiDat.CongTrinhNgam = ctn;
                        dkts.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
                        if (dSSHTaiSan != null && dSSHTaiSan != "")
                        {
                            foreach (string id in arrdsthuataisan)
                            {
                                _add = new DC_THUATAISAN();
                                _add.THUATAISANID = Guid.NewGuid().ToString();
                                _add.TAISANGANLIENVOIDATID = tsglvd.TAISANGANLIENVOIDATID;
                                _add.THUADATID = id;
                                tsglvd.DSThua.Add(_add);
                            }
                        }
                        bhs.HoSoTN.DonDangKy.DSDangKyTaiSan.Add(dkts);
                    }
                    else
                    {
                        foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                        {
                            if (item.TAISANID == models.CurCongTrinhNgam.uId)
                            {
                                item.DienTich = models.CurCongTrinhNgam.DIENTICHCONGTRINH;
                                item.MOTATOMTAT = models.mota;
                                if (item.TaiSanGanLienVoiDat != null)
                                {
                                    item.TaiSanGanLienVoiDat.TENTAISAN = models.CurCongTrinhNgam.TENCONGTRINH;
                                    item.TaiSanGanLienVoiDat.diachitaisan = diachi;
                                    if (item.trangthaitaisan != 1)
                                    {
                                        item.trangthaitaisan = 2;
                                    }
                                    item.TaiSanGanLienVoiDat.CongTrinhNgam.DIENTICHCONGTRINH = models.CurCongTrinhNgam.DIENTICHCONGTRINH;
                                    item.TaiSanGanLienVoiDat.CongTrinhNgam.DOSAUTOIDA = models.CurCongTrinhNgam.DOSAUTOIDA;
                                    item.TaiSanGanLienVoiDat.CongTrinhNgam.HINHTHUCSOHUU = models.CurCongTrinhNgam.HINHTHUCSOHUU;
                                    item.TaiSanGanLienVoiDat.CongTrinhNgam.LOAICONGTRINHNGAM = models.CurCongTrinhNgam.LOAICONGTRINHNGAM;
                                    item.TaiSanGanLienVoiDat.CongTrinhNgam.NAMHOANTHANH = models.CurCongTrinhNgam.NAMHOANTHANH;
                                    item.TaiSanGanLienVoiDat.CongTrinhNgam.NAMXAYDUNG = models.CurCongTrinhNgam.NAMXAYDUNG;
                                    item.TaiSanGanLienVoiDat.CongTrinhNgam.TENCONGTRINH = models.CurCongTrinhNgam.TENCONGTRINH;
                                    item.TaiSanGanLienVoiDat.CongTrinhNgam.THOIHANSOHUU = models.CurCongTrinhNgam.THOIHANSOHUU;
                                    item.TaiSanGanLienVoiDat.CongTrinhNgam.VITRIDAUNOI = models.CurCongTrinhNgam.VITRIDAUNOI;
                                    item.TaiSanGanLienVoiDat.CongTrinhNgam.DIACHI = models.CurCongTrinhNgam.DIACHI;
                                    item.TaiSanGanLienVoiDat.CongTrinhNgam.MAXA = bhs.HoSoTN.MaKVHC;
                                    item.TaiSanGanLienVoiDat.DSThua = new List<DC_THUATAISAN>();
                                    if (dSSHTaiSan != null && dSSHTaiSan != "")
                                    {
                                        foreach (string id in arrdsthuataisan)
                                        {
                                            _add = new DC_THUATAISAN();
                                            _add.THUATAISANID = Guid.NewGuid().ToString();
                                            _add.TAISANGANLIENVOIDATID = item.TaiSanGanLienVoiDat.TAISANGANLIENVOIDATID;
                                            _add.THUADATID = id;
                                            item.TaiSanGanLienVoiDat.DSThua.Add(_add);
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    break;
                case 8:
                    if (models.CurHangMucCongTrinh.HANGMUCCONGTRINHID == null || models.CurHangMucCongTrinh.HANGMUCCONGTRINHID == "")
                    {
                        DC_HANGMUCCONGTRINH hmct = new DC_HANGMUCCONGTRINH();
                        hmct.HANGMUCCONGTRINHID = models.CurHangMucCongTrinh.HANGMUCCONGTRINHID = Guid.NewGuid().ToString();
                        hmct.CAPHANG = models.CurHangMucCongTrinh.CAPHANG;
                        hmct.CONGNANG = models.CurHangMucCongTrinh.CONGNANG;
                        hmct.CONGTRINHXAYDUNGID = models.CurHangMucCongTrinh.CONGTRINHXAYDUNGID;
                        hmct.DIENTICHSAN = models.CurHangMucCongTrinh.DIENTICHSAN;
                        hmct.DIENTICHXAYDUNG = models.CurHangMucCongTrinh.DIENTICHXAYDUNG;
                        hmct.KETCAU = models.CurHangMucCongTrinh.KETCAU;
                        hmct.NAMHOANTHANH = models.CurHangMucCongTrinh.NAMHOANTHANH;
                        hmct.NAMXAYDUNG = models.CurHangMucCongTrinh.NAMXAYDUNG;
                        hmct.SOTANG = models.CurHangMucCongTrinh.SOTANG;
                        hmct.SOTANGHAM = models.CurHangMucCongTrinh.SOTANGHAM;
                        hmct.TENHANGMUC = models.CurHangMucCongTrinh.TENHANGMUC;
                        hmct.THOIHANSOHUU = models.CurHangMucCongTrinh.THOIHANSOHUU;
                        hmct.DIACHIID = models.CurHangMucCongTrinh.DIACHIID;
                        DC_TAISANGANLIENVOIDAT tsglvd = new DC_TAISANGANLIENVOIDAT();
                        tsglvd.TAISANGANLIENVOIDATID = Guid.NewGuid().ToString();
                        hmct.uId = models.CurHangMucCongTrinh.uId = tsglvd.TAISANGANLIENVOIDATID;
                        tsglvd.diachitaisan = diachi;
                        tsglvd.DSThua = new List<DC_THUATAISAN>();
                        tsglvd.LOAITAISAN = "8";
                        tsglvd.TENTAISAN = hmct.TENHANGMUC;
                        tsglvd.TAISANID = hmct.HANGMUCCONGTRINHID;
                        DC_DANGKY_TAISAN dkts = new DC_DANGKY_TAISAN();
                        dkts.DANGKYTAISANID = Guid.NewGuid().ToString();
                        dkts.TAISANID = tsglvd.TAISANGANLIENVOIDATID;
                        dkts.MOTATOMTAT = models.mota;
                        dkts.DienTich = hmct.DIENTICHSAN;
                        dkts.LoaiTaiSan = "Hạng mục công trình";
                        dkts.trangthaitaisan = 1;
                        dkts.TaiSanGanLienVoiDat = tsglvd;
                        dkts.TaiSanGanLienVoiDat.HangMucCongTrinh = hmct;
                        dkts.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
                        bhs.HoSoTN.DonDangKy.DSDangKyTaiSan.Add(dkts);
                        if (dSSHTaiSan != null && dSSHTaiSan != "")
                        {
                            foreach (string id in arrdsthuataisan)
                            {
                                _add = new DC_THUATAISAN();
                                _add.THUATAISANID = Guid.NewGuid().ToString();
                                _add.TAISANGANLIENVOIDATID = tsglvd.TAISANGANLIENVOIDATID;
                                _add.THUADATID = id;
                                tsglvd.DSThua.Add(_add);
                            }
                        }
                    }
                    else {
                        foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                        {
                            if (item.TAISANID == models.CurHangMucCongTrinh.uId)
                            {
                                item.DienTich = models.CurHangMucCongTrinh.DIENTICHSAN;
                                item.MOTATOMTAT = models.mota;
                                if (item.TaiSanGanLienVoiDat != null)
                                {
                                    item.TaiSanGanLienVoiDat.TENTAISAN = models.CurHangMucCongTrinh.TENHANGMUC;
                                    item.TaiSanGanLienVoiDat.diachitaisan = diachi;
                                    if (item.trangthaitaisan != 1)
                                    {
                                        item.trangthaitaisan = 2;
                                    }
                                    item.TaiSanGanLienVoiDat.HangMucCongTrinh.CAPHANG = models.CurHangMucCongTrinh.CAPHANG;
                                    item.TaiSanGanLienVoiDat.HangMucCongTrinh.CONGNANG = models.CurHangMucCongTrinh.CONGNANG;
                                    item.TaiSanGanLienVoiDat.HangMucCongTrinh.CONGTRINHXAYDUNGID = models.CurHangMucCongTrinh.CONGTRINHXAYDUNGID;
                                    item.TaiSanGanLienVoiDat.HangMucCongTrinh.DIENTICHSAN = models.CurHangMucCongTrinh.DIENTICHSAN;
                                    item.TaiSanGanLienVoiDat.HangMucCongTrinh.DIENTICHXAYDUNG = models.CurHangMucCongTrinh.DIENTICHXAYDUNG;
                                    item.TaiSanGanLienVoiDat.HangMucCongTrinh.KETCAU = models.CurHangMucCongTrinh.KETCAU;
                                    item.TaiSanGanLienVoiDat.HangMucCongTrinh.NAMHOANTHANH = models.CurHangMucCongTrinh.NAMHOANTHANH;
                                    item.TaiSanGanLienVoiDat.HangMucCongTrinh.NAMXAYDUNG = models.CurHangMucCongTrinh.NAMXAYDUNG;
                                    item.TaiSanGanLienVoiDat.HangMucCongTrinh.SOTANG = models.CurHangMucCongTrinh.SOTANG;
                                    item.TaiSanGanLienVoiDat.HangMucCongTrinh.SOTANGHAM = models.CurHangMucCongTrinh.SOTANGHAM;
                                    item.TaiSanGanLienVoiDat.HangMucCongTrinh.TENHANGMUC = models.CurHangMucCongTrinh.TENHANGMUC;
                                    item.TaiSanGanLienVoiDat.HangMucCongTrinh.THOIHANSOHUU = models.CurHangMucCongTrinh.THOIHANSOHUU;
                                    item.TaiSanGanLienVoiDat.HangMucCongTrinh.DIACHIID = models.CurHangMucCongTrinh.DIACHIID;
                                    item.TaiSanGanLienVoiDat.DSThua = new List<DC_THUATAISAN>();
                                    if (dSSHTaiSan != null && dSSHTaiSan != "")
                                    {
                                        foreach (string id in arrdsthuataisan)
                                        {
                                            _add = new DC_THUATAISAN();
                                            _add.THUATAISANID = Guid.NewGuid().ToString();
                                            _add.TAISANGANLIENVOIDATID = item.TaiSanGanLienVoiDat.TAISANGANLIENVOIDATID;
                                            _add.THUADATID = id;
                                            item.TaiSanGanLienVoiDat.DSThua.Add(_add);
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    break;
                case 9:

                    if (models.CurRungTrong.RUNGTRONGID == null || models.CurRungTrong.RUNGTRONGID == "")
                    {
                        DC_RUNGTRONG rt = new DC_RUNGTRONG();
                        rt.RUNGTRONGID = models.CurRungTrong.RUNGTRONGID = Guid.NewGuid().ToString();
                        rt.DIENTICH = models.CurRungTrong.DIENTICH;
                        rt.HINHTHUCSOHUU = models.CurRungTrong.HINHTHUCSOHUU;
                        rt.LOAICAYRUNG = models.CurRungTrong.LOAICAYRUNG;
                        rt.TENRUNG = models.CurRungTrong.TENRUNG;
                        rt.THOIHANSOHUU = models.CurRungTrong.THOIHANSOHUU;
                        rt.DIACHI = models.CurRungTrong.DIACHI;
                        DC_TAISANGANLIENVOIDAT tsglvd = new DC_TAISANGANLIENVOIDAT();
                        tsglvd.TAISANGANLIENVOIDATID = Guid.NewGuid().ToString();
                        rt.uId = models.CurRungTrong.uId = tsglvd.TAISANGANLIENVOIDATID;
                        tsglvd.diachitaisan = diachi;
                        tsglvd.DSThua = new List<DC_THUATAISAN>();
                        tsglvd.LOAITAISAN = "9";
                        tsglvd.TENTAISAN = rt.TENRUNG;
                        tsglvd.TAISANID = rt.RUNGTRONGID;
                        DC_DANGKY_TAISAN dkts = new DC_DANGKY_TAISAN();
                        dkts.DANGKYTAISANID = Guid.NewGuid().ToString();
                        dkts.TAISANID = tsglvd.TAISANGANLIENVOIDATID;
                        dkts.MOTATOMTAT = models.mota;
                        dkts.LoaiTaiSan = "rừng trồng";
                        dkts.DienTich = rt.DIENTICH;
                        dkts.trangthaitaisan = 1;
                        dkts.TaiSanGanLienVoiDat = tsglvd;
                        dkts.TaiSanGanLienVoiDat.RungTrong = rt;
                        dkts.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
                        if (dSSHTaiSan != null && dSSHTaiSan != "")
                        {
                            foreach (string id in arrdsthuataisan)
                            {
                                _add = new DC_THUATAISAN();
                                _add.THUATAISANID = Guid.NewGuid().ToString();
                                _add.TAISANGANLIENVOIDATID = tsglvd.TAISANGANLIENVOIDATID;
                                _add.THUADATID = id;
                                tsglvd.DSThua.Add(_add);
                            }
                        }
                        bhs.HoSoTN.DonDangKy.DSDangKyTaiSan.Add(dkts);
                    }
                    else
                    {
                        foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                        {
                            if (item.TAISANID == models.CurRungTrong.uId || item.TaiSanGanLienVoiDat.TAISANID == models.CurRungTrong.RUNGTRONGID)
                            {
                                item.DienTich = models.CurRungTrong.DIENTICH;
                                item.MOTATOMTAT = models.mota;
                                if (item.TaiSanGanLienVoiDat != null)
                                {
                                    item.TaiSanGanLienVoiDat.TENTAISAN = models.CurRungTrong.TENRUNG;
                                    item.TaiSanGanLienVoiDat.diachitaisan = diachi;
                                    if (item.trangthaitaisan != 1)
                                    {
                                        item.trangthaitaisan = 2;
                                    }
                                    item.TaiSanGanLienVoiDat.RungTrong.DIENTICH = item.DienTich = models.CurRungTrong.DIENTICH;
                                    item.TaiSanGanLienVoiDat.RungTrong.HINHTHUCSOHUU = models.CurRungTrong.HINHTHUCSOHUU;
                                    item.TaiSanGanLienVoiDat.RungTrong.LOAICAYRUNG = models.CurRungTrong.LOAICAYRUNG;
                                    item.TaiSanGanLienVoiDat.RungTrong.TENRUNG = models.CurRungTrong.TENRUNG;
                                    item.TaiSanGanLienVoiDat.RungTrong.DIACHI = models.CurRungTrong.DIACHI;
                                    item.TaiSanGanLienVoiDat.RungTrong.THOIHANSOHUU = models.CurRungTrong.THOIHANSOHUU;
                                    item.TaiSanGanLienVoiDat.DSThua = new List<DC_THUATAISAN>();
                                    if (dSSHTaiSan != null && dSSHTaiSan != "")
                                    {
                                        foreach (string id in arrdsthuataisan)
                                        {
                                            _add = new DC_THUATAISAN();
                                            _add.THUATAISANID = Guid.NewGuid().ToString();
                                            _add.TAISANGANLIENVOIDATID = item.TaiSanGanLienVoiDat.TAISANGANLIENVOIDATID;
                                            _add.THUADATID = id;
                                            item.TaiSanGanLienVoiDat.DSThua.Add(_add);
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    break;
                case 10:
                    if (models.CurCayLauNam.CAYLAUNAMID == null || models.CurCayLauNam.CAYLAUNAMID == "")
                    {
                        DC_CAYLAUNAM cln = new DC_CAYLAUNAM();
                        cln.CAYLAUNAMID = models.CurCayLauNam.CAYLAUNAMID = Guid.NewGuid().ToString();
                        cln.DIACHIID = models.CurCayLauNam.DIACHIID;
                        cln.DIENTICH = models.CurCayLauNam.DIENTICH;
                        cln.HINHTHUCSOHUU = models.CurCayLauNam.HINHTHUCSOHUU;
                        cln.LOAICAYTRONG = models.CurCayLauNam.LOAICAYTRONG;
                        cln.TENCAYLAUNAM = models.CurCayLauNam.TENCAYLAUNAM;
                        cln.THOIHANSOHUU = models.CurCayLauNam.THOIHANSOHUU;
                        cln.DIACHI = models.CurCayLauNam.DIACHI;
                        DC_TAISANGANLIENVOIDAT tsglvd = new DC_TAISANGANLIENVOIDAT();
                        tsglvd.TAISANGANLIENVOIDATID = Guid.NewGuid().ToString();
                        cln.uId = models.CurCayLauNam.uId = tsglvd.TAISANGANLIENVOIDATID;
                        tsglvd.diachitaisan = diachi;
                        tsglvd.DSThua = new List<DC_THUATAISAN>();
                        tsglvd.LOAITAISAN = "10";
                        tsglvd.TENTAISAN = cln.TENCAYLAUNAM;
                        tsglvd.TAISANID = cln.CAYLAUNAMID;
                        DC_DANGKY_TAISAN dkts = new DC_DANGKY_TAISAN();
                        dkts.DANGKYTAISANID = Guid.NewGuid().ToString();
                        dkts.TAISANID = tsglvd.TAISANGANLIENVOIDATID;
                        dkts.MOTATOMTAT = models.mota;
                        dkts.trangthaitaisan = 1;
                        dkts.LoaiTaiSan = "Cây lâu năm";
                        dkts.DienTich = cln.DIENTICH;
                        dkts.TaiSanGanLienVoiDat = tsglvd;
                        dkts.TaiSanGanLienVoiDat.CayLauNam = cln;
                        dkts.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
                        if (dSSHTaiSan != null && dSSHTaiSan != "")
                        {
                            foreach (string id in arrdsthuataisan)
                            {
                                _add = new DC_THUATAISAN();
                                _add.THUATAISANID = Guid.NewGuid().ToString();
                                _add.TAISANGANLIENVOIDATID = tsglvd.TAISANGANLIENVOIDATID;
                                _add.THUADATID = id;
                                tsglvd.DSThua.Add(_add);
                            }
                        }
                        bhs.HoSoTN.DonDangKy.DSDangKyTaiSan.Add(dkts);
                    }
                    else
                    {
                        foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                        {
                            if (item.TAISANID == models.CurCayLauNam.uId || item.TaiSanGanLienVoiDat.TAISANID == models.CurCayLauNam.CAYLAUNAMID)
                            {
                                item.DienTich = models.CurCayLauNam.DIENTICH;
                                item.MOTATOMTAT = models.mota;
                                if (item.TaiSanGanLienVoiDat != null)
                                {
                                    item.TaiSanGanLienVoiDat.TENTAISAN = models.CurCayLauNam.TENCAYLAUNAM;
                                    item.TaiSanGanLienVoiDat.diachitaisan = diachi;
                                    if (item.trangthaitaisan != 1)
                                    {
                                        item.trangthaitaisan = 2;
                                    }
                                    item.TaiSanGanLienVoiDat.CayLauNam.DIENTICH = models.CurCayLauNam.DIENTICH;
                                    item.TaiSanGanLienVoiDat.CayLauNam.HINHTHUCSOHUU = models.CurCayLauNam.HINHTHUCSOHUU;
                                    item.TaiSanGanLienVoiDat.CayLauNam.LOAICAYTRONG = models.CurCayLauNam.LOAICAYTRONG;
                                    item.TaiSanGanLienVoiDat.CayLauNam.TENCAYLAUNAM = models.CurCayLauNam.TENCAYLAUNAM;
                                    item.TaiSanGanLienVoiDat.CayLauNam.THOIHANSOHUU = models.CurCayLauNam.THOIHANSOHUU;
                                    item.TaiSanGanLienVoiDat.CayLauNam.DIACHI = models.CurCayLauNam.DIACHI;
                                    item.TaiSanGanLienVoiDat.DSThua = new List<DC_THUATAISAN>();
                                    if (dSSHTaiSan != null && dSSHTaiSan != "")
                                    {
                                        foreach (string id in arrdsthuataisan)
                                        {
                                            _add = new DC_THUATAISAN();
                                            _add.THUATAISANID = Guid.NewGuid().ToString();
                                            _add.TAISANGANLIENVOIDATID = item.TaiSanGanLienVoiDat.TAISANGANLIENVOIDATID;
                                            _add.THUADATID = id;
                                            item.TaiSanGanLienVoiDat.DSThua.Add(_add);
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        public static List<HC_TINH> get_tinh()
        {
            List<HC_TINH> lst_tinh = new List<HC_TINH>();
            using (MplisEntities db = new MplisEntities())
            {
                lst_tinh = (from item in db.HC_TINH
                            select item).OrderBy(a => a.TENTINH).ToList();
            }
            return lst_tinh;
        }
        public static List<HC_HUYEN> get_huyen()
        {
            List<HC_HUYEN> lst_huyen = new List<HC_HUYEN>();
            using (MplisEntities db = new MplisEntities())
            {
                lst_huyen = (from item in db.HC_HUYEN
                             select item).OrderBy(a => a.TENHUYEN).ToList();
            }
            return lst_huyen;
        }
        public static List<HC_DMKVHC> get_xa()
        {
            List<HC_DMKVHC> lst_xa = new List<HC_DMKVHC>();
            using (MplisEntities db = new MplisEntities())
            {
                lst_xa = (from item in db.HC_DMKVHC
                          where item.MAKVHC.Length > 5
                          select item).OrderBy(a => a.TENKVHC).ToList();
            }
            return lst_xa;
        }
        public static List<HC_HUYEN> get_huyenbytinh(string tentinh)
        {
            List<HC_HUYEN> lst_huyen = new List<HC_HUYEN>();
            using (MplisEntities db = new MplisEntities())
            {
                var tinh = (from a in db.HC_TINH where a.TENTINH.Equals(tentinh) select a).FirstOrDefault();
                lst_huyen = (from item in db.HC_HUYEN
                             where item.TINHID.Equals(tinh.TINHID)
                             select item).OrderBy(a => a.TENHUYEN).ToList();
            }
            return lst_huyen;
        }
        public static List<HC_DMKVHC> get_xabyhuyen(string tenhuyen, string tentinh)
        {
            List<HC_DMKVHC> lst_xa = new List<HC_DMKVHC>();
            using (MplisEntities db = new MplisEntities())
            {
                var tinh = (from a in db.HC_TINH where a.TENTINH.Equals(tentinh) select a).FirstOrDefault();
                var huyen = (from a in db.HC_HUYEN where a.TENHUYEN.Equals(tenhuyen) && a.TINHID.Equals(tinh.TINHID) select a).FirstOrDefault();
                lst_xa = (from item in db.HC_DMKVHC
                          where item.MAKVHC.Length > 5 && item.HUYENID.Equals(huyen.HUYENID)
                          select item).OrderBy(a => a.TENKVHC).ToList();
            }
            return lst_xa;
        }
        public static DC_DIACHI get_diachibytaisanid(string id)
        {
            DC_DIACHI diachi = new DC_DIACHI();
            using (MplisEntities db = new MplisEntities())
            {
                var diachits = (from a in db.DC_TAISAN_DIACHI where a.TAISANGANLIENVOIDATID == id select a).FirstOrDefault();
                if (diachits != null)
                {
                    diachi = (from item in db.DC_DIACHI where item.DIACHIID == diachits.DIACHIID select item).FirstOrDefault();
                }
            }
            return diachi;
        }
        public static void xoadiachitaisan(string taisanid)
        {
            using (MplisEntities db = new MplisEntities())
            {
                if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                        || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                    db.Database.Connection.Open();
                var trans = db.Database.Connection.BeginTransaction();
                DbCommand cmd = db.Database.Connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "delete from DC_TAISAN_DIACHI where TAISANID = '" + taisanid + "'";
                cmd.ExecuteNonQuery();
                trans.Commit();
                db.SaveChanges();
            }
        }
        public static void xoadiachi(string diachiid)
        {
            using (MplisEntities db = new MplisEntities())
            {
                if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                        || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                    db.Database.Connection.Open();
                var trans = db.Database.Connection.BeginTransaction();
                DbCommand cmd = db.Database.Connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "delete from DC_DIACHI where DIACHIID = '" + diachiid + "'";
                cmd.ExecuteNonQuery();
                trans.Commit();
                db.SaveChanges();
            }
        }
    }
}