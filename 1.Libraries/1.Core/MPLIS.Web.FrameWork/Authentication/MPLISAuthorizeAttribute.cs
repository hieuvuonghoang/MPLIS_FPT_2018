//using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
//using Microsoft.AspNet.Identity;
using AppCore.Models;
using MPLIS.Libraries.Data.SSO.Models;

namespace MPLIS.Web.FrameWork.Authentication
{
    public class MPLISAuthorizeAttribute : AuthorizeAttribute
    {
        private bool _isAuthorized;
        private MplisEntities coSoDuLieuMplis = new MplisEntities();
        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            //_isAuthorized = base.AuthorizeCore(httpContext);
            _isAuthorized = httpContext.Session["BSUserInfor"] == null ? false : true;
            return _isAuthorized;
        }

        private CustomUser getCurrentUser(AuthorizationContext filterContext)
        {
            CustomUser currentUser = null;
            BSUserInfor ui = (BSUserInfor)filterContext.HttpContext.Session["BSUserInfor"];
            if (ui != null)
            {
                currentUser = new CustomUser();
                currentUser.ID = ui.UserInfo.User.NGUOIDUNGID;
                currentUser.UserName = ui.UserInfo.User.TENDANGNHAP;
                currentUser.HOTENNGUOIDUNG = ui.UserInfo.User.HOTENNGUOIDUNG;
                currentUser.GIOITINH = ui.UserInfo.User.GIOITINH;
                currentUser.SODIENTHOAI = ui.UserInfo.User.SODIENTHOAI;
                currentUser.SODIENTHOAI2 = ui.UserInfo.User.SODIENTHOAI2;
                currentUser.EMAIL = ui.UserInfo.User.EMAIL;
                currentUser.DIACHI = ui.UserInfo.User.DIACHI;
                currentUser.LOAINGUOIDUNG = ui.UserInfo.User.LOAINGUOIDUNG == null ? "" : ((decimal)ui.UserInfo.User.LOAINGUOIDUNG).ToString("N0");
                currentUser.CAPNGUOIDUNG = ui.UserInfo.User.CAPNGUOIDUNG;
                currentUser.MADONVIHANHCHINH = ui.UserInfo.ToChuc.DONVIHANHCHINHID;
                currentUser.CurKVHCID = ui.UserInfo.User.DONVIHANHCHINHID;
            }
            //if (filterContext.HttpContext.Session["BSUserInfor"] != null)
            //{
            //    currentUser = new CustomUser();
            //    //var claims = System.Security.Claims.ClaimsPrincipal.Current.Claims;
            //    currentUser.ID = ui.UserInfo.User.NGUOIDUNGID; //claims.Where(it => it.Type == System.Security.Claims.ClaimTypes.NameIdentifier).First().Value;
            //    currentUser.UserName = ui.UserInfo.User.TENDANGNHAP;//claims.Where(it => it.Type == System.Security.Claims.ClaimTypes.Name).First().Value;
            //    //currentUser.roles = claims.Where(it => it.Type == System.Security.Claims.ClaimTypes.Role).Select(it => it.Value).ToArray();
            //    //var _IsSuperAdmin = claims.Where(it => it.Type == MPLIS.Web.FrameWork.Authentication.ClaimTypes.IsSuperAdmin).FirstOrDefault();
            //    //currentUser.IsSuperAdmin = _IsSuperAdmin == null ? "" : _IsSuperAdmin.Value;
            //    //var _DonViId = claims.Where(it => it.Type == MPLIS.Web.FrameWork.Authentication.ClaimTypes.DonViId).FirstOrDefault();
            //    //currentUser.DonViId = (_DonViId == null || string.IsNullOrEmpty(_DonViId.Value)) ? null : (Guid?)Guid.Parse(_DonViId.Value);

            //    ////add new
            //    currentUser.LOAINGUOIDUNG = ui.UserInfo.User.LOAINGUOIDUNG ==null? "" : ui.UserInfo.User.LOAINGUOIDUNG.ToString();//claims.Where(it => it.Type == MPLIS.Web.FrameWork.Authentication.ClaimTypes.LOAINGUOIDUNG).First().Value;
            //    //currentUser.ListMenu = claims.Where(it => it.Type == MPLIS.Web.FrameWork.Authentication.ClaimTypes.ListMenu).First().Value;
            //    //currentUser.ForceSignOut = claims.Where(it => it.Type == MPLIS.Web.FrameWork.Authentication.ClaimTypes.ForceSignOut).First().Value;
            //    //currentUser.AllowLocalLogin = claims.Where(it => it.Type == MPLIS.Web.FrameWork.Authentication.ClaimTypes.AllowLocalLogin).First().Value;
            //    //currentUser.Activated = claims.Where(it => it.Type == MPLIS.Web.FrameWork.Authentication.ClaimTypes.Activated).First().Value;
            //    //currentUser.NeedChangePassword = claims.Where(it => it.Type == MPLIS.Web.FrameWork.Authentication.ClaimTypes.NeedChangePassword).First().Value;
            //}

            return currentUser;
        }
        #region // Ham luu quyen (luu ten controller va action vao database)
        //private void LuuQuyen(string controllerCanLuu, string actinonCanLuu, string idNguoiCapNhat)
        //{
        //    HT_QUYEN quyen = new HT_QUYEN();
        //    quyen.QUYENID = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
        //    quyen.CONTROLLERNAME = controllerCanLuu;
        //    quyen.ACTIONNAME = actinonCanLuu;
        //    quyen.NGUOICAPNHATID = idNguoiCapNhat;

