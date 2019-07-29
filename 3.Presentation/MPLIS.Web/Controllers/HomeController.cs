using AppCore.Models;
using MPLIS.Libraries.Data.SSO.Models;
using MPLIS.Libraries.Services.SSO;
using MPLIS.Libraries.Services.Utilities;
using MPLIS.Web.FrameWork.Authentication;
using MPLIS.Web.FrameWork.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MPLIS.Web.Controllers
{
    public class HomeController : BaseController
    {
        private MplisEntities coSoDuLieuMplis = new MplisEntities();
        
        public ActionResult ThongBaoQuyenNguoiDung()
        {
            return View();
        }
        //[MPLIS.Web.FrameWork.Authentication.CustomAuthorize]
        public ActionResult QuenMatKhau() // hàm dùng để lấy lại mật khẩu khi người dùng quên
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[MPLIS.Web.FrameWork.Authentication.CustomAuthorize]
        public ActionResult QuenMatKhau(FormCollection ketNoiForm) // hàm dùng để lấy lại mật khẩu khi người dùng quên
        {
            string thongBaoQuenMatKhau;
            // Lay thong tin tu form sang controller
            string sHoVaTen = ketNoiForm["TxtHoVaTen"].Trim();
            string sTenDangNhap = ketNoiForm["TxtTenDangNhap"].Trim();
            string sEmailDangKy = ketNoiForm["TxtEmailDangKy"].Trim();

            BSUserInfor ui = (BSUserInfor)Session["BSUserInfor"];
            HT_NGUOIDUNG nguoiDung = AutoMapper.Mapper.Map<SSOHtNguoiDung, HT_NGUOIDUNG>(ui.UserInfo.User);
            if (nguoiDung == null)
            {
                thongBaoQuenMatKhau = "Tên đăng nhập không tồn tại !";
            }
            else
            {
                if (string.IsNullOrEmpty(nguoiDung.EMAIL))
                {
                    thongBaoQuenMatKhau = "Bạn chưa đăng ký email với hệ thống ! Vui lòng liên hệ với Admin";
                }
                else
                {
                    if (nguoiDung.EMAIL.ToUpper().Trim() != sEmailDangKy.ToUpper().Trim())
                    {
                        thongBaoQuenMatKhau = "Email đăng ký không đúng !";
                    }
                    else
                    {
                        EmailService service = new EmailService();

                        string sMatKhauMoi = service.RandomString(6, true);
                        string smtpUserName = "haininh@live.com";
                        string smtpPassword = "H@iNinh1986";
                        string smtpHost = "smtp.live.com";
                        int smtpPort = 25; // hoac 465 (port cua smtp.live.com)

                        string emailTo = sEmailDangKy.Trim(); // mail dang ky trong he thong - de lay lai mat khau
                        string subject = "Lấy lại mật khẩu đăng nhập hệ thống MPLIS";
                        string body = string.Format("Xin chào bạn: <b>{0}</b><br/>Mật khẩu mới của bạn được gửi từ : {1}<br/>Mật khẩu mới là: </br>{2}", sHoVaTen, "Quản trị hệ thống MPLIS", sMatKhauMoi);

                        bool kq = service.Send(smtpUserName, smtpPassword, smtpHost, smtpPort,
                            emailTo, subject, body);

                        if (kq)
                        {
                            // mã hóa password
                            var sha = SHA256.Create();
                            var computedHash = sha.ComputeHash(Encoding.Unicode.GetBytes(sMatKhauMoi));
                            sMatKhauMoi = Convert.ToBase64String(computedHash).ToString();

                            // cap nhat mat khau moi vao co so du lieu
                            nguoiDung.MATKHAU = sMatKhauMoi;
                            nguoiDung.PHAITHAYDOIMATKHAU = "1";

                            //UpdateModel(nguoiDung);
                            coSoDuLieuMplis.Entry(nguoiDung).State = System.Data.Entity.EntityState.Modified;
                            coSoDuLieuMplis.SaveChanges();

                            thongBaoQuenMatKhau = "Mật khẩu mới đã được gửi vào mail đăng ký ! Vui lòng truy cập vào mail để xem mật khẩu";
                        }
                        else
                        {
                            thongBaoQuenMatKhau = "Yêu cầu lấy lại mật khẩu đã thất bại !";
                        }
                    }
                }
            }
            ViewBag.ThongBaoQuenMatKhau = thongBaoQuenMatKhau;

            return View();
        }

        //[Authorize]
        public ActionResult DoiMatKhauKhiDangNhap() // đổi mật khẩu khi đăng nhập lần đầu
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoiMatKhauKhiDangNhap(FormCollection ketNoiForm) // đổi mật khẩu khi đăng nhập lần đầu
        {
            // Lay thong tin tu form sang controller
            string sMatKhauHienTai = ketNoiForm["TxtMatKhauHienTai"];
            string sMatKhauMoi = ketNoiForm["TxtMatKhauMoi"];
            string sXacNhanMatKhau = ketNoiForm["TxtXacNhanMatKhau"];
            string thongBaoDoiMatKhau = "", thongBao = "";

            // mã hóa password
            var sha = SHA256.Create();
            var computedHash = sha.ComputeHash(Encoding.Unicode.GetBytes(sMatKhauHienTai));
            sMatKhauHienTai = Convert.ToBase64String(computedHash).ToString();
            if (string.IsNullOrEmpty(CurrentUser.ID))
            {
                thongBaoDoiMatKhau = "Không xác định được người dùng cần đổi mật khẩu !";
            }
            else
            {
                BSUserInfor ui = (BSUserInfor)Session["BSUserInfor"];
                HT_NGUOIDUNG nguoiDung = AutoMapper.Mapper.Map<SSOHtNguoiDung, HT_NGUOIDUNG>(ui.UserInfo.User);
                if (nguoiDung.MATKHAU != sMatKhauHienTai)
                {
                    thongBaoDoiMatKhau = "Nhập sai mật khẩu hiện tại !";
                }
                else
                {
                    // Doi mat khau
                    computedHash = sha.ComputeHash(Encoding.Unicode.GetBytes(sMatKhauMoi.Trim()));
                    sMatKhauMoi = Convert.ToBase64String(computedHash).ToString();
                    nguoiDung.MATKHAU = sMatKhauMoi;
                    nguoiDung.PHAITHAYDOIMATKHAU = "0";

                    //UpdateModel(nguoiDung);
                    coSoDuLieuMplis.Entry(nguoiDung).State = System.Data.Entity.EntityState.Modified;
                    coSoDuLieuMplis.SaveChanges();

                    thongBao = "Đổi mật khẩu thành công. Hãy đăng nhập bằng mật khẩu mới !";
                    return RedirectToAction("Logout", "Home");
                }
            }
            ViewBag.TB = thongBao;
            ViewBag.thongBaoDoiMatKhau = thongBaoDoiMatKhau;
            return View();
        }

        //[Authorize]
        public ActionResult Index()
        {
            BSUserInfor ui = (BSUserInfor)Session["BSUserInfor"];
            SSOHtUngDung ud;
            string TenUD, ThuTuUD, KTUD;
            string maUngDungQuanTriHeThong = "QTH";
            // Hien thi danh sach ung dung trang index
            foreach (DictionaryEntry item7 in ui.UserInfo.AllUngDung)
            {
                ud = (SSOHtUngDung)item7.Value;
                string thuTuSapXepDeHienThi = ud.THUTUSAPXEP;
                TenUD = "TenUngDung" + ud.THUTUSAPXEP;
                ThuTuUD = "ThuTuUngDung" + ud.THUTUSAPXEP;
                ViewData[TenUD] = ud.TENUNGDUNG;
                ViewData[ThuTuUD] = ud.THUTUSAPXEP;
            }
            // Kiem tra ung dung duoc phep truy cap cua nguoi dung
            // Lay danh sach ung dung duoc phep truy cap cua nguoi dung   
            var ungDungNguoiDungs = ui.UserInfo.DSUngDung.Values.Cast<SSOHtUngDung>().OrderBy(i => i.THUTUSAPXEP).ToList();

            foreach (var item6 in ungDungNguoiDungs)
            {
                string thuTuSapXep = item6.THUTUSAPXEP;
                KTUD = "KiemTraUngDung" + thuTuSapXep;
                ThuTuUD = "LinkUngDung" + thuTuSapXep;
                if (item6.MAUNGDUNG == maUngDungQuanTriHeThong)
                {
                    if (ui.UserInfo.User.LOAINGUOIDUNG == 1 || ui.UserInfo.User.LOAINGUOIDUNG == 2)
                    {
                        ViewData[ThuTuUD] = item6.URL + "?ungDung=" + item6.UNGDUNGID;
                        ViewData[KTUD] = "co";
                    }
                    else
                    {
                        ViewData[KTUD] = "QuanTriHeThongDuocTruyCap";
                    }
                }
                else
                {
                    if (ui.UserInfo.User.LOAINGUOIDUNG == 1 || ui.UserInfo.User.LOAINGUOIDUNG == 2)
                    {
                        ViewData[KTUD] = "QuanTriHeThongKhongTruyCap";
                    }
                    else
                    {
                        ViewData[ThuTuUD] = item6.URL + "?ungDung=" + item6.UNGDUNGID;
                        ViewData[KTUD] = "co";
                    }
                }
            }
            HttpContext.Session["user_esri"] = "user_1";
            HttpContext.Session["pass_esri"] = "12345a@";
            // lay thong tin va Anh dai dien, ten nguoi dung, ... cua nguoi dung
            if (!string.IsNullOrEmpty(Convert.ToString(ui.UserInfo.User.ANHBIEUTUONG)))
            {
                ViewBag.AnhBieuTuong = "data:image/png;base64," + Convert.ToBase64String(ui.UserInfo.User.ANHBIEUTUONG);
            }
            else
            {
                if (ui.UserInfo.User.GIOITINH == "1")
                {
                    ViewBag.AnhBieuTuong = "/Images/AnhDaiDienMacDinh/AnhDaiDienNam.jpg";
                }
                else
                {
                    ViewBag.AnhBieuTuong = "/Images/AnhDaiDienMacDinh/AnhDaiDienNu.jpg";
                }
            }
            ViewBag.tenguoidung = ui.UserInfo.User.HOTENNGUOIDUNG;

            return View();
        }

        [MPLISAuthorize]
        public ActionResult Home(string ungDung)
        {
            if (ungDung != null)
            {
                BSUserInfor ui = (BSUserInfor)Session["BSUserInfor"];
                ui.CurUngDung = ungDung;
                Session["BSUserInfor"] = ui;
            }

            return View();
        }

        public ActionResult DinhTuyen(string ungDung)
        {
            if (ungDung != null)
            {
                BSUserInfor ui = (BSUserInfor)Session["BSUserInfor"];
                ui.CurUngDung = ungDung;
                Session["BSUserInfor"] = ui;
            }

            return View("Home");
        }

        // ham DichVuCong tam thoi khong dung den
        public ActionResult DichVuCong(string ungDung)
        {
            int soLuongUngDung = 0;
            string urlDichVuCong = "/Home/ThongBaoQuyenNguoiDung";
            BSUserInfor ui = (BSUserInfor)Session["BSUserInfor"];
            var ungDungNguoiDungs = ui.UserInfo.DSUngDung.Values.Cast<HT_UNGDUNG>().ToList();
            foreach (var itemUngDungNguoiDung in ungDungNguoiDungs)
            {
                switch (itemUngDungNguoiDung.MAUNGDUNG)
                {
                    case "DV1":
                        urlDichVuCong = itemUngDungNguoiDung.URL;
                        soLuongUngDung = soLuongUngDung + 1;
                        break;
                    case "DV2":
                        urlDichVuCong = itemUngDungNguoiDung.URL;
                        soLuongUngDung = soLuongUngDung + 1;
                        break;
                    case "DV3":
                        urlDichVuCong = itemUngDungNguoiDung.URL;
                        soLuongUngDung = soLuongUngDung + 1;
                        break;
                    case "DVW":
                        urlDichVuCong = itemUngDungNguoiDung.URL;
                        soLuongUngDung = soLuongUngDung + 1;
                        break;
                    default:
                        break;
                }
            }

            if (soLuongUngDung > 1)
            {
                urlDichVuCong = "/Home/Home?UngDung=" + ungDung;
            }

            return Redirect(urlDichVuCong);
        }

        #region Đổi mật khẩu mới
        public ActionResult ThayDoiMatKhau(string matKhauHienTai, string matKhauMoi, string xacNhanMatKhau)
        {
            if (Request.IsAjaxRequest())
            {
                string thongBaoThayDoiMatKhau = "";
                if (string.IsNullOrEmpty(matKhauHienTai) || string.IsNullOrEmpty(matKhauMoi) || string.IsNullOrEmpty(xacNhanMatKhau))
                {
                    thongBaoThayDoiMatKhau = "Không để trống các ô nhập mật khẩu !";
                }
                else
                {
                    if (matKhauMoi != xacNhanMatKhau)
                    {
                        thongBaoThayDoiMatKhau = "Nhập xác nhận mật khẩu sai !";
                    }
                    else
                    {
                        if (matKhauMoi == matKhauHienTai)
                        {
                            thongBaoThayDoiMatKhau = "Không nhập mật khẩu mới trùng với mật khẩu hiện tại !";
                        }
                        else
                        {
                            // mã hóa password
                            var sha = SHA256.Create();
                            var computedHash = sha.ComputeHash(Encoding.Unicode.GetBytes(matKhauHienTai));

                            var chuoiMatKhauHienTai = Convert.ToBase64String(computedHash).ToString();
                            BSUserInfor ui = (BSUserInfor)Session["BSUserInfor"];
                            HT_NGUOIDUNG nguoiDung = AutoMapper.Mapper.Map<SSOHtNguoiDung, HT_NGUOIDUNG>(ui.UserInfo.User);
                            if (nguoiDung.MATKHAU != chuoiMatKhauHienTai)
                            {
                                thongBaoThayDoiMatKhau = "Nhập sai mật khẩu hiện tại !";
                            }
                            else
                            {
                                // Doi mat khau
                                computedHash = sha.ComputeHash(Encoding.Unicode.GetBytes(matKhauMoi));
                                var chuoiMatKhauMoi = Convert.ToBase64String(computedHash).ToString();
                                nguoiDung.MATKHAU = chuoiMatKhauMoi;

                                coSoDuLieuMplis.Entry(nguoiDung).State = System.Data.Entity.EntityState.Modified;
                                coSoDuLieuMplis.SaveChanges();
                                ui.UserInfo.User = AutoMapper.Mapper.Map<HT_NGUOIDUNG, SSOHtNguoiDung>(nguoiDung);
                                Session["BSUserInfor"] = ui;

                                thongBaoThayDoiMatKhau = "Đổi mật khẩu thành công !";
                            }
                        }
                    }
                }
                return Json(thongBaoThayDoiMatKhau, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
        }
        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        [MPLIS.Web.FrameWork.Authentication.MPLISAuthorize]
        public ActionResult DoiMatKhau(FormCollection ketNoiForm)
        {
            // Lay thong tin tu form sang controller
            string sMatKhauHienTai = ketNoiForm["txtMatKhauHienTai"];
            string sUrl = ketNoiForm["txtDuongDanUrl"];
            string sMatKhauMoi = ketNoiForm["txtMatKhauMoi"];
            string sXacNhanMatKhau = ketNoiForm["txtXacNhanMatKhau"];
            string thongBaoDoiMatKhau = "";

            // mã hóa password
            var sha = SHA256.Create();
            var computedHash = sha.ComputeHash(Encoding.Unicode.GetBytes(sMatKhauHienTai));
            sMatKhauHienTai = Convert.ToBase64String(computedHash).ToString();

            BSUserInfor ui = (BSUserInfor)Session["BSUserInfor"];
            HT_NGUOIDUNG nguoiDung = AutoMapper.Mapper.Map<SSOHtNguoiDung, HT_NGUOIDUNG>(ui.UserInfo.User);
            if (nguoiDung.MATKHAU != sMatKhauHienTai)
            {
                thongBaoDoiMatKhau = "Nhập sai mật khẩu hiện tại !";
            }
            else
            {
                // Doi mat khau
                computedHash = sha.ComputeHash(Encoding.Unicode.GetBytes(sMatKhauMoi.Trim()));
                sMatKhauMoi = Convert.ToBase64String(computedHash).ToString();
                nguoiDung.MATKHAU = sMatKhauMoi;

                coSoDuLieuMplis.Entry(nguoiDung).State = System.Data.Entity.EntityState.Modified;
                coSoDuLieuMplis.SaveChanges();
                ui.UserInfo.User = AutoMapper.Mapper.Map<HT_NGUOIDUNG, SSOHtNguoiDung>(nguoiDung);
                Session["BSUserInfor"] = ui;
                thongBaoDoiMatKhau = "Đổi mật khẩu thành công !";
            }

            thongBaoDoiMatKhau = "";

            return Json(thongBaoDoiMatKhau, "application/json", Encoding.UTF8);
        }

        public ActionResult ThayDoiThongTinNguoiDung()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThayDoiThongTinNguoiDung(FormCollection ketNoiForm, HttpPostedFileBase anhDaiDien)
        {
            // Lay thong tin tu form sang controller
            string sDuongDanUrl = ketNoiForm["txtUrlThayDoiThongTinNguoiDung"];
            string sNguoiDungID = ketNoiForm["txtNguoiDungID"];
            string sDiaChi = ketNoiForm["txtDiaChi"];
            string sSoDienThoai = ketNoiForm["txtSoDienThoai"];
            string sSoDienThoai2 = ketNoiForm["txtSoDienThoai2"];
            //string sChucVu = ketNoiForm["txtChucVu"];
            string sMoTa = ketNoiForm["txtMoTa"];

            BSUserInfor ui = (BSUserInfor)Session["BSUserInfor"];
            HT_NGUOIDUNG nguoiDung = AutoMapper.Mapper.Map<SSOHtNguoiDung, HT_NGUOIDUNG>(ui.UserInfo.User);
            nguoiDung.DIACHI = sDiaChi;
            nguoiDung.SODIENTHOAI = sSoDienThoai;
            nguoiDung.SODIENTHOAI2 = sSoDienThoai2;
            //nguoiDung.CHUCVU = sChucVu;
            nguoiDung.MOTA = sMoTa;

            if (anhDaiDien != null && anhDaiDien.ContentLength > 0)
            {
                using (var binaryReader = new BinaryReader(anhDaiDien.InputStream))
                {
                    nguoiDung.ANHBIEUTUONG = binaryReader.ReadBytes(anhDaiDien.ContentLength);
                }
            }

            coSoDuLieuMplis.Entry(nguoiDung).State = System.Data.Entity.EntityState.Modified;
            coSoDuLieuMplis.SaveChanges();
            ui.UserInfo.User = AutoMapper.Mapper.Map<HT_NGUOIDUNG, SSOHtNguoiDung>(nguoiDung);
            Session["BSUserInfor"] = ui;

            if (!string.IsNullOrEmpty(sDuongDanUrl))
            {
                return Redirect(sDuongDanUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult genChonDonViHanhChinh()
        {
            BSUserInfor ui = (BSUserInfor)Session["BSUserInfor"];

            if (ui != null && ui.UserInfo != null)
            {
                ViewBag.XaNguoiDung = SSOUtility.LayXaNguoiDung(ui.UserInfo);
                ViewBag.HuyenNguoiDung = SSOUtility.LayHuyenNguoiDung(ui.UserInfo);
                HC_DMKVHC xa = CurXa;
                ViewBag.XAID = xa == null ? "" : xa.KVHCID;
                HC_HUYEN huyen = CurHuyen;
                ViewBag.HUYENID = huyen == null ? "" : huyen.HUYENID;
                ViewBag.LOAINGUOIDUNG = CurrentUser.LOAINGUOIDUNG;
            }

            return PartialView();
        }

        public ActionResult chonDVHC(string curURL, string HUYENID, string XAID)
        {
            if (!string.IsNullOrEmpty(XAID))
            {
                BSUserInfor ui = (BSUserInfor)Session["BSUserInfor"];
                ui.UserInfo.User.DONVIHANHCHINHID = XAID;
                Session["BSUserInfor"] = ui;
                using (MplisEntities db = new MplisEntities())
                {
                    HT_NGUOIDUNG user = AutoMapper.Mapper.Map<SSOHtNguoiDung, HT_NGUOIDUNG>(ui.UserInfo.User);
                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return Redirect(curURL);
        }

        public ActionResult _MainFooter()
        {
            string ten = (CurHuyen == null ? "" : CurHuyen.TENHUYEN + " - ") + (CurXa == null ? "" : CurXa.TENKVHC);

            return PartialView("_MainFooter", ten);
        }

        public ActionResult GenerateAnhDaiDien()
        {
            BSUserInfor ui = (BSUserInfor)Session["BSUserInfor"];
            //string html = SSOUtility.GenerateAnhDaiDien(ui.UserInfo);

            return PartialView("_GenerateAnhDaiDien", ui.UserInfo);
        }

        public ActionResult GenerateDoiMatKhau()
        {
            //string html = SSOUtility.GenerateDoiMatKhau("khong", "");
            return PartialView("_GenerateDoiMatKhau", "");
        }

        public ActionResult GenerateThongTinCaNhan()
        {
            BSUserInfor ui = (BSUserInfor)Session["BSUserInfor"];
            //string html = SSOUtility.GenerateThongTinCaNhan(ui.UserInfo);

            return PartialView("_GenerateThongTinCaNhan", ui.UserInfo);
        }

        public ActionResult GenerateMenu()
        {
            BSUserInfor ui = (BSUserInfor)Session["BSUserInfor"];
            string strMenuTree = SSOUtility.CreateHtmlMenuTree(ui.UserInfo, ui.CurUngDung);

            return PartialView("_GenerateMenu", strMenuTree);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return PartialView();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return PartialView();
        }
    }
}