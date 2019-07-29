using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;
using System.Data.Entity;
using System.Data.Common;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCNGUOIServices
    {
        public static DC_NGUOI getChu(string nguoiID)
        {
            DC_NGUOI ret = null;
            using (MplisEntities db = new MplisEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;
                var retNguoi = db.DC_NGUOI.Where(it => it.NGUOIID.Equals(nguoiID))
                    .Select(nguoi => new
                    {
                        nguoi,
                        doiTuongSD = db.DM_DOITUONGSUDUNG.Where(it => it.DOITUONGSUDUNGID == nguoi.DOITUONGSUDUNGID).FirstOrDefault()
                    }).FirstOrDefault();
                if (retNguoi != null)
                {
                    ret = retNguoi.nguoi;
                    ret.DoiTuongSuDung = retNguoi.doiTuongSD;
                    if (ret != null)
                        switch (ret.LOAIDOITUONGID)
                        {
                            case "1"://DC_CANHAN
                                ret.CaNhan = DCCANHANServices.GetCaNhan(ret.CHITIETID, db);
                                break;
                            case "2"://DC_HOGIADINH
                                ret.HoGiaDinh = DCHOGIADINHServices.GetHoGiaDinh(ret.CHITIETID, db);
                                break;
                            case "3"://DC_VOCHONG
                                ret.VoChong = DCVOCHONGServices.GetVoChong(ret.CHITIETID, db);
                                break;
                            case "4"://DC_TOCHUC
                                ret.ToChuc = DCTOCHUCServices.GetToChuc(ret.CHITIETID, db);
                                break;
                            case "5"://DC_CONGDONG
                                ret.CongDong = DCCONGDONGServices.GetCongDong(ret.CHITIETID, db);
                                break;
                            case "6"://DC_NHOMNGUOI
                                ret.NhomNguoi = DCNHOMNGUOIServices.GetNhomNguoi(ret.CHITIETID, db);
                                break;
                            default:
                                break;
                        }
                }
            }
            return ret;
        }
        public static DC_NGUOI GetChu(string nguoiID, MplisEntities db)
        {
            DC_NGUOI ret = null;
            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = false;
            var retNguoi = db.DC_NGUOI.Where(it => it.NGUOIID.Equals(nguoiID))
                .Select(nguoi => new
                {
                    nguoi,
                    doiTuongSD = db.DM_DOITUONGSUDUNG.Where(it => it.DOITUONGSUDUNGID == nguoi.DOITUONGSUDUNGID).FirstOrDefault()
                }).FirstOrDefault();
            if (retNguoi != null)
            {
                ret = retNguoi.nguoi;
                ret.DoiTuongSuDung = retNguoi.doiTuongSD;
                if (ret != null)
                    switch (ret.LOAIDOITUONGID)
                    {
                        case "1"://DC_CANHAN
                            ret.CaNhan = DCCANHANServices.GetCaNhan(ret.CHITIETID, db);
                            break;
                        case "2"://DC_HOGIADINH
                            ret.HoGiaDinh = DCHOGIADINHServices.GetHoGiaDinh(ret.CHITIETID, db);
                            break;
                        case "3"://DC_VOCHONG
                            ret.VoChong = DCVOCHONGServices.GetVoChong(ret.CHITIETID, db);
                            break;
                        case "4"://DC_TOCHUC
                            ret.ToChuc = DCTOCHUCServices.GetToChuc(ret.CHITIETID, db);
                            break;
                        case "5"://DC_CONGDONG
                            ret.CongDong = DCCONGDONGServices.GetCongDong(ret.CHITIETID, db);
                            break;
                        case "6"://DC_NHOMNGUOI
                            ret.NhomNguoi = DCNHOMNGUOIServices.GetNhomNguoi(ret.CHITIETID, db);
                            break;
                        default:
                            break;
                    }
            }
            return ret;
        }
        public static void SaveNguoi(DC_NGUOI nguoi, MplisEntities db)
        {
            if (nguoi.TRANGTHAI == 1)
            {
                db.Entry(nguoi).State = EntityState.Added;
                nguoi.TRANGTHAI = 2;
            }
            else if (nguoi.TRANGTHAI == 2)
            {
                db.Entry(nguoi).State = EntityState.Modified;
            }
        }
    }
}