        //    coSoDuLieuMplis.HT_QUYEN.Add(quyen);
        //    coSoDuLieuMplis.SaveChanges();
        //}
        #endregion
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            CustomUser currentUser;
            //base.OnAuthorization(filterContext);
            if (_isAuthorized)
            {
                currentUser = getCurrentUser(filterContext);

                UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
                
                //filterContext.Controller.ViewBag.roles = currentUser.roles;
                //IAuthenticationManager authenticationManager = filterContext.HttpContext.GetOwinContext().Authentication;

                //cần customize thêm để tránh việc liên tục truy cập vào db mỗi khi xác thực quyền
                //Lấy trực tiếp user từ thông tin đã lưu - Current user

                //if (currentUser == null)
                //{
                //    //Sign out
                //    authenticationManager.SignOut();
                //    filterContext.Result = new RedirectResult(urlHelper.Action("Login", "Home"));
                //    return;
                //}
                #region // luu cac action va controller vao bang HT_Quyen (neu quyen chua ton tai)
                //var actionName = Convert.ToString(filterContext.RouteData.Values["action"]);
                //var controollerName = Convert.ToString(filterContext.RouteData.Values["controller"]);
                //var quyens = (from q in this.coSoDuLieuMplis.HT_QUYEN
                //              where q.ACTIONNAME.ToLower() == actionName.ToLower()
                //              && q.CONTROLLERNAME.ToLower() == controollerName.ToLower()
                //              select q).ToList();
                //if (quyens.Count == 0)
                //{
                //    LuuQuyen(controollerName, actionName, currentUser.ID);
                //}
                #endregion
                //filterContext.Controller.ViewBag.isAdmin = (currentUser.IsSuperAdmin == "Y");
                //Check roles
                var currRoleName = string.Format("{0}_{1}", filterContext.RouteData.Values["controller"], filterContext.RouteData.Values["action"]).ToLower();
                if (!currentUser.roles.Contains(currRoleName))
                {
                    //if (currentUser.IsSuperAdmin != "Y")
                    //{
                    //filterContext.Result = new ContentResult() { Content = "Bạn chưa được phân quyền cho chức năng này!" };
                    //filterContext.HttpContext.Response.StatusCode = 403;
                    if (currentUser.LOAINGUOIDUNG != "1")
                    {
                        filterContext.Result = new ContentResult() { Content = "<h2>Tài khoản không được phép truy cập vào mục này. Vui lòng liên hệ với Quản trị hệ thống để được cấp phép, hoặc Đăng nhập bằng tài khoản khác !</h2> <br /> <a href = '/Home/Logout'> Quay lại trang login </a> <br /> <a href = '/Home/Index'> Quay lại trang trang chủ </a>" };
                        filterContext.HttpContext.Response.StatusCode = 403;
                        //filterContext.HttpContext.Response.Redirect("/Home/ThongBaoQuyenNguoiDung");
                        //urlHelper.Action("Index", "Error", )
                    }
                    //}
                    //filterContext.Result = new RedirectResult(urlHelper.Action("Login", "Account", new { msg = "Bạn chưa được phân quyền cho chức năng này!" }));
                }
                //using (var _roleManager = new RoleManager<ROLE>(new RoleStore<ROLE>(new MPLIS_Data_Admin_Context())))
                //{
                //    if (!roles.Contains(currRoleName))
                //    {
                //        if (currentUser.IsSuperAdmin != "Y")
                //        {
                //            filterContext.Result = new ContentResult() { Content = "Bạn chưa được phân quyền cho chức năng này!" };
                //            filterContext.HttpContext.Response.StatusCode = 403;
                //        }
                //        //filterContext.Result = new RedirectResult(urlHelper.Action("Login", "Account", new { msg = "Bạn chưa được phân quyền cho chức năng này!" }));
                //    }
                //    ////Init Role
                //    //if (!_roleManager.RoleExists<ROLE, string>(currRoleName))
                //    //{
                //    //    var role = new ROLE(currRoleName); ;
                //    //    _roleManager.Create<ROLE, string>(role);
                //    //}
                //}

                //Check isactive or needchangepassword
                //if (currentUser.AllowLocalLogin == "Y")
                //    if ((currentUser.Activated != "Y") || (currentUser.NeedChangePassword == "Y"))
                //    {
                //        filterContext.Result = new RedirectResult(urlHelper.Action("ChangePasswordConfirmation", "Account"));
                //    }
                //if (currentUser.ForceSignOut == "Y")
                //{
                //    authenticationManager.SignOut();
                //    filterContext.Result = new RedirectResult(urlHelper.Action("Login", "Account"));
                //}

            }
        }
    }
}