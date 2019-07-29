using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MPLIS.Libraries.Data.XuLyHoSo.Models;
using AppCore.Models;
using AutoMapper;
using System.Data.Entity;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCGIAYTOTUYTHANServices
    {
        public static string GetTenLoaiGiayTo(string loaiGiayToTuyThanID)
        {
            string tenLoaiGiayToTuyThan = "";
            using(MplisEntities db = new MplisEntities())
            {
                var ret = db.DM_LOAIGIAYTOTUYTHAN.Where(it => it.LOAIGIAYTOTUYTHANID.Equals(loaiGiayToTuyThanID))
                    .Select(it => it.TENLOAIGIAYTOTUYTHAN).FirstOrDefault();
                if(ret != null)
                {
                    tenLoaiGiayToTuyThan = ret;
                }
            }
            return tenLoaiGiayToTuyThan;
        }
    }
}