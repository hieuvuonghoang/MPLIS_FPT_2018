using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;
//using MPLIS.Libraries.Data.LuanChuyenHoSo.Models;
using System.Data.Entity;
using AutoMapper;
using System.Data.Common;
using System.Collections;
using Newtonsoft.Json.Linq;
using MPLIS.Libraries.Data.XuLyHoSo.Models;



namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCTHUADATServices
    {
        public static List<DM_LOAIBANDODIACHINH> GetLoaiBanDo()
        {
            using (MplisEntities dbo = new MplisEntities())
            {
                List<DM_LOAIBANDODIACHINH> lstdm_mdsd = new List<DM_LOAIBANDODIACHINH>();
                using (MplisEntities db = new MplisEntities())
                {
                    lstdm_mdsd = (from item in db.DM_LOAIBANDODIACHINH
                                  select item).OrderBy(a => a.TENLOAIBANDODIACHINH).ToList();
                }
                return lstdm_mdsd.ToList();
            }

        }
        public static string GetTenTaiLieuDoDac(string id)
        {
            using (MplisEntities dbo = new MplisEntities())
            {
                var objtailieu = (from item in dbo.DC_TAILIEUDODAC where item.TAILIEUDODACID == id select item).FirstOrDefault();
                if (objtailieu != null)
                {
                    return objtailieu.TENTAILIEU;
                }
                else return "";
            }

        }
        public static DC_THUADAT getThuaDat(string ThuaDatID)
        {
            DC_THUADAT ret;

            using (MplisEntities db = new MplisEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;
                var td = (from t in db.DC_THUADAT
                          where t.THUADATID.Equals(ThuaDatID)
                          select new
                          {
                              t,
                              TTs = db.DC_BD_THUA_THUA.Where(i => i.THUADATID.Equals(t.THUADATID)),
                              MDSDs = db.DC_MUCDICHSUDUNGDAT.Where(i => i.THUADATID.Equals(t.THUADATID))
                              .Select(md => new
                              {
                                  md,
                                  vt = db.DC_VITRITHUADAT.Where(i => i.MUCDICHSUDUNGDATID.Equals(md.MUCDICHSUDUNGDATID)),
                                  ngsdd = db.DC_NGUONGOCSUDUNG.Where(i => i.MUCDICHSUDUNGDATID.Equals(md.MUCDICHSUDUNGDATID))
                              }).ToList(),
                              GDs = db.GD_GIATHUADAT.Where(i => i.THUADATID.Equals(t.THUADATID)),
                              tc = db.DC_TRANHCHAP.Where(i => i.THUADATID.Equals(t.THUADATID)),
                              qsdd = db.DC_QUYENSUDUNGDAT.Where(i => i.THUADATID.Equals(t.THUADATID)),
                              hc = db.DC_HANCHE.Where(i=>i.THUADATID.Equals(t.THUADATID)),
                              tldd = db.DC_TAILIEUDODAC.Where(i => i.TAILIEUDODACID == t.TAILIEUDODACID).FirstOrDefault(),
                              Xa = db.HC_DMKVHC.Where(it => it.KVHCID.Equals(t.XAID)).FirstOrDefault()
                          }).FirstOrDefault();
                if (td != null)
                {
                    ret = td.t;
                    string soto = ret.SOHIEUTOBANDO.ToString();
                    string sothua = ret.SOTHUTUTHUA.ToString();
                    ret.QHThua = td.TTs.ToList();
                    ret.Xa = td.Xa;
                    ret.TenXaPhuong = td.Xa.TENKVHC;
                    if (ret.DOANDUONGID != null)
                    {
                        ret.DUONG = get_duongbydoanduong(ret.DOANDUONGID);
                    }
                    List<DC_MUCDICHSUDUNGDAT> xn = new List<DC_MUCDICHSUDUNGDAT>();
                    DC_MUCDICHSUDUNGDAT item;
                    DM_MUCDICHSUDUNG dmmd = new DM_MUCDICHSUDUNG();
                    foreach (var it in td.MDSDs)
                    {
                        item = it.md;
                        dmmd = (from a in db.DM_MUCDICHSUDUNG where a.MUCDICHSUDUNGID == item.MUCDICHSUDUNGID select a).FirstOrDefault();
                        item.MDSD = dmmd == null ? "" : dmmd.MAMUCDICHSUDUNG;
                        item.TenMDSD = dmmd == null ? "" : dmmd.TENMUCDICHSUDUNG;
                        item.NGSDDats = it.ngsdd.ToList();
                        item.DSViTriMDSD = it.vt.ToList();
                        item.DMMucDichSuDung = dmmd;
                        item.SOHIEUTOBANDO = td.t.SOHIEUTOBANDO ?? 0M;
                        item.SOTHUTUTHUA = td.t.SOTHUTUTHUA ?? 0M;
                        item.TenXaPhuong = td.Xa.TENKVHC;
                        string nguontostring = "";
                        List<string> listnguonid = new List<string>();
                        foreach (var a in item.NGSDDats)
                        {
                            listnguonid.Add(a.LOAINGUONGOCSUDUNGID);
                        }
                        item.NguonID = listnguonid;
                        nguontostring = GetLoaiNguonGocToString(item.NguonID);
                        if (item.SUDUNGCHUNG == 1)
                            item._SUDUNGCHUNG = true;
                        else
                            item._SUDUNGCHUNG = false;
                        if (item.LAMUCDICHCHINH == true)
                            item._LAMUCDICHCHINH = true;
                        else
                            item._LAMUCDICHCHINH = false;
                        xn.Add(item);
                    }
                    ret.DSMucDichSuDungDat = xn;
                    string str = "";
                    if (ret.DSMucDichSuDungDat != null && ret.DSMucDichSuDungDat.Count > 0)
                    {
                        foreach (var mdsd in ret.DSMucDichSuDungDat)
                        {
                            if (mdsd.DMMucDichSuDung != null)
                                str += mdsd.DMMucDichSuDung.MAMUCDICHSUDUNG + ", ";
                        }
                        if (str.Length > 0) str = str.Substring(0, str.Length - 2);
                    }
                    ret.DSMucDichSuDungDatToString = str;
                    ret.DSTranhChap = td.tc.ToList();
                    ret.DSGiaDat = td.GDs.ToList();
                    if (td.tldd != null)
                        ret.TENTAILIEUDD = td.tldd.TENTAILIEU;
                    var dshslk = (from a in db.HS_LIENKETTHUADAT where a.SOTO.Equals(soto) && a.SOTHUA.Equals(sothua) && a.XAID.Equals(ret.XAID) select a).ToList();
                    List<HS_HOSO> DShs = new List<HS_HOSO>();
                    HS_HOSO hs = new HS_HOSO();
                    foreach (var t1 in dshslk)
                    {
                        hs = (from a in db.HS_HOSO where a.HOSOID == t1.HOSOID select a).FirstOrDefault();
                        if (hs != null)
                            DShs.Add(hs);
                    }
                    ret.DSQuyenSDD = td.qsdd.ToList();
                    ret.DSHoSo = DShs;
                    ret.DSHanCheThua = td.hc.ToList();
                    foreach (var hct in ret.DSHanCheThua)
                    {
                        if (hct.CONHIEULUC == "Y")
                            hct._ConHieuLuc = true;
                        else
                            hct._ConHieuLuc = false;
                        if (hct.HANCHEMOTPHAN == "Y")
                            hct._HanCheMotPhan = true;
                        else
                            hct._HanCheMotPhan = false;
                    }
                    if (td.t.DANGTRANHCHAP == null || td.t.DANGTRANHCHAP.Equals("N"))
                        ret._DANGTRANHCHAP = false;
                    else
                        ret._DANGTRANHCHAP = true;
                }
                else ret = new DC_THUADAT();
            }
            return ret;
        }

        //Thêm thửa đất
        public static List<DC_DANGKY_THUA> ThemThuaDat(DC_THUADAT thuacu, DC_THUADAT thuamoi, List<DC_DANGKY_THUA> dsthua)
        {
            thuamoi.DSMucDichSuDungDat = thuacu.DSMucDichSuDungDat;
            bool checktontaithua = false;
            if (thuamoi.THUADATID != null && thuamoi.THUADATID != "")
            {
                foreach (var item in dsthua)
                {
                    if (item.Thua.THUADATID == thuamoi.THUADATID)
                    {
                        checktontaithua = true;
                        break;
                    }
                }
                if (checktontaithua == false)
                {
                    DC_DANGKY_THUA obj = new DC_DANGKY_THUA();
                    obj.Thua = thuamoi;
                    obj.THUADATID = thuamoi.THUADATID;
                    //thuamoi.TRANGTHAITHUA = "1";
                    dsthua.Add(obj);
                }
                else
                {
                    foreach (var a in dsthua)
                    {
                        if (a.Thua.THUADATID == thuamoi.THUADATID)
                        {
                            a.Thua = thuamoi;
                            //  a.Thua.TRANGTHAITHUA = "2";
                            break;
                        }
                    }
                }
            }
            else
            {
                thuamoi.THUADATID = Guid.NewGuid().ToString();
                DC_DANGKY_THUA obj = new DC_DANGKY_THUA();
                obj.Thua = thuamoi;
                obj.THUADATID = thuamoi.THUADATID;
                // thuamoi.TRANGTHAITHUA = "1";
                dsthua.Add(obj);
            }
            return dsthua;
        }

        public static DC_MUCDICHSUDUNGDAT getMDSDbyID(string idmdsddat)
        {
            using (MplisEntities dbo = new MplisEntities())
            {
                var obj = (from item in dbo.DC_MUCDICHSUDUNGDAT.Where(i => i.MUCDICHSUDUNGDATID == idmdsddat) select item).FirstOrDefault();
                if (obj != null)
                {
                    obj._LAMUCDICHCHINH = (obj.LAMUCDICHCHINH == null || obj.LAMUCDICHCHINH == false) ? false : true;
                }
                else
                {
                    obj = new DC_MUCDICHSUDUNGDAT();
                }
                return obj;
            }
        }

        public static DC_THUADAT getThuaDatSesion(string ThuaDatID, List<DC_DANGKY_THUA> dsthua)
        {
            DC_THUADAT objthua = new DC_THUADAT();
            foreach (var item in dsthua)
            {
                if (item.THUADATID == ThuaDatID)
                {
                    objthua = item.Thua;
                    break;
                }

            }
            return objthua;
        }
        public static string getAllMDSD(string thuaid, List<DC_MUCDICHSUDUNGDAT> dsmdsd)
        {
            string strmdsd = "";
            var lstmdsd = from item in dsmdsd where item.THUADATID == thuaid select item;
            using (MplisEntities dbo = new MplisEntities())
            {
                foreach (var a in lstmdsd)
                {
                    var objmdsd = (from b in dbo.DM_MUCDICHSUDUNG where b.MUCDICHSUDUNGID == a.MUCDICHSUDUNGID select b).FirstOrDefault();
                    if (objmdsd != null)
                    {
                        strmdsd = strmdsd + " ," + objmdsd.MAMUCDICHSUDUNG;
                    }
                }
            }
            return strmdsd;
        }
        public static List<DC_THUADAT> SearchThuaDat(string xaid, string sothututhua, string sotobando)
        {
            using (MplisEntities dbo = new MplisEntities())
            {
                decimal sothua = decimal.Parse(sothututhua);
                decimal soto = decimal.Parse(sotobando);
                var lstthua = from item in dbo.DC_THUADAT where item.XAID == xaid && item.SOTHUTUTHUA == sothua && item.SOHIEUTOBANDO == soto select item;
                return lstthua.ToList();
            }
        }

        public static bool SaveDangKyThua(BoHoSoModel bhs)
        {
            bool save = false;
            try
            {
                using (MplisEntities dbo = new MplisEntities())
                {
                    foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyThua)
                    {
                        switch (item.TRANGTHAITHUA)
                        {
                            //thêm mới
                            case "1":
                                //thêm mới thửa
                                DC_THUADAT objthua = new DC_THUADAT();
                                objthua = item.Thua;
                                if (item.Thua._TRONGDB == 1)
                                {
                                    DC_THUADAT objthuadb = new DC_THUADAT();
                                    Mapper.Map<DC_THUADAT, DC_THUADAT>(item.Thua, objthuadb);
                                    dbo.Entry(objthuadb).State = EntityState.Modified;

                                    //xóa mục didischs thửa add lại
                                    var listmucdichsd = (from b in dbo.DC_MUCDICHSUDUNGDAT where b.THUADATID == objthuadb.THUADATID select b);
                                    foreach (var objmdsd in listmucdichsd)
                                    {
                                        XoaViTri(objmdsd);
                                        XoaNguonGoc(objmdsd);
                                        //objmucdich = objmdsd;
                                        dbo.DC_MUCDICHSUDUNGDAT.Remove(objmdsd);

                                    }
                                    dbo.SaveChanges();
                                    foreach (var objthemmdsd in objthuadb.DSMucDichSuDungDat)
                                    {
                                        DC_MUCDICHSUDUNGDAT objmucdich = new DC_MUCDICHSUDUNGDAT();
                                        Mapper.Map<DC_MUCDICHSUDUNGDAT, DC_MUCDICHSUDUNGDAT>(objthemmdsd, objmucdich);
                                        dbo.DC_MUCDICHSUDUNGDAT.Add(objmucdich);
                                        dbo.SaveChanges();
                                        foreach (var objvitri in objmucdich.DSViTriMDSD)
                                        {
                                            DC_VITRITHUADAT vitri = new DC_VITRITHUADAT();
                                            Mapper.Map<DC_VITRITHUADAT, DC_VITRITHUADAT>(objvitri, vitri);
                                            dbo.DC_VITRITHUADAT.Add(vitri);
                                        }
                                        foreach (var objnguongoc in objmucdich.NGSDDats)
                                        {
                                            DC_NGUONGOCSUDUNG nguongoc = new DC_NGUONGOCSUDUNG();
                                            Mapper.Map<DC_NGUONGOCSUDUNG, DC_NGUONGOCSUDUNG>(objnguongoc, nguongoc);
                                            dbo.DC_NGUONGOCSUDUNG.Add(nguongoc);
                                        }
                                    }
                                    XoaGiaDat(objthuadb);
                                    foreach (var objthemgia in objthuadb.DSGiaDat)
                                    {
                                        dbo.GD_GIATHUADAT.Add(objthemgia);
                                    }
                                    XoaHanChe(objthuadb);
                                    if (objthuadb.DSHanCheThua != null)
                                    {
                                        foreach (var objhanche in objthuadb.DSHanCheThua)
                                        {
                                            dbo.DC_HANCHE.Add(objhanche);
                                        }
                                    }
                                }
                                else
                                {
                                    dbo.DC_THUADAT.Add(objthua);
                                    dbo.SaveChanges();
                                    //thêm mục đích sử dụng
                                    if (item.Thua.DSMucDichSuDungDat != null)
                                    {
                                        foreach (var objmdsd in item.Thua.DSMucDichSuDungDat)
                                        {

                                            DC_MUCDICHSUDUNGDAT objmucdich = new DC_MUCDICHSUDUNGDAT();
                                            objmucdich = objmdsd;
                                            dbo.DC_MUCDICHSUDUNGDAT.Add(objmucdich);
                                            dbo.SaveChanges();
                                            foreach (var objvitri in objmdsd.DSViTriMDSD)
                                            {
                                                dbo.DC_VITRITHUADAT.Add(objvitri);
                                            }
                                            foreach (var objnguongoc in objmdsd.NGSDDats)
                                            {
                                                dbo.DC_NGUONGOCSUDUNG.Add(objnguongoc);
                                            }
                                            // dbo.Entry(objmucdich).State = EntityState.Added;
                                        }
                                    }
                                    // thêm giá đất
                                    if (item.Thua.DSGiaDat != null)
                                    {
                                        foreach (var objgia in item.Thua.DSGiaDat)
                                        {
                                            GD_GIATHUADAT objgiadat = new GD_GIATHUADAT();
                                            objgiadat = objgia;
                                            dbo.GD_GIATHUADAT.Add(objgiadat);
                                        }
                                    }
                                    if (item.Thua.DSTranhChap != null)
                                    {
                                        foreach (var objtranhchap in item.Thua.DSTranhChap)
                                        {
                                            dbo.DC_TRANHCHAP.Add(objtranhchap);
                                        }
                                    }
                                    if (item.Thua.DSHanCheThua != null)
                                    {
                                        foreach(var objhanche in item.Thua.DSHanCheThua)
                                        {
                                            dbo.DC_HANCHE.Add(objhanche);
                                        }
                                    }
                                }
                                //dbo.SaveChanges();
                                DC_DANGKY_THUA objdangkythua = new DC_DANGKY_THUA();
                                objdangkythua.DONDANGKYID = item.DONDANGKYID;
                                objdangkythua.THUADATID = item.THUADATID;
                                objdangkythua.DANGKYTHUAID = item.DANGKYTHUAID;
                                objdangkythua.XAID = item.Thua.XAID;
                                objdangkythua.SOTHUTHUTHUA = item.Thua.SOTHUTUTHUA;
                                objdangkythua.SOHIEUTOBANDO = item.Thua.SOHIEUTOBANDO;
                                dbo.DC_DANGKY_THUA.Add(objdangkythua);
                                if (item.Thua._DACAPQUYEN == true)
                                {
                                    List<DC_QUYENSUDUNGDAT> listquyensd = (from a in dbo.DC_QUYENSUDUNGDAT where a.THUADATID == item.Thua.THUADATID || a.THUADATID == item.Thua.THUAGOCID select a).ToList();
                                    bool checkgcn = false;
                                    foreach(var quyen in listquyensd)
                                    {
                                        var objgcn_dangky = (from a in dbo.DC_DANGKY_GCN where a.DONDANGKYID == item.DONDANGKYID && a.GIAYCHUNGNHANID == quyen.GIAYCHUNGNHANID select a).FirstOrDefault();
                                            if (objgcn_dangky != null)
                                            {
                                                checkgcn = true;
                                                break;
                                            }
                                        if(checkgcn == false)
                                        {
                                            DC_GIAYCHUNGNHAN giaychungnhan = DCGIAYCHUNGNHANServices.getGiayChungNhan(quyen.GIAYCHUNGNHANID);
                                            DC_DANGKY_GCN dkgcn = new DC_DANGKY_GCN();
                                            dkgcn.GiayChungNhan = giaychungnhan;
                                            dkgcn.GIAYCHUNGNHANID = quyen.GIAYCHUNGNHANID;
                                            dkgcn.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
                                            dkgcn.DANGKYGCNID = Guid.NewGuid().ToString();
                                            dkgcn.MaVach = giaychungnhan.MAVACH;
                                            dkgcn.SoPhatHanh = giaychungnhan.SOPHATHANH;
                                            dbo.DC_DANGKY_GCN.Add(dkgcn);
                                            bhs.HoSoTN.DonDangKy.DSDangKyGCN.Add(dkgcn);
                                            dbo.SaveChanges();
                                            if (giaychungnhan.NGUOIID != null)
                                            {
                                                var objchu_dangky = (from a in dbo.DC_DANGKY_NGUOI where a.DONDANGKYID == item.DONDANGKYID && a.NGUOIID == giaychungnhan.NGUOIID select item).FirstOrDefault();
                                                if (objchu_dangky == null)
                                                {
                                                    DC_DANGKY_NGUOI objnguoi = new DC_DANGKY_NGUOI();
                                                    objnguoi.DANGKYNGUOIID = Guid.NewGuid().ToString();
                                                    objnguoi.DONDANGKYID = item.DONDANGKYID;
                                                    objnguoi.NGUOIID = giaychungnhan.NGUOIID;
                                                    dbo.DC_DANGKY_NGUOI.Add(objnguoi);
                                                    bhs.HoSoTN.DonDangKy.DSDangKyChu.Add(objnguoi);
                                                }
                                            }
                                            var listhua_gcn = from a in dbo.DC_QUYENSUDUNGDAT.Where(i => i.GIAYCHUNGNHANID.Equals(giaychungnhan.GIAYCHUNGNHANID))
                                                              select new
                                                              {
                                                                  a,
                                                                  mdsd = (from mucdich in dbo.DC_MUCDICHSUDUNGDAT.Where(b => b.MUCDICHSUDUNGDATID.Equals(a.MUCDICHSUDUNGDATID))
                                                                          select new
                                                                          {
                                                                              mdsd = mucdich,
                                                                              t = (dbo.DC_THUADAT.Where(td => td.THUADATID.Equals(mucdich.THUADATID))).FirstOrDefault()
                                                                          }).FirstOrDefault()
                                                              };
                                            if (listhua_gcn.Count() > 0)
                                            {
                                                foreach (var objthuadk in listhua_gcn)
                                                {
                                                    //var objthua_dangky = (from item in dbo.DC_DANGKY_THUA
                                                    //                      where item.THUADATID == objthuadk.THUADATID && item.DONDANGKYID == dondangkyid
                                                    //                      select item).FirstOrDefault();
                                                    bool checktontaithua = false;
                                                    foreach (var a in bhs.HoSoTN.DonDangKy.DSDangKyThua)
                                                    {
                                                        if ((a.SOHIEUTOBANDO == objthuadk.mdsd.t.SOHIEUTOBANDO) && (a.SOTHUTHUTHUA == objthuadk.mdsd.t.SOTHUTUTHUA) && (a.XAID == objthuadk.mdsd.t.XAID))
                                                        {
                                                            checktontaithua = true;
                                                            break;
                                                        }
                                                    }
                                                    if (checktontaithua == false)
                                                    {
                                                        var thua = DCTHUADATServices.getthuatimkiem(objthuadk.mdsd.t.SOTHUTUTHUA.ToString(), objthuadk.mdsd.t.SOHIEUTOBANDO.ToString(), objthuadk.mdsd.t.XAID);
                                                        if (thua.TRANGTHAI == "Y")
                                                        {
                                                            thua = DCTHUADATServices.CloneThuaDatTimKiem(thua);
                                                            thua.TRANGTHAI = "S";
                                                            dbo.DC_THUADAT.Add(thua);
                                                            dbo.SaveChanges();
                                                            foreach (var gd in thua.DSGiaDat)
                                                            {
                                                                dbo.GD_GIATHUADAT.Add(gd);
                                                            }
                                                            foreach (var hc in thua.DSHanCheThua)
                                                            {
                                                                dbo.DC_HANCHE.Add(hc);
                                                            }
                                                            foreach (var mdsd in thua.DSMucDichSuDungDat)
                                                            {
                                                                dbo.DC_MUCDICHSUDUNGDAT.Add(mdsd);
                                                                dbo.SaveChanges();
                                                                foreach (var vt in mdsd.DSViTriMDSD)
                                                                {
                                                                    dbo.DC_VITRITHUADAT.Add(vt);
                                                                }
                                                                foreach (var ng in mdsd.NGSDDats)
                                                                {
                                                                    dbo.DC_NGUONGOCSUDUNG.Add(ng);
                                                                }
                                                                dbo.SaveChanges();
                                                            }
                                                        }

                                                        //insert thửa mới vào bảng đăng ký thửa 
                                                        DC_DANGKY_THUA objdkthuamoi = new DC_DANGKY_THUA();
                                                        objdkthuamoi.DANGKYTHUAID = Guid.NewGuid().ToString();
                                                        objdkthuamoi.DONDANGKYID = item.DONDANGKYID;
                                                        objdkthuamoi.THUADATID = thua.THUADATID;
                                                        // objdkthuamoi.MUCDICHSUDUNGDATID = objmdcdmoi.MUCDICHSUDUNGDATID;
                                                        objdkthuamoi.SOHIEUTOBANDO = thua.SOHIEUTOBANDO;
                                                        objdkthuamoi.SOTHUTHUTHUA = thua.SOTHUTUTHUA;
                                                        objdkthuamoi.XAID = thua.XAID;
                                                        objdkthuamoi.Thua = thua;
                                                        objdkthuamoi.mdsd = thua.DSMucDichSuDungDatToString;
                                                        objdkthuamoi.TenXaPhuong = thua.Xa.TENKVHC;
                                                        //  dbo.DC_MUCDICHSUDUNGDAT.Add(objmdcdmoi);
                                                        //  dbo.SaveChanges();
                                                        dbo.DC_DANGKY_THUA.Add(objdkthuamoi);
                                                        bhs.HoSoTN.DonDangKy.DSDangKyThua.Add(objdkthuamoi);
                                                    }
                                                }
                                            }
                                            var listtaisan_gcn = (from a in dbo.DC_QUYENSOHUUTAISAN where a.GIAYCHUNGNHANID.Equals(giaychungnhan.GIAYCHUNGNHANID) select a).ToList();
                                            if (listtaisan_gcn.Count() > 0)
                                            {
                                                foreach (var objtaisandk in listtaisan_gcn)
                                                {
                                                    DC_DANGKY_TAISAN objtaisan_dangky = new DC_DANGKY_TAISAN();
                                                    var listts = (from a in dbo.DC_TAISANGANLIENVOIDAT where a.TAISANGANLIENVOIDATID == objtaisandk.TAISANGANLIENVOIDATID || a.TAISANGOCID == objtaisandk.TAISANGANLIENVOIDATID select a).ToList();
                                                    foreach (var objtaisanglvd in listts)
                                                    {
                                                        objtaisan_dangky = (from ts in dbo.DC_DANGKY_TAISAN
                                                                            where ts.TAISANID == objtaisanglvd.TAISANGANLIENVOIDATID && ts.DONDANGKYID == item.DONDANGKYID
                                                                            select ts).FirstOrDefault();
                                                        if (objtaisan_dangky != null)
                                                        {
                                                            break;
                                                        }
                                                    }
                                                    if (objtaisan_dangky == null)
                                                    {
                                                        //clone tài sản
                                                        DC_TAISANGANLIENVOIDAT objtaisannew = new DC_TAISANGANLIENVOIDAT();
                                                        var objtaisancu = DCTAISANGANLIENVOIDATServices.getTaiSanGanLienVoiDat(objtaisandk.TAISANGANLIENVOIDATID);
                                                        if (objtaisancu != null)
                                                        {
                                                            objtaisannew = Mapper.Map<DC_TAISANGANLIENVOIDAT, DC_TAISANGANLIENVOIDAT>(objtaisancu);
                                                            objtaisannew.TAISANGANLIENVOIDATID = Guid.NewGuid().ToString();
                                                            objtaisannew.TAISANGOCID = objtaisancu.TAISANGANLIENVOIDATID;
                                                            //objthuanew.THUAGOCID = objthuacu.THUADATID;
                                                            objtaisannew.TRANGTHAI = "S";
                                                            dbo.DC_TAISANGANLIENVOIDAT.Add(objtaisannew);
                                                            //insert tài sản đăng ky

                                                        }
                                                        DC_DANGKY_TAISAN objdktaisanmoi = new DC_DANGKY_TAISAN();
                                                        objdktaisanmoi.DANGKYTAISANID = Guid.NewGuid().ToString();
                                                        objdktaisanmoi.DONDANGKYID = item.DONDANGKYID;
                                                        objdktaisanmoi.TAISANID = objtaisannew.TAISANGANLIENVOIDATID;
                                                        objdktaisanmoi.LoaiTaiSan = objtaisannew.LoaiTaiSanGanLienVoiDat.TENLOAITAISANGANLIENVOIDAT;
                                                        objdktaisanmoi.DienTich = objtaisannew.DienTich;
                                                        objdktaisanmoi.TaiSanGanLienVoiDat = objtaisannew;
                                                        dbo.DC_DANGKY_TAISAN.Add(objdktaisanmoi);
                                                        bhs.HoSoTN.DonDangKy.DSDangKyTaiSan.Add(objdktaisanmoi);
                                                        dbo.SaveChanges();
                                                    }

                                                }
                                            }
                                        }
                                    }
                                }
                                break;
                            //sửa
                            case "2":
                                DC_THUADAT objsuathua = new DC_THUADAT();
                                Mapper.Map<DC_THUADAT, DC_THUADAT>(item.Thua, objsuathua);
                                dbo.Entry(objsuathua).State = EntityState.Modified;

                                //xóa mục didischs thửa add lại
                                var lstmucdichsd = (from b in dbo.DC_MUCDICHSUDUNGDAT where b.THUADATID == objsuathua.THUADATID select b);
                                foreach (var objmdsd in lstmucdichsd)
                                {
                                    XoaViTri(objmdsd);
                                    XoaNguonGoc(objmdsd);
                                    //objmucdich = objmdsd;
                                    dbo.DC_MUCDICHSUDUNGDAT.Remove(objmdsd);

                                }
                                dbo.SaveChanges();
                                foreach (var objthemmdsd in objsuathua.DSMucDichSuDungDat)
                                {
                                    DC_MUCDICHSUDUNGDAT objmucdich = new DC_MUCDICHSUDUNGDAT();
                                    Mapper.Map<DC_MUCDICHSUDUNGDAT, DC_MUCDICHSUDUNGDAT>(objthemmdsd, objmucdich);
                                    dbo.DC_MUCDICHSUDUNGDAT.Add(objmucdich);
                                    dbo.SaveChanges();
                                    foreach (var objvitri in objmucdich.DSViTriMDSD)
                                    {
                                        DC_VITRITHUADAT vitri = new DC_VITRITHUADAT();
                                        Mapper.Map<DC_VITRITHUADAT, DC_VITRITHUADAT>(objvitri, vitri);
                                        dbo.DC_VITRITHUADAT.Add(vitri);
                                    }
                                    foreach (var objnguongoc in objmucdich.NGSDDats)
                                    {
                                        DC_NGUONGOCSUDUNG nguon = new DC_NGUONGOCSUDUNG();
                                        Mapper.Map<DC_NGUONGOCSUDUNG, DC_NGUONGOCSUDUNG>(objnguongoc, nguon);
                                        dbo.DC_NGUONGOCSUDUNG.Add(nguon);
                                    }
                                }
                                XoaGiaDat(objsuathua);
                                foreach (var objthemgia in objsuathua.DSGiaDat)
                                {
                                    dbo.GD_GIATHUADAT.Add(objthemgia);
                                }
                                XoaHanChe(objsuathua);
                                if(objsuathua.DSHanCheThua != null)
                                {
                                    foreach (var objhanche in objsuathua.DSHanCheThua)
                                    {
                                        dbo.DC_HANCHE.Add(objhanche);
                                    }
                                }
                                //dbo.SaveChanges();
                                break;
                            //xóa
                            case "3":
                                var obj = (from a in dbo.DC_DANGKY_THUA where a.DANGKYTHUAID == item.DANGKYTHUAID select a).FirstOrDefault();
                                if (obj != null)
                                {
                                    dbo.Entry(obj).State = EntityState.Deleted;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    dbo.SaveChanges();
                    // return true;
                    save = true;
                }
            }
            catch (Exception ex)
            {
                save = false;
                throw;
            }
            return save;
        }
        public static DC_TAILIEUDODAC getTaiLieuDoDac(string tailieudodacid)
        {
            DC_TAILIEUDODAC obj = new DC_TAILIEUDODAC();
            using (MplisEntities dbo = new MplisEntities())
            {
                obj = (from item in dbo.DC_TAILIEUDODAC where item.TAILIEUDODACID == tailieudodacid select item).FirstOrDefault();
                if (obj == null)
                {
                    obj = new DC_TAILIEUDODAC();
                }
            }
            return obj;
        }

        // lưu tài sản
        //Clone thửa đất
        public static DC_THUADAT CloneThuaDat(DC_THUADAT thuaDatGoc)
        {
            DC_THUADAT thuaDatClone = new DC_THUADAT();
            using (MplisEntities db = new MplisEntities())
            {
                Mapper.Map<DC_THUADAT, DC_THUADAT>(thuaDatGoc, thuaDatClone);
                thuaDatClone.THUAGOCID = thuaDatClone.THUADATID;
                thuaDatClone.THUADATID = Guid.NewGuid().ToString();
                //Clone dữ liệu liên quan tới thửa đất: DC_MUCDICHSUDUNGDAT, GD_GIATHUADAT
                //DC_MUCDICHSUDUNGDAT
                foreach (var mdsd in thuaDatClone.DSMucDichSuDungDat)
                {
                    mdsd.THUADATID = thuaDatClone.THUADATID;
                    DCMUCDICHSUDUNGServices.CloneMucDichSuDungDat(mdsd);
                }
                //GD_GIATHUADAT
                foreach (var gt in thuaDatClone.DSGiaDat)
                {
                    gt.THUADATID = thuaDatClone.THUADATID;
                    GDGIATHUADATServices.CloneGiaThuaDat(gt);
                }
            }
            return thuaDatClone;
        }
        public static List<DC_THUADAT> TimKiemThua(string SttThua, string SoToBanDo, string KhuVucHanhChinh)
        {
            DC_THUADAT thua = new DC_THUADAT();
            int sttthua = int.Parse(SttThua);
            int stbd = int.Parse(SoToBanDo);
            List<DC_THUADAT> lstthuatimkiem = new List<DC_THUADAT>();
            using (MplisEntities db = new MplisEntities())
            {
                thua = (from t1 in db.DC_THUADAT
                        where t1.SOTHUTUTHUA == sttthua && t1.SOHIEUTOBANDO == stbd && t1.XAID == KhuVucHanhChinh
                        select t1).FirstOrDefault();
                lstthuatimkiem.Add(thua);
            }
            if (thua.TRANGTHAI == "Y")
            {
                DC_THUADAT thuaclone = new DC_THUADAT();
                thuaclone = DCTHUADATServices.CloneThuaDat(thua);
                thuaclone.TRANGTHAI = "S";
                lstthuatimkiem.Add(thuaclone);
            }
            return lstthuatimkiem;
        }
        public static DC_THUADAT getthuatimkiem(string SttThua, string SoToBanDo, string KhuVucHanhChinh)
        {
            DC_THUADAT ret;
            decimal sttthua = decimal.Parse(SttThua);
            decimal stbd = decimal.Parse(SoToBanDo);
            using (MplisEntities db = new MplisEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;
                var td = (from t in db.DC_THUADAT
                          where t.SOHIEUTOBANDO == stbd && t.SOTHUTUTHUA == sttthua && t.XAID.Equals(KhuVucHanhChinh)&&t.TRANGTHAI.Equals("S")
                          select new
                          {
                              t,
                              TTs = db.DC_BD_THUA_THUA.Where(i => i.THUADATID.Equals(t.THUADATID)),
                              MDSDs = db.DC_MUCDICHSUDUNGDAT.Where(i => i.THUADATID.Equals(t.THUADATID))
                              .Select(md => new
                              {
                                  md,
                                  vt = db.DC_VITRITHUADAT.Where(i => i.MUCDICHSUDUNGDATID.Equals(md.MUCDICHSUDUNGDATID)),
                                  ngsdd = db.DC_NGUONGOCSUDUNG.Where(i => i.MUCDICHSUDUNGDATID.Equals(md.MUCDICHSUDUNGDATID))
                              }).ToList(),
                              GDs = db.GD_GIATHUADAT.Where(i => i.THUADATID.Equals(t.THUADATID)),
                              tc = db.DC_TRANHCHAP.Where(i => i.THUADATID.Equals(t.THUADATID)),
                              hslk = db.HS_LIENKETTHUADAT.Where(i => i.XAID.Equals(t.XAID) && i.SOTO == SoToBanDo && i.SOTHUA == SttThua),
                              qsdd = db.DC_QUYENSUDUNGDAT.Where(i => i.THUADATID.Equals(t.THUADATID)),
                              hc=db.DC_HANCHE.Where(i=>i.THUADATID.Equals(t.THUADATID)),
                              tldd = db.DC_TAILIEUDODAC.Where(i => i.TAILIEUDODACID == t.TAILIEUDODACID).FirstOrDefault(),
                              Xa = db.HC_DMKVHC.Where(it => it.KVHCID.Equals(t.XAID)).FirstOrDefault()
                          }).FirstOrDefault();
                if (td == null)
                {
                    td = (from t in db.DC_THUADAT
                          where t.SOHIEUTOBANDO == stbd && t.SOTHUTUTHUA == sttthua && t.XAID.Equals(KhuVucHanhChinh)
                          select new
                          {
                              t,
                              TTs = db.DC_BD_THUA_THUA.Where(i => i.THUADATID.Equals(t.THUADATID)),
                              MDSDs = db.DC_MUCDICHSUDUNGDAT.Where(i => i.THUADATID.Equals(t.THUADATID))
                              .Select(md => new
                              {
                                  md,
                                  vt = db.DC_VITRITHUADAT.Where(i => i.MUCDICHSUDUNGDATID.Equals(md.MUCDICHSUDUNGDATID)),
                                  ngsdd = db.DC_NGUONGOCSUDUNG.Where(i => i.MUCDICHSUDUNGDATID.Equals(md.MUCDICHSUDUNGDATID))
                              }).ToList(),
                              GDs = db.GD_GIATHUADAT.Where(i => i.THUADATID.Equals(t.THUADATID)),
                              tc = db.DC_TRANHCHAP.Where(i => i.THUADATID.Equals(t.THUADATID)),
                              hslk = db.HS_LIENKETTHUADAT.Where(i => i.XAID.Equals(t.XAID) && i.SOTO == SoToBanDo && i.SOTHUA == SttThua),
                              qsdd = db.DC_QUYENSUDUNGDAT.Where(i => i.THUADATID.Equals(t.THUADATID)),
                              hc = db.DC_HANCHE.Where(i => i.THUADATID.Equals(t.THUADATID)),
                              tldd = db.DC_TAILIEUDODAC.Where(i => i.TAILIEUDODACID == t.TAILIEUDODACID).FirstOrDefault(),
                              Xa = db.HC_DMKVHC.Where(it => it.KVHCID.Equals(t.XAID)).FirstOrDefault()
                          }).FirstOrDefault();
                }
                if (td != null)
                {
                    ret = td.t;
                    ret.QHThua = td.TTs.ToList();
                    ret.Xa = td.Xa;
                    if (ret.DOANDUONGID != null)
                    {
                        ret.DUONG = get_duongbydoanduong(ret.DOANDUONGID);
                    }
                    List<DC_MUCDICHSUDUNGDAT> xn = new List<DC_MUCDICHSUDUNGDAT>();
                    DC_MUCDICHSUDUNGDAT item;
                    DM_MUCDICHSUDUNG dmmd = new DM_MUCDICHSUDUNG();
                    foreach (var it in td.MDSDs)
                    {
                        item = it.md;
                        dmmd = (from a in db.DM_MUCDICHSUDUNG where a.MUCDICHSUDUNGID == item.MUCDICHSUDUNGID select a).FirstOrDefault();
                        item.MDSD = dmmd == null ? "" : dmmd.MAMUCDICHSUDUNG;
                        item.TenMDSD = dmmd == null ? "" : dmmd.TENMUCDICHSUDUNG;
                        item.NGSDDats = it.ngsdd.ToList();
                        item.DSViTriMDSD = it.vt.ToList();
                        List<string> listnguonid = new List<string>();
                        string nguontostring ="";
                        foreach(var a in item.NGSDDats)
                        {
                            listnguonid.Add(a.LOAINGUONGOCSUDUNGID);
                        }
                        item.NguonID = listnguonid;
                        nguontostring = GetLoaiNguonGocToString(item.NguonID);
                        item.DMMucDichSuDung = dmmd;
                        if (item.SUDUNGCHUNG == 1)
                            item._SUDUNGCHUNG = true;
                        else
                            item._SUDUNGCHUNG = false;
                        if (item.LAMUCDICHCHINH == true)
                            item._LAMUCDICHCHINH = true;
                        else
                            item._LAMUCDICHCHINH = false;
                        xn.Add(item);
                    }
                    ret.DSMucDichSuDungDat = xn;
                    string str = "";
                    if (ret.DSMucDichSuDungDat != null && ret.DSMucDichSuDungDat.Count > 0)
                    {
                        foreach (var mdsd in ret.DSMucDichSuDungDat)
                        {
                            if (mdsd.DMMucDichSuDung != null)
                                str += mdsd.DMMucDichSuDung.MAMUCDICHSUDUNG + ", ";
                        }
                        if (str.Length > 0) str = str.Substring(0, str.Length - 2);

                    }
                    ret.DSMucDichSuDungDatToString = str;
                    ret.DSTranhChap = td.tc.ToList();
                    ret.DSHoSoLK = td.hslk.ToList();
                    ret.DSGiaDat = td.GDs.ToList();
                    if (td.tldd != null)
                        ret.TENTAILIEUDD = td.tldd.TENTAILIEU;
                    List<HS_HOSO> DShs = new List<HS_HOSO>();
                    HS_HOSO hs = new HS_HOSO();
                    foreach (var t1 in ret.DSHoSoLK)
                    {
                        hs = (from a in db.HS_HOSO where a.HOSOID == t1.HOSOID select a).FirstOrDefault();
                        if (hs != null)
                            DShs.Add(hs);
                    }

                    ret.DSQuyenSDD = td.qsdd.ToList();
                    ret.DSHoSo = DShs;
                    ret.DSHanCheThua = td.hc.ToList();
                    foreach(var hct in ret.DSHanCheThua)
                    {
                        if (hct.CONHIEULUC == "Y")
                            hct._ConHieuLuc = true;
                        else
                            hct._ConHieuLuc = false;
                        if (hct.HANCHEMOTPHAN == "Y")
                            hct._HanCheMotPhan = true;
                        else
                            hct._HanCheMotPhan = false;
                    }
                    if (td.t.DANGTRANHCHAP == null || td.t.DANGTRANHCHAP.Equals("N"))
                        ret._DANGTRANHCHAP = false;
                    else
                        ret._DANGTRANHCHAP = true;
                    if (td.t.LADOITUONGCHIEMDAT == null || td.t.LADOITUONGCHIEMDAT == 0)
                        ret._LADOITUONGCHIEMDAT = false;
                    else
                        ret._LADOITUONGCHIEMDAT = true;
                }
                else {
                    ret = new DC_THUADAT();
                    ret.DSGiaDat = new List<GD_GIATHUADAT>();
                    ret.DSMucDichSuDungDat = new List<DC_MUCDICHSUDUNGDAT>();
                    ret.DSTranhChap = new List<DC_TRANHCHAP>();
                    ret.SOHIEUTOBANDO = stbd;
                    ret.SOTHUTUTHUA = sttthua;
                    ret.THUADATID = Guid.NewGuid().ToString();
                }
            }
            return ret;
        }
        public static DC_THUADAT CloneThuaDatTimKiem(DC_THUADAT thuaDatGoc)
        {
            DC_THUADAT thuaDatClone = new DC_THUADAT();
            Mapper.Map<DC_THUADAT, DC_THUADAT>(thuaDatGoc, thuaDatClone);
            thuaDatClone.THUAGOCID = thuaDatClone.THUADATID;
            thuaDatClone.THUADATID = Guid.NewGuid().ToString();
            //Clone dữ liệu liên quan tới thửa đất: DC_MUCDICHSUDUNGDAT, GD_GIATHUADAT
            //DC_MUCDICHSUDUNGDAT
            foreach (var mdsd in thuaDatClone.DSMucDichSuDungDat)
            {
                mdsd.THUADATID = thuaDatClone.THUADATID;
                DC_MUCDICHSUDUNGDAT mdsdclone=  CloneMucDichSuDungDat(mdsd);
                Mapper.Map<DC_MUCDICHSUDUNGDAT, DC_MUCDICHSUDUNGDAT>(mdsdclone, mdsd);
            }
            //GD_GIATHUADAT
            foreach (var gt in thuaDatClone.DSGiaDat)
            {
                gt.THUADATID = thuaDatClone.THUADATID;
                GD_GIATHUADAT giadatclone = CloneGiaThuaDat(gt);
                Mapper.Map<GD_GIATHUADAT, GD_GIATHUADAT>(giadatclone, gt);
            }
            foreach (var tc in thuaDatClone.DSTranhChap)
            {
                tc.THUADATID = thuaDatClone.THUADATID;
                CloneTranhChap(tc);
            }
            foreach (var hc in thuaDatClone.DSHanCheThua)
            {
                hc.THUADATID = thuaDatClone.THUADATID;
                DC_HANCHE hancheclone = CloneHanChe(hc);
                Mapper.Map<DC_HANCHE, DC_HANCHE>(hancheclone, hc);
            }
            return thuaDatClone;
        }
        public static DC_MUCDICHSUDUNGDAT CloneMucDichSuDungDat(DC_MUCDICHSUDUNGDAT mucDichSuDungDatGoc)
        {
            DC_MUCDICHSUDUNGDAT mucDichSuDungDatClone = new DC_MUCDICHSUDUNGDAT();
            Mapper.Map<DC_MUCDICHSUDUNGDAT, DC_MUCDICHSUDUNGDAT>(mucDichSuDungDatGoc, mucDichSuDungDatClone);
            mucDichSuDungDatClone.MDSDGOCID = mucDichSuDungDatClone.MUCDICHSUDUNGDATID;
            mucDichSuDungDatClone.MUCDICHSUDUNGDATID = Guid.NewGuid().ToString();
            //Clone DC_NGUONGOCSUDUNG
            foreach (var ngsd in mucDichSuDungDatClone.NGSDDats)
            {
                ngsd.MUCDICHSUDUNGDATID = mucDichSuDungDatClone.MUCDICHSUDUNGDATID;
                DC_NGUONGOCSUDUNG nguonclone= CloneDCNguonGocSuDung(ngsd);
                Mapper.Map<DC_NGUONGOCSUDUNG, DC_NGUONGOCSUDUNG>(nguonclone, ngsd);
            }
            foreach (var vtmd in mucDichSuDungDatClone.DSViTriMDSD)
            {
                vtmd.MUCDICHSUDUNGDATID = mucDichSuDungDatClone.MUCDICHSUDUNGDATID;
               DC_VITRITHUADAT vitriclone= CloneDCViTri(vtmd);
                Mapper.Map<DC_VITRITHUADAT, DC_VITRITHUADAT>(vitriclone,vtmd);
            }
            return mucDichSuDungDatClone;
        }
        public static DC_NGUONGOCSUDUNG CloneDCNguonGocSuDung(DC_NGUONGOCSUDUNG nguonGocSuDungGoc)
        {
            DC_NGUONGOCSUDUNG nguonGocSuDungClone = new DC_NGUONGOCSUDUNG();
            Mapper.Map<DC_NGUONGOCSUDUNG, DC_NGUONGOCSUDUNG>(nguonGocSuDungGoc, nguonGocSuDungClone);
            nguonGocSuDungClone.NGUONGOCSUDUNGID = Guid.NewGuid().ToString();
            return nguonGocSuDungClone;
        }
        public static DC_VITRITHUADAT CloneDCViTri(DC_VITRITHUADAT vitrithua)
        {
            DC_VITRITHUADAT vitriclone = new DC_VITRITHUADAT();
            Mapper.Map<DC_VITRITHUADAT, DC_VITRITHUADAT>(vitrithua, vitriclone);
            vitriclone.VITRIID = Guid.NewGuid().ToString();
            return vitriclone;
        }
        public static GD_GIATHUADAT CloneGiaThuaDat(GD_GIATHUADAT giaThuaDatGoc)
        {
            GD_GIATHUADAT giaThuaDatClone = new GD_GIATHUADAT();
            Mapper.Map<GD_GIATHUADAT, GD_GIATHUADAT>(giaThuaDatGoc, giaThuaDatClone);
            giaThuaDatClone.GIATHUADATID = Guid.NewGuid().ToString();
            return giaThuaDatClone;
        }
        public static DC_TRANHCHAP CloneTranhChap(DC_TRANHCHAP TranhChapThua)
        {
            DC_TRANHCHAP TranhChapClone = new DC_TRANHCHAP();
            Mapper.Map<DC_TRANHCHAP, DC_TRANHCHAP>(TranhChapThua, TranhChapClone);
            TranhChapClone.TRANHCHAPID = Guid.NewGuid().ToString();
            return TranhChapClone;
        }
        public static DC_HANCHE CloneHanChe(DC_HANCHE HanCheThua)
        {
            DC_HANCHE HanCheClone = new DC_HANCHE();
            Mapper.Map<DC_HANCHE, DC_HANCHE>(HanCheThua, HanCheClone);
            HanCheClone.HANCHEID = Guid.NewGuid().ToString();
            return HanCheClone;
        }

        public static bool checkGCN(DC_THUADAT models)
        {
            if (models.DSMucDichSuDungDat != null)
                foreach (var item in models.DSMucDichSuDungDat)
                {
                    if (item.SOLANCAPQUYEN > 0)
                        return true;
                    break;
                }
            return false;
        }
        public static bool CheckDuLieuThua(DC_THUADAT models)
        {
            List<DC_THUADAT> thuacheck;
            using (MplisEntities db = new MplisEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;
                thuacheck = (from a in db.DC_THUADAT where a.XAID == models.XAID && a.SOHIEUTOBANDO == models.SOHIEUTOBANDO && a.SOTHUTUTHUA == models.SOTHUTUTHUA select a).ToList();
                if (thuacheck != null)
                {
                    foreach(var item in thuacheck)
                    {
                        if (item.TRANGTHAI == "S" && item.THUADATID != models.THUADATID)
                        {
                            return true;
                        }
                        if (item.TRANGTHAI == "Y" && item.THUADATID != models.THUAGOCID)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
        public static void XoaViTri(DC_MUCDICHSUDUNGDAT mdsd)
        {
            using (MplisEntities db = new MplisEntities())
            {
                if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                        || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                    db.Database.Connection.Open();
                var trans = db.Database.Connection.BeginTransaction();
                DbCommand cmd = db.Database.Connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "delete from DC_VITRITHUADAT where MUCDICHSUDUNGDATID = '" + mdsd.MUCDICHSUDUNGDATID + "'";
                cmd.ExecuteNonQuery();
                trans.Commit();
                db.SaveChanges();
            }
        }
        public static void XoaGiaDat(DC_THUADAT thua)
        {
            using (MplisEntities db = new MplisEntities())
            {
                if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                        || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                    db.Database.Connection.Open();
                var trans = db.Database.Connection.BeginTransaction();
                DbCommand cmd = db.Database.Connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "delete from GD_GIATHUADAT where THUADATID = '" + thua.THUADATID + "'";
                cmd.ExecuteNonQuery();
                trans.Commit();
                db.SaveChanges();
            }
        }
        public static void XoaHanChe(DC_THUADAT thua)
        {
            using (MplisEntities db = new MplisEntities())
            {
                if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                        || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                    db.Database.Connection.Open();
                var trans = db.Database.Connection.BeginTransaction();
                DbCommand cmd = db.Database.Connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "delete from DC_HANCHE where THUADATID = '" + thua.THUADATID + "'";
                cmd.ExecuteNonQuery();
                trans.Commit();
                db.SaveChanges();
            }
        }
        public static void XoaNguonGoc(DC_MUCDICHSUDUNGDAT mdsd)
        {
            using (MplisEntities db = new MplisEntities())
            {
                if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                        || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                    db.Database.Connection.Open();
                var trans = db.Database.Connection.BeginTransaction();
                DbCommand cmd = db.Database.Connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "delete from DC_NGUONGOCSUDUNG where MUCDICHSUDUNGDATID = '" + mdsd.MUCDICHSUDUNGDATID + "'";
                cmd.ExecuteNonQuery();
                trans.Commit();
                db.SaveChanges();
            }
        }

        public static void ThemMDSD(DC_THUADAT models,DC_THUADAT thuamoi,string TenMDSD)
        {
            if (models.CurMDSDDAT.MUCDICHSUDUNGDATID == null || models.CurMDSDDAT.MUCDICHSUDUNGDATID == "")
            {
                models.CurMDSDDAT.THUADATID = thuamoi.THUADATID;
                models.CurMDSDDAT.MUCDICHSUDUNGDATID = Guid.NewGuid().ToString();
                if (models.CurMDSDDAT.LOAITHOIHANSUDUNG == "0")
                {
                    models.CurMDSDDAT.THOIHANSUDUNG = "Lâu dài";
                }
                else
                {
                    if (models.CurMDSDDAT.TUNGAY == null)
                    {
                        models.CurMDSDDAT.THOIHANSUDUNG = " đến ngày " + models.CurMDSDDAT.DENNGAY.Value.ToString("dd/MM/yyyy");
                    }
                    if (models.CurMDSDDAT.DENNGAY == null)
                    {
                        models.CurMDSDDAT.THOIHANSUDUNG = "Từ ngày " + models.CurMDSDDAT.TUNGAY.Value.ToString("dd/MM/yyyy");
                    }
                    if(models.CurMDSDDAT.TUNGAY!=null && models.CurMDSDDAT.DENNGAY != null)
                    {
                        models.CurMDSDDAT.THOIHANSUDUNG = "Từ ngày " + models.CurMDSDDAT.TUNGAY.Value.ToString("dd/MM/yyyy") + " đến ngày " + models.CurMDSDDAT.DENNGAY.Value.ToString("dd/MM/yyyy");
                    }
                }
                if (models.CurMDSDDAT._LAMUCDICHCHINH == true)
                    models.CurMDSDDAT.LAMUCDICHCHINH = true;
                else
                    models.CurMDSDDAT.LAMUCDICHCHINH = false;
                if (models.CurMDSDDAT._SUDUNGCHUNG == true)
                    models.CurMDSDDAT.SUDUNGCHUNG = 1;
                else
                    models.CurMDSDDAT.SUDUNGCHUNG = 0;
                models.CurMDSDDAT.TenMDSD = TenMDSD;
                models.CurMDSDDAT.DSViTriMDSD = new List<DC_VITRITHUADAT>();
                List<DC_NGUONGOCSUDUNG> lstnguon = new List<DC_NGUONGOCSUDUNG>();
                foreach(var a in models.CurMDSDDAT.NguonID)
                {
                    DC_NGUONGOCSUDUNG nguon = new DC_NGUONGOCSUDUNG();
                    nguon.NGUONGOCSUDUNGID = Guid.NewGuid().ToString();
                    nguon.MUCDICHSUDUNGDATID = models.CurMDSDDAT.MUCDICHSUDUNGDATID;
                    nguon.LOAINGUONGOCSUDUNGID = a;
                    lstnguon.Add(nguon);
                }
                models.CurMDSDDAT.NGSDDats = lstnguon;
                models.CurMDSDDAT.NGUONGOCSDTH = GetLoaiNguonGocToString(models.CurMDSDDAT.NguonID);
                thuamoi.DSMucDichSuDungDat.Add(models.CurMDSDDAT);
            }
            else
            {
                foreach(var item in thuamoi.DSMucDichSuDungDat)
                {
                    if (item.MUCDICHSUDUNGDATID == models.CurMDSDDAT.MUCDICHSUDUNGDATID)
                    {
                        item.MUCDICHSUDUNGID = models.CurMDSDDAT.MUCDICHSUDUNGID;
                        item.MUCDICHSUDUNGQHID = models.CurMDSDDAT.MUCDICHSUDUNGQHID;
                        item.HINHTHUCSUDUNGID = models.CurMDSDDAT.HINHTHUCSUDUNGID;
                        item.DIENTICH = models.CurMDSDDAT.DIENTICH;
                        item.DIENTICHKHONGPHAINOPTIEN = models.CurMDSDDAT.DIENTICHKHONGPHAINOPTIEN;
                        item.DIENTICHPHAINOPTIEN = models.CurMDSDDAT.DIENTICHPHAINOPTIEN;
                        item.LOAITHOIHANSUDUNG = models.CurMDSDDAT.LOAITHOIHANSUDUNG;
                        if (models.CurMDSDDAT.LOAITHOIHANSUDUNG == "0")
                        {
                            item.THOIHANSUDUNG = "Lâu dài";
                        }
                        else
                        {
                            item.TUNGAY = models.CurMDSDDAT.TUNGAY;
                            item.DENNGAY = models.CurMDSDDAT.DENNGAY;
                            if (item.TUNGAY == null)
                            {
                                item.THOIHANSUDUNG = " đến ngày " + item.DENNGAY.Value.ToString("dd/MM/yyyy");
                            }
                            if (item.DENNGAY == null)
                            {
                                item.THOIHANSUDUNG = "Từ ngày " + item.TUNGAY.Value.ToString("dd/MM/yyyy");
                            }
                            if (item.TUNGAY != null && item.DENNGAY != null)
                            {
                                item.THOIHANSUDUNG = "Từ ngày " + item.TUNGAY.Value.ToString("dd/MM/yyyy") + " đến ngày " + item.DENNGAY.Value.ToString("dd/MM/yyyy");
                            }
                        }
                        item._LAMUCDICHCHINH = models.CurMDSDDAT._LAMUCDICHCHINH;
                        item._SUDUNGCHUNG = models.CurMDSDDAT._SUDUNGCHUNG;
                        if (item._LAMUCDICHCHINH == true)
                            item.LAMUCDICHCHINH = true;
                        else
                            item.LAMUCDICHCHINH = false;
                        if (item._SUDUNGCHUNG == true)
                            item.SUDUNGCHUNG = 1;
                        else
                            item.SUDUNGCHUNG = 0;
                        item.NguonID = models.CurMDSDDAT.NguonID;
                        item.NGUONGOCSDTH = GetLoaiNguonGocToString(item.NguonID);
                        item.NGSDDats = new List<DC_NGUONGOCSUDUNG>();
                        if(item.NguonID !=null)
                        foreach (var a in item.NguonID)
                        {
                            DC_NGUONGOCSUDUNG nguon = new DC_NGUONGOCSUDUNG();
                            nguon.NGUONGOCSUDUNGID = Guid.NewGuid().ToString();
                            nguon.MUCDICHSUDUNGDATID = item.MUCDICHSUDUNGDATID;
                            nguon.LOAINGUONGOCSUDUNGID = a;
                            item.NGSDDats.Add(nguon);
                        }
                        item.TenMDSD = TenMDSD;
                        break;
                    }
                }
            }
          thuamoi=  getMDSDtoString(thuamoi);
        }
        public static void ThemHanChe(DC_THUADAT models, DC_THUADAT thuamoi)
        {
            if (models.CurHanChe.HANCHEID == null || models.CurHanChe.HANCHEID == "")
            {
                models.CurHanChe.THUADATID = thuamoi.THUADATID;
                models.CurHanChe.HANCHEID = Guid.NewGuid().ToString();
                if (models.CurHanChe._ConHieuLuc == true)
                {
                    models.CurHanChe.CONHIEULUC = "Y";
                }
                else
                {
                    models.CurHanChe.CONHIEULUC = "N";
                }
                if (models.CurHanChe._HanCheMotPhan == true)
                {
                    models.CurHanChe.HANCHEMOTPHAN = "Y";
                }
                else
                {
                    models.CurHanChe.HANCHEMOTPHAN = "N";
                }
                thuamoi.DSHanCheThua.Add(models.CurHanChe);
            }
            else
            {
                foreach(var item in thuamoi.DSHanCheThua)
                {
                    if (item.HANCHEID == models.CurHanChe.HANCHEID)
                    {
                        item.LOAIHANCHEID = models.CurHanChe.LOAIHANCHEID;
                        item.NOIDUNGHANCHE = models.CurHanChe.NOIDUNGHANCHE; ;
                        item.COQUANBANHANH = models.CurHanChe.COQUANBANHANH;
                        item.SOVANBAN = models.CurHanChe.SOVANBAN;
                        item.NGAYBANHANH = models.CurHanChe.NGAYBANHANH;
                        item.DIENTICH = models.CurHanChe.DIENTICH;
                        item.SODORANHGIOIHANCHE = models.CurHanChe.SODORANHGIOIHANCHE;
                        item._ConHieuLuc = models.CurHanChe._ConHieuLuc;
                        if (models.CurHanChe._ConHieuLuc == true)
                        {
                            item.CONHIEULUC = "Y";
                            if (item.NGAYHETHIEULUC != null)
                            {
                                item.NGAYHETHIEULUC = null;
                            }
                        }
                        else
                        {
                            item.CONHIEULUC = "N";
                                item.NGAYHETHIEULUC = DateTime.Now;
                        }
                        if (models.CurHanChe._HanCheMotPhan == true)
                        {
                            item.HANCHEMOTPHAN = "Y";
                        }
                        else
                        {
                            item.HANCHEMOTPHAN = "N";
                        }
                        break;
                    }
                }
            }
            decimal ttTanhChap = 0;
            foreach (var item in thuamoi.DSHanCheThua)
            {
                if (item == null)
                {
                    thuamoi._DANGTRANHCHAP = false;
                    thuamoi.DANGTRANHCHAP = "N";
                }
                else
                {
                    if (item._ConHieuLuc == true)
                        ttTanhChap = ttTanhChap + 1;
                }
            }
            if (ttTanhChap == 0)
            {
                thuamoi._DANGTRANHCHAP = false;
                thuamoi.DANGTRANHCHAP = "N";
            }
            else
            {
                thuamoi._DANGTRANHCHAP = true;
                thuamoi.DANGTRANHCHAP = "Y";
            }
        }
        public static void ThemGiaDat(DC_THUADAT models, DC_THUADAT thuamoi)
        {
            if (models.CurGiaDat.GIATHUADATID == null || models.CurGiaDat.GIATHUADATID == "")
            {
                models.CurGiaDat.THUADATID = thuamoi.THUADATID;
                models.CurGiaDat.GIATHUADATID = Guid.NewGuid().ToString();
                thuamoi.DSGiaDat.Add(models.CurGiaDat);
            }
            else
            {
                foreach(var item in thuamoi.DSGiaDat)
                {
                    if (item.GIATHUADATID == models.CurGiaDat.GIATHUADATID)
                    {
                        item.LOAIGIADATID = models.CurGiaDat.LOAIGIADATID;
                        item.CANCUPHAPLY = models.CurGiaDat.CANCUPHAPLY;
                        item.THOIDIEMXACDINH = models.CurGiaDat.THOIDIEMXACDINH;
                        item.GIADAT = models.CurGiaDat.GIADAT;
                        item.TENFILE = models.CurGiaDat.TENFILE;
                        break;
                    }
                }
            }
        }
        public static void ThemViTri(DC_THUADAT models, DC_THUADAT thuamoi)
        {
            var mdsd = (from item in thuamoi.DSMucDichSuDungDat where item.MUCDICHSUDUNGDATID == models.CurViTri.MUCDICHSUDUNGDATID select item).FirstOrDefault();
            DC_VITRITHUADAT vitri = new DC_VITRITHUADAT();
            if(models.CurViTri.VITRIID == null || models.CurViTri.VITRIID == "")
            {
                models.CurViTri.VITRIID = Guid.NewGuid().ToString();
                mdsd.DSViTriMDSD.Add(models.CurViTri);
            }
            else
            {
                foreach(var item in mdsd.DSViTriMDSD)
                {
                    if (item.VITRIID == models.CurViTri.VITRIID)
                    {
                        item.DUONG = models.CurViTri.DUONG;
                        item.DOANDUONG = models.CurViTri.DOANDUONG;
                        item.KHUVUC = models.CurViTri.KHUVUC;
                        item.VITRI = models.CurViTri.VITRI;
                        item.CHIEUSAU = models.CurViTri.CHIEUSAU;
                        item.CHIEURONGNGOHEM = models.CurViTri.CHIEURONGNGOHEM;
                    }
                }
            }
            thuamoi.DSViTri = mdsd.DSViTriMDSD;
        }
        public static DC_THUADAT getMDSDtoString(DC_THUADAT thua)
        {
            using(MplisEntities db=new MplisEntities())
            {
                string str = "";
                if (thua.DSMucDichSuDungDat != null && thua.DSMucDichSuDungDat.Count > 0)
                {
                    foreach (var mdsd in thua.DSMucDichSuDungDat)
                    {
                        var MaMDSD = (from a in db.DM_MUCDICHSUDUNG where a.MUCDICHSUDUNGID == mdsd.MUCDICHSUDUNGID select a).FirstOrDefault();
                        str += MaMDSD.MAMUCDICHSUDUNG + " ,";
                    }
                    if (str.Length > 0) str = str.Substring(0, str.Length - 2);

                }
                thua.DSMucDichSuDungDatToString = str;
            }
            return thua;
        }
        public static HC_DMKVHC getXa(string xaID)
        {
            HC_DMKVHC xa = new HC_DMKVHC();
            using(MplisEntities db=new MplisEntities())
            {
                xa = (from a in db.HC_DMKVHC where a.KVHCID == xaID select a).FirstOrDefault();
            }
            return xa;
        }
        public static string GetLoaiNguonGocToString(List<string> nguonID)
        {
            string str = "";
            using (MplisEntities db = new MplisEntities())
            {
                if (nguonID != null )
                {
                    foreach (var nguon in nguonID)
                    {
                        var loainguon = (from a in db.DM_LOAINGUONGOCSUDUNG where a.LOAINGUONGOCSUDUNGID == nguon select a).FirstOrDefault();
                        if (loainguon != null)
                            str += loainguon.TENNGUONGOCSUDUNG + ", ";
                    }
                    if (str.Length > 0) str = str.Substring(0, str.Length - 2);

                }
            }
            return str;
        }
        public static void ThemThua(DC_THUADAT models,DC_THUADAT thuamoi,BoHoSoModel bhs)
        {
            if (models._TRONGDANGKY == 1)
            {
                foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyThua)
                {
                    if (item.THUADATID == models.THUADATID)
                    {
                        item.DiaChi = models.DIACHITHUADAT;
                        if (models.DIENTICHPHAPLY != null)
                        {
                            item.DienTich = (decimal)models.DIENTICHPHAPLY;
                        }
                        item.mdsd = thuamoi.DSMucDichSuDungDatToString;
                        if (models.SOHIEUTOBANDO != null)
                        {
                            item.SHToBanDo = (decimal)models.SOHIEUTOBANDO;
                        }
                        item.SOHIEUTOBANDO = models.SOHIEUTOBANDO;
                        item.SOTHUTHUTHUA = models.SOTHUTUTHUA;
                        if (models.SOTHUTUTHUA != null)
                        {
                            item.STTThua = (decimal)models.SOTHUTUTHUA;
                        }
                        item.XAID = models.XAID;
                        if (item.TRANGTHAITHUA != "1")
                        {
                            item.TRANGTHAITHUA = "2";
                        }
                        Mapper.Map<DC_THUADAT, DC_THUADAT>(thuamoi, item.Thua);
                        item.Thua.DIENTICH = models.DIENTICH;
                        item.Thua.DIENTICHPHAPLY = models.DIENTICHPHAPLY;
                        item.Thua.SOHIEUTOBANDO = models.SOHIEUTOBANDO;
                        item.Thua.SOTHUTUTHUA = models.SOTHUTUTHUA;
                        item.Thua.TENTAILIEUDD = models.TENTAILIEUDD;
                        item.Thua.LOAITHUADAT = models.LOAITHUADAT;
                        item.Thua.DIACHITHUADAT = models.DIACHITHUADAT;
                        item.Thua.XAID = models.XAID;
                        item.Thua.DUONG = models.DUONG;
                        item.Thua.DOANDUONGID = models.DOANDUONGID;
                        item.Thua.KHUVUCID = models.KHUVUCID;
                        item.Thua._LADOITUONGCHIEMDAT = models._LADOITUONGCHIEMDAT;
                        if (models._LADOITUONGCHIEMDAT == true)
                        {
                            item.Thua.LADOITUONGCHIEMDAT = 1;
                        }
                        else
                        {
                            item.Thua.LADOITUONGCHIEMDAT = 0;
                        }
                        item.Thua.Xa = DCTHUADATServices.getXa(item.XAID);
                        item.TenXaPhuong = item.Thua.Xa.TENKVHC;
                        break;
                    }
                }
            }
            else
            {
                models._DACAPQUYEN = DCTHUADATServices.checkGCN(thuamoi);
                    var thuatimkiem = (from a in bhs.HoSoTN.DonDangKy.DSDangKyThua where a.SOHIEUTOBANDO == models.SOHIEUTOBANDO && a.SOTHUTHUTHUA == models.SOTHUTUTHUA && a.XAID == models.XAID && a.THUADATID == models.THUADATID select a).FirstOrDefault();
                    if (thuatimkiem == null)
                    {
                        DC_THUADAT themthua = new DC_THUADAT();
                        Mapper.Map<DC_THUADAT, DC_THUADAT>(thuamoi, themthua);
                        themthua.DIENTICH = models.DIENTICH;
                        themthua.DIENTICHPHAPLY = models.DIENTICHPHAPLY;
                        themthua.SOHIEUTOBANDO = models.SOHIEUTOBANDO;
                        themthua.SOTHUTUTHUA = models.SOTHUTUTHUA;
                        themthua.TENTAILIEUDD = models.TENTAILIEUDD;
                        themthua.LOAITHUADAT = models.LOAITHUADAT;
                        themthua.DIACHITHUADAT = models.DIACHITHUADAT;
                        themthua._DACAPQUYEN = models._DACAPQUYEN;
                        themthua.KHUVUCID = models.KHUVUCID;
                        themthua.DOANDUONGID = models.DOANDUONGID;
                        themthua.DUONG = models.DUONG;
                        themthua.XAID = models.XAID;
                        themthua._LADOITUONGCHIEMDAT = models._LADOITUONGCHIEMDAT;
                        if (models._LADOITUONGCHIEMDAT == true)
                        {
                            themthua.LADOITUONGCHIEMDAT = 1;
                        }
                        else
                        {
                            themthua.LADOITUONGCHIEMDAT = 0;
                        }
                        themthua.Xa = DCTHUADATServices.getXa(models.XAID);
                        DC_DANGKY_THUA thuadk = new DC_DANGKY_THUA();
                        thuadk.DANGKYTHUAID = Guid.NewGuid().ToString();
                        thuadk.DiaChi = themthua.DIACHITHUADAT;
                        if (themthua.DIENTICHPHAPLY != null)
                        {
                            thuadk.DienTich = (decimal)themthua.DIENTICHPHAPLY;
                        }
                        thuadk.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
                        thuadk.mdsd = themthua.DSMucDichSuDungDatToString;
                        thuadk.THUADATID = themthua.THUADATID;
                        if (themthua.SOHIEUTOBANDO != null)
                        {
                            thuadk.SHToBanDo = (decimal)themthua.SOHIEUTOBANDO;
                        }
                        thuadk.SOHIEUTOBANDO = themthua.SOHIEUTOBANDO;
                        if (themthua.SOTHUTUTHUA != null)
                        {
                            thuadk.STTThua = (decimal)themthua.SOTHUTUTHUA;
                        }
                        thuadk.SOTHUTHUTHUA = themthua.SOTHUTUTHUA;
                        thuadk.Thua = themthua;
                        thuadk.XAID = themthua.XAID;
                        thuadk.TenXaPhuong = themthua.Xa.TENKVHC;
                        thuadk.TRANGTHAITHUA = "1";
                        bhs.HoSoTN.DonDangKy.DSDangKyThua.Add(thuadk);
                    }
                    else
                    {
                        foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyThua)
                        {
                            if (item.XAID == models.XAID && item.SOHIEUTOBANDO == models.SOHIEUTOBANDO && item.SOTHUTHUTHUA == models.SOTHUTUTHUA)
                            {
                                item.DiaChi = models.DIACHITHUADAT;
                                if (models.DIENTICHPHAPLY != null)
                                {
                                    item.DienTich = (decimal)models.DIENTICHPHAPLY;
                                }
                                item.mdsd = thuamoi.DSMucDichSuDungDatToString;
                                if (models.SOHIEUTOBANDO != null)
                                {
                                    item.SHToBanDo = (decimal)models.SOHIEUTOBANDO;
                                }
                                item.SOHIEUTOBANDO = models.SOHIEUTOBANDO;
                                item.SOTHUTHUTHUA = models.SOTHUTUTHUA;
                                if (models.SOTHUTUTHUA != null)
                                {
                                    item.STTThua = (decimal)models.SOTHUTUTHUA;
                                }
                                item.XAID = models.XAID;
                                if (item.TRANGTHAITHUA != "1")
                                {
                                    item.TRANGTHAITHUA = "2";
                                }
                                Mapper.Map<DC_THUADAT, DC_THUADAT>(thuamoi, item.Thua);
                                item.Thua.THUADATID = item.THUADATID;
                                item.Thua.DIENTICH = models.DIENTICH;
                                item.Thua.DIENTICHPHAPLY = models.DIENTICHPHAPLY;
                                item.Thua.SOHIEUTOBANDO = models.SOHIEUTOBANDO;
                                item.Thua.SOTHUTUTHUA = models.SOTHUTUTHUA;
                                item.Thua.TENTAILIEUDD = models.TENTAILIEUDD;
                                item.Thua.LOAITHUADAT = models.LOAITHUADAT;
                                item.Thua.DIACHITHUADAT = models.DIACHITHUADAT;
                                item.Thua.DUONG = models.DUONG;
                                item.Thua.DOANDUONGID = models.DOANDUONGID;
                                item.Thua.KHUVUCID = models.KHUVUCID;
                                item.Thua._LADOITUONGCHIEMDAT = models._LADOITUONGCHIEMDAT;
                                if (models._LADOITUONGCHIEMDAT == true)
                                {
                                    item.Thua.LADOITUONGCHIEMDAT = 1;
                                }
                                else
                                {
                                    item.Thua.LADOITUONGCHIEMDAT = 0;
                                }
                                item.Thua.XAID = models.XAID;
                                break;
                            }
                        }
                    }

            }
        }
        public static List<DC_LOAIHANCHE> get_Loaihanche()
        {
            List<DC_LOAIHANCHE> lsthanche = new List<DC_LOAIHANCHE>();

            using (MplisEntities db = new MplisEntities())
            {
                lsthanche = (from t1 in db.DC_LOAIHANCHE
                                       select t1).OrderBy(a => a.TENLOAIHANCHE).ToList();
            }

            return lsthanche;
        }
        public static List<DC_TENDUONG> get_listduong(string xaid)
        {
            List<DC_TENDUONG> lstduong = new List<DC_TENDUONG>();

            using (MplisEntities db = new MplisEntities())
            {
                var xa = (from t in db.HC_DMKVHC where t.KVHCID == xaid select t).FirstOrDefault();
                lstduong = (from t1 in db.DC_TENDUONG
                             select t1).OrderBy(a => a.TENDUONG).ToList();
            }

            return lstduong;
        }
        public static List<DC_KHUVUC> get_listkhuvuc(string xaid)
        {
            List<DC_KHUVUC> lstkhuvuc = new List<DC_KHUVUC>();

            using (MplisEntities db = new MplisEntities())
            {
                lstkhuvuc = (from t1 in db.DC_KHUVUC where t1.XAID==xaid
                            select t1).OrderBy(a => a.TENKHUVUC).ToList();
            }

            return lstkhuvuc;
        }
        public static List<DM_HINHTHUCSUDUNGDAT> get_Loaihinhthuc()
        {
            List<DM_HINHTHUCSUDUNGDAT> lsthinhthuc = new List<DM_HINHTHUCSUDUNGDAT>();

            using (MplisEntities db = new MplisEntities())
            {
                lsthinhthuc = (from t1 in db.DM_HINHTHUCSUDUNGDAT
                             select t1).OrderBy(a => a.TENHINHTHUCSUDUNG).ToList();
            }

            return lsthinhthuc;
        }
        public static List<DC_DOANDUONG> get_listdoanduong(string duongid)
        {
            List<DC_DOANDUONG> lstdoanduong = new List<DC_DOANDUONG>();

            using (MplisEntities db = new MplisEntities())
            {
                lstdoanduong = (from t1 in db.DC_DOANDUONG
                             where t1.TENDUONGID == duongid
                                select t1).OrderBy(a => a.TENDOANDUONG).ToList();
            }

            return lstdoanduong;
        }
        public static string get_duongbydoanduong(string doanduongid)
        {
            DC_TENDUONG duong = new DC_TENDUONG();
            using (MplisEntities db = new MplisEntities())
            {
                duong = (from t1 in db.DC_TENDUONG
                                where t1.TENDUONGID == doanduongid
                         select t1).FirstOrDefault();
            }
            return duong.TENDUONGID;
        }

    }
}