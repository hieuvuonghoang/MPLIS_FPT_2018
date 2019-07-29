using MPLIS.Web.FrameWork.Authentication;
using MPLIS.Web.FrameWork.PluginManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AppCore.Models;
using System.Collections;
using System.Data.Entity;
using MPLIS.Libraries.Data.SSO.Models;
using AutoMapper;
using MPLIS.Libraries.Data.SSO.Interfaces;

namespace MPLIS.Web.FrameWork.Base
{
    public class BaseController : MPLISController
    {
        protected const int tinhType = 2;
        protected const int huyenType = 3;
        private MplisEntities _dataContext = new MplisEntities();
        private CustomUser _CustomUser;
        public BaseController() : base()
        {

        }
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            //base.OnAuthorization(filterContext);
        }

        protected virtual CustomUser CurrentUser
        {
            get
            {
                if (_CustomUser == null)
                {
                    BSUserInfor ui = (BSUserInfor)Session["BSUserInfor"];
                    if (ui != null)
                    {
                        _CustomUser = new CustomUser();
                        _CustomUser.ID = ui.UserInfo.User.NGUOIDUNGID;
                        _CustomUser.UserName = ui.UserInfo.User.TENDANGNHAP;
                        _CustomUser.HOTENNGUOIDUNG = ui.UserInfo.User.HOTENNGUOIDUNG;
                        _CustomUser.GIOITINH = ui.UserInfo.User.GIOITINH;
                        _CustomUser.SODIENTHOAI = ui.UserInfo.User.SODIENTHOAI;
                        _CustomUser.SODIENTHOAI2 = ui.UserInfo.User.SODIENTHOAI2;
                        _CustomUser.EMAIL = ui.UserInfo.User.EMAIL;
                        _CustomUser.DIACHI = ui.UserInfo.User.DIACHI;
                        _CustomUser.LOAINGUOIDUNG = ui.UserInfo.User.LOAINGUOIDUNG == null ? "" : ((decimal)ui.UserInfo.User.LOAINGUOIDUNG).ToString("N0");
                        _CustomUser.CAPNGUOIDUNG = ui.UserInfo.User.CAPNGUOIDUNG;
                        _CustomUser.MADONVIHANHCHINH = ui.UserInfo.ToChuc.DONVIHANHCHINHID;
                        _CustomUser.CurKVHCID = ui.UserInfo.User.DONVIHANHCHINHID;
                    }
                }

                return _CustomUser;
            }
        }

        public HC_DMKVHC CurXa
        {
            get
            {
                if (CurrentUser.CurKVHCID != null)
                {
                    BSUserInfor ui = (BSUserInfor)Session["BSUserInfor"];
                    if (ui.UserInfo.ToChucKVHC.Contains(_CustomUser.CurKVHCID))
                    {
                        IDMKVHC kvhc = (IDMKVHC)ui.UserInfo.ToChucKVHC[_CustomUser.CurKVHCID];
                        if (kvhc.MAKVHC != null && kvhc.MAKVHC.Length == 10)
                        {
                            SSOHcXa xa = (SSOHcXa)ui.UserInfo.ToChucKVHC[_CustomUser.CurKVHCID];
                            return Mapper.Map<SSOHcXa, HC_DMKVHC>(xa);
                        }
                    }
                }
                return null;
            }
        }

        public HC_HUYEN CurHuyen
        {
            get
            {
                if (CurrentUser.CurKVHCID != null)
                {
                    BSUserInfor ui = (BSUserInfor)Session["BSUserInfor"];
                    if (ui.UserInfo.ToChucKVHC.Contains(_CustomUser.CurKVHCID))
                    {
                        IDMKVHC kvhc = (IDMKVHC)ui.UserInfo.ToChucKVHC[_CustomUser.CurKVHCID];
                        if(kvhc.MAKVHC != null && kvhc.MAKVHC.Length == 10)
                        {
                            SSOHcXa xa = (SSOHcXa)ui.UserInfo.ToChucKVHC[_CustomUser.CurKVHCID];
                            SSOHcHuyen huyen = (SSOHcHuyen)ui.UserInfo.ToChucKVHC[xa.HUYENID];
                            return Mapper.Map<SSOHcHuyen, HC_HUYEN>(huyen);
                        }
                    }
                }
                return null;
            }
        }

