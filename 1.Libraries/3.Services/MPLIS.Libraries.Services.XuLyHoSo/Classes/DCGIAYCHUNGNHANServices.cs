using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;
using MPLIS.Libraries.Data.XuLyHoSo.Models;
using System.Data.Common;
using AutoMapper;
using System.Data.Entity;
using MPLIS.Libraries.Data.XuLyHoSo.Models.ViewModels.TTGiayChungNhan;
using Newtonsoft.Json.Linq;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCGIAYCHUNGNHANServices
    {

        #region ""
        public static bool InitBHSCurGCN(string gCNID, TaiGCN taiGCN, BoHoSoModel bhs)
        {
            if (gCNID != null && gCNID != "")
            {
                DC_GIAYCHUNGNHAN gCN = null;
                switch (taiGCN)
                {
                    case TaiGCN.DANGKY:
                        if (bhs.HoSoTN.DonDangKy.DSDangKyGCN != null)
                        {
                            foreach (var tempGCNDK in bhs.HoSoTN.DonDangKy.DSDangKyGCN)
                            {
                                if (tempGCNDK.GIAYCHUNGNHANID == gCNID)
                                {
                                    gCN = tempGCNDK.GiayChungNhan;
                                    break;
                                }
                            }
                        }
                        break;
                    case TaiGCN.BIENDONG:
                        if (bhs.HoSoTN.BienDong.DSGcn != null)
                        {
                            foreach (var tempGCNBD in bhs.HoSoTN.BienDong.DSGcn)
                            {
                                if (tempGCNBD.GIAYCHUNGNHANID == gCNID)
                                {
                                    gCN = tempGCNBD.GiayChungNhan;
                                    break;
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
                if (gCN != null)
                {
                    //Nếu trạng thái xử lý GCN ở "S" thì cho phép chỉnh sửa thông tin trên GCN:
                    //Nếu trạng thía xử lý GCN ở "Y" thì kiểm tra xem GCN có thuộc đăng ký hay không:
                    //  +Nếu thuộc thì không cho phép chỉnh sửa thông tin trên GCN - GCN này đang có tính pháp lý và dữ liệu đã có trong hệ thống.
                    //  +Nếu không thuộc đăng ký thì cho phép chỉnh sửa thông tin trên GCN - GCN này đang có tính pháp lý những không có trong hệ thống (Thêm mới GCN đầu vào).
                    if (gCN.TRANGTHAIXULY == "S")
                    {
                        gCN.ChinhSua = true;
                    }
                    else
                    {
                        bool foundDangKy = false;
                        if (bhs.HoSoTN.DonDangKy.DSDangKyGCN != null)
                        {
                            foreach (var tempGCNDK in bhs.HoSoTN.DonDangKy.DSDangKyGCN)
                            {
                                if (tempGCNDK.GIAYCHUNGNHANID == gCN.GIAYCHUNGNHANID)
                                {
                                    foundDangKy = true;
                                    break;
                                }
                            }
                        }
                        gCN.ChinhSua = foundDangKy ? false : true;
                    }
                    bhs.CurDC_GIAYCHUNGNHAN = gCN;
                    return true;
                }
            }
            return false;
        }
        public static void SaveGiayChungNhan(DC_GIAYCHUNGNHAN giayChungNhan, MplisEntities db, out string mes)
        {
            try
            {
                string queryDel = "";
                queryDel += "DELETE FROM DC_BD_GCN_GCN WHERE GIAYCHUNGNHANID IN ('" + giayChungNhan.GIAYCHUNGNHANID + "'); ";
                queryDel += "DELETE FROM DC_BD_TREN_GCN WHERE GIAYCHUNGNHANID IN ('" + giayChungNhan.GIAYCHUNGNHANID + "'); ";
                queryDel += "DELETE FROM DC_QUYENSUDUNGDAT WHERE GIAYCHUNGNHANID IN ('" + giayChungNhan.GIAYCHUNGNHANID + "'); ";
                queryDel += "DELETE FROM DC_QUYENQUANLYDAT WHERE GIAYCHUNGNHANID IN ('" + giayChungNhan.GIAYCHUNGNHANID + "'); ";
                queryDel += "DELETE FROM DC_QUYENSOHUUTAISAN WHERE GIAYCHUNGNHANID IN ('" + giayChungNhan.GIAYCHUNGNHANID + "'); ";
                queryDel += "DELETE FROM DC_HANCHE WHERE GIAYCHUNGNHANID IN ('" + giayChungNhan.GIAYCHUNGNHANID + "'); ";
                queryDel += "DELETE FROM DC_GCN_TILESH WHERE GIAYCHUNGNHANID IN ('" + giayChungNhan.GIAYCHUNGNHANID + "'); ";
                if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                            || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                    db.Database.Connection.Open();
                DbCommand cmd = db.Database.Connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "BEGIN " + queryDel + " END; ";
                cmd.ExecuteNonQuery();

                if (giayChungNhan.TRANGTHAI == 1)
                {
                    db.Entry(Mapper.Map<DC_GIAYCHUNGNHAN, DC_GIAYCHUNGNHAN>(giayChungNhan)).State = EntityState.Added;
                    giayChungNhan.TRANGTHAI = 2;
                }
                else if (giayChungNhan.TRANGTHAI == 2)
                {
                    db.Entry(Mapper.Map<DC_GIAYCHUNGNHAN, DC_GIAYCHUNGNHAN>(giayChungNhan)).State = EntityState.Modified;
                }

                if (giayChungNhan.QHGcn_Gcn != null)
                {
                    foreach (var temp in giayChungNhan.QHGcn_Gcn)
                    {
                        DCBDGCNGCNServices.SaveBDGCNGCN(temp, db);
                    }
                }

                if (giayChungNhan.DSBDTrenGCN != null)
                {
                    foreach (var temp in giayChungNhan.DSBDTrenGCN)
                    {
                        DCBDTRENGCNServices.SaveBDTrenGCN(temp, db);
                    }
                }

                if (giayChungNhan.DSQuyenSDDat != null)
                {
                    foreach (var temp in giayChungNhan.DSQuyenSDDat)
                    {
                        DCQUYENSUDUNGDATServices.SaveQuyenSuDungDat(temp, db);
                    }
                }

                if (giayChungNhan.DSQuyenQLDat != null)
                {
                    foreach (var temp in giayChungNhan.DSQuyenQLDat)
                    {
                        DCQUYENQUANLYDATServices.SaveQuyenQuanLyDat(temp, db);
                    }
                }

                if (giayChungNhan.DSQuyenSHTS != null)
                {
                    foreach (var temp in giayChungNhan.DSQuyenSHTS)
                    {
                        DCQUYENSOHUUTAISANServices.SaveQuyenSoHuuTaiSan(temp, db);
                    }
                }

                if (giayChungNhan.DSHanChe != null)
                {
                    foreach (var temp in giayChungNhan.DSHanChe)
                    {
                        DCHANCHEServices.SaveHanChe(temp, db);
                    }
                }

                if (giayChungNhan.DSTyLeSoHuu != null)
                {
                    foreach (var temp in giayChungNhan.DSTyLeSoHuu)
                    {
                        DCGCNTYLESHServices.SaveGCNTyLeSH(temp, db);
                    }
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                mes = err;
                return;
            }
            mes = "Lưu thông tin GCN vào CSDL thành công!";
            return;
        }
        public static bool UpdateTTGiayChungNhan(DC_GIAYCHUNGNHAN gCN, BoHoSoModel bhs, out string message)
        {
            if (bhs.CurDC_GIAYCHUNGNHAN.ChinhSua && gCN.GIAYCHUNGNHANID == bhs.CurDC_GIAYCHUNGNHAN.GIAYCHUNGNHANID && gCN.NGUOIID != null)
            {
                DC_GIAYCHUNGNHAN tempCurGCN = Mapper.Map<DC_GIAYCHUNGNHAN, DC_GIAYCHUNGNHAN>(bhs.CurDC_GIAYCHUNGNHAN);
                bhs.CurDC_GIAYCHUNGNHAN.SOPHATHANH = gCN.SOPHATHANH;
                bhs.CurDC_GIAYCHUNGNHAN.MAVACH = gCN.MAVACH;
                bhs.CurDC_GIAYCHUNGNHAN.SOVAOSO = gCN.SOVAOSO;
                bhs.CurDC_GIAYCHUNGNHAN.NGAYCAP = gCN.NGAYCAP;
                if (bhs.CurDC_GIAYCHUNGNHAN.NGUOIID != gCN.NGUOIID)
                {
                    UpdateChuTrenGCN(gCN.NGUOIID, bhs);
                    bhs.CurDC_GIAYCHUNGNHAN.NGUOIID = gCN.NGUOIID;
                }
                bhs.CurDC_GIAYCHUNGNHAN.GHICHU = gCN.GHICHU;
                bhs.CurDC_GIAYCHUNGNHAN.NONVTC = gCN.NONVTC;
                bhs.CurDC_GIAYCHUNGNHAN.BANQUET = gCN.BANQUET;
                if (DBUpdateGiayChungNhan(bhs.CurDC_GIAYCHUNGNHAN, out message))
                {
                    foreach (var tempBDGCN in bhs.HoSoTN.BienDong.DSGcn)
                    {
                        if (tempBDGCN.GiayChungNhan.GIAYCHUNGNHANID == bhs.CurDC_GIAYCHUNGNHAN.GIAYCHUNGNHANID)
                        {
                            tempBDGCN.UpdateData();
                            break;
                        }
                    }
                    return true;
                }
                bhs.CurDC_GIAYCHUNGNHAN = Mapper.Map<DC_GIAYCHUNGNHAN, DC_GIAYCHUNGNHAN>(tempCurGCN);
                return false;
            }
            message = "Có lỗi xảy ra!";
            return false;
        }
        public static void ConvertHashTableToDSGCNCha(Hashtable dSGCNCha, List<DC_BD_GCN> dsGCN)
        {
            List<string> DSCha;
            DC_BD_GCN_GCN _add;
            if (dSGCNCha != null && dSGCNCha.Count > 0 && dsGCN != null && dsGCN.Count > 0)
            {
                foreach (var it in dsGCN)
                {
                    if (it.LAGCNVAO == "N" && dSGCNCha.Contains(it.GIAYCHUNGNHANID))
                    {
                        it.GiayChungNhan.QHGcn_Gcn = new List<DC_BD_GCN_GCN>();
                    }
                }
                foreach (var it in dsGCN)
                {
                    if (it.LAGCNVAO == "N" && dSGCNCha.Contains(it.GIAYCHUNGNHANID))
                    {
                        DSCha = ((JArray)dSGCNCha[it.GIAYCHUNGNHANID]).ToObject<List<string>>();
                        foreach (string id in DSCha)
                        {
                            _add = new DC_BD_GCN_GCN();
                            _add.BDGCNGCNID = Guid.NewGuid().ToString();
                            _add.GIAYCHUNGNHANID = it.GIAYCHUNGNHANID;
                            _add.GCNCHAID = id;
                            it.GiayChungNhan.QHGcn_Gcn.Add(_add);
                            if (it.GiayChungNhan.TRANGTHAI == 0)
                            {
                                it.GiayChungNhan.TRANGTHAI = 2;
                            }
                        }
                    }
                }
            }
        }
        public static bool UpdateChuTrenGCN(string nguoiID, BoHoSoModel bhs)
        {
            if (nguoiID != "" && bhs.HoSoTN.DonDangKy.DSDangKyChu != null)
            {
                DC_DANGKY_NGUOI dangKyNguoi = null;
                foreach (var tempDKNguoi in bhs.HoSoTN.DonDangKy.DSDangKyChu)
                {
                    if (tempDKNguoi.NGUOIID == nguoiID)
                    {
                        dangKyNguoi = tempDKNguoi;
                        break;
                    }
                }
                if (dangKyNguoi != null && dangKyNguoi.Chu != null)
                {
                    DC_GIAYCHUNGNHAN curGCN = bhs.CurDC_GIAYCHUNGNHAN;
                    if (DCGCNTYLESHServices.DBDeleteGCNTLSHByGCNID(curGCN.GIAYCHUNGNHANID))
                    {
                        curGCN.DSTyLeSoHuu = new List<DC_GCN_TILESH>();
                        if (dangKyNguoi.Chu.LOAIDOITUONGID == "6" && dangKyNguoi.Chu.NhomNguoi != null)
                        {
                            decimal TLSH = Math.Floor((100M / dangKyNguoi.Chu.NhomNguoi.DSThanhVien.Count) * 100) / 100;
                            foreach (var tempTVNhomNguoi in dangKyNguoi.Chu.NhomNguoi.DSThanhVien)
                            {
                                DC_GCN_TILESH gCNTLSH = new DC_GCN_TILESH();
                                gCNTLSH.GCNTILESHID = Guid.NewGuid().ToString();
                                gCNTLSH.GIAYCHUNGNHANID = curGCN.GIAYCHUNGNHANID;
                                gCNTLSH.THANHVIENID = tempTVNhomNguoi.THANHPHANID;
                                gCNTLSH.TILESOHUU = TLSH;
                                gCNTLSH.TENLOAICHU = tempTVNhomNguoi.TENLOAICHU;
                                gCNTLSH.HOTEN = tempTVNhomNguoi.HOTEN;
                                gCNTLSH.SOGIAYTO = tempTVNhomNguoi.SOGIAYTO;
                                if (DCGCNTYLESHServices.DBInsertGCNTLSH(gCNTLSH))
                                    curGCN.DSTyLeSoHuu.Add(gCNTLSH);
                                else
                                    return false;
                            }
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        public static bool DBUpdateGiayChungNhan(DC_GIAYCHUNGNHAN giayChungNhan, out string message)
        {
            using (MplisEntities db = new MplisEntities())
            {
                try
                {
                    db.Entry(Mapper.Map<DC_GIAYCHUNGNHAN, DC_GIAYCHUNGNHAN>(giayChungNhan)).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    return false;
                }
            }
            message = "Cập nhật thành công thông tin GCN trong CSDL!";
            return true;
        }
        public static bool DBUpdateGiayChungNhan(DC_GIAYCHUNGNHAN giayChungNhan)
        {
            using (MplisEntities db = new MplisEntities())
            {
                try
                {
                    db.Entry(Mapper.Map<DC_GIAYCHUNGNHAN, DC_GIAYCHUNGNHAN>(giayChungNhan)).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool DBDeleteGiayChungNhan(string giayChungNhanID, MplisEntities db, out string message)
        {
            try
            {
                string queryDel = "";
                queryDel += "DELETE FROM DC_BD_GCN_GCN WHERE GIAYCHUNGNHANID IN ('" + giayChungNhanID + "'); ";
                queryDel += "DELETE FROM DC_BD_GCN_GCN WHERE GCNCHAID IN ('" + giayChungNhanID + "'); ";
                //queryDel += "DELETE FROM DC_BD_TREN_GCN WHERE GIAYCHUNGNHANID IN ('" + giayChungNhanID + "'); ";
                queryDel += "DELETE FROM DC_QUYENSUDUNGDAT WHERE GIAYCHUNGNHANID IN ('" + giayChungNhanID + "'); ";
                queryDel += "DELETE FROM DC_QUYENQUANLYDAT WHERE GIAYCHUNGNHANID IN ('" + giayChungNhanID + "'); ";
                queryDel += "DELETE FROM DC_QUYENSOHUUTAISAN WHERE GIAYCHUNGNHANID IN ('" + giayChungNhanID + "'); ";
                queryDel += "DELETE FROM DC_HANCHE WHERE GIAYCHUNGNHANID IN ('" + giayChungNhanID + "'); ";
                queryDel += "DELETE FROM DC_GCN_TILESH WHERE GIAYCHUNGNHANID IN ('" + giayChungNhanID + "'); ";
                queryDel += "DELETE FROM DC_GIAYCHUNGNHAN WHERE GIAYCHUNGNHANID IN ('" + giayChungNhanID + "'); ";
                if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                            || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                    db.Database.Connection.Open();
                DbCommand cmd = db.Database.Connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "BEGIN " + queryDel + " END; ";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
            message = "Xóa GCN và dữ liệu liên quan thành công!";
            return true;
        }
        #endregion

        #region "Xử Lý Sở Hữu Chung khi thêm quyền vào GCN"
        public static void SoHuuChungTheoQuyenID(ISQuyen isQuyen, string iD, string laGCNVao, BoHoSoModel bhs, out string soHuuChungID)
        {
            DC_GIAYCHUNGNHAN curGCN = bhs.CurDC_GIAYCHUNGNHAN;
            DC_BD_GCN bDGCN = null;
            foreach (var tempBDGCN in bhs.HoSoTN.BienDong.DSGcn)
            {
                if (tempBDGCN.GiayChungNhan != null && tempBDGCN.GiayChungNhan.TRANGTHAIXULY == "S" && tempBDGCN.LAGCNVAO == laGCNVao && tempBDGCN.GiayChungNhan.GIAYCHUNGNHANID != curGCN.GIAYCHUNGNHANID)
                {
                    if (isQuyen == ISQuyen.QSDDAT && tempBDGCN.GiayChungNhan.DSQuyenSDDat != null)
                    {
                        foreach (var tempQSDDat in tempBDGCN.GiayChungNhan.DSQuyenSDDat)
                        {
                            if (tempQSDDat.MUCDICHSUDUNGDATID == iD)
                            {
                                bDGCN = tempBDGCN;
                                break;
                            }
                        }

                    }
                    else if (isQuyen == ISQuyen.QQLDAT && tempBDGCN.GiayChungNhan.DSQuyenQLDat != null)
                    {
                        foreach (var tempQQLDat in tempBDGCN.GiayChungNhan.DSQuyenQLDat)
                        {
                            if (tempQQLDat.MUCDICHSUDUNGID == iD)
                            {
                                bDGCN = tempBDGCN;
                                break;
                            }
                        }
                    }
                    else if (isQuyen == ISQuyen.QSHTS && tempBDGCN.GiayChungNhan.DSQuyenSHTS != null)
                    {
                        foreach (var tempQSHTS in tempBDGCN.GiayChungNhan.DSQuyenSHTS)
                        {
                            if (tempQSHTS.TAISANGANLIENVOIDATID == iD)
                            {
                                bDGCN = tempBDGCN;
                                break;
                            }
                        }
                    }
                    if (bDGCN != null)
                        break;
                }
            }
            if (bDGCN != null)
            {
                //Tìm thấy với mucDichSuDungDatID / taiSanGanLienVoiDatID hiện tại đã được cấp trên một GCN
                if (bDGCN.GiayChungNhan.SOHUUCHUNGID == null || bDGCN.GiayChungNhan.SOHUUCHUNGID == "")
                {
                    //GCN tìm thấy chưa có trường SOHUUCHUNGID: Sinh ra trường này, cập nhật lại TT GCN trong CSDL
                    bDGCN.GiayChungNhan.SOHUUCHUNGID = Guid.NewGuid().ToString();
                    soHuuChungID = bDGCN.GiayChungNhan.SOHUUCHUNGID;
                    DBUpdateGiayChungNhan(bDGCN.GiayChungNhan);
                    return;
                }
                else
                {
                    soHuuChungID = bDGCN.GiayChungNhan.SOHUUCHUNGID;
                    return;
                }
            }
            soHuuChungID = null;
        }
        #endregion

        #region "Quyền Sử Dụng Đất"
        public static bool ThemQSDDatVaoGCN(BoHoSoModel bhs, DC_BD_GCN bDGCN, DC_THUADAT thuaDat, DC_MUCDICHSUDUNGDAT mucDichSuDungDat, out string message)
        {
            DC_GIAYCHUNGNHAN curGCN = bhs.CurDC_GIAYCHUNGNHAN;
            DC_QUYENSUDUNGDAT quyenSDDat = new DC_QUYENSUDUNGDAT();
            quyenSDDat.QUYENSUDUNGDATID = Guid.NewGuid().ToString();
            quyenSDDat.GIAYCHUNGNHANID = curGCN.GIAYCHUNGNHANID;
            quyenSDDat.NGUOIID = curGCN.NGUOIID;
            quyenSDDat.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
            //Là GCN đầu vào được thêm mới (TH lần đầu tiên cấp GCN)
            if (bDGCN.LAGCNVAO == "Y")
            {
                //Thửa đất và MDSD lấy bản gốc
                quyenSDDat.MUCDICHSUDUNGDATID = mucDichSuDungDat.MDSDGOCID;
                quyenSDDat.THUADATID = thuaDat.THUAGOCID;
            }
            //Là GCN đầu ra
            else if (bDGCN.LAGCNVAO == "N")
            {
                //Thửa đất và MDSD lấy bản dược Clone từ bản gốc (Phần Clone được xử lý tại tab Đăng Ký)
                quyenSDDat.MUCDICHSUDUNGDATID = mucDichSuDungDat.MUCDICHSUDUNGDATID;
                quyenSDDat.THUADATID = thuaDat.THUADATID;
            }
            //Xử lý Sở Hữu Chung
            string sOHuuChungID = null;
            SoHuuChungTheoQuyenID(ISQuyen.QSDDAT, quyenSDDat.MUCDICHSUDUNGDATID, bDGCN.LAGCNVAO, bhs, out sOHuuChungID);
            if (sOHuuChungID != null)
            {
                if (curGCN.SOHUUCHUNGID == null || curGCN.SOHUUCHUNGID == "")
                {
                    curGCN.SOHUUCHUNGID = sOHuuChungID;
                    DBUpdateGiayChungNhan(curGCN);
                }
                quyenSDDat.TILESOHUU = 0M;
            }
            else
            {
                quyenSDDat.TILESOHUU = 100M;
            }
            //Hai thông tin này chỉ để phục vụ hiển thị thông tin thửa và Mã MDSD: Tạm thời vẫn lấy theo thửa Clone (Nếu cần thay đổi thì chỉnh sửa sau)
            quyenSDDat.Thua = thuaDat;
            quyenSDDat.MdsdDat = mucDichSuDungDat;
            quyenSDDat.UpdateData();
            if (DCQUYENSUDUNGDATServices.DBInsertQuyenSuDungDat(quyenSDDat, out message))
            {
                curGCN.DSQuyenSDDat.Add(quyenSDDat);
                return true;
            }
            return false;
        }
        public static bool ThemQSDDatTheoThuaDatIDVaoGCN(List<string> dSThuaID, BoHoSoModel bhs, out string message)
        {
            string errMessage = "";
            string successMessage = "";
            DC_GIAYCHUNGNHAN curGCN = bhs.CurDC_GIAYCHUNGNHAN;
            #region "Kiểm tra dữ liệu truyền vào"
            if (curGCN != null && curGCN.ChinhSua && dSThuaID.Count > 0)
            {
                //Dữ liệu đúng
                DC_BD_GCN bDGCN = null;
                #region "Duyệt qua Danh Sách GCN trong Biến Động"
                //Tìm kiếm bDGCN trong danh sách có bDGCN.GIAYCHUNGNHANID = curGCN.GIAYCHUNGNHANID
                foreach (var tempBDGCN in bhs.HoSoTN.BienDong.DSGcn)
                {
                    if (tempBDGCN.GIAYCHUNGNHANID == curGCN.GIAYCHUNGNHANID)
                    {
                        bDGCN = tempBDGCN;
                        break;
                    }
                }
                #endregion
                #region "Tìm kiếm thấy GCN hiện tại thuộc Danh Sách GCN trong Biến Động"
                if (bDGCN != null)
                {
                    //Tìm kiếm thấy
                    DC_THUADAT thuaDat = null;
                    #region "Duyệt qua Danh Sách: dSThuaID - Chứa THUAID của thửa đất được chọn để thêm vào quyền"
                    foreach (var tempThuaID in dSThuaID)
                    {
                        //Với mỗi THUADATID được duyệt qua kiểm tra xem thửa có tồn tại trong đăng ký hay không?
                        thuaDat = null;
                        #region "Duyệt qua Danh Sách Thửa trong Đăng Ký"
                        foreach (var tempDKThua in bhs.HoSoTN.DonDangKy.DSDangKyThua)
                        {
                            if (tempDKThua.THUADATID == tempThuaID)
                            {
                                thuaDat = tempDKThua.Thua;
                                break;
                            }
                        }
                        #endregion
                        #region "Kết quả tìm kiếm Thửa Đất trong Đăng Ký"
                        #region "Tìm kiếm thấy Thửa Đất"
                        if (thuaDat != null)
                        {
                            #region "Kiểm tra DSQuyenSDDat trong GCN (Hiện Tại):"
                            //  +Nếu null thì phải khởi tạo Danh Sách.
                            //  +Ngược lại bỏ qua
                            if (curGCN.DSQuyenSDDat == null)
                                curGCN.DSQuyenSDDat = new List<DC_QUYENSUDUNGDAT>();
                            #endregion
                            #region "Duyệt qua Danh Sách Mục Đích Sử Dụng của Thửa Đất (Trong Đăng Ký) được tìm thấy:"
                            //Một thửa đất có nhiều mục đích sử dụng:
                            foreach (var tempMDSD in thuaDat.DSMucDichSuDungDat)
                            {
                                //Với mỗi Mục Đích Sử Dụng của Thửa Đất được duyệt qua kiểm tra xem MDSD này đã được cấp quyền trên GCN (Hiện Tại) hay chưa?
                                bool foundMDSD = false;
                                #region "Duyệt qua Danh Sách Quyền Sử Dụng Đất trên GCN (Hiện Tại)"
                                foreach (var tempQSDDat in curGCN.DSQuyenSDDat)
                                {
                                    if (bDGCN.LAGCNVAO == "Y")
                                    {
                                        if (tempQSDDat.MUCDICHSUDUNGDATID == tempMDSD.MDSDGOCID)
                                        {
                                            foundMDSD = true;
                                            break;
                                        }
                                    }
                                    else if (bDGCN.LAGCNVAO == "N")
                                    {
                                        if (tempQSDDat.MUCDICHSUDUNGDATID == tempMDSD.MUCDICHSUDUNGDATID)
                                        {
                                            foundMDSD = true;
                                            break;
                                        }
                                    }
                                }
                                #endregion
                                if (!foundMDSD)
                                {
                                    string messageF = "";
                                    if (ThemQSDDatVaoGCN(bhs, bDGCN, thuaDat, tempMDSD, out messageF))
                                    {
                                        successMessage += "\"Quyền Sử Dụng Đất\" trên thửa có THUADATID (" + tempThuaID + ") được thêm thành công vào GCN!\n";
                                    }
                                    else
                                    {
                                        errMessage += messageF + "\n";
                                    }
                                }
                                else
                                {
                                    errMessage += "Thửa đất có THUADATID (" + tempThuaID + ") đã được cấp quyền?\n";
                                }
                            }
                            #endregion
                        }
                        #endregion
                        #region "Tìm kiếm không thấy Thửa Đất"
                        else
                        {
                            errMessage += "Thửa đất có THUADATID (" + tempThuaID + ") không thuộc đăng ký?\n";
                        }
                        #endregion
                        #endregion
                    }
                    message = "Success:\n" + successMessage + "Err:\n" + errMessage;
                    return true;
                    #endregion
                }
                #endregion
                #region "Tìm kiếm không thấy GCN hiện tại thuộc Danh Sách GCN trong Biến Động"
                //Dữ liệu không đúng
                #endregion
            }
            #endregion
            message = "Dữ liệu không đúng?";
            return false;
        }
        public static bool ThemQSDDatTheoMDSDIDVaoGCN(List<string> dSMDSDID, BoHoSoModel bhs, out string message)
        {
            string errMessage = "";
            string successMessage = "";
            DC_GIAYCHUNGNHAN curGCN = bhs.CurDC_GIAYCHUNGNHAN;
            if (curGCN != null && curGCN.ChinhSua && dSMDSDID.Count > 0)
            {
                DC_BD_GCN bDGCN = null;
                foreach (var tempBDGCN in bhs.HoSoTN.BienDong.DSGcn)
                {
                    if (tempBDGCN.GIAYCHUNGNHANID == curGCN.GIAYCHUNGNHANID)
                    {
                        bDGCN = tempBDGCN;
                        break;
                    }
                }
                if (bDGCN != null)
                {
                    DC_THUADAT thuaDat = null;
                    DC_MUCDICHSUDUNGDAT mucDichSuDungDat = null;
                    foreach (var tempMDSDID in dSMDSDID)
                    {
                        thuaDat = null;
                        mucDichSuDungDat = null;
                        foreach (var tempDKThua in bhs.HoSoTN.DonDangKy.DSDangKyThua)
                        {
                            if (tempDKThua.Thua != null)
                            {
                                foreach (var tempThuaMDSD in tempDKThua.Thua.DSMucDichSuDungDat)
                                {
                                    if (tempThuaMDSD.MUCDICHSUDUNGDATID == tempMDSDID)
                                    {
                                        thuaDat = tempDKThua.Thua;
                                        mucDichSuDungDat = tempThuaMDSD;
                                        break;
                                    }
                                }
                                if (thuaDat != null && mucDichSuDungDat != null)
                                {
                                    break;
                                }
                            }
                        }
                        if (thuaDat != null && mucDichSuDungDat != null)
                        {
                            if (curGCN.DSQuyenSDDat == null)
                                curGCN.DSQuyenSDDat = new List<DC_QUYENSUDUNGDAT>();
                            bool foundMDSD = false;
                            foreach (var tempQSDDat in curGCN.DSQuyenSDDat)
                            {
                                if (bDGCN.LAGCNVAO == "Y")
                                {
                                    if (tempQSDDat.MUCDICHSUDUNGDATID == mucDichSuDungDat.MDSDGOCID)
                                    {
                                        foundMDSD = true;
                                        break;
                                    }
                                }
                                else if (bDGCN.LAGCNVAO == "N")
                                {
                                    if (tempQSDDat.MUCDICHSUDUNGDATID == mucDichSuDungDat.MUCDICHSUDUNGDATID)
                                    {
                                        foundMDSD = true;
                                        break;
                                    }
                                }
                            }
                            if (!foundMDSD)
                            {
                                string messageF = "";
                                if (ThemQSDDatVaoGCN(bhs, bDGCN, thuaDat, mucDichSuDungDat, out messageF))
                                {
                                    successMessage += "\"Quyền Sử Dụng Đất\" với MUCDICHSUDUNGID (" + tempMDSDID + ") trên THUADATID (" + thuaDat.THUADATID + ") được thêm thành công vào GCN!\n";
                                }
                                else
                                {
                                    errMessage += messageF + "\n";
                                }
                            }
                            else
                            {
                                errMessage += "MUCDICHSUDUNGID (" + tempMDSDID + ") đã được cấp quyền sử dụng trên GCN!\n";
                            }
                        }
                        else
                        {
                            errMessage += "MUCDICHSUDUNGID (" + tempMDSDID + ") không thuộc bất kỳ một thửa đất nào trong đăng ký?\n";
                        }
                    }
                    message = "Success:\n" + successMessage + "Err:\n" + errMessage;
                    return true;
                }
            }
            message = "Dữ liệu không đúng?";
            return false;
        }
        public static bool XoaQSDatTrenGCN(string quyenSDDatID, BoHoSoModel bhs, out string message)
        {
            DC_GIAYCHUNGNHAN curGCN = bhs.CurDC_GIAYCHUNGNHAN;
            if (quyenSDDatID != "" && curGCN != null && curGCN.ChinhSua)
            {
                DC_QUYENSUDUNGDAT qSDDat = null;
                foreach (var tempQSDDat in curGCN.DSQuyenSDDat)
                {
                    if (tempQSDDat.QUYENSUDUNGDATID == quyenSDDatID)
                    {
                        qSDDat = tempQSDDat;
                        break;
                    }
                }
                if (qSDDat != null && DCQUYENSUDUNGDATServices.DBDeleteQuyenSuDungDat(qSDDat, out message))
                {
                    curGCN.DSQuyenSDDat.Remove(qSDDat);
                    return true;
                }
            }
            message = "Dữ liệu không đúng?";
            return false;
        }
        #endregion

        #region "Quyền Quản Lý Đất"
        public static bool ThemQQLDatVaoGCN(BoHoSoModel bhs, DC_BD_GCN bDGCN, DC_THUADAT thuaDat, DC_MUCDICHSUDUNGDAT mucDichSuDungDat, out string message)
        {
            DC_GIAYCHUNGNHAN curGCN = bhs.CurDC_GIAYCHUNGNHAN;
            DC_QUYENQUANLYDAT quyenQLDat = new DC_QUYENQUANLYDAT();
            quyenQLDat.QUYENQUANLYDATID = Guid.NewGuid().ToString();
            quyenQLDat.GIAYCHUNGNHANID = curGCN.GIAYCHUNGNHANID;
            quyenQLDat.NGUOIID = curGCN.NGUOIID;
            quyenQLDat.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
            //Là GCN đầu vào được thêm mới
            if (bDGCN.LAGCNVAO == "Y")
            {
                //Thửa đất và MDSD lấy bản gốc
                quyenQLDat.MUCDICHSUDUNGID = mucDichSuDungDat.MDSDGOCID;
                quyenQLDat.THUADATID = thuaDat.THUAGOCID;
            }
            //Là GCN đầu ra
            else if (bDGCN.LAGCNVAO == "N")
            {
                //Thửa đất và MDSD lấy bản dược Clone từ bản gốc (Phần Clone được xử lý tại tab Đăng Ký)
                quyenQLDat.MUCDICHSUDUNGID = mucDichSuDungDat.MUCDICHSUDUNGDATID;
                quyenQLDat.THUADATID = thuaDat.THUADATID;
            }
            //Xử lý Sở Hữu Chung
            string sOHuuChungID = null;
            SoHuuChungTheoQuyenID(ISQuyen.QQLDAT, quyenQLDat.MUCDICHSUDUNGID, bDGCN.LAGCNVAO, bhs, out sOHuuChungID);
            if (sOHuuChungID != null)
            {
                if (curGCN.SOHUUCHUNGID == null || curGCN.SOHUUCHUNGID == "")
                {
                    curGCN.SOHUUCHUNGID = sOHuuChungID;
                    DBUpdateGiayChungNhan(curGCN);
                }
                quyenQLDat.TILESOHUU = 0M;
            }
            else
            {
                quyenQLDat.TILESOHUU = 100M;
            }
            //Hai thông tin này chỉ để phục vụ hiển thị thông tin thửa và Mã MDSD: Tạm thời vẫn lấy theo thửa Clone (Nếu cần thay đổi thì chỉnh sửa sau)
            quyenQLDat.Thua = thuaDat;
            quyenQLDat.MdsdDat = mucDichSuDungDat;
            quyenQLDat.UpdateData();
            if (DCQUYENQUANLYDATServices.DBInsertQuyenQuanLyDat(quyenQLDat, out message))
            {
                curGCN.DSQuyenQLDat.Add(quyenQLDat);
                return true;
            }
            return false;
        }
        public static bool ThemQQLDatTheoThuaDatIDVaoGCN(List<string> dSThuaID, BoHoSoModel bhs, out string message)
        {
            string errMessage = "";
            string successMessage = "";
            DC_GIAYCHUNGNHAN curGCN = bhs.CurDC_GIAYCHUNGNHAN;
            #region "Kiểm tra dữ liệu truyền vào"
            if (curGCN != null && curGCN.ChinhSua && dSThuaID.Count > 0)
            {
                //Dữ liệu đúng
                DC_BD_GCN bDGCN = null;
                #region "Duyệt qua Danh Sách GCN trong Biến Động"
                //Tìm kiếm bDGCN trong danh sách có bDGCN.GIAYCHUNGNHANID = curGCN.GIAYCHUNGNHANID
                foreach (var tempBDGCN in bhs.HoSoTN.BienDong.DSGcn)
                {
                    if (tempBDGCN.GIAYCHUNGNHANID == curGCN.GIAYCHUNGNHANID)
                    {
                        bDGCN = tempBDGCN;
                        break;
                    }
                }
                #endregion
                #region "Tìm kiếm thấy GCN hiện tại thuộc Danh Sách GCN trong Biến Động"
                if (bDGCN != null)
                {
                    //Tìm kiếm thấy
                    DC_THUADAT thuaDat = null;
                    #region "Duyệt qua Danh Sách: dSThuaID - Chứa THUAID của thửa đất được chọn để thêm vào quyền"
                    foreach (var tempThuaID in dSThuaID)
                    {
                        //Với mỗi THUADATID được duyệt qua kiểm tra xem thửa có tồn tại trong đăng ký hay không?
                        thuaDat = null;
                        #region "Duyệt qua Danh Sách Thửa trong Đăng Ký"
                        foreach (var tempDKThua in bhs.HoSoTN.DonDangKy.DSDangKyThua)
                        {
                            if (tempDKThua.THUADATID == tempThuaID)
                            {
                                thuaDat = tempDKThua.Thua;
                                break;
                            }
                        }
                        #endregion
                        #region "Kết quả tìm kiếm Thửa Đất trong Đăng Ký"
                        #region "Tìm kiếm thấy Thửa Đất"
                        if (thuaDat != null)
                        {
                            #region "Kiểm tra DSQuyenSDDat trong GCN (Hiện Tại):"
                            //  +Nếu null thì phải khởi tạo Danh Sách.
                            //  +Ngược lại bỏ qua
                            if (curGCN.DSQuyenQLDat == null)
                                curGCN.DSQuyenQLDat = new List<DC_QUYENQUANLYDAT>();
                            #endregion
                            #region "Duyệt qua Danh Sách Mục Đích Sử Dụng của Thửa Đất (Trong Đăng Ký) được tìm thấy:"
                            //Một thửa đất có nhiều mục đích sử dụng:
                            foreach (var tempMDSD in thuaDat.DSMucDichSuDungDat)
                            {
                                //Với mỗi Mục Đích Sử Dụng của Thửa Đất được duyệt qua kiểm tra xem MDSD này đã được cấp quyền trên GCN (Hiện Tại) hay chưa?
                                bool foundMDSD = false;
                                #region "Duyệt qua Danh Sách Quyền Sử Dụng Đất trên GCN (Hiện Tại)"
                                foreach (var tempQQLDat in curGCN.DSQuyenQLDat)
                                {
                                    if (bDGCN.LAGCNVAO == "Y")
                                    {
                                        if (tempQQLDat.MUCDICHSUDUNGID == tempMDSD.MDSDGOCID)
                                        {
                                            foundMDSD = true;
                                            break;
                                        }
                                    }
                                    else if (bDGCN.LAGCNVAO == "N")
                                    {
                                        if (tempQQLDat.MUCDICHSUDUNGID == tempMDSD.MUCDICHSUDUNGDATID)
                                        {
                                            foundMDSD = true;
                                            break;
                                        }
                                    }
                                }
                                #endregion
                                if (!foundMDSD)
                                {
                                    string messageF = "";
                                    if (ThemQQLDatVaoGCN(bhs, bDGCN, thuaDat, tempMDSD, out messageF))
                                    {
                                        successMessage += "\"Quyền Quản Lý Đất\" trên thửa có THUADATID (" + tempThuaID + ") được thêm thành công vào GCN!\n";
                                    }
                                    else
                                    {
                                        errMessage += messageF + "\n";
                                    }
                                }
                                else
                                {
                                    errMessage += "Thửa đất có THUADATID (" + tempThuaID + ") đã được cấp quyền?\n";
                                }
                            }
                            #endregion
                        }
                        #endregion
                        #region "Tìm kiếm không thấy Thửa Đất"
                        else
                        {
                            errMessage += "Thửa đất có THUADATID (" + tempThuaID + ") không thuộc đăng ký?\n";
                        }
                        #endregion
                        #endregion
                    }
                    message = "Success:\n" + successMessage + "Err:\n" + errMessage;
                    return true;
                    #endregion
                }
                #endregion
                #region "Tìm kiếm không thấy GCN hiện tại thuộc Danh Sách GCN trong Biến Động"
                //Dữ liệu không đúng
                #endregion
            }
            #endregion
            message = "Dữ liệu không đúng?";
            return false;
        }
        public static bool ThemQQLDatTheoMDSDIDVaoGCN(List<string> dSMDSDID, BoHoSoModel bhs, out string message)
        {
            string errMessage = "";
            string successMessage = "";
            DC_GIAYCHUNGNHAN curGCN = bhs.CurDC_GIAYCHUNGNHAN;
            if (curGCN != null && curGCN.ChinhSua && dSMDSDID.Count > 0)
            {
                DC_BD_GCN bDGCN = null;
                foreach (var tempBDGCN in bhs.HoSoTN.BienDong.DSGcn)
                {
                    if (tempBDGCN.GIAYCHUNGNHANID == curGCN.GIAYCHUNGNHANID)
                    {
                        bDGCN = tempBDGCN;
                        break;
                    }
                }
                if (bDGCN != null)
                {
                    DC_THUADAT thuaDat = null;
                    DC_MUCDICHSUDUNGDAT mucDichSuDungDat = null;
                    foreach (var tempMDSDID in dSMDSDID)
                    {
                        thuaDat = null;
                        mucDichSuDungDat = null;
                        foreach (var tempDKThua in bhs.HoSoTN.DonDangKy.DSDangKyThua)
                        {
                            if (tempDKThua.Thua != null)
                            {
                                foreach (var tempThuaMDSD in tempDKThua.Thua.DSMucDichSuDungDat)
                                {
                                    if (tempThuaMDSD.MUCDICHSUDUNGDATID == tempMDSDID)
                                    {
                                        thuaDat = tempDKThua.Thua;
                                        mucDichSuDungDat = tempThuaMDSD;
                                        break;
                                    }
                                }
                                if (thuaDat != null && mucDichSuDungDat != null)
                                {
                                    break;
                                }
                            }
                        }
                        if (thuaDat != null && mucDichSuDungDat != null)
                        {
                            if (curGCN.DSQuyenQLDat == null)
                                curGCN.DSQuyenQLDat = new List<DC_QUYENQUANLYDAT>();
                            bool foundMDSD = false;
                            foreach (var tempQQLDat in curGCN.DSQuyenQLDat)
                            {
                                if (bDGCN.LAGCNVAO == "Y")
                                {
                                    if (tempQQLDat.MUCDICHSUDUNGID == mucDichSuDungDat.MDSDGOCID)
                                    {
                                        foundMDSD = true;
                                        break;
                                    }
                                }
                                else if (bDGCN.LAGCNVAO == "N")
                                {
                                    if (tempQQLDat.MUCDICHSUDUNGID == mucDichSuDungDat.MUCDICHSUDUNGDATID)
                                    {
                                        foundMDSD = true;
                                        break;
                                    }
                                }
                            }
                            if (!foundMDSD)
                            {
                                string messageF = "";
                                if (ThemQQLDatVaoGCN(bhs, bDGCN, thuaDat, mucDichSuDungDat, out messageF))
                                {
                                    successMessage += "\"Quyền Quản Lý Đất\" với MUCDICHSUDUNGID (" + tempMDSDID + ") trên THUADATID (" + thuaDat.THUADATID + ") được thêm thành công vào GCN!\n";
                                }
                                else
                                {
                                    errMessage += messageF + "\n";
                                }
                            }
                            else
                            {
                                errMessage += "MUCDICHSUDUNGID (" + tempMDSDID + ") đã được cấp quyền sử dụng trên GCN!\n";
                            }
                        }
                        else
                        {
                            errMessage += "MUCDICHSUDUNGID (" + tempMDSDID + ") không thuộc bất kỳ một thửa đất nào trong đăng ký?\n";
                        }
                    }
                    message = "Success:\n" + successMessage + "Err:\n" + errMessage;
                    return true;
                }
            }
            message = "Dữ liệu không đúng?";
            return false;
        }
        public static bool XoaQQLDatTrenGCN(string quyenQLDatID, BoHoSoModel bhs, out string message)
        {
            DC_GIAYCHUNGNHAN curGCN = bhs.CurDC_GIAYCHUNGNHAN;
            if (quyenQLDatID != "" && curGCN != null && curGCN.ChinhSua)
            {
                DC_QUYENQUANLYDAT qQLDat = null;
                foreach (var tempQQLDat in curGCN.DSQuyenQLDat)
                {
                    if (tempQQLDat.QUYENQUANLYDATID == quyenQLDatID)
                    {
                        qQLDat = tempQQLDat;
                        break;
                    }
                }
                if (qQLDat != null && DCQUYENQUANLYDATServices.DBDeleteQuyenQuanLyDat(qQLDat, out message))
                {
                    curGCN.DSQuyenQLDat.Remove(qQLDat);
                    return true;
                }
            }
            message = "Dữ liệu không đúng?";
            return false;
        }
        #endregion

        #region "Quyền Sở Hữu Tài Sản"
        public static bool ThemQSHTSVaoGCN(List<string> dSTaiSanGanLienVoiDatID, BoHoSoModel bhs, out string message)
        {
            string errMessage = "";
            string successMessage = "";
            DC_GIAYCHUNGNHAN curGCN = bhs.CurDC_GIAYCHUNGNHAN;

            if (curGCN != null && curGCN.ChinhSua && dSTaiSanGanLienVoiDatID.Count > 0)
            {
                DC_BD_GCN bDGCN = null;
                foreach (var tempBDGCN in bhs.HoSoTN.BienDong.DSGcn)
                {
                    if (tempBDGCN.GIAYCHUNGNHANID == curGCN.GIAYCHUNGNHANID)
                    {
                        bDGCN = tempBDGCN;
                        break;
                    }
                }
                if (bDGCN != null)
                {
                    DC_TAISANGANLIENVOIDAT taiSanGanLienVoiDat = null;
                    bool foundTaiSan = false;
                    foreach (var tempTaiSanGanLienVoiDatID in dSTaiSanGanLienVoiDatID)
                    {
                        //Kiểm tra tài sản có trong đăng ký hay không?
                        taiSanGanLienVoiDat = null;
                        foreach (var tempDKTS in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                        {
                            if (tempDKTS.TAISANID == tempTaiSanGanLienVoiDatID && tempDKTS.TaiSanGanLienVoiDat != null)
                            {
                                taiSanGanLienVoiDat = tempDKTS.TaiSanGanLienVoiDat;
                                break;
                            }
                        }
                        if (taiSanGanLienVoiDat == null)
                        {
                            errMessage += "TAISANGANLIENVOIDATID (" + tempTaiSanGanLienVoiDatID + ") không có trong đăng ký?\n";
                            continue;
                        }
                        //Kiểm tra tài sản thêm mới trong đăng ký hay tài sản gốc được clone:
                        bool laThemMoi = false;
                        foreach (var tempTaiSan in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                        {
                            if (tempTaiSan.TaiSanGanLienVoiDat.TAISANGANLIENVOIDATID == tempTaiSanGanLienVoiDatID && (tempTaiSan.TaiSanGanLienVoiDat.TAISANGOCID == null || tempTaiSan.TaiSanGanLienVoiDat.TAISANGOCID == ""))
                            {
                                laThemMoi = true;
                                break;
                            }
                        }
                        //Kiểm tra quyền sở hữu đã được cấp với tài sản đang xét hay chưa?
                        foundTaiSan = false;
                        if (curGCN.DSQuyenSHTS == null)
                            curGCN.DSQuyenSHTS = new List<DC_QUYENSOHUUTAISAN>();
                        foreach (var tempQSHTS in curGCN.DSQuyenSHTS)
                        {
                            if (laThemMoi)
                            {
                                if (bDGCN.LAGCNVAO == "Y" && tempQSHTS.TaiSanGanLienVoiDat.TAISANGOCID == tempTaiSanGanLienVoiDatID)
                                {
                                    foundTaiSan = true;
                                    break;
                                }
                                else if (bDGCN.LAGCNVAO == "N" && tempQSHTS.TaiSanGanLienVoiDat.TAISANGANLIENVOIDATID == tempTaiSanGanLienVoiDatID)
                                {
                                    foundTaiSan = true;
                                    break;
                                }
                            }
                            else if (tempQSHTS.TaiSanGanLienVoiDat.TAISANGANLIENVOIDATID == tempTaiSanGanLienVoiDatID)
                            {
                                foundTaiSan = true;
                                break;
                            }
                        }
                        if (foundTaiSan)
                        {
                            errMessage += "\"Quyền Sở Hữu Tài Sản\" với tài sản có TAISANGANLIENVOIDATID (" + tempTaiSanGanLienVoiDatID + ") đã tồn tại trên GCN\n";
                            continue;
                        }
                        DC_TAISANGANLIENVOIDAT taiSanGanLienVoiDatClone = null;
                        if (laThemMoi && bDGCN.LAGCNVAO == "Y")
                        {
                            //Thêm quyền sở hữu tài sản cho tài sản được thêm mới trong đăng ký vào GCN đầu vào:
                            //  +Trên GCN đầu vào tài sản / thửa phải ở Y.
                            //  +Kiểm tra xem tài sản đã được clone hay chưa, nếu chưa thì clone đổi trạng thái S => Y.
                            //  +Thêm quyền
                            using (MplisEntities db = new MplisEntities())
                            {
                                //+Kiểm tra trong database tài sản đã được Clone hay chưa?
                                var ret = db.DC_TAISANGANLIENVOIDAT.Where(it => it.TAISANGOCID == tempTaiSanGanLienVoiDatID).FirstOrDefault();
                                if (ret != null)
                                {
                                    taiSanGanLienVoiDatClone = ret;
                                }
                                else
                                {
                                    taiSanGanLienVoiDatClone = new DC_TAISANGANLIENVOIDAT();
                                    taiSanGanLienVoiDatClone.TAISANGANLIENVOIDATID = Guid.NewGuid().ToString();
                                    taiSanGanLienVoiDatClone.TAISANID = taiSanGanLienVoiDat.TAISANID;
                                    taiSanGanLienVoiDatClone.LOAITAISAN = taiSanGanLienVoiDat.LOAITAISAN;
                                    taiSanGanLienVoiDatClone.TRANGTHAI = "Y";
                                    taiSanGanLienVoiDatClone.TAISANGOCID = taiSanGanLienVoiDat.TAISANGANLIENVOIDATID;
                                    db.Entry(taiSanGanLienVoiDatClone).State = EntityState.Added;
                                    db.SaveChanges();
                                    taiSanGanLienVoiDatClone = DCTAISANGANLIENVOIDATServices.getTaiSanGanLienVoiDat(taiSanGanLienVoiDatClone.TAISANGANLIENVOIDATID);
                                }
                            }
                        }

                        DC_QUYENSOHUUTAISAN quyenSHTaiSan = new DC_QUYENSOHUUTAISAN();
                        quyenSHTaiSan.QUYENSOHUUTAISANID = Guid.NewGuid().ToString();
                        quyenSHTaiSan.NGUOIID = curGCN.NGUOIID;
                        quyenSHTaiSan.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
                        quyenSHTaiSan.GIAYCHUNGNHANID = curGCN.GIAYCHUNGNHANID;
                        if (taiSanGanLienVoiDatClone != null)
                        {
                            quyenSHTaiSan.TAISANGANLIENVOIDATID = taiSanGanLienVoiDatClone.TAISANGANLIENVOIDATID;
                            quyenSHTaiSan.TaiSanGanLienVoiDat = taiSanGanLienVoiDatClone;
                        }
                        else
                        {
                            quyenSHTaiSan.TAISANGANLIENVOIDATID = tempTaiSanGanLienVoiDatID;
                            quyenSHTaiSan.TaiSanGanLienVoiDat = taiSanGanLienVoiDat;
                        }

                        string sOHuuChungID = null;
                        SoHuuChungTheoQuyenID(ISQuyen.QSHTS, quyenSHTaiSan.TAISANGANLIENVOIDATID, bDGCN.LAGCNVAO, bhs, out sOHuuChungID);
                        if (sOHuuChungID != null)
                        {
                            if (curGCN.SOHUUCHUNGID == null || curGCN.SOHUUCHUNGID == "")
                            {
                                curGCN.SOHUUCHUNGID = sOHuuChungID;
                                DBUpdateGiayChungNhan(curGCN);
                            }
                            quyenSHTaiSan.TILESOHUU = 0M;
                        }
                        else
                        {
                            quyenSHTaiSan.TILESOHUU = 100M;
                        }

                        quyenSHTaiSan.UpdateData();
                        string messageF = "";
                        if(DCQUYENSOHUUTAISANServices.DBInsertQuyenSoHuuTaiSan(quyenSHTaiSan, out messageF))
                        {
                            curGCN.DSQuyenSHTS.Add(quyenSHTaiSan);
                            successMessage += "\"Quyền Sở Hữu Tài Sản\" với tài sản có TAISANGANLIENVOIDATID (" + tempTaiSanGanLienVoiDatID + ") được thêm thành công vào GCN!\n";
                        } else
                        {
                            errMessage += messageF + "\n";
                        }
                    }
                    message = "Success:\n" + successMessage + "Err:\n" + errMessage;
                    return true;
                }
            }
            message = "Dữ liệu không đúng?";
            return false;
        }
        public static bool XoaQSHTaiSanTrenGCN(string quyenSHTSID, BoHoSoModel bhs, out string message)
        {
            DC_GIAYCHUNGNHAN curGCN = bhs.CurDC_GIAYCHUNGNHAN;
            if (quyenSHTSID != "" && curGCN != null && curGCN.TRANGTHAIXULY == "S")
            {
                DC_QUYENSOHUUTAISAN qSHTS = null;
                foreach (var tempQSHTS in curGCN.DSQuyenSHTS)
                {
                    if (tempQSHTS.QUYENSOHUUTAISANID == quyenSHTSID)
                    {
                        qSHTS = tempQSHTS;
                        break;
                    }
                }
                if (qSHTS != null && DCQUYENSOHUUTAISANServices.DBDeleteQuyenSoHuuTaiSan(qSHTS, out message))
                {
                    curGCN.DSQuyenSHTS.Remove(qSHTS);
                    return true;
                }
            }
            message = "Dữ liệu không đúng?";
            return false;
        }
        public static void AddQuyenSoHuuTaiSan(BoHoSoModel bhs, List<string> dSTSGLVDID)
        {
            DC_GIAYCHUNGNHAN curGiayChungNhan = bhs.CurDC_GIAYCHUNGNHAN;
            DC_TAISANGANLIENVOIDAT taiSan = null;
            bool found = false;
            string SOHUUCHUNGID = null;
            decimal TILESOHUU = 100M;
            foreach (var taiSanID in dSTSGLVDID)
            {
                found = false;
                foreach (var qSHTS in curGiayChungNhan.DSQuyenSHTS)
                {
                    if (qSHTS.TAISANGANLIENVOIDATID.Equals(taiSanID))
                    {
                        found = true;
                        break;
                    }
                }
                taiSan = null;
                foreach (var taiSanTemp in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                {
                    if (taiSanTemp.TaiSanGanLienVoiDat.TAISANGANLIENVOIDATID.Equals(taiSanID))
                    {
                        taiSan = taiSanTemp.TaiSanGanLienVoiDat;
                        break;
                    }
                }
                if (!found && taiSan != null)
                {
                    DC_QUYENSOHUUTAISAN objTaiSan = new DC_QUYENSOHUUTAISAN();
                    objTaiSan.QUYENSOHUUTAISANID = Guid.NewGuid().ToString();
                    objTaiSan.TAISANGANLIENVOIDATID = taiSanID;
                    objTaiSan.NGUOIID = curGiayChungNhan.NGUOIID;
                    objTaiSan.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
                    objTaiSan.GIAYCHUNGNHANID = curGiayChungNhan.GIAYCHUNGNHANID;
                    objTaiSan.TenTaiSan = taiSan.TENTAISAN;
                    objTaiSan.LoaiTaiSan = taiSan.LoaiTaiSanGanLienVoiDat.TENLOAITAISANGANLIENVOIDAT;
                    objTaiSan.Chu = curGiayChungNhan.Chu;
                    objTaiSan.TaiSanGanLienVoiDat = taiSan;
                    SOHUUCHUNGID = null;
                    TILESOHUU = 100M;
                    //ThemQSHTS_XuLySoHuuChung(objTaiSan.TAISANGANLIENVOIDATID, curGiayChungNhan.GIAYCHUNGNHANID, bhs.HoSoTN.BienDong.DSGcn, out SOHUUCHUNGID, out TILESOHUU);
                    curGiayChungNhan.SOHUUCHUNGID = SOHUUCHUNGID;
                    objTaiSan.TILESOHUU = TILESOHUU;
                    curGiayChungNhan.DSQuyenSHTS.Add(objTaiSan);
                }
            }
        }
        #endregion

        #region "Get GCN"
        public static bool GetGiayChungNhan(string soPhatHanh, string maVach, List<DC_GIAYCHUNGNHAN> dSGCN)
        {
            DC_GIAYCHUNGNHAN gCN = null;
            using (MplisEntities db = new MplisEntities())
            {
                if (soPhatHanh == "")
                {
                    gCN = db.DC_GIAYCHUNGNHAN.Where(it => it.MAVACH == maVach).FirstOrDefault();
                }
                else
                {
                    gCN = db.DC_GIAYCHUNGNHAN.Where(it => it.SOPHATHANH == soPhatHanh && it.MAVACH == maVach).FirstOrDefault();
                }
                if (gCN != null)
                {
                    /*
                        +GCN tìm thấy thuộc trường hợp Sở Hữu Chung cấp nhiều GCN:
                            +Get tất cả GCN liên quan.
                    */
                    if (gCN.SOHUUCHUNGID != null && gCN.SOHUUCHUNGID != "")
                    {
                        var ret = db.DC_GIAYCHUNGNHAN.Where(it => it.SOHUUCHUNGID == gCN.SOHUUCHUNGID).ToList();
                        if (ret.Count > 1)
                        {
                            dSGCN = ret;
                        }
                    }
                    else
                    {
                        dSGCN.Add(gCN);
                    }
                    /*
                        +Load dữ liệu liên quan trên từng GCN trong CSDL:
                    */
                    foreach (var tempGCN in dSGCN)
                    {
                        //Dữ liệu chủ trên GCN:
                        if (tempGCN.NGUOIID != null && tempGCN.NGUOIID != "")
                        {
                            tempGCN.Chu = DCNGUOIServices.GetChu(tempGCN.NGUOIID, db);
                        }
                    }
                    return true;
                }
            }
            return false;
        }
        #endregion

        public static int _loadgcn = 0;
        public static void setloaddatagiaychungnhan(int abc)
        {
            _loadgcn = abc;
        }

        public static int getloaddatagiaychungnhan()
        {
            return _loadgcn;
        }

        public static DC_GIAYCHUNGNHAN getGiayChungNhan(string GiayChungNhanID)
        {
            DC_GIAYCHUNGNHAN ret = null;
            using (MplisEntities db = new MplisEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;
                //Thông tin chung và hai danh sách quyền
                var retVal = (from gcn in db.DC_GIAYCHUNGNHAN.Where(i => i.GIAYCHUNGNHANID.Equals(GiayChungNhanID))
                              select new
                              {
                                  gcn,
                                  QSHs = db.DC_QUYENSOHUUTAISAN.Where(i => i.GIAYCHUNGNHANID.Equals(gcn.GIAYCHUNGNHANID)),
                                  QSDs = db.DC_QUYENSUDUNGDAT.Where(i => i.GIAYCHUNGNHANID.Equals(gcn.GIAYCHUNGNHANID)),
                                  QQLDs = db.DC_QUYENQUANLYDAT.Where(i => i.GIAYCHUNGNHANID.Equals(gcn.GIAYCHUNGNHANID)),
                                  HCs = db.DC_HANCHE.Where(i => i.GIAYCHUNGNHANID.Equals(gcn.GIAYCHUNGNHANID)),
                                  TLSHs = db.DC_GCN_TILESH.Where(i => i.GIAYCHUNGNHANID.Equals(gcn.GIAYCHUNGNHANID)),
                                  QHs = db.DC_BD_GCN_GCN.Where(i => i.GIAYCHUNGNHANID.Equals(gcn.GIAYCHUNGNHANID))
                              }).FirstOrDefault();
                if (retVal != null)
                {
                    ret = retVal.gcn;
                    ret.DSQuyenSDDat = retVal.QSDs.ToList();
                    ret.DSQuyenSHTS = retVal.QSHs.ToList();
                    ret.DSQuyenQLDat = retVal.QQLDs.ToList();
                    ret.DSHanChe = retVal.HCs.ToList();
                    ret.QHGcn_Gcn = retVal.QHs.ToList();
                    ret.DSTyLeSoHuu = retVal.TLSHs.ToList();

                    retVal.gcn.Chu = DCNGUOIServices.getChu(retVal.gcn.NGUOIID);
                    if (retVal.gcn.Chu != null)
                    {
                        if (retVal.TLSHs != null)
                        {
                            var dstlsh = retVal.TLSHs.ToList();
                            if (retVal.gcn.Chu.LOAIDOITUONGID == "6" && dstlsh.Count() > 0)
                            {
                                foreach (var temp in dstlsh)
                                {
                                    foreach (var tempB in retVal.gcn.Chu.NhomNguoi.DSThanhVien)
                                    {
                                        if (temp.THANHVIENID == tempB.THANHPHANID)
                                        {
                                            temp.TENLOAICHU = tempB.HOTEN;
                                            temp.SOGIAYTO = tempB.SOGIAYTO;
                                            temp.TENLOAICHU = tempB.TENLOAICHU;
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                    }


                    //Chủ và thửa trong danh sách quyền sử dụng đất
                    foreach (var q in ret.DSQuyenSDDat)
                    {
                        //lấy dữ liệu liên quan đến thửa đất
                        q.Thua = DCTHUADATServices.getThuaDat(q.THUADATID);

                        //Lấy dữ liệu liên quan đến chủ sử dụng
                        q.Chu = DCNGUOIServices.getChu(q.NGUOIID);

                        var data = (from md in db.DC_MUCDICHSUDUNGDAT.Where(i => i.MUCDICHSUDUNGDATID.Equals(q.MUCDICHSUDUNGDATID))
                                    select new
                                    {
                                        md,
                                        mdsd = db.DM_MUCDICHSUDUNG.Where(i => i.MUCDICHSUDUNGID.Equals(md.MUCDICHSUDUNGID)).FirstOrDefault(),
                                        ngsds = db.DC_NGUONGOCSUDUNG.Where(i => i.MUCDICHSUDUNGDATID.Equals(md.MUCDICHSUDUNGDATID)).ToList()
                                    }).FirstOrDefault();
                        if (data != null)
                        {
                            q.MdsdDat = data.md;
                            q.MdsdDat.MDSD = data.mdsd == null ? "" : data.mdsd.MAMUCDICHSUDUNG;
                            q.MdsdDat.NGSDDats = data.ngsds;
                            if (q.MdsdDat.DIENTICH != null)
                                q.DienTich = (decimal)q.MdsdDat.DIENTICH;
                        }
                        q.STTThua = (decimal)q.Thua.SOTHUTUTHUA;
                        q.SHToBanDo = (decimal)q.Thua.SOHIEUTOBANDO;
                        q.XaPhuong = q.Thua.Xa.TENKVHC;
                    }

                    //Chủ và tài sản trong danh sách quyền sở hữu tài sản
                    foreach (var q in ret.DSQuyenSHTS)
                    {
                        q.TaiSanGanLienVoiDat = DCTAISANGANLIENVOIDATServices.getTaiSanGanLienVoiDat(q.TAISANGANLIENVOIDATID);
                        q.Chu = DCNGUOIServices.getChu(q.NGUOIID);
                    }

                    //Chủ và thửa trong danh sách quyền quản lý đất
                    foreach (var q in ret.DSQuyenQLDat)
                    {
                        //lấy dữ liệu liên quan đến thửa đất
                        q.Thua = DCTHUADATServices.getThuaDat(q.THUADATID);

                        //lấy dữ liệu liên quan đến chủ quản lý
                        q.Chu = DCNGUOIServices.getChu(q.NGUOIID);

                        var data = (from md in db.DC_MUCDICHSUDUNGDAT.Where(i => i.MUCDICHSUDUNGDATID.Equals(q.MUCDICHSUDUNGID))
                                    select new
                                    {
                                        md,
                                        mdsd = db.DM_MUCDICHSUDUNG.Where(i => i.MUCDICHSUDUNGID.Equals(md.MUCDICHSUDUNGID)).FirstOrDefault(),
                                        ngsds = db.DC_NGUONGOCSUDUNG.Where(i => i.MUCDICHSUDUNGDATID.Equals(md.MUCDICHSUDUNGDATID)).ToList()
                                    }).FirstOrDefault();
                        if (data != null)
                        {
                            q.MdsdDat = data.md;
                            q.MdsdDat.MDSD = data.mdsd == null ? "" : data.mdsd.MAMUCDICHSUDUNG;
                            q.MdsdDat.NGSDDats = data.ngsds;
                        }
                    }

                    //Hạn chế trên giấy chứng nhận
                    foreach (var hanChe in ret.DSHanChe)
                    {
                        if (hanChe.LOAIHANCHEID != null)
                            hanChe.LoaiHanChe = DCLOAIHANCHEServices.GetLoaiHanChe(hanChe.LOAIHANCHEID, db);
                    }

                    ret.isInitData = true;
                }
            }
            return ret;
        }

        public static DC_GIAYCHUNGNHAN getGiayChungNhan(string SoPhatHanh, string MaVach)
        {
            if (SoPhatHanh.Equals("") && MaVach.Equals("")) return null;
            DC_GIAYCHUNGNHAN ret = null;
            using (MplisEntities db = new MplisEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;
                //Thông tin chung và hai danh sách quyền
                var retVal = (IQueryable<DC_GIAYCHUNGNHAN>)db.DC_GIAYCHUNGNHAN;
                if (!SoPhatHanh.Equals("")) retVal = retVal.Where(i => i.SOPHATHANH == SoPhatHanh.ToUpper());
                if (!MaVach.Equals("")) retVal = retVal.Where(i => i.MAVACH == MaVach.ToUpper());
                var result = (from gcn in retVal
                              select new
                              {
                                  gcn,
                                  QSHs = db.DC_QUYENSOHUUTAISAN.Where(i => i.GIAYCHUNGNHANID.Equals(gcn.GIAYCHUNGNHANID)).ToList(),
                                  QSDs = db.DC_QUYENSUDUNGDAT.Where(i => i.GIAYCHUNGNHANID.Equals(gcn.GIAYCHUNGNHANID)).ToList(),
                                  QQLDs = db.DC_QUYENQUANLYDAT.Where(i => i.GIAYCHUNGNHANID.Equals(gcn.GIAYCHUNGNHANID)).ToList(),
                                  QHs = db.DC_BD_GCN_GCN.Where(i => i.GIAYCHUNGNHANID.Equals(gcn.GIAYCHUNGNHANID)).ToList()
                              }).FirstOrDefault();
                if (result != null)
                {
                    ret = result.gcn;
                    ret.DSQuyenSDDat = result.QSDs;
                    ret.DSQuyenSHTS = result.QSHs;
                    ret.QHGcn_Gcn = result.QHs;
                    ret.DSQuyenQLDat = result.QQLDs;
                    //Chủ và thửa trong danh sách quyền sử dụng đất
                    foreach (var q in ret.DSQuyenSDDat)
                    {
                        //lấy dữ liệu liên quan đến thửa đất
                        q.Thua = DCTHUADATServices.getThuaDat(q.THUADATID);

                        //Lấy dữ liệu liên quan đến chủ sử dụng
                        q.Chu = DCNGUOIServices.getChu(q.NGUOIID);

                        var data = (from md in db.DC_MUCDICHSUDUNGDAT.Where(i => i.MUCDICHSUDUNGDATID.Equals(q.MUCDICHSUDUNGDATID))
                                    select new
                                    {
                                        md,
                                        mdsd = db.DM_MUCDICHSUDUNG.Where(i => i.MUCDICHSUDUNGID.Equals(md.MUCDICHSUDUNGID)).FirstOrDefault(),
                                        ngsds = db.DC_NGUONGOCSUDUNG.Where(i => i.MUCDICHSUDUNGDATID.Equals(md.MUCDICHSUDUNGDATID)).ToList(),
                                    }).FirstOrDefault();
                        if (data != null)
                        {
                            q.MdsdDat = data.md;
                            q.MdsdDat.MDSD = data.mdsd == null ? "" : data.mdsd.TENMUCDICHSUDUNG;
                            q.MdsdDat.NGSDDats = data.ngsds;
                            if (q.MdsdDat.DIENTICH != null)
                                q.DienTich = (decimal)q.MdsdDat.DIENTICH;
                        }
                        q.STTThua = (decimal)q.Thua.SOTHUTUTHUA;
                        q.SHToBanDo = (decimal)q.Thua.SOHIEUTOBANDO;
                        q.XaPhuong = q.Thua.Xa.TENKVHC;
                    }

                    //Chủ và tài sản trong danh sách quyền sở hữu tài sản
                    foreach (var q in ret.DSQuyenSHTS)
                    {
                        q.TaiSanGanLienVoiDat = DCTAISANGANLIENVOIDATServices.getTaiSanGanLienVoiDat(q.TAISANGANLIENVOIDATID);
                        q.Chu = DCNGUOIServices.getChu(q.NGUOIID);
                    }

                    ret.isInitData = true;
                }
            }

            return ret;
        }

        public static VM_XuLyHoSo_GCN getDC_GIAYCHUNGNHAN_DonDK(string HoSoTiepNhanID, string BienDongID)
        {
            VM_XuLyHoSo_GCN ret = new VM_XuLyHoSo_GCN();

            using (MplisEntities db = new MplisEntities())
            {
                ret._BienDongID = BienDongID;
                ret._HoSoTiepNhanID = HoSoTiepNhanID;
                ret.DonDangKy = DCDONDANGKYServices.getDonDangKyByHoSoTiepNhanID(HoSoTiepNhanID);
            }
            return ret;
        }

        public static void updateTTGiayChungNhan(DC_GIAYCHUNGNHAN gcn)
        {
            if (gcn == null) return;
            if (gcn.DSQuyenSDDat != null && gcn.DSQuyenSDDat.Count > 0)
            {
                foreach (var q in gcn.DSQuyenSDDat)
                {
                    if (q.Thua != null)
                    {
                        q.SHToBanDo = (decimal)q.Thua.SOHIEUTOBANDO;
                        q.STTThua = (decimal)q.Thua.SOTHUTUTHUA;
                        q.XaPhuong = q.Thua.Xa.TENKVHC;
                    }
                    if (q.MdsdDat != null)
                    {
                        if (q.MdsdDat.MDSD != null && !q.MdsdDat.MDSD.Equals(""))
                        {
                            q.Str_MucDichSDDat += q.MdsdDat.MDSD + ", ";
                            q.DienTich = (decimal)q.MdsdDat.DIENTICH;
                        }
                    }
                    if (q.Str_MucDichSDDat != null)
                    {
                        q.Str_MucDichSDDat = q.Str_MucDichSDDat.Substring(0, q.Str_MucDichSDDat.Length - 2);
                    }
                }
            }

            if (gcn.DSQuyenSHTS != null && gcn.DSQuyenSHTS.Count > 0)
            {
                foreach (var q in gcn.DSQuyenSHTS)
                {
                    if (q.TaiSanGanLienVoiDat != null)
                    {
                        q.LoaiTaiSan = q.TaiSanGanLienVoiDat.LOAITAISAN;
                        q.TenTaiSan = q.TaiSanGanLienVoiDat.TENTAISAN;
                        updateDienTichTaiSan(q);
                        q.LoaiTaiSan = q.TaiSanGanLienVoiDat.LoaiTaiSanGanLienVoiDat.TENLOAITAISANGANLIENVOIDAT;
                    }
                }
            }

            if (gcn.DSQuyenQLDat != null && gcn.DSQuyenQLDat.Count > 0)
            {
                foreach (var q in gcn.DSQuyenQLDat)
                {
                    if (q.Thua != null)
                    {
                        q.SHToBanDo = (decimal)q.Thua.SOHIEUTOBANDO;
                        q.STTThua = (decimal)q.Thua.SOTHUTUTHUA;
                        q.XaPhuong = q.Thua.Xa.TENKVHC;
                    }
                    if (q.MdsdDat != null)
                    {
                        if (q.MdsdDat.MDSD != null && !q.MdsdDat.MDSD.Equals(""))
                        {
                            q.Str_MucDichSDDat += q.MdsdDat.MDSD + ", ";
                            q.DienTich = (decimal)q.MdsdDat.DIENTICH;
                        }
                    }
                    if (q.Str_MucDichSDDat != null)
                    {
                        q.Str_MucDichSDDat = q.Str_MucDichSDDat.Substring(0, q.Str_MucDichSDDat.Length - 2);
                    }
                }
            }

            if (gcn.DSHanChe != null && gcn.DSHanChe.Count > 0)
            {
                foreach (var hanChe in gcn.DSHanChe)
                {
                    if (hanChe.LoaiHanChe != null)
                    {
                        hanChe.TenLoaiHanChe = hanChe.LoaiHanChe.TENLOAIHANCHE;
                    }
                }
            }
        }

        private static void updateDienTichTaiSan(DC_QUYENSOHUUTAISAN q)
        {
            //lấy diện tích của tài sản
            switch (q.LoaiTaiSan)
            {
                case "1"://DC_NHARIENGLE
                    if (q.TaiSanGanLienVoiDat.NhaRiengLe != null)
                        q.DienTich = q.TaiSanGanLienVoiDat.NhaRiengLe.DIENTICHSAN ?? 0.0M;
                    break;
                case "2"://DC_NHACHUNGCU
                case "3":
                    if (q.TaiSanGanLienVoiDat.NhaChungCu != null && q.TaiSanGanLienVoiDat.NhaChungCu.DIENTICHSAN != null)
                        q.DienTich = q.TaiSanGanLienVoiDat.NhaChungCu.DIENTICHSAN ?? 0.0M;
                    break;
                case "4"://DC_CANHO
                    if (q.TaiSanGanLienVoiDat.CanHo != null)
                        if (q.TaiSanGanLienVoiDat.CanHo.DIENTICHSAN != null)
                        {
                            q.DienTich = q.TaiSanGanLienVoiDat.CanHo.DIENTICHSAN ?? 0.0M;
                        }
                    break;
                case "5"://DC_HANGMUCNGOAICANHO
                    if (q.TaiSanGanLienVoiDat.HangMucNgoaiCanHo != null)
                        q.DienTich = q.TaiSanGanLienVoiDat.HangMucNgoaiCanHo.DIENTICH ?? 0.0M;
                    break;
                case "6"://DC_CONGTRINHXAYDUNG
                    if (q.TaiSanGanLienVoiDat.CongTrinhXayDung != null)
                        q.DienTich = q.TaiSanGanLienVoiDat.CongTrinhXayDung.DIENTICHSAN ?? 0.0M;
                    break;
                case "7"://DC_CONGTRINHNGAM
                    if (q.TaiSanGanLienVoiDat.CongTrinhNgam != null)
                        q.DienTich = q.TaiSanGanLienVoiDat.CongTrinhNgam.DIENTICHCONGTRINH ?? 0.0M;
                    break;
                case "8"://DC_HANGMUCCONGTRINH
                    if (q.TaiSanGanLienVoiDat.HangMucCongTrinh != null)
                        q.DienTich = q.TaiSanGanLienVoiDat.HangMucCongTrinh.DIENTICHSAN ?? 0.0M;
                    break;
                case "9"://DC_RUNGTRONG
                    if (q.TaiSanGanLienVoiDat.RungTrong != null)
                        q.DienTich = q.TaiSanGanLienVoiDat.RungTrong.DIENTICH ?? 0.0M;
                    break;
                case "10"://DC_CAYLAUNAM
                    if (q.TaiSanGanLienVoiDat.CayLauNam != null)
                        q.DienTich = q.TaiSanGanLienVoiDat.CayLauNam.DIENTICH ?? 0.0M;
                    break;
                default:
                    break;
            }
        }

        #region "Lưu thông tin giấy chứng nhận"
        public static DC_GIAYCHUNGNHAN CreateNewGCN()
        {
            DC_GIAYCHUNGNHAN gcn = new DC_GIAYCHUNGNHAN();

            using (MplisEntities db = new MplisEntities())
            {
                gcn.GIAYCHUNGNHANID = Guid.NewGuid().ToString();
                gcn.TRANGTHAIXULY = "Y";
                db.Entry(gcn).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }

            return gcn;
        }


        //Clone GCN Đầu Vào thành GCN Đầu Ra:
        //GCN Đầu Vào có trong Đăng Ký hoặc không có trong Đăng Ký (Thêm mới GCN Đầu Vào) đều thực hiện Clone như nhau
        //Khi Clone: Quyền trên GCN được Clone bình thường, Chủ lấy từ GCN gốc, Thửa - MĐSD - TS lấy từ Thửa - MĐSD - TS trong đăng ký và có TrangThaiXuLy là S (đang xử lý)
        public static DC_GIAYCHUNGNHAN CopyGCNToiDauRa(BoHoSoModel bhs, string BDGCNID)
        {
            DC_GIAYCHUNGNHAN gcn = new DC_GIAYCHUNGNHAN();
            DC_QUYENSUDUNGDAT qd;
            DC_QUYENSOHUUTAISAN qts;
            DC_QUYENQUANLYDAT qqld;
            using (MplisEntities db = new MplisEntities())
            {
                foreach (var it in bhs.HoSoTN.BienDong.DSGcn)
                {
                    if (it.BDGCNID.Equals(BDGCNID))
                    {
                        #region Clone Giấy chứng nhận
                        Mapper.Map<DC_GIAYCHUNGNHAN, DC_GIAYCHUNGNHAN>(it.GiayChungNhan, gcn);
                        gcn.GIAYCHUNGNHANID = Guid.NewGuid().ToString();
                        gcn.TRANGTHAIXULY = "S";
                        db.Entry(gcn).State = EntityState.Added;
                        db.SaveChanges();
                        #endregion
                        #region Clone Quyền sử dụng đất trên GCN
                        List<DC_QUYENSUDUNGDAT> listQuyenDat = new List<DC_QUYENSUDUNGDAT>();
                        foreach (var objqd in it.GiayChungNhan.DSQuyenSDDat)
                        {
                            Mapper.Map<DC_QUYENSUDUNGDAT, DC_QUYENSUDUNGDAT>(objqd, qd = new DC_QUYENSUDUNGDAT());
                            qd.QUYENSDDGOCID = qd.QUYENSUDUNGDATID;
                            qd.QUYENSUDUNGDATID = Guid.NewGuid().ToString();
                            qd.GIAYCHUNGNHANID = gcn.GIAYCHUNGNHANID;
                            foreach (var objdkt in bhs.HoSoTN.DonDangKy.DSDangKyThua)
                            {
                                if (objdkt.Thua != null && objdkt.Thua.THUAGOCID == qd.THUADATID)
                                {
                                    qd.THUADATID = objdkt.Thua.THUADATID;
                                    foreach (var objmdsd in objdkt.Thua.DSMucDichSuDungDat)
                                    {
                                        if (objmdsd.MDSDGOCID != null && objmdsd.MDSDGOCID == qd.MUCDICHSUDUNGDATID)
                                        {
                                            qd.MUCDICHSUDUNGDATID = objmdsd.MUCDICHSUDUNGDATID;
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                            db.Entry(qd).State = EntityState.Added;
                            db.SaveChanges();
                            listQuyenDat.Add(qd);
                        }
                        #endregion
                        #region Clone Quyền sở hữu tài sản trên GCN
                        List<DC_QUYENSOHUUTAISAN> listQuyenTS = new List<DC_QUYENSOHUUTAISAN>();
                        foreach (var objqts in it.GiayChungNhan.DSQuyenSHTS)
                        {
                            Mapper.Map<DC_QUYENSOHUUTAISAN, DC_QUYENSOHUUTAISAN>(objqts, qts = new DC_QUYENSOHUUTAISAN());
                            qts.QUYENSHTSGOCID = qts.QUYENSOHUUTAISANID;
                            qts.QUYENSOHUUTAISANID = Guid.NewGuid().ToString();
                            qts.GIAYCHUNGNHANID = gcn.GIAYCHUNGNHANID;
                            foreach (var objdkts in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                            {
                                if (objdkts.TaiSanGanLienVoiDat != null && objdkts.TaiSanGanLienVoiDat.TAISANGOCID == objqts.TAISANGANLIENVOIDATID)
                                {
                                    qts.TAISANGANLIENVOIDATID = objdkts.TaiSanGanLienVoiDat.TAISANGANLIENVOIDATID;
                                    break;
                                }
                            }
                            db.Entry(qts).State = EntityState.Added;
                            db.SaveChanges();
                            listQuyenTS.Add(qts);
                        }
                        #endregion
                        #region Clone Quyền quản lý đất trên GCN
                        List<DC_QUYENQUANLYDAT> listQuyenQLDat = new List<DC_QUYENQUANLYDAT>();
                        foreach (var objQLDat in it.GiayChungNhan.DSQuyenQLDat)
                        {
                            Mapper.Map<DC_QUYENQUANLYDAT, DC_QUYENQUANLYDAT>(objQLDat, qqld = new DC_QUYENQUANLYDAT());
                            qqld.QUYENQLDATGOCID = qqld.QUYENQUANLYDATID;
                            qqld.QUYENQUANLYDATID = Guid.NewGuid().ToString();
                            qqld.GIAYCHUNGNHANID = gcn.GIAYCHUNGNHANID;
                            foreach (var objdkt in bhs.HoSoTN.DonDangKy.DSDangKyThua)
                            {
                                if (objdkt.Thua != null && objdkt.Thua.THUAGOCID == qqld.THUADATID)
                                {
                                    qqld.THUADATID = objdkt.Thua.THUADATID;
                                    foreach (var objmdsd in objdkt.Thua.DSMucDichSuDungDat)
                                    {
                                        if (objmdsd.MDSDGOCID != null && objmdsd.MDSDGOCID == qqld.MUCDICHSUDUNGID)
                                        {
                                            qqld.MUCDICHSUDUNGID = objmdsd.MUCDICHSUDUNGDATID;
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                            db.Entry(qqld).State = EntityState.Added;
                            db.SaveChanges();
                            listQuyenQLDat.Add(qqld);
                        }
                        #endregion

                        DC_BD_GCN bdGCN = Mapper.Map<DC_BD_GCN, DC_BD_GCN>(it);
                        bdGCN.BDGCNID = Guid.NewGuid().ToString();
                        bdGCN.GIAYCHUNGNHANID = gcn.GIAYCHUNGNHANID;
                        bdGCN.GiayChungNhan = gcn;
                        bdGCN.LAGCNVAO = "N";
                        bdGCN.TrangThai = "S";
                        db.Entry(bdGCN).State = EntityState.Added;
                        db.SaveChanges();

                        //Cập nhật lại bhs
                        bdGCN.GiayChungNhan.DSQuyenSDDat = new List<DC_QUYENSUDUNGDAT>(listQuyenDat);
                        bdGCN.GiayChungNhan.DSQuyenSHTS = new List<DC_QUYENSOHUUTAISAN>(listQuyenTS);
                        bdGCN.GiayChungNhan.DSQuyenQLDat = new List<DC_QUYENQUANLYDAT>(listQuyenQLDat);
                        bhs.HoSoTN.BienDong.DSGcn.Add(bdGCN);
                        break;
                    }
                }
                //Cập nhật lại ls_droplist_ttriengGCN cho bhs
                bhs.initListTTRiengGCN();
            }
            return gcn;
        }

        public static void SaveTTChungGiayChungNhan(BoHoSoModel bhs, DC_GIAYCHUNGNHAN gcn)
        {
            using (MplisEntities db = new MplisEntities())
            {
                foreach (var it in bhs.HoSoTN.BienDong.DSGcn)
                {
                    //cập nhật các bản ghi GCN liên quan
                    if (it.GIAYCHUNGNHANID.Equals(gcn.GIAYCHUNGNHANID))
                    {
                        Mapper.Map<DC_GIAYCHUNGNHAN, DC_GIAYCHUNGNHAN>(gcn, it.GiayChungNhan);
                        Mapper.Map<DC_GIAYCHUNGNHAN, DC_GIAYCHUNGNHAN>(gcn, bhs.CurDC_GIAYCHUNGNHAN);
                    }
                }
                db.Entry(gcn).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static bool saveAll(DC_GIAYCHUNGNHAN gcn)
        {
            bool ret = true;

            ret = saveThongTinChung(gcn);

            return ret;
        }

        private static bool saveThongTinChung(DC_GIAYCHUNGNHAN gcn)
        {
            bool ret = true;

            return ret;
        }
        #endregion

        #region "Xóa Giấy chứng nhận và các đối tượng liên quan"
        public static void DeleteGiayChungNhan(DC_GIAYCHUNGNHAN gcn)
        {
            using (MplisEntities db = new MplisEntities())
            {
                if (gcn.QHGcn_Gcn != null)
                {
                    foreach (var it in gcn.QHGcn_Gcn)
                    {
                        db.Entry(it).State = EntityState.Deleted;
                    }
                }
                if (gcn.DSQuyenSDDat != null)
                {
                    foreach (var it in gcn.DSQuyenSDDat)
                    {
                        db.Entry(it).State = EntityState.Deleted;
                    }
                }
                if (gcn.DSQuyenSHTS != null)
                {
                    foreach (var it in gcn.DSQuyenSHTS)
                    {
                        db.Entry(it).State = EntityState.Deleted;
                    }
                }
                db.Entry(gcn).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
        #endregion

        #region "Quyền sử dụng đất"

        public static void addQuyenSDDTheoThuaDatVaoGCN(string[] dsThuaID, string gcnID, BoHoSoModel bhs)
        {
            DC_GIAYCHUNGNHAN gcn = null;
            DC_THUADAT thuaDat = null;
            if (dsThuaID != null && dsThuaID.Count() > 0)
            {
                //Kiểm tra Danh sách gcn trong biến động có gcn với ID = gcnID hay không?
                foreach (var objBDGCN in bhs.HoSoTN.BienDong.DSGcn)
                {
                    if (objBDGCN.GIAYCHUNGNHANID.Equals(gcnID))
                    {
                        gcn = objBDGCN.GiayChungNhan;
                        break;
                    }
                }
                //Có gcn với ID khớp với gcnID gửi lên:
                if (gcn != null)
                {
                    //Duyệt qua danh sách thửa:
                    foreach (var thuaID in dsThuaID)
                    {
                        thuaDat = null;
                        //Kiểm tra Danh sách thửa trong đăng ký có Thua với ID = thuaID hay không?
                        foreach (var objDangKyThua in bhs.HoSoTN.DonDangKy.DSDangKyThua)
                        {
                            if (objDangKyThua.THUADATID.Equals(thuaID))
                            {
                                thuaDat = objDangKyThua.Thua;
                                break;
                            }
                        }
                        //Có Thua với ID khớp với thuaID gửi lên:
                        if (thuaDat != null)
                        {
                            //Kiểm tra DSQuyenSDDat trong gcn:
                            if (gcn.DSQuyenSDDat == null)
                            {
                                gcn.DSQuyenSDDat = new List<DC_QUYENSUDUNGDAT>();
                            }
                            //Duyệt qua Danh sách MDSD của thuaDat:
                            foreach (var objMDSD in thuaDat.DSMucDichSuDungDat)
                            {
                                //Kiểm tra DSQuyenSDDat trong gcn đã tồn tại MDSDDAT hay chưa?
                                var check = gcn.DSQuyenSDDat.Where(it => it.MUCDICHSUDUNGDATID.Equals(objMDSD.MUCDICHSUDUNGDATID)).FirstOrDefault();
                                //Không tồn tại: thực hiện thêm quyền:
                                if (check == null)
                                {
                                    DC_QUYENSUDUNGDAT objQSDD = new DC_QUYENSUDUNGDAT();
                                    objQSDD.QUYENSUDUNGDATID = Guid.NewGuid().ToString();
                                    objQSDD.MUCDICHSUDUNGDATID = objMDSD.MUCDICHSUDUNGDATID;
                                    objQSDD.THUADATID = thuaDat.THUADATID;
                                    objQSDD.NGUOIID = gcn.NGUOIID;
                                    objQSDD.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
                                    objQSDD.DienTich = (decimal)objMDSD.DIENTICH;
                                    objQSDD.GIAYCHUNGNHANID = gcn.GIAYCHUNGNHANID;
                                    objQSDD.Str_MucDichSDDat = objMDSD.MDSD;
                                    objQSDD.SHToBanDo = (decimal)thuaDat.SOHIEUTOBANDO;
                                    objQSDD.STTThua = (decimal)thuaDat.SOTHUTUTHUA;
                                    objQSDD.Thua = thuaDat;
                                    objQSDD.Chu = gcn.Chu;
                                    objQSDD.MdsdDat = objMDSD;
                                    objQSDD.XaPhuong = thuaDat.Xa.TENKVHC;
                                    gcn.DSQuyenSDDat.Add(objQSDD);
                                }
                            }
                        }
                    }
                    bhs.CurDC_GIAYCHUNGNHAN = gcn;
                }
            }
        }

        public static void addQuyenSDDTheoMDSDDatVaoGCN(string[] dsMDSDID, string gcnID, BoHoSoModel bhs)
        {
            DC_GIAYCHUNGNHAN gcn = null;
            DC_THUADAT thuaDat;
            DC_MUCDICHSUDUNGDAT MDSDDat = null;
            bool found;
            if (dsMDSDID != null && dsMDSDID.Count() > 0)
            {
                foreach (var bdGCN in bhs.HoSoTN.BienDong.DSGcn)
                {
                    if (bdGCN.GIAYCHUNGNHANID.Equals(gcnID))
                    {
                        gcn = bdGCN.GiayChungNhan;
                        break;
                    }
                }
                if (gcn != null)
                {
                    foreach (var mdsdID in dsMDSDID)
                    {
                        MDSDDat = null;
                        found = false;
                        thuaDat = null;
                        foreach (var dangKyThua in bhs.HoSoTN.DonDangKy.DSDangKyThua)
                        {
                            foreach (var mdsd in dangKyThua.Thua.DSMucDichSuDungDat)
                            {
                                if (mdsd.MUCDICHSUDUNGDATID.Equals(mdsdID))
                                {
                                    MDSDDat = mdsd;
                                    thuaDat = dangKyThua.Thua;
                                    found = true;
                                    break;
                                }
                            }
                            if (found)
                            {
                                break;
                            }
                        }
                        if (MDSDDat != null)
                        {
                            if (gcn.DSQuyenSDDat == null)
                            {
                                gcn.DSQuyenSDDat = new List<DC_QUYENSUDUNGDAT>();
                            }
                            var check = gcn.DSQuyenSDDat.Where(it => it.MUCDICHSUDUNGDATID.Equals(MDSDDat.MUCDICHSUDUNGDATID)).FirstOrDefault();
                            if (check == null)
                            {
                                DC_QUYENSUDUNGDAT objQSDD = new DC_QUYENSUDUNGDAT();
                                objQSDD.QUYENSUDUNGDATID = Guid.NewGuid().ToString();
                                objQSDD.MUCDICHSUDUNGDATID = MDSDDat.MUCDICHSUDUNGDATID;
                                objQSDD.THUADATID = MDSDDat.THUADATID;
                                objQSDD.NGUOIID = gcn.NGUOIID;
                                objQSDD.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
                                objQSDD.DienTich = (decimal)MDSDDat.DIENTICH;
                                objQSDD.GIAYCHUNGNHANID = gcn.GIAYCHUNGNHANID;
                                objQSDD.Str_MucDichSDDat = MDSDDat.MDSD;
                                objQSDD.SHToBanDo = (decimal)thuaDat.SOHIEUTOBANDO;
                                objQSDD.STTThua = (decimal)thuaDat.SOTHUTUTHUA;
                                objQSDD.Thua = thuaDat;
                                objQSDD.Chu = gcn.Chu;
                                objQSDD.MdsdDat = MDSDDat;
                                objQSDD.XaPhuong = thuaDat.Xa.TENKVHC;
                                gcn.DSQuyenSDDat.Add(objQSDD);
                            }
                        }
                    }
                    bhs.CurDC_GIAYCHUNGNHAN = gcn;
                }
            }
        }

        public static void removeQuyenSDDatInGCN(string quyenSDDATID, string gcnID, BoHoSoModel bhs)
        {
            foreach (var qSDD in bhs.CurDC_GIAYCHUNGNHAN.DSQuyenSDDat)
            {
                if (qSDD.GIAYCHUNGNHANID.Equals(gcnID))
                {
                    bhs.CurDC_GIAYCHUNGNHAN.DSQuyenSDDat.Remove(qSDD);
                    break;
                }
            }
        }

        public static void updateDSQuyenSDDatInGCN(string gcnID, BoHoSoModel bhs)
        {
            DC_GIAYCHUNGNHAN gcn = null;
            foreach (var bdGCN in bhs.HoSoTN.BienDong.DSGcn)
            {
                if (bdGCN.GIAYCHUNGNHANID.Equals(gcnID))
                {
                    gcn = bdGCN.GiayChungNhan;
                    break;
                }
            }
            if (gcn != null)
            {
                using (MplisEntities db = new MplisEntities())
                {
                    var listQSDD = db.DC_QUYENSUDUNGDAT.Where(it => it.GIAYCHUNGNHANID.Equals(gcn.GIAYCHUNGNHANID)).ToList();
                    if (listQSDD != null)
                    {
                        //Delete DC_QUYENSUDUNGDAT theo GCNID
                        foreach (var objQSDD in listQSDD)
                        {
                            db.Entry(objQSDD).State = EntityState.Deleted;
                        }
                        //Add DC_QUYENSUDUNGDAT
                        foreach (var objQSDD in gcn.DSQuyenSDDat)
                        {
                            db.Entry(Mapper.Map<DC_QUYENSUDUNGDAT, DC_QUYENSUDUNGDAT>(objQSDD)).State = EntityState.Added;
                        }
                        db.SaveChanges();
                    }
                }
            }

        }

        #endregion

        #region "Quyền sở hữu tài sản"

        public static void addQuyenSHTSVaoGCN(string[] dSTaiSanID, string gcnID, BoHoSoModel bhs)
        {
            DC_GIAYCHUNGNHAN gcn = null;
            DC_TAISANGANLIENVOIDAT taiSan;
            bool found;
            if (dSTaiSanID != null)
            {
                foreach (var bdGCN in bhs.HoSoTN.BienDong.DSGcn)
                {
                    if (bdGCN.GIAYCHUNGNHANID.Equals(gcnID))
                    {
                        gcn = bdGCN.GiayChungNhan;
                        break;
                    }
                }
                if (gcn != null)
                {
                    foreach (var taiSanID in dSTaiSanID)
                    {
                        found = false;
                        foreach (var qSHTS in gcn.DSQuyenSHTS)
                        {
                            if (qSHTS.TAISANGANLIENVOIDATID.Equals(taiSanID))
                            {
                                found = true;
                                break;
                            }
                        }
                        taiSan = null;
                        foreach (var taiSanTemp in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                        {
                            if (taiSanTemp.TaiSanGanLienVoiDat.TAISANGANLIENVOIDATID.Equals(taiSanID))
                            {
                                taiSan = taiSanTemp.TaiSanGanLienVoiDat;
                                break;
                            }
                        }
                        if (!found && taiSan != null)
                        {
                            DC_QUYENSOHUUTAISAN objTaiSan = new DC_QUYENSOHUUTAISAN();
                            objTaiSan.QUYENSOHUUTAISANID = Guid.NewGuid().ToString();
                            objTaiSan.TAISANGANLIENVOIDATID = taiSanID;
                            objTaiSan.NGUOIID = gcn.NGUOIID;
                            objTaiSan.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
                            objTaiSan.GIAYCHUNGNHANID = gcn.GIAYCHUNGNHANID;
                            objTaiSan.TenTaiSan = taiSan.TENTAISAN;
                            objTaiSan.LoaiTaiSan = taiSan.LoaiTaiSanGanLienVoiDat.TENLOAITAISANGANLIENVOIDAT;
                            objTaiSan.Chu = gcn.Chu;
                            objTaiSan.TaiSanGanLienVoiDat = taiSan;
                            gcn.DSQuyenSHTS.Add(objTaiSan);
                        }
                    }
                    bhs.CurDC_GIAYCHUNGNHAN = gcn;
                }
            }
        }

        public static void removeQuyenSHTSInGCN(string quyenSHTSID, string gcnID, BoHoSoModel bhs)
        {
            foreach (var qSHTS in bhs.CurDC_GIAYCHUNGNHAN.DSQuyenSHTS)
            {
                if (qSHTS.QUYENSOHUUTAISANID.Equals(quyenSHTSID))
                {
                    bhs.CurDC_GIAYCHUNGNHAN.DSQuyenSHTS.Remove(qSHTS);
                    break;
                }
            }
        }

        public static void updateDSQuyenSHTSInGCN(string gcnID, BoHoSoModel bhs)
        {
            DC_GIAYCHUNGNHAN gcn = null;
            foreach (var bdGCN in bhs.HoSoTN.BienDong.DSGcn)
            {
                if (bdGCN.GIAYCHUNGNHANID.Equals(gcnID))
                {
                    gcn = bdGCN.GiayChungNhan;
                    break;
                }
            }
            if (gcn != null)
            {
                using (MplisEntities db = new MplisEntities())
                {
                    var listQSHTS = db.DC_QUYENSOHUUTAISAN.Where(it => it.GIAYCHUNGNHANID.Equals(gcn.GIAYCHUNGNHANID)).ToList();
                    if (listQSHTS != null)
                    {
                        //Delete DC_QUYENSUDUNGDAT theo GCNID
                        foreach (var objQSHTS in listQSHTS)
                        {
                            db.Entry(objQSHTS).State = EntityState.Deleted;
                        }
                        //Add DC_QUYENSOHUUTAISAN
                        foreach (var objQSHTS in gcn.DSQuyenSHTS)
                        {
                            db.Entry(Mapper.Map<DC_QUYENSOHUUTAISAN, DC_QUYENSOHUUTAISAN>(objQSHTS)).State = EntityState.Added;
                        }
                        db.SaveChanges();
                    }
                }
            }
        }
        public static List<DC_GIAYCHUNGNHAN> getGCNSHC(string gcnshcID)
        {
            List<DC_GIAYCHUNGNHAN> dsSoHuuChung = new List<DC_GIAYCHUNGNHAN>();
            using (MplisEntities db = new MplisEntities())
            {
                var dsSoHuu = (from a in db.DC_GIAYCHUNGNHAN where a.SOHUUCHUNGID == gcnshcID select a).ToList();
                foreach (var item in dsSoHuu)
                {
                    var b = getGiayChungNhan(item.GIAYCHUNGNHANID);
                    dsSoHuuChung.Add(b);
                }
            }
            return dsSoHuuChung;
        }
        public static void AddGCNDK(BoHoSoModel bhs, DC_GIAYCHUNGNHAN objGCN)
        {

            DC_DANGKY_GCN objdangky = new DC_DANGKY_GCN();
            objdangky.DANGKYGCNID = Guid.NewGuid().ToString();
            objdangky.GIAYCHUNGNHANID = objGCN.GIAYCHUNGNHANID;
            objdangky.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
            objdangky.GiayChungNhan = objGCN;
            objdangky.SoPhatHanh = objGCN.SOPHATHANH;
            objdangky.MaVach = objGCN.MAVACH;
            objdangky.TrangThai = objGCN.TRANGTHAIXULY;
            objdangky.themxoa = 1;
            bhs.HoSoTN.DonDangKy.DSDangKyGCN.Add(objdangky);
            if (objGCN.SOHUUCHUNGID != null)
            {
                List<DC_GIAYCHUNGNHAN> dsdongsohuu = getGCNSHC(objGCN.SOHUUCHUNGID);
                foreach (var item in dsdongsohuu)
                {
                    DC_DANGKY_GCN objkiemtra = (from a in bhs.HoSoTN.DonDangKy.DSDangKyGCN where a.GIAYCHUNGNHANID == item.GIAYCHUNGNHANID select a).FirstOrDefault();
                    if (objkiemtra != null)
                    {
                        DC_DANGKY_GCN objdangkyshc = new DC_DANGKY_GCN();
                        objdangkyshc.DANGKYGCNID = Guid.NewGuid().ToString();
                        objdangkyshc.GIAYCHUNGNHANID = item.GIAYCHUNGNHANID;
                        objdangkyshc.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
                        objdangkyshc.GiayChungNhan = item;
                        objdangkyshc.SoPhatHanh = item.SOPHATHANH;
                        objdangkyshc.MaVach = item.MAVACH;
                        objdangkyshc.TrangThai = item.TRANGTHAIXULY;
                        objdangkyshc.themxoa = 1;
                        bhs.HoSoTN.DonDangKy.DSDangKyGCN.Add(objdangkyshc);
                    }
                }
            }
        }
        #endregion

        #region Quyền quản lý đất

        public static void addQuyenQLDTheoThuaDatVaoGCN(string[] dsThuaID, string gcnID, BoHoSoModel bhs)
        {
            DC_GIAYCHUNGNHAN gcn = null;
            DC_THUADAT thuaDat = null;
            if (dsThuaID != null && dsThuaID.Count() > 0)
            {
                //Kiểm tra Danh sách gcn trong biến động có gcn với ID = gcnID hay không?
                foreach (var objBDGCN in bhs.HoSoTN.BienDong.DSGcn)
                {
                    if (objBDGCN.GIAYCHUNGNHANID.Equals(gcnID))
                    {
                        gcn = objBDGCN.GiayChungNhan;
                        break;
                    }
                }
                //Có gcn với ID khớp với gcnID gửi lên:
                if (gcn != null)
                {
                    //Duyệt qua danh sách thửa:
                    foreach (var thuaID in dsThuaID)
                    {
                        thuaDat = null;
                        //Kiểm tra Danh sách thửa trong đăng ký có Thua với ID = thuaID hay không?
                        foreach (var objDangKyThua in bhs.HoSoTN.DonDangKy.DSDangKyThua)
                        {
                            if (objDangKyThua.THUADATID.Equals(thuaID))
                            {
                                thuaDat = objDangKyThua.Thua;
                                break;
                            }
                        }
                        //Có Thua với ID khớp với thuaID gửi lên:
                        if (thuaDat != null)
                        {
                            //Kiểm tra DSQuyenSDDat trong gcn:
                            if (gcn.DSQuyenQLDat == null)
                            {
                                gcn.DSQuyenQLDat = new List<DC_QUYENQUANLYDAT>();
                            }
                            //Duyệt qua Danh sách MDSD của thuaDat:
                            foreach (var objMDSD in thuaDat.DSMucDichSuDungDat)
                            {
                                //Kiểm tra DSQuyenSDDat trong gcn đã tồn tại MDSDDAT hay chưa?
                                var check = gcn.DSQuyenQLDat.Where(it => it.MUCDICHSUDUNGID.Equals(objMDSD.MUCDICHSUDUNGDATID)).FirstOrDefault();
                                //Không tồn tại: thực hiện thêm quyền:
                                if (check == null)
                                {
                                    DC_QUYENQUANLYDAT objQQLD = new DC_QUYENQUANLYDAT();
                                    objQQLD.QUYENQUANLYDATID = Guid.NewGuid().ToString();
                                    objQQLD.MUCDICHSUDUNGID = objMDSD.MUCDICHSUDUNGDATID;
                                    objQQLD.THUADATID = thuaDat.THUADATID;
                                    objQQLD.NGUOIID = gcn.NGUOIID;
                                    objQQLD.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
                                    objQQLD.DienTich = (decimal)objMDSD.DIENTICH;
                                    objQQLD.GIAYCHUNGNHANID = gcn.GIAYCHUNGNHANID;
                                    objQQLD.Str_MucDichSDDat = objMDSD.MDSD;
                                    objQQLD.SHToBanDo = (decimal)thuaDat.SOHIEUTOBANDO;
                                    objQQLD.STTThua = (decimal)thuaDat.SOTHUTUTHUA;
                                    objQQLD.Thua = thuaDat;
                                    objQQLD.Chu = gcn.Chu;
                                    objQQLD.MdsdDat = objMDSD;
                                    objQQLD.XaPhuong = thuaDat.Xa.TENKVHC;
                                    gcn.DSQuyenQLDat.Add(objQQLD);
                                }
                            }
                        }
                    }
                    bhs.CurDC_GIAYCHUNGNHAN = gcn;
                }
            }
        }

        public static void addQuyenQLDTheoMDSDDatVaoGCN(string[] dsMDSDID, string gcnID, BoHoSoModel bhs)
        {
            DC_GIAYCHUNGNHAN gcn = null;
            DC_THUADAT thuaDat;
            DC_MUCDICHSUDUNGDAT MDSDDat = null;
            bool found;
            if (dsMDSDID != null && dsMDSDID.Count() > 0)
            {
                foreach (var bdGCN in bhs.HoSoTN.BienDong.DSGcn)
                {
                    if (bdGCN.GIAYCHUNGNHANID.Equals(gcnID))
                    {
                        gcn = bdGCN.GiayChungNhan;
                        break;
                    }
                }
                if (gcn != null)
                {
                    foreach (var mdsdID in dsMDSDID)
                    {
                        MDSDDat = null;
                        found = false;
                        thuaDat = null;
                        foreach (var dangKyThua in bhs.HoSoTN.DonDangKy.DSDangKyThua)
                        {
                            foreach (var mdsd in dangKyThua.Thua.DSMucDichSuDungDat)
                            {
                                if (mdsd.MUCDICHSUDUNGDATID.Equals(mdsdID))
                                {
                                    MDSDDat = mdsd;
                                    thuaDat = dangKyThua.Thua;
                                    found = true;
                                    break;
                                }
                            }
                            if (found)
                            {
                                break;
                            }
                        }
                        if (MDSDDat != null)
                        {
                            if (gcn.DSQuyenQLDat == null)
                            {
                                gcn.DSQuyenQLDat = new List<DC_QUYENQUANLYDAT>();
                            }
                            var check = gcn.DSQuyenQLDat.Where(it => it.MUCDICHSUDUNGID.Equals(MDSDDat.MUCDICHSUDUNGDATID)).FirstOrDefault();
                            if (check == null)
                            {
                                DC_QUYENQUANLYDAT objQQLD = new DC_QUYENQUANLYDAT();
                                objQQLD.QUYENQUANLYDATID = Guid.NewGuid().ToString();
                                objQQLD.MUCDICHSUDUNGID = MDSDDat.MUCDICHSUDUNGDATID;
                                objQQLD.THUADATID = MDSDDat.THUADATID;
                                objQQLD.NGUOIID = gcn.NGUOIID;
                                objQQLD.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
                                objQQLD.DienTich = (decimal)MDSDDat.DIENTICH;
                                objQQLD.GIAYCHUNGNHANID = gcn.GIAYCHUNGNHANID;
                                objQQLD.Str_MucDichSDDat = MDSDDat.MDSD;
                                objQQLD.SHToBanDo = (decimal)thuaDat.SOHIEUTOBANDO;
                                objQQLD.STTThua = (decimal)thuaDat.SOTHUTUTHUA;
                                objQQLD.Thua = thuaDat;
                                objQQLD.Chu = gcn.Chu;
                                objQQLD.MdsdDat = MDSDDat;
                                objQQLD.XaPhuong = thuaDat.Xa.TENKVHC;
                                gcn.DSQuyenQLDat.Add(objQQLD);
                            }
                        }
                    }
                    bhs.CurDC_GIAYCHUNGNHAN = gcn;
                }
            }
        }

        public static void removeQuyenQLDatInGCN(string quyenSDDATID, string gcnID, BoHoSoModel bhs)
        {
            foreach (var qQLD in bhs.CurDC_GIAYCHUNGNHAN.DSQuyenQLDat)
            {
                if (qQLD.GIAYCHUNGNHANID.Equals(gcnID))
                {
                    bhs.CurDC_GIAYCHUNGNHAN.DSQuyenQLDat.Remove(qQLD);
                    break;
                }
            }
        }

        public static void updateDSQuyenQLDatInGCN(string gcnID, BoHoSoModel bhs)
        {
            DC_GIAYCHUNGNHAN gcn = null;
            foreach (var bdGCN in bhs.HoSoTN.BienDong.DSGcn)
            {
                if (bdGCN.GIAYCHUNGNHANID.Equals(gcnID))
                {
                    gcn = bdGCN.GiayChungNhan;
                    break;
                }
            }
            if (gcn != null)
            {
                using (MplisEntities db = new MplisEntities())
                {
                    var listQQLD = db.DC_QUYENQUANLYDAT.Where(it => it.GIAYCHUNGNHANID.Equals(gcn.GIAYCHUNGNHANID)).ToList();
                    if (listQQLD != null)
                    {
                        //Delete DC_QUYENQUANLYDAT theo GCNID
                        foreach (var objQQLD in listQQLD)
                        {
                            db.Entry(objQQLD).State = EntityState.Deleted;
                        }
                        //Add DC_QUYENQUANLYDAT
                        foreach (var objQQLD in gcn.DSQuyenQLDat)
                        {
                            db.Entry(Mapper.Map<DC_QUYENQUANLYDAT, DC_QUYENQUANLYDAT>(objQQLD)).State = EntityState.Added;
                        }
                        db.SaveChanges();
                    }
                }
            }

        }

        #endregion

        #region  Xem giấy chứng nhận
        public static DC_GIAYCHUNGNHAN getGCN_byThua(string xaid, string sothututhua, string sotobando)
        {
            DC_GIAYCHUNGNHAN ret = new DC_GIAYCHUNGNHAN();

            using (MplisEntities db = new MplisEntities())
            {
                decimal soto = decimal.Parse(sotobando);
                decimal sothua = decimal.Parse(sothututhua);
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;
                var objthua = (from item in db.DC_THUADAT where item.SOTHUTUTHUA == sothua && item.SOHIEUTOBANDO == soto && item.XAID == xaid select item).FirstOrDefault();
                if (objthua != null)
                {
                    ret.DSQuyenSDDat = (from item in db.DC_QUYENSUDUNGDAT
                                        where item.THUADATID == objthua.THUADATID
                                        select item).ToList();

                    if (ret.DSQuyenSDDat.Count > 0)
                    {
                        string gcnid = ret.DSQuyenSDDat.FirstOrDefault().GIAYCHUNGNHANID;
                        ret.GIAYCHUNGNHANID = gcnid;
                        string nguoiid = ret.DSQuyenSDDat.FirstOrDefault().NGUOIID;
                        string thuaid = ret.DSQuyenSDDat.FirstOrDefault().THUADATID;
                        ret = (from item in db.DC_GIAYCHUNGNHAN where item.GIAYCHUNGNHANID == gcnid select item).FirstOrDefault();

                        //ret.Chu = new DC_NGUOI();
                        var objnguoi = new DC_NGUOI();
                        objnguoi = DCNGUOIServices.getChu(nguoiid);
                        ret.Chu = objnguoi;
                        ret.DSQuyenSDDat = (from item in db.DC_QUYENSUDUNGDAT
                                            where item.THUADATID == objthua.THUADATID
                                            select item).ToList();
                        ret.DSQuyenSHTS = (from item in db.DC_QUYENSOHUUTAISAN
                                           where item.GIAYCHUNGNHANID == gcnid
                                           select item).ToList();
                        foreach (var item in ret.DSQuyenSDDat)
                        {
                            item.Thua = DCTHUADATServices.getThuaDat(item.THUADATID);
                        }
                        //tài sản gắn liền với đất

                        foreach (var item in ret.DSQuyenSHTS)
                        {
                            item.DC_TAISANGANLIENVOIDAT = DCTAISANGANLIENVOIDATServices.getTaiSanGanLienVoiDat(item.TAISANGANLIENVOIDATID);
                        }
                    }
                    else
                    {
                        //ret.DSQuyenSDDat = new List<DC_QUYENSUDUNGDAT>();
                        //ret.DSQuyenSDDat[0].Thua = new DC_THUADAT();
                        //ret.DSQuyenSDDat[0].Thua = objthua;
                    }
                }
            }

            return ret;
        }
        public static string returngioitinh(decimal? gioitinh)
        {
            string str = "";
            if (gioitinh == 0)
            {
                str = "Bà: ";
            }
            else
            {
                str = "Ông: ";
            }
            return str;
        }
        public static string number2Text(string sNumber)
        {
            int mLen, i, mDigit;
            string mTemp = null;
            string[] mNumText = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };

            mLen = sNumber.Length;
            for (i = 1; i <= mLen; i++)
            {
                mDigit = int.Parse(sNumber.Substring(i - 1, 1));
                if (mTemp == null)
                    mTemp = mNumText[mDigit];
                else
                    mTemp += " " + mNumText[mDigit];
                if (mLen == i) break;
                switch ((mLen - i) % 9)
                {
                    case 0:
                        mTemp = mTemp + " tỷ";
                        if (sNumber.Substring(i, 3) == "000") i += 3;
                        if (sNumber.Substring(i, 3) == "000") i += 3;
                        if (sNumber.Substring(i, 3) == "000") i += 3;
                        break;
                    case 6:
                        mTemp = mTemp + " triệu";
                        if (sNumber.Substring(i, 3) == "000") i += 3;
                        if (sNumber.Substring(i, 3) == "000") i += 3;
                        break;
                    case 3:
                        mTemp = mTemp + " nghìn";
                        if (sNumber.Substring(i, 3) == "000") i += 3;
                        break;
                    default:
                        switch ((mLen - i) % 3)
                        {
                            case 2:
                                mTemp = mTemp + " trăm";
                                break;
                            case 1:
                                mTemp = mTemp + " mươi";
                                break;
                        }
                        break;
                }
            }
            if (mTemp != null)
            {
                //Loại bỏ trường hợp x00
                mTemp = mTemp.Replace("không mươi không", "");
                //Loại bỏ trường hợp 00x
                mTemp = mTemp.Replace("không mươi ", "linh ");
                //Loại bỏ trường hợp x0, x>=2
                mTemp = mTemp.Replace("mươi không", "mươi");
                //Fix trường hợp 10
                mTemp = mTemp.Replace("một mươi", "mười");
                //Fix trường hợp x4, x>=2
                mTemp = mTemp.Replace("mươi bốn", "mươi tư");
                //Fix trường hợp x04 
                mTemp = mTemp.Replace("linh bốn", "linh tư");
                //Fix trường hợp x5, x>=2
                mTemp = mTemp.Replace("mươi năm", "mươi lăm");
                //Fix trường hợp x1, x>=2
                mTemp = mTemp.Replace("mươi một", "mươi mốt");
                //Fix trường hợp x15
                mTemp = mTemp.Replace("mười năm", "mười lăm");
                //Bỏ ký tự space
                mTemp = mTemp.Trim();
                //Ucase ký tự đầu tiên
            }
            return mTemp;
            //return mTemp; //UCase(Left(mTemp, 1)) & Mid(mTemp, 2);
        }
        public static giaychungnhan getGCN_inGCN(DC_GIAYCHUNGNHAN objgcn, string xaid, string sothua, string soto)
        {
            giaychungnhan gcn = new giaychungnhan();
            gcn.mavach = objgcn.MAVACH;
            gcn.G_ghichu = objgcn.GHICHU;
            gcn.G_sovaoso = objgcn.SOVAOSO;
            //chủ
            if (objgcn.Chu != null)
            {
                if (objgcn.Chu.LOAIDOITUONGID == "1")
                {

                    gcn.TENCHU1 = returngioitinh(objgcn.Chu.CaNhan.GIOITINH) + objgcn.Chu.CaNhan.HOTEN + " " + objgcn.Chu.CaNhan.TEN;
                    gcn.socmtchu1 = objgcn.Chu.CaNhan.SOGIAYTO == null ? "" : "Số CMT: " + objgcn.Chu.CaNhan.SOGIAYTO;
                    if (objgcn.Chu.CaNhan.NGAYCAP != null)
                    {
                        gcn.ngaycmtchu1 = "Cấp Ngày: " + objgcn.Chu.CaNhan.NGAYCAP.Value.ToString("dd/mm/yyyy");
                    }
                    else
                    {
                        gcn.ngaycmtchu1 = "";
                    }
                    gcn.sinhnamchu1 = objgcn.Chu.CaNhan.NAMSINH == null ? "" : "Sinh năm: " + objgcn.Chu.CaNhan.NAMSINH;
                    gcn.noicmtchu1 = objgcn.Chu.CaNhan.NOICAP == null ? "" : "Cấp tại: " + objgcn.Chu.CaNhan.NOICAP;
                    gcn.diachichu1 = objgcn.Chu.CaNhan.DIACHI == null ? "" : "Địa chỉ: " + objgcn.Chu.CaNhan.DIACHI;
                }
                // hộ gia đình
                else if (objgcn.Chu.LOAIDOITUONGID == "2")
                {
                    gcn.TENCHU1 = returngioitinh(objgcn.Chu.HoGiaDinh.ChuHoCN.GIOITINH) + objgcn.Chu.HoGiaDinh.ChuHoCN.HOTEN + " " + objgcn.Chu.HoGiaDinh.ChuHoCN.TEN;
                    gcn.socmtchu1 = objgcn.Chu.HoGiaDinh.ChuHoCN.SOGIAYTO == null ? "" : "Số CMT: " + objgcn.Chu.HoGiaDinh.ChuHoCN.SOGIAYTO;
                    if (objgcn.Chu.HoGiaDinh.ChuHoCN.NGAYCAP != null)
                    {
                        gcn.ngaycmtchu1 = "Cấp Ngày: " + objgcn.Chu.HoGiaDinh.ChuHoCN.NGAYCAP.Value.ToString("dd/mm/yyyy");
                    }
                    else
                    {
                        gcn.ngaycmtchu1 = "";
                    }
                    gcn.noicmtchu1 = objgcn.Chu.HoGiaDinh.ChuHoCN.NOICAP == null ? "" : "Cấp tại: " + objgcn.Chu.HoGiaDinh.ChuHoCN.NOICAP;
                    gcn.diachichu1 = objgcn.Chu.HoGiaDinh.ChuHoCN.DIACHI == null ? "" : "Địa chỉ: " + objgcn.Chu.HoGiaDinh.ChuHoCN.DIACHI;
                    gcn.sinhnamchu1 = objgcn.Chu.HoGiaDinh.ChuHoCN.NAMSINH == null ? "" : "Sinh năm: " + objgcn.Chu.HoGiaDinh.ChuHoCN.NAMSINH;

                    gcn.TENCHU2 = returngioitinh(objgcn.Chu.HoGiaDinh.VoChongCN.GIOITINH) + objgcn.Chu.HoGiaDinh.VoChongCN.HOTEN + " " + objgcn.Chu.HoGiaDinh.VoChongCN.TEN;
                    gcn.socmtchu2 = objgcn.Chu.HoGiaDinh.VoChongCN.SOGIAYTO == null ? "" : "Số CMT: " + objgcn.Chu.HoGiaDinh.VoChongCN.SOGIAYTO;
                    if (objgcn.Chu.HoGiaDinh.VoChongCN.NGAYCAP != null)
                    {
                        gcn.ngaycmtchu2 = "Cấp Ngày: " + objgcn.Chu.HoGiaDinh.VoChongCN.NGAYCAP.Value.ToString("dd/mm/yyyy");
                    }
                    else
                    {
                        gcn.ngaycmtchu2 = "";
                    }
                    gcn.noicmtchu2 = objgcn.Chu.HoGiaDinh.VoChongCN.NOICAP == null ? "" : "Cấp tại: " + objgcn.Chu.HoGiaDinh.VoChongCN.NOICAP;
                    gcn.diachichu2 = objgcn.Chu.HoGiaDinh.VoChongCN.DIACHI == null ? "" : "Địa chỉ: " + objgcn.Chu.HoGiaDinh.VoChongCN.DIACHI;
                    gcn.sinhnamchu2 = objgcn.Chu.HoGiaDinh.VoChongCN.NAMSINH == null ? "" : "Sinh năm: " + objgcn.Chu.HoGiaDinh.VoChongCN.NAMSINH;

                }
                else if (objgcn.Chu.LOAIDOITUONGID == "3")
                {
                    gcn.TENCHU1 = returngioitinh(objgcn.Chu.VoChong.ChongCN.GIOITINH) + objgcn.Chu.VoChong.ChongCN.HOTEN + " " + objgcn.Chu.VoChong.ChongCN.TEN;
                    gcn.socmtchu1 = objgcn.Chu.VoChong.ChongCN.SOGIAYTO == null ? "" : "Số CMT: " + objgcn.Chu.VoChong.ChongCN.SOGIAYTO;
                    if (objgcn.Chu.VoChong.ChongCN.NGAYCAP != null)
                    {
                        gcn.ngaycmtchu1 = "Cấp Ngày: " + objgcn.Chu.VoChong.ChongCN.NGAYCAP.Value.ToString("dd/mm/yyyy");
                    }
                    else
                    {
                        gcn.ngaycmtchu1 = "";
                    }
                    gcn.noicmtchu1 = objgcn.Chu.VoChong.ChongCN.NOICAP == null ? "" : "Cấp tại: " + objgcn.Chu.VoChong.ChongCN.NOICAP;
                    gcn.diachichu1 = objgcn.Chu.VoChong.ChongCN.DIACHI == null ? "" : "Địa chỉ: " + objgcn.Chu.VoChong.ChongCN.DIACHI;
                    gcn.sinhnamchu1 = objgcn.Chu.VoChong.ChongCN.NAMSINH == null ? "" : "Sinh năm: " + objgcn.Chu.VoChong.ChongCN.NAMSINH;

                    gcn.TENCHU2 = returngioitinh(objgcn.Chu.VoChong.VoCN.GIOITINH) + objgcn.Chu.VoChong.VoCN.HOTEN + " " + objgcn.Chu.VoChong.VoCN.TEN;
                    gcn.socmtchu2 = objgcn.Chu.VoChong.VoCN.SOGIAYTO == null ? "" : "Số CMT: " + objgcn.Chu.VoChong.VoCN.SOGIAYTO;
                    if (objgcn.Chu.VoChong.VoCN.NGAYCAP != null)
                    {
                        gcn.ngaycmtchu2 = "Cấp Ngày: " + objgcn.Chu.VoChong.VoCN.NGAYCAP.Value.ToString("dd/mm/yyyy");
                    }
                    else
                    {
                        gcn.ngaycmtchu2 = "";
                    }
                    gcn.noicmtchu2 = objgcn.Chu.VoChong.VoCN.NOICAP == null ? "" : "Cấp tại: " + objgcn.Chu.VoChong.VoCN.NOICAP;
                    gcn.diachichu2 = objgcn.Chu.VoChong.VoCN.DIACHI == null ? "" : "Địa chỉ: " + objgcn.Chu.VoChong.VoCN.DIACHI;
                    gcn.sinhnamchu2 = objgcn.Chu.VoChong.VoCN.NAMSINH == null ? "" : "Sinh năm: " + objgcn.Chu.VoChong.VoCN.NAMSINH;
                }
                else if (objgcn.Chu.LOAIDOITUONGID == "4")
                {
                    gcn.TENCHU1 = "Tên cộng đồng: " + objgcn.Chu.CongDong.TENCONGDONG;
                    gcn.socmtchu1 = "";

                    gcn.ngaycmtchu1 = "";

                    gcn.diachichu1 = objgcn.Chu.CongDong.DIACHI == null ? "" : "Địa chỉ: " + objgcn.Chu.CongDong.DIACHI;


                    gcn.TENCHU2 = "Người đại diện: " + objgcn.Chu.CongDong.NguoiDaiDien.HODEM + " " + objgcn.Chu.CongDong.NguoiDaiDien.TEN;
                    gcn.socmtchu2 = objgcn.Chu.CongDong.NguoiDaiDien.SOGIAYTO == null ? "" : "Số CMT: " + objgcn.Chu.CongDong.NguoiDaiDien.SOGIAYTO;
                    if (objgcn.Chu.CongDong.NguoiDaiDien.NGAYCAP != null)
                    {
                        gcn.ngaycmtchu2 = "Cấp Ngày: " + objgcn.Chu.CongDong.NguoiDaiDien.NGAYCAP.Value.ToString("dd/mm/yyyy");
                    }
                    else
                    {
                        gcn.ngaycmtchu2 = "";
                    }
                    gcn.noicmtchu2 = objgcn.Chu.CongDong.NguoiDaiDien.NOICAP == null ? "" : "Cấp tại: " + objgcn.Chu.CongDong.NguoiDaiDien.NOICAP;
                    gcn.diachichu2 = objgcn.Chu.CongDong.NguoiDaiDien.DIACHI == null ? "" : "Địa chỉ: " + objgcn.Chu.CongDong.NguoiDaiDien.DIACHI;
                    gcn.sinhnamchu2 = objgcn.Chu.CongDong.NguoiDaiDien.NAMSINH == null ? "" : "Sinh năm: " + objgcn.Chu.CongDong.NguoiDaiDien.NAMSINH;
                }
                else if (objgcn.Chu.LOAIDOITUONGID == "5")
                {
                    gcn.TENCHU1 = "Tên tổ chứcc: " + objgcn.Chu.ToChuc.TENTOCHUC;
                    gcn.socmtchu1 = "Số giấy phép:" + objgcn.Chu.ToChuc.SOQUYETDINH;

                    gcn.ngaycmtchu1 = "Ngày cấp: " + objgcn.Chu.ToChuc.NGAYQUYETDINH;

                    gcn.diachichu1 = "Địa chỉ: " + objgcn.Chu.ToChuc.DIACHI;


                    gcn.TENCHU2 = "Người đại diện: " + objgcn.Chu.ToChuc.NguoiDaiDien.HODEM + " " + objgcn.Chu.ToChuc.NguoiDaiDien.TEN;
                    gcn.socmtchu2 = "Số CMT: " + objgcn.Chu.ToChuc.NguoiDaiDien.SOGIAYTO;
                    if (objgcn.Chu.ToChuc.NguoiDaiDien.NGAYCAP != null)
                    {
                        gcn.ngaycmtchu2 = "Cấp Ngày: " + objgcn.Chu.ToChuc.NguoiDaiDien.NGAYCAP.Value.ToString("dd/mm/yyyy");
                    }
                    else
                    {
                        gcn.ngaycmtchu2 = "";
                    }
                    gcn.noicmtchu2 = objgcn.Chu.ToChuc.NguoiDaiDien.NOICAP == null ? "" : "Cấp tại: " + objgcn.Chu.ToChuc.NguoiDaiDien.NOICAP;
                    gcn.diachichu2 = objgcn.Chu.ToChuc.NguoiDaiDien.DIACHI == null ? "" : "Địa chỉ: " + objgcn.Chu.ToChuc.NguoiDaiDien.DIACHI;
                    gcn.sinhnamchu2 = objgcn.Chu.ToChuc.NguoiDaiDien.NAMSINH == null ? "" : "Sinh năm: " + objgcn.Chu.ToChuc.NguoiDaiDien.NAMSINH;
                }
            }
            // thửa đất
            if (objgcn.DSQuyenSDDat.Count > 0)
            {
                ArrayList arrthua = new ArrayList();
                gcn.Dsthuadat = new List<thuadat>();
                foreach (var objthua in objgcn.DSQuyenSDDat)
                {
                    if (!arrthua.Contains(objthua.Thua.SOTHUTUTHUA + "_" + objthua.Thua.SOHIEUTOBANDO))
                    {
                        thuadat objthuadat = new thuadat();

                        //   var thuaid = objgcn.DSQuyenSDDat.FirstOrDefault().;
                        // var objthua = objgcn.DSQuyenSDDat.FirstOrDefault();
                        //using (MplisEntities db = new MplisEntities())
                        //{
                        //    var objthua = from item in db.DC_THUADAT where item.THUADATID == 
                        //}
                        objthuadat.sothua = objthua.Thua.SOTHUTUTHUA.Value.ToString();
                        objthuadat.soto = objthua.Thua.SOHIEUTOBANDO.Value.ToString();
                        objthuadat.dientichpl = objthua.Thua.DIENTICHPHAPLY == null ? "0" : objthua.Thua.DIENTICHPHAPLY.Value.ToString();
                        if (objthua.Thua.DIENTICHPHAPLY.Value.ToString().Contains("."))
                        {
                            string[] catso = objthua.Thua.DIENTICHPHAPLY.Value.ToString().Split('.');
                            string sotruoc = number2Text(catso[0].ToString());
                            string sosau = number2Text(catso[1].ToString());
                            objthuadat.bangchu = sotruoc + " phẩy " + sosau;
                        }
                        else
                        {
                            objthuadat.bangchu = number2Text(objthua.Thua.DIENTICHPHAPLY.Value.ToString());

                        }
                        objthuadat.diachi = objthua.Thua.DIACHITHUADAT;
                        string htsd = "";
                        string mdsd = "";
                        string thoihansd = "";
                        string nguongoc = "";
                        using (MplisEntities db = new MplisEntities())
                        {
                            foreach (var a in objgcn.DSQuyenSDDat)
                            {
                                var objmdsd = (from item in db.DC_MUCDICHSUDUNGDAT.Where(x => x.MUCDICHSUDUNGDATID.Equals(a.MUCDICHSUDUNGDATID))
                                               select new
                                               {
                                                   mdsddat = item,
                                                   mdsd = (from md in db.DM_MUCDICHSUDUNG.Where(y => y.MUCDICHSUDUNGID.Equals(item.MUCDICHSUDUNGID)) select md).FirstOrDefault()
                                               }).FirstOrDefault();
                                mdsd = mdsd + ", " + objmdsd.mdsd.TENMUCDICHSUDUNG;
                                thoihansd = thoihansd + ", " + objmdsd.mdsddat.THOIHANSUDUNG;
                                htsd = objmdsd.mdsddat.SUDUNGCHUNG == null ? "" : objmdsd.mdsddat.SUDUNGCHUNG.Value.ToString();//"Sử dụng chung: " + objmdsd.mdsddat.SUDUNGCHUNG;
                            }

                        }
                        mdsd = mdsd.Substring(1, mdsd.Length - 1);
                        objthuadat.hinhthucsudung = htsd;
                        objthuadat.thoihansudung = thoihansd.Substring(1, thoihansd.Length - 1);
                        objthuadat.mucdichsudung = mdsd;
                        objthuadat.nguongocsudung = objthua.Thua.THUAGOCID;
                        gcn.Dsthuadat.Add(objthuadat);
                        arrthua.Add(objthuadat.sothua + "_" + objthuadat.soto);
                    }
                }
            }
            else
            {
                gcn.Dsthuadat = new List<thuadat>();
                using (MplisEntities db = new MplisEntities())
                {
                    decimal? dsothua = decimal.Parse(sothua);
                    decimal? dsoto = decimal.Parse(soto);
                    var objthua = (from item in db.DC_THUADAT where item.SOTHUTUTHUA == dsothua && item.SOHIEUTOBANDO == dsoto && item.XAID == xaid select item).FirstOrDefault();
                    var thuadat = new thuadat();
                    thuadat.diachi = objthua.DIACHITHUADAT;
                    thuadat.sothua = objthua.SOTHUTUTHUA.Value.ToString();
                    thuadat.soto = objthua.SOHIEUTOBANDO.Value.ToString();
                    thuadat.dientichpl = objthua.DIENTICHPHAPLY.ToString();

                    gcn.Dsthuadat.Add(thuadat);
                }

            }
            // nhà ở
            gcn.Dsnhao = new List<nhao>();
            if (objgcn.DSQuyenSHTS != null)
            {
                foreach (var objnhao in objgcn.DSQuyenSHTS)
                {

                    //Nhà riêng lẻ
                    if (objnhao.DC_TAISANGANLIENVOIDAT.LOAITAISAN == "1")
                    {
                        nhao nha = new nhao();
                        nha.N_caphang = objnhao.DC_TAISANGANLIENVOIDAT.NhaRiengLe.CAPHANG;
                        nha.N_dtsan = objnhao.DC_TAISANGANLIENVOIDAT.NhaRiengLe.DIENTICHSAN == null ? "0" : objnhao.DC_TAISANGANLIENVOIDAT.NhaRiengLe.DIENTICHSAN.ToString();
                        nha.N_dtxaydung = objnhao.DC_TAISANGANLIENVOIDAT.NhaRiengLe.DIENTICHXAYDUNG == null ? "0" : objnhao.DC_TAISANGANLIENVOIDAT.NhaRiengLe.DIENTICHXAYDUNG.ToString();
                        nha.N_hinhthucsohuu = "Nhà riêng lẻ";
                        nha.N_loainhao = "Nhà riêng lẻ";
                        nha.N_thoihan = "Lâu dài";
                        gcn.Dsnhao.Add(nha);
                    }
                    //rừng
                    else if (objnhao.DC_TAISANGANLIENVOIDAT.LOAITAISAN == "4")
                    {
                        if (objnhao.DC_TAISANGANLIENVOIDAT.RungTrong != null)
                        {
                            gcn.R_dt = objnhao.DC_TAISANGANLIENVOIDAT.RungTrong.DIENTICH == null ? "0" : objnhao.DC_TAISANGANLIENVOIDAT.RungTrong.DIENTICH.ToString();
                            gcn.R_loai = objnhao.DC_TAISANGANLIENVOIDAT.RungTrong.LOAICAYRUNG;
                            gcn.R_nguon = "Chưa có trường này trong db";
                            gcn.R_sh = objnhao.DC_TAISANGANLIENVOIDAT.RungTrong.HINHTHUCSOHUU;
                            gcn.R_th = objnhao.DC_TAISANGANLIENVOIDAT.RungTrong.THOIHANSOHUU;
                        }
                    }
                    // cây lâu năm
                    else if (objnhao.DC_TAISANGANLIENVOIDAT.LOAITAISAN == "3")
                    {

                    }
                }
            }
            //query biến động
            using (MplisEntities db = new MplisEntities())
            {
                var objlsbd_gcn = (from item in db.LS_BD_GCN where item.GCNHIENTAIID == objgcn.GIAYCHUNGNHANID select item).OrderByDescending(a => a.NGAYPD).FirstOrDefault();
                if (objlsbd_gcn != null)
                {
                    List<LS_BD_GCN> node = new List<LS_BD_GCN>();
                    node.Add(objlsbd_gcn);
                    returndsbdgcn(objlsbd_gcn.GCNHIENTAIID, objlsbd_gcn.NGAYPD, node);
                    if (node.Count > 0)
                    {
                        gcn.Dsbiendong = new List<biendong>();
                        foreach (var bdgcn in node)
                        {
                            biendong obj = new biendong();
                            var objbiendong = (from item in db.DC_BIENDONG where item.BIENDONGID == bdgcn.BIENDONGID select item).FirstOrDefault();
                            if (objbiendong != null)
                            {
                                obj.biendongid = objbiendong.BIENDONGID;
                                obj.noidungbiendong = objbiendong.NOIDUNGBIENDONG;
                                obj.ngaybiendong = objbiendong.NGAYCONGCHUNG == null ? "" : objbiendong.NGAYCONGCHUNG.Value.ToString();
                                gcn.Dsbiendong.Add(obj);
                            }

                        }
                    }

                }

            }
            gcn.Dshangmuc = new List<hangmuc>();
            gcn.Tenloaicongtrinh = "Chưa có";
            return gcn;
        }

        //get thông tin biến động
        public static ObjBienDong getbiendong_inGCN(string xaid, string sothua, string soto)
        {
            ObjBienDong gcn = new ObjBienDong();

            //query biến động
            using (MplisEntities db = new MplisEntities())
            {
                decimal soto1 = decimal.Parse(soto);
                decimal sothua1 = decimal.Parse(sothua);
                var objthua = (from item in db.DC_THUADAT where item.SOTHUTUTHUA == sothua1 && item.SOHIEUTOBANDO == soto1 && item.XAID == xaid select item).FirstOrDefault();
                if (objthua != null)
                {
                    var objgcn = (from item in db.DC_QUYENSUDUNGDAT
                                  where item.THUADATID == objthua.THUADATID
                                  select item).ToList().FirstOrDefault();

                    if (objgcn != null)
                    {
                        var objlsbd_gcn = (from item in db.LS_BD_GCN where item.GCNHIENTAIID == objgcn.GIAYCHUNGNHANID select item).OrderBy(a => a.NGAYPD).FirstOrDefault();
                        if (objlsbd_gcn != null)
                        {
                            List<LS_BD_GCN> node = new List<LS_BD_GCN>();
                            node.Add(objlsbd_gcn);
                            returndsbdgcn(objlsbd_gcn.GCNHIENTAIID, objlsbd_gcn.NGAYPD, node);
                            if (node.Count > 0)
                            {
                                gcn.Dsbiendong = new List<biendong>();
                                foreach (var bdgcn in node)
                                {
                                    biendong obj = new biendong();
                                    var objbiendong = (from item in db.DC_BIENDONG where item.BIENDONGID == bdgcn.BIENDONGID select item).FirstOrDefault();
                                    if (objbiendong != null)
                                    {
                                        obj.biendongid = objbiendong.BIENDONGID;
                                        obj.noidungbiendong = objbiendong.NOIDUNGBIENDONG;
                                        obj.ngaybiendong = objbiendong.NGAYCONGCHUNG == null ? "" : objbiendong.NGAYCONGCHUNG.Value.ToString();
                                        gcn.Dsbiendong.Add(obj);
                                    }

                                }
                            }

                        }
                    }
                }

            }
            return gcn;
        }
        public static List<LS_BD_GCN> returndsbdgcn(string idgcn, DateTime? ngaypheduyet, List<LS_BD_GCN> node)
        {
            using (MplisEntities db = new MplisEntities())
            {
                var lsbiendong = (from item in db.LS_BD_GCN where item.GCNCHAID == idgcn && item.NGAYPD < ngaypheduyet select item).OrderByDescending(b => b.NGAYPD).FirstOrDefault();
                if (lsbiendong != null)
                {
                    node.Add(lsbiendong);
                    returndsbdgcn(lsbiendong.GCNID, lsbiendong.NGAYPD, node);
                }
                else
                {
                    return (node);
                }

            }
            return (node);
        }
        #endregion
        public static VM_SAVE SaveDangKyGCN(BoHoSoModel bhs)
        {
            VM_SAVE save = new VM_SAVE();
            save.save = false;
            try
            {
                using (MplisEntities db = new MplisEntities())
                {
                    foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyGCN)
                    {
                        switch (item.themxoa)
                        {
                            case 1:
                                db.DC_DANGKY_GCN.Add(item);
                                DC_BD_GCN BDGCN = new DC_BD_GCN();
                                BDGCN.BDGCNID = Guid.NewGuid().ToString();
                                BDGCN.GIAYCHUNGNHANID = item.GIAYCHUNGNHANID;
                                BDGCN.BIENDONGID = bhs.HoSoTN.BienDong.BIENDONGID;
                                BDGCN.GiayChungNhan = item.GiayChungNhan;
                                BDGCN.LAGCNVAO = "Y";
                                BDGCN.TrangThai = item.GiayChungNhan.TRANGTHAIXULY;
                                BDGCN.MaVach = item.MaVach;
                                BDGCN.SoPhatHanh = item.SoPhatHanh;
                                db.DC_BD_GCN.Add(BDGCN);
                                if (item.GiayChungNhan.NGUOIID != null)
                                {
                                    var objchu_dangky = (from a in db.DC_DANGKY_NGUOI where a.DONDANGKYID == item.DONDANGKYID && a.NGUOIID == item.GiayChungNhan.NGUOIID select item).FirstOrDefault();
                                    if (objchu_dangky == null)
                                    {
                                        DC_DANGKY_NGUOI obj = new DC_DANGKY_NGUOI();
                                        obj.DANGKYNGUOIID = Guid.NewGuid().ToString();
                                        obj.DONDANGKYID = item.DONDANGKYID;
                                        obj.NGUOIID = item.GiayChungNhan.NGUOIID;
                                        db.DC_DANGKY_NGUOI.Add(obj);
                                        bhs.HoSoTN.DonDangKy.DSDangKyChu.Add(obj);
                                    }
                                }
                                var listhua_gcn = from a in db.DC_QUYENSUDUNGDAT.Where(i => i.GIAYCHUNGNHANID.Equals(item.GIAYCHUNGNHANID))
                                                  select new
                                                  {
                                                      a,
                                                      mdsd = (from mucdich in db.DC_MUCDICHSUDUNGDAT.Where(b => b.MUCDICHSUDUNGDATID.Equals(a.MUCDICHSUDUNGDATID))
                                                              select new
                                                              {
                                                                  mdsd = mucdich,
                                                                  t = (db.DC_THUADAT.Where(td => td.THUADATID.Equals(mucdich.THUADATID))).FirstOrDefault()
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
                                                db.DC_THUADAT.Add(thua);
                                                db.SaveChanges();
                                                foreach (var gd in thua.DSGiaDat)
                                                {
                                                    db.GD_GIATHUADAT.Add(gd);
                                                }
                                                foreach (var hc in thua.DSHanCheThua)
                                                {
                                                    db.DC_HANCHE.Add(hc);
                                                }
                                                foreach (var mdsd in thua.DSMucDichSuDungDat)
                                                {
                                                    db.DC_MUCDICHSUDUNGDAT.Add(mdsd);
                                                    db.SaveChanges();
                                                    foreach (var vt in mdsd.DSViTriMDSD)
                                                    {
                                                        db.DC_VITRITHUADAT.Add(vt);
                                                    }
                                                    foreach (var ng in mdsd.NGSDDats)
                                                    {
                                                        db.DC_NGUONGOCSUDUNG.Add(ng);
                                                    }
                                                    db.SaveChanges();
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
                                            if (thua.DIENTICHPHAPLY != null)
                                            {
                                                objdkthuamoi.DienTich = (decimal)thua.DIENTICHPHAPLY;
                                            }
                                            if (thua.SOHIEUTOBANDO != null)
                                            {
                                                objdkthuamoi.SHToBanDo = (decimal)thua.SOHIEUTOBANDO;
                                            }
                                            if (thua.SOTHUTUTHUA != null)
                                            {
                                                objdkthuamoi.STTThua = (decimal)thua.SOTHUTUTHUA;
                                            }
                                            objdkthuamoi.TenXaPhuong = thua.Xa.TENKVHC;
                                            //  dbo.DC_MUCDICHSUDUNGDAT.Add(objmdcdmoi);
                                            //  dbo.SaveChanges();
                                            db.DC_DANGKY_THUA.Add(objdkthuamoi);
                                            bhs.HoSoTN.DonDangKy.DSDangKyThua.Add(objdkthuamoi);
                                        }
                                    }
                                }
                                var listtaisan_gcn = (from a in db.DC_QUYENSOHUUTAISAN where a.GIAYCHUNGNHANID.Equals(item.GIAYCHUNGNHANID) select a).ToList();
                                if (listtaisan_gcn.Count() > 0)
                                {
                                    foreach (var objtaisandk in listtaisan_gcn)
                                    {
                                        DC_DANGKY_TAISAN objtaisan_dangky = new DC_DANGKY_TAISAN();
                                        var listts = (from a in db.DC_TAISANGANLIENVOIDAT where a.TAISANGANLIENVOIDATID == objtaisandk.TAISANGANLIENVOIDATID || a.TAISANGOCID == objtaisandk.TAISANGANLIENVOIDATID select a).ToList();
                                        foreach (var objtaisanglvd in listts)
                                        {
                                            objtaisan_dangky = (from ts in db.DC_DANGKY_TAISAN
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
                                                db.DC_TAISANGANLIENVOIDAT.Add(objtaisannew);
                                                //insert tài sản đăng ky

                                            }
                                            DC_DANGKY_TAISAN objdktaisanmoi = new DC_DANGKY_TAISAN();
                                            objdktaisanmoi.DANGKYTAISANID = Guid.NewGuid().ToString();
                                            objdktaisanmoi.DONDANGKYID = item.DONDANGKYID;
                                            objdktaisanmoi.TAISANID = objtaisannew.TAISANGANLIENVOIDATID;
                                            objdktaisanmoi.LoaiTaiSan = objtaisannew.LoaiTaiSanGanLienVoiDat.TENLOAITAISANGANLIENVOIDAT;
                                            objdktaisanmoi.DienTich = objtaisannew.DienTich;
                                            objdktaisanmoi.TaiSanGanLienVoiDat = objtaisannew;
                                            db.DC_DANGKY_TAISAN.Add(objdktaisanmoi);
                                            bhs.HoSoTN.DonDangKy.DSDangKyTaiSan.Add(objdktaisanmoi);
                                            db.SaveChanges();
                                        }

                                    }
                                }
                                break;
                            case 3:
                                var xoadk = (from a in db.DC_DANGKY_GCN where a.DANGKYGCNID == item.DANGKYGCNID select a).FirstOrDefault();
                                var xoabd = (from bd in db.DC_BD_GCN where bd.GIAYCHUNGNHANID == xoadk.GIAYCHUNGNHANID select bd).ToList();
                                if (xoabd != null)
                                {
                                    foreach (var a in xoabd)
                                    {
                                        db.Entry(a).State = EntityState.Deleted;
                                    }
                                }
                                if (xoadk != null)
                                {
                                    db.Entry(xoadk).State = EntityState.Deleted;
                                }
                                if (item.GiayChungNhan.NGUOIID != null)
                                {
                                    var nguoidk = (from a in db.DC_DANGKY_NGUOI where a.NGUOIID.Equals(item.GiayChungNhan.NGUOIID) && a.DONDANGKYID == item.DONDANGKYID select a).FirstOrDefault();
                                    if (nguoidk != null)
                                    {
                                        db.Entry(nguoidk).State = EntityState.Deleted;
                                    }
                                }
                                var listhuagcn = from a in db.DC_QUYENSUDUNGDAT.Where(i => i.GIAYCHUNGNHANID.Equals(item.GIAYCHUNGNHANID))
                                                 select new
                                                 {
                                                     a,
                                                     mdsd = (from mucdich in db.DC_MUCDICHSUDUNGDAT.Where(b => b.MUCDICHSUDUNGDATID.Equals(a.MUCDICHSUDUNGDATID))
                                                             select new
                                                             {
                                                                 mdsd = mucdich,
                                                                 t = (db.DC_THUADAT.Where(td => td.THUADATID.Equals(mucdich.THUADATID))).FirstOrDefault()
                                                             }).FirstOrDefault()
                                                 };
                                if (listhuagcn.Count() > 0)
                                {
                                    foreach (var thuadk in listhuagcn)
                                    {
                                        var thuadkxoa = (from a in db.DC_DANGKY_THUA where a.SOHIEUTOBANDO == thuadk.mdsd.t.SOHIEUTOBANDO && a.SOTHUTHUTHUA == thuadk.mdsd.t.SOTHUTUTHUA && a.XAID == thuadk.mdsd.t.XAID && a.DONDANGKYID == item.DONDANGKYID select a).FirstOrDefault();
                                        if (thuadkxoa != null)
                                        {
                                            db.Entry(thuadkxoa).State = EntityState.Deleted;
                                            for (var i = 0; i <= bhs.HoSoTN.DonDangKy.DSDangKyThua.Count - 1; i++)
                                            {
                                                if (bhs.HoSoTN.DonDangKy.DSDangKyThua[i].THUADATID == thuadkxoa.THUADATID)
                                                {
                                                    bhs.HoSoTN.DonDangKy.DSDangKyThua.RemoveAt(i);
                                                }
                                            }
                                        }
                                    }
                                }
                                var listtaisangcn = from a in db.DC_QUYENSOHUUTAISAN.Where(i => i.GIAYCHUNGNHANID.Equals(item.GIAYCHUNGNHANID))
                                                    select new
                                                    {
                                                        a,
                                                        tsglvd = (from taisan in db.DC_TAISANGANLIENVOIDAT where taisan.TAISANGANLIENVOIDATID == a.TAISANGANLIENVOIDATID || taisan.TAISANGOCID == a.TAISANGANLIENVOIDATID select taisan).ToList()
                                                    };
                                if (listtaisangcn.Count() > 0)
                                {
                                    foreach (var tsdk in listtaisangcn)
                                    {
                                        foreach (var tsglvd in tsdk.tsglvd)
                                        {
                                            var tsxoa = (from a in db.DC_DANGKY_TAISAN where a.TAISANID == tsglvd.TAISANGANLIENVOIDATID && a.DONDANGKYID == item.DONDANGKYID select a).FirstOrDefault();
                                            if (tsxoa != null)
                                            {
                                                var tsglvdxoa = (from a in db.DC_TAISANGANLIENVOIDAT where a.TAISANGANLIENVOIDATID == tsxoa.TAISANID select a).FirstOrDefault();
                                                db.Entry(tsxoa).State = EntityState.Deleted;
                                                db.Entry(tsglvdxoa).State = EntityState.Deleted;
                                                for (var i = 0; i <= bhs.HoSoTN.DonDangKy.DSDangKyTaiSan.Count - 1; i++)
                                                {
                                                    if (bhs.HoSoTN.DonDangKy.DSDangKyTaiSan[i].DANGKYTAISANID == tsxoa.DANGKYTAISANID)
                                                    {
                                                        bhs.HoSoTN.DonDangKy.DSDangKyTaiSan.RemoveAt(i);
                                                    }
                                                }
                                                db.SaveChanges();
                                            }
                                        }
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    db.SaveChanges();
                    // return true;
                    save.save = true;
                    save.bhs = bhs;
                }
            }
            catch (Exception e)
            {
                save.save = false;
                throw;
            }
            return save;
        }
    }
}