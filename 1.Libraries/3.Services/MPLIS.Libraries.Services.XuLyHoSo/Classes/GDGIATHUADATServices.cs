using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;
using AutoMapper;
using System.Data.Entity;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public class GDGIATHUADATServices
    {
        public static GD_GIATHUADAT CloneGiaThuaDat(GD_GIATHUADAT giaThuaDatGoc)
        {
            GD_GIATHUADAT giaThuaDatClone = new GD_GIATHUADAT();
            using (MplisEntities db = new MplisEntities())
            {
                Mapper.Map<GD_GIATHUADAT, GD_GIATHUADAT>(giaThuaDatGoc, giaThuaDatClone);
                giaThuaDatClone.GIATHUADATID = Guid.NewGuid().ToString();
                db.Entry(giaThuaDatClone).State = EntityState.Added;
                db.SaveChanges();
            }
            return giaThuaDatClone;
        }
    }
}