using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;
using AutoMapper;
using MPLIS.Libraries.Data.XuLyHoSo.Models;
using System.Data.Entity;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCDANGKYGCNServices
    {
        public static bool ThemGCNVaoDangKy(string soPhatHanh, string maVach, BoHoSoModel bhs, out string message)
        {
            DC_GIAYCHUNGNHAN gCN = null;
            //Search GCN trong đăng ký?
            if (soPhatHanh == "")
            {
                //Search theo Mã Vạch
                foreach (var tempDangKyGCN in bhs.HoSoTN.DonDangKy.DSDangKyGCN)
                {
                    if (tempDangKyGCN.GiayChungNhan.MAVACH == maVach)
                    {
                        gCN = tempDangKyGCN.GiayChungNhan;
                        break;
                    }
                }
            }
            else
            {
                //Search theo Số Phát Hành và Mã Vạch
                foreach (var tempDangKyGCN in bhs.HoSoTN.DonDangKy.DSDangKyGCN)
                {
                    if (tempDangKyGCN.GiayChungNhan.MAVACH == maVach && tempDangKyGCN.GiayChungNhan.SOPHATHANH == soPhatHanh)
                    {
                        gCN = tempDangKyGCN.GiayChungNhan;
                        break;
                    }
                }
            }
            if (gCN == null)
            {
                //Nếu không tìm thấy trong đăng ký thì tìm trong CSDL!
                List<DC_GIAYCHUNGNHAN> dSGCN = new List<DC_GIAYCHUNGNHAN>();
                DCGIAYCHUNGNHANServices.GetGiayChungNhan(soPhatHanh, maVach, dSGCN);
                foreach (var tempGCN in dSGCN)
                {
                    //Giấy Chứng Nhận trong Đăng Ký:
                    DC_DANGKY_GCN dangKyGCN = new DC_DANGKY_GCN();
                    dangKyGCN.GIAYCHUNGNHANID = tempGCN.GIAYCHUNGNHANID;
                    dangKyGCN.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
                    dangKyGCN.GiayChungNhan = tempGCN;
                    if (DBInsertOrUpdateDangKyGCN(dangKyGCN))
                    {
                        dangKyGCN.InitData();
                        bhs.HoSoTN.DonDangKy.DSDangKyGCN.Add(dangKyGCN);
                    }
                    //Chủ trong Đăng Ký:
                    if (tempGCN.Chu != null)
                    {
                        bool foundNguoi = false;
                        if (bhs.HoSoTN.DonDangKy.DSDangKyChu != null)
                        {
                            foreach (var tempDangKyChu in bhs.HoSoTN.DonDangKy.DSDangKyChu)
                            {
                                if (tempDangKyChu.Chu != null && tempDangKyChu.Chu.NGUOIID == tempGCN.Chu.NGUOIID)
                                {
                                    foundNguoi = true;
                                    break;
                                }
                            }
                        }
                        if (!foundNguoi)
                        {
                            DC_DANGKY_NGUOI dangKyNguoi = new DC_DANGKY_NGUOI();
                            dangKyNguoi.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
                            dangKyNguoi.NGUOIID = tempGCN.NGUOIID;
                            dangKyNguoi.LOAI = decimal.Parse(tempGCN.Chu.LOAIDOITUONGID);
                            dangKyNguoi.Chu = tempGCN.Chu;
                            if (DCDANGKYNGUOIServices.DBInsertOrUpdateDangKyNguoi(dangKyNguoi))
                            {
                                dangKyNguoi.InitData();
                                bhs.HoSoTN.DonDangKy.DSDangKyChu.Add(dangKyNguoi);
                            }
                        }
                    }
                }
                //Init Return Result
                if (dSGCN.Count == 0)
                {
                    message = "Giấy Chứng Nhận có số phát hành: \"" + soPhatHanh + "\", mã vạch: \"" + maVach + "\" không tồn tại trong CSDL!";
                    return false;
                }
                else if (dSGCN.Count == 1)
                {
                    message = "Giấy Chứng Nhận có số phát hành: \"" + soPhatHanh + "\", mã vạch: \"" + maVach + "\" đã được thêm vào danh sách!";
                    return true;
                }
                else
                {
                    message = dSGCN.Count - 1 + " Giấy Chứng Nhận là Sở Hữu Chung với GCN có số phát hành: \"" + soPhatHanh + "\", mã vạch: \"" + maVach + "\" đã được thêm vào danh sách!";
                    return true;
                }
            }
            message = "Giấy Chứng Nhận có số phát hành: \"" + soPhatHanh + "\", mã vạch: \"" + maVach + "\" đã tồn tại trong danh sách đăng ký!";
            return false;
        }
        public static bool XoaGCNTrongDangKy(string dangKyGCNID, BoHoSoModel bhs, out string message)
        {
            if (dangKyGCNID != null && dangKyGCNID != "")
            {
                DC_DANGKY_GCN dangKyGCN = null;
                foreach (var tempDangKyGCN in bhs.HoSoTN.DonDangKy.DSDangKyGCN)
                {
                    if (tempDangKyGCN.DANGKYGCNID == dangKyGCNID)
                    {
                        dangKyGCN = tempDangKyGCN;
                        break;
                    }
                }
                if (dangKyGCN != null)
                {
                    //Kiểm tra dữ liệu trên GCN có tham gia vào biến động hay không?
                    bool checkData = false;
                    //Kiểm tra trên Danh Sách Biến Động GCN đầu vào:
                    foreach (var tempBienDongGCN in bhs.HoSoTN.BienDong.DSGcn)
                    {
                        if (tempBienDongGCN.LAGCNVAO == "Y" && tempBienDongGCN.GIAYCHUNGNHANID == dangKyGCN.GIAYCHUNGNHANID)
                        {
                            checkData = true;
                            break;
                        }
                    }
                    if (checkData)
                    {
                        message = "Giấy Chứng Nhận đang tham gia biến động bạn không thể xóa khỏi danh sách?";
                        return false;
                    }
                    //Xóa dữ liệu DC_DANGKY_NGUOI
                    if(DCDANGKYNGUOIServices.XoaNguoiTrongDangKyByNguoiID(dangKyGCN.GiayChungNhan.NGUOIID, bhs))
                    {

                    }
                    //Xóa dữ liệu DC_DANGKY_GCN
                    if (DBDeleteDangKyGCN(dangKyGCN))
                    {
                        bhs.HoSoTN.DonDangKy.DSDangKyGCN.Remove(dangKyGCN);
                        message = "Xóa Giấy Chứng Nhận trong đăng ký thành công!";
                        return true;
                    }
                }
            }
            message = "Dữ liệu không đúng?";
            return false;
        }
        public static bool DBInsertOrUpdateDangKyGCN(DC_DANGKY_GCN dangKyGCN)
        {
            try
            {
                using (MplisEntities db = new MplisEntities())
                {
                    if (dangKyGCN.DANGKYGCNID == null || dangKyGCN.DANGKYGCNID == "")
                    {
                        dangKyGCN.DANGKYGCNID = Guid.NewGuid().ToString();
                        db.Entry(Mapper.Map<DC_DANGKY_GCN, DC_DANGKY_GCN>(dangKyGCN)).State = EntityState.Added;
                    }
                    else
                    {
                        db.Entry(Mapper.Map<DC_DANGKY_GCN, DC_DANGKY_GCN>(dangKyGCN)).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public static bool DBDeleteDangKyGCN(DC_DANGKY_GCN dangKyGCN)
        {
            try
            {
                using (MplisEntities db = new MplisEntities())
                {
                    db.Entry(Mapper.Map<DC_DANGKY_GCN, DC_DANGKY_GCN>(dangKyGCN)).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }

}