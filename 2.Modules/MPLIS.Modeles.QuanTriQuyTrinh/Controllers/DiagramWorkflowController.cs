using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppCore.Models;
using MPLIS.Libraries.Data.QuanTriQuyTrinh.Models;
using MPLIS.Libraries.Services.QuanTriQuyTrinh;
using MPLIS.Web.FrameWork.Base;
using AutoMapper;
using Newtonsoft.Json;
using MPLIS.Libraries.Data.SSO.Models;

namespace MPLIS.Modeles.QuanTriQuyTrinh.Controllers
{
    public class DiagramWorkflowController : BaseController
    {
        // GET: DiagramWorkflow
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Demo()
        {
            QT_QUYTRINH quyTrinh = new QT_QUYTRINH();
            return PartialView(quyTrinh);
        }
        [HttpPost]
        public ActionResult TimKiem_QUYTRINH(string tenQuyTrinh)
        {
            BSUserInfor ui = (BSUserInfor)Session["BSUserInfor"];
            byte capToChuc = ui.UserInfo.ToChuc.CAPTOCHUC ?? 0;
            string donViHanhChinhID = ui.UserInfo.ToChuc.DONVIHANHCHINHID;
            List<QT_QUYTRINH> dSQuyTrinh = new List<QT_QUYTRINH>();
            Session["dSQuyTrinh"] = dSQuyTrinh;
            DSQuyTrinhVM dSQuyTrinhVM = new DSQuyTrinhVM();
            if (tenQuyTrinh != null && tenQuyTrinh != "")
            {
                dSQuyTrinh = QTQUYTRINHServices.TimKiemQuyTrinhByTenQuyTrinh(tenQuyTrinh, donViHanhChinhID);
                Session["dSQuyTrinh"] = dSQuyTrinh;
            }
            if (dSQuyTrinh.Count > 0)
            {
                //Chứa dữ liệu sử dụng cho View
                foreach (var tempQuyTrinh in dSQuyTrinh)
                {
                    dSQuyTrinhVM.DSQuyTrinh.Add(tempQuyTrinh);
                }
            }
            //Tạo Session chứa danh sách người dùng và danh sách khu vực hành chính liên quan tới CurrentUser
            if (Session["dSNguoiDung"] == null)
            {
                Session["dSNguoiDung"] = HTNGUOIDUNGServices.GetNguoiDungByDVHCID(donViHanhChinhID);
            }
            if (Session["dSKVHC"] == null)
            {
                Session["dSKVHC"] = HCDMKVHCServices.GetKVHC(capToChuc, donViHanhChinhID);
            }
            return PartialView("_QuyTrinh_DSQuyTrinh", dSQuyTrinhVM);
        }
        [HttpPost]
        public ActionResult _QuyTrinh_ChiTietQuyTrinh(string quyTrinhID)
        {
            List<QT_QUYTRINH> dSQuyTrinh = (List<QT_QUYTRINH>)Session["dSQuyTrinh"];
            QT_QUYTRINH curQuyTrinh = new QT_QUYTRINH();
            foreach (var tempQuyTrinh in dSQuyTrinh)
            {
                if (tempQuyTrinh.QUYTRINHID == quyTrinhID)
                {
                    curQuyTrinh = tempQuyTrinh;
                    break;
                }
            }
            Session["curQuyTrinh"] = curQuyTrinh;
            return PartialView(curQuyTrinh);
        }
        [HttpPost]
        public ActionResult _QuyTrinh_TTQuyTrinh()
        {
            QT_QUYTRINH curQuyTrinh = (QT_QUYTRINH)Session["curQuyTrinh"];
            ViewBag.dSNhomQuyTrinh = QTNHOMQUYTRINHServices.GetDSNhomQuyTrinh();
            return PartialView(curQuyTrinh);
        }
        [HttpPost]
        public ActionResult _QuyTrinh_SoDoQuyTrinh()
        {
            QT_QUYTRINH curQuyTrinh = (QT_QUYTRINH)Session["curQuyTrinh"];
            return PartialView(curQuyTrinh);
        }
        [HttpPost]
        public ActionResult _QuyTrinh_Save_SoDoQuyTrinh(string eXML, string eSVG)
        {
            List<QT_QUYTRINH> dSQuyTrinh = (List<QT_QUYTRINH>)Session["dSQuyTrinh"];
            QT_QUYTRINH curQuyTrinh = (QT_QUYTRINH)Session["curQuyTrinh"];
            List<QT_BUOCQUYTRINH> curDSBuocQuyTrinh = new List<QT_BUOCQUYTRINH>();
            string mes = "";
            bool err = false;
            string errMes = "";
            curDSBuocQuyTrinh = QTBUOCQUYTRINHServices.ConvertXMLToObject(eXML, curQuyTrinh.QUYTRINHID, out err, out errMes);
            if (!err)
            {
                curQuyTrinh.SVG = eSVG;
                curQuyTrinh.XML = eXML;
                QTQUYTRINHServices.SaveQuyTrinh(dSQuyTrinh, curQuyTrinh, out mes);
                QTBUOCQUYTRINHServices.SaveBuocQuyTrinh(curQuyTrinh, curDSBuocQuyTrinh);
                Session["curQuyTrinh"] = curQuyTrinh;
                return Json(new { mes = "Lưu sơ đồ quy trình thành công!" });
            }
            else
            {
                return Json(new { mes = errMes });
            }
        }
        [HttpPost]
        public ActionResult _QuyTrinh_SaoChep(string quyTrinhID)
        {
            List<QT_QUYTRINH> dSQuyTrinh = (List<QT_QUYTRINH>)Session["dSQuyTrinh"];
            QT_QUYTRINH quyTrinhClone = null;
            bool success = false;
            string mes = "";
            if (QTQUYTRINHServices.CoppyQuyTrinh(dSQuyTrinh, quyTrinhID, out quyTrinhClone, out mes))
            {
                success = true;
                Session["dSQuyTrinh"] = dSQuyTrinh;
                return Json(new { success = success, mes = mes, quyTrinh = Json(new { QUYTRINHID = quyTrinhClone.QUYTRINHID, TENQUYTRINH = quyTrinhClone.TENQUYTRINH, TENNHOMQUYTRINH = quyTrinhClone.TENNHOMQUYTRINH, CAPQUYTRINH = quyTrinhClone.CAPQUYTRINH, THOIHANGIAIQUYETTOIDA = quyTrinhClone.THOIHANGIAIQUYETTOIDA }).Data });
            }
            //var obj = Json(new {QUYTRINHID = quyTrinhClone.QUYTRINHID, TENQUYTRINH = quyTrinhClone.TENQUYTRINH, TENNHOMQUYTRINH = quyTrinhClone.TENNHOMQUYTRINH, CAPQUYTRINH = quyTrinhClone.CAPQUYTRINH, THOIHANGIAIQUYETTOIDA = quyTrinhClone.THOIHANGIAIQUYETTOIDA });
            return Json(new { success = success, mes = mes });
        }
        [HttpPost]
        public ActionResult _QuyTrinh_XoaQuyTrinh(string quyTrinhID)
        {
            List<QT_QUYTRINH> dSQuyTrinh = (List<QT_QUYTRINH>)Session["dSQuyTrinh"];
            string mes = "";
            bool success = false;
            if (QTQUYTRINHServices.DeleteQuyTrinh(dSQuyTrinh, quyTrinhID, out mes))
            {
                //Xóa thành công: Cập nhật lại Session
                success = true;
                Session["dSQuyTrinh"] = dSQuyTrinh;
            }
            return Json(new { success = success, mes = mes });
        }
        [HttpPost]
        public ActionResult _QuyTrinh_ThemMoi()
        {
            BSUserInfor ui = (BSUserInfor)Session["BSUserInfor"];
            QT_QUYTRINH quyTrinh = new QT_QUYTRINH();
            string donViHanhChinhID = ui.UserInfo.ToChuc.DONVIHANHCHINHID;
            quyTrinh.QUYTRINHID = Guid.NewGuid().ToString();
            quyTrinh.TRANGTHAI = 1;
            quyTrinh.DONVIHANHCHINHID = donViHanhChinhID;
            Session["curQuyTrinh"] = quyTrinh;
            return PartialView("_QuyTrinh_ChiTietQuyTrinh", quyTrinh);
        }
        [HttpPost]
        public ActionResult _QuyTrinh_CauHinhXuLy()
        {
            QT_QUYTRINH curQuyTrinh = (QT_QUYTRINH)Session["curQuyTrinh"];
            CauHinhXuLyVM cauHinhXuLyVM = new CauHinhXuLyVM();
            cauHinhXuLyVM.DSBuocQuyTrinh = new List<QT_BUOCQUYTRINH>();
            foreach (var tempBuocQuyTrinh in curQuyTrinh.DSBuocQuyTrinh)
            {
                cauHinhXuLyVM.DSBuocQuyTrinh.Add(tempBuocQuyTrinh);
            }
            cauHinhXuLyVM.CauHinhXuLy = curQuyTrinh.CauHinhXuLy;
            cauHinhXuLyVM.DSNguoiDung = (List<HT_NGUOIDUNG>)Session["dSNguoiDung"];
            cauHinhXuLyVM.DSKhuVucHanhChinh = (List<HC_DMKVHC>)Session["dSKVHC"];
            return PartialView(cauHinhXuLyVM);
        }
        [HttpPost]
        public ActionResult _Save_QuyTrinh_CauHinhXuLy(string jsonCauHinhXuLy)
        {
            QT_QUYTRINH curQuyTrinh = (QT_QUYTRINH)Session["curQuyTrinh"];
            QTBUOCQTCAUHINHServices.SaveBuocQTCauHinh(jsonCauHinhXuLy, curQuyTrinh);
            Session["curQuyTrinh"] = curQuyTrinh;
            return Json("Success");
        }
        [HttpPost]
        public ActionResult _Save_QuyTrinh_TTQuyTrinh(QT_QUYTRINH formQuyTrinh)
        {
            List<QT_QUYTRINH> dSQuyTrinh = (List<QT_QUYTRINH>)Session["dSQuyTrinh"];
            QT_QUYTRINH curQuyTrinh = (QT_QUYTRINH)Session["curQuyTrinh"];
            string mes = "";
            bool success = false;
            curQuyTrinh.TENQUYTRINH = formQuyTrinh.TENQUYTRINH;
            curQuyTrinh.KYHIEU = formQuyTrinh.KYHIEU;
            curQuyTrinh.CAPQUYTRINH = formQuyTrinh.CAPQUYTRINH;
            curQuyTrinh.THOIHANGIAIQUYETTOIDA = formQuyTrinh.THOIHANGIAIQUYETTOIDA;
            curQuyTrinh.NHOMQUYTRINHID = formQuyTrinh.NHOMQUYTRINHID;
            if(QTQUYTRINHServices.SaveQuyTrinh(dSQuyTrinh, curQuyTrinh, out mes))
            {
                success = true;
                //var obj = Json(new { QUYTRINHID = curQuyTrinh.QUYTRINHID, TENQUYTRINH = curQuyTrinh.TENQUYTRINH, TENNHOMQUYTRINH = curQuyTrinh.TENNHOMQUYTRINH, CAPQUYTRINH = curQuyTrinh.CAPQUYTRINH, THOIHANGIAIQUYETTOIDA = curQuyTrinh.THOIHANGIAIQUYETTOIDA });
                return Json(new { success = success, mes = mes, Json(new { QUYTRINHID = curQuyTrinh.QUYTRINHID, TENQUYTRINH = curQuyTrinh.TENQUYTRINH, TENNHOMQUYTRINH = curQuyTrinh.TENNHOMQUYTRINH, CAPQUYTRINH = curQuyTrinh.CAPQUYTRINH, THOIHANGIAIQUYETTOIDA = curQuyTrinh.THOIHANGIAIQUYETTOIDA }).Data });
            }
            Session["curQuyTrinh"] = curQuyTrinh;
            Session["dSQuyTrinh"] = dSQuyTrinh;
            return Json(new { success = success, mes = mes });
        }
        [HttpPost]
        public ActionResult _Popup_QuyTrinh_CauHinhXuLy_ChinhSuaBuoc(string buocQuyTrinhID)
        {
            QT_QUYTRINH curQuyTrinh = (QT_QUYTRINH)Session["curQuyTrinh"];
            foreach (var tempBuocQuyTrinh in curQuyTrinh.DSBuocQuyTrinh)
            {
                if (tempBuocQuyTrinh.BUOCQUYTRINHID == buocQuyTrinhID)
                {
                    curQuyTrinh.CurBuocQuyTrinh = tempBuocQuyTrinh;
                    break;
                }
            }
            Session["curQuyTrinh"] = curQuyTrinh;
            return PartialView(curQuyTrinh.CurBuocQuyTrinh);

        }
        [HttpPost]
        public ActionResult _Save_QuyTrinh_TTBuocQuyTrinh(string dataJSON)
        {
            QT_QUYTRINH curQuyTrinh = (QT_QUYTRINH)Session["curQuyTrinh"];
            QT_BUOCQUYTRINH buocQuyTrinh = JsonConvert.DeserializeObject<QT_BUOCQUYTRINH>(dataJSON);
            foreach (var tempCongViec in buocQuyTrinh.DSCongViecTheoBuoc)
            {
                tempCongViec.CONGVIECTHEOBUOCID = Guid.NewGuid().ToString();
            }
            QT_BUOCQUYTRINH curBuocQuyTrinh = curQuyTrinh.CurBuocQuyTrinh;
            if (buocQuyTrinh.BUOCQUYTRINHID == curBuocQuyTrinh.BUOCQUYTRINHID)
            {
                curBuocQuyTrinh.THOIGIANQUYDINH = buocQuyTrinh.THOIGIANQUYDINH;
                curBuocQuyTrinh.MOTA = buocQuyTrinh.MOTA;
                curBuocQuyTrinh.DSCongViecTheoBuoc = buocQuyTrinh.DSCongViecTheoBuoc;
                Session["curQuyTrinh"] = curQuyTrinh;
                return Json(new { err = false, BUOCQUYTRINHID = buocQuyTrinh.BUOCQUYTRINHID, THOIGIANQUYDINH = buocQuyTrinh.THOIGIANQUYDINH, MOTA = buocQuyTrinh.MOTA });
            }
            else
            {
                return Json(new { err = true });
            }
        }
        [HttpPost]
        public ActionResult _QuyTrinh_DSCongViec_ThemMoi()
        {
            QT_QUYTRINH curQuyTrinh = (QT_QUYTRINH)Session["curQuyTrinh"];
            QT_CONGVIECTHEOBUOC congViecTheoBuoc = new QT_CONGVIECTHEOBUOC();
            congViecTheoBuoc.CONGVIECTHEOBUOCID = Guid.NewGuid().ToString();
            return PartialView();
        }
        [HttpPost]
        public ActionResult _QuyTrinh_DSCongViec_ChiTiet()
        {
            QT_TTHC_QUYTRINH curTTHCQuyTrinh = (QT_TTHC_QUYTRINH)Session["curTTHCQuyTrinh"];
            QT_BUOCQUYTRINH curBuocQuyTrinh = curTTHCQuyTrinh.QuyTrinh.CurBuocQuyTrinh;
            QT_QUYTRINH curQuyTrinh = curTTHCQuyTrinh.QuyTrinh;
            QT_CONGVIECTHEOBUOC congViecTheoBuoc = new QT_CONGVIECTHEOBUOC();
            congViecTheoBuoc.CONGVIECTHEOBUOCID = Guid.NewGuid().ToString();
            return PartialView();
        }
        public ActionResult DesignDiagram()
        {
            QT_QUYTRINH quyTrinh = new QT_QUYTRINH();
            using (MplisEntities db = new MplisEntities())
            {
                var ret = db.QT_QUYTRINH.Where(it => it.QUYTRINHID == "8764A420876B424B90E2BE40FAE898C5").FirstOrDefault();
                if (ret != null)
                {
                    quyTrinh = ret;
                }
            }
            return View(quyTrinh);
        }

    }
}