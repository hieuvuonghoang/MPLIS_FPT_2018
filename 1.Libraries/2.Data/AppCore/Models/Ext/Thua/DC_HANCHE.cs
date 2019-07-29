using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class DC_HANCHE
    {
        public DC_LOAIHANCHE LoaiHanChe { get; set; }
        public string TenLoaiHanChe { get; set; }
        public bool _ConHieuLuc
        {
            get
            {
                return CONHIEULUC == "Y" ? true : false;
            }
            set
            {
                if (value)
                    CONHIEULUC = "Y";
                else
                    CONHIEULUC = "N";
            }
        }
        public bool _HanCheMotPhan
        {
            get
            {
                return HANCHEMOTPHAN == "Y" ? true : false;
            }
            set
            {
                if (value)
                    HANCHEMOTPHAN = "Y";
                else
                    HANCHEMOTPHAN = "N";
            }
        }
        //0: Mặc định
        //1: Thêm mới
        //2: Cập nhật
        public int TRANGTHAI { get; set; }
    }
}
