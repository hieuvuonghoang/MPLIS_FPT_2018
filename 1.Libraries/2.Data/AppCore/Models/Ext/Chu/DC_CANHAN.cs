using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class DC_CANHAN
    {
        public DC_CANHAN()
        {
            DSGiayToTuyThan = new List<DC_GIAYTOTUYTHAN>();
            //CurGiayToTuyThan = new DC_GIAYTOTUYTHAN();
        }
        public string NGUOIID { get; set; }
        public List<DC_GIAYTOTUYTHAN> DSGiayToTuyThan { get; set; }
        public DC_GIAYTOTUYTHAN CurGiayToTuyThan { get; set; }
        public bool isInit = false;

        public bool isHasHeader { get; set; }

        //trạng thái thêm/sửa/xóa đối tượng : 
        // mặc định là 0 : không thay đổi
        // mặc định là 1 : thêm
        // mặc định là 2 : sửa
        // mặc định là 3 : xóa
        public int TRANGTHAI { get; set; }

        //Đối tượng 1: chủ hộ
        // 2: vợ chồng
        //3 :con thành viên
        public string DOI_TUONG { get; set; }
        public string QHVOICHUHOID { get; set; }
        //Đối tượng 1: cá nhân
        // 2: hộ gia đình
        //3 : vợ chồng
        // 4: tổ chức
        //5 : cộng đồng dân cư
        public string TEN_DOI_TUONG { get; set; }
        //1: Chồng
        //2: Vợ
        public string VO_CHONG { get; set; }
        //Đối tượng 1: cá nhân
        // 2: hộ gia đình
        //3 : vợ chồng
        // 4: tổ chức
        //5 : cộng đồng dân cư
        public string TYPE_CHU { get; set; }

        public string DOITUONGSUDUNGID { get; set; }

        //1 thêm mới cá nhân
        //2 sửa cá nhân
        //3 xóa cá nhân
        public string CO_DB { get; set; }
        public bool _CONSONG
        {
            get
            {
                if (CONSONG == null)
                    CONSONG = false;
                return CONSONG ?? false;
            }
            set
            {
                CONSONG = value;
            }
        }

        public void getData()
        {
            using (MplisEntities db = new MplisEntities())
            {
                var objgt = (from t2 in db.DC_GIAYTOTUYTHAN
                             where t2.CANHANID == CANHANID
                             orderby t2.THOIDIEMCAPNHAT descending
                             select t2).ToList();
                DSGiayToTuyThan = objgt;
            }
            isInit = true;
        }
        public void setHoTen()
        {
            HOTEN = HODEM + " " + TEN;
        }
        public bool FLAGSEARCH { get; set; }
        public string NHOMNGUOIVAITROID { get; set; }
    }
}
