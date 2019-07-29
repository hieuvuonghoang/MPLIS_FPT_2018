using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class DC_VOCHONG
    {
        public DC_VOCHONG()
        {
            //CurCaNhan = new Models.DC_CANHAN();
        }
        public DC_CANHAN VoCN { get; set; }
        public DC_CANHAN ChongCN { get; set; }
        //trạng thái thêm/sửa/xóa đối tượng : 
        // mặc định là 0 : không thay đổi
        // mặc định là 1 : thêm
        // mặc định là 2 : sửa
        // mặc định là 3 : xóa
        public int TRANGTHAI { get; set; }
        public DC_CANHAN CurCaNhan { get; set; }
      
    }
}