        public HC_TINH CurTinh
        {
            get
            {
                if (CurrentUser.CurKVHCID != null)
                {
                    BSUserInfor ui = (BSUserInfor)Session["BSUserInfor"];
                    if (ui.UserInfo.ToChucKVHC.Contains(_CustomUser.CurKVHCID))
                    {
                        IDMKVHC kvhc = (IDMKVHC)ui.UserInfo.ToChucKVHC[_CustomUser.CurKVHCID];
                        if (kvhc.MAKVHC != null && kvhc.MAKVHC.Length == 10)
                        {
                            SSOHcXa xa = (SSOHcXa)ui.UserInfo.ToChucKVHC[_CustomUser.CurKVHCID];
                            SSOHcHuyen h = (SSOHcHuyen)ui.UserInfo.ToChucKVHC[xa.HUYENID];
                            SSOHcTinh t = (SSOHcTinh)ui.UserInfo.ToChucKVHC[h.TINHID];
                            return Mapper.Map<SSOHcTinh, HC_TINH>(t);
                        }
                    }
                }
                return null;
            }
        }

        //public string getMAXA()
        //{
        //    if (_CustomUser.CurKVHCID != null)
        //    {
        //        SSOUserLoginInfors ui = (SSOUserLoginInfors)Session["BSUserInfor"];
        //        if (ui.ToChucKVHC.Contains(_CustomUser.CurKVHCID))
        //        {
        //            SSOHcXa xa = (SSOHcXa)ui.ToChucKVHC[_CustomUser.CurKVHCID];
        //            return xa.MAXA;
        //        }
        //    }
        //    return null;
        //}
        //public string XAID
        //{
        //    get
        //    {
        //        if (_CustomUser.CurKVHCID != null)
        //        {
        //            SSOUserLoginInfors ui = (SSOUserLoginInfors)Session["BSUserInfor"];
        //            if (ui.ToChucKVHC.Contains(_CustomUser.CurKVHCID))
        //            {
        //                SSOHcXa xa = (SSOHcXa)ui.ToChucKVHC[_CustomUser.CurKVHCID];
        //                return xa.XAID;
        //            }
        //        }
        //        return null;
        //    }
        //}

