using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCLOAIHANCHEServices
    {
        public static DC_LOAIHANCHE GetLoaiHanChe(string loaiHanCheID, MplisEntities db)
        {
            return db.DC_LOAIHANCHE.Where(it => it.LOAIHANCHEID.Equals(loaiHanCheID)).FirstOrDefault();
        }
    }
}