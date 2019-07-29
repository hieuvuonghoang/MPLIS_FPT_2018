using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;
using Newtonsoft.Json;

namespace AppCore.Models
{
    public partial class QT_QUYTRINH
    {
        public List<QT_BUOCQUYTRINH> DSBuocQuyTrinh { get; set; }
        public Hashtable CauHinhXuLy { get; set; }
        public QT_BUOCQUYTRINH CurBuocQuyTrinh { get; set; }
        public QT_NHOMQUYTRINH NhomQuyTrinh { get; set; }
        public int TRANGTHAI { get; set; }
        public string TENNHOMQUYTRINH { get; set; }
    }
}