        //public string HUYENID
        //{
        //    get
        //    {
        //        if (_CustomUser.CurKVHCID != null)
        //        {
        //            SSOUserLoginInfors ui = (SSOUserLoginInfors)Session["BSUserInfor"];
        //            if (ui.ToChucKVHC.Contains(_CustomUser.CurKVHCID))
        //            {
        //                SSOHcXa xa = (SSOHcXa)ui.ToChucKVHC[_CustomUser.CurKVHCID];
        //                SSOHcHuyen h = (SSOHcHuyen)ui.ToChucKVHC[xa.HUYENID];
        //                return h.HUYENID;
        //            }
        //        }
        //        return null;
        //    }
        //}
        //public string getMAHUYEN()
        //{
        //    if (_CustomUser.CurKVHCID != null)
        //    {
        //        SSOUserLoginInfors ui = (SSOUserLoginInfors)Session["BSUserInfor"];
        //        if (ui.ToChucKVHC.Contains(_CustomUser.CurKVHCID))
        //        {
        //            SSOHcXa xa = (SSOHcXa)ui.ToChucKVHC[_CustomUser.CurKVHCID];
        //            SSOHcHuyen h = (SSOHcHuyen)ui.ToChucKVHC[xa.HUYENID];
        //            return h.MAHUYEN;
        //        }
        //    }
        //    return null;
        //}
        //public string CurTinh == null ? "" : CurTinh.MATINH
        //{
        //    if (_CustomUser.CurKVHCID != null)
        //    {
        //        SSOUserLoginInfors ui = (SSOUserLoginInfors)Session["BSUserInfor"];
        //        if (ui.ToChucKVHC.Contains(_CustomUser.CurKVHCID))
        //        {
        //            SSOHcXa xa = (SSOHcXa)ui.ToChucKVHC[_CustomUser.CurKVHCID];
        //            SSOHcHuyen h = (SSOHcHuyen)ui.ToChucKVHC[xa.HUYENID];
        //            SSOHcTinh t = (SSOHcTinh)ui.ToChucKVHC[h.TINHID];
        //            return t.MATINH;
        //        }
        //    }
        //    return null;
        //}
        //public string getTINHID()
        //{
        //    if (_CustomUser.CurKVHCID != null)
        //    {
        //        SSOUserLoginInfors ui = (SSOUserLoginInfors)Session["BSUserInfor"];
        //        if (ui.ToChucKVHC.Contains(_CustomUser.CurKVHCID))
        //        {
        //            SSOHcXa xa = (SSOHcXa)ui.ToChucKVHC[_CustomUser.CurKVHCID];
        //            SSOHcHuyen h = (SSOHcHuyen)ui.ToChucKVHC[xa.HUYENID];
        //            SSOHcTinh t = (SSOHcTinh)ui.ToChucKVHC[h.TINHID];
        //            return t.TINHID;
        //        }
        //    }
        //    return null;
        //}

        //public enum tencauhinh
        //{
        //    XAID, HUYENID, TINHID, UNGDUNGID, MAXA, MAHUYEN, MATINH, SESID, KETNOI
        //}

        //public Boolean CheckToChucNguoiDung(string idnguoidung)
        //{
        //    var objND = _dataContext.HT_TOCHUC_NGUOIDUNG.FirstOrDefault(x => x.NGUOIDUNGID == idnguoidung);
        //    if (objND != null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public string GetCauHinhNguoiDung(tencauhinh tch, string nguoidungID)
        //{
        //    string tencauhinh = tch.ToString();
        //    string giatri;
        //    var objcauhinh = _dataContext.HT_CAUHINHNGUOIDUNG.FirstOrDefault(x => x.TENCAUHINH == tencauhinh && x.NGUOIDUNGID == nguoidungID);
        //    if (objcauhinh == null)
        //    {
        //        return giatri = null;
        //    }
        //    else
        //    {
        //        return giatri = objcauhinh.GIATRI;
        //    }
        //}

        //public void SetCauHinhNguoiDung(tencauhinh tch, string giatri, string nguoidungid)
        //{
        //    string tencauhinh = tch.ToString();
        //    //Check if duplicate config
        //    var objcauhinhList = (from x in _dataContext.HT_CAUHINHNGUOIDUNG
        //                          where (x.TENCAUHINH == tencauhinh && x.NGUOIDUNGID == nguoidungid)
        //                          select x
        //                           ).ToList();
        //    if (objcauhinhList.Count > 1)
        //    {
        //        //delete all config
        //        foreach (var item in objcauhinhList)
        //        {
        //            _dataContext.HT_CAUHINHNGUOIDUNG.Remove(item);
        //            _dataContext.SaveChanges();
        //        }
        //        objcauhinhList = new List<HT_CAUHINHNGUOIDUNG>();
        //    }

        //    var objcauhinh = objcauhinhList.FirstOrDefault();
        //    //Fix
        //    if (objcauhinh == null)
        //    {
        //        InsertCauHinh(tencauhinh, giatri, nguoidungid);
        //    }
        //    else
        //    {
        //        UpdateCauHinh(tencauhinh, giatri, nguoidungid);
        //    }
        //}

