using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Data.Entity;
using MPLIS.Libraries.Data.XuLyHoSo.Models;
using AppCore.Models;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCNHOMNGUOITHANHVIENServices
    {
        public static void SaveNhomNguoiThanhVien(DC_NHOMNGUOI_THANHVIEN nhomNguoiThanhVien, MplisEntities db)
        {
            db.Entry(Mapper.Map<DC_NHOMNGUOI_THANHVIEN, DC_NHOMNGUOI_THANHVIEN>(nhomNguoiThanhVien)).State = EntityState.Added;
        }
    }
}