using AppCore.Models;
using AutoMapper;
//using MPLIS.Libraries.Data.LuanChuyenHoSo.Models;
using MPLIS.Libraries.Data.XuLyHoSo.Models;
using MPLIS.Libraries.Data.XuLyHoSo.Models.XuLyHoSo.DangKy;
//using MPLIS.Modules.LuanChuyenHoSo.clsUtil;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DONDANGKYServices
    {

        #region Services Chủ Cá Nhân
        //public static bool SaveChuCaNhan(DC_CANHAN formData, BoHoSoModel bhs)
        //{
        //    try
        //    {
        //        DC_DANGKY_NGUOI curDangKyChu = bhs.HoSoTN.DonDangKy.CurDangKyChu;
        //        using (MplisEntities db = new MplisEntities())
        //        {
        //            formData.setHoTen();
        //            switch (curDangKyChu.Chu.LOAIDOITUONGID)
        //            {
        //                case "1":
        //                    if (formData.CANHANID != null && formData.CANHANID != "")
        //                    {
        //                        db.Entry(formData).State = EntityState.Modified;
        //                        Mapper.Map<DC_CANHAN, DC_CANHAN>(formData, curDangKyChu.Chu.CaNhan);
        //                    }
        //                    else
        //                    {
        //                        formData.CANHANID = Guid.NewGuid().ToString();
        //                        curDangKyChu.Chu.CHITIETID = formData.CANHANID;
        //                        curDangKyChu.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
        //                        db.Entry(formData).State = EntityState.Added;
        //                        db.Entry(curDangKyChu.Chu).State = EntityState.Added;
        //                        db.Entry(curDangKyChu).State = EntityState.Added;
        //                        curDangKyChu.Chu.CaNhan = new DC_CANHAN();
        //                        Mapper.Map<DC_CANHAN, DC_CANHAN>(formData, curDangKyChu.Chu.CaNhan);
        //                        bhs.HoSoTN.DonDangKy.DSDangKyChu.Add(curDangKyChu);
        //                    }
        //                    break;
        //                case "2":
        //                    if (formData.CANHANID != null && formData.CANHANID != "")
        //                    {
        //                        var rethGDThanhVien = db.DC_HOGIADINH_THANHVIEN.Where(it => it.HOGIADINHID.Equals(curDangKyChu.Chu.HoGiaDinh.HOGIADINHID) && it.CANHANID.Equals(formData.CANHANID)).FirstOrDefault();
        //                        if (rethGDThanhVien != null)
        //                        {
        //                            foreach (var tempThanhVien in curDangKyChu.Chu.HoGiaDinh.DSThanhVien)
        //                            {
        //                                if (tempThanhVien.CANHANID.Equals(formData.CANHANID))
        //                                {
        //                                    db.Entry(formData).State = EntityState.Modified;
        //                                    Mapper.Map<DC_CANHAN, DC_CANHAN>(formData, tempThanhVien.ThanhVien);
        //                                    break;
        //                                }
        //                            }
        //                        }
        //                        else
        //                        {
        //                            DC_HOGIADINH_THANHVIEN hGDThanhVien = new DC_HOGIADINH_THANHVIEN(curDangKyChu.Chu.HoGiaDinh.HOGIADINHID, formData.CANHANID);
        //                            curDangKyChu.Chu.HoGiaDinh.DSThanhVien.Add(hGDThanhVien);
        //                            db.Entry(hGDThanhVien).State = EntityState.Added;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        formData.CANHANID = Guid.NewGuid().ToString();
        //                        DC_HOGIADINH_THANHVIEN hGDThanhVien = new DC_HOGIADINH_THANHVIEN(curDangKyChu.Chu.HoGiaDinh.HOGIADINHID, formData.CANHANID);
        //                        db.Entry(formData).State = EntityState.Added;
        //                        db.Entry(hGDThanhVien).State = EntityState.Added;
        //                        curDangKyChu.Chu.HoGiaDinh.DSThanhVien.Add(hGDThanhVien);
        //                    }
        //                    break;
        //                case "3":
        //                    break;
        //                case "4":
        //                    break;
        //                case "5":
        //                    break;
        //                case "6":
        //                    break;
        //                default:
        //                    break;
        //            }
        //            db.SaveChanges();
        //        }
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        //public static bool SaveGiayToTuyThan(DC_GIAYTOTUYTHAN formData, BoHoSoModel bhs)
        //{
        //    try
        //    {
        //        DC_DANGKY_NGUOI curDangKyChu = bhs.HoSoTN.DonDangKy.CurDangKyChu;
        //        using (MplisEntities db = new MplisEntities())
        //        {
        //            switch (curDangKyChu.Chu.LOAIDOITUONGID)
        //            {
        //                case "1":
        //                    //Edit / Add
        //                    if (formData.GIAYTOTUYTHANID != null && formData.GIAYTOTUYTHANID != "")
        //                    {
        //                        foreach (var tempGiayTo in curDangKyChu.Chu.CaNhan.DSGiayToTuyThan)
        //                        {
        //                            if (tempGiayTo.GIAYTOTUYTHANID.Equals(formData.GIAYTOTUYTHANID))
        //                            {
        //                                db.Entry(formData).State = EntityState.Modified;
        //                                formData.TenGiayToTuyThan = DCGIAYTOTUYTHANServices.GetLoaiGiayToTuyThan(formData.LOAIGIAYTOTUYTHANID).TENLOAIGIAYTOTUYTHAN;
        //                                Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(formData, tempGiayTo);
        //                                break;
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        //isThem = true;
        //                        formData.GIAYTOTUYTHANID = Guid.NewGuid().ToString();
        //                        db.Entry(formData).State = EntityState.Added;
        //                        formData.TenGiayToTuyThan = DCGIAYTOTUYTHANServices.GetLoaiGiayToTuyThan(formData.LOAIGIAYTOTUYTHANID).TENLOAIGIAYTOTUYTHAN;
        //                        curDangKyChu.Chu.CaNhan.DSGiayToTuyThan.Add(formData);
        //                    }
        //                    break;
        //                case "2":
        //                    if (formData.GIAYTOTUYTHANID != null && formData.GIAYTOTUYTHANID != "")
        //                    {
        //                        foreach (var tempThanhVien in curDangKyChu.Chu.HoGiaDinh.DSThanhVien)
        //                        {
        //                            if (tempThanhVien.CANHANID.Equals(formData.CANHANID))
        //                            {
        //                                foreach (var tempGiayTo in tempThanhVien.ThanhVien.DSGiayToTuyThan)
        //                                {
        //                                    if (tempGiayTo.GIAYTOTUYTHANID.Equals(formData.GIAYTOTUYTHANID))
        //                                    {
        //                                        db.Entry(formData).State = EntityState.Modified;
        //                                        formData.TenGiayToTuyThan = DCGIAYTOTUYTHANServices.GetLoaiGiayToTuyThan(formData.LOAIGIAYTOTUYTHANID).TENLOAIGIAYTOTUYTHAN;
        //                                        Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(formData, tempGiayTo);
        //                                        break;
        //                                    }
        //                                }
        //                                break;
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        //isThem = true;
        //                        foreach (var tempThanhVien in curDangKyChu.Chu.HoGiaDinh.DSThanhVien)
        //                        {
        //                            if (tempThanhVien.CANHANID.Equals(formData.CANHANID))
        //                            {
        //                                formData.GIAYTOTUYTHANID = Guid.NewGuid().ToString();
        //                                db.Entry(formData).State = EntityState.Added;
        //                                formData.TenGiayToTuyThan = DCGIAYTOTUYTHANServices.GetLoaiGiayToTuyThan(formData.LOAIGIAYTOTUYTHANID).TENLOAIGIAYTOTUYTHAN;
        //                                tempThanhVien.ThanhVien.DSGiayToTuyThan.Add(formData);
        //                                break;
        //                            }
        //                        }
        //                    }
        //                    break;
        //                case "3":
        //                    break;
        //                case "4":
        //                    break;
        //                case "5":
        //                    break;
        //                case "6":
        //                    break;
        //                default:
        //                    break;
        //            }
        //            db.SaveChanges();
        //        }
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}
        #endregion
        #region Services chủ sở hữu

        #region Chủ Hộ Gia Đình
        public static List<DC_HOGIADINH> SearchHoGiaDinhByCMTChuHo(string cmtChuHo)
        {
            List<DC_HOGIADINH> dSHoGiaDinh = new List<DC_HOGIADINH>();
            DC_HOGIADINH hoGiaDinh = new DC_HOGIADINH();
            using (MplisEntities db = new MplisEntities())
            {
                var retHoGiaDinh = db.DC_HOGIADINH.Where(it => it.CMTCHUHO.Equals(cmtChuHo))
                    .Select(hoGD => new
                    {
                        hoGD,
                        chuHoCN = db.DC_CANHAN.Where(it => it.CANHANID.Equals(hoGD.CHUHO)).FirstOrDefault(),
                        voChongCN = db.DC_CANHAN.Where(it => it.CANHANID.Equals(hoGD.VOCHONG)).FirstOrDefault(),
                        thanhViens = db.DC_HOGIADINH_THANHVIEN.Where(it => it.HOGIADINHID.Equals(hoGD.HOGIADINHID))
                        .Select(thanhVien => new
                        {
                            thanhVien,
                            caNhan = db.DC_CANHAN.Where(it => it.CANHANID.Equals(thanhVien.CANHANID)).FirstOrDefault()
                        }).ToList()
                    }).ToList();
                if (retHoGiaDinh != null)
                {
                    foreach (var tempHoGiaDinh in retHoGiaDinh)
                    {
                        hoGiaDinh = tempHoGiaDinh.hoGD;
                        hoGiaDinh.ChuHoCN = tempHoGiaDinh.chuHoCN;
                        hoGiaDinh.VoChongCN = tempHoGiaDinh.voChongCN;
                        foreach (var tempThanhVien in tempHoGiaDinh.thanhViens)
                        {
                            tempThanhVien.thanhVien.ThanhVien = tempThanhVien.caNhan;
                            hoGiaDinh.DSThanhVien.Add(tempThanhVien.thanhVien);
                        }
                        dSHoGiaDinh.Add(hoGiaDinh);
                    }

                }
            }
            return dSHoGiaDinh;
        }

        public static DC_HOGIADINH GetHoGiaDinhByHGDID(string hoGiaDinhID)
        {
            DC_HOGIADINH hoGiaDinh = new DC_HOGIADINH();
            using (MplisEntities db = new MplisEntities())
            {
                var retHoGiaDinh = db.DC_HOGIADINH.Where(it => it.CMTCHUHO.Equals(hoGiaDinhID))
                    .Select(hoGD => new
                    {
                        hoGD,
                        chuHoCN = db.DC_CANHAN.Where(it => it.CANHANID.Equals(hoGD.CHUHO)).FirstOrDefault(),
                        voChongCN = db.DC_CANHAN.Where(it => it.CANHANID.Equals(hoGD.VOCHONG)).FirstOrDefault(),
                        thanhViens = db.DC_HOGIADINH_THANHVIEN.Where(it => it.HOGIADINHID.Equals(hoGD.HOGIADINHID))
                        .Select(thanhVien => new
                        {
                            thanhVien,
                            caNhan = db.DC_CANHAN.Where(it => it.CANHANID.Equals(thanhVien.CANHANID)).FirstOrDefault()
                        }).ToList()
                    }).FirstOrDefault();
                if (retHoGiaDinh != null)
                {

                    hoGiaDinh = retHoGiaDinh.hoGD;
                    hoGiaDinh.ChuHoCN = retHoGiaDinh.chuHoCN;
                    hoGiaDinh.VoChongCN = retHoGiaDinh.voChongCN;
                    foreach (var tempThanhVien in retHoGiaDinh.thanhViens)
                    {
                        tempThanhVien.thanhVien.ThanhVien = tempThanhVien.caNhan;
                        hoGiaDinh.DSThanhVien.Add(tempThanhVien.thanhVien);
                    }
                }
            }
            return hoGiaDinh;
        }
        #endregion
        public static DangKyChuHoGiaDinh DsHienThi(DangKyChuHoGiaDinh objhogiadinh)
        {
            //List<DSHienThiHoGiaDinh> ds = new List<DSHienThiHoGiaDinh>();
            //objhogiadinh.DSHienThi = new List<DSHienThiHoGiaDinh>();
            //get danh sách hiển thị thành viên hộ gia đình
            //if (objhogiadinh.CHUHO != "" && objhogiadinh.CHUHO != null)
            //{
            //    var objhienthi = new DSHienThiHoGiaDinh();
            //    objhienthi.CANHANID = objhogiadinh.CHUHO;
            //    objhienthi.HOTEN = objhogiadinh.ObjChuHo.HODEM + " " + objhogiadinh.ObjChuHo.TEN;
            //    objhienthi.QUANHE = "Chủ hộ";
            //    objhienthi.SOGIAYTO = objhogiadinh.ObjChuHo.SOGIAYTO;
            //    objhogiadinh.DSHienThi.Add(objhienthi);
            //}
            //if (objhogiadinh.VOCHONG != "" && objhogiadinh.VOCHONG != null)
            //{
            //    var objhienthi = new DSHienThiHoGiaDinh();
            //    objhienthi.CANHANID = objhogiadinh.VOCHONG;
            //    objhienthi.HOTEN = objhogiadinh.ObjVoChong.HODEM + " " + objhogiadinh.ObjVoChong.TEN;
            //    objhienthi.QUANHE = "Vợ/chồng";
            //    objhienthi.SOGIAYTO = objhogiadinh.ObjVoChong.SOGIAYTO;
            //    objhogiadinh.DSHienThi.Add(objhienthi);
            //}
            //if (objhogiadinh.DSThanhVien.Count > 0)
            //{
            //    foreach (var objcon in objhogiadinh.DSThanhVien)
            //    {
            //        var objhienthi = new DSHienThiHoGiaDinh();
            //        objhienthi.CANHANID = objcon.ObjThanhVien.CANHANID;
            //        objhienthi.HOTEN = objcon.ObjThanhVien.HODEM + " " + objcon.ObjThanhVien.TEN;
            //        objhienthi.QUANHE = "con";
            //        objhienthi.SOGIAYTO = objcon.ObjThanhVien.SOGIAYTO;
            //        objhogiadinh.DSHienThi.Add(objhienthi);
            //    }

            //}
            return objhogiadinh;
        }
        public static bool SaveCongDong(DC_DANGKY_NGUOI item, MplisEntities dbo)
        {
            try
            {
                DC_CONGDONG objtochuc = new DC_CONGDONG();
                objtochuc.CONGDONGID = item.Chu.CongDong.CONGDONGID;
                objtochuc = item.Chu.CongDong;
                if (item.Chu.CongDong.NGUOIDAIDIENID != null || item.Chu.CongDong.NGUOIDAIDIENID != "")
                {
                    DC_CANHAN objcanhan_ChuHo = new DC_CANHAN();
                    Mapper.Map<DC_CANHAN, DC_CANHAN>(item.Chu.CongDong.NguoiDaiDien, objcanhan_ChuHo);
                    objtochuc.NGUOIDAIDIENID = objcanhan_ChuHo.CANHANID;
                    var checkcanhan = (from vien in dbo.DC_CANHAN where vien.CANHANID == objcanhan_ChuHo.CANHANID select vien).FirstOrDefault();
                    if (checkcanhan == null)
                    {
                        dbo.DC_CANHAN.Add(objcanhan_ChuHo);
                    }

                    // lưu giấy tờ tùy thân chủ hộ
                    if (item.Chu.CongDong.NguoiDaiDien.DSGiayToTuyThan != null)
                    {
                        foreach (var objgiayto in item.Chu.CongDong.NguoiDaiDien.DSGiayToTuyThan)
                        {
                            if (objgiayto != null)
                            {
                                var checkgiayto = (from g in dbo.DC_GIAYTOTUYTHAN where g.CANHANID == objgiayto.CANHANID && g.GIAYTOTUYTHANID == objgiayto.GIAYTOTUYTHANID select g).FirstOrDefault();
                                if (checkgiayto == null)
                                {
                                    DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                                    Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(objgiayto, obj);
                                    dbo.DC_GIAYTOTUYTHAN.Add(obj);
                                }
                            }
                        }
                    }

                }


                //check hộ gia đình thành viên
                var checkho = (from ho in dbo.DC_CONGDONG where ho.CONGDONGID == objtochuc.CONGDONGID select ho).FirstOrDefault();
                if (checkho == null)
                {
                    dbo.DC_CONGDONG.Add(objtochuc);
                    objtochuc.CONGDONGID = Guid.NewGuid().ToString();
                }
                else
                {
                    //checkho = objvochong;
                    checkho.NGUOIDAIDIENID = objtochuc.NGUOIDAIDIENID;
                }
                DC_DANGKY_NGUOI objdangkynguoi = new DC_DANGKY_NGUOI();
                DC_NGUOI objnguoi = new DC_NGUOI();
                objnguoi.NGUOIID = item.Chu.NGUOIID;
                objnguoi.CHITIETID = item.Chu.CongDong.CONGDONGID;
                objnguoi.LOAIDOITUONGID = "5";
                dbo.DC_NGUOI.Add(objnguoi);
                objdangkynguoi.DANGKYNGUOIID = Guid.NewGuid().ToString();
                objdangkynguoi.DONDANGKYID = item.DONDANGKYID;
                objdangkynguoi.LOAI = 5;
                objdangkynguoi.NGUOIID = objnguoi.NGUOIID;
                dbo.DC_DANGKY_NGUOI.Add(objdangkynguoi);
                dbo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public static bool SaveToChuc(DC_DANGKY_NGUOI item, MplisEntities dbo)
        {
            try
            {
                DC_TOCHUC objtochuc = new DC_TOCHUC();
                objtochuc.TOCHUCID = item.Chu.ToChuc.TOCHUCID;
                objtochuc = item.Chu.ToChuc;
                if (item.Chu.ToChuc.NGUOIDAIDIENID != null || item.Chu.ToChuc.NGUOIDAIDIENID != "")
                {
                    DC_CANHAN objcanhan_ChuHo = new DC_CANHAN();
                    Mapper.Map<DC_CANHAN, DC_CANHAN>(item.Chu.ToChuc.NguoiDaiDien, objcanhan_ChuHo);
                    objtochuc.NGUOIDAIDIENID = objcanhan_ChuHo.CANHANID;
                    var checkcanhan = (from vien in dbo.DC_CANHAN where vien.CANHANID == objcanhan_ChuHo.CANHANID select vien).FirstOrDefault();
                    if (checkcanhan == null)
                    {
                        dbo.DC_CANHAN.Add(objcanhan_ChuHo);
                    }

                    // lưu giấy tờ tùy thân chủ hộ
                    if (item.Chu.ToChuc.NguoiDaiDien.DSGiayToTuyThan != null)
                    {
                        foreach (var objgiayto in item.Chu.ToChuc.NguoiDaiDien.DSGiayToTuyThan)
                        {
                            if (objgiayto != null)
                            {
                                var checkgiayto = (from g in dbo.DC_GIAYTOTUYTHAN where g.CANHANID == objgiayto.CANHANID && g.GIAYTOTUYTHANID == objgiayto.GIAYTOTUYTHANID select g).FirstOrDefault();
                                if (checkgiayto == null)
                                {
                                    DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                                    Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(objgiayto, obj);
                                    dbo.DC_GIAYTOTUYTHAN.Add(obj);
                                }
                            }
                        }
                    }

                }


                //check hộ gia đình thành viên
                var checkho = (from ho in dbo.DC_TOCHUC where ho.TOCHUCID == objtochuc.TOCHUCID select ho).FirstOrDefault();
                if (checkho == null)
                {
                    dbo.DC_TOCHUC.Add(objtochuc);
                    objtochuc.TOCHUCID = Guid.NewGuid().ToString();
                }
                else
                {
                    //checkho = objvochong;
                    checkho.NGUOIDAIDIENID = objtochuc.NGUOIDAIDIENID;
                }
                DC_DANGKY_NGUOI objdangkynguoi = new DC_DANGKY_NGUOI();
                DC_NGUOI objnguoi = new DC_NGUOI();
                objnguoi.NGUOIID = item.Chu.NGUOIID;
                objnguoi.CHITIETID = item.Chu.ToChuc.TOCHUCID;
                objnguoi.LOAIDOITUONGID = "4";
                dbo.DC_NGUOI.Add(objnguoi);
                objdangkynguoi.DANGKYNGUOIID = Guid.NewGuid().ToString();
                objdangkynguoi.DONDANGKYID = item.DONDANGKYID;
                objdangkynguoi.LOAI = 4;
                objdangkynguoi.NGUOIID = objnguoi.NGUOIID;
                dbo.DC_DANGKY_NGUOI.Add(objdangkynguoi);
                dbo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public static bool SaveVoChong(DC_DANGKY_NGUOI item, MplisEntities dbo)
        {
            try
            {
                DC_VOCHONG objvochong = new DC_VOCHONG();
                objvochong.VOCHONGID = item.Chu.VoChong.VOCHONGID;
                objvochong.DIACHI = item.Chu.VoChong.DIACHI;
                if (item.Chu.VoChong.CHONG != null || item.Chu.VoChong.CHONG != "")
                {
                    DC_CANHAN objcanhan_ChuHo = new DC_CANHAN();
                    Mapper.Map<DC_CANHAN, DC_CANHAN>(item.Chu.VoChong.ChongCN, objcanhan_ChuHo);
                    objvochong.CHONG = objcanhan_ChuHo.CANHANID;
                    var checkcanhan = (from vien in dbo.DC_CANHAN where vien.CANHANID == objcanhan_ChuHo.CANHANID select vien).FirstOrDefault();
                    if (checkcanhan == null)
                    {
                        dbo.DC_CANHAN.Add(objcanhan_ChuHo);
                    }
                    objvochong.CMTCHONG = objcanhan_ChuHo.SOGIAYTO;
                    // lưu giấy tờ tùy thân chủ hộ
                    foreach (var objgiayto in item.Chu.VoChong.ChongCN.DSGiayToTuyThan)
                    {
                        if (objgiayto != null)
                        {
                            var checkgiayto = (from g in dbo.DC_GIAYTOTUYTHAN where g.CANHANID == objgiayto.CANHANID && g.GIAYTOTUYTHANID == objgiayto.GIAYTOTUYTHANID select g).FirstOrDefault();
                            if (checkgiayto == null)
                            {
                                DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                                Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(objgiayto, obj);
                                dbo.DC_GIAYTOTUYTHAN.Add(obj);
                            }
                        }
                    }

                }
                if (item.Chu.VoChong.VO != null || item.Chu.VoChong.VO != "")
                {
                    DC_CANHAN objcanhan_vochong = new DC_CANHAN();
                    Mapper.Map<DC_CANHAN, DC_CANHAN>(item.Chu.VoChong.VoCN, objcanhan_vochong);
                    var checkcanhan = (from vien in dbo.DC_CANHAN where vien.CANHANID == objcanhan_vochong.CANHANID select vien).FirstOrDefault();
                    if (checkcanhan == null)
                    {
                        dbo.DC_CANHAN.Add(objcanhan_vochong);
                    }
                    // dbo.SaveChanges();
                    objvochong.VO = objcanhan_vochong.CANHANID;
                    objvochong.CMTVO = objcanhan_vochong.SOGIAYTO;
                    // lưu giấy tờ tùy thân chủ hộ
                    if (item.Chu.VoChong.VoCN.DSGiayToTuyThan != null)
                    {
                        foreach (var objgiayto in item.Chu.VoChong.VoCN.DSGiayToTuyThan)
                        {
                            var checkgiayto = (from g in dbo.DC_GIAYTOTUYTHAN where g.CANHANID == objgiayto.CANHANID && g.GIAYTOTUYTHANID == objgiayto.GIAYTOTUYTHANID select g).FirstOrDefault();
                            if (checkgiayto == null)
                            {
                                DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                                Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(objgiayto, obj);
                                dbo.DC_GIAYTOTUYTHAN.Add(obj);
                            }
                        }
                    }
                }

                //check hộ gia đình thành viên
                var checkho = (from ho in dbo.DC_VOCHONG where ho.VOCHONGID == objvochong.VOCHONGID select ho).FirstOrDefault();
                if (checkho == null)
                {
                    dbo.DC_VOCHONG.Add(objvochong);
                }
                else
                {
                    //checkho = objvochong;
                    checkho.CHONG = objvochong.CHONG;
                    checkho.VO = objvochong.VO;
                    checkho.CMTCHONG = objvochong.CMTCHONG;
                    checkho.CMTVO = objvochong.CMTVO;
                    checkho.DIACHI = objvochong.DIACHI;

                }

                //   dbo.SaveChanges();
                DC_DANGKY_NGUOI objdangkynguoi = new DC_DANGKY_NGUOI();
                DC_NGUOI objnguoi = new DC_NGUOI();
                objnguoi.NGUOIID = item.Chu.NGUOIID;
                objnguoi.CHITIETID = item.Chu.VoChong.VOCHONGID;
                objnguoi.LOAIDOITUONGID = "3";
                dbo.DC_NGUOI.Add(objnguoi);
                objdangkynguoi.DANGKYNGUOIID = Guid.NewGuid().ToString();
                objdangkynguoi.DONDANGKYID = item.DONDANGKYID;
                objdangkynguoi.LOAI = 3;
                objdangkynguoi.NGUOIID = objnguoi.NGUOIID;
                dbo.DC_DANGKY_NGUOI.Add(objdangkynguoi);
                dbo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public static bool SaveHoGiaDinh(DC_DANGKY_NGUOI item, MplisEntities dbo)
        {
            try
            {
                DC_HOGIADINH objhogiadinh = new DC_HOGIADINH();
                objhogiadinh.HOGIADINHID = item.Chu.HoGiaDinh.HOGIADINHID;
                objhogiadinh.DIACHI = item.Chu.HoGiaDinh.DIACHI;
                if (item.Chu.HoGiaDinh.CHUHO != null || item.Chu.HoGiaDinh.CHUHO != "")
                {
                    DC_CANHAN objcanhan_ChuHo = new DC_CANHAN();
                    Mapper.Map<DC_CANHAN, DC_CANHAN>(item.Chu.HoGiaDinh.ChuHoCN, objcanhan_ChuHo);
                    objhogiadinh.CHUHO = objcanhan_ChuHo.CANHANID;
                    var checkcanhan = (from vien in dbo.DC_CANHAN where vien.CANHANID == objcanhan_ChuHo.CANHANID select vien).FirstOrDefault();
                    if (checkcanhan == null)
                    {
                        dbo.DC_CANHAN.Add(objcanhan_ChuHo);
                    }

                    DC_HOGIADINH_THANHVIEN objthanhvien = new DC_HOGIADINH_THANHVIEN();
                    objthanhvien.CANHANID = objhogiadinh.CHUHO;
                    //check hộ gia đình thành viên
                    var checkthanhvien = (from vien in dbo.DC_HOGIADINH_THANHVIEN where vien.HOGIADINHID == objhogiadinh.HOGIADINHID && vien.CANHANID == objhogiadinh.CHUHO select vien).FirstOrDefault();
                    if (checkthanhvien == null)
                    {
                        dbo.DC_HOGIADINH_THANHVIEN.Add(objthanhvien);
                    }
                    objthanhvien.HOGIADINHID = objhogiadinh.HOGIADINHID;
                    // objhogiadinh.CHUHO = item.lst_HoGiaDinh[0].CHUHO;
                    objhogiadinh.CMTCHUHO = objcanhan_ChuHo.SOGIAYTO;
                    //objthanhvien.QUANHEVOICHUHO = "Chủ hộ";
                    // lưu giấy tờ tùy thân chủ hộ
                    foreach (var objgiayto in item.Chu.HoGiaDinh.ChuHoCN.DSGiayToTuyThan)
                    {
                        if (objgiayto != null)
                        {
                            var checkgiayto = (from g in dbo.DC_GIAYTOTUYTHAN where g.CANHANID == objgiayto.CANHANID && g.GIAYTOTUYTHANID == objgiayto.GIAYTOTUYTHANID select g).FirstOrDefault();
                            if (checkgiayto == null)
                            {
                                DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                                Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(objgiayto, obj);
                                dbo.DC_GIAYTOTUYTHAN.Add(obj);
                            }
                        }
                    }

                }
                if (item.Chu.HoGiaDinh.VOCHONG != null || item.Chu.HoGiaDinh.VOCHONG != "")
                {
                    DC_CANHAN objcanhan_vochong = new DC_CANHAN();
                    Mapper.Map<DC_CANHAN, DC_CANHAN>(item.Chu.HoGiaDinh.VoChongCN, objcanhan_vochong);
                    var checkcanhan = (from vien in dbo.DC_CANHAN where vien.CANHANID == objcanhan_vochong.CANHANID select vien).FirstOrDefault();
                    if (checkcanhan == null)
                    {
                        dbo.DC_CANHAN.Add(objcanhan_vochong);
                    }

                    objhogiadinh.VOCHONG = objcanhan_vochong.CANHANID;
                    DC_HOGIADINH_THANHVIEN objthanhvien = new DC_HOGIADINH_THANHVIEN();
                    objthanhvien.CANHANID = objhogiadinh.VOCHONG;
                    //check hộ gia đình thành viên
                    var checkthanhvien = (from vien in dbo.DC_HOGIADINH_THANHVIEN where vien.HOGIADINHID == objhogiadinh.HOGIADINHID && vien.CANHANID == objhogiadinh.VOCHONG select vien).FirstOrDefault();
                    if (checkthanhvien == null)
                    {
                        dbo.DC_HOGIADINH_THANHVIEN.Add(objthanhvien);
                    }

                    objthanhvien.HOGIADINHID = objhogiadinh.HOGIADINHID;
                    // objhogiadinh.VOCHONG = item.lst_HoGiaDinh[0].VOCHONG;
                    objhogiadinh.CMTVOCHONG = objcanhan_vochong.SOGIAYTO;
                    //objthanhvien.QUANHEVOICHUHO = "Vợ/chồng";
                    // lưu giấy tờ tùy thân chủ hộ
                    foreach (var objgiayto in item.Chu.HoGiaDinh.VoChongCN.DSGiayToTuyThan)
                    {
                        var checkgiayto = (from g in dbo.DC_GIAYTOTUYTHAN where g.CANHANID == objgiayto.CANHANID && g.GIAYTOTUYTHANID == objgiayto.GIAYTOTUYTHANID select g).FirstOrDefault();
                        if (checkgiayto == null)
                        {
                            DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                            Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(objgiayto, obj);
                            dbo.DC_GIAYTOTUYTHAN.Add(obj);
                        }
                    }
                }
                if (item.Chu.HoGiaDinh.DSThanhVien.Count > 0)
                {
                    foreach (var a in item.Chu.HoGiaDinh.DSThanhVien)
                    {
                        if (a.ThanhVien.CANHANID != item.Chu.HoGiaDinh.VOCHONG && a.ThanhVien.CANHANID != item.Chu.HoGiaDinh.CHUHO)
                        {
                            DC_CANHAN objcanhan_thanhvien = new DC_CANHAN();
                            Mapper.Map<DC_CANHAN, DC_CANHAN>(a.ThanhVien, objcanhan_thanhvien);
                            var checkcanhan = (from vien in dbo.DC_CANHAN where vien.CANHANID == objcanhan_thanhvien.CANHANID select vien).FirstOrDefault();
                            if (checkcanhan == null)
                            {
                                dbo.DC_CANHAN.Add(objcanhan_thanhvien);
                            }

                            DC_HOGIADINH_THANHVIEN objthanhvien = new DC_HOGIADINH_THANHVIEN();
                            objthanhvien.CANHANID = objcanhan_thanhvien.CANHANID;
                            objthanhvien.HOGIADINHID = objhogiadinh.HOGIADINHID;
                            //objthanhvien.QUANHEVOICHUHO = a.QUANHEVOICHUHO;


                            // lưu giấy tờ tùy thân cho thành viên
                            foreach (var objgiayto in a.ThanhVien.DSGiayToTuyThan)
                            {
                                if (objgiayto != null)
                                {
                                    var checkgiayto = (from g in dbo.DC_GIAYTOTUYTHAN where g.CANHANID == objgiayto.CANHANID && g.GIAYTOTUYTHANID == objgiayto.GIAYTOTUYTHANID select g).FirstOrDefault();
                                    if (checkgiayto == null)
                                    {
                                        DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                                        Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(objgiayto, obj);
                                        dbo.DC_GIAYTOTUYTHAN.Add(obj);
                                    }
                                }
                            }
                            //check hộ gia đình thành viên
                            var checkthanhvien = (from vien in dbo.DC_HOGIADINH_THANHVIEN where vien.HOGIADINHID == objhogiadinh.HOGIADINHID && vien.CANHANID == objcanhan_thanhvien.CANHANID select vien).FirstOrDefault();
                            if (checkthanhvien == null)
                            {
                                dbo.DC_HOGIADINH_THANHVIEN.Add(objthanhvien);
                            }
                            //   dbo.DC_HOGIADINH_THANHVIEN.Add(objthanhvien);
                        }

                    }
                }
                //check hộ gia đình thành viên
                var checkho = (from ho in dbo.DC_HOGIADINH where ho.HOGIADINHID == objhogiadinh.HOGIADINHID select ho).FirstOrDefault();
                if (checkho == null)
                {
                    dbo.DC_HOGIADINH.Add(objhogiadinh);
                }
                else
                {
                    checkho.CHUHO = objhogiadinh.CHUHO;
                    checkho.VOCHONG = objhogiadinh.VOCHONG;
                    checkho.CMTCHUHO = objhogiadinh.CMTCHUHO;
                    checkho.CMTVOCHONG = objhogiadinh.CMTVOCHONG;
                    checkho.DIACHI = objhogiadinh.DIACHI;
                }

                // dbo.SaveChanges();
                DC_DANGKY_NGUOI objdangkynguoi = new DC_DANGKY_NGUOI();
                DC_NGUOI objnguoi = new DC_NGUOI();
                objnguoi.NGUOIID = item.Chu.NGUOIID;
                objnguoi.CHITIETID = item.Chu.HoGiaDinh.HOGIADINHID;
                objnguoi.LOAIDOITUONGID = "2";
                dbo.DC_NGUOI.Add(objnguoi);

                objdangkynguoi.DANGKYNGUOIID = Guid.NewGuid().ToString();
                objdangkynguoi.DONDANGKYID = item.DONDANGKYID;
                objdangkynguoi.LOAI = 2;
                objdangkynguoi.NGUOIID = objnguoi.NGUOIID;
                dbo.DC_DANGKY_NGUOI.Add(objdangkynguoi);
                dbo.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public static bool SaveHoGiaDinhThuocNhom(DC_HOGIADINH item, MplisEntities dbo, DC_NHOMNGUOI objnhom, out bool them)
        {
            DC_HOGIADINH objhogiadinh = new DC_HOGIADINH();
            objhogiadinh.HOGIADINHID = item.HOGIADINHID;
            objhogiadinh.DIACHI = item.DIACHI;
            if (item.CHUHO != null || item.CHUHO != "")
            {
                DC_CANHAN objcanhan_ChuHo = new DC_CANHAN();
                Mapper.Map<DC_CANHAN, DC_CANHAN>(item.ChuHoCN, objcanhan_ChuHo);
                objhogiadinh.CHUHO = objcanhan_ChuHo.CANHANID;
                var checkcanhan = (from vien in dbo.DC_CANHAN where vien.CANHANID == objcanhan_ChuHo.CANHANID select vien).FirstOrDefault();
                if (checkcanhan == null)
                {
                    dbo.DC_CANHAN.Add(objcanhan_ChuHo);
                }

                DC_HOGIADINH_THANHVIEN objthanhvien = new DC_HOGIADINH_THANHVIEN();
                objthanhvien.CANHANID = objhogiadinh.CHUHO;
                //check hộ gia đình thành viên
                var checkthanhvien = (from vien in dbo.DC_HOGIADINH_THANHVIEN where vien.HOGIADINHID == objhogiadinh.HOGIADINHID && vien.CANHANID == objhogiadinh.CHUHO select vien).FirstOrDefault();
                if (checkthanhvien == null)
                {
                    objthanhvien.HOGIADINHID = objhogiadinh.HOGIADINHID;
                    dbo.DC_HOGIADINH_THANHVIEN.Add(objthanhvien);
                }

                // objhogiadinh.CHUHO = item.lst_HoGiaDinh[0].CHUHO;
                objhogiadinh.CMTCHUHO = objcanhan_ChuHo.SOGIAYTO;
                //objthanhvien.QUANHEVOICHUHO = "Chủ hộ";
                // lưu giấy tờ tùy thân chủ hộ
                if (item.ChuHoCN.DSGiayToTuyThan != null)
                {
                    foreach (var objgiayto in item.ChuHoCN.DSGiayToTuyThan)
                    {
                        if (objgiayto != null)
                        {
                            var checkgiayto = (from g in dbo.DC_GIAYTOTUYTHAN where g.CANHANID == objgiayto.CANHANID && g.GIAYTOTUYTHANID == objgiayto.GIAYTOTUYTHANID select g).FirstOrDefault();
                            if (checkgiayto == null)
                            {
                                DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                                Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(objgiayto, obj);
                                dbo.DC_GIAYTOTUYTHAN.Add(obj);
                            }
                        }
                    }
                }

            }
            //  dbo.SaveChanges();
            if (item.VOCHONG != null || item.VOCHONG != "")
            {
                DC_CANHAN objcanhan_vochong = new DC_CANHAN();
                Mapper.Map<DC_CANHAN, DC_CANHAN>(item.VoChongCN, objcanhan_vochong);
                var checkcanhan = (from vien in dbo.DC_CANHAN where vien.CANHANID == objcanhan_vochong.CANHANID select vien).FirstOrDefault();
                if (checkcanhan == null)
                {
                    dbo.DC_CANHAN.Add(objcanhan_vochong);
                }

                objhogiadinh.VOCHONG = objcanhan_vochong.CANHANID;
                DC_HOGIADINH_THANHVIEN objthanhvien = new DC_HOGIADINH_THANHVIEN();
                objthanhvien.CANHANID = objhogiadinh.VOCHONG;
                //check hộ gia đình thành viên
                var checkthanhvien = (from vien in dbo.DC_HOGIADINH_THANHVIEN where vien.HOGIADINHID == objhogiadinh.HOGIADINHID && vien.CANHANID == objhogiadinh.VOCHONG select vien).FirstOrDefault();
                if (checkthanhvien == null)
                {
                    objthanhvien.HOGIADINHID = objhogiadinh.HOGIADINHID;
                    dbo.DC_HOGIADINH_THANHVIEN.Add(objthanhvien);
                }


                // objhogiadinh.VOCHONG = item.lst_HoGiaDinh[0].VOCHONG;
                objhogiadinh.CMTVOCHONG = objcanhan_vochong.SOGIAYTO;
                //objthanhvien.QUANHEVOICHUHO = "Vợ/chồng";
                // lưu giấy tờ tùy thân chủ hộ
                if (item.VoChongCN.DSGiayToTuyThan != null)
                {
                    foreach (var objgiayto in item.VoChongCN.DSGiayToTuyThan)
                    {
                        var checkgiayto = (from g in dbo.DC_GIAYTOTUYTHAN where g.CANHANID == objgiayto.CANHANID && g.GIAYTOTUYTHANID == objgiayto.GIAYTOTUYTHANID select g).FirstOrDefault();
                        if (checkgiayto == null)
                        {
                            DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                            Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(objgiayto, obj);
                            dbo.DC_GIAYTOTUYTHAN.Add(obj);
                        }
                    }
                }
            }
            //   dbo.SaveChanges();
            if (item.DSThanhVien.Count > 0)
            {
                foreach (var a in item.DSThanhVien)
                {
                    if (a.ThanhVien.CANHANID != item.VOCHONG && a.ThanhVien.CANHANID != item.CHUHO)
                    {
                        DC_CANHAN objcanhan_thanhvien = new DC_CANHAN();
                        Mapper.Map<DC_CANHAN, DC_CANHAN>(a.ThanhVien, objcanhan_thanhvien);
                        var checkcanhan = (from vien in dbo.DC_CANHAN where vien.CANHANID == objcanhan_thanhvien.CANHANID select vien).FirstOrDefault();
                        if (checkcanhan == null)
                        {
                            dbo.DC_CANHAN.Add(objcanhan_thanhvien);
                        }

                        DC_HOGIADINH_THANHVIEN objthanhvien = new DC_HOGIADINH_THANHVIEN();
                        objthanhvien.CANHANID = objcanhan_thanhvien.CANHANID;
                        objthanhvien.HOGIADINHID = objhogiadinh.HOGIADINHID;
                        //objthanhvien.QUANHEVOICHUHO = a.QUANHEVOICHUHO;


                        // lưu giấy tờ tùy thân cho thành viên
                        foreach (var objgiayto in a.ThanhVien.DSGiayToTuyThan)
                        {
                            if (objgiayto != null)
                            {
                                var checkgiayto = (from g in dbo.DC_GIAYTOTUYTHAN where g.CANHANID == objgiayto.CANHANID && g.GIAYTOTUYTHANID == objgiayto.GIAYTOTUYTHANID select g).FirstOrDefault();
                                if (checkgiayto == null)
                                {
                                    DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                                    Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(objgiayto, obj);
                                    dbo.DC_GIAYTOTUYTHAN.Add(obj);
                                }
                            }
                        }
                        //check hộ gia đình thành viên
                        var checkthanhvien = (from vien in dbo.DC_HOGIADINH_THANHVIEN where vien.HOGIADINHID == objhogiadinh.HOGIADINHID && vien.CANHANID == objcanhan_thanhvien.CANHANID select vien).FirstOrDefault();
                        if (checkthanhvien == null)
                        {
                            dbo.DC_HOGIADINH_THANHVIEN.Add(objthanhvien);
                        }
                        //   dbo.DC_HOGIADINH_THANHVIEN.Add(objthanhvien);
                    }

                }
            }
            //check hộ gia đình thành viên
            var checkho = (from ho in dbo.DC_HOGIADINH where ho.HOGIADINHID == objhogiadinh.HOGIADINHID select ho).FirstOrDefault();
            if (checkho == null)
            {
                dbo.DC_HOGIADINH.Add(objhogiadinh);
                them = true;
            }
            else
            {
                checkho.CHUHO = objhogiadinh.CHUHO;
                checkho.VOCHONG = objhogiadinh.VOCHONG;
                checkho.CMTCHUHO = objhogiadinh.CMTCHUHO;
                checkho.CMTVOCHONG = objhogiadinh.CMTVOCHONG;
                checkho.DIACHI = objhogiadinh.DIACHI;
                them = false;
            }
            //  dbo.SaveChanges();
            var checknhomnguoi = (from nhom in dbo.DC_NHOMNGUOI where nhom.NHOMNGUOIID == objnhom.NHOMNGUOIID select nhom).FirstOrDefault();

            if (checknhomnguoi == null)
            {
                //checknhomnguoi = new DC_NHOMNGUOI();
                objnhom.NGUOIDAIDIEN = objhogiadinh.HOGIADINHID;
                dbo.DC_NHOMNGUOI.Add(objnhom);
            }
            //  dbo.SaveChanges();
            //cập nhật danh sách thành viên
            //var objthanhviennhom = (from itemthanhvien in dbo.DC_NHOMNGUOI_THANHVIEN where itemthanhvien.NHOMNGUOIID == objnhom.NHOMNGUOIID && itemthanhvien.THANHPHANID == objhogiadinh.HOGIADINHID select itemthanhvien).FirstOrDefault();
            //if (objthanhviennhom == null)
            //{
            //    DC_NHOMNGUOI_THANHVIEN obj = new DC_NHOMNGUOI_THANHVIEN();
            //    //obj.THANHPHANID = objhogiadinh.HOGIADINHID;
            //    obj.LOAIDOITUONG = 2;
            //    obj.NHOMNGUOIID = objnhom.NHOMNGUOIID;
            //    dbo.DC_NHOMNGUOI_THANHVIEN.Add(obj);
            //}
            dbo.SaveChanges();
            return them;


        }

        public static bool SaveHoVoChongThuocNhom(DC_VOCHONG item, MplisEntities dbo, DC_NHOMNGUOI objnhom, out bool them)
        {
            DC_VOCHONG objvochong = new DC_VOCHONG();
            objvochong.VOCHONGID = item.VOCHONGID;
            objvochong.DIACHI = item.DIACHI;
            //  them = false;
            if (item.CHONG != null || item.CHONG != "")
            {
                DC_CANHAN objcanhan_ChuHo = new DC_CANHAN();
                Mapper.Map<DC_CANHAN, DC_CANHAN>(item.ChongCN, objcanhan_ChuHo);
                objvochong.CHONG = objcanhan_ChuHo.CANHANID;
                var checkcanhan = (from vien in dbo.DC_CANHAN where vien.CANHANID == objcanhan_ChuHo.CANHANID select vien).FirstOrDefault();
                if (checkcanhan == null)
                {
                    dbo.DC_CANHAN.Add(objcanhan_ChuHo);
                }
                objvochong.CMTCHONG = objcanhan_ChuHo.SOGIAYTO;
                // lưu giấy tờ tùy thân chủ hộ
                if (item.ChongCN.DSGiayToTuyThan != null)
                {
                    foreach (var objgiayto in item.ChongCN.DSGiayToTuyThan)
                    {
                        if (objgiayto != null)
                        {
                            var checkgiayto = (from g in dbo.DC_GIAYTOTUYTHAN where g.CANHANID == objgiayto.CANHANID && g.GIAYTOTUYTHANID == objgiayto.GIAYTOTUYTHANID select g).FirstOrDefault();
                            if (checkgiayto == null)
                            {
                                DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                                Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(objgiayto, obj);
                                dbo.DC_GIAYTOTUYTHAN.Add(obj);
                            }
                        }
                    }
                }

            }
            if (item.VO != null || item.VO != "")
            {
                DC_CANHAN objcanhan_vochong = new DC_CANHAN();
                Mapper.Map<DC_CANHAN, DC_CANHAN>(item.VoCN, objcanhan_vochong);
                var checkcanhan = (from vien in dbo.DC_CANHAN where vien.CANHANID == objcanhan_vochong.CANHANID select vien).FirstOrDefault();
                if (checkcanhan == null)
                {
                    dbo.DC_CANHAN.Add(objcanhan_vochong);
                }
                // dbo.SaveChanges();
                objvochong.VO = objcanhan_vochong.CANHANID;
                objvochong.CMTVO = objcanhan_vochong.SOGIAYTO;
                // lưu giấy tờ tùy thân chủ hộ
                if (item.VoCN.DSGiayToTuyThan != null)
                {
                    foreach (var objgiayto in item.VoCN.DSGiayToTuyThan)
                    {
                        var checkgiayto = (from g in dbo.DC_GIAYTOTUYTHAN where g.CANHANID == objgiayto.CANHANID && g.GIAYTOTUYTHANID == objgiayto.GIAYTOTUYTHANID select g).FirstOrDefault();
                        if (checkgiayto == null)
                        {
                            DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                            Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(objgiayto, obj);
                            dbo.DC_GIAYTOTUYTHAN.Add(obj);
                        }
                    }
                }
            }

            //check hộ gia đình thành viên
            var checkho = (from ho in dbo.DC_VOCHONG where ho.VOCHONGID == objvochong.VOCHONGID select ho).FirstOrDefault();
            if (checkho == null)
            {
                dbo.DC_VOCHONG.Add(objvochong);
                them = true;
            }
            else
            {
                //checkho = objvochong;
                checkho.CHONG = objvochong.CHONG;
                checkho.VO = objvochong.VO;
                checkho.CMTCHONG = objvochong.CMTCHONG;
                checkho.CMTVO = objvochong.CMTVO;
                checkho.DIACHI = objvochong.DIACHI;
                them = false;
            }


            var checknhomnguoi = (from nhom in dbo.DC_NHOMNGUOI where nhom.NHOMNGUOIID == objnhom.NHOMNGUOIID select nhom).FirstOrDefault();

            if (checknhomnguoi == null)
            {
                //checknhomnguoi = new DC_NHOMNGUOI();

                dbo.DC_NHOMNGUOI.Add(objnhom);
            }
            //cập nhật danh sách thành viên
            //var objthanhviennhom = (from itemthanhvien in dbo.DC_NHOMNGUOI_THANHVIEN where itemthanhvien.NHOMNGUOIID == objnhom.NHOMNGUOIID && itemthanhvien.THANHPHANID == objvochong.VOCHONGID select itemthanhvien).FirstOrDefault();
            //if (objthanhviennhom == null)
            //{
            //    DC_NHOMNGUOI_THANHVIEN obj = new DC_NHOMNGUOI_THANHVIEN();
            //    obj.THANHPHANID = objvochong.VOCHONGID;
            //    obj.LOAIDOITUONG = 3;
            //    obj.NHOMNGUOIID = objnhom.NHOMNGUOIID;
            //    dbo.DC_NHOMNGUOI_THANHVIEN.Add(obj);
            //}
            dbo.SaveChanges();
            return them;


        }

        public static bool SaveHoToChucThuocNhom(DC_TOCHUC item, MplisEntities dbo, DC_NHOMNGUOI objnhom, out bool them)
        {

            DC_TOCHUC objtochuc = new DC_TOCHUC();
            objtochuc.TOCHUCID = item.TOCHUCID;
            objtochuc = item;
            if (item.NGUOIDAIDIENID != null || item.NGUOIDAIDIENID != "")
            {
                DC_CANHAN objcanhan_ChuHo = new DC_CANHAN();
                Mapper.Map<DC_CANHAN, DC_CANHAN>(item.NguoiDaiDien, objcanhan_ChuHo);
                objtochuc.NGUOIDAIDIENID = objcanhan_ChuHo.CANHANID;
                var checkcanhan = (from vien in dbo.DC_CANHAN where vien.CANHANID == objcanhan_ChuHo.CANHANID select vien).FirstOrDefault();
                if (checkcanhan == null)
                {
                    dbo.DC_CANHAN.Add(objcanhan_ChuHo);
                }

                // lưu giấy tờ tùy thân chủ hộ
                if (item.NguoiDaiDien.DSGiayToTuyThan != null)
                {
                    foreach (var objgiayto in item.NguoiDaiDien.DSGiayToTuyThan)
                    {
                        if (objgiayto != null)
                        {
                            var checkgiayto = (from g in dbo.DC_GIAYTOTUYTHAN where g.CANHANID == objgiayto.CANHANID && g.GIAYTOTUYTHANID == objgiayto.GIAYTOTUYTHANID select g).FirstOrDefault();
                            if (checkgiayto == null)
                            {
                                DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                                Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(objgiayto, obj);
                                dbo.DC_GIAYTOTUYTHAN.Add(obj);
                            }
                        }
                    }
                }

            }


            //check hộ gia đình thành viên
            var checkho = (from ho in dbo.DC_TOCHUC where ho.TOCHUCID == objtochuc.TOCHUCID select ho).FirstOrDefault();
            if (checkho == null)
            {
                dbo.DC_TOCHUC.Add(objtochuc);
                objtochuc.TOCHUCID = Guid.NewGuid().ToString();
                them = true;
            }
            else
            {
                //checkho = objvochong;
                checkho.NGUOIDAIDIENID = objtochuc.NGUOIDAIDIENID;
                them = false;
            }
            var checknhomnguoi = (from nhom in dbo.DC_NHOMNGUOI where nhom.NHOMNGUOIID == objnhom.NHOMNGUOIID select nhom).FirstOrDefault();

            if (checknhomnguoi == null)
            {
                //checknhomnguoi = new DC_NHOMNGUOI();

                dbo.DC_NHOMNGUOI.Add(objnhom);
            }
            //cập nhật danh sách thành viên
            //var objthanhviennhom = (from itemthanhvien in dbo.DC_NHOMNGUOI_THANHVIEN where itemthanhvien.NHOMNGUOIID == objnhom.NHOMNGUOIID && itemthanhvien.THANHPHANID == objtochuc.TOCHUCID select itemthanhvien).FirstOrDefault();
            //if (objthanhviennhom == null)
            //{
            //    DC_NHOMNGUOI_THANHVIEN obj = new DC_NHOMNGUOI_THANHVIEN();
            //    obj.THANHPHANID = objtochuc.TOCHUCID;
            //    obj.LOAIDOITUONG = 4;
            //    obj.NHOMNGUOIID = objnhom.NHOMNGUOIID;
            //    dbo.DC_NHOMNGUOI_THANHVIEN.Add(obj);
            //}
            dbo.SaveChanges();
            return them;
        }


        public static bool SaveCongDongNhom(DC_CONGDONG item, MplisEntities dbo, DC_NHOMNGUOI objnhom, out bool them)
        {

            DC_CONGDONG objtochuc = new DC_CONGDONG();
            objtochuc.CONGDONGID = item.CONGDONGID;
            objtochuc = item;
            if (item.NGUOIDAIDIENID != null || item.NGUOIDAIDIENID != "")
            {
                DC_CANHAN objcanhan_ChuHo = new DC_CANHAN();
                Mapper.Map<DC_CANHAN, DC_CANHAN>(item.NguoiDaiDien, objcanhan_ChuHo);
                objtochuc.NGUOIDAIDIENID = objcanhan_ChuHo.CANHANID;
                var checkcanhan = (from vien in dbo.DC_CANHAN where vien.CANHANID == objcanhan_ChuHo.CANHANID select vien).FirstOrDefault();
                if (checkcanhan == null)
                {
                    dbo.DC_CANHAN.Add(objcanhan_ChuHo);
                }

                // lưu giấy tờ tùy thân chủ hộ
                if (item.NguoiDaiDien.DSGiayToTuyThan != null)
                {
                    foreach (var objgiayto in item.NguoiDaiDien.DSGiayToTuyThan)
                    {
                        if (objgiayto != null)
                        {
                            var checkgiayto = (from g in dbo.DC_GIAYTOTUYTHAN where g.CANHANID == objgiayto.CANHANID && g.GIAYTOTUYTHANID == objgiayto.GIAYTOTUYTHANID select g).FirstOrDefault();
                            if (checkgiayto == null)
                            {
                                DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                                Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(objgiayto, obj);
                                dbo.DC_GIAYTOTUYTHAN.Add(obj);
                            }
                        }
                    }
                }

            }
            //check hộ gia đình thành viên
            var checkho = (from ho in dbo.DC_CONGDONG where ho.CONGDONGID == objtochuc.CONGDONGID select ho).FirstOrDefault();
            if (checkho == null)
            {
                dbo.DC_CONGDONG.Add(objtochuc);
                objtochuc.CONGDONGID = Guid.NewGuid().ToString();
                them = true;
            }
            else
            {
                //checkho = objvochong;
                checkho.NGUOIDAIDIENID = objtochuc.NGUOIDAIDIENID;
                them = false;
            }
            var checknhomnguoi = (from nhom in dbo.DC_NHOMNGUOI where nhom.NHOMNGUOIID == objnhom.NHOMNGUOIID select nhom).FirstOrDefault();

            if (checknhomnguoi == null)
            {
                //checknhomnguoi = new DC_NHOMNGUOI();

                dbo.DC_NHOMNGUOI.Add(objnhom);
            }
            //cập nhật danh sách thành viên
            //var objthanhviennhom = (from itemthanhvien in dbo.DC_NHOMNGUOI_THANHVIEN where itemthanhvien.NHOMNGUOIID == objnhom.NHOMNGUOIID && itemthanhvien.THANHPHANID == objtochuc.CONGDONGID select itemthanhvien).FirstOrDefault();
            //if (objthanhviennhom == null)
            //{
            //    DC_NHOMNGUOI_THANHVIEN obj = new DC_NHOMNGUOI_THANHVIEN();
            //    obj.THANHPHANID = objtochuc.CONGDONGID;
            //    obj.LOAIDOITUONG = 5;
            //    obj.NHOMNGUOIID = objnhom.NHOMNGUOIID;
            //    dbo.DC_NHOMNGUOI_THANHVIEN.Add(obj);
            //}
            dbo.SaveChanges();
            return them;


        }

        public static List<DC_GIAYTOTUYTHAN> getgiaytotuythan(List<DC_GIAYTOTUYTHAN> lst)
        {
            if (lst == null || lst.Count == 0) return lst;

            using (MplisEntities database = new MplisEntities())
            {
                foreach (var a in lst)
                {
                    if (a != null)
                    {
                        var loaigiayto = (from item in database.DM_LOAIGIAYTOTUYTHAN where item.LOAIGIAYTOTUYTHANID == a.LOAIGIAYTOTUYTHANID select item).FirstOrDefault();
                        if (loaigiayto != null)
                        {
                            a.TenGiayToTuyThan = loaigiayto.TENLOAIGIAYTOTUYTHAN;
                        }
                    }
                }
            }
            return lst;
        }

        public static List<DC_NGUOI_SearchNguoi> searchcanhan(string socmt)
        {
            var CNN_listFind = new List<DC_NGUOI_SearchNguoi>();
            using (MplisEntities dbo = new MplisEntities())
            {
                //var predicate = PrecateBuilder.True<DC_CANHAN>();
                //predicate = predicate.And();
                var querynguoi = (from canhan in dbo.DC_CANHAN.Where(x => x.SOGIAYTO.Trim().ToUpper().Equals(socmt.Trim().ToUpper()))
                                  select new DC_NGUOI_CaNhan
                                  {
                                      CANHANID = canhan.CANHANID,
                                      HOTEN = canhan.HOTEN,
                                      SOGIAYTO = canhan.SOGIAYTO,
                                      DIACHI = canhan.DIACHI,
                                  }
                                  );

                foreach (var item in querynguoi)
                {

                    DC_NGUOI_SearchNguoi obj = new DC_NGUOI_SearchNguoi();
                    obj.CANHANID = item.CANHANID;
                    obj.HOTEN = item.HOTEN;
                    obj.DIACHI = item.DIACHI;
                    obj.SOGIAYTO = item.SOGIAYTO;
                    var objselect = (from abc in dbo.DC_NGUOI.Where(x => x.CHITIETID == item.CANHANID) select new { nguoiid = abc.NGUOIID }).FirstOrDefault();
                    if (objselect != null)
                    {
                        obj.NGUOIID = objselect.nguoiid;
                    }
                    // obj.NGUOIID = item.NGUOIID;
                    CNN_listFind.Add(obj);
                }
            }
            return CNN_listFind;
        }
        public static List<DC_NGUOI_SearchHoGiaDinh> searchHogiadinh(string socmt)
        {
            var CNN_listFind = new List<DC_NGUOI_SearchHoGiaDinh>();
            using (MplisEntities dbo = new MplisEntities())
            {


                //var predicate = PrecateBuilder.True<DC_HOGIADINH>();
                //predicate = predicate.And(x => x.CMTCHUHO.Trim().ToUpper().Equals(socmt.Trim().ToUpper()));
                var querynguoi = (from canhan in dbo.DC_HOGIADINH.Where(x => x.CMTCHUHO.Trim().ToUpper().Equals(socmt.Trim().ToUpper()))
                                  select new
                                  {
                                      HOGIADINHID = canhan.HOGIADINHID,
                                      CHUHO = canhan.CHUHO,
                                      VOCHONG = canhan.VOCHONG,
                                  }
                                  );

                var querynguoi1 = (from canhan in dbo.DC_HOGIADINH.Where(x => x.CMTCHUHO.Trim().ToUpper().Equals(socmt.Trim().ToUpper()))
                                   select new DC_NGUOI_SearchHoGiaDinh
                                   {
                                       HOGIADINHID = canhan.HOGIADINHID,
                                       HOTEN_CHUHO = canhan.ChuHoCN.HOTEN,
                                       CMTCHUHO = canhan.ChuHoCN.SOGIAYTO,
                                       HOTEN_VOCHONG = canhan.VoChongCN.HOTEN,
                                       CMTVOCHONG = canhan.VoChongCN.SOGIAYTO,
                                   }
                                 );
                foreach (var item in querynguoi)
                {

                    DC_NGUOI_SearchHoGiaDinh obj = new DC_NGUOI_SearchHoGiaDinh();
                    obj.HOGIADINHID = item.HOGIADINHID;

                    var objchuho = (from abc in dbo.DC_CANHAN.Where(x => x.CANHANID == item.CHUHO) select abc).FirstOrDefault();
                    if (objchuho != null)
                    {
                        obj.HOTEN_CHUHO = objchuho.HODEM + " " + objchuho.TEN;
                        obj.CMTCHUHO = objchuho.SOGIAYTO;

                    }
                    var objVoChong = (from abc in dbo.DC_CANHAN.Where(x => x.CANHANID == item.VOCHONG) select abc).FirstOrDefault();
                    if (objVoChong != null)
                    {
                        obj.HOTEN_VOCHONG = objVoChong.HODEM + " " + objVoChong.TEN;
                        obj.CMTVOCHONG = objchuho.SOGIAYTO;
                    }
                    // obj.NGUOIID = item.NGUOIID;
                    CNN_listFind.Add(obj);
                }
                // CNN_listFind = querynguoi;
            }
            return CNN_listFind;
        }

        // tìm kiếm tổ chức
        public static List<DC_NGUOI_SearchToChuc> searchToChuc(string socmt)
        {
            var CNN_listFind = new List<DC_NGUOI_SearchToChuc>();
            using (MplisEntities dbo = new MplisEntities())
            {
                //var predicate = PrecateBuilder.True<DC_TOCHUC>();
                //predicate = predicate.And(x => x.MASOTHUE.Trim().ToUpper().Equals(socmt.Trim().ToUpper()));
                var querynguoi = (from canhan in dbo.DC_TOCHUC.Where(x => x.MASOTHUE.Trim().ToUpper().Equals(socmt.Trim().ToUpper()))
                                  select new DC_NGUOI_SearchToChuc
                                  {
                                      TOCHUCID = canhan.TOCHUCID,
                                      TENTOCHUC = canhan.TENTOCHUC,
                                      SOQUYETDINH = canhan.SOQUYETDINH,
                                      MASOTHUE = canhan.MASOTHUE,
                                      NGUOIDAIDIEN = canhan.NGUOIDAIDIENID
                                  }
                                  );

                foreach (var item in querynguoi)
                {

                    DC_NGUOI_SearchToChuc obj = new DC_NGUOI_SearchToChuc();
                    obj.TOCHUCID = item.TOCHUCID;
                    obj.TENTOCHUC = item.TENTOCHUC;
                    obj.SOQUYETDINH = item.SOQUYETDINH;
                    obj.MASOTHUE = item.MASOTHUE;
                    var objselect = (from abc in dbo.DC_CANHAN.Where(x => x.CANHANID == item.NGUOIDAIDIEN) select abc).FirstOrDefault();
                    if (objselect != null)
                    {
                        obj.NGUOIDAIDIEN = objselect.HODEM + " " + objselect.TEN;
                    }
                    // obj.NGUOIID = item.NGUOIID;
                    CNN_listFind.Add(obj);
                }
            }
            return CNN_listFind;
        }
        // tìm kiếm tổ chức
        public static List<DC_NGUOI_SearchCongDong> searchCongDong(string tencongdong)
        {
            var CNN_listFind = new List<DC_NGUOI_SearchCongDong>();
            using (MplisEntities dbo = new MplisEntities())
            {
                //var predicate = PrecateBuilder.True<DC_CONGDONG>();
                //predicate = predicate.And(x => x.TENCONGDONG.Trim().ToUpper().Contains(tencongdong.Trim().ToUpper()));
                var querynguoi = (from canhan in dbo.DC_CONGDONG.Where(x => x.TENCONGDONG.Trim().ToUpper().Contains(tencongdong.Trim().ToUpper()))
                                  select new DC_NGUOI_SearchCongDong
                                  {
                                      CONGDONGID = canhan.CONGDONGID,
                                      TENCONGDONG = canhan.TENCONGDONG,
                                      DIACHICONGDONG = canhan.DIACHI,

                                      NGUOIDAIDIEN = canhan.NGUOIDAIDIENID
                                  }
                                  );

                foreach (var item in querynguoi)
                {

                    DC_NGUOI_SearchCongDong obj = new DC_NGUOI_SearchCongDong();
                    obj.CONGDONGID = item.CONGDONGID;
                    obj.TENCONGDONG = item.TENCONGDONG;
                    obj.DIACHICONGDONG = item.DIACHICONGDONG;
                    var objselect = (from abc in dbo.DC_CANHAN.Where(x => x.CANHANID == item.NGUOIDAIDIEN) select abc).FirstOrDefault();
                    if (objselect != null)
                    {
                        obj.NGUOIDAIDIEN = objselect.HODEM + " " + objselect.TEN;
                    }
                    // obj.NGUOIID = item.NGUOIID;
                    CNN_listFind.Add(obj);
                }
            }
            return CNN_listFind;
        }
        // danh sách hiển thị chủ hộ
        public static DC_HOGIADINH getdshienthi(DC_HOGIADINH objhogiadinh)
        {
            objhogiadinh.DSHienThi = new List<AppCore.Models.DSHienThiHoGiaDinh>();
            foreach (var objcon in objhogiadinh.DSThanhVien)
            {

                var objhienthi = new AppCore.Models.DSHienThiHoGiaDinh();
                objhienthi.CANHANID = objcon.ThanhVien.CANHANID;
                objhienthi.HOTEN = objcon.ThanhVien.HODEM + " " + objcon.ThanhVien.TEN;
                //objhienthi.QUANHE = objcon.QUANHEVOICHUHO;
                objhienthi.SOGIAYTO = objcon.ThanhVien.SOGIAYTO;
                objhogiadinh.DSHienThi.Add(objhienthi);
                // }
            }
            return objhogiadinh;
        }
        public static bool SaveChuDangky(VM_XuLyHoSo_DK GetObject)
        {
            try
            {
                using (MplisEntities dbo = new MplisEntities())
                {
                    foreach (var item in GetObject.CHU_DANGKY)
                    {
                        if (item.Chu.TRANGTHAI_NGUOI != null)
                        {
                            switch (item.Chu.TRANGTHAI_NGUOI)
                            {
                                //thêm mới
                                case 1:
                                    #region//trường hợp chủ là cá nhân
                                    if (item.LOAI == 1)
                                    {
                                        DC_CANHAN objcanhan = new DC_CANHAN();
                                        DC_DANGKY_NGUOI objdangkynguoi = new DC_DANGKY_NGUOI();
                                        DC_NGUOI objnguoi = new DC_NGUOI();
                                        objdangkynguoi.DANGKYNGUOIID = Guid.NewGuid().ToString();
                                        Mapper.Map<DC_CANHAN, DC_CANHAN>(item.Chu.CaNhan, objcanhan);
                                        objcanhan.HOTEN = objcanhan.HODEM + " " + objcanhan.TEN;
                                        //  Mapper.Map<DC_CANHAN, DC_DANGKY_NGUOI>(item.Chu.CaNhan, objdangkynguoi);
                                        objdangkynguoi.NGUOIID = item.NGUOIID;
                                        objdangkynguoi.LOAI = 1;
                                        objdangkynguoi.DONDANGKYID = GetObject.DONDANGKYID;
                                        objnguoi.NGUOIID = objdangkynguoi.NGUOIID;
                                        objnguoi.CHITIETID = objcanhan.CANHANID;
                                        objnguoi.LOAIDOITUONGID = "1";
                                        dbo.DC_CANHAN.Add(objcanhan);
                                        dbo.DC_DANGKY_NGUOI.Add(objdangkynguoi);
                                        dbo.DC_NGUOI.Add(objnguoi);
                                        foreach (var a in item.Chu.CaNhan.DSGiayToTuyThan)
                                        {
                                            DC_GIAYTOTUYTHAN objgt = new DC_GIAYTOTUYTHAN();
                                            objgt.GIAYTOTUYTHANID = Guid.NewGuid().ToString();
                                            objgt.LOAIGIAYTOTUYTHANID = a.LOAIGIAYTOTUYTHANID;
                                            objgt.NGAYCAP = a.NGAYCAP;
                                            objgt.NOICAP = a.NOICAP;
                                            objgt.SOGIAYTO = a.SOGIAYTO;
                                            objgt.CANHANID = objcanhan.CANHANID;
                                            objgt.LAGIAYTOINGCN = a.LAGIAYTOINGCN;
                                            dbo.DC_GIAYTOTUYTHAN.Add(objgt);
                                        }
                                        dbo.SaveChanges();
                                    }
                                    #endregion

                                    #region // chủ hộ gia đình
                                    else if (item.LOAI == 2)
                                    {
                                        var save = DONDANGKYServices.SaveHoGiaDinh(item, dbo);

                                    }
                                    #endregion
                                    #region  //vợ chồng
                                    else if (item.LOAI == 3)
                                    {
                                        var save = DONDANGKYServices.SaveVoChong(item, dbo);
                                    }
                                    #endregion
                                    #region   //tổ chức

                                    else if (item.LOAI == 4)
                                    {
                                        var save = DONDANGKYServices.SaveToChuc(item, dbo);
                                    }
                                    #endregion
                                    #region  //cộng đồng
                                    else if (item.LOAI == 5)
                                    {
                                        var save = DONDANGKYServices.SaveCongDong(item, dbo);
                                    }
                                    #endregion

                                    //chủ nhóm người
                                    else if (item.LOAI == 6)
                                    {
                                        DC_DANGKY_NGUOI objnguoi = new DC_DANGKY_NGUOI();
                                        objnguoi.NGUOIID = item.NGUOIID;
                                        objnguoi.DONDANGKYID = item.DONDANGKYID;
                                        objnguoi.DANGKYNGUOIID = Guid.NewGuid().ToString();
                                        objnguoi.LOAI = 6;
                                        dbo.DC_DANGKY_NGUOI.Add(objnguoi);
                                        dbo.SaveChanges();
                                    }
                                    break;
                                //sửa
                                case 2:
                                    #region  //trường hợp chủ là cá nhân
                                    if (item.LOAI == 1)
                                    {
                                        // sửa cá nhân
                                        string canhan = item.Chu.CaNhan.CANHANID;
                                        var objcanhan = (from a in dbo.DC_CANHAN where a.CANHANID == canhan select a).FirstOrDefault();
                                        if (objcanhan != null)
                                        {
                                            // dbo.DC_CANHAN.Remove(objcanhan);
                                            Mapper.Map<DC_CANHAN, DC_CANHAN>(item.Chu.CaNhan, objcanhan);
                                        }
                                        // sửa giấy tờ tùy thân người
                                        var lstgiayto = (from a in dbo.DC_GIAYTOTUYTHAN where a.CANHANID == canhan select a);
                                        foreach (var b in lstgiayto)
                                        {

                                            dbo.DC_GIAYTOTUYTHAN.Remove(b);

                                        }
                                        foreach (var c in item.Chu.CaNhan.DSGiayToTuyThan)
                                        {
                                            DC_GIAYTOTUYTHAN g = new DC_GIAYTOTUYTHAN();
                                            Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(c, g);
                                            g.GIAYTOTUYTHANID = Guid.NewGuid().ToString();
                                            g.CANHANID = canhan;
                                            dbo.DC_GIAYTOTUYTHAN.Add(g);
                                        }

                                    }
                                    #endregion
                                    #region // chủ hộ gia đình
                                    else if (item.LOAI == 2)
                                    {
                                        // DC_HOGIADINH objhogiadinh = new AppCore.Models.DC_HOGIADINH();
                                        // Cập nhật hộ gia đình 
                                        var objhogiadinh = (from h in dbo.DC_HOGIADINH where h.HOGIADINHID == item.Chu.HoGiaDinh.HOGIADINHID select h).FirstOrDefault();
                                        if (objhogiadinh != null)
                                        {
                                            // Mapper.Map<DC_HOGIADINH, DC_HOGIADINH>(item.Chu.HoGiaDinh, objhogiadinh);
                                            objhogiadinh.HOGIADINHID = item.Chu.HoGiaDinh.HOGIADINHID;
                                            objhogiadinh.CHUHO = item.Chu.HoGiaDinh.CHUHO;
                                            objhogiadinh.VOCHONG = item.Chu.HoGiaDinh.VOCHONG;
                                            objhogiadinh.CMTCHUHO = item.Chu.HoGiaDinh.CMTCHUHO;
                                            objhogiadinh.CMTVOCHONG = item.Chu.HoGiaDinh.CMTVOCHONG;

                                            dbo.Entry(objhogiadinh).State = EntityState.Modified;
                                            //db.SaveChanges();
                                        }
                                        //cập chủ hộ
                                        if (item.Chu.HoGiaDinh.CHUHO != null)
                                        {
                                            var objcanhanchuho = (from c in dbo.DC_CANHAN where c.CANHANID == item.Chu.HoGiaDinh.CHUHO select c).FirstOrDefault();
                                            if (objcanhanchuho != null)
                                            {
                                                Mapper.Map<DC_CANHAN, DC_CANHAN>(item.Chu.HoGiaDinh.ChuHoCN, objcanhanchuho);
                                                dbo.Entry(objcanhanchuho).State = EntityState.Modified;
                                                var lstgiayto = (from giayto in dbo.DC_GIAYTOTUYTHAN where giayto.CANHANID == objcanhanchuho.CANHANID select giayto);
                                                foreach (var obj in lstgiayto)
                                                {
                                                    dbo.DC_GIAYTOTUYTHAN.Remove(obj);
                                                }

                                            }
                                            if (item.Chu.HoGiaDinh.ChuHoCN.DSGiayToTuyThan != null)
                                            {
                                                foreach (var objgiayto in item.Chu.HoGiaDinh.ChuHoCN.DSGiayToTuyThan)
                                                {
                                                    if (objgiayto != null)
                                                    {
                                                        DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                                                        Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(objgiayto, obj);
                                                        dbo.DC_GIAYTOTUYTHAN.Add(obj);
                                                    }
                                                }
                                            }
                                        }
                                        //cập vợ chồng
                                        if (item.Chu.HoGiaDinh.VOCHONG != null)
                                        {
                                            var objcanhanchuho = (from c in dbo.DC_CANHAN where c.CANHANID == item.Chu.HoGiaDinh.VOCHONG select c).FirstOrDefault();
                                            if (objcanhanchuho != null)
                                            {
                                                Mapper.Map<DC_CANHAN, DC_CANHAN>(item.Chu.HoGiaDinh.VoChongCN, objcanhanchuho);
                                                dbo.Entry(objcanhanchuho).State = EntityState.Modified;
                                                var lstgiayto = (from giayto in dbo.DC_GIAYTOTUYTHAN where giayto.CANHANID == objcanhanchuho.CANHANID select giayto);
                                                foreach (var obj in lstgiayto)
                                                {
                                                    dbo.DC_GIAYTOTUYTHAN.Remove(obj);
                                                }

                                            }
                                            if (item.Chu.HoGiaDinh.VoChongCN.DSGiayToTuyThan != null)
                                            {
                                                foreach (var objgiayto in item.Chu.HoGiaDinh.VoChongCN.DSGiayToTuyThan)
                                                {
                                                    if (objgiayto != null)
                                                    {
                                                        DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                                                        Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(objgiayto, obj);
                                                        dbo.DC_GIAYTOTUYTHAN.Add(obj);
                                                    }
                                                }
                                            }
                                        }
                                        //cập thành viên
                                        foreach (var objthanhvien in item.Chu.HoGiaDinh.DSThanhVien)
                                        {
                                            if ((objthanhvien.ThanhVien.CANHANID != item.Chu.HoGiaDinh.CHUHO) && (objthanhvien.ThanhVien.CANHANID != item.Chu.HoGiaDinh.VOCHONG))
                                            {
                                                if (objthanhvien.ThanhVien.CANHANID != null)
                                                {
                                                    var objthanhvientontai = (from thanhvien in dbo.DC_HOGIADINH_THANHVIEN where thanhvien.HOGIADINHID == item.Chu.HoGiaDinh.HOGIADINHID && thanhvien.CANHANID == objthanhvien.ThanhVien.CANHANID select thanhvien).FirstOrDefault();

                                                    if (objthanhvientontai != null)
                                                    {
                                                        var objcanhanchuho = (from c in dbo.DC_CANHAN where c.CANHANID == objthanhvien.ThanhVien.CANHANID select c).FirstOrDefault();
                                                        if (objcanhanchuho != null)
                                                        {
                                                            Mapper.Map<DC_CANHAN, DC_CANHAN>(objthanhvien.ThanhVien, objcanhanchuho);
                                                            dbo.Entry(objcanhanchuho).State = EntityState.Modified;
                                                            var lstgiayto = (from giayto in dbo.DC_GIAYTOTUYTHAN where giayto.CANHANID == objthanhvien.ThanhVien.CANHANID select giayto);
                                                            foreach (var obj in lstgiayto)
                                                            {
                                                                dbo.DC_GIAYTOTUYTHAN.Remove(obj);
                                                            }
                                                            if (objthanhvien.ThanhVien.DSGiayToTuyThan != null)
                                                            {
                                                                foreach (var objgiayto in objthanhvien.ThanhVien.DSGiayToTuyThan)
                                                                {
                                                                    if (objgiayto != null)
                                                                    {
                                                                        DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                                                                        Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(objgiayto, obj);
                                                                        dbo.DC_GIAYTOTUYTHAN.Add(obj);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        DC_HOGIADINH_THANHVIEN obj = new DC_HOGIADINH_THANHVIEN();
                                                        obj.HOGIADINHID = item.Chu.HoGiaDinh.HOGIADINHID;
                                                        obj.CANHANID = objthanhvien.ThanhVien.CANHANID;
                                                        //obj.QUANHEVOICHUHO = "Con";
                                                        dbo.DC_HOGIADINH_THANHVIEN.Add(obj);
                                                    }


                                                }
                                            }
                                        }
                                        dbo.SaveChanges();
                                    }
                                    #endregion
                                    #region  //vợ chồng
                                    else if (item.LOAI == 3)
                                    {

                                        // Cập nhật vợ chồng
                                        var objvochong = (from h in dbo.DC_VOCHONG where h.VOCHONGID == item.Chu.VoChong.VOCHONGID select h).FirstOrDefault();
                                        if (objvochong != null)
                                        {
                                            // Mapper.Map<DC_VOCHONG, DC_VOCHONG>(item.Chu.VoChong, objvochong);
                                            objvochong.VOCHONGID = item.Chu.VoChong.VOCHONGID;
                                            objvochong.VO = item.Chu.VoChong.VoCN.CANHANID;
                                            objvochong.CHONG = item.Chu.VoChong.ChongCN.CANHANID;
                                            objvochong.CMTCHONG = item.Chu.VoChong.CMTCHONG;
                                            objvochong.CMTVO = item.Chu.VoChong.CMTVO;
                                            dbo.Entry(objvochong).State = EntityState.Modified;
                                            //db.SaveChanges();
                                        }
                                        //cập chủ hộ
                                        if (item.Chu.VoChong.CHONG != null)
                                        {
                                            var objcanhanchuho = (from c in dbo.DC_CANHAN where c.CANHANID == item.Chu.VoChong.CHONG select c).FirstOrDefault();
                                            if (objcanhanchuho != null)
                                            {
                                                Mapper.Map<DC_CANHAN, DC_CANHAN>(item.Chu.VoChong.ChongCN, objcanhanchuho);
                                                dbo.Entry(objcanhanchuho).State = EntityState.Modified;
                                                var lstgiayto = (from giayto in dbo.DC_GIAYTOTUYTHAN where giayto.CANHANID == objcanhanchuho.CANHANID select giayto);
                                                foreach (var obj in lstgiayto)
                                                {
                                                    dbo.DC_GIAYTOTUYTHAN.Remove(obj);
                                                }
                                                if (item.Chu.VoChong.ChongCN.DSGiayToTuyThan != null)
                                                {
                                                    foreach (var objgiayto in item.Chu.VoChong.ChongCN.DSGiayToTuyThan)
                                                    {
                                                        if (objgiayto != null)
                                                        {
                                                            DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                                                            Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(objgiayto, obj);
                                                            dbo.DC_GIAYTOTUYTHAN.Add(obj);
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                // thêm mới cá nhân
                                                DC_CANHAN objca = new DC_CANHAN();
                                                Mapper.Map<DC_CANHAN, DC_CANHAN>(item.Chu.VoChong.ChongCN, objca);
                                                dbo.DC_CANHAN.Add(objca);
                                            }

                                        }
                                        //cập vợ chồng
                                        if (item.Chu.VoChong.VO != null)
                                        {
                                            var objcanhanchuho = (from c in dbo.DC_CANHAN where c.CANHANID == item.Chu.VoChong.VO select c).FirstOrDefault();
                                            if (objcanhanchuho != null)
                                            {
                                                Mapper.Map<DC_CANHAN, DC_CANHAN>(item.Chu.VoChong.VoCN, objcanhanchuho);
                                                dbo.Entry(objcanhanchuho).State = EntityState.Modified;
                                                var lstgiayto = (from giayto in dbo.DC_GIAYTOTUYTHAN where giayto.CANHANID == objcanhanchuho.CANHANID select giayto);
                                                foreach (var obj in lstgiayto)
                                                {
                                                    dbo.DC_GIAYTOTUYTHAN.Remove(obj);
                                                }
                                                if (item.Chu.VoChong.VoCN.DSGiayToTuyThan != null)
                                                {
                                                    foreach (var objgiayto in item.Chu.VoChong.VoCN.DSGiayToTuyThan)
                                                    {
                                                        if (objgiayto != null)
                                                        {
                                                            DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                                                            Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(objgiayto, obj);
                                                            dbo.DC_GIAYTOTUYTHAN.Add(obj);
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                // thêm mới cá nhân
                                                DC_CANHAN objca = new DC_CANHAN();
                                                Mapper.Map<DC_CANHAN, DC_CANHAN>(item.Chu.VoChong.VoCN, objca);
                                                dbo.DC_CANHAN.Add(objca);

                                            }

                                        }
                                        dbo.SaveChanges();
                                    }
                                    #endregion
                                    #region  //tổ chức
                                    else if (item.LOAI == 4)
                                    {
                                        // Cập nhật vợ chồng
                                        var objtochuc = (from h in dbo.DC_TOCHUC where h.TOCHUCID == item.Chu.ToChuc.TOCHUCID select h).FirstOrDefault();
                                        if (objtochuc != null)
                                        {
                                            // Mapper.Map<DC_VOCHONG, DC_VOCHONG>(item.Chu.VoChong, objvochong);
                                            // objtochuc.TOCHUCID = item.Chu.ToChuc.TOCHUCID;
                                            objtochuc.NGUOIDAIDIENID = item.Chu.ToChuc.NguoiDaiDien.CANHANID;
                                            objtochuc.DIACHI = item.Chu.ToChuc.DIACHI;
                                            objtochuc.MADOANHNGHIEP = item.Chu.ToChuc.MADOANHNGHIEP;
                                            objtochuc.MASOTHUE = item.Chu.ToChuc.MASOTHUE;
                                            objtochuc.NGAYQUYETDINH = item.Chu.ToChuc.NGAYQUYETDINH;
                                            objtochuc.SOQUYETDINH = item.Chu.ToChuc.SOQUYETDINH;
                                            objtochuc.TENTOCHUC = item.Chu.ToChuc.TENTOCHUC;
                                            objtochuc.TENTOCHUCTA = item.Chu.ToChuc.TENTOCHUCTA;
                                            objtochuc.TENVIETTAT = item.Chu.ToChuc.TENVIETTAT;
                                            dbo.Entry(objtochuc).State = EntityState.Modified;
                                            //db.SaveChanges();
                                        }
                                        //cập người đại diện
                                        if (item.Chu.ToChuc.NGUOIDAIDIENID != null)
                                        {
                                            var objcanhanchuho = (from c in dbo.DC_CANHAN where c.CANHANID == item.Chu.ToChuc.NGUOIDAIDIENID select c).FirstOrDefault();
                                            if (objcanhanchuho != null)
                                            {
                                                Mapper.Map<DC_CANHAN, DC_CANHAN>(item.Chu.ToChuc.NguoiDaiDien, objcanhanchuho);
                                                dbo.Entry(objcanhanchuho).State = EntityState.Modified;
                                                var lstgiayto = (from giayto in dbo.DC_GIAYTOTUYTHAN where giayto.CANHANID == objcanhanchuho.CANHANID select giayto);
                                                foreach (var obj in lstgiayto)
                                                {
                                                    dbo.DC_GIAYTOTUYTHAN.Remove(obj);
                                                }
                                                foreach (var objgiayto in item.Chu.ToChuc.NguoiDaiDien.DSGiayToTuyThan)
                                                {
                                                    if (objgiayto != null)
                                                    {
                                                        DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                                                        Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(objgiayto, obj);
                                                        dbo.DC_GIAYTOTUYTHAN.Add(obj);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                // thêm mới cá nhân
                                                DC_CANHAN objca = new DC_CANHAN();
                                                Mapper.Map<DC_CANHAN, DC_CANHAN>(item.Chu.ToChuc.NguoiDaiDien, objca);
                                                dbo.DC_CANHAN.Add(objca);
                                            }

                                        }
                                        dbo.SaveChanges();
                                    }
                                    #endregion
                                    #region //cộng đồng
                                    else if (item.LOAI == 5)
                                    {
                                        // Cập nhật vợ chồng
                                        var objtochuc = (from h in dbo.DC_CONGDONG where h.CONGDONGID == item.Chu.CongDong.CONGDONGID select h).FirstOrDefault();
                                        if (objtochuc != null)
                                        {
                                            // Mapper.Map<DC_VOCHONG, DC_VOCHONG>(item.Chu.VoChong, objvochong);
                                            // objtochuc.TOCHUCID = item.Chu.ToChuc.TOCHUCID;
                                            objtochuc.NGUOIDAIDIENID = item.Chu.CongDong.NguoiDaiDien.CANHANID;
                                            objtochuc.DIACHI = item.Chu.CongDong.DIACHI;
                                            objtochuc.TENCONGDONG = item.Chu.CongDong.TENCONGDONG;

                                            dbo.Entry(objtochuc).State = EntityState.Modified;
                                            //db.SaveChanges();
                                        }
                                        //cập người đại diện
                                        if (item.Chu.CongDong.NGUOIDAIDIENID != null)
                                        {
                                            var objcanhanchuho = (from c in dbo.DC_CANHAN where c.CANHANID == item.Chu.CongDong.NGUOIDAIDIENID select c).FirstOrDefault();
                                            if (objcanhanchuho != null)
                                            {
                                                Mapper.Map<DC_CANHAN, DC_CANHAN>(item.Chu.CongDong.NguoiDaiDien, objcanhanchuho);
                                                dbo.Entry(objcanhanchuho).State = EntityState.Modified;
                                                var lstgiayto = (from giayto in dbo.DC_GIAYTOTUYTHAN where giayto.CANHANID == objcanhanchuho.CANHANID select giayto);
                                                foreach (var obj in lstgiayto)
                                                {
                                                    dbo.DC_GIAYTOTUYTHAN.Remove(obj);
                                                }
                                                foreach (var objgiayto in item.Chu.CongDong.NguoiDaiDien.DSGiayToTuyThan)
                                                {
                                                    if (objgiayto != null)
                                                    {
                                                        DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                                                        Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(objgiayto, obj);
                                                        dbo.DC_GIAYTOTUYTHAN.Add(obj);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                // thêm mới cá nhân
                                                DC_CANHAN objca = new DC_CANHAN();
                                                Mapper.Map<DC_CANHAN, DC_CANHAN>(item.Chu.CongDong.NguoiDaiDien, objca);
                                                dbo.DC_CANHAN.Add(objca);
                                            }

                                        }
                                        dbo.SaveChanges();
                                    }
                                    #endregion
                                    break;
                                //xóa
                                case 3:
                                    #region //trường hợp chủ là cá nhân
                                    if (item.LOAI == 1)
                                    {
                                        string canhan = item.Chu.CaNhan.CANHANID;
                                        // xóa đơn đăng ký người
                                        var lstdkchu = (from a in dbo.DC_DANGKY_NGUOI where a.NGUOIID == item.NGUOIID && a.DONDANGKYID == item.DONDANGKYID select a);
                                        foreach (var b in lstdkchu)
                                        {
                                            dbo.DC_DANGKY_NGUOI.Remove(b);
                                        }
                                        //// xóa giấy tờ tùy thân người
                                        //var lstgiayto = (from k in dbo.DC_GIAYTOTUYTHAN where k.CANHANID == canhan select k);
                                        //foreach (var b in lstgiayto)
                                        //{
                                        //    dbo.DC_GIAYTOTUYTHAN.Remove(b);
                                        //}
                                        //// xóa cá nhân

                                        //var objcanhan = (from h in dbo.DC_CANHAN where h.CANHANID == canhan select h).FirstOrDefault();
                                        //if (objcanhan != null)
                                        //{
                                        //    dbo.DC_CANHAN.Remove(objcanhan);
                                        //}
                                        //// xóa  người
                                        //var objnguoi = (from m in dbo.DC_NGUOI where m.NGUOIID == item.NGUOIID select m).FirstOrDefault();
                                        //if (objnguoi != null)
                                        //{
                                        //    dbo.DC_NGUOI.Remove(objnguoi);
                                        //}
                                        dbo.SaveChanges();
                                    }
                                    #endregion
                                    #region  // chủ hộ gia đình
                                    else if (item.LOAI == 2)
                                    {
                                        // xóa đăng ký hộ gia đình
                                        var objdangkynguoi = (from a in dbo.DC_DANGKY_NGUOI where a.DONDANGKYID == item.DONDANGKYID && a.NGUOIID == item.NGUOIID select a).FirstOrDefault();
                                        if (objdangkynguoi != null)
                                        {
                                            dbo.DC_DANGKY_NGUOI.Remove(objdangkynguoi);
                                        }
                                        dbo.SaveChanges();
                                        // break;
                                    }
                                    #endregion
                                    #region //vợ chồng
                                    else if (item.LOAI == 3)
                                    {
                                        // xóa đăng ký hộ gia đình
                                        var objdangkynguoi = (from a in dbo.DC_DANGKY_NGUOI where a.DONDANGKYID == item.DONDANGKYID && a.NGUOIID == item.NGUOIID select a).FirstOrDefault();
                                        if (objdangkynguoi != null)
                                        {
                                            dbo.DC_DANGKY_NGUOI.Remove(objdangkynguoi);
                                        }
                                        dbo.SaveChanges();
                                        // break;
                                    }
                                    #endregion
                                    #region //tổ chức
                                    else if (item.LOAI == 4)
                                    {
                                        // xóa đăng ký hộ gia đình
                                        var objdangkynguoi = (from a in dbo.DC_DANGKY_NGUOI where a.DONDANGKYID == item.DONDANGKYID && a.NGUOIID == item.NGUOIID select a).FirstOrDefault();
                                        if (objdangkynguoi != null)
                                        {
                                            dbo.DC_DANGKY_NGUOI.Remove(objdangkynguoi);
                                        }
                                        dbo.SaveChanges();
                                    }
                                    #endregion
                                    #region  //cộng đồng
                                    else if (item.LOAI == 5)
                                    {
                                        // xóa đăng ký hộ gia đình
                                        var objdangkynguoi = (from a in dbo.DC_DANGKY_NGUOI where a.DONDANGKYID == item.DONDANGKYID && a.NGUOIID == item.NGUOIID select a).FirstOrDefault();
                                        if (objdangkynguoi != null)
                                        {
                                            dbo.DC_DANGKY_NGUOI.Remove(objdangkynguoi);
                                        }
                                        dbo.SaveChanges();
                                    }
                                    //chủ nhóm người
                                    else if (item.LOAI == 6)
                                    {
                                        // xóa đăng ký hộ gia đình
                                        var objdangkynguoi = (from a in dbo.DC_DANGKY_NGUOI where a.DONDANGKYID == item.DONDANGKYID && a.NGUOIID == item.NGUOIID select a).FirstOrDefault();
                                        if (objdangkynguoi != null)
                                        {
                                            dbo.DC_DANGKY_NGUOI.Remove(objdangkynguoi);
                                        }
                                        dbo.SaveChanges();
                                    }
                                    #endregion
                                    break;
                                default:
                                    break;
                            }

                        }

                    }
                    dbo.SaveChanges();
                    var ketqua = new DC_DANGKY_NGUOI();
                    foreach (var item in GetObject.CHU_DANGKY)
                    {
                        if (item.Chu.TRANGTHAI_NGUOI == 1 || item.Chu.TRANGTHAI_NGUOI == 2)
                        {
                            item.Chu.TRANGTHAI_NGUOI = 0;
                        }
                        else if (item.Chu.TRANGTHAI_NGUOI == 3)
                        {
                            ketqua = item;
                        }
                    }
                    GetObject.CHU_DANGKY.Remove(ketqua);

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public static DC_NGUOI GetNguoi(string hogiadinhid)
        {
            DC_NGUOI ret = new DC_NGUOI();
            using (MplisEntities dbo = new MplisEntities())
            {
                var objThanhVien = (from t1 in dbo.DC_HOGIADINH.Where(t => t.HOGIADINHID == hogiadinhid).DefaultIfEmpty()
                                    select new
                                    {
                                        t1,
                                        x = dbo.DC_HOGIADINH_THANHVIEN.Where(t => t.HOGIADINHID == t1.HOGIADINHID)
                                        .Select(t2 => new
                                        {
                                            t2,
                                            cns = dbo.DC_CANHAN.Where(t => t.CANHANID.Equals(t2.CANHANID)).
                                           Select(t3 => new
                                           {
                                               t3,
                                               gttt = dbo.DC_GIAYTOTUYTHAN.Where(t => t.CANHANID.Equals(t3.CANHANID))
                                           }).FirstOrDefault()
                                        })
                                    }).FirstOrDefault();

                if (objThanhVien != null)
                {
                    ret.HoGiaDinh = objThanhVien.t1;
                    List<DC_HOGIADINH_THANHVIEN> ls = new List<DC_HOGIADINH_THANHVIEN>();
                    DC_HOGIADINH_THANHVIEN item;
                    //DC_CANHAN cn;
                    //Hashtable tv = new Hashtable();
                    //Hashtable hgdtv = new Hashtable();
                    foreach (var it in objThanhVien.x)
                    {
                        item = it.t2;
                        if (it.cns != null)
                        {
                            item.ThanhVien = it.cns.t3;
                            item.ThanhVien.DSGiayToTuyThan = it.cns.gttt.ToList();
                        }
                        ls.Add(item);

                    }
                    if (ret.HoGiaDinh == null)
                    {
                        ret.HoGiaDinh = new DC_HOGIADINH();
                        ret.HoGiaDinh.DSThanhVien = new List<DC_HOGIADINH_THANHVIEN>();

                    }
                    else
                    {
                        ret.HoGiaDinh.DSThanhVien = ls;
                    }
                }
                //  if (ret.HoGiaDinh != null && (ret.HoGiaDinh.DSThanhVien == null || ret.HoGiaDinh.DSThanhVien.Count == 0))
                if (ret.HoGiaDinh != null)
                {
                    string[] idVC = new string[] { ret.HoGiaDinh.VOCHONG, ret.HoGiaDinh.CHUHO };

                    var objVCChuHo = (from t2 in dbo.DC_CANHAN.Where(t => idVC.Contains(t.CANHANID)).DefaultIfEmpty()
                                      select new
                                      {
                                          t2,
                                          gttt2 = dbo.DC_GIAYTOTUYTHAN.Where(i => i.CANHANID.Equals(t2.CANHANID)).DefaultIfEmpty()
                                      }).ToList();

                    if (objVCChuHo != null && objVCChuHo.Count > 0)
                    {
                        foreach (var cn in objVCChuHo)
                        {
                            if (cn.t2 != null)
                                if (cn.t2.CANHANID.Equals(ret.HoGiaDinh.VOCHONG))
                                {
                                    ret.HoGiaDinh.VoChongCN = cn.t2;
                                    ret.HoGiaDinh.VoChongCN.DSGiayToTuyThan = cn.gttt2.ToList();
                                }
                                else
                                {
                                    ret.HoGiaDinh.ChuHoCN = cn.t2;
                                    ret.HoGiaDinh.ChuHoCN.DSGiayToTuyThan = cn.gttt2.ToList();
                                }
                        }
                    }
                }
            }

            return ret;
        }

        public static List<DC_NGUOI_SearchVoChong> searchVoChong(string socmt)
        {
            var CNN_listFind = new List<DC_NGUOI_SearchVoChong>();
            using (MplisEntities dbo = new MplisEntities())
            {


                //var predicate = PrecateBuilder.True<DC_VOCHONG>();
                //predicate = predicate.And(x => x.CMTCHONG.Trim().ToUpper().Equals(socmt.Trim().ToUpper()));
                var querynguoi = (from canhan in dbo.DC_VOCHONG.Where(x => x.CMTCHONG.Trim().ToUpper().Equals(socmt.Trim().ToUpper()))
                                  select new
                                  {
                                      VOCHONGID = canhan.VOCHONGID,
                                      CHONG = canhan.CHONG,
                                      VO = canhan.VO,
                                  }
                                  );


                foreach (var item in querynguoi)
                {

                    DC_NGUOI_SearchVoChong obj = new DC_NGUOI_SearchVoChong();
                    obj.VOCHONGID = item.VOCHONGID;

                    var objchuho = (from abc in dbo.DC_CANHAN.Where(x => x.CANHANID == item.CHONG) select abc).FirstOrDefault();
                    if (objchuho != null)
                    {
                        obj.HOTEN_CHUHO = objchuho.HODEM + " " + objchuho.TEN;
                        obj.CMTCHUHO = objchuho.SOGIAYTO;

                    }
                    var objVoChong = (from abc in dbo.DC_CANHAN.Where(x => x.CANHANID == item.VO) select abc).FirstOrDefault();
                    if (objVoChong != null)
                    {
                        obj.HOTEN_VOCHONG = objVoChong.HODEM + " " + objVoChong.TEN;
                        obj.CMTVOCHONG = objchuho.SOGIAYTO;
                    }
                    // obj.NGUOIID = item.NGUOIID;
                    CNN_listFind.Add(obj);
                }
                // CNN_listFind = querynguoi;
            }
            return CNN_listFind;
        }

        //get người vợ chồng
        public static DC_NGUOI Getvochong(string vochongid)
        {
            DC_NGUOI ret = new DC_NGUOI();
            using (MplisEntities dbo = new MplisEntities())
            {
                var objchu3 = (from item in dbo.DC_VOCHONG where item.VOCHONGID == vochongid select item).FirstOrDefault();
                if (objchu3 != null)
                {
                    ret.VoChong = objchu3;
                    List<string> vcs = new List<string> { ret.VoChong.VO, ret.VoChong.CHONG };
                    var objvc = (from cn in dbo.DC_CANHAN.Where(s => vcs.Contains(s.CANHANID))
                                 select new
                                 {
                                     cn,
                                     gttt = dbo.DC_GIAYTOTUYTHAN.Where(i => i.CANHANID.Equals(cn.CANHANID)).DefaultIfEmpty()
                                 }).ToList();
                    if (objvc != null)
                    {
                        foreach (var vc in objvc)
                        {
                            if (vc.cn.CANHANID.Equals(ret.VoChong.VO))
                            {
                                ret.VoChong.VoCN = vc.cn;
                                ret.VoChong.VoCN.DSGiayToTuyThan = vc.gttt.ToList();
                            }
                            if (vc.cn.CANHANID.Equals(ret.VoChong.CHONG))
                            {
                                ret.VoChong.ChongCN = vc.cn;
                                ret.VoChong.ChongCN.DSGiayToTuyThan = vc.gttt.ToList();
                            }
                        }
                    }
                }
            }

            return ret;
        }

        //get người vợ chồng
        public static DC_NGUOI GetToChuc(string tochucid)
        {
            DC_NGUOI ret = new DC_NGUOI();
            using (MplisEntities dbo = new MplisEntities())
            {
                var objchu5 = (from item in dbo.DC_TOCHUC where item.TOCHUCID == tochucid select item).FirstOrDefault();
                if (objchu5 != null)
                {
                    ret.ToChuc = objchu5;
                    var objcn1 = (from cn in dbo.DC_CANHAN
                                  where cn.CANHANID == ret.ToChuc.NGUOIDAIDIENID
                                  select new
                                  {
                                      cn,
                                      gttt = dbo.DC_GIAYTOTUYTHAN.Where(i => i.CANHANID.Equals(cn.CANHANID)).DefaultIfEmpty()
                                  }).FirstOrDefault();
                    if (objcn1 != null)
                    {
                        ret.ToChuc.NguoiDaiDien = objcn1.cn;
                        ret.ToChuc.NguoiDaiDien.DSGiayToTuyThan = objcn1.gttt.ToList();
                    }
                }
            }

            return ret;
        }

        //get người cộng đồng
        public static DC_NGUOI GetCongDong(string tochucid)
        {
            DC_NGUOI ret = new DC_NGUOI();
            using (MplisEntities dbo = new MplisEntities())
            {
                var objchu4 = (from item in dbo.DC_CONGDONG where item.CONGDONGID == tochucid select item).FirstOrDefault();
                if (objchu4 != null)
                {
                    ret.CongDong = objchu4;
                    var objcn = (from cn in dbo.DC_CANHAN
                                 where cn.CANHANID == ret.CongDong.NGUOIDAIDIENID
                                 select new
                                 {
                                     cn,
                                     gttt = dbo.DC_GIAYTOTUYTHAN.Where(i => i.CANHANID.Equals(cn.CANHANID)).DefaultIfEmpty()
                                 }
                                 ).FirstOrDefault();
                    if (objcn != null)
                    {
                        ret.CongDong.NguoiDaiDien = objcn.cn;
                        ret.CongDong.NguoiDaiDien.DSGiayToTuyThan = objcn.gttt.ToList();
                    }

                }
            }

            return ret;
        }

        // xóa chủ khỏi nhóm
        public static bool Xoachukhoinhom(string idcanhan, string nhomnguoi)
        {
            try
            {
                using (MplisEntities dbo = new MplisEntities())
                {

                    //var objthanhvien = (from item in dbo.DC_NHOMNGUOI_THANHVIEN where item.NHOMNGUOIID == nhomnguoi && item.THANHPHANID == idcanhan select item).FirstOrDefault();
                    //if (objthanhvien != null)
                    //{
                    //    dbo.DC_NHOMNGUOI_THANHVIEN.Remove(objthanhvien);
                    //}
                    dbo.SaveChanges();

                }

                return true;
            }
            catch (Exception ex)
            {
                return false;

                throw;
            }
        }

        public static DC_CANHAN GetCaNhanNhom(string canhanid)
        {
            DC_CANHAN obj = new DC_CANHAN();
            using (MplisEntities dbo = new MplisEntities())
            {
                var objchu1 = (from cn in dbo.DC_CANHAN.Where(i => i.CANHANID.Equals(canhanid))
                               select new
                               {
                                   cn,
                                   gttt = dbo.DC_GIAYTOTUYTHAN.Where(i => i.CANHANID.Equals(cn.CANHANID))
                               }).FirstOrDefault();
                if (objchu1 != null)
                {
                    obj = objchu1.cn;
                    obj.DSGiayToTuyThan = objchu1.gttt.ToList();
                }
            }
            return obj;
        }

        public static DC_HOGIADINH GetHoGiaDinhNhom(string hogiadinhid)
        {
            DC_HOGIADINH obj = new DC_HOGIADINH();
            using (MplisEntities dbo = new MplisEntities())
            {
                var objThanhVien = (from t1 in dbo.DC_HOGIADINH.Where(t => t.HOGIADINHID == hogiadinhid).DefaultIfEmpty()
                                    select new
                                    {
                                        t1,
                                        x = dbo.DC_HOGIADINH_THANHVIEN.Where(t => t.HOGIADINHID == t1.HOGIADINHID)
                                        .Select(t2 => new
                                        {
                                            t2,
                                            cns = dbo.DC_CANHAN.Where(t => t.CANHANID.Equals(t2.CANHANID)).
                                           Select(t3 => new
                                           {
                                               t3,
                                               gttt = dbo.DC_GIAYTOTUYTHAN.Where(t => t.CANHANID.Equals(t3.CANHANID))
                                           }).FirstOrDefault()
                                        })
                                    }).FirstOrDefault();

                if (objThanhVien != null)
                {
                    obj = objThanhVien.t1;
                    List<DC_HOGIADINH_THANHVIEN> ls = new List<DC_HOGIADINH_THANHVIEN>();
                    DC_HOGIADINH_THANHVIEN item;
                    //DC_CANHAN cn;
                    //Hashtable tv = new Hashtable();
                    //Hashtable hgdtv = new Hashtable();
                    foreach (var it in objThanhVien.x)
                    {
                        item = it.t2;
                        if (it.cns != null)
                        {
                            item.ThanhVien = it.cns.t3;
                            item.ThanhVien.DSGiayToTuyThan = it.cns.gttt.ToList();
                        }
                        ls.Add(item);
                        //ls.Add(it.t2);
                        //if (it.t3 != null && !tv.Contains(it.t3.CANHANID))
                        //{
                        //    it.t2.ThanhVien = it.t3;
                        //    it.t2.ThanhVien.DSGiayToTuyThan = it.gttt.ToList();
                        //    ls.Add(it.t2);
                        //    tv.Add(it.t3.CANHANID, it.t3.CANHANID);
                        //}
                    }
                    if (obj == null)
                    {
                        obj = new DC_HOGIADINH();
                        obj.DSThanhVien = new List<DC_HOGIADINH_THANHVIEN>();

                    }
                    else
                    {
                        obj.DSThanhVien = ls;
                    }
                }
                //  if (obj != null && (obj.DSThanhVien == null || obj.DSThanhVien.Count == 0))
                if (obj != null)
                {
                    string[] idVC = new string[] { obj.VOCHONG, obj.CHUHO };

                    var objVCChuHo = (from t2 in dbo.DC_CANHAN.Where(t => idVC.Contains(t.CANHANID)).DefaultIfEmpty()
                                      select new
                                      {
                                          t2,
                                          gttt2 = dbo.DC_GIAYTOTUYTHAN.Where(i => i.CANHANID.Equals(t2.CANHANID)).DefaultIfEmpty()
                                      }).ToList();

                    if (objVCChuHo != null && objVCChuHo.Count > 0)
                    {
                        foreach (var cn in objVCChuHo)
                        {
                            if (cn.t2 != null)
                                if (cn.t2.CANHANID.Equals(obj.VOCHONG))
                                {
                                    obj.VoChongCN = cn.t2;
                                    obj.VoChongCN.DSGiayToTuyThan = cn.gttt2.ToList();
                                }
                                else
                                {
                                    obj.ChuHoCN = cn.t2;
                                    obj.ChuHoCN.DSGiayToTuyThan = cn.gttt2.ToList();
                                }
                        }
                    }
                }
            }
            return obj;
        }

        public static DC_VOCHONG GetVoChongNhom(string vochongid)
        {
            DC_VOCHONG obj = new DC_VOCHONG();
            using (MplisEntities dbo = new MplisEntities())
            {
                var objchu3 = (from item in dbo.DC_VOCHONG where item.VOCHONGID == vochongid select item).FirstOrDefault();
                if (objchu3 != null)
                {
                    obj = objchu3;
                    List<string> vcs = new List<string> { obj.VO, obj.CHONG };
                    var objvc = (from cn in dbo.DC_CANHAN.Where(s => vcs.Contains(s.CANHANID))
                                 select new
                                 {
                                     cn,
                                     gttt = dbo.DC_GIAYTOTUYTHAN.Where(i => i.CANHANID.Equals(cn.CANHANID)).DefaultIfEmpty()
                                 }).ToList();
                    if (objvc != null)
                    {
                        foreach (var vc in objvc)
                        {
                            if (vc.cn.CANHANID.Equals(obj.VO))
                            {
                                obj.VoCN = vc.cn;
                                obj.VoCN.DSGiayToTuyThan = vc.gttt.ToList();
                            }
                            if (vc.cn.CANHANID.Equals(obj.CHONG))
                            {
                                obj.ChongCN = vc.cn;
                                obj.ChongCN.DSGiayToTuyThan = vc.gttt.ToList();
                            }
                        }
                    }
                }
            }
            return obj;
        }

        public static DC_TOCHUC GetToChucNhom(string tochucid)
        {
            DC_TOCHUC obj = new DC_TOCHUC();
            using (MplisEntities dbo = new MplisEntities())
            {
                var objchu5 = (from item in dbo.DC_TOCHUC where item.TOCHUCID == tochucid select item).FirstOrDefault();
                if (objchu5 != null)
                {
                    obj = objchu5;
                    var objcn1 = (from cn in dbo.DC_CANHAN
                                  where cn.CANHANID == obj.NGUOIDAIDIENID
                                  select new
                                  {
                                      cn,
                                      gttt = dbo.DC_GIAYTOTUYTHAN.Where(i => i.CANHANID.Equals(cn.CANHANID)).DefaultIfEmpty()
                                  }).FirstOrDefault();
                    if (objcn1 != null)
                    {
                        obj.NguoiDaiDien = objcn1.cn;
                        obj.NguoiDaiDien.DSGiayToTuyThan = objcn1.gttt.ToList();
                    }
                }
            }
            return obj;
        }


        public static DC_CONGDONG GetCongDongNhom(string congdongid)
        {
            DC_CONGDONG obj = new DC_CONGDONG();
            using (MplisEntities dbo = new MplisEntities())
            {
                var objchu4 = (from item in dbo.DC_CONGDONG where item.CONGDONGID == congdongid select item).FirstOrDefault();
                if (objchu4 != null)
                {
                    obj = objchu4;
                    var objcn = (from cn in dbo.DC_CANHAN
                                 where cn.CANHANID == obj.NGUOIDAIDIENID
                                 select new
                                 {
                                     cn,
                                     gttt = dbo.DC_GIAYTOTUYTHAN.Where(i => i.CANHANID.Equals(cn.CANHANID)).DefaultIfEmpty()
                                 }
                                 ).FirstOrDefault();
                    if (objcn != null)
                    {
                        obj.NguoiDaiDien = objcn.cn;
                        obj.NguoiDaiDien.DSGiayToTuyThan = objcn.gttt.ToList();
                    }

                }
            }
            return obj;
        }
        #endregion

        #region get all combox
        public static List<loaithuadat> getloaithuadat()
        {
            List<loaithuadat> lstXP = new List<loaithuadat>();
            loaithuadat objXPEmty = new loaithuadat();
            objXPEmty.idloaithuadat = "";
            objXPEmty.tenloaithuadat = "--Chọn loại thửa--";
            lstXP.Add(objXPEmty);
            loaithuadat objXPEmty1 = new loaithuadat();
            objXPEmty1.idloaithuadat = "Y";
            objXPEmty1.tenloaithuadat = "Thửa pháp lý";
            lstXP.Add(objXPEmty1);
            loaithuadat objXPEmty2 = new loaithuadat();
            objXPEmty2.idloaithuadat = "N";
            objXPEmty2.tenloaithuadat = "Là thửa xử lý ";
            lstXP.Add(objXPEmty2);
            loaithuadat objXPEmty3 = new loaithuadat();
            objXPEmty3.idloaithuadat = "S";
            objXPEmty3.tenloaithuadat = "Là thửa chờ phê duyệt";
            lstXP.Add(objXPEmty3);
            return lstXP;
        }
        public static List<DM_MUCDICHSUDUNG> getdm_MDSD()
        {
            List<DM_MUCDICHSUDUNG> lstdm_mdsd = new List<DM_MUCDICHSUDUNG>();
            using (MplisEntities db = new MplisEntities())
            {
                lstdm_mdsd = (from item in db.DM_MUCDICHSUDUNG
                              select item).OrderBy(a => a.TENMUCDICHSUDUNG).ToList();
            }
            return lstdm_mdsd;
        }
        public static List<DM_MUCDICHSUDUNGQH> getdm_LOAIQUYHOACH()
        {
            List<DM_MUCDICHSUDUNGQH> lstdm_mdsd = new List<DM_MUCDICHSUDUNGQH>();
            using (MplisEntities db = new MplisEntities())
            {
                lstdm_mdsd = (from item in db.DM_MUCDICHSUDUNGQH
                              select item).OrderBy(a => a.TENMUCDICHSUDUNGQH).ToList();
            }
            return lstdm_mdsd;
        }
        public static List<DM_LOAINGUONGOCSUDUNG> getdm_LOAINGUONGOC()
        {
            List<DM_LOAINGUONGOCSUDUNG> lstdm_mdsd = new List<DM_LOAINGUONGOCSUDUNG>();
            using (MplisEntities db = new MplisEntities())
            {
                lstdm_mdsd = (from item in db.DM_LOAINGUONGOCSUDUNG
                              select item).OrderBy(a => a.TENNGUONGOCSUDUNG).ToList();
            }
            return lstdm_mdsd;
        }
        public static List<GD_DMLOAIGIADAT> getdm_loaigiadat()
        {
            List<GD_DMLOAIGIADAT> lstdm_mdsd = new List<GD_DMLOAIGIADAT>();
            using (MplisEntities db = new MplisEntities())
            {
                lstdm_mdsd = (from item in db.GD_DMLOAIGIADAT
                              select item).OrderBy(a => a.LOAIGIADAT).ToList();
            }
            return lstdm_mdsd;
        }
        public static List<DM_DANTOC> GetDM_DANTOC()
        {
            List<DM_DANTOC> dSDanToc = new List<DM_DANTOC>();
            using (MplisEntities db = new MplisEntities())
            {
                dSDanToc = db.DM_DANTOC.OrderBy(it => it.TENDANTOC).ToList();
            }
            return dSDanToc;
        }
        public static List<DM_DANTOC> getdm_dantoc()
        {
            List<DM_DANTOC> lstdantoc = new List<DM_DANTOC>();
            using (MplisEntities db = new MplisEntities())
            {
                lstdantoc = (from item in db.DM_DANTOC
                             select item).OrderBy(a => a.TENDANTOC).ToList();
            }
            return lstdantoc;
        }
        public static List<DM_LOAIGIAYTOTUYTHAN> getdm_loaigiaytotuythan()
        {
            List<DM_LOAIGIAYTOTUYTHAN> lstdantoc = new List<DM_LOAIGIAYTOTUYTHAN>();
            using (MplisEntities db = new MplisEntities())
            {
                lstdantoc = (from item in db.DM_LOAIGIAYTOTUYTHAN
                             select item).OrderBy(a => a.TENLOAIGIAYTOTUYTHAN).ToList();
            }
            return lstdantoc;
        }
        public static List<DM_LOAIGIAYTOTUYTHAN> GetDM_LOAIGIAYTOTUYTHAN()
        {
            List<DM_LOAIGIAYTOTUYTHAN> dSLoaiGiayToTuyThan = new List<DM_LOAIGIAYTOTUYTHAN>();
            using (MplisEntities db = new MplisEntities())
            {
                dSLoaiGiayToTuyThan = db.DM_LOAIGIAYTOTUYTHAN.OrderBy(it => it.TENLOAIGIAYTOTUYTHAN).ToList();
            }
            return dSLoaiGiayToTuyThan;
        }
        public static Hashtable getdm_denghi()
        {
            Hashtable lstdenghi = new Hashtable();
            lstdenghi.Add(8, "Đề nghị Đăng ký quyền sử dụng đất");
            lstdenghi.Add(7, "Đề nghị Đăng ký quyền quản lý đất");
            lstdenghi.Add(6, "Đề nghị cấp giấy chứng nhận đối với đất");
            lstdenghi.Add(5, "Đề nghị cấp giấy chứng nhận đối với tài sản trên đất");
            lstdenghi.Add(4, "Đề nghị Đăng ký và cấp giấy chứng nhận đối với đất");
            lstdenghi.Add(3, "Đề nghị Đăng ký và cấp giấy chứng nhận đối với tài sản trên đất");
            lstdenghi.Add(2, "Đề nghị Đăng ký và cấp giấy chứng nhận đối với đất và tài sản trên đất");
            lstdenghi.Add(1, "Đề nghị khác");
            return lstdenghi;
        }
        public static List<objgioitinh> getdm_gioitinh()
        {
            List<objgioitinh> lst = new List<Classes.objgioitinh>();
            objgioitinh obj1 = new objgioitinh();
            obj1.GIOITINH = 1M;
            obj1.TENGIOITINH = "Nam";
            lst.Add(obj1);
            objgioitinh obj2 = new objgioitinh();
            obj2.GIOITINH = 0M;
            obj2.TENGIOITINH = "Nữ";
            lst.Add(obj2);
            objgioitinh obj3 = new objgioitinh();
            obj3.GIOITINH = 2M;
            obj3.TENGIOITINH = "Giới tính thứ 3";
            lst.Add(obj3);
            return lst;
        }
        public static List<DM_GIOITINH> GetDM_GIOITINH()
        {
            List<DM_GIOITINH> dSGioiTinh = new List<DM_GIOITINH>();
            DM_GIOITINH gioiTinhNam = new DM_GIOITINH(1, "Nam");
            DM_GIOITINH gioiTinhNu = new DM_GIOITINH(0, "Nữ");
            DM_GIOITINH gioiTinhThuBa = new DM_GIOITINH(2, "Giới tính thứ 3");
            dSGioiTinh.Add(gioiTinhNam);
            dSGioiTinh.Add(gioiTinhNu);
            dSGioiTinh.Add(gioiTinhThuBa);
            return dSGioiTinh;
        }
        public static List<DM_LOAICHU> GetDM_LOAICHU()
        {
            List<DM_LOAICHU> dSLoaiChu = new List<DM_LOAICHU>();
            dSLoaiChu.Add(new DM_LOAICHU(1, "Cá nhân"));
            dSLoaiChu.Add(new DM_LOAICHU(2, "Hộ gia đình"));
            dSLoaiChu.Add(new DM_LOAICHU(3, "Vợ chồng"));
            dSLoaiChu.Add(new DM_LOAICHU(4, "Tổ chức"));
            dSLoaiChu.Add(new DM_LOAICHU(5, "Cộng đồng"));
            dSLoaiChu.Add(new DM_LOAICHU(6, "Nhóm người"));
            return dSLoaiChu;

        }
        public static List<DM_LOAICHU> GetDM_LOAICHUNHOMNGUOI()
        {
            List<DM_LOAICHU> dSLoaiChu = new List<DM_LOAICHU>();
            dSLoaiChu.Add(new DM_LOAICHU(1, "Cá nhân"));
            dSLoaiChu.Add(new DM_LOAICHU(2, "Hộ gia đình"));
            dSLoaiChu.Add(new DM_LOAICHU(3, "Vợ chồng"));
            dSLoaiChu.Add(new DM_LOAICHU(4, "Tổ chức"));
            dSLoaiChu.Add(new DM_LOAICHU(5, "Cộng đồng"));
            return dSLoaiChu;

        }
        public static Hashtable getdm_lachu()
        {
            Hashtable lstdenghi = new Hashtable();

            lstdenghi.Add(6, "Chủ sử dụng/sở hữu");
            lstdenghi.Add(5, "Đồng sử dụng/sở hữu");
            lstdenghi.Add(4, "Bên chuyển quyền");
            lstdenghi.Add(3, "Bên nhận chuyển quyền");
            lstdenghi.Add(2, "Bên thế chấp");
            lstdenghi.Add(1, "Bên nhận thế chấp");
            return lstdenghi;
        }
        public static List<DM_QUOCTICH> GetDM_QUOCTICH()
        {
            List<DM_QUOCTICH> dSQuocTich = new List<DM_QUOCTICH>();
            using (MplisEntities db = new MplisEntities())
            {
                dSQuocTich = db.DM_QUOCTICH.OrderBy(it => it.TENQUOCGIATV).ToList();
            }
            return dSQuocTich;
        }
        public static List<DM_DOITUONGSUDUNG> GetDM_DOITUONGSUDUNG(int loaiChu)
        {
            List<DM_DOITUONGSUDUNG> dSDoiTuongSuDung = new List<DM_DOITUONGSUDUNG>();
            using (MplisEntities db = new MplisEntities())
            {
                dSDoiTuongSuDung = db.DM_DOITUONGSUDUNG.Where(it => it.LOAICHU == loaiChu).ToList();
            }
            return dSDoiTuongSuDung;
        }

        public static List<DM_DOITUONGSUDUNG> GetDM_DOITUONGSUDUNG(decimal loaiChu)
        {
            List<DM_DOITUONGSUDUNG> dSDoiTuongSuDung = new List<DM_DOITUONGSUDUNG>();
            using (MplisEntities db = new MplisEntities())
            {
                if(loaiChu == 2 || loaiChu == 3)
                {
                    dSDoiTuongSuDung = db.DM_DOITUONGSUDUNG.Where(it => it.LOAICHU == 2).ToList();
                } else
                {
                    dSDoiTuongSuDung = db.DM_DOITUONGSUDUNG.Where(it => it.LOAICHU == loaiChu).ToList();
                }
            }
            return dSDoiTuongSuDung;
        }

        public static string GetTenQuanHeVoiCH(string qHVoiChuHoID)
        {
            string tenQuanHe = "";
            using(MplisEntities db = new MplisEntities())
            {
                var ret = db.DM_QHVOICHUHO.Where(it => it.QHVOICHUHOID == qHVoiChuHoID)
                    .Select(it => it.TENQUANHE)
                    .FirstOrDefault();
                if(ret != null)
                {
                    tenQuanHe = ret;
                }
            }
            return tenQuanHe;
        }
        public static List<DM_QHVOICHUHO> GetDM_QHVOICHUHO()
        {
            List<DM_QHVOICHUHO> dSQuanHe = new List<DM_QHVOICHUHO>();
            using (MplisEntities db = new MplisEntities())
            {
                dSQuanHe = db.DM_QHVOICHUHO.OrderBy(it => it.STT).ToList();
            }
            return dSQuanHe;
        }
        public static List<DM_QUOCTICH> getdm_quoctich()
        {
            List<DM_QUOCTICH> lstdm_mdsd = new List<DM_QUOCTICH>();
            using (MplisEntities db = new MplisEntities())
            {
                lstdm_mdsd = (from item in db.DM_QUOCTICH
                              select item).OrderBy(a => a.TENQUOCGIATV).ToList();
            }
            return lstdm_mdsd;
        }
        public static List<HC_DMKVHC> getdm_HC_XA(string xaid)
        {
            HC_DMKVHC abc = new HC_DMKVHC();
            List<HC_DMKVHC> listxa = new List<HC_DMKVHC>();
            using (MplisEntities dbo = new MplisEntities())
            {
                abc = (from a in dbo.HC_DMKVHC where a.KVHCID == xaid select a).FirstOrDefault();
                 listxa = dbo.HC_DMKVHC.Where(i => i.HUYENID == abc.HUYENID).ToList();

            }
            return listxa;
        }
        public static List<DC_MUCDICHSUDUNGDAT> getmucdichsudung(List<DC_MUCDICHSUDUNGDAT> lst)
        {
            using (MplisEntities database = new MplisEntities())
            {
                if (lst != null)
                {
                    foreach (var a in lst)
                    {
                        if (a != null)
                        {
                            var loaigiayto = (from item in database.DM_MUCDICHSUDUNG where item.MUCDICHSUDUNGID == a.MUCDICHSUDUNGID select item).FirstOrDefault();
                            if (loaigiayto != null)
                            {
                                a.TenMDSD = loaigiayto.TENMUCDICHSUDUNG;
                            }
                        }
                    }
                }
            }
            return lst;
        }
        public static List<DM_VAITRONHOMNGUOI> GetDM_VAITRONHOMNGUOI()
        {
            List<DM_VAITRONHOMNGUOI> dSVaiTroNhomNguoi = new List<DM_VAITRONHOMNGUOI>();
            dSVaiTroNhomNguoi.Add(new DM_VAITRONHOMNGUOI("2", "Thành viên"));
            dSVaiTroNhomNguoi.Add(new DM_VAITRONHOMNGUOI("1", "Người đại diện"));
            return dSVaiTroNhomNguoi;
        }
        public static List<VaiTroTVNN> GetDM_VAITRONN()
        {
            List<VaiTroTVNN> dSVaiTroNhomNguoi = new List<VaiTroTVNN>();
            dSVaiTroNhomNguoi.Add(new VaiTroTVNN(0, "Thành viên"));
            dSVaiTroNhomNguoi.Add(new VaiTroTVNN(1, "Người đại diện"));
            return dSVaiTroNhomNguoi;
        }
        #endregion

        #region Services thửa đăng ký
        public static DC_THUADAT GetThuaBy_ThuaID(string THUAID)
        {
            DC_THUADAT objthua = new DC_THUADAT();
            using (MplisEntities dbo = new MplisEntities())
            {
                var obj = (from item in dbo.DC_THUADAT where item.THUADATID == THUAID select item).FirstOrDefault();
                if (obj != null)
                {
                    objthua = obj;
                }
            }
            return objthua;
        }
        //thêm thửa
        public static DC_THUADAT ThemTHuaDangKy(DC_THUADAT thuamoi, DC_THUADAT thuacu, bool them)
        {
            using (MplisEntities dbo = new MplisEntities())
            {
                if (thuamoi.XAID != null || thuamoi.SOTHUTUTHUA != null || thuamoi.SOHIEUTOBANDO != null)
                {
                    IQueryable<DC_THUADAT> objthuadat = dbo.DC_THUADAT;
                    if (!string.IsNullOrEmpty(thuamoi.XAID))
                    {
                        objthuadat = objthuadat.Where(x => x.XAID.Equals(thuamoi.XAID));
                    }
                    if (!string.IsNullOrEmpty(thuamoi.SOTHUTUTHUA.ToString()))
                    {
                        decimal? sothua = decimal.Parse(thuamoi.SOTHUTUTHUA.Value.ToString());
                        objthuadat = objthuadat.Where(x => x.SOTHUTUTHUA == sothua);
                    }
                    if (!string.IsNullOrEmpty(thuamoi.SOHIEUTOBANDO.ToString()))
                    {
                        decimal? soto = decimal.Parse(thuamoi.SOHIEUTOBANDO.Value.ToString());
                        objthuadat = objthuadat.Where(x => x.SOHIEUTOBANDO == soto);
                    }

                    objthuadat = objthuadat.Where(x => x.LOAITHUADAT.Equals("N"));
                    decimal? _soto = 0, _sothua = 0, _dt = 0, _dtpl = 0;

                    //bool _tranhchap = false;
                    //var objthuadat = dbo.DC_THUADAT.Where(predicate).FirstOrDefault();
                    var Thua = objthuadat.FirstOrDefault();
                    if (Thua != null)
                    {
                        if (thuamoi.THUADATID != null && thuamoi.THUADATID != "")
                        {
                            Mapper.Map<DC_THUADAT, DC_THUADAT>(thuamoi, Thua);
                            if (Thua.TAILIEUDODACID != null)
                            {
                                var obj = (from item in dbo.DC_TAILIEUDODAC.Where(i => i.TAILIEUDODACID == thuamoi.TAILIEUDODACID) select item).FirstOrDefault();
                                if (obj != null)
                                {
                                    thuamoi.TENTAILIEUDD = obj.TENTAILIEU;
                                }
                                else
                                {
                                    thuamoi.TENTAILIEUDD = "";
                                }
                            }
                            else
                            {
                                thuamoi.TENTAILIEUDD = "";
                            }
                            //cập nhật mục đích sử dụng
                            thuamoi.DSMucDichSuDungDat = thuacu.DSMucDichSuDungDat;
                            thuacu = thuamoi;
                            them = false;
                        }
                        else
                        {

                            DC_THUADAT themthua = new DC_THUADAT();
                            themthua = thuamoi;
                            themthua.THUADATID = Guid.NewGuid().ToString();
                            if (Thua.TAILIEUDODACID != null)
                            {
                                var obj = (from item in dbo.DC_TAILIEUDODAC.Where(i => i.TAILIEUDODACID == thuamoi.TAILIEUDODACID) select item).FirstOrDefault();
                                if (obj != null)
                                {
                                    thuamoi.TENTAILIEUDD = obj.TENTAILIEU;
                                }
                                else
                                {
                                    thuamoi.TENTAILIEUDD = "";
                                }
                            }
                            else
                            {
                                thuamoi.TENTAILIEUDD = "";
                            }
                            //cập nhật mục đích sử dụng
                            themthua.DSMucDichSuDungDat = thuacu.DSMucDichSuDungDat;
                            thuacu = themthua;
                            them = false;
                        }

                    }
                    // thêm thửa đăng ký 
                    else
                    {

                    }

                }

            }
            return thuacu;
        }


        #endregion
    }
    public class VaiTroTVNN
    {
        public VaiTroTVNN(int vaiTroID, string tenVaiTro)
        {
            VAITROID = vaiTroID;
            TENVAITRO = tenVaiTro;
        }
        public string TENVAITRO { get; set; }
        public int VAITROID { get; set; }
    }
    public class loaithuadat
    {
        public string idloaithuadat { get; set; }
        public string tenloaithuadat { get; set; }
    }
    public class objgioitinh
    {
        public Nullable<decimal> GIOITINH { get; set; }
        public string TENGIOITINH { get; set; }
    }
    public class DM_GIOITINH
    {
        public DM_GIOITINH(int gioiTinh, string tenGioiTinh)
        {
            GIOITINH = gioiTinh;
            TENGIOITINH = tenGioiTinh;
        }
        public int? GIOITINH { get; set; }
        public string TENGIOITINH { get; set; }
    }
    public class DM_VAITRONHOMNGUOI
    {
        public DM_VAITRONHOMNGUOI(string nhomNguoiVaiTroID, string tenVaiTro)
        {
            NHOMNGUOIVAITROID = nhomNguoiVaiTroID;
            TENVAITRO = tenVaiTro;
        }
        public string NHOMNGUOIVAITROID { get; set; }
        public string TENVAITRO { get; set; }
    }
    public class DM_LOAICHU
    {
        public DM_LOAICHU(int loaiChuID, string tenLoaiChu)
        {
            LOAICHUID = loaiChuID;
            TENLOAICHU = tenLoaiChu;
        }
        public int? LOAICHUID { get; set; }
        public string TENLOAICHU { get; set; }

    }

}