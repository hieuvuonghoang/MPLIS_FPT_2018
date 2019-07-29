using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class VoChongLS
    {
        //trạng thái thêm/sửa/xóa đối tượng : 
        // mặc định là 0 : không thay đổi
        // mặc định là 1 : thêm
        // mặc định là 2 : sửa
        // mặc định là 3 : xóa
        public int TRANGTHAI { get; set; }
        public CaNhanLS VoCN { get; set; }
        public CaNhanLS ChongCN { get; set; }
        public CaNhanLS CurCaNhan { get; set; }

        #region "Properties"
        public string VOCHONGID { get; set; }
        public string CHONG { get; set; }
        public string VO { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public string DIACHI { get; set; }
        public string CMTCHONG { get; set; }
        public string CMTVO { get; set; }
        #endregion
    }
}
