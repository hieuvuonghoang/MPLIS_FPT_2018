using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class DC_HOGIADINH
    {
        public DC_HOGIADINH()
        {
            //DSHienThi = new List<Models.DSHienThiHoGiaDinh>();
            DSThanhVien = new List<DC_HOGIADINH_THANHVIEN>();
        }
        public List<DC_HOGIADINH_THANHVIEN> DSThanhVien { get; set; }
        public DC_HOGIADINH_THANHVIEN CurHGDThanhVien { get; set; }
        public DC_CANHAN ChuHoCN { get; set; }
        public DC_CANHAN VoChongCN { get; set; }
        public DC_CANHAN CurCaNhan { get; set; }
        //trạng thái thêm/sửa/xóa đối tượng : 
        // mặc định là 0 : không thay đổi
        // mặc định là 1 : thêm
        // mặc định là 2 : sửa
        // mặc định là 3 : xóa
        public int TRANGTHAI { get; set; }
        public string DOITUONGSUDUNGID { get; set; }
        public List<DSHienThiHoGiaDinh> DSHienThi { get; set; }
        public string CHUHO_HOTEN { get; set; }
        public string VOCHONG_HOTEN { get; set; }
        public void  SetThongTinHoGiaDinh()
        {
            CMTCHUHO = null;
            CHUHO_HOTEN = null;
            CHUHO = null;
            CMTVOCHONG = null;
            VOCHONG_HOTEN = null;
            VOCHONG = null;
            foreach (var temp in DSThanhVien)
            {
                if(temp.QHVOICHUHOID == "DBE8EB8DA18049ED8E253B2685769746")
                {
                    CMTCHUHO = temp.ThanhVien.SOGIAYTO;
                    CHUHO_HOTEN = temp.ThanhVien.HOTEN;
                    CHUHO = temp.ThanhVien.CANHANID;
                } else if(temp.QHVOICHUHOID == "CD487A3FFF9B45B3BAC998F80F68622C" || temp.QHVOICHUHOID == "87D621F7C7004637BD871BAB0D97068D")
                {
                    CMTVOCHONG = temp.ThanhVien.SOGIAYTO;
                    VOCHONG_HOTEN = temp.ThanhVien.HOTEN;
                    VOCHONG = temp.ThanhVien.CANHANID;
                }
            }
        }
    }

    public class DSHienThiHoGiaDinh
    {
        public string CANHANID { get; set; }
        public string HOTEN { get; set; }
        public string SOGIAYTO { get; set; }
        public string QUANHE { get; set; }
    }
}