        //public void InsertCauHinh(string tencauhinh, string giatri, string nguoidungid)
        //{
        //    HT_CAUHINHNGUOIDUNG objcauhinh = new HT_CAUHINHNGUOIDUNG();
        //    objcauhinh.CAUHINHNGUOIDUNGID = TaoIdTheoChuan();
        //    objcauhinh.NGUOIDUNGID = nguoidungid;
        //    objcauhinh.TENCAUHINH = tencauhinh;
        //    objcauhinh.GIATRI = giatri;
        //    objcauhinh.NGUOICAPNHATID = CurrentUser.ID;
        //    _dataContext.HT_CAUHINHNGUOIDUNG.Add(objcauhinh);
        //    _dataContext.SaveChanges();
        //}

        //public void UpdateCauHinh(string tencauhinh, string giatri, string nguoidungid)
        //{
        //    HT_CAUHINHNGUOIDUNG objcauhinh = _dataContext.HT_CAUHINHNGUOIDUNG.FirstOrDefault(x => x.TENCAUHINH == tencauhinh && x.NGUOIDUNGID == nguoidungid);
        //    objcauhinh.GIATRI = giatri;
        //    _dataContext.Entry(objcauhinh).State = EntityState.Modified;
        //    _dataContext.SaveChanges();
        //}

        //public void DeleteCauHinh(string tencauhinh, string nguoidungid)
        //{
        //    HT_CAUHINHNGUOIDUNG objcauhinh = _dataContext.HT_CAUHINHNGUOIDUNG.FirstOrDefault(x => x.TENCAUHINH == tencauhinh && x.NGUOIDUNGID == nguoidungid);
        //    _dataContext.Entry(objcauhinh).State = EntityState.Deleted;
        //    _dataContext.SaveChanges();
        //}

        protected virtual string GetErrorMessage()
        {
            var allErrors = ModelState.Values.SelectMany(it => it.Errors);
            var msg = "";
            foreach (var err in allErrors)
            {
                msg += err.ErrorMessage + "</br>";
            }
            return msg;
        }

        public string TaoIdTheoChuan()
        {
            return Guid.NewGuid().ToString().Replace("-", "").ToUpper();
        }

        public virtual void UpdateSession(string taskId, string typetaskId, string objectref, string actionId, string processId)
        {

        }


        public IEnumerable<HC_DMKVHC> ListXaFromDONVIHANHCHINH(string cap, string donvihanhchinhid)
        {
            List<HC_DMKVHC> ret;
            SSOHcXa xa;
            BSUserInfor ui = (BSUserInfor)Session["BSUserInfor"];
            if (cap == "1")
                return null;
            if (cap == "2")
            {
                if (ui.UserInfo.ToChucKVHC.Contains(donvihanhchinhid))
                {
                    ret = new List<HC_DMKVHC>();
                    foreach (var obj in ui.UserInfo.ToChucKVHC)
                    {
                        if (obj.GetType() == typeof(SSOHcXa))
                        {
                            xa = (SSOHcXa)obj;
                            ret.Add(Mapper.Map<SSOHcXa, HC_DMKVHC>(xa));
                        }
                    }
                }
                else
                    ret = (from t in _dataContext.HC_TINH
                           join h in _dataContext.HC_HUYEN on t.TINHID equals h.TINHID into j1
                           where t.TINHID == donvihanhchinhid
                           from th in j1.DefaultIfEmpty()
                           join x in _dataContext.HC_DMKVHC on th.HUYENID equals x.HUYENID into j2
                           from thx in j2.DefaultIfEmpty()
                           select thx
                ).ToList();
                return ret;
            }
            if (cap == "3")
                return (from x in _dataContext.HC_DMKVHC
                        where x.HUYENID == donvihanhchinhid
                        select x).ToList();
            return (from x in _dataContext.HC_DMKVHC where x.KVHCID == donvihanhchinhid select x).ToList();
        }

        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }
    }

    //public class ObjectRef
    //{
    //    public Guid ObjectId { get; set; }
    //    public string ObjectType { get; set; }
    //}
}
