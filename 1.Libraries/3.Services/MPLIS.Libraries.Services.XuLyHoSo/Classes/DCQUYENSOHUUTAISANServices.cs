using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;
using System.Data.Entity;
using AutoMapper;

namespace MPLIS.Libraries.Services.XuLyHoSo
{
    public static class DCQUYENSOHUUTAISANServices
    {
        public static void SaveQuyenSoHuuTaiSan(DC_QUYENSOHUUTAISAN quyenSHTaiSan, MplisEntities db)
        {
            db.Entry(Mapper.Map<DC_QUYENSOHUUTAISAN, DC_QUYENSOHUUTAISAN>(quyenSHTaiSan)).State = EntityState.Added;
        }
        public static bool DBDeleteQuyenSoHuuTaiSan(DC_QUYENSOHUUTAISAN quyenSHTaiSan, out string message)
        {
            using (MplisEntities db = new MplisEntities())
            {
                try
                {
                    db.Entry(Mapper.Map<DC_QUYENSOHUUTAISAN, DC_QUYENSOHUUTAISAN>(quyenSHTaiSan)).State = EntityState.Deleted;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    return false;
                }
            }
            message = "Xóa quyền sở hữu tài sản thành công!";
            return true;
        }
        public static bool DBInsertQuyenSoHuuTaiSan(DC_QUYENSOHUUTAISAN quyenSHTS, out string message)
        {
            try
            {
                using (MplisEntities db = new MplisEntities())
                {
                    db.Entry(Mapper.Map<DC_QUYENSOHUUTAISAN, DC_QUYENSOHUUTAISAN>(quyenSHTS)).State = EntityState.Added;
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
    }
}