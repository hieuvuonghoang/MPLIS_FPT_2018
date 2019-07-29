using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AppCore.Models;
using System.IO;
using System.Net;
using MPLIS.Web.FrameWork.Base;
using MPLIS.Libraries.Services.XuLyHoSo.Classes;
using MPLIS.Libraries.Data.XuLyHoSo.Models;
using System.Globalization;
using MPLIS.Libraries.Data.XuLyHoSo.Models.LichSu;
namespace MPLIS.Modules.XuLyHoSo.Controllers
{
    public class LichsuController : Controller
    {
        private MplisEntities db = new MplisEntities();
        public static BienDong_VM objbiendong = new BienDong_VM();
        public static HOSO_VM ObjHoSo = new HOSO_VM();
        // GET: Lichsu
        public ActionResult Index()
        {
            return PartialView();
        }

        public JsonResult ViewBienDong()
        {
            BienDongLS obj = new BienDongLS();
            obj.SOTHUTUBIENDONG = 1234555555555555555;
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ViewBienDong1()
        {
            BienDongLS obj = new BienDongLS();
            obj.SOTHUTUBIENDONG = 444444444444;
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public ActionResult _GCNLS()
        {
            var _BienDongID = "e924e5ac-4ca3-48c8-af8b-350ae68beba4";
            
            //ObjHoSo.CurDC_BienDong = DCBIENDONGServices.getBienDongByBienDongID(_BienDongID);
            ObjHoSo.CurDC_BienDong = DCBIENDONGServices.getBienDongByBienDongID(_BienDongID);
            //DCBIENDONGServices.updateTTBienDong(ObjHoSo);
            var listlsbohoso = (from item in db.LS_BOHOSO where item.BIENDONGID == ObjHoSo.CurDC_BienDong.BIENDONGID select item);
            foreach (var objbohs in listlsbohoso)
            {
                ObjHoSo.CurDC_BienDong.LS_BOHOSO.Add(objbohs);
            }
            // return PartialView("_BienDongLS", objbiendong);
            ListGCNLS lstgcn = new Controllers.ListGCNLS();
            var objthua = (from item in db.DC_THUADAT where item.SOTHUTUTHUA == 66 && item.SOHIEUTOBANDO == 17 && item.XAID == "ba15dfd78076462d9d9058b23611c759" select item).FirstOrDefault();
            if(objthua!=null)
            {
                ObjHoSo.dohoathua = objthua.GEOMETRY;
            }
            // List<GCNLS> listgcn = new List<GCNLS>();
            GCNLS obj1 = new Controllers.GCNLS();
            obj1.mavach = "123456";
            obj1.sophathanh = "11111";
            obj1.soquyetdinh = "222222";
            obj1.ngayquyetdinh = DateTime.Now;
            GCNLS obj2 = new Controllers.GCNLS();
            obj2.mavach = "4444444";
            obj2.sophathanh = "555555";
            obj2.soquyetdinh = "66666666";
            obj2.ngayquyetdinh = DateTime.Now;
            lstgcn.listgcn.Add(obj1);
            lstgcn.listgcn.Add(obj2);
            BienDongLS obj = new BienDongLS();
            obj.SOTHUTUBIENDONG = 444444444444;

            return PartialView("_GCNLS", ObjHoSo);
        }
        public ActionResult _BienDongLS()
        {
            var _BienDongID = "e924e5ac-4ca3-48c8-af8b-350ae68beba4";

            objbiendong.CurDC_BienDong = DCBIENDONGServices.getBienDongByBienDongID(_BienDongID);
            return PartialView("_BienDongLS", objbiendong);
        }
        public ActionResult LichSu()
        {
            QT_HOSOTIEPNHAN HSTN = QTHOSOTIEPNHANServices.getAllHoSoTiepNhan("2D921A9AF541474991F4380FAE31561F");
            HoSoTiepNhanLS HoSoLS = BOHOSOServices.ConvertHoSoTiepNhanToLS(HSTN);
            QT_HOSOTIEPNHAN HSTN1 = BOHOSOServices.ConvertHoSoLSToHoSoTiepNhan(HoSoLS);
            ObjLichSu obj = new Controllers.ObjLichSu();
            obj.name = "GCN";
            obj.GCN = "12345678";
            obj.SOTO = "12";
            obj.SOTHUA = "123";
            obj.CHU = "abc";
            obj.LAGCN = "Y";
            obj.className = "";
            obj.children = new List<ObjLichSu>() {
                new ObjLichSu { name = "Biến động", GCN = "Tách Thửa", SOTO = "", SOTHUA = "", CHU = "LAGCN", LAGCN = "N",
                children = new List<ObjLichSu>()
                {
                     new ObjLichSu { name = "GCN", GCN = "3333333333333", SOTO = "12", SOTHUA = "33", CHU = "xxxxxxxxxxxxxxxxx", LAGCN = "Y" },
                      new ObjLichSu { name = "GCN", GCN = "2222222222222", SOTO = "12", SOTHUA = "22", CHU = "tttttttttttttttttttt", LAGCN = "Y" }
                }
            } };
            return PartialView(obj);
        }

        // GET: Lichsu/Details/5
        public ActionResult Details(int id)
        {
            return PartialView();
        }

        // GET: Lichsu/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Lichsu/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return PartialView();
            }
        }

        // GET: Lichsu/Edit/5
        public ActionResult Edit(int id)
        {
            return PartialView();
        }

        // POST: Lichsu/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return PartialView();
            }
        }

        // GET: Lichsu/Delete/5
        public ActionResult Delete(int id)
        {
            return PartialView();
        }

        // POST: Lichsu/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return PartialView();
            }
        }
    }
    public class ObjLichSu
    {
        public string name { get; set; }
        public string GCN { get; set; }
        public string SOTO { get; set; }
        public string SOTHUA { get; set; }
        public string CHU { get; set; }
        public string LAGCN { get; set; }
        public string className { get; set; }
        public List<ObjLichSu> children { get; set; }
    }
    public class GCNLS
    {
        public string mavach { get; set; }
        public string sophathanh { get; set; }
        public string soquyetdinh { get; set; }
        public DateTime ngayquyetdinh { get; set; }

    }
    public class ListGCNLS
    {
        public List<GCNLS> listgcn = new List<GCNLS>();


    }
}
