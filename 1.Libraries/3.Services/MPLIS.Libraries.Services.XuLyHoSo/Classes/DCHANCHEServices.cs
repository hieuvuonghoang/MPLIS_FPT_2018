using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using AppCore.Models;
using MPLIS.Libraries.Data.XuLyHoSo.Models;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCHANCHEServices
    {
        public static void SaveHanChe(DC_HANCHE hanChe, MplisEntities db)
        {
            db.Entry(Mapper.Map<DC_HANCHE, DC_HANCHE>(hanChe)).State = EntityState.Added;
        }
        public static bool DBInsertOrUpdateHanChe_GCN(DC_HANCHE hanChe, out string message, BoHoSoModel bhs)
        {
            string str = "";
            if(bhs.CurDC_GIAYCHUNGNHAN.ChinhSua)
            {
                try
                {
                    using (MplisEntities db = new MplisEntities())
                    {
                        if (hanChe.HANCHEID == null || hanChe.HANCHEID == "")
                        {
                            hanChe.HANCHEID = Guid.NewGuid().ToString();
                            hanChe.GIAYCHUNGNHANID = bhs.CurDC_GIAYCHUNGNHAN.GIAYCHUNGNHANID;
                            db.Entry(Mapper.Map<DC_HANCHE, DC_HANCHE>(hanChe)).State = EntityState.Added;
                        }
                        else
                        {
                            db.Entry(Mapper.Map<DC_HANCHE, DC_HANCHE>(hanChe)).State = EntityState.Modified;
                        }
                        db.SaveChanges();
                    }
                    DC_HANCHE tempHanChe = null;
                    if (bhs.CurDC_GIAYCHUNGNHAN.DSHanChe != null)
                    {
                        foreach (var temp in bhs.CurDC_GIAYCHUNGNHAN.DSHanChe)
                        {
                            if (temp.HANCHEID == hanChe.HANCHEID)
                            {
                                tempHanChe = temp;
                                break;
                            }
                        }
                    }
                    else
                    {
                        bhs.CurDC_GIAYCHUNGNHAN.DSHanChe = new List<DC_HANCHE>();
                    }
                    if (tempHanChe != null)
                    {
                        bhs.CurDC_GIAYCHUNGNHAN.DSHanChe.Remove(tempHanChe);
                        str = "Cập nhật thông tin hạn chế thành công!";
                    }
                    else
                    {
                        str = "Thêm mới hạn chế thành công!";
                    }
                    bhs.CurDC_GIAYCHUNGNHAN.DSHanChe.Add(hanChe);
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    return false;
                }
                message = str;
                return true;
            }
            message = "Dữ liệu không đúng?";
            return false;
        }
        public static bool DBDeleteHanChe(string hanCheID, BoHoSoModel bhs, out string message)
        {
            if (hanCheID != "" && bhs.CurDC_GIAYCHUNGNHAN.TRANGTHAIXULY == "S")
            {
                DC_HANCHE hanChe = null;
                foreach (var tempHanChe in bhs.CurDC_GIAYCHUNGNHAN.DSHanChe)
                {
                    if (tempHanChe.HANCHEID == hanCheID)
                    {
                        hanChe = tempHanChe;
                        break;
                    }
                }
                if (hanChe != null)
                {
                    try
                    {
                        using (MplisEntities db = new MplisEntities())
                        {
                            db.Entry(Mapper.Map<DC_HANCHE, DC_HANCHE>(hanChe)).State = EntityState.Deleted;
                            db.SaveChanges();
                        }
                        bhs.CurDC_GIAYCHUNGNHAN.DSHanChe.Remove(hanChe);
                    }
                    catch (Exception ex)
                    {
                        message = ex.Message;
                        return false;
                    }
                    message = "Xóa hạn chế thành công!";
                    return true;
                }
            }
            message = "Dữ liệu không đúng?\nHoặc bạn đang xóa hạn chế trên GCN đang có tính pháp lý?";
            return false;
        }
    }
}