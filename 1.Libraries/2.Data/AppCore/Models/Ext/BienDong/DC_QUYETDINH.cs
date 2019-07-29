using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class DC_QUYETDINH
    {
        public bool isAdd { get; set; }

        public DC_QUYETDINH()
        {
            isAdd = true;
            //QUYETDINHID = Guid.NewGuid().ToString();
        }
        public DC_QUYETDINH(string soQuyetDinh)
        {
            isAdd = true;
            this.SOQUYETDINH = soQuyetDinh;
        }
    }
}
