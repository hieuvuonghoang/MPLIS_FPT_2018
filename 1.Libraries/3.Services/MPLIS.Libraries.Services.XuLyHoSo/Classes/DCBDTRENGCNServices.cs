using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;
using System.Data.Entity;
using AutoMapper;

namespace MPLIS.Libraries.Services.XuLyHoSo
{
    public static class DCBDTRENGCNServices
    {
        public static void SaveBDTrenGCN(DC_BD_TREN_GCN bienDongTrenGCN, MplisEntities db)
        {
            db.Entry(Mapper.Map<DC_BD_TREN_GCN, DC_BD_TREN_GCN>(bienDongTrenGCN)).State = EntityState.Added;
        }
    }
}