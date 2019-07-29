using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;
using System.Data.Entity;
using System.Data.Common;
using AutoMapper;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCGCNTYLESHServices
    {
        public static void SaveGCNTyLeSH(DC_GCN_TILESH gCNTLHS, MplisEntities db)
        {
            db.Entry(Mapper.Map<DC_GCN_TILESH, DC_GCN_TILESH>(gCNTLHS)).State = EntityState.Added;
        }
        public static bool DBInsertGCNTLSH(DC_GCN_TILESH gCNTLSH)
        {
            try
            {
                using (MplisEntities db = new MplisEntities())
                {
                    db.Entry(Mapper.Map<DC_GCN_TILESH, DC_GCN_TILESH>(gCNTLSH)).State = EntityState.Added;
                    db.SaveChanges();
                }
            } catch(Exception)
            {
                return false;
            }
            return true;
        }
        public static bool DBDeleteGCNTLSHByGCNID(string giayChungNhanID)
        {
            try
            {
                using (MplisEntities db = new MplisEntities())
                {
                    string queryDel = "";
                    queryDel += "DELETE FROM DC_GCN_TILESH WHERE GIAYCHUNGNHANID IN ('" + giayChungNhanID + "'); ";
                    if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                                || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                        db.Database.Connection.Open();
                    DbCommand cmd = db.Database.Connection.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "BEGIN " + queryDel + " END; ";
                    cmd.ExecuteNonQuery();
                }
            }catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}