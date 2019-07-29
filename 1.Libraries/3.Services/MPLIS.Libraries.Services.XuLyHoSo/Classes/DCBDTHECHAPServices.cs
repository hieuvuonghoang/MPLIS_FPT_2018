using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCBDTHECHAPServices
    {
        public static DC_BD_THECHAP getTheChapByBienDongID(string BienDongID)
        {
            DC_BD_THECHAP ret = null;
            using (MplisEntities db = new MplisEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;
                var retVal = (from tc in db.DC_BD_THECHAP.Where(i => i.BIENDONGID.Equals(BienDongID))
                              select new
                              {
                                  tc,
                                  SDDs = db.DC_QUYENSUDUNGDAT.Where(i => i.BDTHECHAPID.Equals(tc.BDTHECHAPID)),
                                  QTSs = db.DC_QUYENSOHUUTAISAN.Where(i => i.BDTHECHAPID.Equals(tc.BDTHECHAPID))
                              }).FirstOrDefault();
                if (retVal != null)
                {
                    ret = retVal.tc;
                    ret.DSQuyenSoHuuTaiSan = retVal.QTSs.ToList();
                    ret.DSQuyenSuDungDat = retVal.SDDs.ToList();
                }
            }

            return ret;
        }

        public static void updateTheChapByBienDongID(DC_BD_THECHAP obj)
        {
            if (obj != null)
            {
                if (obj.DSQuyenSuDungDat != null)
                    updateDSQuyenSuDungDat(obj);
                if (obj.DSQuyenSoHuuTaiSan != null)
                    updateTaiSanGanLienVoiDat(obj);
            }
        }

        public static void updateDSQuyenSuDungDat(DC_BD_THECHAP obj)
        {
            if (obj.DSQuyenSuDungDat.Count > 0)
            {
                foreach (var sdd in obj.DSQuyenSuDungDat)
                {
                    sdd.XaPhuong = sdd.Thua.XAID;
                    sdd.SHToBanDo = (decimal)sdd.Thua.SOHIEUTOBANDO;
                    sdd.STTThua = (decimal)sdd.Thua.SOTHUTUTHUA;
                    sdd.DienTich = (decimal)sdd.Thua.DIENTICH;
                    sdd.DiaChi = sdd.Thua.DIACHITHUADAT;
                }
            }
        }

        public static void updateTaiSanGanLienVoiDat(DC_BD_THECHAP obj)
        {
            #region
            if (obj.DSQuyenSoHuuTaiSan.Count > 0)
            {
                foreach (var shts_loaits in obj.DSQuyenSoHuuTaiSan)
                {
                    switch (shts_loaits.TaiSanGanLienVoiDat.LOAITAISAN)
                    {
                        case "1"://DC_NHARIENGLE
                            shts_loaits.LoaiTaiSan = "Nhà riêng lẻ";
                            shts_loaits.TenTaiSan = shts_loaits.TaiSanGanLienVoiDat.TENTAISAN;
                            shts_loaits.DienTich = (decimal)shts_loaits.TaiSanGanLienVoiDat.NhaRiengLe.DIENTICHSAN;
                            break;
                        case "2"://DC_NHACHUNGCU
                            shts_loaits.LoaiTaiSan = "Nhà chung cư";
                            shts_loaits.TenTaiSan = shts_loaits.TaiSanGanLienVoiDat.TENTAISAN;
                            shts_loaits.DienTich = (decimal)shts_loaits.TaiSanGanLienVoiDat.NhaChungCu.DIENTICHSAN;
                            break;
                        case "4"://DC_CANHO
                            shts_loaits.LoaiTaiSan = "Căn hộ";
                            shts_loaits.TenTaiSan = shts_loaits.TaiSanGanLienVoiDat.TENTAISAN;
                            shts_loaits.DienTich = (decimal)shts_loaits.TaiSanGanLienVoiDat.CanHo.DIENTICHSAN;
                            break;
                        case "5"://DC_HANGMUCNGOAICANHO
                            shts_loaits.LoaiTaiSan = "Hạng mục ngoài căn hộ";
                            shts_loaits.TenTaiSan = shts_loaits.TaiSanGanLienVoiDat.TENTAISAN;
                            shts_loaits.DienTich = (decimal)shts_loaits.TaiSanGanLienVoiDat.HangMucNgoaiCanHo.DIENTICH;
                            break;
                        case "6"://DC_CONGTRINHXAYDUNG
                            shts_loaits.LoaiTaiSan = "Công trình xây dựng";
                            shts_loaits.TenTaiSan = shts_loaits.TaiSanGanLienVoiDat.TENTAISAN;
                            shts_loaits.DienTich = (decimal)shts_loaits.TaiSanGanLienVoiDat.CongTrinhXayDung.DIENTICHSAN;
                            break;
                        case "7"://DC_CONGTRINHNGAM
                            shts_loaits.LoaiTaiSan = "Công trình ngầm";
                            shts_loaits.TenTaiSan = shts_loaits.TaiSanGanLienVoiDat.TENTAISAN;
                            shts_loaits.DienTich = (decimal)shts_loaits.TaiSanGanLienVoiDat.CongTrinhNgam.DIENTICHCONGTRINH;
                            break;
                        case "8"://DC_HANGMUCCONGTRINH
                            shts_loaits.LoaiTaiSan = "Hạng mục công trình";
                            shts_loaits.TenTaiSan = shts_loaits.TaiSanGanLienVoiDat.TENTAISAN;
                            shts_loaits.DienTich = (decimal)shts_loaits.TaiSanGanLienVoiDat.HangMucCongTrinh.DIENTICHSAN;
                            break;
                        case "9"://DC_RUNGTRONG
                            shts_loaits.LoaiTaiSan = "Trồng rừng";
                            shts_loaits.TenTaiSan = shts_loaits.TaiSanGanLienVoiDat.TENTAISAN;
                            shts_loaits.DienTich = (decimal)shts_loaits.TaiSanGanLienVoiDat.RungTrong.DIENTICH;
                            break;
                        case "10"://DC_CAYLAUNAM
                            shts_loaits.LoaiTaiSan = "Cây lâu năm";
                            shts_loaits.TenTaiSan = shts_loaits.TaiSanGanLienVoiDat.TENTAISAN;
                            shts_loaits.DienTich = (decimal)shts_loaits.TaiSanGanLienVoiDat.CayLauNam.DIENTICH;
                            break;
                        default:
                            break;
                    }
                }

            }
            #endregion
        }
    }
}