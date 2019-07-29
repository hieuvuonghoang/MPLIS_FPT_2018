using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;
using MPLIS.Libraries.Data.XuLyHoSo.Models;
using AutoMapper;
using System.Data.Entity;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCHOGIADINHTHANHVIENServies
    {
        public static void SaveHoGiaDinhThanhVien(DC_HOGIADINH_THANHVIEN hoGiaDinhThanhVien, MplisEntities db)
        {
            db.Entry(Mapper.Map<DC_HOGIADINH_THANHVIEN, DC_HOGIADINH_THANHVIEN>(hoGiaDinhThanhVien)).State = EntityState.Added;
        }
    }
}