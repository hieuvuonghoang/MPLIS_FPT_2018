using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;
using MPLIS.Libraries.Data.XuLyHoSo.Models;
using System.Data.Entity;
namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCDONDANGKYServices
    {
        public static int _loaddondangky = 0;
        public static void setloaddatadondangky(int abc)
        {
            _loaddondangky = abc;
        }
        public static int getsetloaddatadondangky()
        {
            return _loaddondangky;
        }
        #region "Lấy toàn bộ dữ liệu cho đơn đăng ký"
        public static DC_DONDANGKY getDonDangKyByDonDangKyID(string DonDangKyid)
        {
            DC_DONDANGKY ret;

            ret = getDonDangKy(DonDangKyid, false);
            ret = initInnerData(ret);

            return ret;
        }

        public static DC_DONDANGKY getDonDangKyByHoSoTiepNhanID(string HoSoTiepNhanid)
        {
            DC_DONDANGKY ret;

            ret = getDonDangKy(HoSoTiepNhanid, true);
            ret = initInnerData(ret);

            return ret;
        }

        private static DC_DONDANGKY initInnerData(DC_DONDANGKY ret)
        {
            if (ret == null) return null;
            //khởi tạo thông tin cho giấy chứng nhận
            foreach (var gcn in ret.DSDangKyGCN)
            {
                gcn.GiayChungNhan = DCGIAYCHUNGNHANServices.getGiayChungNhan(gcn.GIAYCHUNGNHANID);
            }

            //khởi tạo thông tin cho chủ
            foreach (var ch in ret.DSDangKyChu)
            {
                ch.Chu = DCNGUOIServices.getChu(ch.NGUOIID);
            }

            //khởi tạo thông tin cho thua
            foreach (var th in ret.DSDangKyThua)
            {
                th.Thua = DCTHUADATServices.getThuaDat(th.THUADATID);
            }

            //khởi tạo thông tin cho tài sản
            foreach (var ts in ret.DSDangKyTaiSan)
            {
                ts.TaiSanGanLienVoiDat = DCTAISANGANLIENVOIDATServices.getTaiSanGanLienVoiDatByTaiSanID(ts.TAISANID);
                //ts.TaiSanGanLienVoiDat = DCTAISANGANLIENVOIDATServices.GetTaiSanGanLienVoiDat(ts.TAISANID);
            }

            //khởi tạo thông tin cho xác nhận đơn đăng ký
            //using (MplisEntities db = new MplisEntities())
            //{
            //    foreach (var xn in ret.DSXacNhan)
            //    {
            //        xn.DSYKienXacNhan = (from yk in db.DC_YKIENXACNHAN
            //                             where yk.XACNHANDONDANGKYID.Equals(xn.XACNHANDONDANGKYID)
            //                             select yk).ToList();
            //    }
            //}

            ret.isInitData = true;

            return ret;
        }

        //isHoSoID == true get theo HOSOTIEPNHANID, ngược lại get theo DONDANGKYID
        private static DC_DONDANGKY getDonDangKy(string id, bool isHoSoID)
        {
            DC_DONDANGKY ret = null;
            using (MplisEntities db = new MplisEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;
                if (isHoSoID)
                {
                    var retVal = (from don in db.DC_DONDANGKY
                                  where don.HOSOTIEPNHANID.Equals(id)
                                  select new
                                  {
                                      don,
                                      GCNs = db.DC_DANGKY_GCN.Where(i => i.DONDANGKYID.Equals(don.DONDANGKYID)),
                                      CHUs = db.DC_DANGKY_NGUOI.Where(i => i.DONDANGKYID.Equals(don.DONDANGKYID)),
                                      THUAs = db.DC_DANGKY_THUA.Where(i => i.DONDANGKYID.Equals(don.DONDANGKYID)),
                                      TAISANs = db.DC_DANGKY_TAISAN.Where(i => i.DONDANGKYID.Equals(don.DONDANGKYID)),
                                      XNs = db.DC_XACNHANDONDANGKY.Where(i => i.DONDANGKYID.Equals(don.DONDANGKYID))
                                      .Select(x => new
                                      {
                                          x,
                                          yk = db.DC_YKIENXACNHAN.Where(i => i.XACNHANDONDANGKYID.Equals(x.XACNHANDONDANGKYID))
                                      })
                                  }).FirstOrDefault();
                    var gcn1 = (from item in db.DC_DANGKY_GCN where item.DONDANGKYID == retVal.don.DONDANGKYID select item);
                    if (retVal != null)
                    {
                        ret = retVal.don;
                        ret.DSDangKyGCN = gcn1.ToList();
                        ret.DSDangKyChu = retVal.CHUs.ToList();
                        ret.DSDangKyThua = retVal.THUAs.ToList();
                        ret.DSDangKyTaiSan = retVal.TAISANs.ToList();
                        List<DC_XACNHANDONDANGKY> xn = new List<DC_XACNHANDONDANGKY>();
                        DC_XACNHANDONDANGKY item;
                        foreach (var it in retVal.XNs)
                        {
                            item = it.x;
                            item.DSYKienXacNhan = it.yk.ToList();
                            xn.Add(item);
                        }
                        ret.DSXacNhan = xn;
                        ret.isInitData = true;
                    }
                }
                else
                {
                    var retVal = (from don in db.DC_DONDANGKY
                                  where don.DONDANGKYID.Equals(id)
                                  select new
                                  {
                                      don,
                                      GCNs = db.DC_DANGKY_GCN.Where(i => i.DONDANGKYID.Equals(don.DONDANGKYID)),
                                      CHUs = db.DC_DANGKY_NGUOI.Where(i => i.DONDANGKYID.Equals(don.DONDANGKYID)),
                                      THUAs = db.DC_DANGKY_THUA.Where(i => i.DONDANGKYID.Equals(don.DONDANGKYID)),
                                      TAISANs = db.DC_DANGKY_TAISAN.Where(i => i.DONDANGKYID.Equals(don.DONDANGKYID)),
                                      XNs = db.DC_XACNHANDONDANGKY.Where(i => i.DONDANGKYID.Equals(don.DONDANGKYID))
                                      .Select(x => new
                                      {
                                          x,
                                          yk = db.DC_YKIENXACNHAN.Where(i => i.XACNHANDONDANGKYID.Equals(x.XACNHANDONDANGKYID))
                                      })
                                  }).FirstOrDefault();

                    if (retVal != null)
                    {
                        ret = retVal.don;
                        ret.DSDangKyGCN = retVal.GCNs.ToList();
                        ret.DSDangKyChu = retVal.CHUs.ToList();
                        ret.DSDangKyThua = retVal.THUAs.ToList();
                        ret.DSDangKyTaiSan = retVal.TAISANs.ToList();
                        List<DC_XACNHANDONDANGKY> xn = new List<DC_XACNHANDONDANGKY>();
                        DC_XACNHANDONDANGKY item;
                        foreach (var it in retVal.XNs)
                        {
                            item = it.x;
                            item.DSYKienXacNhan = it.yk.ToList();
                            xn.Add(item);
                        }
                        ret.DSXacNhan = xn;
                        ret.isInitData = true;
                    }
                }
            }

            return ret;
        }
        public static DC_DONDANGKY update_HSTN_DonDangky(DC_DONDANGKY objhstn)
        {
            #region update thoong tin chu
            if (objhstn != null)
            {
                if (objhstn.DSDangKyChu != null) objhstn = updateDSChu(objhstn);
                if (objhstn.DSDangKyGCN != null) objhstn = updateDSGCN(objhstn);
                if (objhstn.DSDangKyThua != null) objhstn = updateDSThua(objhstn);



            }
            #endregion
            return objhstn;
        }
        #endregion

        public static bool saveAll(DC_DONDANGKY bd)
        {
            throw new NotImplementedException();
        }

        public static void updateTTDonDangKy(DC_DONDANGKY DonDK)
        {
            if (DonDK == null) return;
            updateDSChu(DonDK);
            updateDSGCN(DonDK);
            updateDSThua(DonDK);
            updateDSTaiSan(DonDK);
        }

        public static DC_DONDANGKY updateDSChu(DC_DONDANGKY objhstn)
        {
            #region update thoong tin chu
            if (objhstn.DSDangKyChu.Count > 0)
            {
                foreach (var it in objhstn.DSDangKyChu)
                {
                    switch (it.Chu.LOAIDOITUONGID)
                    {
                        case "1":
                            it.Chu_TenLoaiChu = "Cá nhân";
                            if (it.Chu.CaNhan != null)
                            {
                                it.Chu_HoTen = it.Chu.CaNhan.HOTEN;
                                it.Chu_DiaChi = it.Chu.CaNhan.DIACHI;
                                if (it.Chu.CaNhan.DSGiayToTuyThan != null && it.Chu.CaNhan.DSGiayToTuyThan.Count > 0 && it.Chu.CaNhan.DSGiayToTuyThan[0] != null)
                                    it.Chu_CMT = it.Chu.CaNhan.DSGiayToTuyThan[0].SOGIAYTO;
                            }
                            break;
                        case "2":
                            it.Chu_TenLoaiChu = "Hộ gia đình";
                            if (it.Chu.HoGiaDinh.DSThanhVien != null)
                            {
                                it.Chu_DiaChi = it.Chu.HoGiaDinh.DIACHI;
                                it.Chu_HoTen = "";
                                it.Chu_CMT = "";
                                foreach (var hgd in it.Chu.HoGiaDinh.DSThanhVien)
                                {
                                    it.Chu_HoTen += hgd.ThanhVien.HOTEN + ", ";
                                    it.Chu_CMT += hgd.ThanhVien.SOGIAYTO + ",";
                                }
                                if (it.Chu_HoTen != "")
                                {
                                    it.Chu_HoTen = it.Chu_HoTen.Substring(0, it.Chu_HoTen.Length - 2);
                                }
                                if (it.Chu_CMT != "")
                                {
                                    it.Chu_CMT = it.Chu_CMT.Substring(0, it.Chu_CMT.Length - 2);
                                }
                            }
                            break;
                        case "3":
                            it.Chu_TenLoaiChu = "Vợ chồng";
                            if (it.Chu.VoChong != null)
                            {
                                it.Chu_HoTen += it.Chu.VoChong.VoCN.HOTEN + ", " + it.Chu.VoChong.ChongCN.HOTEN;
                                it.Chu_DiaChi = it.Chu.VoChong.DIACHI;
                                if (it.Chu.VoChong.VoCN.DSGiayToTuyThan != null && it.Chu.VoChong.VoCN.DSGiayToTuyThan.Count > 0 && it.Chu.VoChong.VoCN.DSGiayToTuyThan[0] != null)
                                    it.Chu_CMT += it.Chu.VoChong.VoCN.DSGiayToTuyThan[0].SOGIAYTO + ", ";
                                if (it.Chu.VoChong.ChongCN.DSGiayToTuyThan != null && it.Chu.VoChong.ChongCN.DSGiayToTuyThan.Count > 0 && it.Chu.VoChong.ChongCN.DSGiayToTuyThan[0] != null)
                                    it.Chu_CMT += it.Chu.VoChong.ChongCN.DSGiayToTuyThan[0].SOGIAYTO;
                            }
                            break;
                        case "5":
                            it.Chu_TenLoaiChu = "Cộng đồng";
                            if (it.Chu.CongDong != null)
                            {
                                it.Chu_DiaChi = it.Chu.CongDong.DIACHI;
                                if (it.Chu.CongDong.NguoiDaiDien != null)
                                {
                                    it.Chu_HoTen = it.Chu.CongDong.NguoiDaiDien.HOTEN;
                                    if (it.Chu.CongDong.NguoiDaiDien.DSGiayToTuyThan != null && it.Chu.CongDong.NguoiDaiDien.DSGiayToTuyThan.Count > 0 && it.Chu.CongDong.NguoiDaiDien.DSGiayToTuyThan[0] != null)
                                        it.Chu_CMT = it.Chu.CongDong.NguoiDaiDien.DSGiayToTuyThan[0].SOGIAYTO;
                                }
                            }
                            break;
                        case "4":
                            it.Chu_TenLoaiChu = "Tổ Chức";
                            if (it.Chu.ToChuc != null)
                            {
                                it.Chu_DiaChi = it.Chu.ToChuc.DIACHI;
                                if (it.Chu.ToChuc.NguoiDaiDien != null)
                                {
                                    // it.Chu_HoTen += it.Chu.ToChuc.NguoiDaiDien.HOTEN;
                                    it.Chu_HoTen += it.Chu.ToChuc.TENTOCHUC;
                                    //if (it.Chu.ToChuc.NguoiDaiDien.DSGiayToTuyThan != null && it.Chu.ToChuc.NguoiDaiDien.DSGiayToTuyThan.Count > 0 && it.Chu.ToChuc.NguoiDaiDien.DSGiayToTuyThan[0] != null)
                                    //    it.Chu_CMT = it.Chu.ToChuc.NguoiDaiDien.DSGiayToTuyThan[0].SOGIAYTO;
                                    it.Chu_CMT = it.Chu.ToChuc.SOQUYETDINH;
                                }
                            }
                            break;
                        case "6":
                            it.Chu_TenLoaiChu = "Nhóm người";
                            if (it.Chu.NhomNguoi != null)
                            {
                                it.Chu_DiaChi = "";//không có địa chỉ
                                                   //if (it.Chu.NhomNguoi.DSThanhVien != null)
                                                   //{
                                                   //    foreach (var nn in it.Chu.NhomNguoi.DSThanhVien)
                                                   //    {
                                                   //        if (nn.ThanhVien != null)
                                                   //        {
                                                   //            it.Chu_HoTen += nn.ThanhVien.HOTEN + ", ";
                                                   //        }
                                                   //    }
                                                   //}
                                if (it.Chu.NhomNguoi.NGUOIDAIDIEN != null)
                                {
                                    //foreach (var nn in it.Chu.NhomNguoi.DSThanhVien)
                                    //{
                                    using (MplisEntities dbo = new MplisEntities())
                                    {
                                        var objcanhan = (from item in dbo.DC_CANHAN where item.CANHANID == it.Chu.NhomNguoi.NGUOIDAIDIEN select item).FirstOrDefault();
                                        if (objcanhan != null)
                                        {
                                            it.Chu_HoTen = objcanhan.HODEM + " " + objcanhan.TEN;
                                            it.Chu_CMT = objcanhan.SOGIAYTO;
                                        }
                                    }


                                    //}
                                }
                                // it.Chu_CMT = "";//không biết lấy từ đâu
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion
            return objhstn;
        }

        public static DC_DONDANGKY updateDSGCN(DC_DONDANGKY objhstn)
        {
            #region update thoong tin gcn
            if (objhstn.DSDangKyGCN.Count > 0)
            {
                foreach (var it in objhstn.DSDangKyGCN)
                {
                    it.SoPhatHanh = it.GiayChungNhan.SOPHATHANH;
                    it.MaVach = it.GiayChungNhan.MAVACH;
                    it.TrangThai = it.GiayChungNhan.TRANGTHAIXULY;
                }
            }
            #endregion
            return objhstn;
        }

        public static DC_DONDANGKY updateDSThua(DC_DONDANGKY objhstn)
        {
            #region update thoong tin thua
            if (objhstn.DSDangKyThua.Count > 0)
            {
                foreach (var it in objhstn.DSDangKyThua)
                {
                    it.XaPhuong = it.Thua.XAID;
                    it.DiaChi = it.Thua.DIACHITHUADAT;
                    it.SHToBanDo = (decimal)it.Thua.SOHIEUTOBANDO;
                    it.STTThua = (decimal)it.Thua.SOTHUTUTHUA;
                    if(it.Thua.DIENTICHPHAPLY!=null)
                    it.DienTich = (decimal)it.Thua.DIENTICHPHAPLY;
                    //load tên xã
                    using (MplisEntities db = new MplisEntities())
                    {
                        var objhcxa = (from item in db.HC_DMKVHC where item.KVHCID == it.Thua.XAID select item).FirstOrDefault();
                        if (objhcxa != null)
                        {
                            it.TenXaPhuong = objhcxa.TENKVHC;
                        }
                        var objmdsd = (from item in db.DC_MUCDICHSUDUNGDAT.Where(a => a.THUADATID == it.THUADATID)
                                       select new
                                       {
                                           item,
                                           tenmdsd = (from mdsd in db.DM_MUCDICHSUDUNG.Where(b => b.MUCDICHSUDUNGID == item.MUCDICHSUDUNGID) select mdsd).FirstOrDefault()
                                       });
                        //if (objmdsd != null)
                        //{
                        //    it.mdsd = objmdsd.tenmdsd;
                        //}
                        foreach (var item in objmdsd)
                        {
                            it.mdsd += item.tenmdsd.MAMUCDICHSUDUNG + ", ";
                        }
                        if (it.mdsd != null)
                        {
                            it.mdsd = it.mdsd.Substring(0, it.mdsd.Length - 2);
                        }
                    }
                }
            }
            #endregion
            return objhstn;
        }

        public static void updateDSTaiSan(DC_DONDANGKY objDonDangKy)
        {
            foreach (var objDangKyTaiSan in objDonDangKy.DSDangKyTaiSan)
            {
                if(objDangKyTaiSan.TaiSanGanLienVoiDat.LoaiTaiSanGanLienVoiDat != null)
                {
                    objDangKyTaiSan.LoaiTaiSan = objDangKyTaiSan.TaiSanGanLienVoiDat.LoaiTaiSanGanLienVoiDat.TENLOAITAISANGANLIENVOIDAT;
                }
                objDangKyTaiSan.TenTaiSan = objDangKyTaiSan.TaiSanGanLienVoiDat.TENTAISAN;
                objDangKyTaiSan.DienTich = objDangKyTaiSan.DienTich;
                switch (objDangKyTaiSan.TaiSanGanLienVoiDat != null ? objDangKyTaiSan.TaiSanGanLienVoiDat.LOAITAISAN : "")
                {
                    case "1":
                        if (objDangKyTaiSan.TaiSanGanLienVoiDat.NhaRiengLe != null)
                        {
                            objDangKyTaiSan.DienTich = objDangKyTaiSan.TaiSanGanLienVoiDat.NhaRiengLe.DIENTICHSAN;
                        }
                        break;
                    case "2":
                        if (objDangKyTaiSan.TaiSanGanLienVoiDat.KhuChungCu != null)
                        {
                            objDangKyTaiSan.DienTich = objDangKyTaiSan.TaiSanGanLienVoiDat.KhuChungCu.DIENTICHKHU;
                        }
                        break;
                    case "3":
                        if (objDangKyTaiSan.TaiSanGanLienVoiDat.NhaChungCu != null)
                        {
                            objDangKyTaiSan.DienTich = objDangKyTaiSan.TaiSanGanLienVoiDat.NhaChungCu.DIENTICHSAN;
                        }
                        break;
                    case "4":
                        if (objDangKyTaiSan.TaiSanGanLienVoiDat.CanHo != null)
                        {
                            objDangKyTaiSan.DienTich = objDangKyTaiSan.TaiSanGanLienVoiDat.CanHo.DIENTICHSAN;
                        }
                        break;
                    case "5":
                        if (objDangKyTaiSan.TaiSanGanLienVoiDat.HangMucNgoaiCanHo != null)
                        {
                            objDangKyTaiSan.DienTich = objDangKyTaiSan.TaiSanGanLienVoiDat.HangMucNgoaiCanHo.DIENTICH;
                        }
                        break;
                    case "6":
                        if (objDangKyTaiSan.TaiSanGanLienVoiDat.CongTrinhXayDung != null)
                        {
                            objDangKyTaiSan.DienTich = objDangKyTaiSan.TaiSanGanLienVoiDat.CongTrinhXayDung.DIENTICHSAN;
                        }
                        break;
                    case "7":
                        if (objDangKyTaiSan.TaiSanGanLienVoiDat.CongTrinhNgam != null)
                        {
                            objDangKyTaiSan.DienTich = objDangKyTaiSan.TaiSanGanLienVoiDat.CongTrinhNgam.DIENTICHCONGTRINH;
                        }
                        break;
                    case "8":

                        if (objDangKyTaiSan.TaiSanGanLienVoiDat.HangMucCongTrinh != null)
                        {
                            objDangKyTaiSan.DienTich = objDangKyTaiSan.TaiSanGanLienVoiDat.HangMucCongTrinh.DIENTICHSAN;
                        }
                        break;
                    case "9":
                        if (objDangKyTaiSan.TaiSanGanLienVoiDat.RungTrong != null)
                        {
                            objDangKyTaiSan.DienTich = objDangKyTaiSan.TaiSanGanLienVoiDat.RungTrong.DIENTICH;
                        }
                        break;
                    case "10":
                        if (objDangKyTaiSan.TaiSanGanLienVoiDat.CayLauNam != null)
                        {
                            objDangKyTaiSan.DienTich = objDangKyTaiSan.TaiSanGanLienVoiDat.CayLauNam.DIENTICH;
                        }
                        break;
                    default:
                        break;
                }
                switch (objDangKyTaiSan.TaiSanGanLienVoiDat != null ? objDangKyTaiSan.TaiSanGanLienVoiDat.LOAITAISAN : "")
                {
                    case "1":
                        if (objDangKyTaiSan.TaiSanGanLienVoiDat.NhaRiengLe != null)
                        {
                            objDangKyTaiSan.DienTich = objDangKyTaiSan.TaiSanGanLienVoiDat.NhaRiengLe.DIENTICHSAN;
                        }
                        break;
                    case "2":
                        break;
                    case "3":
                        if (objDangKyTaiSan.TaiSanGanLienVoiDat.NhaChungCu != null)
                        {
                            objDangKyTaiSan.DienTich = objDangKyTaiSan.TaiSanGanLienVoiDat.NhaChungCu.DIENTICHSAN;
                        }
                        break;
                    case "4":
                        if (objDangKyTaiSan.TaiSanGanLienVoiDat.CanHo != null)
                        {
                            objDangKyTaiSan.DienTich = objDangKyTaiSan.TaiSanGanLienVoiDat.CanHo.DIENTICHSAN;
                        }
                        break;
                    case "5":
                        if (objDangKyTaiSan.TaiSanGanLienVoiDat.HangMucNgoaiCanHo != null)
                        {
                            objDangKyTaiSan.DienTich = objDangKyTaiSan.TaiSanGanLienVoiDat.HangMucNgoaiCanHo.DIENTICH;
                        }
                        break;
                    case "6":
                        if (objDangKyTaiSan.TaiSanGanLienVoiDat.CongTrinhXayDung != null)
                        {
                            objDangKyTaiSan.DienTich = objDangKyTaiSan.TaiSanGanLienVoiDat.CongTrinhXayDung.DIENTICHSAN;
                        }
                        break;
                    case "7":
                        if (objDangKyTaiSan.TaiSanGanLienVoiDat.CongTrinhNgam != null)
                        {
                            objDangKyTaiSan.DienTich = objDangKyTaiSan.TaiSanGanLienVoiDat.CongTrinhNgam.DIENTICHCONGTRINH;
                        }
                        break;
                    case "8":

                        if (objDangKyTaiSan.TaiSanGanLienVoiDat.HangMucCongTrinh != null)
                        {
                            objDangKyTaiSan.DienTich = objDangKyTaiSan.TaiSanGanLienVoiDat.HangMucCongTrinh.DIENTICHSAN;
                        }
                        break;
                    case "9":
                        if (objDangKyTaiSan.TaiSanGanLienVoiDat.RungTrong != null)
                        {
                            objDangKyTaiSan.DienTich = objDangKyTaiSan.TaiSanGanLienVoiDat.RungTrong.DIENTICH;
                        }
                        break;
                    case "10":
                        if (objDangKyTaiSan.TaiSanGanLienVoiDat.CayLauNam != null)
                        {
                            objDangKyTaiSan.DienTich = objDangKyTaiSan.TaiSanGanLienVoiDat.CayLauNam.DIENTICH;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        #region V3.0
        public static bool XoaChu(string dangKyNguoiID, BoHoSoModel bhs)
        {
            DC_DANGKY_NGUOI dangKyNguoi = null;
            //Delete Session && DB
            foreach(var temp in bhs.HoSoTN.DonDangKy.DSDangKyChu)
            {
                if(temp.DANGKYNGUOIID.Equals(dangKyNguoiID)) {
                    dangKyNguoi = temp;
                    break;
                }
            }
            if(dangKyNguoi != null)
            {
                bhs.HoSoTN.DonDangKy.DSDangKyChu.Remove(dangKyNguoi);
                using(MplisEntities db = new MplisEntities())
                {
                    db.Entry(dangKyNguoi).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            return true;
        }
        #endregion
    }
}