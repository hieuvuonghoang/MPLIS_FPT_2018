using System;
using System.Collections.Generic;
using System.Linq;
using MPLIS.Libraries.Data.SSO.Models;
using AppCore.Models;
using System.Collections;
using AutoMapper;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Services.QTHT.Service
{
    public class UserManagerService
    {
        public static SSOUserLoginInfors GetUserInfor(string NGUOIDUNGID)
        {
            if (NGUOIDUNGID == null || NGUOIDUNGID == "") return null;
            SSOUserLoginInfors Us = new SSOUserLoginInfors();
            SSOHcTinh sTinh;
            SSOHcHuyen sHuyen;
            SSOHcXa sXa;
            SSOHtQuyen sQuyen;
            Hashtable cXa = new Hashtable(), cHuyen = new Hashtable();
            string tenQuyen = "";

            using (MplisEntities db = new MplisEntities())
            {
                //Lấy thông tin tổ chức của người dùng
                var TcInf = (from tcnd in db.HT_TOCHUC_NGUOIDUNG.Where(i => i.NGUOIDUNGID.Equals(NGUOIDUNGID))
                             select new
                             {
                                 tcnd,
                                 tc = db.HT_TOCHUC.Where(i => i.TOCHUCID.Equals(tcnd.TOCHUCID)).FirstOrDefault()
                             }).FirstOrDefault();
                if (TcInf != null && TcInf.tc != null)
                {
                    Us.ToChucNguoiDung = Mapper.Map<HT_TOCHUC_NGUOIDUNG, SSOHtToChucNguoiDung>(TcInf.tcnd);
                    Us.ToChuc = Mapper.Map<HT_TOCHUC, SSOHtToChuc>(TcInf.tc);

                    #region "Lấy các thông tin liên quan tổ chức"
                    #region "KVHC - tổ chức"
                    switch (Us.ToChuc.CAPTOCHUC)
                    {
                        case 1:     //cấp trung ương - do nothing
                            break;
                        case 2:     //cấp tỉnh - lấy toàn bộ cây hành chính cấp tỉnh
                                    //lấy tỉnh
                            var hcT = (from t in db.HC_TINH.Where(i => i.TINHID.Equals(Us.ToChuc.DONVIHANHCHINHID))
                                       select t).FirstOrDefault();
                            if (hcT != null)
                            {
                                sTinh = Mapper.Map<HC_TINH, SSOHcTinh>(hcT);
                                Us.ToChucKVHC.Add(sTinh.TINHID, sTinh);
                                //lấy huyện theo tỉnh
                                var hcH = (from h in db.HC_HUYEN
                                           where h.MAKVHC.StartsWith(sTinh.MAKVHC)
                                           select h).ToList();
                                if (hcH != null)
                                {
                                    foreach (var it in hcH)
                                    {
                                        sHuyen = Mapper.Map<HC_HUYEN, SSOHcHuyen>(it);
                                        Us.ToChucKVHC.Add(sHuyen.HUYENID, sHuyen);
                                    }

                                    //lấy xã theo tỉnh
                                    var hcXa = (from x in db.HC_DMKVHC
                                                where x.MAKVHC.StartsWith(sTinh.MAKVHC)
                                                select x).ToList();
                                    if (hcH != null)
                                    {
                                        foreach (var it in hcXa)
                                        {
                                            sXa = Mapper.Map<HC_DMKVHC, SSOHcXa>(it);
                                            if (!Us.ToChucKVHC.Contains(sXa.KVHCID)) Us.ToChucKVHC.Add(sXa.KVHCID, sXa);
                                        }
                                    }
                                }
                            }
                            break;
                        case 3:     //cấp huyện
                                    //lấy huyện
                            var hcHuyen = (from t in db.HC_HUYEN.Where(i => i.HUYENID.Equals(Us.ToChuc.DONVIHANHCHINHID))
                                           select t).FirstOrDefault();
                            if (hcHuyen != null)
                            {
                                sHuyen = Mapper.Map<HC_HUYEN, SSOHcHuyen>(hcHuyen);
                                Us.ToChucKVHC.Add(sHuyen.HUYENID, sHuyen);

                                //lấy tỉnh của huyện
                                var hcT1 = (from t in db.HC_TINH.Where(i => i.TINHID.Equals(sHuyen.TINHID))
                                            select t).FirstOrDefault();
                                if (hcT1 != null)
                                {
                                    sTinh = Mapper.Map<HC_TINH, SSOHcTinh>(hcT1);
                                    if (!Us.ToChucKVHC.Contains(sTinh.TINHID)) Us.ToChucKVHC.Add(sTinh.TINHID, sTinh);
                                }

                                //lấy xã theo huyện
                                var hcXa = (from xa in db.HC_DMKVHC.Where(i => i.HUYENID.Equals(hcHuyen.HUYENID))
                                            select xa).ToList();
                                if (hcXa != null)
                                {
                                    foreach (var it in hcXa)
                                    {
                                        sXa = Mapper.Map<HC_DMKVHC, SSOHcXa>(it);
                                        if (!Us.ToChucKVHC.Contains(sXa.KVHCID)) Us.ToChucKVHC.Add(sXa.KVHCID, sXa);
                                    }
                                }

                            }
                            break;
                        default:    //cấp xã
                            var hcXa1 = (from t in db.HC_DMKVHC.Where(i => i.KVHCID.Equals(Us.ToChuc.DONVIHANHCHINHID))
                                         select t).FirstOrDefault();
                            if (hcXa1 != null)
                            {
                                sXa = Mapper.Map<HC_DMKVHC, SSOHcXa>(hcXa1);
                                if (!Us.ToChucKVHC.Contains(sXa.KVHCID)) Us.ToChucKVHC.Add(sXa.KVHCID, sXa);
                                //lấy huyện
                                var hcHuyen1 = (from t in db.HC_HUYEN.Where(i => i.HUYENID.Equals(sXa.HUYENID))
                                                select t).FirstOrDefault();
                                if (hcHuyen1 != null)
                                {
                                    sHuyen = Mapper.Map<HC_HUYEN, SSOHcHuyen>(hcHuyen1);
                                    if (!Us.ToChucKVHC.Contains(sHuyen.HUYENID)) Us.ToChucKVHC.Add(sHuyen.HUYENID, sHuyen);
                                    //lấy tỉnh
                                    var hcT1 = (from t in db.HC_TINH.Where(i => i.TINHID.Equals(sHuyen.TINHID))
                                                select t).FirstOrDefault();
                                    if (hcT1 != null)
                                    {
                                        sTinh = Mapper.Map<HC_TINH, SSOHcTinh>(hcT1);
                                        if (!Us.ToChucKVHC.Contains(sTinh.TINHID)) Us.ToChucKVHC.Add(sTinh.TINHID, sTinh);
                                    }
                                }
                            }
                            break;
                    }
                    #endregion

                    #region "Quyền/Menu - tổ chức"
                    //lấy danh sách nhóm chức năng của tổ chức
                    var ncn = (from tcncn in db.HT_TOCHUC_NHOMCHUCNANG.Where(i => i.TOCHUCID.Equals(Us.ToChuc.TOCHUCID))
                               select new
                               {
                                   tcncn,
                                   ncn = db.HT_NHOMCHUCNANG.Where(i => i.NHOMCHUCNANGID.Equals(tcncn.NHOMCHUCNANGID)).FirstOrDefault()
                               }).ToList();
                    if (ncn != null && ncn.Count > 0)
                    {
                        List<string> NCNIds = new List<string>();
                        foreach (var it in ncn)
                        {
                            if (it.ncn != null)
                                NCNIds.Add(it.ncn.NHOMCHUCNANGID);
                        }

                        if (NCNIds.Count > 0)
                        {
                            #region "Quyền - tổ chức"
                            //lấy danh sách chức năng theo danh sách nhóm chức năng của tổ chức
                            var dscn = (from cnncn in db.HT_CHUCNANG_NHOMCHUCNANG.Where(i => NCNIds.Contains(i.NHOMCHUCNANGID))
                                        select new
                                        {
                                            cnncn,
                                            cn = db.HT_CHUCNANG.Where(i => i.CHUCNANGID.Equals(cnncn.CHUCNANGID)).FirstOrDefault(),
                                        }).ToList();
                            if (dscn != null && dscn.Count > 0)
                            {
                                List<string> CNIds = new List<string>();
                                foreach (var it in dscn)
                                {
                                    if (it.cn != null)
                                        CNIds.Add(it.cn.CHUCNANGID);
                                }
                                if (CNIds.Count > 0)
                                {
                                    //lấy danh sách quyền theo danh sách chức năng của tổ chức
                                    var dsq = (from q in db.HT_QUYEN.Where(i => CNIds.Contains(i.CHUCNANGID))
                                               select q).ToList();
                                    if (dsq != null && dsq.Count > 0)
                                    {
                                        foreach (var it in dsq)
                                        {
                                            sQuyen = Mapper.Map<HT_QUYEN, SSOHtQuyen>(it);
                                            if (!Us.ToChucQuyen.Contains(it.QUYENID)) Us.ToChucQuyen.Add(it.QUYENID, sQuyen);
                                        }
                                    }
                                }
                            }
                            #endregion

                            #region "Menu - Tổ chức"
                            //Lấy danh sách ứng dụng được chọn
                            var dsUD = (from ud in db.HT_UNGDUNG
                                        select ud).ToList();
                            SSOHtUngDung ud1;
                            foreach (var ud in dsUD)
                            {
                                ud1 = Mapper.Map<HT_UNGDUNG, SSOHtUngDung>(ud);
                                Us.AllUngDung.Add(ud1.UNGDUNGID, ud1);
                            }

                            var dsmn1 = (from ncnmn in db.HT_NHOMCHUCNANG_MENU.Where(i => NCNIds.Contains(i.NHOMCHUCNANGID))
                                         select new
                                         {
                                             ncnmn,
                                             mn = db.HT_MENU.Where(i => i.MENUID.Equals(ncnmn.MENUID)).Where(i => i.CHOPHEPSUDUNG.Equals("1")).FirstOrDefault(),
                                         }).OrderBy(i => i.mn.UNGDUNGID).OrderBy(i => i.mn.MAMENU);

                            //lấy danh sách chức năng theo danh sách nhóm chức năng của tổ chức
                            var dsmn = (from ncnmn in db.HT_NHOMCHUCNANG_MENU.Where(i => NCNIds.Contains(i.NHOMCHUCNANGID))
                                        select new
                                        {
                                            ncnmn,
                                            mn = db.HT_MENU.Where(i => i.MENUID.Equals(ncnmn.MENUID)).Where(i => i.CHOPHEPSUDUNG.Equals("1")).FirstOrDefault(),
                                        }).OrderBy(i => i.mn.UNGDUNGID).OrderBy(i => i.mn.MAMENU).ToList();
                            if (dsmn != null && dsmn.Count > 0)
                            {
                                //tách riêng menu theo ứng dụng
                                List<SSOHtMenu> UDMenu;
                                SSOHtMenu it;
                                Hashtable umid = new Hashtable();

                                for (int i = 0; i < dsmn.Count; i++)
                                {
                                    if (dsmn[i].mn != null)
                                        if (!umid.Contains(dsmn[i].mn.MENUID))
                                        {
                                            if (Us.ToChucMenu.Contains(dsmn[i].mn.UNGDUNGID))
                                            {
                                                UDMenu = (List<SSOHtMenu>)Us.ToChucMenu[dsmn[i].mn.UNGDUNGID];
                                                it = Mapper.Map<HT_MENU, SSOHtMenu>(dsmn[i].mn);
                                                UDMenu.Add(it);
                                            }
                                            else
                                            {
                                                UDMenu = new List<SSOHtMenu>();
                                                it = Mapper.Map<HT_MENU, SSOHtMenu>(dsmn[i].mn);
                                                UDMenu.Add(it);
                                                Us.ToChucMenu.Add(dsmn[i].mn.UNGDUNGID, UDMenu);
                                            }
                                            umid.Add(dsmn[i].mn.MENUID, dsmn[i].mn.MENUID);
                                            if (!Us.DSUngDung.Contains(dsmn[i].mn.UNGDUNGID))
                                            {
                                                ud1 = (SSOHtUngDung)Us.AllUngDung[dsmn[i].mn.UNGDUNGID];
                                                Us.DSUngDung.Add(ud1.UNGDUNGID, ud1);
                                            }
                                        }
                                }
                            }
                            #endregion
                        }
                    }
                    #endregion
                    #endregion
                }

                #region "Lấy các thông tin liên quan user"
                #region "Xã - người dùng"
                var hcXND = (from t in db.HT_XA_NGUOIDUNG.Where(i => i.NGUOIDUNGID.Equals(NGUOIDUNGID))
                             select new
                             {
                                 t,
                                 xa = db.HC_DMKVHC.Where(i => i.KVHCID.Equals(t.XAID)).FirstOrDefault()
                             }).OrderBy(i => i.xa.MAKVHC).ToList();

                if (hcXND != null && hcXND.Count > 0)
                {
                    foreach (var it in hcXND)
                    {
                        //cấu hình xã cho người dùng không được vượt cấp của tổ chức - chỉ lấy xã mà tổ chức của người dùng có quyền
                        if (it.xa != null && !cXa.Contains(it.xa.KVHCID) && Us.ToChucKVHC.Contains(it.xa.KVHCID))
                        {
                            Us.NguoiDungXa.Add(Mapper.Map<HC_DMKVHC, SSOHcXa>(it.xa));
                            cXa.Add(it.xa.KVHCID, it.xa.KVHCID);
                            if (!cHuyen.Contains(it.xa.HUYENID) && Us.ToChucKVHC.Contains(it.xa.HUYENID))
                            {
                                sHuyen = (SSOHcHuyen)Us.ToChucKVHC[it.xa.HUYENID];
                                Us.NguoiDungHuyen.Add(sHuyen);
                                cHuyen.Add(it.xa.HUYENID, it.xa.HUYENID);
                            }
                        }
                    }
                }
                #endregion

                #region "Quyền - người dùng"
                var qnd = (from t in db.HT_NGUOIDUNG_QUYEN.Where(i => i.NGUOIDUNGID.Equals(NGUOIDUNGID))
                           select new
                           {
                               t,
                               q = db.HT_QUYEN.Where(i => i.QUYENID.Equals(t.QUYENID)).FirstOrDefault()
                           }).ToList();
                if (qnd != null && qnd.Count > 0)
                {
                    foreach (var it in qnd)
                    {
                        sQuyen = Mapper.Map<HT_QUYEN, SSOHtQuyen>(it.q);
                        tenQuyen = (it.q.CONTROLLERNAME == null ? "" : it.q.CONTROLLERNAME) + "_" + (it.q.ACTIONNAME == null ? "" : it.q.ACTIONNAME);
                        if (it.q != null && !Us.NguoiDungQuyen.Contains(tenQuyen)) Us.NguoiDungQuyen.Add(tenQuyen, sQuyen);
                    }
                }
                #endregion

                //có thể vứt đống này đi vì không dùng
                //#region "Cấu hình người dùng"
                //var chnd = (from t in db.HT_CAUHINHNGUOIDUNG.Where(i => i.NGUOIDUNGID.Equals(user.NGUOIDUNGID))
                //            select t).ToList();
                //if (chnd != null && chnd.Count > 0)
                //{
                //    foreach (var it in chnd)
                //    {
                //        if (!Us.CauHinhNguoiDung.Contains(it.TENCAUHINH)) Us.CauHinhNguoiDung.Add(it.TENCAUHINH, it);
                //    }
                //}
                //#endregion
                #endregion

                //Us.Token = Utility.GetGuidHash();
                //Us.User = Mapper.Map<HT_NGUOIDUNG, SSOHtNguoiDung>(user);
                //Us.TokenExpires = DateTime.Now.AddHours(Config.AUTH_TOKEN_TIMEOUT_IN_HOURS);

                //cập nhật lại DONVIHANHCHINHID nếu cần
                //if (Us.User.DONVIHANHCHINHID == null)
                //{
                //    if (Us.NguoiDungXa.Count > 0)
                //    {
                //        string message = "";
                //        Us.User.DONVIHANHCHINHID = Us.NguoiDungXa[0].KVHCID;
                //        UpdateUser(Us.User, out message);
                //    }
                //}
            }
            return Us;
        }
        public static bool UpdateUser(SSOHtNguoiDung us, out string message)
        {
            bool ret = true;
            message = "Cập nhật thành công";
            HT_NGUOIDUNG user;

            try
            {
                if (us != null)
                {
                    user = Mapper.Map<SSOHtNguoiDung, HT_NGUOIDUNG>(us);
                    using (MplisEntities db = new MplisEntities())
                    {
                        db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Error:" + ex.ToString();
                ret = false;
            }

            return ret;
        }
    }
}
