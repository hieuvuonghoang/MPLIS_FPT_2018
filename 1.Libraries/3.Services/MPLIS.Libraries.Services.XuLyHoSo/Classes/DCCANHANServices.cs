using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;
using AutoMapper;
using MPLIS.Libraries.Data.XuLyHoSo.Models;
using System.Data.Entity;
using System.Data.Common;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCCANHANServices
    {
        public static DC_CANHAN GetCaNhan(string caNhanID, MplisEntities db)
        {
            DC_CANHAN objCaNhan = null;
            var retCaNhan = db.DC_CANHAN.Where(it => it.CANHANID == caNhanID)
                .Select(caNhan => new
                {
                    caNhan,
                    giayTos = db.DC_GIAYTOTUYTHAN.Where(it => it.CANHANID.Equals(caNhan.CANHANID))
                    .Select(giayTo => new
                    {
                        giayTo,
                        tenGiayTo = db.DM_LOAIGIAYTOTUYTHAN.Where(it => it.LOAIGIAYTOTUYTHANID.Equals(giayTo.LOAIGIAYTOTUYTHANID))
                        .Select(it => it.TENLOAIGIAYTOTUYTHAN)
                        .FirstOrDefault()
                    }).ToList()
                }).FirstOrDefault();
            if (retCaNhan != null)
            {
                objCaNhan = retCaNhan.caNhan;
                objCaNhan.TRANGTHAI = 2;
                if(objCaNhan.HOTEN == null || objCaNhan.HOTEN == "")
                    objCaNhan.HOTEN = retCaNhan.caNhan.HODEM + " " + retCaNhan.caNhan.TEN;
                objCaNhan.DSGiayToTuyThan = new List<DC_GIAYTOTUYTHAN>();
                DC_GIAYTOTUYTHAN giayTo = new DC_GIAYTOTUYTHAN();
                foreach (var tempGiayTo in retCaNhan.giayTos)
                {
                    giayTo = tempGiayTo.giayTo;
                    giayTo.TenGiayToTuyThan = tempGiayTo.tenGiayTo;
                    objCaNhan.DSGiayToTuyThan.Add(giayTo);
                }
            }
            return objCaNhan;
        }
        public static List<DC_CANHAN> GetDSCaNhan(string soGiayTo)
        {
            List<DC_CANHAN> dSCaNhan = new List<DC_CANHAN>();
            using(MplisEntities db = new MplisEntities())
            {
                var ret = db.DC_CANHAN.Where(it => it.SOGIAYTO == soGiayTo).ToList();
                if(ret != null)
                {
                    dSCaNhan = ret;
                }
            }
            return dSCaNhan;
        }
        public static void SaveCaNhan(DC_CANHAN caNhan, MplisEntities db)
        {
            //Xóa tất cả giấy tờ tùy thân liên quan tới cá nhân
            if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                    || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                db.Database.Connection.Open();
            DbCommand cmd = db.Database.Connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "BEGIN DELETE DC_GIAYTOTUYTHAN WHERE CANHANID IN ('" + caNhan.CANHANID + "'); END; ";
            cmd.ExecuteNonQuery();
            //Thêm mới cá nhân hoặc cập nhật thông tin
            if (caNhan.TRANGTHAI == 1)
            {
                db.Entry(caNhan).State = EntityState.Added;
                caNhan.TRANGTHAI = 2;
            }
            else if (caNhan.TRANGTHAI == 2)
            {
                db.Entry(caNhan).State = EntityState.Modified;
            }
            //Thêm mới tất cả giấy tờ tùy thân liên quan tới cá nhân
            foreach (var temp in caNhan.DSGiayToTuyThan)
            {
                temp.GIAYTOTUYTHANID = Guid.NewGuid().ToString();
                temp.CANHANID = caNhan.CANHANID;
                db.Entry(temp).State = EntityState.Added;
            }
        }
    }
}