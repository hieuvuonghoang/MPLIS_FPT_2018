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
using Newtonsoft.Json;
using System.Data.Common;
using AutoMapper;
using System.Reflection;

namespace MPLIS.Modules.XuLyHoSo.Controllers
{
    public class TTBienDongController : BaseController
    {
        #region Biến Động HieuVH2
        [HttpPost]
        public ActionResult KiemTraBienDong()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            if (bhs.HoSoTN.BienDong == null)
            {
                bhs.HoSoTN.CurBienDong = new DC_BIENDONG();
                DC_BIENDONG bienDong = bhs.HoSoTN.CurBienDong;
                bienDong.BIENDONGID = Guid.NewGuid().ToString();
                bienDong.HOSOTIEPNHANID = bhs.HoSoTN.HOSOTIEPNHANID;
                Session["BoHoSo_" + CurrentUser.UserName] = bhs;
                return Json(new { exist = false, mes = "Cần tạo mới thông tin cho Biến Động!" });
            }
            return Json(new { exist = true });
        }
        public ActionResult BienDong_ThemMoi_TTChung()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            TTChungBienDongVM bd = Mapper.Map<DC_BIENDONG, TTChungBienDongVM>(bhs.HoSoTN.CurBienDong);
            ViewBag.DM_LOAIBIENDONG_list = new SelectList(bhs.DS_LoaiBienDong, "LOAIBIENDONGID", "TENLOAIBIENDONG");
            return PartialView(bd);
        }
        [HttpPost]
        public ActionResult BienDong_ThemMoi_Save(TTChungBienDongVM formData)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            bhs.HoSoTN.BienDong = Mapper.Map<TTChungBienDongVM, DC_BIENDONG>(formData);
            bhs.HoSoTN.BienDong.LOAIBIENDONGID = "444444";
            bhs.HoSoTN.BienDong.DSGcn = new List<DC_BD_GCN>();
            bhs.HoSoTN.BienDong.DSChu = new List<DC_BD_CHU>();
            bhs.HoSoTN.BienDong.DSThua = new List<DC_BD_THUA>();
            bhs.HoSoTN.CurBienDong = null;
            DCBIENDONGServices.SaveBienDong(bhs.HoSoTN.BienDong);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return Json(new { success = true, mes = "Thêm mới Biến Động thành công!" });
        }
        #region Giấy Chứng Nhận
        public ActionResult BienDong_DSGCN()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSGCNBDVM GCNVM = new DSGCNBDVM();
            GCNVM.initData(bhs);
            return PartialView(GCNVM);
        }
        public ActionResult BienDong_DSGCNVAO()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSGCNBDVM GCNVM = new DSGCNBDVM();
            GCNVM.initData(bhs);
            return PartialView(GCNVM);
        }
        public ActionResult BienDong_DSGCNRA()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSGCNBDVM GCNVM = new DSGCNBDVM();
            GCNVM.initData(bhs);
            return PartialView(GCNVM);
        }
        [HttpPost]
        public ActionResult BienDong_DSGCN_XoaGCN(string bienDongGCNID)
        {
            bool success = false;
            string message = "";
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            if (DCBDGCNServieces.XoaBDGCN(bienDongGCNID, bhs, out message))
            {
                Session["BoHoSo_" + CurrentUser.UserName] = bhs;
                success = true;
            }
            return Json(new { success = success, message = message });
        }
        [HttpPost]
        public ActionResult BienDong_DSGCNVAO_SaoChepGCN(string bienDongGCNID)
        {
            bool success = false;
            string message = "";
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            if(success = DCBDGCNServieces.SaoChepBDGCN(bienDongGCNID, bhs, out message))
                Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return Json(new { success = success, message = message });
        }
        [HttpPost]
        public ActionResult ThemMoi_GCN(string LAGCNVAO)
        {
            bool success = false;
            string message = "";
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            if (success = DCBDGCNServieces.ThemMoiBDGCN(LAGCNVAO, bhs, out message))
                Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return Json(new { success = success, message = message });
        }
        [HttpPost]
        public ActionResult ThemMoi_GCNVao_TuDangKy()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSGCNDonVM dSGCNDonVM = new DSGCNDonVM();
            foreach (var temp in bhs.HoSoTN.DonDangKy.DSDangKyGCN)
                dSGCNDonVM.DSDangKyGCN.Add(Mapper.Map<DC_DANGKY_GCN, GCNDonVM>(temp));
            return PartialView("Popup_DSGCNDangKy", dSGCNDonVM);
        }
        [HttpPost]
        public ActionResult BienDong_Save_DSGCN(string data)
        {
            bool success = false;
            string message = "";
            Hashtable hashTable = JsonConvert.DeserializeObject<Hashtable>(data);
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DCGIAYCHUNGNHANServices.ConvertHashTableToDSGCNCha(hashTable, bhs.HoSoTN.BienDong.DSGcn);
            return Json(new { success = success, message = message });
        }
        #endregion
        //Tham số truyền vào chuỗi data được JSON.stringify từ List<DANGKYGCNID>
        [HttpPost]
        public ActionResult SaveForm_Popup_DSGCNDangKy(string data)
        {
            bool success = false;
            string message = "";
            List<string> dSDANGKYGCNID = JsonConvert.DeserializeObject<List<string>>(data);
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            if (DCBDGCNServieces.ThemMoiBDGCNTuDangKy(dSDANGKYGCNID, bhs, out message))
            {
                Session["BoHoSo_" + CurrentUser.UserName] = bhs;
                success = true;
            }
            return Json(new { success = success, message = message });
        }
        #endregion
        //GET: TTBienDong
        public ActionResult Index()
        {
            return PartialView();
        }

        #region "Load data - for each partial view"
        public ActionResult _HoSoTiepNhan()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            //XuLyHoSoController xuLyHoSo = new XuLyHoSoController();
            //return PartialView("")
            ////Lưu lịch sử
            //QT_HOSOTIEPNHAN HSTN = QTHOSOTIEPNHANServices.getAllHoSoTiepNhan("da67d46d-621c-4e4e-89c3-758f949adf64"); //hồ sơ test lưu lịch sử
            ////QT_HOSOTIEPNHAN HSTN = QTHOSOTIEPNHANServices.getAllHoSoTiepNhan("2D921A9AF541474991F4380FAE31561F");   //hồ sơ Trường test
            //HoSoTiepNhanLS HoSoLS = BOHOSOServices.ConvertHoSoTiepNhanToLS(HSTN);
            //QT_HOSOTIEPNHAN HSTN1 = BOHOSOServices.ConvertHoSoLSToHoSoTiepNhan(HoSoLS);
            //BOHOSOServices.LuuLichSu(HSTN);

            ////Khôi phục dữ liệu
            //LS_BOHOSO bhs = BOHOSOServices.getHoSoLSByBienDongID("C3D9ADCCEAD046D593ACB353C5CEBF6D");
            //HoSoTiepNhanLS HoSoLS1 = JsonConvert.DeserializeObject<HoSoTiepNhanLS>(bhs.DATA);
            //BOHOSOServices.RestoreBussinessData(bhs);

            //BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            //ViewBag.DSLoaiHoSo
            ViewBag.DSLoaiHoSo = new SelectList(new List<SelectListItem>
            {
                new SelectListItem() {Selected = false, Text = "Trực tiếp", Value = "0" },
                new SelectListItem() {Selected = false, Text = "Trực tuyến", Value = "1" },
                new SelectListItem() {Selected = false, Text = "Nơi khác", Value = "2" }
            }, "LOAIHOSO", "TENLOAI");
            ViewBag.DSVaiTroNguoiNop = new SelectList(new List<SelectListItem>
            {
                new SelectListItem() {Selected = false, Text = "Chủ sử dụng / sở hữu", Value = "1" },
                new SelectListItem() {Selected = false, Text = "Người được ủy quyền", Value = "2" },
                new SelectListItem() {Selected = false, Text = "Điều kiện thửa kê khai trình", Value = "3" }
            }, "VAITRONGUOINOPHOSO", "TENVAITRO");
            ViewBag.DSPhuongPhapNhanThongBao = new SelectList(new List<SelectListItem>
            {
                new SelectListItem() {Selected = false, Text = "Trực tiếp", Value = "0" },
                new SelectListItem() {Selected = false, Text = "Tin nhắn SMS", Value = "1" },
                new SelectListItem() {Selected = false, Text = "Email", Value = "2" },
                new SelectListItem() {Selected = false, Text = "Tổng đài điện thoại", Value = "3" },
                new SelectListItem() {Selected = false, Text = "Trực tiếp + SMS", Value = "4" },
                new SelectListItem() {Selected = false, Text = "Trực tiếp + SMS + Email", Value = "5" },
                new SelectListItem() {Selected = false, Text = "Trực tiếp + SMS + Email + Tổng đài", Value = "6" }
            }, "PHUONGPHAPNHANTHONGBAO", "TENPHUONGPHAP");
            return PartialView("~/Views/XuLyHoSo/_XLHS_HoSoTiepNhan.cshtml", bhs.HoSoTN);
        }

        public ActionResult _ThongTinDangKy()
        {
            return PartialView();
        }

        public ActionResult _BienDong()
        {
            //BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            //ViewBag.DS_dsGCNDangKy_list = new SelectList(bhs.ls_droplist_ttriengGCN, "ID", "NAME");
            //Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            //TTChungBienDongVM bd = Mapper.Map<DC_BIENDONG, TTChungBienDongVM>(bhs.HoSoTN.BienDong);
            return PartialView();
        }//truongnt

        public ActionResult _BienDong_BD()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            TTChungBienDongVM bd = Mapper.Map<DC_BIENDONG, TTChungBienDongVM>(bhs.HoSoTN.BienDong);
            ViewBag.DM_LOAIBIENDONG_list = new SelectList(bhs.DS_LoaiBienDong, "LOAIBIENDONGID", "TENLOAIBIENDONG");
            return PartialView(bd);
        }

        public ActionResult _BienDong_DSCHU()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSChuBDVM ChuVM = new DSChuBDVM();
            ChuBDVM ch;
            foreach (var it in bhs.HoSoTN.BienDong.DSChu)
            {
                ch = Mapper.Map<DC_BD_CHU, ChuBDVM>(it);
                ChuVM.DSChu.Add(ch);
            }
            return PartialView(ChuVM);
        }

        public ActionResult _BienDong_DSCHUVAO()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSChuBDVM ChuVM = new DSChuBDVM();
            ChuBDVM ch;
            foreach (var it in bhs.HoSoTN.BienDong.DSChu)
            {
                ch = Mapper.Map<DC_BD_CHU, ChuBDVM>(it);
                ChuVM.DSChu.Add(ch);
            }
            ViewBag.DS_dsVaiTro_list = new SelectList(new List<SelectListItem>
            {
                new SelectListItem() {Selected = true, Text = "Bên thế chấp", Value = "T" },
                new SelectListItem() {Selected = false, Text = "Bên nhận thế chấp", Value = "N" },
                new SelectListItem() {Selected = false, Text = "Bên bảo lãnh", Value = "B" }
            }, "Value", "Text");
            return PartialView(ChuVM);
        }

        public ActionResult _BienDong_DSCHURA()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSChuBDVM ChuVM = new DSChuBDVM();
            ChuBDVM ch;
            foreach (var it in bhs.HoSoTN.BienDong.DSChu)
            {
                ch = Mapper.Map<DC_BD_CHU, ChuBDVM>(it);
                ChuVM.DSChu.Add(ch);
            }

            return PartialView(ChuVM);
        }

        public ActionResult _BienDong_DSGCN()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSGCNBDVM GCNVM = new DSGCNBDVM();
            GCNVM.initData(bhs);
            return PartialView(GCNVM);
        }

        public ActionResult _BienDong_DSGCNVAO()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSGCNBDVM GCNVM = new DSGCNBDVM();
            GCNVM.initData(bhs);
            return PartialView(GCNVM);
        }

        public ActionResult _BienDong_DSGCNRA()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSGCNBDVM GCNVM = new DSGCNBDVM();
            GCNVM.initData(bhs);

            return PartialView(GCNVM);
        }

        public ActionResult _BienDong_UpdateDSTHUA()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DCBIENDONGServices.updateDSThuaTuDSGCNVaoRa(bhs.HoSoTN);
            DSThuaBDVM ThuaVM = new DSThuaBDVM();
            ThuaVM.initData(bhs);

            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("_BienDong_DSTHUA", ThuaVM);
        }

        public ActionResult _BienDong_DSTHUA()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSThuaBDVM ThuaVM = new DSThuaBDVM();
            ThuaVM.initData(bhs);

            return PartialView(ThuaVM);
        }

        public ActionResult _BienDong_DSTHUAVAO()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSThuaBDVM ThuaVM = new DSThuaBDVM();
            ThuaVM.initData(bhs);
            return PartialView(ThuaVM);
        }

        public ActionResult _BienDong_DSTHUAXL()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSThuaBDVM ThuaVM = new DSThuaBDVM();
            ThuaVM.initData(bhs);

            return PartialView(ThuaVM);
        }

        public ActionResult _BienDong_DSTHUARA()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSThuaBDVM ThuaVM = new DSThuaBDVM();
            ThuaVM.initData(bhs);

            return PartialView(ThuaVM);
        }
        public ActionResult _BienDong_TTRIENG()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            TTRiengVM tTRiengVM = new TTRiengVM();
            //
            ViewBag.DS_dsVaiTro_list = new SelectList(new List<SelectListItem>
            {
                new SelectListItem() {Selected = true, Text = "Bên thế chấp", Value = "T" },
                new SelectListItem() {Selected = false, Text = "Bên nhận thế chấp", Value = "N" },
                new SelectListItem() {Selected = false, Text = "Bên bảo lãnh", Value = "B" }
            }, "Value", "Text");
            foreach (var it in bhs.HoSoTN.BienDong.DSChu)
            {
                tTRiengVM.dSChuBDVM.DSChu.Add(Mapper.Map<DC_BD_CHU, ChuBDVM>(it));
            }
            //
            if (bhs.HoSoTN.BienDong.TheChapObj != null)
            {
                tTRiengVM.theChapVM = Mapper.Map<DC_BD_THECHAP, TheChapVM>(bhs.HoSoTN.BienDong.TheChapObj);
                ViewBag.DS_dsGCNDangKy_list = new SelectList(bhs.ls_droplist_ttriengGCN, "ID", "NAME");
            }
            return PartialView(tTRiengVM);
        }
        public ActionResult _BienDong_TTRIENG_THECHAP()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            TheChapVM TCVM = new TheChapVM();
            if (bhs.HoSoTN.BienDong.TheChapObj != null)
                TCVM = Mapper.Map<DC_BD_THECHAP, TheChapVM>(bhs.HoSoTN.BienDong.TheChapObj);
            return PartialView(TCVM);
        }

        public ActionResult _BienDong_TTRIENG_THECHAP_TTQUYEN()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            if (bhs.HoSoTN.BienDong.TheChapObj != null)
            {
                ViewBag.DS_dsGCNDangKy_list = new SelectList(bhs.ls_droplist_ttriengGCN, "ID", "NAME");
                return PartialView("_BienDong_TTRIENG_THECHAP_TTQUYEN");
            }
            return Json(new { result = "" });
        }

        #region "TT riêng thế chấp"
        //id_chon = GIAYCHUNGNHANID
        public ActionResult _LoadChTietTTRieng_QuyenSD(string giayChungNhanID, string loaiBienDongID)
        {
            if (giayChungNhanID != "")
            {
                BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
                TheChapGiaiChapGCNVM theChapGiaiChapGCNVM = new TheChapGiaiChapGCNVM();
                theChapGiaiChapGCNVM.initData(bhs, giayChungNhanID, loaiBienDongID);
                return PartialView("_BienDong_TTRIENG_THECHAP_TTQUYEN_CTQUYEN", theChapGiaiChapGCNVM);
            }
            return Json(new { rusult = "" });
        }
        #endregion

        #region "Popup forms"
        public ActionResult _Popup_DSCHU()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSChuDonVM dSChuDonVM = new DSChuDonVM();
            ChuDonVM chuDonVM;
            foreach (var it in bhs.HoSoTN.DonDangKy.DSDangKyChu)
            {
                chuDonVM = Mapper.Map<DC_DANGKY_NGUOI, ChuDonVM>(it);
                dSChuDonVM.DSDangKyChu.Add(chuDonVM);
            }
            return PartialView(dSChuDonVM);
        }

        public ActionResult _Popup_DSGCNRA()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSGCNBDVM TCVM = new DSGCNBDVM();
            GCNBDVM ch;
            foreach (var it in bhs.HoSoTN.BienDong.DSGcn)
            {
                ch = Mapper.Map<DC_BD_GCN, GCNBDVM>(it);
                TCVM.DSGcn.Add(ch);
            }

            return PartialView(TCVM);
        }

        public ActionResult _Popup_DSGCNDangKy()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSGCNDonVM TCVM = new DSGCNDonVM();
            foreach (var it in bhs.HoSoTN.DonDangKy.DSDangKyGCN)
            {
                TCVM.DSDangKyGCN.Add(Mapper.Map<DC_DANGKY_GCN, GCNDonVM>(it));
            }
            return PartialView(TCVM);
        }
        public ActionResult _Popup_DSGCNVAO()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSGCNDonVM TCVM = new DSGCNDonVM();
            GCNDonVM ch;
            foreach (var it in bhs.HoSoTN.DonDangKy.DSDangKyGCN)
            {
                ch = Mapper.Map<DC_DANGKY_GCN, GCNDonVM>(it);
                TCVM.DSDangKyGCN.Add(ch);
            }
            return PartialView(TCVM);
        }

        public ActionResult _Popup_DSTHUARA()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSThuaBDVM TCVM = new DSThuaBDVM();
            ThuaBDVM ch;
            foreach (var it in bhs.HoSoTN.BienDong.DSThua)
            {
                ch = Mapper.Map<DC_BD_THUA, ThuaBDVM>(it);
                TCVM.DSThua.Add(ch);
            }

            return PartialView(TCVM);
        }

        public ActionResult _Popup_DSTHUAXL()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSThuaDonVM TCVM = new DSThuaDonVM();
            TCVM.initData(bhs);

            return PartialView(TCVM);
        }

        public ActionResult _Popup_DSTHUAVAO()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSThuaBDVM TCVM = new DSThuaBDVM();
            ThuaBDVM ch;
            foreach (var it in bhs.HoSoTN.BienDong.DSThua)
            {
                ch = Mapper.Map<DC_BD_THUA, ThuaBDVM>(it);
                TCVM.DSThua.Add(ch);
            }

            return PartialView(TCVM);
        }

        public ActionResult _PopupQuyetDinh()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            if (bhs.HoSoTN.BienDong.CurDC_QUYETDINH == null)
            {
                bhs.HoSoTN.BienDong.CurDC_QUYETDINH = new DC_QUYETDINH();
                Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            }
            return PartialView(Mapper.Map<DC_QUYETDINH, QuyetDinhVM>(bhs.HoSoTN.BienDong.CurDC_QUYETDINH));
        }
        #endregion

        public ActionResult _TTNghiaVuTaiChinh()
        {
            return PartialView();
        }

        #endregion

        #region "Save-DB"
        [HttpPost]
        public ActionResult Save_IDformBienDong_BD(TTChungBienDongVM formData)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DCBIENDONGServices.SaveDB_TTBIENDONG(formData, bhs.HoSoTN.BienDong);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return Json(new { result = "success" }); //PartialView("_BienDong_BD", bd);
        }

        [HttpPost]
        public ActionResult Save_IDformBienDong_DSGCN(string JsonGcnCha)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            Hashtable DSGcnCha = JsonConvert.DeserializeObject<Hashtable>(JsonGcnCha);
            DCBIENDONGServices.saveDSGCNCha(DSGcnCha, bhs.HoSoTN.BienDong.DSGcn);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return Json(new { result = "success" });
        }

        [HttpPost]
        public ActionResult Save_IDformBienDong_DSTHUA(string JsonThuaCha, bool isCOTHUAXL)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            Hashtable DSThuaCha = JsonConvert.DeserializeObject<Hashtable>(JsonThuaCha);
            //cần cập nhật lại thông tin của bhs và sử dụng bhs để lưu dữ liệu trước khi cập nhật lại vào session
            DCBIENDONGServices.Savedb_DSTHUA(bhs, isCOTHUAXL ? "Y" : "N", DSThuaCha);
            DSThuaBDVM ThuaVM = new DSThuaBDVM();
            ThuaVM.initData(bhs);
            Session["objVMBienDong_" + CurrentUser.UserName] = bhs;
            return PartialView("_BienDong_DSTHUA", ThuaVM);
        }

        [HttpPost]
        public ActionResult Save_IDformBienDong_TTRIENG(TheChapVM formData)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            //cần cập nhật lại thông tin của bhs và sử dụng bhs để lưu dữ liệu trước khi cập nhật lại vào session
            DCBIENDONGServices.SaveDB_TTRIENG(formData, bhs);
            Session["objVMBienDong_" + CurrentUser.UserName] = bhs;
            return Json(new { result = "success" }); //PartialView("_BienDong_TTRIENG_THECHAP", formData);
        }

        [HttpPost]
        public ActionResult Save_IDformBienDong_TTRIENG_THECHAP(TheChapVM formData)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DCBIENDONGServices.SaveDB_TTRIENG(formData, bhs);
            Session["objVMBienDong_" + CurrentUser.UserName] = bhs;
            return Json(new { result = "success" });
        }

        [HttpPost]
        public ActionResult Save_IDformBienDong_TTRIENG_CTQUYEN(string JsonTheChapGCNVM)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            QuyenDatQuyenSHTSJson quyenDatQuyenSHTSJson = JsonConvert.DeserializeObject<QuyenDatQuyenSHTSJson>(JsonTheChapGCNVM);
            DCBIENDONGServices.SaveDB_TTRIENG_CTQUYEN(quyenDatQuyenSHTSJson, bhs);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return Json(new { result = "success" });
        }

        #region "Popup quyết định"
        [HttpPost]
        public ActionResult Save_PopupQuyetDinh(QuyetDinhVM formData)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DCBIENDONGServices.SaveDB_QuyetDinh(formData, bhs);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            ViewBag.DM_LOAIBIENDONG_list = new SelectList(bhs.DS_LoaiBienDong, "LOAIBIENDONGID", "TENLOAIBIENDONG");
            return PartialView("_BienDong_BD", Mapper.Map<DC_BIENDONG, TTChungBienDongVM>(bhs.HoSoTN.BienDong));
        }
        #endregion
        #endregion

        #region "Xử lý nghiệp vụ trên chủ/thửa/giấy chứng nhận - Thêm/bớt đối tượng, tạo quan hệ trong các danh sách"
        #region Chủ 
        public ActionResult Remove_DSCHUVAO_R(string id)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DCBIENDONGServices.removeChuTrongBD(id, bhs);
            DSChuBDVM ChuVM = new DSChuBDVM();
            ChuBDVM ch;
            foreach (var it in bhs.HoSoTN.BienDong.DSChu)
            {
                ch = Mapper.Map<DC_BD_CHU, ChuBDVM>(it);
                ChuVM.DSChu.Add(ch);
            }
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("_BienDong_DSCHUVAO_Table", ChuVM);
        }

        public ActionResult Details_DSCHUVAO_R(string id)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            foreach (var it in bhs.HoSoTN.BienDong.DSChu)
            {
                Console.WriteLine("OK");
            }
            return PartialView("");
        }

        [HttpPost]
        public ActionResult Add_DSCHUVAO_RTABLE(string[] DSCHUVAO_CHON, string VAITRO)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            if (VAITRO == "T")
            {
                DCBIENDONGServices.addChuVaoBienDong(DSCHUVAO_CHON, "T", bhs);
            }
            else if (VAITRO == "N")
            {
                DCBIENDONGServices.addChuVaoBienDong(DSCHUVAO_CHON, "N", bhs);
            }
            else if (VAITRO == "B")
            {
                DCBIENDONGServices.addChuVaoBienDong(DSCHUVAO_CHON, "B", bhs);
            }

            DSChuBDVM ChuVM = new DSChuBDVM();
            ChuBDVM ch;
            foreach (var it in bhs.HoSoTN.BienDong.DSChu)
            {
                ch = Mapper.Map<DC_BD_CHU, ChuBDVM>(it);
                ChuVM.DSChu.Add(ch);
            }
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("_BienDong_DSCHUVAO_Table", ChuVM);
        }
        #endregion

        #region "Giấy chứng nhận"
        #region "Giấy chứng nhận vào"
        public ActionResult Remove_DSGCNVAO_R(string id)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DCBIENDONGServices.RemoveGCNBD(bhs, id);
            DSGCNBDVM GCNVM = new DSGCNBDVM();
            GCNVM.initData(bhs);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("_BienDong_DSGCN", GCNVM);
        }
        public ActionResult Copy_DSGCNVAO_R(string id)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DCGIAYCHUNGNHANServices.CopyGCNToiDauRa(bhs, id);
            DSGCNBDVM GCNVM = new DSGCNBDVM();
            GCNVM.initData(bhs);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("_BienDong_DSGCN", GCNVM);
        }
        [HttpPost]
        public ActionResult Add_DSGCNVAO_RTABLE(string[] DSGCNVAO_CHON)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DCBIENDONGServices.AddBienDongGCNs(DSGCNVAO_CHON, bhs);
            DSGCNBDVM GCNVM = new DSGCNBDVM();
            GCNVM.initData(bhs);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("_BienDong_DSGCNVAO", GCNVM);
        }

        public ActionResult ThemMoiGiayChungNhanVao()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DCBIENDONGServices.AddBienDongCreateNewGCN(bhs, "Y");
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            DSGCNBDVM GCNVM = new DSGCNBDVM();
            GCNVM.initData(bhs);

            return PartialView("_BienDong_DSGCNVAO", GCNVM);
        }
        #endregion

        #region "Giấy chứng nhận ra"
        public ActionResult Remove_DSGCNRA_R(string id)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DCBIENDONGServices.RemoveGCNBD(bhs, id);
            DSGCNBDVM GCNVM = new DSGCNBDVM();
            GCNVM.initData(bhs);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("_BienDong_DSGCNRA", GCNVM);
        }

        public ActionResult ThemMoiGiayChungNhanRa()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DCBIENDONGServices.AddBienDongCreateNewGCN(bhs, "N");
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            DSGCNBDVM GCNVM = new DSGCNBDVM();
            GCNVM.initData(bhs);

            return PartialView("_BienDong_DSGCN", GCNVM);
        }
        #endregion
        #endregion

        #region "thửa"
        public ActionResult Remove_DSTHUAXL_R(string id)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DCBIENDONGServices.RemoveThuaBD(bhs, id);
            DSThuaBDVM ThuaVM = new DSThuaBDVM();
            ThuaVM.initData(bhs);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("_BienDong_DSTHUA", ThuaVM);
        }

        [HttpPost]
        public ActionResult Add_DSTHUAXL_RTABLE(string[] DSTHUAXL_CHON)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DCBIENDONGServices.addThuaXLVaoBienDong(DSTHUAXL_CHON, bhs);
            DSThuaBDVM ThuaVM = new DSThuaBDVM();
            ThuaVM.initData(bhs);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("_BienDong_DSTHUA", ThuaVM);
        }
        #endregion
        #endregion

        #region Tìm kiếm quyết định theo số quyết định
        [HttpPost]
        public ActionResult _Popup_QuyetDinh_TimKiemQD(string soQuyetDinh)
        {
            List<DC_QUYETDINH> dSQuyetDinh = DCBIENDONGServices.getQuyetDinh(soQuyetDinh);
            if (dSQuyetDinh.Count() == 0)
            {
                DC_QUYETDINH quyetDinh = new DC_QUYETDINH(soQuyetDinh);
                return Json(quyetDinh);
            }
            else if (dSQuyetDinh.Count() == 1)
            {
                return Json(dSQuyetDinh[0]);
            }
            else
            {
                DSQuyetDinhVM dSQuyetDinhVM = new DSQuyetDinhVM();
                foreach (var objQuyetDinh in dSQuyetDinh)
                {
                    dSQuyetDinhVM.DSQuyetDinh.Add(Mapper.Map<DC_QUYETDINH, QuyetDinhVM>(objQuyetDinh));
                }
                string htmlContent = RenderRazorViewToString("_Popup_QuyetDinh_DSQuyetDinh", dSQuyetDinhVM);
                return Json(new { quyetDinh = new DC_QUYETDINH(soQuyetDinh), dSQuyetDinh = dSQuyetDinh, html = htmlContent });
            }
            //List<DC_QUYETDINH> dSQuyetDinh = new List<DC_QUYETDINH>();
            //DSQuyetDinhVM dSQuyetDinhVM = new DSQuyetDinhVM();
            //dSQuyetDinh.Add(new DC_QUYETDINH(soQuyetDinh));
            //foreach (var quyetDinh in dSQuyetDinh)
            //{
            //    dSQuyetDinhVM.DSQuyetDinh.Add(Mapper.Map<DC_QUYETDINH, QuyetDinhVM>(quyetDinh));
            //}
            //return PartialView("_PopupQuyetDinh", dSQuyetDinhVM.DSQuyetDinh[0]);
            //if (dSQuyetDinh.Count() == 0)
            //{
            //    dSQuyetDinh.Add(new DC_QUYETDINH(soQuyetDinh));
            //    foreach (var quyetDinh in dSQuyetDinh)
            //    {
            //        dSQuyetDinhVM.DSQuyetDinh.Add(Mapper.Map<DC_QUYETDINH, QuyetDinhVM>(quyetDinh));
            //    }
            //    return PartialView("_PopupQuyetDinh", dSQuyetDinhVM.DSQuyetDinh[0]);
            //}
            //else
            //{
            //    foreach (var quyetDinh in dSQuyetDinh)
            //    {
            //        dSQuyetDinhVM.DSQuyetDinh.Add(Mapper.Map<DC_QUYETDINH, QuyetDinhVM>(quyetDinh));
            //    }
            //    return PartialView(dSQuyetDinhVM);
            //}
        }

        public string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
        #endregion
    }
}