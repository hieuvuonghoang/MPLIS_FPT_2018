using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using MPLIS.Libraries.Data.XuLyHoSo.Models;
using MPLIS.Libraries.Services.XuLyHoSo.Classes;
using AppCore.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AutoMapper;
using System.Collections;
using MPLIS.Web.FrameWork.Base;
using System.Data.Entity;
using MPLIS.Libraries.Data.XuLyHoSo.Models.XuLyHoSo.DangKy;
using System.IO;
using MPLIS.Libraries.Services.SSO;
using MPLIS.Libraries.Data.SSO;
using System.Threading.Tasks;
using System.Net;
using System.ComponentModel;
using System.Net.Http;
using System.Configuration;
using MPLIS.Libraries.Data.SSO.Params;

namespace MPLIS.Modules.XuLyHoSo.Controllers
{
    public class XLHSHoSoLuuKhoController : BaseController
    {
        // GET: XLHSHoSoLuuKho
        public ActionResult Index()
        {
            return PartialView();
        }
        public ActionResult _HoSoLuuKho()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            ViewBag.listxaHSLuuKho = DONDANGKYServices.getdm_HC_XA(bhs.HoSoTN.DONVIHANHCHINHID);
            ViewBag.listmabiendong = HOSOLUUKHOServices.get_MABIENDONG();
            ViewBag.listPhongHSLuuKho = HOSOLUUKHOServices.get_PHONG();
            ViewBag.listKeHSLuuKho = HOSOLUUKHOServices.get_KE();
            ViewBag.listNganHSLuuKho = HOSOLUUKHOServices.get_NGAN();
            ViewBag.listHopHSLuuKho = HOSOLUUKHOServices.get_HOP();
            ViewBag.Listfilehoso = HOSOLUUKHOServices.get_giayto();
            HS_HOSO hoso = HOSOLUUKHOServices.get_HosoByHSTN(bhs.HoSoTN.HOSOTIEPNHANID);
            if (hoso.HOSOID == null)
            {
                hoso = HOSOLUUKHOServices.New_Hoso(bhs);
            }
            Session["HOSOLUUKHO"] = hoso;
            return PartialView(hoso);
        }
        public ActionResult _HoSoLuuKho_TTChung()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];

            ViewBag.listxaHSLuuKho = DONDANGKYServices.getdm_HC_XA(bhs.HoSoTN.DONVIHANHCHINHID);
            ViewBag.listmabiendong = HOSOLUUKHOServices.get_MABIENDONG();
            ViewBag.listPhongHSLuuKho = HOSOLUUKHOServices.get_PHONG();
            ViewBag.listKeHSLuuKho = HOSOLUUKHOServices.get_KE();
            ViewBag.listNganHSLuuKho = HOSOLUUKHOServices.get_NGAN();
            ViewBag.listHopHSLuuKho = HOSOLUUKHOServices.get_HOP();
            HS_HOSO hoso = HOSOLUUKHOServices.get_HosoByHSTN(bhs.HoSoTN.HOSOTIEPNHANID);
            return PartialView(hoso);
        }
        public ActionResult TaoMaHS(HS_HOSO hoso)
        {
            string MaHoSo=hoso.MAHOSO_ST+"."+hoso.MAHOSO_MB+"."+hoso.MAHOSO_TB;
            return Json(MaHoSo, JsonRequestBehavior.AllowGet);
        }
        public ActionResult _PopUp_ViTriLuu(string id,string LoaiViTri,string ten)
        {
            HS_VITRILUUTRU vitri = new HS_VITRILUUTRU();
            vitri.VITRILUUTRUID = id;
            vitri.MAVITRILUUTRU = LoaiViTri;
            vitri.TENVITRILUUTRU = ten;
            return PartialView("_PopUp_ViTriLuu", vitri);
        }
        public ActionResult CapNhatGCN()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            HS_HOSO hoso = (HS_HOSO)Session["HOSOLUUKHO"];
            hoso.DSGCN = new List<HS_TC_GCN>();
            foreach (var gnc in bhs.HoSoTN.BienDong.DSGcn)
            {
                if (gnc.LAGCNVAO == "N")
                {
                    HS_TC_GCN hsgcn = new HS_TC_GCN();
                    hsgcn.HOSOID = hoso.HOSOID;
                    hsgcn.MAKVHC = bhs.HoSoTN.MaKVHC;
                    hsgcn.MAVACH = gnc.MaVach;
                    hsgcn.SOPHATHANH = gnc.SoPhatHanh;
                    hsgcn.SOVAOSO = gnc.GiayChungNhan.SOVAOSO;
                    hsgcn.GCNID = gnc.GIAYCHUNGNHANID;
                    hsgcn.TCGCNID = Guid.NewGuid().ToString();
                    hsgcn.tenxa = bhs.HoSoTN.TenKVHC;
                    hsgcn.GiayChungNhan = gnc.GiayChungNhan;
                    hoso.DSGCN.Add(hsgcn);
                }
            }
            Session["HOSOLUUKHO"] = hoso;
            return PartialView("_HoSoLuuKho_GCN", hoso);

        }
        public ActionResult CapNhatTHUA()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            HS_HOSO hoso = (HS_HOSO)Session["HOSOLUUKHO"];
            hoso.DSThua = new List<HS_LIENKETTHUADAT>();
            foreach (var thua in bhs.HoSoTN.BienDong.DSThua)
            {
                if (thua.LOAITHUABD == "R")
                {
                    HS_LIENKETTHUADAT thualk = new HS_LIENKETTHUADAT();
                    thualk.HOSOID = hoso.HOSOID;
                    thualk.SOTHUA = thua.STTThua.ToString();
                    thualk.THUAID = thua.THUADATID;
                    thualk.SOTO = thua.SHToBanDo.ToString();
                    thualk.TOTHUAID = Guid.NewGuid().ToString();
                    thualk.XAID = bhs.HoSoTN.DONVIHANHCHINHID;
                    thualk.tenxa = bhs.HoSoTN.TenKVHC;
                    hoso.DSThua.Add(thualk);
                }
            }
            Session["HOSOLUUKHO"] = hoso;
            return PartialView("_HoSoLuuKho_Thua", hoso);

        }
        public ActionResult CapNhatCHU()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];

            HS_HOSO hoso = (HS_HOSO)Session["HOSOLUUKHO"];
            hoso.DSChu = new List<HS_TC_CHU>();
            foreach (var gcn in bhs.HoSoTN.BienDong.DSGcn)
            {
                if (gcn.LAGCNVAO == "N")
                {
                    if (gcn.GiayChungNhan.NGUOIID != null)
                    {
                        var check = (from a in hoso.DSChu where a.CHUID == gcn.GiayChungNhan.NGUOIID select a).FirstOrDefault();
                        if (check == null)
                        {
                            HS_TC_CHU hschu = HOSOLUUKHOServices.get_chuhs(gcn.GiayChungNhan.NGUOIID, hoso.HOSOID);
                            hoso.DSChu.Add(hschu);
                        }
                    }
                }

            }
            Session["HOSOLUUKHO"] = hoso;
            return PartialView("_HoSoLuuKho_Chu", hoso);

        }
        public ActionResult CapNhatViTri(string Loai, string ten, string id)
        {
            string Trangthai = "";
            if (id != null && id != "")
                Trangthai = "capnhat";
            else
                Trangthai = "themmoi";
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            var vitri = HOSOLUUKHOServices.CapNhatViTri(Loai, ten, id, bhs.HoSoTN.DONVIHANHCHINHID);
            ViewBag.listKeHSLuuKho = HOSOLUUKHOServices.get_KE();
            var result = new { vitriid = vitri.VITRILUUTRUID,vitrima=vitri.MAVITRILUUTRU,vitriten=vitri.TENVITRILUUTRU,trangthai=Trangthai};
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Save_formDonDangKy_HSLK(HS_HOSO hoso)
        {
            var result = HOSOLUUKHOServices.save(hoso);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Xoa_formDonDangKy_HSLK(string id)
        {
            string result = "xóa";
            HOSOLUUKHOServices.Del(id,"HS_HOSO");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Save_DSGCN()
        {
            string result = "";
            HS_HOSO hoso = (HS_HOSO)Session["HOSOLUUKHO"];
            var check = HOSOLUUKHOServices.check_hslk(hoso.HOSOID);
            if (check == false)
            {
                result = "Chưa có thông tin hồ sơ lưu kho!!!Yêu cầu tạo mới";
            }
            else
            {
                HOSOLUUKHOServices.SAVE_DSGCN(hoso);
                result = "Lưu danh sách giấy chứng nhận thành công";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Save_HSLK_DSTHUA()
        {
            string result = "";
            HS_HOSO hoso = (HS_HOSO)Session["HOSOLUUKHO"];
            var check = HOSOLUUKHOServices.check_hslk(hoso.HOSOID);
            if (check == false)
            {
                result = "Chưa có thông tin hồ sơ lưu kho!!!Yêu cầu tạo mới";
            }
            else
            {
                HOSOLUUKHOServices.SAVE_DSTHUA(hoso);
                result = "Lưu danh sách thửa thành công";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Save_HSLK_DSCHU()
        {
            string result = "";
            HS_HOSO hoso = (HS_HOSO)Session["HOSOLUUKHO"];
            var check = HOSOLUUKHOServices.check_hslk(hoso.HOSOID);
            if (check == false)
            {
                result = "Chưa có thông tin hồ sơ lưu kho!!!Yêu cầu tạo mới";
            }
            else
            {
                HOSOLUUKHOServices.SAVE_DSCHU(hoso);
                result = "Lưu danh sách chủ thành công";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ChitietFile(string idfile)
        {
            HS_HOSO hoso = (HS_HOSO)Session["HOSOLUUKHO"];
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            var file = (from a in hoso.DSFileDinhKem where a.THANHPHANHOSOID == idfile select a).FirstOrDefault();
            var result = new { fileid = file.THANHPHANHOSOID, hsid = file.HOSOID, loaifile = file.GIAYTOKEMTHEOHSID, tenfile = file.TENTEPDULIEU,duongdan=file.DUONGDAN };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CapNhatFile(HS_HOSO hosofile)
        {
            HS_HOSO hoso = (HS_HOSO)Session["HOSOLUUKHO"];
            if (hosofile.file.THANHPHANHOSOID != null && hosofile.file.THANHPHANHOSOID != "")
            {
                var check = (from a in hoso.DSFileDinhKem where a.THANHPHANHOSOID == hosofile.file.THANHPHANHOSOID select a).FirstOrDefault();
                if (check == null)
                {
                    var file = hosofile.file;
                    hoso.DSFileDinhKem.Add(file);
                    var result = new { fileid = file.THANHPHANHOSOID, hsid = file.HOSOID, loaifile = file.GIAYTOKEMTHEOHSID, tenfile = file.TENTEPDULIEU, duongdan = file.DUONGDAN };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json("dacofile", JsonRequestBehavior.AllowGet);
            }
            else
                return Json("cantaomoihoso", JsonRequestBehavior.AllowGet);

        }
        public ActionResult UpLoadFile()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            HS_HOSO hoso = (HS_HOSO)Session["HOSOLUUKHO"];
            HS_THANHPHANHOSO tphs = new HS_THANHPHANHOSO();
            tphs.HOSOID = hoso.HOSOID;
            tphs.THANHPHANHOSOID = Guid.NewGuid().ToString();
            var par = SSOHTTPRequestService.GetRequestParams(System.Web.HttpContext.Current.Request);
            var path= ConfigurationManager.AppSettings[SSOConstants.Configuration.FILE_UPLOAD_PATH];
            var upload = new UpLoad_infor();
            upload.LoaiFile = "DiaChinh";
            upload.Nam = DateTime.Now.Year.ToString();
            upload.BoHoSo = bhs.HoSoTN.SOBIENNHAN;
            upload.Xa = bhs.HoSoTN.TenKVHC;
            upload.Huyen = HOSOLUUKHOServices.gethuyen(bhs.HoSoTN.DONVIHANHCHINHID);
            upload.Tinh = HOSOLUUKHOServices.gettinh(bhs.HoSoTN.DONVIHANHCHINHID);
            var result = new { token = par.Token, path = path,loaifile=upload.LoaiFile,nam=upload.Nam,xa=upload.Xa,huyen=upload.Huyen,tinh=upload.Tinh,bohoso=upload.BoHoSo,donvi="",hosoinfor=tphs};
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DownLoadFile()
        {
            var par = SSOHTTPRequestService.GetRequestParams(System.Web.HttpContext.Current.Request);

            return Json(par.Token, JsonRequestBehavior.AllowGet);

        }
    }
}