using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;
using AutoMapper;
using System.Data.Entity;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public class DCMUCDICHSUDUNGServices
    {
        public static DC_MUCDICHSUDUNGDAT CloneMucDichSuDungDat(DC_MUCDICHSUDUNGDAT mucDichSuDungDatGoc)
        {
            DC_MUCDICHSUDUNGDAT mucDichSuDungDatClone = new DC_MUCDICHSUDUNGDAT();
            using (MplisEntities db = new MplisEntities())
            {
                Mapper.Map<DC_MUCDICHSUDUNGDAT, DC_MUCDICHSUDUNGDAT>(mucDichSuDungDatGoc, mucDichSuDungDatClone);
                mucDichSuDungDatClone.MDSDGOCID = mucDichSuDungDatClone.MUCDICHSUDUNGDATID;
                mucDichSuDungDatClone.MUCDICHSUDUNGDATID = Guid.NewGuid().ToString();
                db.Entry(mucDichSuDungDatClone).State = EntityState.Added;
                db.SaveChanges();

                //Clone DC_NGUONGOCSUDUNG
                foreach(var ngsd in mucDichSuDungDatClone.NGSDDats)
                {
                    ngsd.MUCDICHSUDUNGDATID = mucDichSuDungDatClone.MUCDICHSUDUNGDATID;
                    DCNGUONGOCSUDUNGServices.CloneDCNguonGocSuDung(ngsd);
                }
            }
            return mucDichSuDungDatClone;
        }

    }
}