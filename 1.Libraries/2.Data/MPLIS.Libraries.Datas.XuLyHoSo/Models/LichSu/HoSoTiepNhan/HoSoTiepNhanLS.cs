using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class HoSoTiepNhanLS
    {
        public DonDangKyLS DonDangKy { get; set; }
        public BienDongLS BienDong { get; set; }
        public List<FileDinhKemHoSoLS> DSFileDinhKem { get; set; }

        public Hashtable DSGiayChungNhan { get; set; }
        public Hashtable DSChu { get; set; }
        public Hashtable DSCaNhan { get; set; }
        public Hashtable DSThua { get; set; }
        public Hashtable DSTaiSan { get; set; }
        public Hashtable DSQuyenSoHuuTaiSan { get; set; }
        public Hashtable DSQuyenSuDungDat { get; set; }
        public Hashtable DSMDSDDat { get; set; }
        
        public HoSoTiepNhanLS()
        {
            DSGiayChungNhan = new Hashtable();
            DSChu = new Hashtable();
            DSCaNhan = new Hashtable();
            DSThua = new Hashtable();
            DSTaiSan = new Hashtable();
            DSQuyenSoHuuTaiSan = new Hashtable();
            DSQuyenSuDungDat = new Hashtable();
            DSMDSDDat = new Hashtable();
            DSFileDinhKem = new List<Models.FileDinhKemHoSoLS>();

        }

        #region "Get relate objects"
        //lấy giấy chứng nhận
        public GiayChungNhanLS GetGiayChungNhanLS(string GiayChungNhanID)
        {
            if (DSGiayChungNhan != null && DSGiayChungNhan.Contains(GiayChungNhanID)) return (GiayChungNhanLS)DSGiayChungNhan[GiayChungNhanID];
            else return null;
        }

        //lấy chủ
        public NguoiLS GetNguoiLS(string NguoiID)
        {
            if (DSChu != null && DSChu.Contains(NguoiID)) return (NguoiLS)DSChu[NguoiID];
            else return null;
        }

        //lấy thửa
        public ThuaDatLS GetThuaDatLS(string ThuaDatID)
        {
            if (DSThua != null && DSThua.Contains(ThuaDatID)) return (ThuaDatLS)DSThua[ThuaDatID];
            else return null;
        }

        //lấy tài sản
        public TaiSanLS GetTaiSanLS(string TaiSanID)
        {
            if (DSTaiSan != null && DSTaiSan.Contains(TaiSanID)) return (TaiSanLS)DSTaiSan[TaiSanID];
            else return null;
        }

        //lấy tài sản
        public QuyenSoHuuTaiSanLS GetQuyenSoHuuTaiSanLS(string QuyenSoHuuTaiSanID)
        {
            if (DSQuyenSoHuuTaiSan != null && DSQuyenSoHuuTaiSan.Contains(QuyenSoHuuTaiSanID)) return (QuyenSoHuuTaiSanLS)DSQuyenSoHuuTaiSan[QuyenSoHuuTaiSanID];
            else return null;
        }

        //lấy thửa
        public QuyenSuDungDatLS GetQuyenSuDungDatLS(string QuyenSuDungDatID)
        {
            if (DSQuyenSuDungDat != null && DSQuyenSuDungDat.Contains(QuyenSuDungDatID)) return (QuyenSuDungDatLS)DSQuyenSuDungDat[QuyenSuDungDatID];
            else return null;
        }
        #endregion

        #region "Properties"
        public string HOSOTIEPNHANID { get; set; }
        public string THUTUCHANHCHINHID { get; set; }
        public Nullable<byte> CAP { get; set; }
        public string DONVIHANHCHINHID { get; set; }
        public string SOBIENNHAN { get; set; }
        public string QUYENTIEPNHAN { get; set; }
        public string CANBOTIEPNHANID { get; set; }
        public Nullable<System.DateTime> NGAYTIEPNHANHOSO { get; set; }
        public Nullable<System.DateTime> NGAYHENTRAHOSO { get; set; }
        public string NGUOINOPHOSO { get; set; }
        public Nullable<byte> TUCACHNGUOINOPHOSO { get; set; }
        public string MOTATOMTAT { get; set; }
        public string SODIENTHOAI { get; set; }
        public string EMAIL { get; set; }
        public string SOGIAYTO { get; set; }
        public Nullable<byte> PHUONGPHAPNHANTHONGBAO { get; set; }
        public string DIACHINGUOINOPHS { get; set; }
        public string TENNGUOINHANKETQUA { get; set; }
        public Nullable<byte> TUCACHNGUOINHANKETQUA { get; set; }
        public string DIACHINGUOINHANKETQUA { get; set; }
        public string NGUOINHANKQHS { get; set; }
        public Nullable<System.DateTime> NGAYTRAKETQUA { get; set; }
        public string GHICHUTRAKETQUA { get; set; }
        public Nullable<byte> TINHTRANGHOSO { get; set; }
        public string XULYTHEOQUYTRINH { get; set; }
        public string TRANGTHAIHOSOID { get; set; }
        public string UID { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public Nullable<System.DateTime> NGAYHENLAYPHIEUCHUYENTHUE { get; set; }
        public string TENHOSO { get; set; }
        public Nullable<byte> LOAIHOSO { get; set; }
        public string MaKVHC { get; set; }
        public string TenKVHC { get; set; }
        public string TRANGTHAI { get; set; }
        #endregion
    }
}
