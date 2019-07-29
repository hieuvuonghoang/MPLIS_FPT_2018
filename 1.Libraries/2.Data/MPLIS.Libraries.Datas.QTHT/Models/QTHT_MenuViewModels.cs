using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore;
using AppCore.Models;
namespace MPLIS.Libraries.Data.QTHT.Models
{
    public class QTHT_MenuViewModels
    {

        public HT_MENU htmenu { get; set; }
        public HT_NHOMCHUCNANG htnhomchucnang { get; set; }
        public IList<HT_MENU> DanhSachMenu { get; set; }
        public HT_MENU MenuItem { get; set; }
        public Boolean chkSD { get; set; }
        public string TenMenuCha { get; set; }
        public HT_NHOMCHUCNANG NhomChucNangItem { get; set; }
        public IList<HT_NHOMCHUCNANG> DanhSachChucNang { get; set; }
        public HT_NHOMCHUCNANG_MENU NhomChucNangMenuItem { get; set; }
        public IList<HT_NHOMCHUCNANG_MENU> DanhSachNhomChucNangMenu { get; set; }
        public IList<HT_NHOMCHUCNANG> DanhSachNhomChucNangKhongThuoc { get; set; }
        public IList<HT_MENU> DanhSachChonMenu { get; set; }
        //public string manhomCN { get; set; }
        public Boolean chkChon { get; set; }
        public IList<HT_MENU> DanhSachCayCon { get; set; }
        public string TenMenu { get; set; }
        public string MenuID { get; set; }
        public IList<HT_MENU> DanhSachMenuPopup { get; set; }
        public string NutBam { get; set; }
        public string iconPhotoString { get; set; }
        public string IDpopup { get; set; }
        public string IDungdung { get; set; }

    }
}