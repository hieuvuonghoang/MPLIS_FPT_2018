using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models.ViewModels.TTGiayChungNhan
{
    public class hangmuc
    {
        public string H_ten { get; set; }
        public string H_dt { get; set; }
        public string H_dtsan { get; set; }
        public string H_ht { get; set; }
        public string H_cap { get; set; }
        public string H_th { get; set; }
    }
    public class thuadat
    {
        public string sothua { get; set; }
        public string soto { get; set; }
        public string diachi { get; set; }
        public string dientichpl { get; set; }
        public string bangchu { get; set; }
        public string hinhthucsudung { get; set; }
        public string mucdichsudung { get; set; }
        public string thoihansudung { get; set; }
        public string nguongocsudung { get; set; }
    }
    public class biendong
    {
        public string biendongid { get; set; }
        public string noidungbiendong { get; set; }
        public string ngaybiendong { get; set; }
       
    }

    public class nhao
    {
        public string N_loainhao { get; set; }
        public string N_dtxaydung { get; set; }
        public string N_dtsan { get; set; }
        public string N_hinhthucsohuu { get; set; }
        public string N_caphang { get; set; }
        public string N_thoihan { get; set; }
    }
    public class giaychungnhan
    {
        // biến động
        public List<biendong> Dsbiendong { get; set; }
        //ds thửa
        public List<thuadat> Dsthuadat { get; set; }
        // dsnhà
        public List<nhao> Dsnhao { get; set; }
        // công trình
        public string Tenloaicongtrinh { get; set; }
        public List<hangmuc> Dshangmuc { get; set; }
        //rừng
        public string R_loai { get; set; }
        public string R_dt { get; set; }
        public string R_nguon { get; set; }
        public string R_sh { get; set; }
        public string R_th { get; set; }
        //cây lâu năm
        public string C_loaicay { get; set; }
        public string C_dt { get; set; }
        public string C_ht { get; set; }
        public string C_th { get; set; }
        //giấy chứng nhận
        public string mavach { get; set; }
        public string G_ghichu { get; set; }
        public string G_sovaoso { get; set; }
        // chủ
        public string TENCHU1 { get; set; }
        public string sinhnamchu1 { get; set; }
        public string socmtchu1 { get; set; }
        public string ngaycmtchu1 { get; set; }
        public string noicmtchu1 { get; set; }
        public string diachichu1 { get; set; }
        public string TENCHU2 { get; set; }
        public string sinhnamchu2 { get; set; }
        public string socmtchu2 { get; set; }
        public string ngaycmtchu2 { get; set; }
        public string noicmtchu2 { get; set; }
        public string diachichu2 { get; set; }
        public string duongdansvg { get; set; }
        public string duongdanmuiten { get; set; }

    }
    public class ObjBienDong
    {
        // biến động
        public List<biendong> Dsbiendong { get; set; }
    }
}
