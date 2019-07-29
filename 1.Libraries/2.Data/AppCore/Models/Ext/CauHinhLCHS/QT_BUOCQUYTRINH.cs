using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class QT_BUOCQUYTRINH
    {
        public List<QT_BUOCQT_CAUHINH> DSBuocQTCauHinh { get; set; }
        public List<QT_CONGVIECTHEOBUOC> DSCongViecTheoBuoc { get; set; }
        public QT_CONGVIECTHEOBUOC CurCongViecTheoBuoc { get; set; }
    }
}
