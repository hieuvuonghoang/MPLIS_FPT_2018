using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;
using Newtonsoft.Json;

namespace MPLIS.Libraries.Data.QuanTriQuyTrinh.Models
{
    public class CauHinhXuLyVM
    {
        public List<QT_BUOCQUYTRINH> DSBuocQuyTrinh { get; set; }
        public List<HT_NGUOIDUNG> DSNguoiDung { get; set; }
        public List<HC_DMKVHC> DSKhuVucHanhChinh { get; set; }
        public Hashtable CauHinhXuLy { get; set; }
        public string JSONCauHinhXuLy
        {
            get
            {
                return JsonConvert.SerializeObject(CauHinhXuLy);
            }
            set
            {
                JSONCauHinhXuLy = value;
            }
        }
    }
}
