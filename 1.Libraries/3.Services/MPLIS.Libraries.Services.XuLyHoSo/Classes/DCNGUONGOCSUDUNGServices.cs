using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;
using AutoMapper;
using System.Data.Entity;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public class DCNGUONGOCSUDUNGServices
    {
        public static DC_NGUONGOCSUDUNG CloneDCNguonGocSuDung(DC_NGUONGOCSUDUNG nguonGocSuDungGoc)
        {
            DC_NGUONGOCSUDUNG nguonGocSuDungClone = new DC_NGUONGOCSUDUNG();
            using (MplisEntities db = new MplisEntities())
            {
                Mapper.Map<DC_NGUONGOCSUDUNG, DC_NGUONGOCSUDUNG>(nguonGocSuDungGoc, nguonGocSuDungClone);
                nguonGocSuDungClone.NGUONGOCSUDUNGID = Guid.NewGuid().ToString();
                db.Entry(nguonGocSuDungClone).State = EntityState.Added;
                db.SaveChanges();
            }
            return nguonGocSuDungClone;
        }
    }
}