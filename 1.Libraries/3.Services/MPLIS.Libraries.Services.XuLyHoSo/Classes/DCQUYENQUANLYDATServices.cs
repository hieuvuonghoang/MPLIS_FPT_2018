using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;
using System.Data.Entity;
using AutoMapper;

namespace MPLIS.Libraries.Services.XuLyHoSo
{
    public static class DCQUYENQUANLYDATServices
    {
        public static void SaveQuyenQuanLyDat(DC_QUYENQUANLYDAT quyenQLDat, MplisEntities db)
        {
            db.Entry(Mapper.Map<DC_QUYENQUANLYDAT, DC_QUYENQUANLYDAT>(quyenQLDat)).State = EntityState.Added;
        }
        public static bool DBInsertQuyenQuanLyDat(DC_QUYENQUANLYDAT quyenQLDat, out string message)
        {
            try
            {
                using (MplisEntities db = new MplisEntities())
                {
                    db.Entry(Mapper.Map<DC_QUYENQUANLYDAT, DC_QUYENQUANLYDAT>(quyenQLDat)).State = EntityState.Added;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
            message = "";
            return true;
        }
        public static bool DBDeleteQuyenQuanLyDat(DC_QUYENQUANLYDAT quyenQLDat, out string message)
        {
            using (MplisEntities db = new MplisEntities())
            {
                try
                {
                    db.Entry(Mapper.Map<DC_QUYENQUANLYDAT, DC_QUYENQUANLYDAT>(quyenQLDat)).State = EntityState.Deleted;
                    db.SaveChanges();
                } catch (Exception ex)
                {
                    message = ex.Message;
                    return false;
                }
            }
            message = "Xóa quyền quản lý đất thành công!";
            return true;
        }
    }
}