using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;
using System.Data.Entity;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class QTHOSOTIEPNHANServices
    {
        //Lấy dữ liệu hồ sơ và các giấy tờ đính kèm bộ hồ sơ
        public static QT_HOSOTIEPNHAN getHoSoTiepNhan(string HoSoTiepNhanID)
        {
            return getTTHoSoTiepNhan(HoSoTiepNhanID, false);
        }
        //Lấy dữ liệu hồ sơ và toàn bộ thông tin liên quan trong bộ hồ sơ
        public static QT_HOSOTIEPNHAN getAllHoSoTiepNhan(string HoSoTiepNhanID)
        {
            return getTTHoSoTiepNhan(HoSoTiepNhanID, true);
        }
        public static QT_HOSOTIEPNHAN getQT_HOSOTIEPNHAN_DonDK(string HoSoTiepNhanID)
        {
            QT_HOSOTIEPNHAN ret = null;

            using (MplisEntities db = new MplisEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;
                var retVal = (from hs in db.QT_HOSOTIEPNHAN.Where(c => c.HOSOTIEPNHANID == HoSoTiepNhanID)
                              select hs).FirstOrDefault();
                if (retVal != null)
                {
                    ret = retVal;
                    ret.DonDangKy = DCDONDANGKYServices.getDonDangKyByHoSoTiepNhanID(HoSoTiepNhanID);
                }
            }
            return ret;
        }
        private static QT_HOSOTIEPNHAN getTTHoSoTiepNhan(string HoSoTiepNhanID, bool isGetAllData)
        {
            QT_HOSOTIEPNHAN ret = null;

            using (MplisEntities db = new MplisEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;
                var retVal = db.QT_HOSOTIEPNHAN.Where(it => it.HOSOTIEPNHANID.Equals(HoSoTiepNhanID))
                    .Select(hoSoTiepNhan => new
                    {
                        hoSoTiepNhan,
                        fileDinhKems = db.QT_FILEDINHKEMHOSO.Where(it => it.HOSOTIEPNHANID.Equals(hoSoTiepNhan.HOSOTIEPNHANID))
                        .Select(fileDinhKem => new
                        {
                            fileDinhKem,
                            giayToTheoTTHC = db.QT_GIAYTOTHEOTTHC.Where(it => it.GIAYTOTHEOTTHCID.Equals(fileDinhKem.GIAYTOTHEOTTHCID)).FirstOrDefault()
                        }).ToList(),
                        thuTucHanhChinh = db.QT_THUTUCHANHCHINH.Where(it => it.THUTUCHANHCHINHID.Equals(hoSoTiepNhan.THUTUCHANHCHINHID)).FirstOrDefault(),
                        khuVucHanhChinh = db.HC_DMKVHC.Where(it => it.KVHCID.Equals(hoSoTiepNhan.DONVIHANHCHINHID)).FirstOrDefault()
                    }).FirstOrDefault();
                if(retVal != null)
                {
                    ret = retVal.hoSoTiepNhan;
                    retVal.hoSoTiepNhan.DSFileDinhKem = new List<QT_FILEDINHKEMHOSO>();
                    foreach(var tempFile in retVal.fileDinhKems)
                    {
                        tempFile.fileDinhKem.GiayToTheoTTHC = tempFile.giayToTheoTTHC;
                        retVal.hoSoTiepNhan.DSFileDinhKem.Add(tempFile.fileDinhKem);
                    }
                    if(retVal.thuTucHanhChinh != null)
                    {
                        ret.TenThuThuHanhChinh = retVal.thuTucHanhChinh.TENTHUTUCHANHCHINH;
                    }
                    ret.MaKVHC = retVal.khuVucHanhChinh.MAXA;
                    ret.TenKVHC = retVal.khuVucHanhChinh.TENKVHC;
                }
            }

            if (isGetAllData)
            {
                ret.BienDong = DCBIENDONGServices.getBienDongByHoSoID(HoSoTiepNhanID);
                ret.DonDangKy = DCDONDANGKYServices.getDonDangKyByHoSoTiepNhanID(HoSoTiepNhanID);
            }

            return ret;
        }

        #region "Thao tác trên bộ hồ sơ"
        public static void addGCNInHoSo(QT_HOSOTIEPNHAN hoso, DC_DANGKY_GCN gcn)
        {
            hoso.DonDangKy.DSDangKyGCN.Add(gcn);
            //thêm vào bảng biến động - thửa
            using (MplisEntities db = new MplisEntities())
            {
                DC_BD_THUA bdThua;
                foreach (var item in gcn.GiayChungNhan.DSQuyenSDDat)
                {
                    bdThua = new DC_BD_THUA();
                    bdThua.BDTHUAID = Guid.NewGuid().ToString();
                    bdThua.THUADATID = item.THUADATID;
                    bdThua.Thua = item.Thua;
                    bdThua.BIENDONGID = hoso.BienDong.BIENDONGID;
                    bdThua.DiaChi = item.Thua.DIACHITHUADAT;
                    bdThua.DienTich = item.DienTich;
                    bdThua.LADULIEULS = "N";
                    bdThua.LoaiThua = item.Thua.LOAITHUADAT;
                    bdThua.LOAITHUABD = "V";
                    bdThua.SHToBanDo = item.Thua.SOHIEUTOBANDO;
                    bdThua.STTThua = item.Thua.SOTHUTUTHUA;
                    bdThua.XaPhuong = hoso.TenKVHC;
                    db.Entry(bdThua).State = EntityState.Added;
                    hoso.BienDong.DSThua.Add(bdThua);
                }
                db.SaveChanges();
            }
        }

        public static void removeGCNInHoSo(QT_HOSOTIEPNHAN hoso, string gcnID)
        {
            try
            {
                //remove khỏi danh sách đăng ký
                DC_DANGKY_GCN dkGCN = null;
                for (int i = hoso.DonDangKy.DSDangKyGCN.Count; i >= 0; i--)
                {
                    if (hoso.DonDangKy.DSDangKyGCN[i].GiayChungNhan.GIAYCHUNGNHANID.Equals(gcnID))
                    {
                        dkGCN = hoso.DonDangKy.DSDangKyGCN[i];
                        hoso.DonDangKy.DSDangKyGCN.RemoveAt(i);
                        break;
                    }
                }
                //xóa khỏi bảng biến động - thửa
                if (dkGCN != null)
                    using (MplisEntities db = new MplisEntities())
                    {
                        DC_BD_THUA bdThua;
                        foreach (var item in dkGCN.GiayChungNhan.DSQuyenSDDat)
                        {
                            bdThua = hoso.BienDong.DSThua.Where(i => i.THUADATID.Equals(item.THUADATID)).FirstOrDefault();
                            if (bdThua != null)
                            {
                                db.Entry(bdThua).State = EntityState.Deleted;
                                hoso.BienDong.DSThua.Remove(bdThua);
                            }
                        }
                        db.SaveChanges();
                    }
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }
        #endregion
    }
}