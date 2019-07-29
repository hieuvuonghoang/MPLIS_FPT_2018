using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;
using AutoMapper;
using System.Data.Entity;

namespace MPLIS.Libraries.Services.XuLyHoSo
{
    public static class DCBDGCNGCNServices
    {
        public static void SaveBDGCNGCN(DC_BD_GCN_GCN bienDongGCNGCN, MplisEntities db)
        {
            db.Entry(Mapper.Map<DC_BD_GCN_GCN, DC_BD_GCN_GCN>(bienDongGCNGCN)).State = EntityState.Added;
        }
    }
}