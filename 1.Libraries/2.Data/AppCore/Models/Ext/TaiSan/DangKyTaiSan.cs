using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public class DangKyTaiSan
    {
        public  DangKyTaiSan()
        {
            CurNhaRiengLe = new Models.DC_NHARIENGLE();
            CurCanHo = new Models.DC_CANHO();
            CurRungTrong = new Models.DC_RUNGTRONG();
            CurCayLauNam = new Models.DC_CAYLAUNAM();
            CurCongTrinhXayDung = new DC_CONGTRINHXAYDUNG();
            CurNhaChungCu = new DC_NHACHUNGCU();
            CurHangMucNgoaiCanHo = new DC_HANGMUCNGOAICANHO();
            CurCongTrinhNgam = new DC_CONGTRINHNGAM();
            CurHangMucCongTrinh = new DC_HANGMUCCONGTRINH();
            CurKhuChungCu = new DC_KHUCHUNGCU();
            lstNhaRiengLe = new List<Models.DC_NHARIENGLE>();
            lstCanHo = new List<Models.DC_CANHO>();
            lstRungTrong = new List<Models.DC_RUNGTRONG>();
            lstCayLauNam = new List<DC_CAYLAUNAM>();
            lstCongTrinhXayDung = new List<DC_CONGTRINHXAYDUNG>();
            lstCongTrinhNgam = new List<DC_CONGTRINHNGAM>();
            lstHangMucCongTrinh = new List<DC_HANGMUCCONGTRINH>();
            lstHangMucNgoaiCanHo = new List<DC_HANGMUCNGOAICANHO>();
            lstNhaChungCu = new List<DC_NHACHUNGCU>();
            lstKhuChungCu = new List<DC_KHUCHUNGCU>();

        }
        public string taisanganlienvoidat_ID { get; set; }
        public DC_NHARIENGLE CurNhaRiengLe { get; set; }
        public DC_CANHO CurCanHo { get; set; }
        public DC_RUNGTRONG CurRungTrong { get; set; }
        public DC_CAYLAUNAM CurCayLauNam { get; set; }
        public DC_CONGTRINHXAYDUNG CurCongTrinhXayDung { get; set; }
        public DC_HANGMUCCONGTRINH CurHangMucCongTrinh { get; set; }
        public DC_HANGMUCNGOAICANHO CurHangMucNgoaiCanHo { get; set; }
        public DC_CONGTRINHNGAM CurCongTrinhNgam { get; set; }
        public DC_NHACHUNGCU CurNhaChungCu { get; set; }
        public DC_KHUCHUNGCU CurKhuChungCu { get; set; }
        public List<DC_CANHO> lstCanHo { get; set; }
        public List<DC_RUNGTRONG> lstRungTrong { get; set; }
        public List<DC_CAYLAUNAM> lstCayLauNam { get; set; }
        public List<DC_NHARIENGLE> lstNhaRiengLe { get; set; }
        public List<DC_CONGTRINHXAYDUNG> lstCongTrinhXayDung { get; set; }
        public List<DC_KHUCHUNGCU> lstKhuChungCu { get; set; }
        public List<DC_NHACHUNGCU> lstNhaChungCu { get; set; }
        public List<DC_CONGTRINHNGAM> lstCongTrinhNgam { get; set; }
        public List<DC_HANGMUCNGOAICANHO> lstHangMucNgoaiCanHo { get; set; }
        public List<DC_HANGMUCCONGTRINH> lstHangMucCongTrinh { get; set; }
        public string tenxats { get; set; }
        public string mota { get; set; }
    }
    
}
