using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace AppCore.Models
{
    public partial class QT_TTHC_QUYTRINH
    {
        public QT_QUYTRINH QuyTrinh { get; set; }
        //0: Mặc định
        //1: Thêm mới
        //2: Chỉnh sửa
        //3: Xóa
        public int TRANGTHAI { get; set; }
        public string TenQuyTrinh { get; set; }
    }
}
