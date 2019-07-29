using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;
using System.Data.Entity;
using AutoMapper;
using System.Data.Common;

namespace MPLIS.Libraries.Services.XuLyHoSo
{
    public static class DCQUYENSUDUNGDATServices
    {
        public static void SaveQuyenSuDungDat(DC_QUYENSUDUNGDAT quyenSDDat, MplisEntities db)
        {
            db.Entry(Mapper.Map<DC_QUYENSUDUNGDAT, DC_QUYENSUDUNGDAT>(quyenSDDat)).State = EntityState.Added;
        }
        public static void DBSaveQuyenSuDungDat(DC_GIAYCHUNGNHAN giayChungNhan)
        {
            using (MplisEntities db = new MplisEntities())
            {
                string queryDel = "DELETE FROM DC_QUYENSUDUNGDAT WHERE GIAYCHUNGNHANID IN ('" + giayChungNhan.GIAYCHUNGNHANID + "'); ";
                if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                            || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                    db.Database.Connection.Open();
                DbCommand cmd = db.Database.Connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "BEGIN " + queryDel + " END; ";
                cmd.ExecuteNonQuery();
            }
        }
        public static bool DBInsertQuyenSuDungDat(DC_QUYENSUDUNGDAT quyenSDDat, out string message)
        {
            try
            {
                using (MplisEntities db = new MplisEntities())
                {
                    db.Entry(Mapper.Map<DC_QUYENSUDUNGDAT, DC_QUYENSUDUNGDAT>(quyenSDDat)).State = EntityState.Added;
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
        public static bool DBDeleteQuyenSuDungDat(DC_QUYENSUDUNGDAT quyenSDDat, out string message)
        {
            using (MplisEntities db = new MplisEntities())
            {
                try
                {
                    db.Entry(Mapper.Map<DC_QUYENSUDUNGDAT, DC_QUYENSUDUNGDAT>(quyenSDDat)).State = EntityState.Deleted;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    return false;
                }
            }
            message = "Xóa quyền sử dụng đất thành công!";
            return true;
        }
    }
}