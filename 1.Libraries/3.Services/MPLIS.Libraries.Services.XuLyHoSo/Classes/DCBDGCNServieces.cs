using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MPLIS.Libraries.Data.XuLyHoSo.Models;
using AppCore.Models;
using AutoMapper;
using System.Data.Entity;
using System.Data.Common;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCBDGCNServieces
    {
        //Thêm mới GCN đầu vào khi: GCN đã được cấp nhưng trong hệ thống không có dữ liệu về GCN.
        //Thêm mới  GCN đầu ra khi: GCN được cấp mới lần đầu.
        public static bool ThemMoiBDGCN(string laGCNVao, BoHoSoModel bhs, out string message)
        {
            DC_BD_GCN bienDongGCN = new DC_BD_GCN();
            bienDongGCN.BDGCNID = Guid.NewGuid().ToString();
            bienDongGCN.BIENDONGID = bhs.HoSoTN.BienDong.BIENDONGID;
            bienDongGCN.LAGCNVAO = laGCNVao == "Y" ? "Y" : "N";
            bienDongGCN.GiayChungNhan = new DC_GIAYCHUNGNHAN();
            bienDongGCN.GiayChungNhan.GIAYCHUNGNHANID = Guid.NewGuid().ToString();
            bienDongGCN.GiayChungNhan.NGAYCAP = DateTime.Now;
            bienDongGCN.GiayChungNhan.TRANGTHAIXULY = bienDongGCN.LAGCNVAO == "Y" ? "Y" : "S";
            bienDongGCN.GIAYCHUNGNHANID = bienDongGCN.GiayChungNhan.GIAYCHUNGNHANID;
            bienDongGCN.UpdateData();
            if (DBInsertBienDongGCN(bienDongGCN))
            {
                bhs.HoSoTN.BienDong.DSGcn.Add(bienDongGCN);
                string str = laGCNVao == "Y" ? "đầu vào " : "đầu ra ";
                message = "Thêm mới Giấy Chứng Nhận " + str + "thành công!";
                return true;
            }
            message = "Có lỗi xảy ra!";
            return false;
        }
        public static bool ThemMoiBDGCNTuDangKy(List<string> dSDANGKYGCNID, BoHoSoModel bhs, out string message)
        {
            bool found = false;
            List<DC_BD_GCN> dSBDGCN = new List<DC_BD_GCN>();
            foreach (var temp in bhs.HoSoTN.DonDangKy.DSDangKyGCN)
            {
                foreach (var DANGKYGCNID in dSDANGKYGCNID)
                {
                    if (temp.DANGKYGCNID == DANGKYGCNID)
                    {
                        found = false;
                        foreach (var tempB in bhs.HoSoTN.BienDong.DSGcn)
                        {
                            if (tempB.GIAYCHUNGNHANID == temp.GIAYCHUNGNHANID)
                            {
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            DC_BD_GCN bienDongGCN = new DC_BD_GCN();
                            bienDongGCN.BDGCNID = Guid.NewGuid().ToString();
                            bienDongGCN.BIENDONGID = bhs.HoSoTN.BienDong.BIENDONGID;
                            bienDongGCN.LAGCNVAO = "Y";
                            bienDongGCN.GIAYCHUNGNHANID = temp.GIAYCHUNGNHANID;
                            bienDongGCN.GiayChungNhan = temp.GiayChungNhan;
                            bienDongGCN.SoPhatHanh = temp.GiayChungNhan.SOPHATHANH;
                            bienDongGCN.MaVach = temp.GiayChungNhan.MAVACH;
                            bienDongGCN.TrangThai = temp.GiayChungNhan.TRANGTHAIXULY;
                            dSBDGCN.Add(bienDongGCN);
                        }
                    }
                }
            }
            if(dSBDGCN.Count > 0)
            {
                if(DBInsertDSBienDongGCN(dSBDGCN, out message))
                {
                    bhs.HoSoTN.BienDong.DSGcn.AddRange(dSBDGCN);
                    return true;
                }
            }
            message = "Có lỗi xảy ra vui lòng thử lại!";
            return false;
        }
        public static bool XoaBDGCN(string bDGCNID, BoHoSoModel bhs, out string message)
        {
            DC_BD_GCN bDGCN = null;
            foreach (var tempBDGCN in bhs.HoSoTN.BienDong.DSGcn)
            {
                if (tempBDGCN.BDGCNID == bDGCNID)
                {
                    bDGCN = tempBDGCN;
                    break;
                }
            }
            if (bDGCN != null)
            {
                using (MplisEntities db = new MplisEntities())
                {
                    try
                    {
                        db.Entry(Mapper.Map<DC_BD_GCN, DC_BD_GCN>(bDGCN)).State = EntityState.Deleted;
                        if(bDGCN.LAGCNVAO == "N" || (bDGCN.LAGCNVAO == "Y" && bDGCN.GiayChungNhan.EnableEdit))
                        {
                            DCGIAYCHUNGNHANServices.DBDeleteGiayChungNhan(bDGCN.GIAYCHUNGNHANID, db, out message);
                        }
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        message = ex.Message;
                        return false;
                    }
                }
                bhs.HoSoTN.BienDong.DSGcn.Remove(bDGCN);
                message = "Xóa GCN khỏi danh sách biến động thành công!";
                return true;
            }
            message = "Có lỗi xảy ra, vui lòng thử lại!";
            return false;
        }
        public static bool SaoChepBDGCN(string bDGCNID, BoHoSoModel bhs, out string message)
        {
            DC_BD_GCN bDGCN = null;
            foreach(var tempBDGCN in bhs.HoSoTN.BienDong.DSGcn)
            {
                if(tempBDGCN.BDGCNID == bDGCNID && tempBDGCN.TrangThai == "Y")
                {
                    bDGCN = tempBDGCN;
                    break;
                }
            }
            if(bDGCN != null && bDGCN.GiayChungNhan != null)
            {
                DC_BD_GCN bDGCNClone = new DC_BD_GCN();
                DC_GIAYCHUNGNHAN gCN = bDGCN.GiayChungNhan;
                DC_GIAYCHUNGNHAN gCNClone = new DC_GIAYCHUNGNHAN();
                gCNClone.GIAYCHUNGNHANID = Guid.NewGuid().ToString();
                gCNClone.NGUOIID = gCN.NGUOIID;
                gCNClone.MAVACH = gCN.MAVACH;
                gCNClone.SOPHATHANH = gCN.SOPHATHANH;
                gCNClone.GHICHU = gCN.GHICHU;
                gCNClone.TRANGTHAIXULY = "S";
                gCNClone.NGAYCAP = DateTime.Now;
                #region "Danh sách quyền sử dụng đất"
                if (bDGCN.GiayChungNhan.DSQuyenSDDat != null)
                {
                    gCNClone.DSQuyenSDDat = new List<DC_QUYENSUDUNGDAT>();
                    foreach (var tempQSDDat in bDGCN.GiayChungNhan.DSQuyenSDDat)
                    {
                        DC_QUYENSUDUNGDAT qSDDatClone = new DC_QUYENSUDUNGDAT();
                        qSDDatClone.QUYENSDDGOCID = tempQSDDat.QUYENSUDUNGDATID;
                        qSDDatClone.QUYENSUDUNGDATID = Guid.NewGuid().ToString();
                        qSDDatClone.GIAYCHUNGNHANID = gCNClone.GIAYCHUNGNHANID;
                        qSDDatClone.NGUOIID = tempQSDDat.NGUOIID;
                        qSDDatClone.TILESOHUU = tempQSDDat.TILESOHUU;
                        qSDDatClone.DONDANGKYID = tempQSDDat.DONDANGKYID;
                        if (tempQSDDat.THUADATID != null && tempQSDDat.THUADATID != "" && bhs.HoSoTN.DonDangKy.DSDangKyThua != null)
                        {
                            foreach(var tempTKThua in bhs.HoSoTN.DonDangKy.DSDangKyThua)
                            {
                                if(tempTKThua.Thua != null && tempTKThua.Thua.THUAGOCID == tempQSDDat.THUADATID)
                                {
                                    qSDDatClone.THUADATID = tempTKThua.Thua.THUADATID;
                                    qSDDatClone.Thua = tempTKThua.Thua;
                                    foreach (var tempMDSD in tempTKThua.Thua.DSMucDichSuDungDat)
                                    {
                                        if(tempMDSD.MDSDGOCID == tempQSDDat.MUCDICHSUDUNGDATID)
                                        {
                                            qSDDatClone.MUCDICHSUDUNGDATID = tempMDSD.MUCDICHSUDUNGDATID;
                                            qSDDatClone.MdsdDat = tempMDSD;
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                        qSDDatClone.UpdateData();
                        gCNClone.DSQuyenSDDat.Add(qSDDatClone);
                    }
                }
                #endregion
                #region "Danh sách quyền quản lý đất"
                if(bDGCN.GiayChungNhan.DSQuyenQLDat != null)
                {
                    gCNClone.DSQuyenQLDat = new List<DC_QUYENQUANLYDAT>();
                    foreach (var tempQQLDat in bDGCN.GiayChungNhan.DSQuyenQLDat)
                    {
                        DC_QUYENQUANLYDAT qQLDatClone = new DC_QUYENQUANLYDAT();
                        qQLDatClone.QUYENQLDATGOCID = tempQQLDat.QUYENQUANLYDATID;
                        qQLDatClone.QUYENQUANLYDATID = Guid.NewGuid().ToString();
                        qQLDatClone.GIAYCHUNGNHANID = gCNClone.GIAYCHUNGNHANID;
                        qQLDatClone.NGUOIID = tempQQLDat.NGUOIID;
                        qQLDatClone.TILESOHUU = tempQQLDat.TILESOHUU;
                        qQLDatClone.DONDANGKYID = tempQQLDat.DONDANGKYID;
                        if (tempQQLDat.THUADATID != null && tempQQLDat.THUADATID != "")
                        {
                            foreach (var tempThuaDat in bhs.HoSoTN.DonDangKy.DSDangKyThua)
                            {
                                if (tempThuaDat.Thua != null && tempThuaDat.Thua.THUAGOCID == tempQQLDat.THUADATID)
                                {
                                    qQLDatClone.THUADATID = tempThuaDat.Thua.THUADATID;
                                    qQLDatClone.Thua = tempThuaDat.Thua;
                                    foreach (var tempMDSD in tempThuaDat.Thua.DSMucDichSuDungDat)
                                    {
                                        if (tempMDSD.MDSDGOCID == tempQQLDat.MUCDICHSUDUNGID)
                                        {
                                            qQLDatClone.MUCDICHSUDUNGID = tempMDSD.MUCDICHSUDUNGDATID;
                                            qQLDatClone.MdsdDat = tempMDSD;
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                        qQLDatClone.UpdateData();
                        gCNClone.DSQuyenQLDat.Add(qQLDatClone);
                    }
                }
                #endregion
                #region "Danh sách quyền quản lý tài sản"
                if(bDGCN.GiayChungNhan.DSQuyenSHTS != null)
                {
                    gCNClone.DSQuyenSHTS = new List<DC_QUYENSOHUUTAISAN>();
                    foreach(var tempQSHTS in bDGCN.GiayChungNhan.DSQuyenSHTS)
                    {
                        DC_QUYENSOHUUTAISAN qSHTSClone = new DC_QUYENSOHUUTAISAN();
                        qSHTSClone.QUYENSHTSGOCID = tempQSHTS.QUYENSOHUUTAISANID;
                        qSHTSClone.QUYENSOHUUTAISANID = Guid.NewGuid().ToString();
                        qSHTSClone.GIAYCHUNGNHANID = gCNClone.GIAYCHUNGNHANID;
                        qSHTSClone.NGUOIID = tempQSHTS.NGUOIID;
                        qSHTSClone.TILESOHUU = tempQSHTS.TILESOHUU;
                        qSHTSClone.DONDANGKYID = tempQSHTS.DONDANGKYID;
                        if (tempQSHTS.TAISANGANLIENVOIDATID != null && tempQSHTS.TAISANGANLIENVOIDATID != "")
                        {
                            foreach (var tempDKTS in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                            {
                                if (tempDKTS.TaiSanGanLienVoiDat != null && tempDKTS.TaiSanGanLienVoiDat.TAISANGOCID == tempQSHTS.TAISANGANLIENVOIDATID)
                                {
                                    qSHTSClone.TAISANGANLIENVOIDATID = tempDKTS.TaiSanGanLienVoiDat.TAISANGANLIENVOIDATID;
                                    qSHTSClone.TaiSanGanLienVoiDat = tempDKTS.TaiSanGanLienVoiDat;
                                    break;
                                }
                            }
                        }
                    }
                }
                #endregion
                bDGCNClone.BDGCNID = Guid.NewGuid().ToString();
                bDGCNClone.GIAYCHUNGNHANID = gCNClone.GIAYCHUNGNHANID;
                bDGCNClone.BIENDONGID = bDGCN.BIENDONGID;
                bDGCNClone.GiayChungNhan = gCNClone;
                bDGCNClone.LAGCNVAO = "N";
                bDGCNClone.TrangThai = gCNClone.TRANGTHAIXULY;
                bDGCNClone.SoPhatHanh = gCNClone.SOPHATHANH;
                bDGCNClone.MaVach = gCNClone.MAVACH;
                if (DBInsertBienDongGCN(bDGCNClone, out message))
                {
                    bhs.HoSoTN.BienDong.DSGcn.Add(bDGCNClone);
                    message = "Sao chép GCN đầu vào thành công!";
                    return true;
                }
                return false;
            }
            message = "Dữ liệu không đúng?\nHoặc bạn đang cố gắng sao chép GCN đang xử lý?";
            return false;
        }
        public static bool DBInsertBienDongGCN(DC_BD_GCN bDGCN, out string message)
        {
            using (MplisEntities db = new MplisEntities())
            {
                try
                {
                    db.Entry(Mapper.Map<DC_GIAYCHUNGNHAN, DC_GIAYCHUNGNHAN>(bDGCN.GiayChungNhan)).State = EntityState.Added;
                    if(bDGCN.GiayChungNhan.DSQuyenSDDat != null)
                    {
                        foreach(var tempQSDDat in bDGCN.GiayChungNhan.DSQuyenSDDat)
                        {
                            db.Entry(Mapper.Map<DC_QUYENSUDUNGDAT, DC_QUYENSUDUNGDAT>(tempQSDDat)).State = EntityState.Added;
                        }
                    }
                    db.Entry(Mapper.Map<DC_BD_GCN, DC_BD_GCN>(bDGCN)).State = EntityState.Added;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    return false;
                }
            }
            message = "Thêm mới GCN vào trong biến động thành công!";
            return true;
        }
        public static bool DBInsertBienDongGCN(DC_BD_GCN bDGCN)
        {
            using (MplisEntities db = new MplisEntities())
            {
                try
                {
                    db.Entry(Mapper.Map<DC_GIAYCHUNGNHAN, DC_GIAYCHUNGNHAN>(bDGCN.GiayChungNhan)).State = EntityState.Added;
                    if (bDGCN.GiayChungNhan.DSQuyenSDDat != null)
                    {
                        foreach (var tempQSDDat in bDGCN.GiayChungNhan.DSQuyenSDDat)
                        {
                            db.Entry(Mapper.Map<DC_QUYENSUDUNGDAT, DC_QUYENSUDUNGDAT>(tempQSDDat)).State = EntityState.Added;
                        }
                    }
                    db.Entry(Mapper.Map<DC_BD_GCN, DC_BD_GCN>(bDGCN)).State = EntityState.Added;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool DBInsertDSBienDongGCN(List<DC_BD_GCN> dSBDGCN, out string message)
        {
            using (MplisEntities db = new MplisEntities())
            {
                try
                {
                    foreach(var tempBDGCN in dSBDGCN)
                    {
                        db.Entry(Mapper.Map<DC_BD_GCN, DC_BD_GCN>(tempBDGCN)).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    return false;
                }
            }
            message = "Thêm mới GCN vào trong biến động thành công!";
            return true;
        }
    }
}