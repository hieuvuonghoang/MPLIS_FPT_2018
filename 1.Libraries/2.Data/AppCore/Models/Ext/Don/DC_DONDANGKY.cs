using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class DC_DONDANGKY
    {
        public List<DC_DANGKY_GCN> DSDangKyGCN { get; set; }
        public List<DC_DANGKY_NGUOI> DSDangKyChu { get; set; }
        public List<DC_DANGKY_THUA> DSDangKyThua { get; set; }
        public List<DC_DANGKY_TAISAN> DSDangKyTaiSan { get; set; }
        public List<DC_XACNHANDONDANGKY> DSXacNhan { get; set; }
        public DC_DANGKY_NGUOI CurDangKyNguoi { get; set; }
        public bool isInitData = false;

        //public void getData()
        //{
        //    using (MplisEntities db = new MplisEntities())
        //    {
        //        //lấy dữ liệu chủ liên quan
        //        var objchu = (from item in db.DC_NGUOI where item.NGUOIID == NGUOIID select item).FirstOrDefault();
        //        if (objchu != null)
        //        {
        //            Chu = objchu;
        //            Chu.getData();
        //        }

        //        //Lấy dữ liệu thửa liên quan
        //        var objThua = (from t1 in db.DC_QUYENSUDUNGDAT
        //                       join t2 in db.DC_THUADAT on t1.THUADATID equals t2.THUADATID
        //                       where t1.GIAYCHUNGNHANID == GIAYCHUNGNHANID
        //                       select new DC_QUYENSUDUNGDAT()
        //                       {
        //                           BDTHECHAPID = t1.BDTHECHAPID,
        //                           DC_BD_THECHAP = t1.DC_BD_THECHAP,
        //                           DONDANGKYID = t1.DONDANGKYID,
        //                           GIAYCHUNGNHANID = t1.GIAYCHUNGNHANID,
        //                           LAQUYENQUANLY = t1.LAQUYENQUANLY,
        //                           MUCDICHSUDUNGDATID = t1.MUCDICHSUDUNGDATID,
        //                           NGAYDANGKYTC = t1.NGAYDANGKYTC,
        //                           NGUOICAPNHATID = t1.NGUOICAPNHATID,
        //                           NGUOIID = t1.NGUOIID,
        //                           QUYENSUDUNGDATID = t1.QUYENSUDUNGDATID,
        //                           THOIDIEMCAPNHAT = t1.THOIDIEMCAPNHAT,
        //                           THOIDIEMKHOITAO = t1.THOIDIEMKHOITAO,
        //                           THUADATID = t1.THUADATID,
        //                           TRANGTHAIPL = t1.TRANGTHAIPL,
        //                           uId = t1.uId,
        //                           Thua = t2
        //                       }).ToList();
        //        DSQuyenSDDat = objThua;

        //        //Lấy dữ liệu tài sản liên quan
        //        var objTS = (from t1 in db.DC_QUYENSOHUUTAISAN
        //                     join t2 in db.DC_TAISANGANLIENVOIDAT on t1.TAISANGANLIENVOIDATID equals t2.TAISANGANLIENVOIDATID
        //                     where t1.GIAYCHUNGNHANID == GIAYCHUNGNHANID
        //                     select new DC_QUYENSOHUUTAISAN()
        //                     {
        //                         BDTHECHAPID = t1.BDTHECHAPID,
        //                         DC_BD_THECHAP = t1.DC_BD_THECHAP,
        //                         DONDANGKYID = t1.DONDANGKYID,
        //                         GIAYCHUNGNHANID = t1.GIAYCHUNGNHANID,
        //                         NGAYDANGKYTC = t1.NGAYDANGKYTC,
        //                         NGUOICAPNHATID = t1.NGUOICAPNHATID,
        //                         NGUOIID = t1.NGUOIID,
        //                         QUYENSOHUUTAISANID = t1.QUYENSOHUUTAISANID,
        //                         TAISANGANLIENVOIDATID = t1.TAISANGANLIENVOIDATID,
        //                         THOIDIEMCAPNHAT = t1.THOIDIEMCAPNHAT,
        //                         THOIDIEMKHOITAO = t1.THOIDIEMKHOITAO,
        //                         TRANGTHAIPL = t1.TRANGTHAIPL,
        //                         uId = t1.uId,
        //                         TaiSanGanLienVoiDat = t2
        //                     }).ToList();
        //        foreach (var ts in objTS)
        //        {
        //            ts.TaiSanGanLienVoiDat.getData();
        //        }
        //        DSQuyenSHTTS = objTS;

        //        //Lấy các giấy chứng nhận cha
        //        var objGCNGCN = (from item in db.DC_BD_GCN_GCN where item.GCNCHAID == GIAYCHUNGNHANID select item).ToList();
        //        if (objGCNGCN != null)
        //        {
        //            QHGcn_Gcn = objGCNGCN;
        //        }
        //    }

        //    isInitData = true;
        //}
    }
}
