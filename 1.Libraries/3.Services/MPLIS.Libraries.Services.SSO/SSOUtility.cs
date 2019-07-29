using AutoMapper;
using MPLIS.Libraries.Data.QTHT.Models;
using MPLIS.Libraries.Data.SSO.Interfaces;
using MPLIS.Libraries.Data.SSO.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Services.SSO
{
    public static class SSOUtility
    {
        #region "Tạo cây menu"
        public static string CreateHtmlMenuTree(SSOUserLoginInfors info, string UngDungId)
        {
            string ret = "";

            if (info != null)
            {
                //bắt đầu mở thẻ ul
                ret = ret + "<section class='sidebar'>";
                ret = ret + "<ul class='sidebar-menu' data-widget='tree'>";

                if (UngDungId.Trim().Equals(""))
                    ret = ret + CreateAllMenuTree(info);
                else
                    ret = ret + CreateMenuTreeByUngDung(info, UngDungId);

                //thêm tên xã
                //ret = ret + "<li class='header'>";
                string tenDVHCGhep = "";
                if (info.User.DONVIHANHCHINHID != null)
                {
                    tenDVHCGhep = LayTenXaHuyen(info, info.User.DONVIHANHCHINHID);
                }
                ret = ret + "<p class='dvhc_' style='color:blue;font-size:14px;white-space:normal;'>" + tenDVHCGhep + "</p>";
                //ret = ret + "</li>";

                //đóng thẻ ul
                ret = ret + "</ul>";
                ret = ret + "</section>";
            }

            return ret;
        }

        private static string LayTenXaHuyen(SSOUserLoginInfors ui, string XaID)
        {
            string ret = "Hãy chọn đơn vị hành chính";

            if (XaID != null)
            {
                if (ui.ToChucKVHC.Contains(XaID))
                {
                    IDMKVHC kvhc = (IDMKVHC)ui.ToChucKVHC[XaID];
                    if (kvhc.MAKVHC != null && kvhc.MAKVHC.Length == 10)
                    {
                        SSOHcXa xa = (SSOHcXa)ui.ToChucKVHC[XaID];
                        SSOHcHuyen huyen = (SSOHcHuyen)ui.ToChucKVHC[xa.HUYENID];
                        ret = huyen.TENHUYEN + " <br> " + xa.TENKVHC;
                    }
                }
            }

            return ret;
        }

        private static string CreateAllMenuTree(SSOUserLoginInfors info)
        {
            string ret = "";
            int stt;

            foreach (DictionaryEntry it in info.ToChucMenu)
            {
                stt = 0;
                //Bắt đầu tạo cây menu
                List<SSOHtMenu> dsMenu = (List<SSOHtMenu>)it.Value;
                ret = ret + createChildNode(dsMenu, 2, ref stt);
            }

            return ret;
        }

        private static string CreateMenuTreeByUngDung(SSOUserLoginInfors info, string UngDungId)
        {
            string ret = "";
            int stt = 0, numChild = 0, baseLenth = 0;
            SSOHtUngDung ud;

            if (info.DSUngDung.Contains(UngDungId))
            {
                ud = (SSOHtUngDung)info.DSUngDung[UngDungId];

                //Thêm dòng tiêu đề cho cây menu
                ret = "<p class='dvhc_' id='UngDungDuocChon' ThuTuXapSep='" + ud.THUTUSAPXEP + "' style='font-size:14px; color:blue; "
                    + "white-space:normal; font-weight:bold; border-bottom: 1px solid #f4f4f4;'>" + ud.TENUNGDUNG + "</p>";

                //Bắt đầu tạo cây menu
                List<SSOHtMenu> dsMenu = (List<SSOHtMenu>)info.ToChucMenu[UngDungId];
                //kiểm tra con
                if (dsMenu != null && dsMenu.Count > 0)
                {
                    baseLenth = dsMenu[0].MAMENU == null ? 2 : dsMenu[0].MAMENU.Length;
                    if (coCon(dsMenu, baseLenth, 0))
                    {
                        for (int i = 0; i < dsMenu.Count; i++)
                        {
                            if (dsMenu[i].MAMENU.Length == 2)
                                if (coCon(dsMenu, 2, i))
                                    numChild += 1;
                        }
                    }

                    if (numChild == 1)
                    {
                        stt += 1;
                        ret = ret + createChildNode(dsMenu, dsMenu[stt].MAMENU.Length, ref stt);
                    }
                    else
                        ret = ret + createChildNode(dsMenu, dsMenu[0].MAMENU == null ? 2 : dsMenu[0].MAMENU.Length, ref stt);
                }
            }

            return ret;
        }

        private static string createChildNode(List<SSOHtMenu> dsMenu, int length, ref int stt)
        {
            string ret = "";
            while (stt < dsMenu.Count)
            {
                if (dsMenu[stt].MAMENU != null)
                    if (dsMenu[stt].MAMENU.Length == length)
                    {
                        if (coCon(dsMenu, length, stt))
                        {
                            ret = ret + "<li class='treeview'>";
                            ret = ret + "<a class='MenuMauBanhMyId' menuId='" + dsMenu[stt].MENUID + "' khoaChaId='" + dsMenu[stt].KHOACHAID + "' href = '" + dsMenu[stt].URL + "?idmenu=" + dsMenu[stt].MENUID + "' style='white-space:normal;'><span> " + dsMenu[stt].TENMENU + " </span><i class='fa fa-angle-left pull-right'></i></a>";
                        }
                        else
                        {
                            ret = ret + "<li>";
                            ret = ret + "<a class='MenuMauBanhMyId mplis_menu' menuId='" + dsMenu[stt].MENUID + "' khoaChaId='" + dsMenu[stt].KHOACHAID + "' href = '" + dsMenu[stt].URL + "?idmenu=" + dsMenu[stt].MENUID + "' style='white-space:normal;'> " + dsMenu[stt].TENMENU + "</a>";
                            ret = ret + "</li>";
                        }
                    }
                    else if (dsMenu[stt].MAMENU.Length > length)
                    {
                        ret = ret + "<ul class='treeview-menu'>";
                        ret = ret + createChildNode(dsMenu, dsMenu[stt].MAMENU.Length, ref stt);
                        ret = ret + "</ul>";
                        continue;
                    }
                    else
                    {
                        ret = ret + "</li>";
                        break;
                    }

                stt += 1;
            }

            return ret;
        }

        private static bool coCon(List<SSOHtMenu> dsMenu, int length, int stt)
        {
            bool ret = false;

            if (stt < dsMenu.Count - 1)
            {
                if (dsMenu[stt + 1].MAMENU != null && length < dsMenu[stt + 1].MAMENU.Length) ret = true;
            }

            return ret;
        }
        #endregion

        #region "Tạo các form thông tin người dùng sau khi đăng nhập"
        // khoi tao cac form thong tin ca nhan cua nguoi dung dang nhap vao he thong
        public static string GenerateThongTinCaNhan(SSOUserLoginInfors ui)
        {
            string listThongTinCaNhan = "";
            string chucVuNguoiDangNhap = ui.ToChucNguoiDung.CHUCVU + " - " + ui.ToChuc.TENTOCHUC;
            // Gan gia tri cho form sua thong tin nguoi dung trong Trong phan thay doi thong tin nguoi dung
            DateTime thoiDiemMatKhauCoHieuLuc, thoiDiemMatKhauHetHieuLuc, thoiDiemHienTai;
            TimeSpan SoNgay;

            listThongTinCaNhan = listThongTinCaNhan + "@using (Html.BeginForm('ThayDoiThongTinNguoiDung', 'Home', new { area = '' }, FormMethod.Post, new { enctype = 'multipart/form-data' }))";
            listThongTinCaNhan = listThongTinCaNhan + "{";
            listThongTinCaNhan = listThongTinCaNhan + "@Html.AntiForgeryToken()";
            listThongTinCaNhan = listThongTinCaNhan + "<div class='modal fade' id='ThongTinCaNhan' role='dialog'>";
            listThongTinCaNhan = listThongTinCaNhan + "<div class='modal-dialog modal-body'>";
            listThongTinCaNhan = listThongTinCaNhan + "<div class='modal-content' style='width:146%;'>";
            listThongTinCaNhan = listThongTinCaNhan + "<div class='modal-header'>";
            listThongTinCaNhan = listThongTinCaNhan + "<button type='button' class='close' data-dismiss='modal'>&times;</button>";
            listThongTinCaNhan = listThongTinCaNhan + "<h4 class='modal-title'> Thông tin cá nhân</h4>";
            listThongTinCaNhan = listThongTinCaNhan + "</div>";

            listThongTinCaNhan = listThongTinCaNhan + "<table class='table' style='background:#f4f4f4;'>";
            listThongTinCaNhan = listThongTinCaNhan + "<tr>";
            listThongTinCaNhan = listThongTinCaNhan + "<td width = '16%'>";
            listThongTinCaNhan = listThongTinCaNhan + "<label class='text' style='text-align: left;'>Tên đăng nhập</label>";
            listThongTinCaNhan = listThongTinCaNhan + "</td>";
            listThongTinCaNhan = listThongTinCaNhan + "<td colspan = '4'>";
            switch (Convert.ToInt32(ui.User.LOAINGUOIDUNG))
            {
                case 1:
                    listThongTinCaNhan = listThongTinCaNhan + "<input type='text' class='form-control' id='txtTenDangNhap' disabled='disabled' value='" + ui.User.TENDANGNHAP + " - Giám sát hệ thống" + "'/>";
                    break;
                case 2:
                    listThongTinCaNhan = listThongTinCaNhan + "<input type='text' class='form-control' id='txtTenDangNhap' disabled='disabled' value='" + ui.User.TENDANGNHAP + " - Quản trị hệ thống" + "'/>";
                    break;
                case 3:
                    listThongTinCaNhan = listThongTinCaNhan + "<input type='text' class='form-control' id='txtTenDangNhap' disabled='disabled' value='" + ui.User.TENDANGNHAP + " - Người dùng tác nghiệp" + "'/>";
                    break;
                case 4:
                    listThongTinCaNhan = listThongTinCaNhan + "<input type='text' class='form-control' id='txtTenDangNhap' disabled='disabled' value='" + ui.User.TENDANGNHAP + " - Địa chính phường xã" + "'/>";
                    break;
                case 5:
                    listThongTinCaNhan = listThongTinCaNhan + "<input type='text' class='form-control' id='txtTenDangNhap' disabled='disabled' value='" + ui.User.TENDANGNHAP + " - Người dùng tra cứu" + "'/>";
                    break;
                default:
                    listThongTinCaNhan = listThongTinCaNhan + "<input type='text' class='form-control' id='txtTenDangNhap' disabled='disabled' value='" + ui.User.TENDANGNHAP + "'/>";
                    break;
            }
            listThongTinCaNhan = listThongTinCaNhan + "<input type = 'hidden' class='form-control' name='txtNguoiDungID' id='txtNguoiDungID' value='" + ui.User.NGUOIDUNGID + "'/>";
            listThongTinCaNhan = listThongTinCaNhan + "<input type = 'hidden' class='form-control' name='txtUrlThayDoiThongTinNguoiDung' id='txtUrlThayDoiThongTinNguoiDung' value=''/>";
            listThongTinCaNhan = listThongTinCaNhan + "</td>";
            listThongTinCaNhan = listThongTinCaNhan + "</tr>";
            listThongTinCaNhan = listThongTinCaNhan + "<tr>";
            listThongTinCaNhan = listThongTinCaNhan + "<td>";
            listThongTinCaNhan = listThongTinCaNhan + "<label class='text' style='text-align: left;'>Họ và tên</label>";
            listThongTinCaNhan = listThongTinCaNhan + "</td>";
            listThongTinCaNhan = listThongTinCaNhan + "<td colspan = '4'>";
            listThongTinCaNhan = listThongTinCaNhan + "<input type='text' class='form-control' id='txtHovaTen' disabled='disabled' value='" + ui.User.HOTENNGUOIDUNG + "'/>";
            listThongTinCaNhan = listThongTinCaNhan + "</td>";
            listThongTinCaNhan = listThongTinCaNhan + "</tr>";
            listThongTinCaNhan = listThongTinCaNhan + "<tr>";
            listThongTinCaNhan = listThongTinCaNhan + "<td>";
            listThongTinCaNhan = listThongTinCaNhan + "<label class='text' style='text-align: left;'>Tham gia hệ thống</label>";
            listThongTinCaNhan = listThongTinCaNhan + "</td>";
            listThongTinCaNhan = listThongTinCaNhan + "<td>";
            listThongTinCaNhan = listThongTinCaNhan + "<input type = 'text' class='form-control' id='txtMatKhau' disabled='disabled' value='" + "ngày "
                + Convert.ToDateTime(ui.User.THOIDIEMMATKHAUCOHIEULUC).Day.ToString() + " - "
                + Convert.ToDateTime(ui.User.THOIDIEMMATKHAUCOHIEULUC).Month.ToString() + " - "
                + Convert.ToDateTime(ui.User.THOIDIEMMATKHAUCOHIEULUC).Year.ToString() + "'/>";
            listThongTinCaNhan = listThongTinCaNhan + "</td>";
            listThongTinCaNhan = listThongTinCaNhan + "<td colspan = '3'>";
            if (ui.User.THOIDIEMMATKHAUCOHIEULUC != null && ui.User.THOIDIEMMATKHAUHETHIEULUC != null)
            {
                thoiDiemHienTai = DateTime.Parse(DateTime.Now.ToString());
                thoiDiemMatKhauCoHieuLuc = DateTime.Parse(ui.User.THOIDIEMMATKHAUCOHIEULUC.ToString());
                thoiDiemMatKhauHetHieuLuc = DateTime.Parse(ui.User.THOIDIEMMATKHAUHETHIEULUC.ToString());
                SoNgay = thoiDiemMatKhauHetHieuLuc - thoiDiemHienTai;
                listThongTinCaNhan = listThongTinCaNhan + "<input type='text' class='form-control' id='txtTBMatKhau' disabled='disabled' value='Mật khẩu " + SoNgay.Days + " ngày còn hiệu lực'/>";
            }
            else
            {
                listThongTinCaNhan = listThongTinCaNhan + "<input type='text' class='form-control' id='txtTBMatKhau' disabled='disabled' value='Mật khẩu không xác định được ngày còn hiệu lực'/>";
            }
            listThongTinCaNhan = listThongTinCaNhan + "</td>";
            listThongTinCaNhan = listThongTinCaNhan + "</tr>";
            listThongTinCaNhan = listThongTinCaNhan + "<tr>";
            listThongTinCaNhan = listThongTinCaNhan + "<td>";
            listThongTinCaNhan = listThongTinCaNhan + "<label class='text' style='text-align: left;'>Cấp người dùng</label>";
            listThongTinCaNhan = listThongTinCaNhan + "</td>";
            listThongTinCaNhan = listThongTinCaNhan + "<td>";

            string capNguoiDung = ui.ToChuc.CAPTOCHUC.ToString();
            switch (capNguoiDung)
            {
                case "1":
                    listThongTinCaNhan = listThongTinCaNhan + "<input type = 'text' class='form-control' id='txtGioiTinh' disabled='disabled' value='Cấp trung ương'/>";
                    break;
                case "2":
                    listThongTinCaNhan = listThongTinCaNhan + "<input type = 'text' class='form-control' id='txtGioiTinh' disabled='disabled' value='Cấp tỉnh'/>";
                    break;
                case "3":
                    listThongTinCaNhan = listThongTinCaNhan + "<input type = 'text' class='form-control' id='txtGioiTinh' disabled='disabled' value='Cấp huyện'/>";
                    break;
                case "4":
                    listThongTinCaNhan = listThongTinCaNhan + "<input type = 'text' class='form-control' id='txtGioiTinh' disabled='disabled' value='Cấp Xã'/>";
                    break;
                default:
                    listThongTinCaNhan = listThongTinCaNhan + "<input type = 'text' class='form-control' id='txtGioiTinh' disabled='disabled' value='Không xác định'/>";
                    break;
            }
            listThongTinCaNhan = listThongTinCaNhan + "</td>";
            listThongTinCaNhan = listThongTinCaNhan + "<td>";
            listThongTinCaNhan = listThongTinCaNhan + "<label class='text'>Email</label>";
            listThongTinCaNhan = listThongTinCaNhan + "</td>";
            listThongTinCaNhan = listThongTinCaNhan + "<td>";
            listThongTinCaNhan = listThongTinCaNhan + "<input type = 'text' class='form-control' id='txtEmail' disabled='disabled' value='" + ui.User.EMAIL + "'/>";
            listThongTinCaNhan = listThongTinCaNhan + "</td>";
            listThongTinCaNhan = listThongTinCaNhan + "</tr>";
            listThongTinCaNhan = listThongTinCaNhan + "<tr>";
            listThongTinCaNhan = listThongTinCaNhan + "<td>";
            listThongTinCaNhan = listThongTinCaNhan + "<label class='text' style='text-align: left;'>Số điện thoại 1 </label>";
            listThongTinCaNhan = listThongTinCaNhan + "</td>";
            listThongTinCaNhan = listThongTinCaNhan + "<td>";
            listThongTinCaNhan = listThongTinCaNhan + "<input type = 'text' class='form-control' name='txtSoDienThoai' id='txtSoDienThoai' value='" + ui.User.SODIENTHOAI + "'/>";
            listThongTinCaNhan = listThongTinCaNhan + "</td>";
            listThongTinCaNhan = listThongTinCaNhan + "<td>";
            listThongTinCaNhan = listThongTinCaNhan + "<label class='text'>Địa chỉ</label>";
            listThongTinCaNhan = listThongTinCaNhan + "</td>";
            listThongTinCaNhan = listThongTinCaNhan + "<td>";
            listThongTinCaNhan = listThongTinCaNhan + "<input type= 'text' class='form-control' name='txtDiaChi' id='txtDiaChi' value='" + ui.User.DIACHI + "'>";
            listThongTinCaNhan = listThongTinCaNhan + "</td>";
            listThongTinCaNhan = listThongTinCaNhan + "</tr>";
            listThongTinCaNhan = listThongTinCaNhan + "<tr>";
            listThongTinCaNhan = listThongTinCaNhan + "<td>";
            listThongTinCaNhan = listThongTinCaNhan + "<label class='text' style='text-align: left;'>Chức vụ - Đơn vị</label>";
            listThongTinCaNhan = listThongTinCaNhan + "</td>";
            listThongTinCaNhan = listThongTinCaNhan + "<td colspan = '4'>";
            listThongTinCaNhan = listThongTinCaNhan + "<input type = 'text' disabled= 'disabled' class='form-control' name='txtChucVu' id='txtChucVu' value='" + chucVuNguoiDangNhap + "'>";
            listThongTinCaNhan = listThongTinCaNhan + "</td>";
            listThongTinCaNhan = listThongTinCaNhan + "</tr>";
            listThongTinCaNhan = listThongTinCaNhan + "<tr>";
            listThongTinCaNhan = listThongTinCaNhan + "<td>";
            listThongTinCaNhan = listThongTinCaNhan + "<label class='text' style='text-align: left;'>Số điện thoại 2</label>";
            listThongTinCaNhan = listThongTinCaNhan + "</td>";
            listThongTinCaNhan = listThongTinCaNhan + "<td>";
            listThongTinCaNhan = listThongTinCaNhan + "<input type = 'text' class='form-control' name='txtSoDienThoai2' id='txtSoDienThoai2' value='" + ui.User.SODIENTHOAI2 + "'>";
            listThongTinCaNhan = listThongTinCaNhan + "</td>";
            listThongTinCaNhan = listThongTinCaNhan + "<td rowspan = '2' style='display: table-cell;vertical-align: middle;'>";
            listThongTinCaNhan = listThongTinCaNhan + "<label class='text' style='text-align: left;'>Ảnh đại diện</label>";
            listThongTinCaNhan = listThongTinCaNhan + "</td>";
            listThongTinCaNhan = listThongTinCaNhan + "<td rowspan = '2' style='display:table-cell;vertical-align:middle;'>";
            listThongTinCaNhan = listThongTinCaNhan + "<table>";
            listThongTinCaNhan = listThongTinCaNhan + "<tr>";
            listThongTinCaNhan = listThongTinCaNhan + "<td width = '120%'>";
            if (!string.IsNullOrEmpty(Convert.ToString(ui.User.ANHBIEUTUONG)))
            {
                listThongTinCaNhan = listThongTinCaNhan + "<img id='file' src='" + "data: image / png; base64," + Convert.ToBase64String(ui.User.ANHBIEUTUONG) + "' width='80' height='90'/>";
            }
            else
            {
                listThongTinCaNhan = listThongTinCaNhan + "<img id='file' src='' width='80' height='90'/>";
            }
            listThongTinCaNhan = listThongTinCaNhan + "</td>";
            listThongTinCaNhan = listThongTinCaNhan + "<td width = '80%'>";
            listThongTinCaNhan = listThongTinCaNhan + "<input id='anhDaiDien' type='file' name='anhDaiDien' onchange='readURL(this);'>";
            listThongTinCaNhan = listThongTinCaNhan + "</td>";
            listThongTinCaNhan = listThongTinCaNhan + "</tr>";
            listThongTinCaNhan = listThongTinCaNhan + "</table>";
            listThongTinCaNhan = listThongTinCaNhan + "</td>";
            listThongTinCaNhan = listThongTinCaNhan + "</tr>";
            listThongTinCaNhan = listThongTinCaNhan + "<tr>";
            listThongTinCaNhan = listThongTinCaNhan + "<td style = 'display: table-cell;vertical-align: middle;'>";
            listThongTinCaNhan = listThongTinCaNhan + "<label class='text' style='text-align: left;'>Mô tả</label>";
            listThongTinCaNhan = listThongTinCaNhan + "</td>";
            listThongTinCaNhan = listThongTinCaNhan + "<td>";
            listThongTinCaNhan = listThongTinCaNhan + "<textarea class='form-control' name='txtMoTa' id='txtmota'>" + ui.User.MOTA + "</textarea>";
            listThongTinCaNhan = listThongTinCaNhan + "</td>";
            listThongTinCaNhan = listThongTinCaNhan + "</tr>";
            listThongTinCaNhan = listThongTinCaNhan + "</table>";

            listThongTinCaNhan = listThongTinCaNhan + "<div class='modal-footer'>";
            listThongTinCaNhan = listThongTinCaNhan + "<button type='submit' class='btn btn-primary'>Lưu</button>";
            listThongTinCaNhan = listThongTinCaNhan + "<button type='button' class='btn btn-default' data-dismiss='modal'>Thoát</button>";
            listThongTinCaNhan = listThongTinCaNhan + "</div>";
            listThongTinCaNhan = listThongTinCaNhan + "</div>";
            listThongTinCaNhan = listThongTinCaNhan + "</div>";
            listThongTinCaNhan = listThongTinCaNhan + "</div>";
            listThongTinCaNhan = listThongTinCaNhan + "}";

            return listThongTinCaNhan;
        }

        public static string GenerateAnhDaiDien(SSOUserLoginInfors ui)
        {
            if (ui == null || ui.User == null) return "";
            string anhDaiDienCuaNguoiDung = "";

            // genberate anh dai dien cua nguoi dung
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<a href = '#' class='dropdown-toggle' data-toggle='dropdown'>";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<!-- The user image in the navbar-->";
            if (!string.IsNullOrEmpty(Convert.ToString(ui.User.ANHBIEUTUONG)))
            {
                anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<img src = '" + "data:image/png;base64,"
                    + Convert.ToBase64String(ui.User.ANHBIEUTUONG) + "' class='user-image' alt='!'/>";
            }
            else
            {
                if (ui.User.GIOITINH == "1")
                {
                    anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<img src = '/Images/AnhDaiDienMacDinh/AnhDaiDienNam.jpg' class='user-image'/>";
                }
                else
                {
                    anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<img src = '/Images/AnhDaiDienMacDinh/AnhDaiDienNu.jpg' class='user-image' alt='!'/>";
                }
            }
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<!-- hidden-xs hides the username on small devices so only the image appears. -->";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<span>" + ui.User.HOTENNGUOIDUNG + "</span>";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "</a>";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<ul class='dropdown-menu'>";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<!-- The user image in the menu -->";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<li class='user-header' style='background-color:#C6DB9B;'>";
            if (!string.IsNullOrEmpty(Convert.ToString(ui.User.ANHBIEUTUONG)))
            {
                anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<img src = '" + "data:image/png;base64," + Convert.ToBase64String(ui.User.ANHBIEUTUONG)
                    + "' class='img-circle' alt='Chưa có ảnh đại diện !' data-toggle='modal' data-target='#ThongTinCaNhan'/>";
            }
            else
            {
                if (ui.User.GIOITINH == "1")
                {
                    anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<img src = '/Images/AnhDaiDienMacDinh/AnhDaiDienNam.jpg' class='img-circle' alt='Chưa có ảnh đại diện !' data-toggle='modal' data-target='#ThongTinCaNhan'/>";
                }
                else
                {
                    anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<img src = '/Images/AnhDaiDienMacDinh/AnhDaiDienNu.jpg' class='img-circle' alt='Chưa có ảnh đại diện !' data-toggle='modal' data-target='#ThongTinCaNhan'/>";
                }
            }
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<p>";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<a href = '#' class='link' data-toggle='modal' data-target='#ThongTinCaNhan'>" + ui.User.HOTENNGUOIDUNG + "</a>";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<small>" + ui.User.TENDANGNHAP + " : tên đăng nhập hệ thống</small>";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "</p>";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "</li>";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<!-- Menu Body -->";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<!-- Menu Footer-->";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<li class='user-footer' style='width:120%;'>";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<div class='pull-left'>";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<a href = '#' class='btn btn-default'>Cấu hình</a>";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "</div>";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "&nbsp;";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<div class='pull-left'>";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<button type = 'button' class='btn btn-default' data-toggle='modal' data-target='#DoiMatKhau' id='doimkbt'>Đổi mật khẩu</button>";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<!--Hiển thi nội dung đổi mật khẩu-->";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<!--end-->";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "</div>";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "&nbsp;";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<div class='pull-left'>";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "<a href = '/Home/Logout' class='btn btn-default'>Đăng xuất</a>";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "</div>";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "</li>";
            anhDaiDienCuaNguoiDung = anhDaiDienCuaNguoiDung + "</ul>";
            // ket thuc generate anh dai dien
            return anhDaiDienCuaNguoiDung;
        }

        public static string GenerateDoiMatKhau(string batPopUpDoiMatKhau, string thongBaoDoiMatkhau)
        {
            string chuoiDoiMatKhau = "";

            chuoiDoiMatKhau = chuoiDoiMatKhau + "<div class='modal fade' id='DoiMatKhau' role='dialog'>";
            chuoiDoiMatKhau = chuoiDoiMatKhau + "<div class='modal-dialog modal-sm'>";
            chuoiDoiMatKhau = chuoiDoiMatKhau + "<div class='modal-content' style='width:auto;height:auto;'>";
            chuoiDoiMatKhau = chuoiDoiMatKhau + "<div class='modal-header'>";
            chuoiDoiMatKhau = chuoiDoiMatKhau + "<button type='button' class='close' data-dismiss='modal'>&times;</button>";
            chuoiDoiMatKhau = chuoiDoiMatKhau + "<h4 class='modal-title'>Thay đổi mật khẩu</h4>";
            chuoiDoiMatKhau = chuoiDoiMatKhau + "</div>";

            chuoiDoiMatKhau = chuoiDoiMatKhau + "<div class='row' style='width: 100 %;padding:0px;margin:0px;'>";

            chuoiDoiMatKhau = chuoiDoiMatKhau + "<div class='row' style='width:100%;padding:0px;margin:2px 0px 0px 0px;'>";
            chuoiDoiMatKhau = chuoiDoiMatKhau + "<div class='col-md-5' style='padding:0px;margin:0px;'><label class='text' style='text-align:left;'>Mật khẩu hiện tại</label></div>";
            chuoiDoiMatKhau = chuoiDoiMatKhau + "<div class='col-md-7' style='padding:0px;margin:0px;'><input type='password' class='text' name='txtMatKhauHienTai' id='txtMatKhauHienTai'/></div>";
            chuoiDoiMatKhau = chuoiDoiMatKhau + "</div>";

            chuoiDoiMatKhau = chuoiDoiMatKhau + "<div class='row' style='width:100%;padding:0px;margin:2px 0px 0px 0px;'>";
            chuoiDoiMatKhau = chuoiDoiMatKhau + "<div class='col-md-5' style='padding:0px;margin:0px;'><label class='text' style='text-align:left;'>Mật khẩu mới</label></div>";
            chuoiDoiMatKhau = chuoiDoiMatKhau + "<div class='col-md-7' style='padding:0px;margin:0px;'><input type='password' class='text' name='txtMatKhauMoi' id='txtMatKhauMoi'/></div>";
            chuoiDoiMatKhau = chuoiDoiMatKhau + "</div>";

            chuoiDoiMatKhau = chuoiDoiMatKhau + "<div class='row' style='width:100%;padding:0px;margin:2px 0px 0px 0px;'>";
            chuoiDoiMatKhau = chuoiDoiMatKhau + "<div class='col-md-5' style='padding:0px;margin:0px;'><label class='text' style='text-align:left;'>Xác nhận mật khẩu</label></div>";
            chuoiDoiMatKhau = chuoiDoiMatKhau + "<div class='col-md-7' style='padding:0px;margin:0px;'><input type='password' class='text' name='txtXacNhanMatKhau' id='txtXacNhanMatKhau'/></div>";
            chuoiDoiMatKhau = chuoiDoiMatKhau + "</div>";

            chuoiDoiMatKhau = chuoiDoiMatKhau + "<input type = 'hidden' class='text' name='txtDuongDanUrl' id='txtDuongDanUrl' value=''/>";
            chuoiDoiMatKhau = chuoiDoiMatKhau + "<input type = 'hidden' class='text' name='HienThiPopUp' id='HienThiPopUp' value='" + batPopUpDoiMatKhau + "'/>";

            chuoiDoiMatKhau = chuoiDoiMatKhau + "</div>";

            chuoiDoiMatKhau = chuoiDoiMatKhau + "<div class='modal-footer' style='text-align:center;'>";
            chuoiDoiMatKhau = chuoiDoiMatKhau + "<button type = 'submit' class='btn btn-primary' style='width:70px;height:30px;padding:0px;text-align:center;' onclick='ThayDoiMatKhau()'>Lưu</button>";
            chuoiDoiMatKhau = chuoiDoiMatKhau + "<button type = 'button' class='btn btn-default' style='width:70px;height:30px;padding:0px;text-align:center;' data-dismiss='modal'>Thoát</button>";
            chuoiDoiMatKhau = chuoiDoiMatKhau + "</div>";
            chuoiDoiMatKhau = chuoiDoiMatKhau + "<div class='modal-footer' style='text-align:center;'>";
            chuoiDoiMatKhau = chuoiDoiMatKhau + "<b style = 'color:red;'> " + thongBaoDoiMatkhau + " </b>";
            chuoiDoiMatKhau = chuoiDoiMatKhau + "</div>";
            chuoiDoiMatKhau = chuoiDoiMatKhau + "</div>";
            chuoiDoiMatKhau = chuoiDoiMatKhau + "</div>";
            chuoiDoiMatKhau = chuoiDoiMatKhau + "</div>";

            return chuoiDoiMatKhau;
        }
        #endregion

        #region "Các hàm dùng trong home controller"
        public static List<HuyenNguoiDung> LayHuyenNguoiDung(SSOUserLoginInfors ui)
        {
            List<HuyenNguoiDung> HuyenND = new List<HuyenNguoiDung>();
            HuyenNguoiDung huyen;

            if (ui != null)
            {
                //lấy huyện
                for (int i = 0; i < ui.NguoiDungHuyen.Count; i++)
                {
                    huyen = new HuyenNguoiDung();
                    huyen.HUYENID = ui.NguoiDungHuyen[i].HUYENID;
                    huyen.TENHUYEN = ui.NguoiDungHuyen[i].TENHUYEN;
                    HuyenND.Add(huyen);
                }
            }

            return HuyenND;
        }

        public static List<DVHCViewModel> LayXaNguoiDung(SSOUserLoginInfors ui)
        {
            List<DVHCViewModel> XaNguoiDung = new List<DVHCViewModel>();
            DVHCViewModel xa;
            SSOHcHuyen sHuyen;

            if (ui != null)
            {
                //lấy xã
                for (int i = 0; i < ui.NguoiDungXa.Count; i++)
                {
                    xa = new DVHCViewModel();
                    xa.MAXA = ui.NguoiDungXa[i].MAXA;
                    xa.TENXA = ui.NguoiDungXa[i].TENKVHC;
                    xa.XAID = ui.NguoiDungXa[i].KVHCID;
                    xa.HUYENID = ui.NguoiDungXa[i].HUYENID;
                    if (ui.ToChucKVHC.Contains(xa.HUYENID))
                    {
                        sHuyen = (SSOHcHuyen)ui.ToChucKVHC[xa.HUYENID];
                        xa.TENHUYEN = sHuyen.TENHUYEN;
                    }
                    XaNguoiDung.Add(xa);
                }
            }

            return XaNguoiDung;
        }
        #endregion
    }
}
